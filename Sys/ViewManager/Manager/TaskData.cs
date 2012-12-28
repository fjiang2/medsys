using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using DevExpress.XtraNavBar;
using Sys.ViewManager.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace Sys.ViewManager.Manager
{
    enum TaskDataType
    { 
        Method  = 1,            //regular method
        StaticMethod  = 2,      //static method
        NewBaseForm   = 3,      //BaseForm
    }

    enum TaskDataGroup
    { 
        Favorite,
        Recent,
        Application,
        Menu
    }

    class TaskData : IValizable, IComparer<TaskData>
    {
        private string key;
        internal readonly string caption;
        internal bool pinned;
        internal DateTime time;
        internal readonly TaskDataType ty;

        private Type hostType;
        private string code;

        // new BaseForm as command
        //Tie code => new hostType(args)
        public TaskData(string key, bool pinned, string caption, Type formClassType, object[] args)
            : this(key, pinned, caption, 
                TaskDataType.NewBaseForm, 
                formClassType, 
                string.Format("new {0}({1})", formClassType, string.Join<VAL>(",",VAL.Boxing(args))))
        { 
        }


        //static method as command
        //Tie code =>typeof(hostType).func(args) because of static method
        //or code  => hostType.func(args) after HostType.Register(typeof(hostType));
        public TaskData(string key, bool pinned, string caption, Type hostType, string func, object[] args)
            : this(key, pinned, caption, 
                TaskDataType.StaticMethod, 
                hostType, 
                string.Format("typeof({0}).{1}({2})", hostType.FullName, func, string.Join<VAL>(",", VAL.Boxing(args))))
        {
        }

        public TaskData(string key, bool pinned, string caption, TaskDataType ty, Type hostType, string code)
        {
            this.key = key;
            this.pinned = pinned;
            this.caption = caption;
            this.ty = ty;

            this.code = code;
            this.hostType = hostType;
            
            this.time = DateTime.Now;
        }
        
        
        public TaskData(VAL val)
        {
            key = val["Key"].Str;
            caption = val["Caption"].Str;
            ty = (TaskDataType)val["TaskType"].Intcon;
            hostType = Tie.HostType.GetType(val["HostType"].Str);
            code = val["Code"].Str;

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
            val["TaskType"] = VAL.Boxing((int)ty);
            val["HostType"] = VAL.Boxing(hostType.FullName);
            val["Code"] = VAL.Boxing(code);
            val["Pinned"] = VAL.Boxing(pinned);
            val["Time"] = VAL.Boxing(time);
            return val;
        }

        public string Key
        {
            get { return this.key; }
        }

        public Type HostType
        {
            get
            {
                return this.hostType;
            }
        }

        public object Evaluate()
        {
            try
            {
                return Tie.Script.Evaluate(code).HostValue;
            }
            catch (Exception ex)
            {
                string message = string.Format("invalid form [{0}], {1}", code, ex.Message);
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void SaveNewShortcut(UserShortcut shortcut)
        {
            System.Drawing.Image icon = SysInformation.Icon.CreateIcon16X16().ToBitmap();

            shortcut.Type = this.ty;
            shortcut.Shortcut = this.key;
            shortcut.Label = this.caption == null ? "Unknown" : caption;
            shortcut.Description = "";
            shortcut.Code = this.code;
            shortcut.IconImage = icon;
            shortcut.Save();
        }
      
 
        public override string ToString()
        {
            if (caption != null)
                return caption;

            return code;
        }

       
    }
}
