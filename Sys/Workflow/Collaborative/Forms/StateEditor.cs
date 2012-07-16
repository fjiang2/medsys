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
            bind.Bind(txtID, StateDpo._ID);
            bind.Bind(txtWorkflowName, StateDpo._Workflow_Name);

            bind.Bind(txtStateName, StateDpo._Name);
            bind.Bind(txtIndex, StateDpo._Index);
            bind.Bind(txtLabel, StateDpo._Label);
            bind.Bind(txtDescription, StateDpo._Description);
            bind.Bind(txtDependency, StateDpo._Description);
            bind.Bind(cblNodeType, "Value", StateDpo._Ty);
            bind.Bind(txtOffset, StateDpo._Offset);
            bind.Bind(txtDuration, StateDpo._Duration);
            bind.Bind(txtMetadata, StateDpo._Metadata);
            bind.Bind(txtDependency, StateDpo._Dependency);
            bind.Bind(txtPreaction, StateDpo._Preaction);
            bind.Bind(txtAction, StateDpo._Action);
            bind.Bind(txtAfterAction, StateDpo._AfterAction);
            bind.Bind(txtPostaction, StateDpo._Postaction);
            bind.Bind(txtAgent, StateDpo._Agent);

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
