using System;
using System.Collections.Generic;
using System.Text;
using Tie;
using System.Data;
using Sys.ViewManager;
using System.Reflection;
using System.Windows.Forms;
using Sys.Workflow.Forms;

namespace Sys.Workflow.Collaborative.Protocols
{

    /**
     * WinForm JSON Protocol
     * 
     * {
     *   FormClass: "LOTO.Forms.CheckInOutForm", //Full Name of WinForm class
     *   Arguments: {arg1, arg2, ...),      //constructor arguments
     *   Title: "Form Caption",
     *   Properties:                        //Form's public properties are set before WinForm pop up.
     *            {
     *              Enabled: true,
     *              Visible: false,
     *              ....
     *            } 
     *   Result:                            //Retrieve properties as Activity Result
     * }
     * 
     ***/

    class WinFormProtocol
    {
        private VAL val;
        public string FormClass;
        private object[] constructorargs; 

        public WinFormProtocol(VAL val)
        {
            this.val = val;

            if (val["FormClass"].Undefined)
            {
                throw new Exception("FormClass is not defined in " + val.ToString());
            }

            
            this.FormClass = val["FormClass"].Str;

            if (val["Arguments"].Defined)
                this.constructorargs = val["Arguments"].ObjectArray;
            else
                this.constructorargs = null;

        }

        public ActivityWinForm NewInstance()
        {
            ActivityWinForm form = (ActivityWinForm)
                HostType.NewInstance(this.FormClass, constructorargs);

            if (val["Title"].Defined)
                form.ChangeCaption(string.Format("{0}({1})",form.Text, val["Title"].Str));

            return form;
        }

        public void SetProperties(Form form)
        {

            if (val["Properties"].Defined)
            {
                VAL props = val["Properties"];
                HostType.SetObjectProperties(form, props);
            }
        }


        public VAL GetResults(Form form)
        {
            VAL props = val["Results"];
            if (props.Undefined)
                return new VAL();

            //return HostType.GetObjectProperties(form, props);
            return GetResults(form, props);
        }

        public VAL GetResults(object instance, VAL props)
        {
            VAL val = new VAL();
            object obj;
            Type type = instance.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            bool found = false;
            for (int i = 0; i < props.Size; i++)
            {
                VAL prop = props[i];
                string key = prop.Str;
                found = false;

                foreach (FieldInfo info in fields)
                {
                    if (info.Name == key)
                    {
                        obj = info.GetValue(instance);
                        val[info.Name] = VAL.Boxing(obj);
                        found = true;
                        break;
                    }
                }
                
                if (!found)
                {
                    foreach (PropertyInfo info2 in properties)
                    {
                        if (info2.Name == key)
                        {
                            if (info2.CanRead)
                            {
                                obj = info2.GetValue(instance, null);
                                val[info2.Name] = VAL.Boxing(obj);
                            }
                            break;
                        }
                    }
                }
            }
            
            return val;
        }

      

        //public VAL VAL
        //{
        //    get
        //    {
        //        VAL val = new VAL();
        //        val["FormClass"] = new VAL(this.FormClass);

        //        return val;
        //    }
        //}
    }
}
