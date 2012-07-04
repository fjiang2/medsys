using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.ViewManager.Forms;
using Sys.ViewManager;
using Tie;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Customization;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Sys.Security;
using Sys.Data;
using Sys.SmartList.Dpo;
using Sys.ViewManager.Security;
using Sys.Foundation.Dpo;
using Sys.OS;

namespace Sys.SmartList.Forms
{



	public partial class MainForm : BaseForm
	{
  	
        Memory memory = Profile.Instance.Memory;
        Memory localMemory = new Memory();

		bool hasCriteriaForm = false;
		bool openbyTreeView = true;

		UserRoleAccount collector;
        string selectCommand = @"
                            SELECT	*
                            FROM	@Commands 
                            WHERE	(Company_ID={0} OR Company_ID IS NULL OR Company_ID = 0) AND Visible=1 AND Ty ={1} AND Released = 1 
                                    AND (Controlled=0 OR Owner_ID = {2}
		                              OR ID IN (SELECT ID 
					                            FROM @IPermissions 
			  	                               WHERE Ty ={1} AND Visible=1 AND Role_ID IN (
						                            SELECT Role_ID FROM @UserRoles WHERE User_ID = {2}
						                            )
                                     ))
                            ORDER BY isNull(OrderBy, 0), label
                        ";

        string selectComamndDeveloper = @"
                            SELECT	*
                            FROM	@Commands 
                            WHERE	(Company_ID={0} OR Company_ID IS NULL OR Company_ID = 0)  AND Ty={1}
                            ORDER BY isNull(OrderBy, 0), label
                            ";

        string selectComamndAdmin = @"
                            SELECT	*
                            FROM	@Commands 
                            WHERE	(Company_ID={0} OR Company_ID IS NULL OR Company_ID = 0) AND Visible=1 AND Ty={1} 
                                    AND ID NOT IN (20)
                                    AND (Access_Level<>2 OR Owner_ID = {2})
                                    AND Released = 1
                            ORDER BY isNull(OrderBy, 0), label
                            ";


		DataTable dtSmartList;
		IDataViewer dataViewer;
		Configuration configuration;

		public IDataViewer DataViewer
		{
			get
			{
				return dataViewer;
			}
		}
		    
		public MainForm()
		{
			Init();
			openbyTreeView = true;
        }

        /// <summary>
        /// Identify multiple smartlist items
        /// </summary>
        private string itemInstanceID = null;

        public MainForm(int ID, string itemInstanceID)
            :this(ID)
        {
            this.itemInstanceID = itemInstanceID;
            this.instanceId += itemInstanceID;
        }
        
		public MainForm(int ID)
            :base(ID.ToString())
		{

			Init();

			openbyTreeView = false;
			splitContainer1.Panel1Collapsed = true;

			DataRow[] rows = this.dtSmartList.Select(string.Format("ID={0}", ID));


            if (treeView1.SelectedDpoNode == null)
			{
				this.ErrorMessage = string.Format("Command ID={0} is not found. or you don't have permission to access", ID);
				return;
			}


			this.Text = treeView1.SelectedDpoNode.Dpo.NodeText;



		}



