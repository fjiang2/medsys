using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Sys.Data;
using Sys.Security;
using Sys.Foundation.DpoClass;
using Sys.ViewManager.Forms;


namespace Sys.Platform.Forms
{
    public partial class UserRoleSetting : BaseForm
    {

        string currentUserName = "";
        List<int> currentRoles = new List<int>();
        bool modified = false;

        public UserRoleSetting()
        {
            InitializeComponent();
     
            lvUsers.GridLines = true;
            lvUsers.View = View.Details;
            lvUsers.FullRowSelect = true;

            lvUserRoles.GridLines = true;
            lvUserRoles.View = View.Details;
            lvUserRoles.FullRowSelect = true;

            lvAllRoles.GridLines = true;
            lvAllRoles.View = View.Details;
            lvAllRoles.FullRowSelect = true;

        }
        
        private void SecuritySetting_Load(object sender, EventArgs e)
        {
            PopulateUsers();
            
            lvUserRoles.Columns.Add("Role ID", 50, HorizontalAlignment.Left);
            lvUserRoles.Columns.Add("Name", 120, HorizontalAlignment.Left);

            lvAllRoles.Columns.Add("Role ID", 50, HorizontalAlignment.Left);
            lvAllRoles.Columns.Add("Name", 120, HorizontalAlignment.Left);

            if (account.IsAdmin)
            {
                this.btnSave.Visible = true;
                this.btnSave.Enabled = true;
            }
        }

        private void PopulateUsers()
        {
            lvUsers.Columns.Add("Employee ID", 60, HorizontalAlignment.Left);
            lvUsers.Columns.Add("First Name", 80, HorizontalAlignment.Left);
            lvUsers.Columns.Add("Last Name", 80, HorizontalAlignment.Left);
            lvUsers.Columns.Add("Class", 80, HorizontalAlignment.Left);

            DataTable dt = SqlCmd.FillDataTable<UserDpo>(
                "SELECT User_Name, First_Name, Last_Name, Group_Name FROM {0} WHERE Inactive = 0 AND User_ID <> {1}",
                UserDpo.TABLE_NAME,
                (int)PredefinedRole.devel);

            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr[0].ToString(), 0);
                item.SubItems.Add(dr[1].ToString());
                item.SubItems.Add(dr[2].ToString());
                item.SubItems.Add(dr[3].ToString());
                lvUsers.Items.Add(item);
            }
        }

        private void PopulateAllRoles()
        {
            lvAllRoles.Items.Clear();
            DataTable dt = Role.AllRoles();

            foreach (DataRow dr in dt.Rows)
            {
                string roleID = dr["Role_ID"].ToString();
                if(!RoleExisted(roleID))
                {
                    ListViewItem item = new ListViewItem(roleID, 0);
                    item.SubItems.Add(dr["Role_Name"].ToString());
                    lvAllRoles.Items.Add(item);
                }
            }
        }

        private void PopulateUserRoles(string userName)
        {
            currentUserName = userName;
            currentRoles.Clear();
             
  
            lvUserRoles.Items.Clear();
            DataTable dt = Role.UserRoles(userName);

            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem item = new ListViewItem(dr["Role_ID"].ToString(), 0);
                item.SubItems.Add(dr["Role_Name"].ToString());
                lvUserRoles.Items.Add(item);
                currentRoles.Add((int)dr["Role_ID"]);
            }
        }

        private void lvUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem item = e.Item;
            if (item.Text == "" || item.Text == currentUserName)
                return;

            if (modified)
            {
                if (MessageBox.Show("Roles changes are not saved, save it?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    btnSave_Click(null, null); 
            }

            lblCurrentUser.Text = string.Format("{0} {1}", item.SubItems[1].Text, item.SubItems[2].Text);
            modified = false;
            PopulateUserRoles(item.Text);
            PopulateAllRoles();
        }


        bool RoleExisted(string roleID)
        { 
            foreach (ListViewItem item in lvUserRoles.Items)
            {
                if (item.Text == roleID)
                        return true;
            }
            return false; 
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAllRoles.SelectedItems)
            {
                if(!RoleExisted(item.Text))
                {
                    lvAllRoles.Items.Remove(item);    
                    lvUserRoles.Items.Add(item);
                    
                    modified = true;
                }
            }

            lvAllRoles.Sort();
            lvUserRoles.Sort();
        }

        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvUserRoles.SelectedItems)
            {
                lvUserRoles.Items.Remove(item);
                lvAllRoles.Items.Add(item);

                modified = true;
            }

            lvAllRoles.Sort();
            lvUserRoles.Sort();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TableName tableName = typeof(UserDpo).TableName();
            int userID = (int)SqlCmd.ExecuteScalar(
                tableName.Provider,
                "SELECT User_ID FROM {0} WHERE User_Name='{1}'", tableName.FullName, currentUserName);

            foreach (ListViewItem item in lvUserRoles.Items)
            {
                int roleID = Int32.Parse(item.Text);
                if (currentRoles.IndexOf(roleID) >= 0)
                {
                    currentRoles.Remove(roleID); 
                }

                UserRole UR = new UserRole(userID, roleID);
                if (!UR.Exists)
                {
                    UR.User_ID = userID;
                    UR.Role_ID = roleID;
                }
                UR.Save();
            }


            string x = "";
            foreach (int r in currentRoles)
            {
                if (x != "") 
                    x += ",";
                x += r.ToString();
            }
            if (x != "")
            {
                TableName tableName2 = typeof(UserRoleDpo).TableName();
                SqlCmd.ExecuteScalar(tableName.Provider,
                    "DELETE FROM {0} WHERE User_ID={1} AND Role_ID IN ({2})", tableName2.FullName, userID, x);
            }

            MessageBox.Show("Role changes are saved.");
            
            modified = false;
            PopulateUserRoles(currentUserName);
            PopulateAllRoles();
        }

        private void lvUserRoles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem item = listView.SelectedItems[0];
                int roleID = Int32.Parse(item.Text);
                string roleName = item.SubItems[1].Text;
                RoleSetting x = new RoleSetting(roleID);
                x.MaintenanceEntry = new object[] { roleID, roleName };
                x.PopUp(this); 
            }

        }

        private void toolStripButtonRoleSetting_Click(object sender, EventArgs e)
        {
            RoleSetting x = new RoleSetting(0);
            x.MaintenanceEntry = new object[] {0, "Admin"};
            x.PopUp(this); 
        }

        private void toolStripButtonAddUser_Click(object sender, EventArgs e)
        {
            BaseForm form = new CreateUserAccount();
            form.PopUp(this);
        }

 
        
    

    }
}