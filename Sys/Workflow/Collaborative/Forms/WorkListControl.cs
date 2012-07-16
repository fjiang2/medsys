using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager.Forms ;
using Sys.ViewManager;
using Sys.Data;
using Sys.Workflow.Dpo;
using Sys.ViewManager.Security;
using Sys.Foundation.Dpo;


namespace Sys.Workflow.Collaborative.Forms
{
    public partial class WorkListControl : BaseUserControl 
    {
        string selectCommand = "SELECT * FROM {0} WHERE Deleted=0 AND Released = 1";
        string selectComamndDeveloper = "SELECT * FROM {0}";


        TreeRowView treeView;
        DataTable dataTable;
        public WorkListControl(ContainerControl owner)
        {
            InitializeComponent();
            this.ParentControl = owner;

            imageList1.Images.Add("Workflow", global::Sys.Workflow.Properties.Resources.brick);
            imageList1.Images.Add("Queue", global::Sys.Workflow.Properties.Resources.wrench_orange);

            this.InitializeTreeView();
        }

        private void InitializeTreeView()
        {
          
            if(Sys.Security.Account.CurrentUser.IsDeveloper)
                this.dataTable = SqlCmd.FillDataTable(selectComamndDeveloper, wfWorkflowDpo.TABLE_NAME);
            else
                this.dataTable = SqlCmd.FillDataTable(selectCommand, wfWorkflowDpo.TABLE_NAME);

            treeView = new TreeRowView(treeView1, dataTable);
            treeView.ImageField = "Workflow";

            treeView1.Nodes.Clear();
            treeView.BuildTreeView();
            

            treeView.SelectNode += new TreeRowView.AfterSelectHandler(treeView_TreeViewEventHandler);
            treeView1.MouseDoubleClick +=new MouseEventHandler(treeView1_MouseDoubleClick);


            this.cbWorkflow.Text = "";
            this.cbWorkflow.Items.Clear();

           
        }


        private ContextMenuStrip WorkflowContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem menu1 = new ToolStripMenuItem("Start Workflow Immediately");
            ToolStripMenuItem menu2 = new ToolStripMenuItem("Workflow Instance...");
            ToolStripMenuItem menu3 = new ToolStripMenuItem("Properties...");

            contextMenu.Items.Add(menu1);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(menu2);
            
            if(account.IsDeveloper)
                contextMenu.Items.Add(menu3);


            menu1.Click += delegate(object sender, EventArgs e)
            {
                Workflow workflow = new Workflow(new WorkflowDpo(WorkflowName));
                WorkflowRuntime.StartWorkflowInstance(this, workflow);
            };

            menu2.Click += delegate(object sender, EventArgs e)
            {
                Workflow workflow = new Workflow(new WorkflowDpo(WorkflowName));
                WorkflowInstanceForm form1 = new WorkflowInstanceForm(workflow, true);
                form1.PopUp(this);
            };

            menu3.Click += delegate(object sender, EventArgs e)
            {
                BaseForm form2 = new Collaborative.Forms.WorkflowForm(WorkflowName);
                form2.PopUp(this);
            };

            return contextMenu;
        }


        private string WorkflowName
        {

            get
            {
                if (this.treeView1.SelectedNode is TreeRowNode)
                {
                    TreeRowNode treeNode = (TreeRowNode)this.treeView1.SelectedNode;
                    string workflowName = treeNode.DataRow["Name"] as String;
                    return workflowName;
                }

                return null;
            }
        }

        private void treeView_TreeViewEventHandler(object sender, TreeRowNodeEventArgs e)
        {
            TreeRowNode treeNode = e.TreeRowNode;
            this.treeView1.SelectedNode = treeNode;
            this.cbWorkflow.Text = treeNode.Text;

        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeView treeView1 = (sender as TreeView);

            // Select the clicked node
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            if (treeView1.SelectedNode == null)
                return;


            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (treeView1.SelectedNode is TreeRowNode)  //workflow node
                    {
                        Workflow workflow = new Workflow(new WorkflowDpo(WorkflowName));
                        WorkflowInstanceForm form1 = new WorkflowInstanceForm(workflow, true);
                        form1.PopUp(this);
                    }
                    break;
            }

        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            TreeView treeView1 = (sender as TreeView);