		private void Init()
		{
			InitializeComponent();
            allAccess = true;

            selectCommand = selectCommand
                .Replace("@Commands", CommandDpo.TABLE_NAME)
                .Replace("@IPermissions", Sys.ViewManager.Dpo.ItemPermissionDpo.TABLE_NAME)
                .Replace("@UserRoles", UserRoleDpo.TABLE_NAME);
            
            selectComamndDeveloper = selectComamndDeveloper
                    .Replace("@Commands", CommandDpo.TABLE_NAME);
            
            selectComamndAdmin = selectComamndAdmin
                    .Replace("@Commands", CommandDpo.TABLE_NAME);


            this.iconImage = global::Sys.SmartList.Properties.Resources.Book_StackOfReportsHS;

            try
            {
                Sys.Modules.TieModule.Load(this.GetType().Assembly, localMemory);
            }
            catch (PositionException e1)
            {
                TieEditor.Show(e1);
            }
            catch (Exception e)
            {
                this.ErrorMessage = e.Message;
            }

            BuildTree();

            treeView1.AfterSelect += delegate(object sender, TreeViewEventArgs e)
            {
                if (e.Action == TreeViewAction.ByMouse)
                {
                    this.cmbSearchBy.SelectedItem = e.Node;
                }
            };

            treeView1.MouseDoubleClick += delegate(object sender, MouseEventArgs e)
            {
                Inquire();
            };

			HostType.Register(this.GetType());
			HostType.Register(typeof(System.DateTime));
			HostType.Register(typeof(System.DayOfWeek));
			HostType.Register(typeof(System.Globalization.CultureInfo));
			HostType.Register(typeof(System.Globalization.CalendarWeekRule));
			HostType.Register(typeof(SqlCmd));
			HostType.Register(typeof(Color), true);
			HostType.Register(typeof(DevExpress.XtraGrid.FormatConditionEnum));
			HostType.Register(typeof(System.Drawing.FontStyle));
            HostType.Register(typeof(DevExpress.XtraVerticalGrid.PropertyGridControl));
            HostType.Register(typeof(DevExpress.XtraEditors.Controls.HeaderClickMode));
            HostType.Register(typeof(DevExpress.XtraEditors.Controls.SearchMode));


#if DEBUG
			//Tie.Logger.Open("c:\\temp\\tie.log");
#endif
		}


        private void BuildTree()
        {
            this.collector = (UserRoleAccount)Account.CurrentUser;

            if (collector.IsDeveloper)
                selectCommand = selectComamndDeveloper;
            else if (collector.IsAdmin)
                selectCommand = selectComamndAdmin;


            treeView1.ImageList = CommandTree.ImageList;

            this.dtSmartList = SqlCmd.FillDataTable(selectCommand, SysInformation.CompanyID, (int)SecurityType.SmartList, collector.UserID);
            List<ITreeNodeDpo> list = new List<ITreeNodeDpo>();
            foreach (DataRow dataRow in dtSmartList.Rows)
            {
                ITreeNodeDpo dpo = new CommandNodeDpo(dataRow);
                list.Add(dpo);
            }

            treeView1.Nodes.Clear();
            treeView1.DataSource = list;
            treeView1.BuildTreeView();
            treeView1.ContextMenuStrip =null;
        }

      

		public override object MaintenanceEntry
		{
			set
			{
				memory.Add(ParameterForm._Parameters, VAL.Boxing(value));
			}
		}


		SQLCommand LoadingSqlCmd = null;
		private void btnInquiry_Click(object sender, EventArgs e)
		{
			Inquire();
		}

		public void Inquire()
		{
			if (treeView1.SelectedDpoNode == null)
				return;

            var dpo = (CommandDpo)treeView1.SelectedDpo;

            if (this.configuration == null || this.configuration.ID != dpo.ID)
            {
                this.configuration = (Configuration)treeView1.SelectedDpo;
                if (configuration.Sql_Command == "")
                    return;
            }

			if (this.dataViewer != null)
			{
				this.splitContainer1.Panel2.Controls.Remove(this.dataViewer.ViewControl);
				this.dataViewer.Dispose();
			}


			this.dataViewer = DataViewerFactory.NewInstance(this.configuration);

			if (this.dataViewer == null)
			{
				this.ErrorMessage = string.Format("ViewMode {0} is not suppoorted.", this.configuration.ViewMode);
				return;
			}

			this.dataViewer.Script.DS = memory;
			this.splitContainer1.Panel2.Controls.Add(this.dataViewer.ViewControl);
			this.Text = this.configuration.Label;

			Inquire(this.openbyTreeView);
		}

