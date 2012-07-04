using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using Sys.Xmpp;
using System.Windows.Forms;
using Sys.ViewManager; 
using System.Data;
using Sys.Data;
using Sys.Workflow.Collaborative;
using Sys.DataManager;

namespace Sys.Workflow
{
    public class CollaborativeActivity : CollaborativeTask, IValizable 
    {
        public const string CONTEXT_TARGET_STATE = "TargetState";
        
        private CollaborativeWorkflowInstance workflowInstance;
        private State state;
 
    

        #region Constructor

        //create an activity
        public CollaborativeActivity(CollaborativeWorkflowInstance workflowInstance, State state)
            : base(workflowInstance, state)
        {
            this.workflowInstance = workflowInstance;
            this.state = state;

            SyncDS();
        }

  

        //read activity
        public CollaborativeActivity(CollaborativeWorkflowInstance workflowInstance, VAL val)
            : base(workflowInstance, val)
        {
            this.workflowInstance = workflowInstance;
            this.state = this.WorkflowInstance.Workflow.States[this.Data.StateName];


            this.InitData(val);
        }




        public static CollaborativeActivity NewInsance(int workflowInstanceID, string stateName, Type workflowInstanceType)
        {
            CollaborativeWorkflowInstance workflowInstance = CollaborativeWorkflowInstance.NewInstance(workflowInstanceID, workflowInstanceType );
            VAL val = workflowInstance.Evaluate(workflowInstance.Activities.Path + "." + stateName);
                
            CollaborativeActivity activity = new CollaborativeActivity(workflowInstance, val);

            workflowInstance.Activities.Add(activity);

            return activity; 
        }


        #endregion


        public CollaborativeWorkflowInstance WorkflowInstance { get { return this.workflowInstance; } }
        public State State { get { return this.state; } }


        #region StartActivity/CompleteActivity/Start/Complete

        private bool StartActivity()
        {
            if (!state.IsInitialState)
            {
                if(!Alive)
                     throw new ApplicationException(string.Format("{0} is never activiated", this));

                if (!DoDependency(PrevActivity))
                    throw new ApplicationException(string.Format("{0} is not ready, it's still waiting.", this));
            }

            TrackDpo.AddTrack(this);    //track workflow instance

            this.Data.Activated = true;
            base.TryStartWork();

            DoPreaction();
            return true;
        }


        private CollaborativeActivityCollection CompleteActivity()
        {
         
            base.CompleteTask();
            SyncDS();

            if (this.state.IsFinalState)
                workflowInstance.Data.CompleteWorkflowInstance();

            CollaborativeActivityCollection nextActvities = new CollaborativeActivityCollection(this.workflowInstance);
            foreach (State S in this.state.NextStates)
            {
                CollaborativeActivity A = this.workflowInstance.Activities[S];
                if (A.Data.TaskStatus == TaskStatus.Closed)
                    continue;

                A.AddPrevActivity(this);
                if (A.DoDependency(this))
                {
                    this.AddNextActivity(A);
                    
                    nextActvities.Add(A);
                    A.Data.TaskStatus = TaskStatus.NotStarted;
                    A.Data.Read = false;
                    A.Data.Activated = true;

                    if (A.State.IsLogicalState)
                    {
                        //Do logical state
                        WorkflowRuntime.StartLogicalActivity(this.Form, A);

                        if (A.State.IsFinalState)
                        {
                            return nextActvities;
                        }
                    }

                    //if (A.State.IsAgentState)
                    //{
                    //    A.AssignTaskTo(MachineID);
                    //    A.Start();
                    //    A.DoAfterAction();  //Monitor SQL Server
                        
                    //}
                }
            }

            return nextActvities;
        }


        public void Start()
        {
            this.StartActivity();
            Sync();
        }

        public void Complete()
        {
            CollaborativeActivityCollection nextActivities = this.CompleteActivity();
            DoPostaction();

            Sync();
            foreach (CollaborativeActivity activity in nextActivities)
                activity.Sync();

            this.WorkflowInstance.Save();
        }

