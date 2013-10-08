using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.ViewManager.Modules
{
    /// <summary>
    /// Module has ability to add/remove menu items to application
    ///  a class implemented IPlugInMenu must have a default constructor()
    /// </summary>
    public interface IPlugInMenu
    {
        void AddMenuItems();
        void RemoveMenuItems();
    }
}
