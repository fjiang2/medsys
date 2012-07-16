using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tie;
using Sys.ViewManager.Forms;
using Sys.Security;
using Sys.ViewManager;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using Sys.Workflow.Forms;
using Sys.Data;
using DevExpress.XtraCharts;
using Sys.ViewManager.DevEx;

namespace Sys.Workflow.Collaborative.Forms
{
    public partial class WorkflowEditor : BaseForm 
    {
        BindDpo<WorkflowDpo> bind;
        Workflow workflow;
        CollaborativeWorkflowInstance workflowInstance;

        public WorkflowEditor(CollaborativeWorkflowInstance workflowInstance)
            :this(workflowInstance.Workflow)
        {
            this.workflowInstance = workflowInstance;
        }

        public WorkflowEditor(Workflow workflow)
        {
            InitializeComponent();
            
            this.workflow = workflow;
            WorkflowDpo dpo = (WorkflowDpo)workflow.Data;

            bind = new BindDpo<WorkflowDpo>(dpo);

            bind.Bind(txtWorkflowName, WorkflowDpo._Name);
            bind.Bind(txtLabel, WorkflowDpo._Label);
            bind.Bind(txtDescription, WorkflowDpo._Description);
            bind.Bind(txtMetadata, WorkflowDpo._Metadata);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Label", typeof(string));

            bind.Reset();

            foreach (State state in workflow.States.Values)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Name"] = state.Data.StateName;
                dataRow["Label"] = state.Data.Title;
                dataTable.Rows.Add(dataRow);
            }
            gridStates.DataSource = dataTable;


            dataTable = new DataTable();
            dataTable.Columns.Add("S1", typeof(string));
            dataTable.Columns.Add("S2", typeof(string));


            foreach (Transition transition in workflow.Transitions.Values)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["S1"] = transition.Data.S1Name;
                dataRow["S2"] = transition.Data.S2Name;
                dataTable.Rows.Add(dataRow);
            }
            
            gridTransitions.DataSource = dataTable;



            gridStates.GridControl.MouseClick += new MouseEventHandler(GridControl_MouseClick);
        }

        void GridControl_MouseClick(object sender, MouseEventArgs e)
        {
                  
            DevExpress.XtraGrid.GridControl gridControl = (DevExpress.XtraGrid.GridControl)sender;
            if (e.Button != MouseButtons.Left)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)gridControl.MainView;

            DataRow dataRow = Grid.GetGridClickEx(gridView, sender);

            if (dataRow != null)
            {
                string stateName = (string)dataRow["Name"];
                StateEditor stateEditor = new StateEditor(workflow.States[stateName]);
                stateEditor.PopUp(this, FormPlace.Floating);
            }
        }

        
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            bind.Apply();

            if (workflowInstance != null)
            {
                workflowInstance.SaveHeap();
                Close();
                return;
            }

            ((WorkflowDpo)workflow.Data).Save();
            foreach (State state in workflow.States.Values)
            {
                ((StateDpo)state.Data).Save();
            }

            foreach (Transition transition in workflow.Transitions.Values)
            {
                ((TransitionDpo)transition.Data).Save();
            }

            Close();
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