        #endregion



        #region PrevActivities/NextActivities

        /// <summary>
        /// Activity has been born
        /// </summary>
        public bool Alive
        {
            get
            {
                if (state.IsInitialState)
                    return true;

                return PrevActivities.Count > 0;
            }
        }

        public CollaborativeActivity PrevActivity
        {
            get
            {
                if (Alive && PrevActivities.Count > 0)
                    return PrevActivities[0];
                else
                    return null;
            }
        }

        public CollaborativeActivityCollection PrevActivities 
        {
            get
            {
                CollaborativeActivityCollection activities = new CollaborativeActivityCollection(workflowInstance);
                
                VAL PS = this.Data.PS;
                foreach (VAL s in PS)
                {
                    activities.Add(workflowInstance.Activities[s.Str]);
                }
                return activities; 
            } 
        }

        public CollaborativeActivityCollection NextActivities 
        { 
            get 
            {
                CollaborativeActivityCollection activities = new CollaborativeActivityCollection(workflowInstance);

                VAL NS = this.Data.NS;
                foreach (VAL s in NS)
                {
                    activities.Add(workflowInstance.Activities[s.Str]);
                }
                return activities; 
            } 
        }

        private void AddPrevActivity(CollaborativeActivity activity)
        {
            State state = activity.State;

            VAL S = new VAL(state.StateName);
            if (S < this.Data.PS)
                return;


            VAL temp = this.Data.PS;
            VAL L = new VAL();
            L.Add(S);
            temp = L + temp;
            this.Data.PS = temp;

            Scope["PS"] = this.Data.PS;

            
        }

        private void AddNextActivity(CollaborativeActivity activity)
        {
            State state = activity.State;

            VAL S = new VAL(state.StateName);
            if (S < this.Data.NS)
                return;

            VAL temp = this.Data.NS;
            temp.Add(S);
            this.Data.NS = temp;

            Scope["NS"] = this.Data.NS;
        }

        #endregion


 

        #region DoDependency/DoPreaction/DoAction/DoPostaction
        
        public bool DoDependency(CollaborativeActivity fromActivity)
        {
            VAL val = workflowInstance.InvokeFunction(this.state.Data.StateDependency, new object[] { fromActivity, this, workflowInstance.Context });
            
            if (val.IsBool)
            {
                this.Data.Activated = val.Boolcon;
                return val.Boolcon;
            }
            
            return false;
        }

        

        //this state can be started?
        public void DoPreaction()
        {
            workflowInstance.InvokeFunction(this.state.Data.StatePreaction, new object[] { this, workflowInstance.Context});
        }

        
        private Form form;
        public Form Form { get { return this.form; } set { this.form = value; } }
        
        
        /// <summary>
        /// do real work, e.g. open a windows form
        /// </summary>
        /// <returns></returns>
        public Form DoAction()
        {
            VAL form = workflowInstance.InvokeFunction(this.State.Data.StateAction, new object[] { this, workflowInstance.Context });
            if (form.value is Form)
                this.form =  (Form)form.value;

            return this.form;
        }

        /// <summary>
        /// Do it  after Form Popup()
        /// </summary>
        /// <returns></returns>
        public void DoAfterAction()
        {
            workflowInstance.InvokeFunction(this.State.Data.StateAfterAction, new object[] { this, workflowInstance.Context });
        }

        
        /// <summary>
        /// Do it after Form closed
        /// </summary>
        /// <returns></returns>
        public VAL DoPostaction()
        {
            VAL val = workflowInstance.InvokeFunction(this.State.Data.StatePostaction, new object[] { this.form, this, this.Data});
            
            return val;
        }


        #endregion



        #region Listener

        [NonValized]
        private UserCollectionProtocol listeners = new UserCollectionProtocol();

        [Valizable]
        public VAL Listeners
        {
            get
            {
                return this.listeners.GetValData();
            }
            set
            {
                this.listeners = new UserCollectionProtocol(value);
            }
        }


