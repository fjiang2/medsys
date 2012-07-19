using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;
using Sys.Data;
using Sys.Data.Manager;
using Sys.Workflow.DpoClass;

namespace Sys.Workflow.Collaborative
{

    public class WorkflowInstanceDpo : wfWorkflowInstanceDpo, ICollaborativeWorkflowInstanceData 
    {

#if ACTIVITIES
        [Association("WorkflowInstance_ID=@ID")]
        public DataPersistentCollection<ActivityInstancePersistent> ActivityInstanceList;
#endif

        //create workflow instance
        public WorkflowInstanceDpo()
        {
            this.Work_Date = DateTime.Now;
            this.Complete_Date = null;
            this.Deleted = false;
        }


        public WorkflowInstanceDpo(DataRow dataRow)
            :base(dataRow)
        {

        }

        //read workflow instance
        public WorkflowInstanceDpo(int instanceID)
        {
            this.ID = instanceID;
            this.Load();
        }

        
    

        #region Interface IWorkflowInstance

        public int PIN { get { return this.ID; } }
        public string WorkflowName { get { return this.Workflow_Name; } set { this.Workflow_Name = value; } }
        public string MemoryStorage { get { return this.Heap; } set { this.Heap = value; } }


        public ICollaborativeTask NewInstance(CollaborativeWorkflowInstance workflowInstance, State state)
        {
            Workflow workflow = workflowInstance.Workflow;

            TaskDpo dpoTask = new TaskDpo();
            StateDpo dpoState = (StateDpo)state.Data;

            dpoTask.WorkflowInstance_ID = this.ID;
            dpoTask.State_Name = dpoState.Name;
            dpoTask.Company = workflow.Data.CompanyName;

            //make logical state invisible
            dpoTask.Visible = !state.IsLogicalState;
            dpoTask.Summary = dpoState.Label;
            dpoTask.Description = dpoState.Description;
            dpoTask.Category1 = "";
            dpoTask.Category2 = "";
            dpoTask.Category3 = "";
            

            dpoTask.Start_Date = DateTime.Now;
            dpoTask.Due_Date = ((DateTime)dpoTask.Start_Date).Add(TimeSpan.FromHours(dpoState.Duration));

            workflowInstance.InvokeFunction(dpoState.Metadata, new object[] { workflowInstance, state, dpoTask, workflowInstance.Context });

            return dpoTask;

        }

        public string LoadHeap(string path)
        {

            string SQL = @"
                    SELECT State_Name, Heap 
                    FROM {0}
                    WHERE WorkflowInstance_ID = {1}
                ";
            
            DataTable dt = SqlCmd.FillDataTable(SQL, wfTaskDpo.TABLE_NAME, this.ID);
            
            StringBuilder script = new StringBuilder();
            foreach (DataRow dataRow in dt.Rows)
            {
                script.AppendFormat("{0}.{1}={2};", path, dataRow[TaskDpo._State_Name], dataRow[TaskDpo._Heap]);
#if DEBUG
                script.AppendLine();
#endif
            }

            return script.ToString();
        }

        public bool Completed
        {
            get
            {
                return this.Complete_Date != null;
            }
        }

        public void CompleteWorkflowInstance()
        {
            this.Complete_Date = DateTime.Now;
        }
    
        #endregion
    }
}
