using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;
using Sys.Modules;
using Sys.ViewManager.Forms;
using Sys.Foundation.DpoClass;

namespace Sys.ViewManager.Modules
{
    /// <summary>
    /// A plug-in is a .NET dll file
    /// which must implements interface IPlugInForm, IPlugInMenu
    /// </summary>
    public class PlugIn
    {
        Assembly assembly;

        public PlugIn(string assemblyName)
        {
            this.assembly = Assembly.Load(assemblyName);
        }

        public PlugIn(Assembly assembly)
        {
            this.assembly = assembly;
        }

        protected string assemblyName
        {
            get
            {
                return assembly.GetName().Name;
            }
        }

        public virtual void Plug()
        {
            AssemblyDpo dpo = new AssemblyDpo();
            dpo.AssemblyName = assemblyName;
            dpo.FullName = this.assembly.FullName;
            dpo.Inactive = false;
            dpo.Version = this.assembly.GetName().Version.ToString();
            dpo.DateInstalled = DateTime.Now;
            dpo.Save();

            foreach (Type type in assembly.GetExportedTypes())
            {
                //Add Menu Items into application
                if (type.IsAbstractOf<IPlugInMenu>())
                {
                    IPlugInMenu obj = (IPlugInMenu)Activator.CreateInstance(type);
                    obj.AddMenuItems();
                }

                if (type.IsAbstractOf<IPlugInForm>())
                {
                    IPlugInForm obj = (IPlugInForm)Activator.CreateInstance(type);
                    obj.AddForms();
                }

                //if IPlugInForm is not implemented, add forms in default way
                if (type.IsSubclassOf(typeof(BaseForm)))
                {
                    FormClass formClass = new FormClass(type);
                    formClass.Form_Class = type.FullName;   //this makes sure form class is not overwritten
                    //formClass.Label = "";
                    formClass.Save();
                }
            }

        }

        public virtual bool Unplug()
        {
            AssemblyDpo dpo = new AssemblyDpo();
            dpo.AssemblyName = assemblyName;
            dpo.Load();
            if (!dpo.Exists)
                return false;

            Assembly assembly = Assembly.Load(dpo.FullName);
            
            //search all BaseForm class
            string L = "";
            foreach (Type type in assembly.GetExportedTypes())
            {
                //Remove Menu Items from application
                if (type.IsAbstractOf<IPlugInMenu>())
                {
                    IPlugInMenu obj = (IPlugInMenu)Activator.CreateInstance(type);
                    obj.RemoveMenuItems();
                }

                //Remove baseform from applicaiton
                if (type.IsAbstractOf<IPlugInForm>())
                {
                    IPlugInForm obj = (IPlugInForm)Activator.CreateInstance(type);
                    obj.RemoveForms();
                }

                if (type.IsSubclassOf(typeof(BaseForm)))
                {
                    if (L != "")
                        L += ",";
                    
                    L += string.Format("'{0}'", type.FullName);
                }
            }

            //remove menu, security setting
            string SQL = @"
                DELETE FROM @IPermissions WHERE ID IN (SELECT ID FROM @UserMenus WHERE Module = '{0}') AND Ty = 2
                DELETE FROM @UserMenus WHERE Module = '{0}'
                DELETE FROM @Permissions WHERE Key_Name IN ({1})
                DELETE FROM @Assemblies WHERE AssemblyName = '{0}'"
                .Replace("@IPermissions", Sys.ViewManager.DpoClass.ItemPermissionDpo.TABLE_NAME)
                .Replace("@Permissions", Sys.ViewManager.DpoClass.FormPermissionDpo.TABLE_NAME)
                .Replace("@UserMenus", Sys.ViewManager.DpoClass.UserMenuDpo.TABLE_NAME)
                .Replace("@Assemblies", AssemblyDpo.TABLE_NAME);

            DataProvider provider = typeof(Sys.ViewManager.DpoClass.ItemPermissionDpo).TableName().Provider;
            SqlCmd.ExecuteNonQuery(provider, SQL, assemblyName, L);
            return true;
        }

        public static Type[] SearchPlugIn(Type startUp, string className)
        {
            AssemblyName[] assemblyNames = Assembly.GetEntryAssembly().GetReferencedAssemblies();
            Module[] modules = startUp.Assembly.GetModules();
            Type[] types = new Type[modules.Length];
            int i = 0;
            foreach (Module module in modules)
            {
                types[i++] = module.Assembly.GetType(className);

            }
            
            return types;
        }

    

    }
}
