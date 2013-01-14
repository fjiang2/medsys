using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Workflow.Forms
{
    public delegate void ActivityEventHandler(object sender, ActivityEventArgs e);

    public class ActivityEventArgs : EventArgs
    {
        public readonly ActivityResult status;
        public readonly object target;

        public ActivityEventArgs(ActivityResult status)
        {
            this.status = status;
            this.target = null;
        }

        public ActivityEventArgs(ActivityResult status, string target)
        {
            this.status = status;
            this.target = target;
        }
    }
}
