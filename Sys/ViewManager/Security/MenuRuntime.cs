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

        private Memory DS = new Memory();
        private IMainForm mainForm;
        MenuConsumer menuConsumer;

        public MenuRuntime(MenuConsumer menuConsumer,  IMainForm mainForm)
        {
            this.menuConsumer = menuConsumer;
            this.mainForm = mainForm;

            HostType.Register(typeof(System.Windows.Forms.MessageBox));
            HostType.Register(typeof(FormPlace), true);
           
            DS["This"] = VAL.Boxing(this);
            DS["CurrentUser"] = VAL.Boxing(Sys.Security.Account.CurrentUser);
            DS["owner"] = VAL.Boxing(mainForm.Form);
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
            BaseForm form = NewInstance(formClass, args);
            if (form == null)
                return;


            if(MenuItem.IconImage != null)
                form.IconImage = MenuItem.IconImage;

            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            form.PopUp(mainForm.Form, formPlace);
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
            DockPanel dockPanel = this.menuConsumer.AddDockPanel(MenuItem, control);
            control.Tag = dockPanel;        
        }

        public void OpenDialog(string formClass, object[] args)
        {
            BaseForm form = NewInstance(formClass, args);
            if (form == null)
                return;

            if (MenuItem.IconImage != null)
                form.IconImage = MenuItem.IconImage;

            form.PopDialog(mainForm.Form);
        }

        private BaseForm NewInstance(string formClass, object[] args)
        {
            try
            {
                return (BaseForm)Sys.Reflector.NewInstance(formClass, args);
            }
            catch (Exception ex)
            {
                string message = string.Format("invalid form [{0}], {1}", formClass, ex.Message);
                MessageBox.Show((Form)this.mainForm, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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

            //Note:
            //When error occurs during invoking MenuConsumer.AddDockPanel(...), 
            //Clear Column[Configuration] in Table UserProfile(SYS00505), because formDockManager.RestoreLayout() may get inconsistant data

            try
            {
                Script.Execute(_SCOPE, code, DS, new StaticFunction());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message for developer", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
			
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
