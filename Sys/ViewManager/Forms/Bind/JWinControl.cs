using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms ;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    
    public class JWinControl : ColumnAdapter
    {


        System.Windows.Forms.Control control;

        protected System.Windows.Forms.Control Control
        {
            get { return control; }
        }

        
        /// Constructor
        public JWinControl(Control control, DataField field)
            : base(field)
        {
            this.control = control;
        }


    }
}