        public void ListenTo(State state)
        {
            CollaborativeActivity host = this.workflowInstance.Activities[state];
            host.listeners.Add(new UserCollectionProtocol(this.Workers));
            host.Sync();
        }

        public void ListenTo(string stateName)
        {
            State state = this.workflowInstance.Workflow.States[stateName];
            ListenTo(state);
            
        }

        public void NotifyListeners(string text)
        {
            Xmpp.XmppClient.Instance.SendMessage(this.listeners, "Notification to listeners", text);
            
        }

        #endregion

        public TaskStatus TaskStatus
        {
            get
            {
                return this.Data.TaskStatus;
            }
        }


        public ActivityResult ActivityResult
        {
            get
            {
                if (this.Data.TaskStatus != TaskStatus.Completed)
                    return ActivityResult.None;

                return this.Data.ActivityResult;
            }

            set
            {
                this.Data.ActivityResult = value;
            }
        }


        [Valizable]
        public VAL Context
        {
            get 
            {
                if (Scope.Undefined)
                    return VAL.Array();

                VAL context = Scope[CollaborativeWorkflowInstance.NS_CONTEXT];
                if (context.Undefined)
                {
                    context = VAL.Array();
                    Scope.Add(CollaborativeWorkflowInstance.NS_CONTEXT, context);
                }

                return context;
            }
            set
            {
                if (value.Undefined || value.IsNull)
                    return;

                VAL context = Scope[CollaborativeWorkflowInstance.NS_CONTEXT];
                for (int i = 0; i < value.Size; i++)
                {
                    VAL v = value[i];
                    context[v[0].Str] = v[1];
                }
            }
        }



        #region Saving/Scope

        public override DataRow Save()
        {
            if (this.Data.PIN == 0)
                base.Save();  //save to generate WorkflowInstance identity ID# 

            SyncDS();

            this.Data.ActivityHeap = Scope.ToJson();

            return base.Save();
        }



        public void Sync()
        {
            if (Data.PIN != 0)
                Collaborative.WorkflowRuntime.SyncTask(this);
            else
            {
                Xmpp.XmppChannel channel = new Xmpp.XmppChannel(this.State.Data.StateChannel, this.State.Data.Title);
                Collaborative.WorkflowRuntime.SyncNewTask(channel, this);
            }
        }

        private void SyncDS()
        {
            //merge properties
            VAL states = workflowInstance.Evaluate(this.workflowInstance.Activities.Path);
            if (states[this.Data.StateName].Undefined)
                states[this.Data.StateName] = this.GetValData();
            else
            {
                VAL scope = states[this.Data.StateName];
                VAL val = this.GetValData();
                for (int i = 0; i < val.Size; i++)
                {
                       VAL v = val[i];
                       scope[v[0].Str] = v[1];
                }
            }
        }

        private VAL Scope
        {
            get
            {
                return workflowInstance.Evaluate(this.Path);
            }
        }

        public string Path
        {
            get
            {
                return string.Format("{0}.{1}", this.workflowInstance.Activities.Path, this.Data.StateName);
            }
        }

        #endregion



        public override string ToString()
        {
            return string.Format("Activity(ID={0}, State={1}, WorkflowInstance={2}, Workflow={3}, #Receivers={4})",
                this.Data.PIN, this.state.StateName, this.workflowInstance.Data.PIN, this.workflowInstance.Workflow.WorkflowName, this.Data.DpcReceived.Count);
        }













        #region Interface to Workflow/State definition


        /***
        /// <summary>
        /// return true if there is no prev state; this is initial state and workflowinstance from this state
        /// </summary>
        /// <returns></returns>
        public bool FromStartState()
        {
            return this.Data.PS.Size == 0;
        }

        public bool FromState(string stateName)
        {
            return this.Data.PS > new VAL(stateName);
        }


        public bool FromState(string stateName, ActivityResult result)
        {
            if (!FromState(stateName))
                return false;

            CollaborativeActivity activity = workflowInstance.Activities[stateName];

            return activity.ActivityResult == result;
        }

        public bool FromState(string stateName, TaskStatus status)
        {
            if (!FromState(stateName))
                return false;

            CollaborativeActivity activity = workflowInstance.Activities[stateName];

            return activity.TaskStatus == status;
        }

        /// <summary>
        /// return true if actvity came from [stateName] and completed
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public bool FromCompletedState(string stateName)
        {
            if (!FromState(stateName))
                return false;

            CollaborativeActivity activity = workflowInstance.Activities[stateName];

            if (activity.Data.TaskStatus != TaskStatus.Completed)
                return false;

            if (activity.Data.ActivityResult != ActivityResult.None)
                return false;

            return true;
        }

        **/


