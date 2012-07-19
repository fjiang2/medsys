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
        private static Library Instance
        {
            get
            {
                if (instance == null)
                    instance = new Library();

                return instance;
            }
        }

        /// <summary>
        /// Dictionary<moduleName, Assembly>
        /// </summary>
        private Dictionary<string, Assembly> assemblies;

        private Library()
        {
            var list = new TableReader<AssemblyDpo>(new ColumnValue(AssemblyDpo._Inactive, 0)).ToList();
            
            this.assemblies = new Dictionary<string, Assembly>();
            foreach (AssemblyDpo assembly in list)
            {
                string name = assembly.AssemblyName;

                try
                {
                    this.assemblies.Add(name, Assembly.Load(name));
                }
                catch (System.IO.FileNotFoundException e)
                {
                    throw e;
                }
            }

        }


        public static Assembly GetAssembly(string moduleName)
        {
            if (Library.Instance.assemblies.ContainsKey(moduleName))
                return Library.Instance.assemblies[moduleName];
            else
                return null;
        }


        public static IEnumerable<string> AssemblyNames
        {
            get
            {
                return Library.Instance.assemblies.Keys.ToArray();
            }
        }

        public static IEnumerable<Assembly> Assemblies
        {
            get
            {
                return Library.Instance.assemblies.Values.ToArray();
            }
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
                        DPObject dpo = (DPObject)Activator.CreateInstance(type);
                        dict.Add(dpo.TableName, type);
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