		private void Inquire(bool openbyTreeView)
		{

            if (configuration.Sql_Command == "")
			{
				//this.ErrorMessage = "SELECT Command is not defined";
				return;
			}


			VAL userLayout = VAL.Array();
			if (configuration.User_Layout != "")
			{
				try
				{
					this.dataViewer.Script.DS = memory;
					userLayout = this.dataViewer.Script.VolatileEvaluate(configuration.User_Layout);
					//userLayout = Coding.Evaluate(configuration.UserLayout, memory);
				}
				catch (CompilingException ex)
				{
					this.ErrorMessage = ex.Message;

					return;
				}

			}


			VAL smartListSetting = new VAL();
			if (configuration.Setting_Script != "")
			{
                CustomizedCode.Clear(localMemory);
                Memory DS = this.dataViewer.Script.DS = localMemory;
				this.dataViewer.Script.DS.AddHostObject("dataViewContainer", this);

				//Execute script and capture exception
				VAL setting = this.dataViewer.Script.Evaluate(configuration.Setting_Script);
                this.dataViewer.Script.DS.Add(CustomizedCode.SETTING, setting);
                

				//save what your changed
				if (configuration.Setting_Script != this.dataViewer.Script.SourceCode)
				{
					configuration.Setting_Script = this.dataViewer.Script.SourceCode;
					configuration.Save();
				}

			}


            LoadingSqlCmd = DataTableLoading(configuration.Sql_Command, userLayout, openbyTreeView);

		}





		#region DataTable Loading Thread
		private SQLCommand DataTableLoading(string script, VAL parameters, bool openbyTreeView)
		{
			hasCriteriaForm = false;
			VAL controls = parameters[ParameterForm._Controls];

			SQLCommand cmd = new SQLCommand(script);
			if (controls.Defined)
			{
				hasCriteriaForm = true;

				if (memory[ParameterForm._Parameters].Undefined)
				{
					ParameterForm f = new ParameterForm();
					f.MaintenanceEntry = new object[] { parameters, memory };
					if (f.ShowDialog(this) == DialogResult.Cancel)
						return null;
				}

				if (memory[ParameterForm._Parameters].Undefined)
					return null;


				VAL args = memory[ParameterForm._Parameters];
				for (int i = 0; i < args.Size; i++)
				{
					this.Text += " " + args[i][1].ToString();
				}

				try
				{
					cmd = ParameterForm.SetSqlParameters(cmd, memory, dataViewer.Script.DS);
				}
				catch (Exception ex)
				{
					this.ErrorMessage = ex.Message;
					cmd = null;
				}

				this.configuration.Header = memory[ParameterForm._Parameters];
				memory.Remove(ParameterForm._Parameters);
			}
			else
				this.configuration.Header = new VAL();

			if (cmd != null)
			{
				this.StartProgressBar("Loading....");
				this.InformationMessage = string.Format("Loading data [{0}] from server ...", treeView1.SelectedDpo.NodeText);

				btnInquiry.Enabled = false;
				toolStripButtonStop.Enabled = true;

#if !DEBUG
                cmd.StartLoadingDataSet(this, parameters);
                cmd.DataSetLoaded += DataSetLoaded;
                cmd.DataRowLoading += DataRowLoading;
#else
				DataSet ds = cmd.FillDataSet();
				DataSetLoaded(ds, parameters);
#endif
			}

			return cmd;
		}



		private void DataRowLoading(DataRow dataRow)
		{
			int count = dataRow.Table.Rows.Count;
			int c = dataRow.Table.DataSet.Tables.Count;

			if (count % 96 == 0)
			{
				string message = string.Format("Loading {0}:{1} Records", c, count);
				this.StartProgressBar(message);
			}
		}

