#define JSON
using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Data;
using Sys.Data;
using Sys.DataManager;


namespace Sys.Workflow
{


    public class CollaborativeWorkflowInstance : IValizable , ILockable
    {
        public const string NS_WORKFLOWINSTANCE = "WorkflowInstance";
        public const string NS_STATES = "States";
        public const string NS_CONTEXT = "Context";

        private Workflow workflow;
        private ICollaborativeWorkflowInstanceData workflowInstanceData;
        private CollaborativeActivityCollection activities;
        private Memory ds = new Memory();
      

        #region Constructors

        private CollaborativeWorkflowInstance(Workflow workflow, ICollaborativeWorkflowInstanceData workflowInstanceData)
        {
            this.workflow = workflow;
            this.workflowInstanceData = workflowInstanceData;
            this.activities = new CollaborativeActivityCollection(this);
        }


        //create new
        public static CollaborativeWorkflowInstance NewInstance(Workflow workflow, Type workflowInstanceDataType)
        {
            ICollaborativeWorkflowInstanceData data = (ICollaborativeWorkflowInstanceData)Activator.CreateInstance(workflowInstanceDataType);
            data.WorkflowName = workflow.WorkflowName;
            CollaborativeWorkflowInstance workflowInstance = new CollaborativeWorkflowInstance(workflow, data);
            return workflowInstance;
        }

   
        //create existed 
        public static CollaborativeWorkflowInstance NewInstance(Workflow workflow, Type workflowInstanceDataType, int workflowInstanceID)
        {
            ICollaborativeWorkflowInstanceData data = (ICollaborativeWorkflowInstanceData)Activator.CreateInstance(workflowInstanceDataType, new object[]{ workflowInstanceID} );
            CollaborativeWorkflowInstance workflowInstance = new CollaborativeWorkflowInstance(workflow, data);
            workflowInstance.ds = CollaborativeWorkflowInstance.LoadWorkflowInstance(data);
            workflowInstance.LoadActivities();
            return workflowInstance;
        }


        //used by task, create instance from VAL
        public static CollaborativeWorkflowInstance NewInstance(int workflowInstanceID, Type workflowInstanceDataType)
        {
            ICollaborativeWorkflowInstanceData data = (ICollaborativeWorkflowInstanceData)Activator.CreateInstance(workflowInstanceDataType, new object[] { workflowInstanceID });
            Memory ds = CollaborativeWorkflowInstance.LoadWorkflowInstance(data);
            VAL val = ds[Workflow.NS_WORKFLOW][data.WorkflowName];
            Workflow workflow = new Workflow(val);
            CollaborativeWorkflowInstance workflowInstance =  new CollaborativeWorkflowInstance(workflow, data);
            workflowInstance.ds = ds;
            workflowInstance.LoadActivities();
            return workflowInstance;
        }


        #endregion

        public Workflow Workflow
        {
            get
            {
                return this.workflow;
            }
        }

        
        public CollaborativeActivityCollection Activities
        {
            get
            {
                return activities;
            }
        }


        public ICollaborativeWorkflowInstanceData Data 
        { 
            get 
            { 
                return this.workflowInstanceData; 
            } 
        }


        public Memory DS
        {
            get
            {
                return this.ds;
            }
        }


        public VAL Evaluate(string expression)
        {
            return Script.Evaluate(expression, this.ds, new WorkflowFunction());
        }
        public VAL Evaluate(string scope, string expression)
        {
            return Script.Evaluate(scope, expression, this.ds, new WorkflowFunction());
        }

        public VAL Execute(string code)
        {
            return Script.Execute(code, this.ds, new WorkflowFunction());
        }

        public VAL Execute(string scope, string code)
        {
            return Script.Execute(scope, code, this.ds, new WorkflowFunction());
        }

        public VAL InvokeFunction(string function, object[] parameters)
        {
            return Script.InvokeFunction(
               this.ds,
               new VAL(),
               function,
               parameters,
               new WorkflowFunction());
        }

        /// <summary>
        /// retunr intial activites
        /// </summary>
        /// <returns></returns>
        private CollaborativeActivityCollection InitializeActivities()
        {

            //read state
            StateCollection states = workflow.InitialStates;
            CollaborativeActivityCollection initialActivities = new CollaborativeActivityCollection(this);
            foreach (State state in states)
            {
                //create activity
                CollaborativeActivity activity = new CollaborativeActivity(this, state);
                activity.Data.PS = VAL.Array();
                activity.Data.Activated = true;
                activity.Data.TaskStatus = TaskStatus.Opened;

                initialActivities.Add(activity);
            }
            
            //activity.StartWork();
            //activity.DoPreaction();
            return initialActivities;
        }

