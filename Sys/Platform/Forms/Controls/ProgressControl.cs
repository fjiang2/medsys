using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys;
using Sys.Data.Manager;

namespace Sys.Platform.Forms
{
    public partial class ProgressControl : UserControl
    {
        Worker worker;
        private Action<Worker> action = null;
      //  private Action<RunWorkerCompletedEventArgs> completed = null;

        public ProgressControl()
        {
            InitializeComponent();
            
            this.worker = GetWorker();
        }

        public Button ActionButton
        {
            get
            {
                return this.btnAction;
            }
        }

        private Worker GetWorker()
        {
            this.txtMessage.Text = "";

            Worker worker = new Worker();

            worker.ProgressChanged += delegate(object s, ProgressChangedEventArgs e1)
            {
                string message = "";
                if (e1.UserState is UserState)
                {
                    UserState state = (UserState)e1.UserState; ;

                    progressBar1.Value = state.Progress1;
                    progressBar2.Value = state.Progress2;

                    txtCounter1.Text = string.Format("{0} % completed.", state.Progress1);
                    txtCounter2.Text = string.Format("{0} % completed.", state.Progress2);

                    message = state.Message;

                }
                else if (e1.UserState is string)
                {
                    progressBar1.Value = e1.ProgressPercentage;
                    message = (string)e1.UserState;
                    txtCounter1.Text = string.Format("{0} % completed.", e1.ProgressPercentage);
                }
                else
                    progressBar1.Value = e1.ProgressPercentage;


                if (message != "")
                {
                    txtMessage.Text += message + "\r\n";
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                    txtMessage.ScrollToCaret();
                }


            };

            worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e1)
            {
                if (e1.UserState is UserState)
                {
                    progressBar1.Value = 100;
                    txtCounter1.Text = "100% completed.";

                    progressBar2.Value = 100;
                    txtCounter2.Text = "100% completed.";
                }
                else if (e1.UserState == null || e1.UserState is string)
                {
                    progressBar1.Value = 100;
                    txtCounter1.Text = "100% completed.";
                }
            };

            return worker;
        }


        public Worker Worker
        {
            get { return this.worker; }
        }

        public Action<Worker> Action
        {
            get { return this.action; }
            set { this.action = value; }
        }

        //public Action<RunWorkerCompletedEventArgs> Completed
        //{
        //    get { return this.completed; }
        //    set { this.completed = value; }
        //}

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (action == null)
                return;

            this.btnAction.Enabled = false;

            worker.DoWork += delegate(object s, DoWorkEventArgs e1)
            {
                this.action(worker);
            };

            worker.RunWorkerAsync();

            this.btnAction.Enabled = true;
        }
    }
}
