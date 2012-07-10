using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tie;
using Sys.Data;
using Sys.DataManager;
using Sys.Workflow.Dpo;
namespace Sys.Workflow.Collaborative
{
   
    public class WorkflowDpo : wfWorkflowDpo, IWorkflowData
    {
        [NonValized]
        [Association("Workflow_Name=@Name", OrderBy="[Index]")]
        public DPCollection<StateDpo> StateList;

        [NonValized]
        [Association("Workflow_Name=@Name")]
        public DPCollection<TransitionDpo> TransitionList;

        //create a workflow, used by designer tools
        public WorkflowDpo()
        {
            this.Released = true;
            this.Visible = true;
            this.Enabled = true;
            this.Deleted = false;
            this.Date_Created = DateTime.Now;
            this.Creator = Sys.Security.Account.CurrentUser.UserID;
        }

        public WorkflowDpo(DataRow dataRow)
            : base(dataRow)
        { 
        }

        //read a workflow for workflow TreeView display
        public WorkflowDpo(string workflowName)
        {
            this.Name = workflowName;
            this.Load();

        }

     
        public override string ToString()
        {
            return this.Name;
        }




        #region interface IWorkflowData

  
        public string WorkflowName { get { return this.Name; } }
        public string CompanyName { get { return this.Company; } }

        public IDPCollection DpcState { get { return this.StateList; } }
        public IDPCollection DpcTransition { get { return this.TransitionList; } }


        public ITransitionData NewTransition()
        {
            TransitionDpo persistent =  new TransitionDpo();
            persistent.Workflow_Name = this.Name;
            return persistent;
        }

        public IStateData NewState()
        {
            StateDpo persistent = new StateDpo();
            persistent.Workflow_Name = this.Name;;
            return persistent;
        }
        
        #endregion
    }
}
