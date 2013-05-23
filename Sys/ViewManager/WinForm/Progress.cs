using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars;

namespace Sys.ViewManager.Forms
{
    class Progress
    {
        private JBackgroundWorker worker;
        private Action<JBackgroundWorker> action = null;
        
        private RepositoryItemMarqueeProgressBar progressBar;
        private BarEditItem pogressBarItem;

        public Progress(BarEditItem pogressBarItem)
        {
            this.pogressBarItem = pogressBarItem;
            this.progressBar = (RepositoryItemMarqueeProgressBar)pogressBarItem.Edit;
            this.worker = new JBackgroundWorker();
            this.worker.WorkerReportsProgress = true;

            worker.ProgressChanged += delegate(object s, ProgressChangedEventArgs e1)
            {
                UserState state = (UserState)e1.UserState;
                pogressBarItem.EditValue = state.Message;
                progressBar.ShowTitle = true;
                progressBar.Stopped = false; 
            };

            worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e1)
            {
                UserState state = (UserState)e1.UserState;
                pogressBarItem.EditValue = "100% completed.";

                progressBar.ShowTitle = false;
                progressBar.Stopped = true;
            };
        }

        public Action<JBackgroundWorker> Action
        {
            get { return this.action; }
            set { this.action = value; }
        }

        public JBackgroundWorker Worker
        {
            get { return this.worker; }
        }

        public void Start()
        {
            if (action == null)
                return;


            worker.DoWork += delegate(object s, DoWorkEventArgs e1)
            {
                this.action(worker);
            };

            worker.RunWorkerAsync();

        }
    }
}