        public bool IsStateOf(string stateName)
        {
            return this.state.StateName == stateName;
        }

        public bool IsCompletedState(string stateName)
        {
            return IsStateOf(stateName, TaskStatus.Completed, ActivityResult.None);
        }

        public bool IsStateOf(string stateName, ActivityResult result)
        {
            return IsStateOf(stateName, TaskStatus.Completed, result);
        }

        public bool IsStateOf(string fromStateName, ActivityResult result, string toStateName)
        {
            return IsStateOf(fromStateName, TaskStatus.Completed, result, toStateName);
        }

        public bool IsStateOf(string stateName, TaskStatus status)
        {
            return IsStateOf(stateName, status, ActivityResult.None);
        }

        public bool IsStateOf(string stateName, TaskStatus status, ActivityResult result)
        {
            if (!IsStateOf(stateName))
                return false;

            return this.TaskStatus == status && this.ActivityResult == result;
        }

        public bool IsStateOf(string fromStateName, TaskStatus status, ActivityResult result, string toStateName)
        {
            if (!IsStateOf(fromStateName))
                return false;

            VAL v = this.Context[CollaborativeActivity.CONTEXT_TARGET_STATE];
            if (v.Undefined)
                return false; 
            
            if (v.Str != toStateName)
                return false;

            return this.TaskStatus == status && this.ActivityResult == result;
        }

        public CollaborativeActivity ActivityOf(string stateName)
        {
            return workflowInstance.Activities[stateName];
        }


        /// <summary>
        /// wait for all previous states to be [result]
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool WaitInboundStates(ActivityResult result)
        {
            foreach (State state in this.state.PrevStates)
            {
                CollaborativeActivity a = workflowInstance.Activities[state];
                if (a.ActivityResult != result)
                    return false;
            }
            return true;
        }


        #endregion


        #region Activity Agent

        private Agent agent = null;

        /// <summary>
        /// Add agent to activity, current only support ONE agent
        /// </summary>
        /// <param name="agent"></param>
        public void AddAgent(Agent agent)
        {
            this.agent = agent;
        }

        private void DoAgent()
        {
            workflowInstance.InvokeFunction(this.State.Data.StateAgent, new object[] { this, workflowInstance.Context });
        }

        /// <summary>
        /// Start agent
        /// </summary>
        /// <returns>false: if agent is not defined</returns>
        public bool StartAgent()
        {
            DoAgent();
            
            if (agent == null)
                return false;

            Monitor(this.agent);
            
            return true;
        }

        public void Monitor(Agent agent)
        {
            this.agent = agent;

          

            //don't monitor completed task
            if (Data.TaskStatus == TaskStatus.Completed)
                return ;

            agent.Finished = this.ActivityAgentFinished;
            Polling.Instance.AddAgent(this.Data.PIN.ToString(), agent);
        }

        private void ActivityAgentFinished(Agent agent)
        {
            Complete();
            
            //if (this.form != null)        //you cannot remove parent thread
        }

        /// <summary>
        /// Check the agent's data is completed
        /// </summary>
        internal void RefreshAgentData()
        {
             DoAgent();

            if (agent == null)
                return;
            
            if (Data.TaskStatus == TaskStatus.Completed)
                return;

            if (agent.DoJob())
            {
                TrackDpo.AddTrack(this);    //track workflow instance

                DataLocking.MustCheckIn(this.Task); //must check in no matter who check it out
                StartWork();
                Complete();
            }
        }

        #endregion

    }


}
