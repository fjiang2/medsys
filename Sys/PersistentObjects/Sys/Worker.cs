using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Sys
{
    public class UserState
    {
        public int Progress1;
        public int Progress2;
        public string Message;

        public UserState()
        {
        }
    }

    public class Worker : BackgroundWorker
    {
        private UserState state = new UserState();
        private bool cancelled = false;

        public Worker()
        {
            this.WorkerReportsProgress = true;
        }

        public void Cancel()
        {
            this.cancelled = true;
        }

        public bool SetProgress(int progress1, int progress2)
        {
            this.state.Progress1 = progress1;
            this.state.Progress2 = progress2;
            this.state.Message = "";
            this.ReportProgress(0, state);

            return this.cancelled;
        }


        public bool SetProgress(int progress2, string message)
        {
            this.state.Progress2 = progress2;
            this.state.Message = message;
            this.ReportProgress(0, state );

            return this.cancelled;
        }

        public bool SetProgress(int progress2)
        {
            this.state.Progress2 = progress2;
            this.state.Message = "";
            this.ReportProgress(0, state);

            return this.cancelled;
        }


        public bool SetProgress(string message)
        {
            this.state.Progress2 = 0;
            this.state.Message = message;
            this.ReportProgress(0, state);

            return this.cancelled;
        }

        public bool SetProgress(int progress1, int progress2, string message)
        {
            this.state.Progress1 = progress1;
            this.state.Progress2 = progress2;
            this.state.Message = message;
            this.ReportProgress(0, state);

            return this.cancelled;
        }

    }

}