		private void DataSetLoaded(DataSet dataSet, object args)
		{
			if (this.IsDisposed)
				return;

			VAL parameters = (VAL)args;
			btnInquiry.Enabled = true;


			this.dataViewer.DataSet = dataSet;

			Cursor.Current = Cursors.WaitCursor;
			this.dataViewer.InitializeViewLayout(parameters);


			if (!cmbSearchBy.Items.Contains(treeView1.SelectedDpoNode))
                cmbSearchBy.Items.Add(treeView1.SelectedDpoNode);

			this.StopProgressBar();
			if (dataSet != null)
			{
				int count = 0;
				foreach (DataTable dataTable in dataSet.Tables)
				{
					count += dataTable.Rows.Count;
				}

				this.InformationMessage = string.Format("Total [{0}] tables and [{1}] records are loaded.", dataSet.Tables.Count, count);
			}

			Cursor.Current = Cursors.Default;

			btnInquiry.Enabled = true;
			toolStripButtonStop.Enabled = false;
		}
		#endregion








		private void toolStripButtonAddFavorite_Click(object sender, EventArgs e)
		{
			if (hasCriteriaForm)
			{
				return;
			}

			if (treeView1.SelectedDpoNode == null)
			{
				this.WarningMessage = "Please inquire first before add a favorite.";
				return;
			}

			VAL v = this.dataViewer.UserViewLayout;

            if ((object)v == null)
            {
                this.WarningMessage = string.Format("This item does not support favorite adding");
                return;
            }

			FavoriteForm form =
                new FavoriteForm(SecurityType.SmartList, treeView1, v.ToString());

			form.PopUp(this, FormPlace.Floating);
		}





		private void cmbSearchBy_TextChanged(object sender, EventArgs e)
		{
			if (cmbSearchBy.SelectedItem == null)
				return;

			treeView1.SelectedNode = (TreeNode)cmbSearchBy.SelectedItem;
		}


		private void toolStripButtonRefresh_Click(object sender, EventArgs e)
		{
            BuildTree();
			this.cmbSearchBy.Text = "";
			this.cmbSearchBy.Items.Clear();
		}



		private bool IsTempalteNode()
		{
			var dpo = (CommandDpo)treeView1.SelectedDpo;
			return !string.IsNullOrEmpty(dpo.Sql_Command);
		}


	
		private void toolStripButtonPanelCollapse_Click(object sender, EventArgs e)
		{
			splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;

		}


		private void Form_Load(object sender, EventArgs e)
		{

			if (Account.CurrentUser.IsDeveloper)
			{
				this.toolStripButtonEditGridMode.Visible = true;
				this.toolStripButtonSave.Visible = true;
			}

			if (!openbyTreeView)
			{
				toolStripButtonPanelCollapse.Visible = false;
				toolStripButtonAddFavorite.Visible = false;
				btnInquiry.Enabled = false;
				toolStripButtonRefresh.Visible = false;


				Inquire();
			}


		}


		private void Form_Closed(object sender, FormClosedEventArgs e)
		{
			if (LoadingSqlCmd != null)
				LoadingSqlCmd.LoadDataTableCancelled = true;

			this.StopProgressBar();
			this.InformationMessage = "";

			if (this.dataViewer != null)
				this.dataViewer.Dispose();
#if  DEBUG
			Tie.Logger.Close();
#endif
		}

		private void toolStripButtonStop_Click(object sender, EventArgs e)
		{

			toolStripButtonStop.Enabled = false;

			if (LoadingSqlCmd != null)
				LoadingSqlCmd.LoadDataTableCancelled = true;

			this.InformationMessage = "Trying to stop loading data....";
		}




		#region Show Data in Grid



		private void btnPrint_Click(object sender, EventArgs e)
		{
            PrintDialog printer = new PrintDialog();
            if(printer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.dataViewer.DataPrint();
		}

       
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            this.dataViewer.DataPrintPreview();
        }


