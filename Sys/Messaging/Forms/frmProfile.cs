using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager;
using Sys.ViewManager.Forms;
using Sys.Xmpp;
using Sys.Foundation.Dpo;

namespace Sys.Messaging.Forms
{
    public partial class frmProfile : BaseForm 
    {
        BindDpo<UserDpo> binding;
        TextBox txtUserName = new TextBox();

        XmppAccount xmppAccount;

        public frmProfile()
            :this(null, null)
        { 
        
        }

        public frmProfile(XmppAccount xmppAccount, agsXMPP.XmppClientConnection xmppCon)
        {
            InitializeComponent();

            this.allAccess = true;

            this.xmppAccount = xmppAccount;

            UserDpo dpo;
            if (xmppCon != null)
                dpo = new UserDpo(xmppCon.MyJID.User); //this.account.UserName;
            else
                dpo = new UserDpo(Sys.Security.Account.CurrentUser.User_Name);

            binding = new BindDpo<UserDpo>(dpo);
            binding.Bind(this.txtUserName, UserDpo._User_Name);

            binding.Bind(this.txtFirstName, UserDpo._First_Name);
            binding.Bind(this.txtLastName, UserDpo._Last_Name);
            binding.Bind(this.txtMiddleName, UserDpo._Middle_Name);
            binding.Bind(this.txtNickname, UserDpo._Nickname);
            binding.Bind(this.txtEmailAddress, UserDpo._Email);


            //----------------------------------------------------
            binding.Bind(this.txtCompany, UserDpo._Group_Name);
            binding.Bind(this.txtDepartment, UserDpo._Department);
            binding.Bind(this.txtJobTitle, UserDpo._Job_Title);
            binding.Bind(this.txtSupervisor, UserDpo._Supervisor);

            binding.Bind(this.txtWorkPhone, UserDpo._WorkPhone);
            binding.Bind(this.txtWorkFax, UserDpo._WorkFax);
            binding.Bind(this.txtWorkPager, UserDpo._WorkPager);
            binding.Bind(this.txtWorkMobile, UserDpo._WorkMobile);

            //----------------------------------------------------
            binding.Bind(this.pictureBox1,UserDpo._Avatar);
            binding.Reset();

        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            binding.Save();
            this.InformationMessage = "Profile information is saved.";
            if (xmppAccount != null)
            {
                Sys.Security.Account a = new Sys.Security.Account(account.UserName);
                xmppAccount.UpdateVcard(a);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    pictureBox1.Image = Bitmap.FromFile(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read image file from disk. Original error: " + ex.Message);
                }


            }

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void txtSupervisor_TextChanged(object sender, EventArgs e)
        {
            if (txtSupervisor.Text == "")
                return;

            Sys.Security.Account acc = new Sys.Security.Account(txtSupervisor.Text);
            if (acc.IsLogined())
                txtSupervisorName.Text = acc.Name;
        }
    }
}
