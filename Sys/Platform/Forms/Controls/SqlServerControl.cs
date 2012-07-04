﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;
using Sys.DataManager;

namespace Sys.Platform.Forms
{
    public partial class SqlServerControl : UserControl
    {
        public SqlServerControl()
        {
            InitializeComponent();
        }


        public string DatabaseName
        {
            get {  return comboBoxDatabase.Text; }
        }


        public string ServerName
        {
            get { return comboBoxServer.Text; }
        }

        private string GetConnection()
        {
            string server, userName, password;
            bool integratedSecurity;

            server = comboBoxServer.Text;
            userName = textBoxUserName.Text;
            password = textBoxPassword.Text;
            integratedSecurity = !textBoxUserName.Enabled;

            string security = "integrated security=SSPI;";

            if (!integratedSecurity)
                security = string.Format("user id= {0}; password={1};", userName, password);

            return string.Format("data source={0}; initial catalog={1}; {2} pooling=false", server, this.comboBoxDatabase.Text, security);

        }

        private void comboBoxServer_DropDown(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (comboBoxServer.Items.Count == 0)
                {
                    string[] servers = SqlServer.GetAvailableServers();

                    if (servers != null && servers.Length != 0)
                    {
                        foreach (string server in servers)
                        {
                            comboBoxServer.Items.Add(server);
                        }
                        int index = comboBoxServer.FindStringExact("(local)");
                        if (index >= 0)
                            comboBoxServer.Text = (string)comboBoxServer.Items[index];
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void radioButtonSQLServerAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            Synchronize();
        }

        private void Synchronize()
        {
            bool windowsAuthentication = radioButtonWindowsAuthentication.Checked;

            textBoxUserName.Enabled = !windowsAuthentication;
            textBoxPassword.Enabled = !windowsAuthentication;
            labelUserName.Enabled = !windowsAuthentication;
            labelPassword.Enabled = !windowsAuthentication;
        }

        private void radioButtonWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            Synchronize();
        }

        private void comboBoxDatabase_DropDown(object sender, EventArgs e)
        {
            if (!radioButtonWindowsAuthentication.Checked && (textBoxUserName.Text == "" || textBoxPassword.Text == ""))
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string server, userName, password;
                bool integratedSecurity;

                //Remove old items
                comboBoxDatabase.Items.Clear();

                server = comboBoxServer.Text;
                userName = textBoxUserName.Text;
                password = textBoxPassword.Text;
                integratedSecurity = !textBoxUserName.Enabled;
                string[] databases = SqlServer.GetDatabases(server, integratedSecurity, userName, password);

                foreach (string database in databases)
                {
                    comboBoxDatabase.Items.Add(database);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }



        public bool Connect()
        {
            string databaseName;
            databaseName = comboBoxDatabase.Text;

            //Check there is a database name
            if (databaseName == string.Empty)
            {
                MessageBox.Show("Please enter a database name");
                return false;
            }

            Sys.Constant.CONNECTION_STRING = GetConnection();
            Sys.Constant.DB_SYSTEM = databaseName;
            Sys.Constant.DB_DEFAULT = databaseName;

            return true;
        }
    }
}
