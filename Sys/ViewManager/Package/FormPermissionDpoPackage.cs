//
// Machine Packed Data
//   by devel at 7/15/2012 8:37:50 AM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.ViewManager.Dpo;

namespace Sys.ViewManager.Package
{
	public class FormPermissionDpoPackage : BasePackage<FormPermissionDpo>
	{

		public FormPermissionDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmAddRoster";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdAdd"",{{""visible"",true},{""enabled"",true}}},{""cmdCancel"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmChat";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdSend"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmFileTransfer";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdAccept"",{{""visible"",true},{""enabled"",true}}},{""cmdClose"",{{""visible"",true},{""enabled"",true}}},{""cmdRefuse"",{{""visible"",true},{""enabled"",true}}},{""cmdSend"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmGroupChat";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdChangeSubject"",{{""visible"",true},{""enabled"",true}}},{""cmdSend"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmInputBox";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""cmdOK"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmLogin";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""cmdLogin"",{{""visible"",true},{""enabled"",true}}},{""chkRegister"",{{""visible"",true},{""enabled"",true}}},{""chkSSL"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmProfile";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnBrowse"",{{""visible"",true},{""enabled"",true}}},{""btnCancel"",{{""visible"",true},{""enabled"",true}}},{""btnClear"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmSearch";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdSearch"",{{""visible"",true},{""enabled"",true}}},{""tsiAddContact"",{{""visible"",true},{""enabled"",true}}},{""tsiVcard"",{{""visible"",true},{""enabled"",true}}},{""xDataControl"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""cmdOK"",{{""visible"",true},{""enabled"",true}}}}}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmSubscribe";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdApprove"",{{""visible"",true},{""enabled"",true}}},{""cmdRefuse"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmUserManagement";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""btnSend"",{{""visible"",true},{""enabled"",true}}},{""btnSendIM"",{{""visible"",true},{""enabled"",true}}},{""btnWorkflow"",{{""visible"",true},{""enabled"",true}}},{""button1"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmVcard";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdClose"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmXData";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""xDataControl1"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""cmdOK"",{{""visible"",true},{""enabled"",true}}}}}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.Database.Forms.DataTableExplorer";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true}}},{""jGridView1"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.DataImporter.DataImportForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true}}},{""btnRetrieveClass"",{{""visible"",true},{""enabled"",true}}},{""btnStart"",{{""visible"",true},{""enabled"",true}}},{""btnStop"",{{""visible"",true},{""enabled"",true}}},{""btnTemplateLookUp"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.DataImporter.DataImportWizard";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnRetrieveDataSource"",{{""visible"",true},{""enabled"",true}}},{""btnRetrieveImportClass"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}},{""btnStart"",{{""visible"",true},{""enabled"",true}}},{""btnStop"",{{""visible"",true},{""enabled"",true}}},{""btnTemplateLookUp"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.Forms.ChangePassword";
			dpo.Value = "{{\"visible\",true},{\"enabled\",true}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.Forms.HomeForm";
			dpo.Value = "{{\"visible\",true},{\"enabled\",true}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.Forms.RoleSetting";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cbExpand"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonClean"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.Forms.UserRoleSetting";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnAddRole"",{{""visible"",true},{""enabled"",true}}},{""btnRemoveRole"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonAddUser"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonRoleSetting"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.SendMailForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnAttachFile"",{{""visible"",true},{""enabled"",true}}},{""btnSend"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonCancel"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSend"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.SmartList.Forms.ConfigurationForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnAdd"",{{""visible"",true},{""enabled"",true}}},{""btnCancel"",{{""visible"",true},{""enabled"",true}}},{""btnHistory"",{{""visible"",true},{""enabled"",true}}},{""btnLoad"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}},{""cbControlled"",{{""visible"",true},{""enabled"",true}}},{""cbEnabled"",{{""visible"",true},{""enabled"",true}}},{""cbReleased"",{{""visible"",true},{""enabled"",true}}},{""cbVisible"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.SmartList.Forms.ContainerForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnInquiry"",{{""visible"",true},{""enabled"",true}}},{""btnPrint"",{{""visible"",true},{""enabled"",true}}},{""btnSwitchView"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonAbout"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonAddFavorite"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonEdit"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonEditGridMode"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonPanelCollapse"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonRefresh"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonStop"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.SmartList.Forms.FavoriteForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnAdd"",{{""visible"",true},{""enabled"",true}}},{""btnCancel"",{{""visible"",true},{""enabled"",true}}},{""btnDelete"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.SmartList.Forms.ParameterForm";
			dpo.Value = "{{\"visible\",true},{\"enabled\",true}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.SmartList.Forms.ReportMaintenanceForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnBuildReport"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.ViewManager.WinForm.HelpForm";
			dpo.Value = "{{\"visible\",true},{\"enabled\",true}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.ViewManager.WinForm.TieEditor";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""toolStripButtonCancel"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonRun"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.ViewManager.WinForm.WinForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""toolStripButtonClear"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonDelete"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonFavorite"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonHelp"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonHistory"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonNew"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonNote"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonOpen"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonPrint"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonRefresh"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonReportIssue"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSearch"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonValidate"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Collaborative.Forms.StateEditor";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cblNodeType"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonCancel"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Collaborative.Forms.TaskForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""btnAssignToMySelf"",{{""visible"",true},{""enabled"",true}}},{""btnMarkComplete"",{{""visible"",true},{""enabled"",true}}},{""btnRevokeTask"",{{""visible"",true},{""enabled"",true}}},{""cbUnread"",{{""visible"",true},{""enabled"",true}}},{""chkLocked"",{{""visible"",true},{""enabled"",true}}},{""chkReminder"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonDelete"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonPrint"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonStartTask"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Collaborative.Forms.TaskListForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""jGridView1"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonCompleted"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonMyAssignments"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonPrint"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonReceived"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonRefresh"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonUnassigned"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Collaborative.Forms.WorkflowEditor";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""gridStates"",{{""visible"",true},{""enabled"",true}}},{""gridTransitions"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonCancel"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Collaborative.Forms.WorkflowForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnCancel"",{{""visible"",true},{""enabled"",true}}},{""btnLoad"",{{""visible"",true},{""enabled"",true}}},{""btnNewWorkflow"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}},{""btnTransistion"",{{""visible"",true},{""enabled"",true}}},{""btnWorkflow"",{{""visible"",true},{""enabled"",true}}},{""button1"",{{""visible"",true},{""enabled"",true}}},{""cbEnabled"",{{""visible"",true},{""enabled"",true}}},{""cbReleased"",{{""visible"",true},{""enabled"",true}}},{""cbVisible"",{{""visible"",true},{""enabled"",true}}},{""jGridView1"",{{""visible"",true},{""enabled"",true}}},{""jGridView2"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Collaborative.Forms.WorkflowInstanceForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""btnEditHeap"",{{""visible"",true},{""enabled"",true}}},{""btnInstanceLookup"",{{""visible"",true},{""enabled"",true}}},{""btnNewWorkflowInstance"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}},{""linkWorkflow"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Forms.ActivityForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""btnComplete"",{{""visible"",true},{""enabled"",true}}},{""btnListen"",{{""visible"",true},{""enabled"",true}}},{""btnNotify"",{{""visible"",true},{""enabled"",true}}},{""chkBranch"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Forms.ActivityWinForm";
			dpo.Value = "{{\"visible\",true},{\"enabled\",true}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Forms.CollectForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""feedbackUserControl1"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnSend"",{{""visible"",true},{""enabled"",true}}},{""cbReopen"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonRefresh"",{{""visible"",true},{""enabled"",true}}}}}}},{""toolStripButtonExit"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonHistory"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSubmit"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonValidate"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Forms.MessageForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""btnOK"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Forms.ReviewForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""feedbackUserControl1"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnSend"",{{""visible"",true},{""enabled"",true}}},{""cbReopen"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonRefresh"",{{""visible"",true},{""enabled"",true}}}}}}},{""toolStripButtonExit"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonHistory"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSubmit"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonValidate"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Forms.SimpleForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""toolStripButtonExit"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonHistory"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSubmit"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonValidate"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Forms.VerifyPassword";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnCancel"",{{""visible"",true},{""enabled"",true}}},{""btnOK"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Workflow.Forms.WorkflowChartForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""chkColorEach"",{{""visible"",true},{""enabled"",true}}},{""chkShowArgument"",{{""visible"",true},{""enabled"",true}}},{""chkShowLegend"",{{""visible"",true},{""enabled"",true}}},{""chkShowValues"",{{""visible"",true},{""enabled"",true}}},{""workflowChartControl1"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 1;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Xmpp.Forms.MessageQueueForm";
			dpo.Value = "{{\"visible\",true},{\"enabled\",true}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmAddRoster";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdAdd"",{{""visible"",true},{""enabled"",true}}},{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""txtJid"",{{""visible"",true},{""enabled"",true}}},{""txtNickname"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmChat";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdSend"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmFileTransfer";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdAccept"",{{""visible"",true},{""enabled"",true}}},{""cmdClose"",{{""visible"",true},{""enabled"",true}}},{""cmdRefuse"",{{""visible"",true},{""enabled"",true}}},{""cmdSend"",{{""visible"",true},{""enabled"",true}}},{""txtDescription"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmGroupChat";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdChangeSubject"",{{""visible"",true},{""enabled"",true}}},{""cmdSend"",{{""visible"",true},{""enabled"",true}}},{""txtSubject"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmInputBox";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""cmdOK"",{{""visible"",true},{""enabled"",true}}},{""txtInput"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmLogin";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""cmdLogin"",{{""visible"",true},{""enabled"",true}}},{""chkRegister"",{{""visible"",true},{""enabled"",true}}},{""chkSSL"",{{""visible"",true},{""enabled"",true}}},{""txtJid"",{{""visible"",true},{""enabled"",true}}},{""txtPassword"",{{""visible"",true},{""enabled"",true}}},{""txtPort"",{{""visible"",true},{""enabled"",true}}},{""txtResource"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmProfile";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnBrowse"",{{""visible"",true},{""enabled"",true}}},{""btnCancel"",{{""visible"",true},{""enabled"",true}}},{""btnClear"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}},{""txtCompany"",{{""visible"",true},{""enabled"",true}}},{""txtDepartment"",{{""visible"",true},{""enabled"",true}}},{""txtEmailAddress"",{{""visible"",true},{""enabled"",true}}},{""txtFirstName"",{{""visible"",true},{""enabled"",true}}},{""txtHomeCity"",{{""visible"",true},{""enabled"",true}}},{""txtHomeCountry"",{{""visible"",true},{""enabled"",true}}},{""txtHomeFax"",{{""visible"",true},{""enabled"",true}}},{""txtHomeMobile"",{{""visible"",true},{""enabled"",true}}},{""txtHomePager"",{{""visible"",true},{""enabled"",true}}},{""txtHomePhone"",{{""visible"",true},{""enabled"",true}}},{""txtHomePostalCode"",{{""visible"",true},{""enabled"",true}}},{""txtHomeState"",{{""visible"",true},{""enabled"",true}}},{""txtHomeStreetAddress"",{{""visible"",true},{""enabled"",true}}},{""txtJobTitle"",{{""visible"",true},{""enabled"",true}}},{""txtLastName"",{{""visible"",true},{""enabled"",true}}},{""txtMiddleName"",{{""visible"",true},{""enabled"",true}}},{""txtNickname"",{{""visible"",true},{""enabled"",true}}},{""txtSupervisor"",{{""visible"",true},{""enabled"",true}}},{""txtSupervisorName"",{{""visible"",true},{""enabled"",true}}},{""txtUserName"",{{""visible"",true},{""enabled"",true}}},{""txtWorkCity"",{{""visible"",true},{""enabled"",true}}},{""txtWorkCountry"",{{""visible"",true},{""enabled"",true}}},{""txtWorkFax"",{{""visible"",true},{""enabled"",true}}},{""txtWorkMobile"",{{""visible"",true},{""enabled"",true}}},{""txtWorkPager"",{{""visible"",true},{""enabled"",true}}},{""txtWorkPhone"",{{""visible"",true},{""enabled"",true}}},{""txtWorkPostalCode"",{{""visible"",true},{""enabled"",true}}},{""txtWorkState"",{{""visible"",true},{""enabled"",true}}},{""txtWorkStreetAddress"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmSearch";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdSearch"",{{""visible"",true},{""enabled"",true}}},{""tsiAddContact"",{{""visible"",true},{""enabled"",true}}},{""tsiVcard"",{{""visible"",true},{""enabled"",true}}},{""xDataControl"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""cmdOK"",{{""visible"",true},{""enabled"",true}}}}}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmSubscribe";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdApprove"",{{""visible"",true},{""enabled"",true}}},{""cmdRefuse"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmUserManagement";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{"": Base Types"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""Sys.Workflow.Forms.ActivityWinForm"",{{""visible"",true},{""enabled"",true}}}}}}},{""btnSend"",{{""visible"",true},{""enabled"",true}}},{""btnSendIM"",{{""visible"",true},{""enabled"",true}}},{""btnWorkflow"",{{""visible"",true},{""enabled"",true}}},{""button1"",{{""visible"",true},{""enabled"",true}}},{""tbFormClass"",{{""visible"",true},{""enabled"",true}}},{""tbSubject"",{{""visible"",true},{""enabled"",true}}},{""tbTaskID"",{{""visible"",true},{""enabled"",true}}},{""tbUserName"",{{""visible"",true},{""enabled"",true}}},{""textBox1"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmVcard";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdClose"",{{""visible"",true},{""enabled"",true}}},{""txtDepartment"",{{""visible"",true},{""enabled"",true}}},{""txtDescription"",{{""visible"",true},{""enabled"",true}}},{""txtEmail"",{{""visible"",true},{""enabled"",true}}},{""txtFullname"",{{""visible"",true},{""enabled"",true}}},{""txtJobTitle"",{{""visible"",true},{""enabled"",true}}},{""txtNickname"",{{""visible"",true},{""enabled"",true}}},{""txtWorkPhone"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Messaging.frmXData";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""xDataControl1"",{{""visible"",true},{""enabled"",true},{""nodes"",{{""cmdCancel"",{{""visible"",true},{""enabled"",true}}},{""cmdOK"",{{""visible"",true},{""enabled"",true}}}}}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.Forms.ChangePassword";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnCancel"",{{""visible"",true},{""enabled"",true}}},{""btnOK"",{{""visible"",true},{""enabled"",true}}},{""txtPass0"",{{""visible"",true},{""enabled"",true}}},{""txtPass1"",{{""visible"",true},{""enabled"",true}}},{""txtPass2"",{{""visible"",true},{""enabled"",true}}},{""txtUserName"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.Platform.Forms.HomeForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""txtCompanyName"",{{""visible"",true},{""enabled"",true}}},{""txtComputerName"",{{""visible"",true},{""enabled"",true}}},{""txtDepartment"",{{""visible"",true},{""enabled"",true}}},{""txtEmployeeName"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.SmartList.Forms.FavoriteForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnAdd"",{{""visible"",true},{""enabled"",true}}},{""btnCancel"",{{""visible"",true},{""enabled"",true}}},{""btnDelete"",{{""visible"",true},{""enabled"",true}}},{""btnSave"",{{""visible"",true},{""enabled"",true}}},{""tbFolder"",{{""visible"",true},{""enabled"",true}}},{""tbTitle"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

			dpo = new FormPermissionDpo();
			dpo.Role_ID = 6;
			dpo.Ty = 1;
			dpo.Key_Name = "Sys.SmartList.Forms.MainForm";
			dpo.Value = @"{{""visible"",true},{""enabled"",true},{""nodes"",{{""btnInquiry"",{{""visible"",true},{""enabled"",true}}},{""btnPrint"",{{""visible"",true},{""enabled"",true}}},{""btnSwitchView"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonAbout"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonAddFavorite"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonEdit"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonEditGridMode"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonPanelCollapse"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonRefresh"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonSave"",{{""visible"",true},{""enabled"",true}}},{""toolStripButtonStop"",{{""visible"",true},{""enabled"",true}}}}}}";
			list.Add(dpo);

		}

	}
}
