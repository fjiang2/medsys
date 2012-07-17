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
using Sys.ViewManager.Utils;
using Sys.ViewManager.DevEx;

namespace Sys.Workflow.Collaborative.Forms
{
    public partial class WorkflowForm : BaseForm 
    {
        WorkflowDataView workflowView;

        public WorkflowForm()
            : this("W1")
        { 
        }

        public WorkflowForm(string workflowName)
            :base(workflowName)
        {
            this.workflowView = new WorkflowDataView(workflowName);

            InitializeComponent();

            this.jGridView1.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.jGridView1.GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.jGridView1.ContextMenuEnabled = false; 
            //this.jGridView1.GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.jGridView1.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None; 

            this.jGridView2.GridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.jGridView2.GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.jGridView2.ContextMenuEnabled = false;
            //this.jGridView2.GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.jGridView2.GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None; 
            
            this.tbScript.SelectionChanged += JRichTextBoxPostionDelegate;
            this.tbScript.AcceptsTab = true;
            
            this.FormClosed += delegate(object sender, FormClosedEventArgs e)
            {
                this.InformationMessage = "";
            };

            
            this.tbLabel.Text = workflowView.Label;
            this.tbDescription.Text = workflowView.Description;
            this.tbCompany.Text = workflowView.Company;
            this.tbKeyName.Text = workflowView.Name;

            this.tbScript.Text = workflowView.Metadata;
            
            this.cbEnabled.Checked = workflowView.Enabled;
            this.cbVisible.Checked = workflowView.Visible;
            this.cbReleased.Checked = workflowView.Released;


            DataLoad();
            this.Text = "Workflow :  " + this.tbLabel.Text;

            this.jGridView1.GridControl.MouseClick += new MouseEventHandler(this.gridControl_DoubleClick);
            this.jGridView2.GridControl.MouseClick += new MouseEventHandler(this.gridControl_DoubleClick);



            jGridView1.GridView.FixedLineWidth = 2;
            jGridView1.GridView.Columns["ID"].Fixed = FixedStyle.Left;
            jGridView1.GridView.Columns["Name"].Fixed = FixedStyle.Left;
        }

        private void gridControl_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DevExpress.XtraGrid.GridControl gridControl = (DevExpress.XtraGrid.GridControl)sender;
            if (e.Button != MouseButtons.Left)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)gridControl.MainView;

            DataRow dataRow = Sys.ViewManager.DevEx.Grid.GetGridClickEx(gridView, sender);
            