        /// <summary>
        /// return Intial Activities
        /// </summary>
        /// <returns></returns>
        public CollaborativeActivityCollection Start()
        {

            CollaborativeActivityCollection activities = this.InitializeActivities();
            foreach (CollaborativeActivity activity in activities)
                activity.Sync();

            this.Save();

            return activities;
        }
     



        public void SyncMemeory()
        {
            DataLocking CO = new DataLocking(this);
            if (CO.Locked)
            {
                throw new ApplicationException(string.Format("WorkflowInstance is locked at {0} by {1}", this, CO));
            }

            workflowInstanceData.Load();
            //synchronize memory in all computers
        }

        //public void CompleteWorkflow()
        //{
        //    this.Complete_Date = DateTime.Now;
        //}



        private static Memory LoadWorkflowInstance(ICollaborativeWorkflowInstanceData workflowInstanceData)
        {
            if (workflowInstanceData.MemoryStorage != "")
            {
                VAL v = Script.Evaluate(workflowInstanceData.MemoryStorage);
                return (Memory)v;

            }

            return new Memory();
        }

        private void LoadActivities()
        {
            string c = workflowInstanceData.LoadHeap(this.activities.Path);
            this.Execute(c);
        }

        public DataRow Save()
        {

            VAL val;
            VAL states = new VAL();


            if (this.workflowInstanceData.MemoryStorage == null)    //SQL INSERT
            {
                this.workflowInstanceData.Save(); //save to generate WorkflowInstance identity ID# 
                
                Add2DS(this.workflow.Path, this.workflow.GetValData());
                val = Conversion.Class2VAL(this.workflowInstanceData);
                val[NS_STATES] = new VAL();
                Add2DS(this.Path, val);
            }
            else
            {
                val = this.Evaluate(this.Path);
                states = val[NS_STATES];
                val[NS_STATES] = new VAL();  //don't save activities into WorkflowInstance's Heap
            }


#if JSON          
            this.workflowInstanceData.MemoryStorage = VAL.Boxing(ds).ToJson();
#else
            this.workflowInstanceData.MemoryStorage = ds.ToString();
#endif

            //keep WorkflowInstance properties 
            DataRow dataRow= this.workflowInstanceData.Save();
            
            if(!states.IsNull)
                val[NS_STATES] = states; //recover activities

            return dataRow;
        }

        /// <summary>
        /// Save Heap, used for Workflow Runtime Editor
        /// </summary>
        public void SaveHeap()
        {
            Add2DS(this.workflow.Path, this.workflow.GetValData());
            VAL val = Conversion.Class2VAL(this.workflowInstanceData);
            val[NS_STATES] = new VAL();
            Add2DS(this.Path, val);

            this.workflowInstanceData.MemoryStorage = VAL.Boxing(ds).ToJson();
            this.workflowInstanceData.Save();
        }


        private void Add2DS(string scope, VAL val)
        {
            string code = string.Format("{0}={1};", scope, val);
            this.Execute(code);
        }


        public VAL Tracking()
        {
            return new VAL();
        }


        
        public override string ToString()
        {
            return string.Format("WorkflowInstance(ID={0}, Workflow={1})", this.workflowInstanceData.PIN, this.workflow.WorkflowName);
        }

        public VAL Context
        {
            get
            {
                VAL wfi = GetValData();
                VAL context = wfi[NS_CONTEXT];
                if (context.Undefined)
                    wfi[NS_CONTEXT] =VAL.Array();

                return context;
            }
        }

        public string Path
        {
            get
            {
                return string.Format("{0}.{1}", NS_WORKFLOWINSTANCE, this.Name);
            }
        }

              
        public VAL GetValData()
        {
            VAL wfi = this.DS[NS_WORKFLOWINSTANCE];

            if (wfi.Defined)
                return wfi[Name];

            return new VAL();
        }

        public string Name
        {
            get
            {
                return "$" + this.workflowInstanceData.PIN;
            }
        }

        public int LockID
        {
            get
            {
                return this.Data.LockID;
            }
        }

        public int LockType
        {
            get
            {
                return this.Data.LockType;
            }
        }

    }
}