            // Select the clicked node
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            if (treeView1.SelectedNode == null)
                return;

            Point point = (sender as Control).PointToClient(Control.MousePosition);
            TreeNode treeNode = this.treeView1.SelectedNode;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (treeNode is TreeRowNode && treeNode.Nodes.Count == 0)
                    {
                        this.cbWorkflow.Text = ((TreeRowNode)treeNode).DataRow["Label"] as string;
#if DEVELOPER                    
                        Workflow workflow = new Workflow(new WorkflowDpo(WorkflowName));
                        foreach (State state in workflow.States.Values)
                        {
                            if (!state.IsInitialState && !state.IsLogicalState)
                            {
                                TreeNode node = new StateTreeNode(state);
                                treeNode.Nodes.Add(node);
                            }
                        }
#else
                        string SQL = @"
                        SELECT  ID, Name, Label
                        FROM    @States
                        WHERE   Workflow_Name = '{0}'
		                        --AND Ty & {1} <> {1}
		                        AND Ty & {2} <> {2}
                                AND ID IN (
                                SELECT DISTINCT IP.ID
                                FROM    @IPermissions IP
                                        INNER JOIN @UserRoles UR ON UR.Role_ID = IP.Role_ID
                                                                             AND UR.User_ID = {3}
                                WHERE   ty = {4} )
                        ORDER BY Label
                        ";
                        SQL = SQL.Replace("@States", Dpo.wfStateDpo.TABLE_NAME)
                            .Replace("@IPermissions", Sys.ViewManager.Dpo.ItemPermissionDpo.TABLE_NAME)
                            .Replace("@UserRoles", UserRoleDpo.TABLE_NAME);
                        
                        DataTable stateTable = SqlCmd.FillDataTable(SQL,
                            WorkflowName, 
                            (int)StateNodeType.Initial,
                            (int)StateNodeType.Logical,

                            Sys.Security.Account.CurrentUser.UserID, 
                            (int)SecurityType.Workflow
                            );

                        foreach (DataRow dataRow in stateTable.Rows)
                        {
                            TreeNode node = new StateTreeNode1(WorkflowName, (string)dataRow["Name"], (string)dataRow["Label"]);
                            treeNode.Nodes.Add(node);
                        }
#endif
                        treeNode.Expand();
                    }
#if DEVELOPER                       
                    else if (treeNode is StateTreeNode)
                    {
                        State state = ((StateTreeNode)treeNode).state;
                        TaskListForm taskListForm = new TaskListForm(state.Workflow.WorkflowName, state.StateName);
                        taskListForm.ParentControl = this;
                        taskListForm.Text = string.Format("Queue: {0}", state.Data.Title);

                        taskListForm.PopUp(this);

                    }
#else
                    else if (treeNode is StateTreeNode1)
                    {
                        StateTreeNode1 node = (StateTreeNode1)treeNode;

                        TaskListForm taskListForm = new TaskListForm(node.workflowName, node.stateName);
                        taskListForm.ParentControl = this;
                        taskListForm.Text = string.Format("Queue: {0}", node.stateTitle);

                        taskListForm.PopUp(this);

                    }
                    else
                        this.cbWorkflow.Text = treeNode.Text;



#endif

                    break;
                
                case MouseButtons.Right:
                    if (treeNode is TreeRowNode)
                    {
                         WorkflowContextMenu().Show((Control)sender, point.X, point.Y);
                    }
                    else if (treeNode is StateTreeNode)
                    { 
                    }
                    break;
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            InitializeTreeView();
        }

     

    }

    class StateTreeNode1 : TreeNode
    {
        public readonly string workflowName;
        public readonly string stateName;
        public readonly string stateTitle;
        public StateTreeNode1(string workflowName, string stateName, string stateTitle)
            : base(stateTitle)
        {
            this.workflowName = workflowName;
            this.stateName = stateName;
            this.stateTitle = stateTitle;

            this.ImageKey = "Queue";
            this.SelectedImageKey = "Queue";
        }
    }

    class StateTreeNode : TreeNode
    {
        public readonly State state;
        public StateTreeNode(State state)
            : base(state.Data.Title)
        {
            this.state = state;
        }
    }
}
