using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Platform.Forms;

namespace Sys.Platform
{
    public class Application
    {

        protected Application()
        { 
        
        }
    
        internal static MainForm mainForm = null;
        
        public static MainForm MainForm
        {
            get
            {
                return mainForm;
            }
        }
    }
}
