using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection;
using Sys.Security;
using Tie;
using Sys.Data;
using Sys.Foundation.DpoClass;
using Sys.ViewManager.Forms;

namespace Sys.ViewManager.Security
{

    public class FormConsumer
    {
        
        VAL setting = new VAL();
        
        public FormConsumer(string formID)
        {
            DataTable dataTable = new TableReader<FormPermission>(@"Ty =1 AND Role_ID IN (SELECT Role_ID FROM {0} WHERE User_ID = {1}) AND Key_Name='{2}'",
                UserRoleDpo.TABLE_NAME,
                Account.CurrentUser.UserID, 
                formID).Table;

            if (dataTable == null || dataTable.Rows.Count == 0)
                return;

            if (dataTable.Rows.Count > 1)
            {
                setting = MergeSetting(dataTable);
            }
            else
            {
                DataRow dataRow = dataTable.Rows[0]; 
                string v = (string)dataRow[FormPermission._Value];
                setting = Script.Evaluate(v);
            }
        }

        private VAL MergeSetting(DataTable dataTable)
        {
            string script = "";
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string v = (string)dataRow[FormPermission._Value];
                VAL setting = Script.Evaluate(v);
                script += MergeSetting("",setting); 
            }
            
            if (script != "")
            {
                Memory memory = new Memory();
                Script.Execute("{" + script + "}", memory);

                return VAL.Boxing(memory);
            }

            return new VAL();
        }

        private string MergeSetting(string prefix, VAL setting)
        {
            string script = "";
            for (int i = 0; i < setting.Size; i++)
            {
                VAL v = setting[i];
                if (v[1].IsList)
                {
                    if (prefix == "")
                        script += MergeSetting(v[0].Str, v[1]);
                    else
                    {
                        script += MergeSetting(string.Format("{0}[{1}]", prefix, v[0]), v[1]);
                    }
                }
                else
                {
                    if (prefix == "")
                        script += string.Format("{0}={1};", v[0].Str, v[1]);
                    else
                        script += string.Format("{0}[{1}]={2};", prefix, v[0], v[1]);
                }
            }
            
            return script;
        }

        public bool CanOpenForm
        {
            get
            {
                if (Account.CurrentUser.IsAdmin || Account.CurrentUser.IsDeveloper)
                    return true;

                if (setting.IsNull)
                    return false;

                VAL p = setting["visible"];
				if (!p.Defined) 
                    return false;
                else
                    return p.Boolcon;
            }
        }

        public bool CanCloseForm
        {
            get
            {
                return true;
            }
        }



        public void SetFieldSecurity(object classInstance)
        {
            FieldSecurity(null, setting, classInstance.GetType(), classInstance);
        }

        private static void FieldSecurity(Type grandParent, VAL setting, Type type, object classInstance)
        {

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            foreach (FieldInfo fieldInfo in fields)
            {
                bool userControl = fieldInfo.FieldType.IsSubclassOf(typeof(UserControl));

                if (FormStore.IsCheckedClass(fieldInfo.FieldType.FullName) || userControl)
                {
                    object fieldInstance = fieldInfo.GetValue(classInstance);

                    //controls added during rumtime
                    if (fieldInstance == null)
                        continue;

                    PropertyInfo[] properties = fieldInfo.FieldType.GetProperties();

                    PropertyInfo propertyInfo = fieldInfo.FieldType.GetProperty("Visible");
                    bool visible = Visible(setting, fieldInfo.Name);
                    propertyInfo.SetValue(fieldInstance, visible, null);

                    propertyInfo = fieldInfo.FieldType.GetProperty("Enabled");
                    bool enabled = Enabled(setting, fieldInfo.Name);
                    propertyInfo.SetValue(fieldInstance, enabled, null);

                    if (userControl)
                    {
                        if (grandParent !=null && grandParent== fieldInstance.GetType())
                            continue;

                        if (!setting.IsNull)
                        {
                            VAL p = setting["nodes"][fieldInfo.Name];
                            if (p.Defined)
                                FieldSecurity(type, p, fieldInstance.GetType(), fieldInstance);
                        }
                    }
                }
            }

            if (type.IsSubclassOf(typeof(BaseForm)) && type.BaseType.Name != typeof(BaseForm).Name)
            {
                FieldSecurity(type, setting["nodes"][FormStore.BaseTypeNodeText]["nodes"][type.BaseType.FullName], type.BaseType, classInstance);
            }



            return;
        }



        private static VAL Control(VAL setting, string controlID)
        {
            VAL p = setting["nodes"];
            if (p.Undefined)
                return new VAL();

            return p[controlID];
        }

        private static bool Enabled(VAL setting, string controlID)
        {
            if (setting.IsNull)
                return false;

            VAL control = Control(setting, controlID);
            if (control.IsNull)
                return false;

            VAL p = control["enabled"];
            if (!p.Defined)
                return false;
            else
                return p.Boolcon;
        }

        private static bool Visible(VAL setting, string controlID)
        {
            if (setting.IsNull)
                return false;

            VAL control = Control(setting, controlID);
            if (control.IsNull)
                return false;

            VAL p = control["visible"];
            if (!p.Defined)
                return false;
            else
                return p.Boolcon;
        }

    }
}