            if (dataRow != null)
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHitInfo = gridView.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));
                if (gridHitInfo == null)
                    return;

                GridColumn gridColumn = gridHitInfo.Column;
                if (gridColumn == null)
                    return;

                DataColumn dataColumn = dataRow.Table.Columns[gridColumn.FieldName];
                if (dataColumn.DataType == typeof(string) && !gridColumn.OptionsColumn.ReadOnly)
                {
                    string result = TieEditor.Show(this,
                        //string.Format("Column : {0} State : {1}", gridColumn.FieldName, dataRow["Label"]),
                        string.Format("Edit Column : {0} ", gridColumn.FieldName),
                        dataRow[gridColumn.FieldName] as String);

                    if (result != null)
                        dataRow[gridColumn.FieldName] = result;
                }
            }
        }


        public override bool DataLoad()
        {
      
            jGridView1.DataSource = this.workflowView.StateList.Table;

            jGridView1.GridView.Columns[StateDpo._Workflow_Name].Visible = false;
            jGridView1.GridView.Columns[StateDpo._Index].Visible = false;

            //State Type
            RepositoryItemImageComboBox tyComboBox = new RepositoryItemImageComboBox();
            tyComboBox.LoadEnumBit<StateNodeType>();
            
            jGridView1.GridView.Columns[StateDpo._Ty].ColumnEdit = tyComboBox;
            jGridView1.GridView.Columns[StateDpo._Ty].Width = 100;

            jGridView1.GridView.Columns[StateDpo._Name].OptionsColumn.ReadOnly = true;
            jGridView1.GridView.Columns[StateDpo._Metadata].OptionsColumn.AllowEdit = false;
            jGridView1.GridView.Columns[StateDpo._Dependency].OptionsColumn.AllowEdit = false;
            jGridView1.GridView.Columns[StateDpo._Preaction].OptionsColumn.AllowEdit = false;
            jGridView1.GridView.Columns[StateDpo._Action].OptionsColumn.AllowEdit = false;
            jGridView1.GridView.Columns[StateDpo._AfterAction].OptionsColumn.AllowEdit = false;
            jGridView1.GridView.Columns[StateDpo._Postaction].OptionsColumn.AllowEdit = false;
            jGridView1.GridView.Columns[StateDpo._Agent].OptionsColumn.AllowEdit = false;

            jGridView2.DataSource = this.workflowView.TransitionList.Table;


            jGridView2.GridView.Columns[TransitionDpo._Workflow_Name].Visible = false;
            jGridView2.GridView.Columns[TransitionDpo._S1_Name].OptionsColumn.ReadOnly = true;
            jGridView2.GridView.Columns[TransitionDpo._S2_Name].OptionsColumn.ReadOnly = true;
            jGridView2.GridView.Columns[TransitionDpo._Expression].OptionsColumn.AllowEdit = false;

            return true;
         }

     

        private void JRichTextBoxPostionDelegate(object sender, System.EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            this.InformationMessage = new RichText(rtb).ToString();
       }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            workflowView.Label = this.tbLabel.Text;
            workflowView.Description = this.tbDescription.Text;
            workflowView.Company = this.tbCompany.Text;
            workflowView.Name = this.tbKeyName.Text ;

            workflowView.Metadata = this.tbScript.Text;

            workflowView.Enabled = this.cbEnabled.Checked;
            workflowView.Visible= this.cbVisible.Checked;
            workflowView.Released = this.cbReleased.Checked;

            workflowView.Modifier = account.UserID;
            workflowView.Date_Modified = DateTime.Now;

            foreach (DataRow dataRow in this.workflowView.StateList.Table.Rows)
            {
                if(dataRow.RowState != DataRowState.Deleted)
                    dataRow[StateDpo._Workflow_Name] = this.tbKeyName.Text;
            }

            foreach (DataRow dataRow in this.workflowView.TransitionList.Table.Rows)
            {
                if(dataRow.RowState != DataRowState.Deleted)
                    dataRow[StateDpo._Workflow_Name] = this.tbKeyName.Text;
            }

            //sort column: "Index"
            this.workflowView.StateList.BeginRowChanged();
            for (int i = 0; i < this.workflowView.StateList.Count; i++)
            {
                StateDpo state = this.workflowView.StateList[i];
                state.Index = i;
                this.workflowView.StateList[i] = state;
            }
            this.workflowView.StateList.EndRowChanged();

            BeginLog();
            AddLog(workflowView);
            AddLog(this.workflowView.StateList);
            AddLog(this.workflowView.TransitionList);
            
            this.workflowView.Save();
            this.workflowView.SaveAssociations();
            
            EndLog();

            InformationMessage = "Workflow is saved.";

            this.DialogResult = DialogResult.Yes;
        }

      


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }


        void ConfirmWindow(object sender, RowChangedEventArgs e)
        {
            string action = "";
            switch (e.state)
            {
                case ObjectState.Deleted: action = "deleted"; break;
                case ObjectState.Modified: action = "overwritten"; break;
                case ObjectState.Added:
                    e.confirmed = true;
                    return;

            }
            string msg = string.Format("Workflow will be {0}, are you sure?", action);

            DialogResult r = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
                e.confirmed = true;
            else
                e.confirmed = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TieScript script = new TieScript();
            VAL val = script.VolatileEvaluate(this.tbScript.Text);
            string json = val.ToJson("");
        }

        private void btnTransistion_Click(object sender, EventArgs e)
        {
            workflowView.Workflow.PredictConnectedStates();


        }

        private void btnWorkflow_Click(object sender, EventArgs e)
        {
           WorkflowChartForm form = new WorkflowChartForm(workflowView);
           Series series0 = form.WorkflowChartControl.Series0;

           RangeBarPointOptions pointOptions = (RangeBarPointOptions)series0.Label.PointOptions;
           pointOptions.PointView = PointView.ArgumentAndValues;

           form.WorkflowChartControl.Diagram.AxisY.DateTimeMeasureUnit = DateTimeMeasurementUnit.Hour;
           form.WorkflowChartControl.ChartControl.Legend.Visible = true;
           ((SeriesViewColorEachSupportBase)series0.View).ColorEach = true;

           form.PopUp(this, FormPlace.Floating);
        }


        private void btnNewWorkflow_Click(object sender, EventArgs e)
        {
            WorkflowDpo persistent = new WorkflowDpo();
            if(this.tbKeyName.Text!="")
            {
                persistent.ID = -1;
                persistent.ParentID = 0;
                persistent.Name = this.tbKeyName.Text;
                persistent.Label = this.tbLabel.Text;
                persistent.Description = this.tbDescription.Text;
                
                persistent.Save();
            }
            else
            {
                this.WarningMessage = string.Format("Cannot create new workflow without defining workflow name.");
                return;
            }
            
            this.workflowView = new WorkflowDataView(this.tbKeyName.Text);

        }


        protected override bool AddShortCut(bool pinned)
        {
            if (this.workflowView == null)
            {
                base.AddShortCut(pinned);
                return true;
            }

            string key = this.workflowView.WorkflowName;
            string caption = "Workflow:" + this.workflowView.WorkflowName;

            if (this.ShortcutManager.Add(pinned, key, caption, this.GetType(), new object[] { key }))
            {
                this.InformationMessage = string.Format("Workflow Form [{0}] is added.", key);
                this.ShortcutManager.Save();

                return true;
            }

            return false;
        }

      
       

    }
}