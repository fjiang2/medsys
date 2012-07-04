using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using DevExpress.XtraNavBar;
using Sys.ViewManager.Forms;
using System.Drawing;

namespace Sys.ViewManager.Manager
{
    class TaskData : IValizable, IComparer<TaskData>
    {
        internal string key;
        internal string caption;
        string formClass;
        object[] args;
        internal bool pinned;
        internal DateTime time;

        public TaskData(string key, bool pinned, string caption, Type formClassType, object[] args)
        {
            this.key = key;
            this.pinned = pinned;
            this.caption = caption;
            this.formClass = formClassType.FullName;
            this.args = args;
            
            this.time = DateTime.Now;
        }
        
        
        public TaskData(VAL val)
        {
            key = val["Key"].Str;
            caption = val["Caption"].Str; 
            formClass = val["FormClass"].Str;
            args = (object[])val["Arguments"];

            VAL x = val["Pinned"];
            if (x.Defined)
                pinned = (bool)x;
            else
                pinned = true;

            x = val["Time"];
            if (x.Defined)
                time = (DateTime)x;
            else
                time = DateTime.Now;
        }


        public int Compare(TaskData x, TaskData y)
        {
            return y.time.CompareTo(x.time);
        }
      
        public VAL GetValData()
        {
            VAL val = new VAL();
            val["Key"] = VAL.Boxing(key);
            val["Caption"] = VAL.Boxing(caption);
            val["FormClass"] = VAL.Boxing(formClass);
            val["Arguments"] = VAL.Boxing(args);
            val["Pinned"] = VAL.Boxing(pinned);
            val["Time"] = VAL.Boxing(time);
            return val;
        }

        public string FormClass
        {
            get
            {
                return this.formClass;
            }
        }

        public BaseForm NewFormInstance()
        {
            return (BaseForm)Reflector.NewInstance(formClass, args);
        }

        public override string ToString()
        {
            if (caption != null)
                return caption;

            return formClass;
        }

       
    }
}
