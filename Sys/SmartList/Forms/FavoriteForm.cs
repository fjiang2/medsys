using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager;
using Sys.Security;
using Sys.ViewManager.Forms;
using Sys.Data;
using Sys.SmartList.Dpo;
using Sys.ViewManager.Security;

namespace Sys.SmartList.Forms
{
    public partial class FavoriteForm : BaseForm  
    {

        SecurityType securityType;
        string value;

        CommandDpo par;

        public FavoriteForm(SecurityType securityType, TreeDpoView tree,  string value)
        {
            InitializeComponent();

            TreeDpoNode selectedNode = tree.SelectedDpoNode;
            par = (CommandDpo)selectedNode.Dpo;

        
            this.securityType = securityType;
            this.value = value;

            this.tbTitle.Text = par.Label;
            this.tbFolder.Text = selectedNode.Text;

            treeView1.Nodes.Clear();
            treeView1.DataSource = tree.DataSource;
           

            if (par.Sql_Command == "")
            {
                while (par.ParentID != 0)
                {
                    TreeDpoNode node = tree.SearchTreeNode(par.ParentID);
                    if (node != null)
                    {
                        par = (CommandDpo)node.Dpo;

                        if (par.Sql_Command != "")
                            break;
                    }
                }
            }

            treeView1.BuildTreeView(null, par.ID);
            treeView1.ExpandAll();

            treeView1.AfterSelect += delegate(object sender, TreeViewEventArgs e)
            {
                if (e.Action == TreeViewAction.ByMouse)
                {
                    tbFolder.Text = treeView1.SelectedDpo.NodeText;
                }
            };

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CommandDpo command = new CommandDpo();

            Button button = (Button)sender;
            if (button == this.btnSave)
            {
                command.ID = par.ID;
                command.Load();
                command.ParentID = par.ParentID;         //Save
            }
            else
            {
                command.ID = -1;
                command.ParentID = par.ID;               //Add
                command.Sql_Command = "";
            }

            command.Ty = (int)securityType;
            command.Label = this.tbTitle.Text;
            command.User_Layout = this.value;
            command.ViewMode = par.ViewMode;

            command.Access_Level = (int)(dpdAccess.Text == "Private" ? SecurityLevel.PrivateAccess : SecurityLevel.PublicAccess);
            command.Controlled = true;
            command.Enabled = true;
            command.Visible = true;
            command.Owner_ID = Account.CurrentUser.UserID;
            
            if (command.Exists)
            {
                if (par.Sql_Command != "")  //SmartList Template cannot be overwritten.
                {
                    ErrorMessage = "SmartList Template cannot be overwritten";
                    return;
                }

                if ( par.Owner_ID != account.User_ID)
                {
                    ErrorMessage = "You are not owner of this favorite, you cannot modify it.";
                    return;
                }


                if (MessageBox.Show("Favorite already exists, overwrite it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            command.Save();
            
            InformationMessage = "Favorite is added.";

            this.Close();
        }

  
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = (int)SqlCmd.ExecuteScalar("SELECT COUNT(*) FROM {0} WHERE ParentID={1}", par.TableName, par.ID);
            
            if (count > 0)
            {
                ErrorMessage = "You cannot delete it, this favorite has children favorites.";
                return;
            }

            if (par.Sql_Command != "")  //SmartList Template cannot be overwritten.
            {
                ErrorMessage = "SmartList Template cannot be deleted";
                return;
            }

            if (par.Owner_ID != account.User_ID)
            {
                ErrorMessage = "You are not owner of this favorite, you cannot delete it.";
                return;
            }

            CommandDpo command = new CommandDpo();
            command.ID = par.ID;

            if (MessageBox.Show("Favorite is going to be deleted, are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning  ) == DialogResult.No)
                return;

            command.Delete();

            InformationMessage = "Favorite is delete.";

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}