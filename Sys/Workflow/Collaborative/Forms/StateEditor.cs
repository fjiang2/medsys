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

namespace Sys.Workflow.Collaborative.Forms
{
    public partial class StateEditor : BaseForm 
    {
        BindDpo<StateDpo> bind;
        public StateEditor(State state)
        {
            InitializeComponent();
            cblNodeType.EnumType = typeof(StateNodeType);

            StateDpo dpo =(StateDpo)state.Data;

            bind = new BindDpo<StateDpo>(dpo);
            bind.Connect(txtID, StateDpo._ID);
            bind.Connect(txtWorkflowName, StateDpo._Workflow_Name);

            bind.Connect(txtStateName, StateDpo._Name);
            bind.Connect(txtIndex, StateDpo._Index);
            bind.Connect(txtLabel, StateDpo._Label);
            bind.Connect(txtDescription, StateDpo._Description);
            bind.Connect(txtDependency, StateDpo._Description);
            bind.Connect(cblNodeType, "Value", StateDpo._Ty);
            bind.Connect(txtOffset, StateDpo._Offset);
            bind.Connect(txtDuration, StateDpo._Duration);
            bind.Connect(txtMetadata, StateDpo._Metadata);
            bind.Connect(txtDependency, StateDpo._Dependency);
            bind.Connect(txtPreaction, StateDpo._Preaction);
            bind.Connect(txtAction, StateDpo._Action);
            bind.Connect(txtAfterAction, StateDpo._AfterAction);
            bind.Connect(txtPostaction, StateDpo._Postaction);
            bind.Connect(txtAgent, StateDpo._Agent);

            bind.Reset();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            bind.Apply();
            Close();
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
