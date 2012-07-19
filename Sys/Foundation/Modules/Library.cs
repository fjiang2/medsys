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
        DPCollection<AssemblyDpo> dpcAssemblies;
        Dictionary<string, Assembly> assemblies;


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


        private Library()
        {
            DataTable dt = SqlCmd.FillDataTable("SELECT * FROM {0} WHERE Inactive = 0", AssemblyDpo.TABLE_NAME);
            dpcAssemblies = new DPCollection<AssemblyDpo>(dt);
            assemblies = new Dictionary<string, Assembly>();

            foreach (AssemblyDpo assembly in dpcAssemblies)
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




        public void CreateTable()
        {
            foreach (Assembly asm in  this.assemblies.Values)
                CreateTable(asm);
        }


        /// <summary>
        /// Create Tables in the SQL Server
        /// </summary>
        /// <param name="assembly"></param>
        public static void CreateTable(Assembly assembly)
        {
            foreach (Type type in assembly.GetExportedTypes())
            {
                if (type.BaseType == typeof(DPObject))
                {
                    DPObject dpo = (DPObject)Activator.CreateInstance(type);
                    dpo.CreateTable();
                }
            }
        
        }


        /// <summary>
        /// return Dictionary<tableName, typeof(DPObject)>
        /// </summary>
        public static TableDpoDictionary GetTableDpoDict()
        {
            TableDpoDictionary dict = new TableDpoDictionary();
            Assembly[] assemblies = Library.GetRegisteredAssemblies();
            foreach (Assembly assembly in assemblies)
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

        public static TableDpoDictionary GetTableDpoDict(Assembly assembly)
        {
            TableDpoDictionary dict = new TableDpoDictionary();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType == typeof(DPObject))
                {
                    DPObject dpo = (DPObject)Activator.CreateInstance(type);
                    dict.Add(dpo.TableName, type);
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
            Assembly[] assemblies = Library.GetRegisteredAssemblies();
            foreach (Assembly assembly in assemblies)
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

        /// <summary>
        /// Save Enum into Dictionary in database from C# Enum Types
        /// </summary>
        public static void GenerateEnumDictionary()
        {
            IEnumerable<Type> enumList = GetEnumTypeList();

            foreach (Type type in enumList)
            {
                EnumType enumType = new EnumType(type);
                enumType.Save();
            }
        }


        public static Assembly GetRegisteredAssembly(string moduleName)
        {
            if (Library.Instance.assemblies.ContainsKey(moduleName))
                return Library.Instance.assemblies[moduleName];
            else
                return null;
        }
     

        public static string[] RegisteredAssemblyNames
        {
            get
            {
                return Library.Instance.assemblies.Keys.ToArray();
            }
        }

        public static Assembly[] GetRegisteredAssemblies()
        {
            return Library.Instance.assemblies.Values.ToArray();
        }
    
    }
}
