using System;
using System.Collections.Generic;
using System.Text;
using Sys.ViewManager;
using System.Windows.Forms;
using System.Data;
using Tie;
using System.Reflection;
using Sys.Security;
using Sys.ViewManager.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using Sys.ViewManager.Manager;

namespace Sys.ViewManager.Security
{
    class MenuRuntime
    {
        private const string _SCOPE = "menuItem";
        private const string _SO = "SO";

        private IMainForm mainForm;
        private System.Windows.Forms.Form owner;
        private Memory DS = new Memory();

        public MenuRuntime(MenuConsumer menuConsumer,  IMainForm mainForm)
        {
            this.mainForm = mainForm;
            this.owner = mainForm.Form;

            HostType.Register(typeof(System.Windows.Forms.MessageBox));
            HostType.Register(typeof(FormPlace), true);
           
            DS["This"] = VAL.Boxing(this);
            DS["CurrentUser"] = VAL.Boxing(Sys.Security.Account.CurrentUser);
            DS["owner"] = VAL.Boxing(owner);
        }

        public void OpenForm(string formClass)
        {
           OpenForm(formClass, null);
        }

        public void OpenForm(FormPlace formPlace, string formClass)
        {
           OpenForm(formPlace, formClass, null);
        }

        public void OpenForm(string formClass, object[] args)
        {
            OpenForm(FormPlace.Auto, formClass, args);
        }


        public void OpenForm(FormPlace formPlace, string formClass, object[] args)
        {
            BaseForm form = (BaseForm)Sys.Reflector.NewInstance(formClass, args);
            
            if(MenuItem.IconImage != null)
                form.IconImage = MenuItem.IconImage;

            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            form.PopUp(owner, formPlace);
            Cursor.Current = cursor;
        }

        public void OpenFormBySO(string formClass)
        {
            if (!Sys.Security.Profile.Instance.ContainsKey(_SO))
            {
                MessageBox.Show("Please Select Sales Order before click Menu","Warning");          
                return ;
            }
            string SO = (string)Sys.Security.Profile.Instance[_SO];  
            OpenForm(formClass, new object[] {SO});
        }

        public void OpenControl(Control control)
        {
            mainForm.ShowMenuItemOnDockPanel(MenuItem, control);
        }

        public void OpenReport(string reportID)
        {
           mainForm.Report.OpenReport(reportID);
        }

        private UserMenuItem MenuItem
        {
            get
            {
                return (UserMenuItem)DS[_SCOPE].value;
            }
        }

        public void menuItem_Click(object sender, ItemClickEventArgs e)
        {
            BarItem barItem = e.Item;
            UserMenuItem menuItem = (UserMenuItem)barItem.Tag;

            string code = menuItem.Command.Replace("Open", "This.Open");
            
            DS["sender"] = VAL.Boxing(sender);
            DS["e"] = VAL.Boxing(e);
            DS[_SO] = VAL.Boxing(Sys.Security.Profile.Instance[_SO]);
            DS[_SCOPE] = VAL.Boxing(menuItem);

            Script.Execute(_SCOPE, code, DS, new StaticFunction());
			
        }
    }


    class StaticFunction : IUserDefinedFunction
    {
        public StaticFunction()
        { }

        public VAL Function(string func, VAL parameters, Memory DS)
        {
            switch (func)
            {
                case "InvokeStaticMethod":  //InvokeStaticMethod(assemblyName, className, methodName, parameters)
                    if (parameters.Size == 4)
                    {
                        string assemblyName = parameters[0].Str;
                        string className = parameters[1].Str;
                        string methodName = parameters[2].Str;
                        Assembly assembly = Assembly.Load(assemblyName);
                        Type type = assembly.GetType(className);
                        System.Reflection.MethodInfo methodInfo = type.GetMethod(methodName);
                        VAL val = VAL.Boxing(methodInfo.Invoke(null, parameters[3].ObjectArray));
                        return val;
                    
                    }
                    break;
            }

            return null;

        }
    }
}
