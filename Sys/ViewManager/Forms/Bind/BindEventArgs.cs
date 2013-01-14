using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.ViewManager.Forms
{
    public delegate void BindDpoHandler(object sender, BindDpoEventArgs e);

    public enum SaveMode
    {
        Insert,
        Update,
        Delete
    }

    public class BindDpoEventArgs : EventArgs
    {
        public bool confirmed;
        public SaveMode mode;

        public BindDpoEventArgs(SaveMode mode)
        {
            this.confirmed = true;
            this.mode = mode;
        }
    }
}
