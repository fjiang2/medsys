using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tie;

namespace Sys.ViewManager.Forms
{
    //--------------------------------------------------------------------------------------------------------------------------------
    public interface IMaintenanceForm
    {

        /// <summary>
     /// Show Maintenance WinForm
     /// </summary>
     /// <param name="owner"></param>
     /// <returns></returns>
        DialogResult PopUp(ContainerControl owner);

        /// <summary>
        /// Initialize the ID, and load the rest of data based on ID searching.
        /// </summary>
        object MaintenanceEntry { set;}

    }


  
}