		private void btnSwitchView_Click(object sender, EventArgs e)
		{

			string text = this.dataViewer.ActivateView();

			if (dataViewer is LayoutViewer)
				this.btnSwitchView.Image = global::Sys.SmartList.Properties.Resources.ArrangeSideBySideHS;

			else if (dataViewer is GridViewer)
				this.btnSwitchView.Image = global::Sys.SmartList.Properties.Resources.ShowGridlinesHS;

			this.btnSwitchView.Text = text;

		}

		#endregion



		#region DataGrid Editor


		private void toolStripButtonEditGridMode_Click(object sender, EventArgs e)
		{
			this.dataViewer.EditMode = !this.dataViewer.EditMode;

			if (this.dataViewer.EditMode)
			{
				this.toolStripButtonEditGridMode.Image = global::Sys.SmartList.Properties.Resources.application_form_edit;
				this.toolStripButtonEditGridMode.Text = "Edit Mode";
				this.toolStripButtonEditGridMode.ToolTipText = "Current Mode is Edit Mode";
				this.Text = "Smart List Editor";
			}
			else
			{
				this.toolStripButtonEditGridMode.Image = global::Sys.SmartList.Properties.Resources.application_form_magnify;
				this.toolStripButtonEditGridMode.Text = "View Mode";
				this.toolStripButtonEditGridMode.ToolTipText = "Current Mode is View Mode";
				this.Text = "Smart List Viewer";

			}

			this.toolStripButtonSave.Enabled = this.dataViewer.EditMode;

		}


		/*
		 * ex:
		 * 
		 * Database.Updates.Holidays.TableName="SFC..Holidays";
		 * Database.Update.Holidays.Columns= {"HoliDate", "Description"};
		 * 
		 * 
		 * 
		 * */
		private void toolStripButtonSave_Click(object sender, EventArgs e)
		{
			if (this.dataViewer.Table0 == null)
			{
				this.WarningMessage = "There is not any data in the grid, data cannot be saved.";
				return;
			}


			try
			{
				if (this.dataViewer.DataSave())
					this.InformationMessage = "Data are saved into SQL Server.";
				else
					this.InformationMessage = "Data are not saved into SQL Server.";
			}
			catch (Exception ex)
			{
				this.ErrorMessage = ex.Message;
			}


		}

		#endregion

        protected override bool AddShortCut(bool pinned)
		{
            if (this.configuration == null && treeView1.SelectedDpoNode != null)
                this.configuration = (Configuration)treeView1.SelectedDpo;

            if (this.configuration != null)
            {
                string key = this.configuration.ID.ToString();
                string caption = "SmartList:" + this.configuration.Label;

                object[] args;
                if (itemInstanceID == null)
                {
                    args = new object[] { this.configuration.ID };
                }
                else
                {
                    args = new object[] { this.configuration.ID, itemInstanceID };
                }


                if (this.ShortcutManager.Add(pinned, key, caption, this.GetType(), args))
                {
                    this.InformationMessage = string.Format("Shortcut SmartList:[{0}] is added.", this.configuration.Label);
                    this.ShortcutManager.Save();
                    return true;
                }

            }
            else
            {
                return base.AddShortCut(pinned);
            }

            return false;
		}

		protected override void ShowHelpForm()
		{
            if (configuration == null)
            {
                base.ShowHelpForm();
                return;
            }

            HelpForm helpForm = new HelpForm("Help: SmartList " + configuration.Label, configuration.Help);
			helpForm.PopUp(this);
		}

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            About();
        }

        public void About()
        {
            Configuration item = (Configuration)treeView1.SelectedDpo;
            if (item != null)
            {
                HelpForm help = new HelpForm(item.Label + "(SmartList)", item.Help);
                help.Show(this);
            }
        }


        public static void PopUp(ContainerControl owner, string caption, int ID, object parameters)
        { 
            MainForm form = new Sys.SmartList.Forms.MainForm(ID); 
            form.MaintenanceEntry = VAL.Boxing(parameters);
            form.PopUp(owner);
            form.ChangeCaption(caption);
        }

       
      
	}




}





