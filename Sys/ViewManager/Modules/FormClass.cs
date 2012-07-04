using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.ViewManager.Dpo;
using Sys.ViewManager.Forms;

namespace Sys.ViewManager.Modules
{
    /// <summary>
    /// Keep Windows Form's ICON, Caption, used by Shortcuts Manager, System Menu
    /// </summary>
    public class FormClass : FormClassDpo
    {
        public FormClass()
        { 
        }

        public FormClass(string formClass)
        {
            this.Form_Class = formClass;
            this.Load();
        }

        public FormClass(Type type)
        {
            this.Form_Class = type.FullName;
            this.Load();
        }

        public FormClass(BaseForm form)
        {
            this.Form_Class = form.GetType().FullName;
            this.Load();
        }
    }
}
