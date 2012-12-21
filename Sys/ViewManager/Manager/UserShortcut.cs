using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.ViewManager.Manager
{
    public enum ShortcutType
    { 
        Desktop,
        System
    }


    /// <summary>
    /// user customerized shortcut, which mainly is a static method
    /// </summary>
    public class UserShortcut : DpoClass.ShortcutDpo
    {
        public UserShortcut()
        { 
        }

        public UserShortcut(DataRow row)
            : base(row)
        { 
        }

        public UserShortcut(string key)
            : base(key)
        {
        }
        
        public UserShortcut(ShortcutType type)
        {
            
        }

        internal TaskDataType Type
        {
            get
            {
                return (TaskDataType)base.Ty;
            }
            set
            {
                base.Ty = (int)value;
            }
        }
    }
}
