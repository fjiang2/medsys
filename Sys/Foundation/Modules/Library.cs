using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;
using Sys.Data.Manager;
using System.Reflection;
using Sys.Foundation.DpoClass;


namespace Sys.Modules
{
    public class Library
    {
        private static Library instance = null;
        public static Library Instance
        {
            get
            {
                if (instance == null)
                    instance = new Library();

                return instance;
            }
        }


        private List<RegisteredAssembly> list;

        private Library()
        {
            this.list = new TableReader<RegisteredAssembly>(AssemblyDpo._Inactive.ColumnName() == 0).ToList();
        }


        public RegisteredAssembly Find(string moduleName)
        {
            if (this.list.Exists(dpo => dpo.AssemblyName == moduleName))
                return this.list.Find(dpo => dpo.AssemblyName == moduleName);
            else
                return null;
        }
        
        public Assembly GetAssembly(string moduleName)
        {
            var dpo = Library.Instance.Find(moduleName);
            if (dpo == null)
                return null;

            return dpo.Assembly;
        }


        public override string ToString()
        {
            return string.Format("Library has {0} assemblies", list.Count);
        }



        public static IEnumerable<Assembly> Assemblies
        {
            get
            {
                return Library.Instance.list.Select(dpo => dpo.Assembly).ToArray();
            }
        }
    

        public static IEnumerable<string> AssemblyNames
        {
            get
            {
                return Library.Assemblies.Select(assembly => assembly.GetName().Name);
            }
        }

      

        public static string AssemblyPath(Assembly assembly, string subpath)
        {
            return AssemblyPath(assembly.GetName().Name, subpath);
        }

        public static string AssemblyPath(string assemblyName, string subpath)
        {
            return Library.Instance.Find(assemblyName).Path(subpath);
        }

    

        /// <summary>
        /// return Dictionary<tableName, typeof(DPObject)>
        /// </summary>
        public static TableDpoDictionary GetTableDpoDict()
        {
            TableDpoDictionary dict = new TableDpoDictionary();
            foreach (Assembly assembly in Library.Assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.BaseType == typeof(DPObject))
                    {
                        if (type.GetAttributes<TableAttribute>().Length != 0)
                        {
                            DPObject dpo = (DPObject)Activator.CreateInstance(type);
                            dict.Add(dpo.TableName, type);
                        }
                    }
                }
        
            }

            return dict;
        }

      

        /// <summary>
        /// Get Enum Types from C# source code
        /// </summary>
        /// <returns></returns>
        public static List<Type> GetEnumTypeList()
        {
            List<Type> list = new List<Type>();
            foreach (Assembly assembly in Library.Assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsEnum)
                    {
                        DataEnumAttribute[] attributes = type.GetAttributes<DataEnumAttribute>();
                        if(attributes.Length > 0)
                            list.Add(type);
                    }
                }

            }

            return list;
        }


        
    
    }
}
