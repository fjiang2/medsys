using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.ViewManager.Modules
{
    /// <summary>
    /// a class implemented IPlugInForm must have a default constructor()
    /// system will automatically add all WinBaseForm if IPlugInForm is not implemented
    /// </summary>
    interface IPlugInForm
    {
        /// <summary>
        /// register BaseForm into application, remove menu security setting
        /// </summary>
        void AddForms();

        /// <summary>
        /// unregister BaseFrom from application, remove form security setting.
        /// </summary>
        void RemoveForms();
    }
}
