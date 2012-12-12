using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Sys.Data;

namespace Sys.Data.Manager
{
    public class Manager
    {
        Assembly assembly;

        public Manager(Assembly assembly)
        {
            this.assembly = assembly;
        }


        /// <summary>
        /// Create DPO classes from SQL SERVER
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="tableNames"></param>
        /// <param name="path"></param>
        /// <param name="nameSpace"></param>
        /// <param name="level"></param>
        /// <param name="isPack"></param>
        /// <param name="hasProvider"></param>
        /// <param name="dict"></param>
        public static void CreateClass(DataProvider provider, string[] tableNames, string path, string nameSpace, 
            Level level, bool isPack, bool hasProvider,
            Dictionary<TableName, Type> dict)
        {
            foreach (string fullName in tableNames)
            {
                TableName tableName = new TableName(provider, fullName);
                ClassTableName ctname = new ClassTableName(provider, tableName.DatabaseName.Name, tableName.Name);

                ClassName cname = new ClassName(nameSpace, AccessModifier.Public, ctname);
                ctname.SetProperties(level, isPack, hasProvider);
                ctname.GenTableDpo(path, true, cname, true, dict);
            }
        }

   

        /// <summary>
        /// Upgrade DPO classes from SQL SERVER
        /// </summary>
        /// <param name="path"></param>
        public void UpgradeClass(string path, Dictionary<TableName, Type> dict)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType != typeof(DPObject))
                    continue;
                {

                    DPObject dpo = (DPObject)Activator.CreateInstance(type);
                    ClassTableName ctname = new ClassTableName(dpo.TableName.Provider, dpo.TableName.DatabaseName.Name, dpo.TableName.Name);

                    ClassName cname = new ClassName(dpo);
                    ctname.SetProperties(dpo.Level, dpo.IsPack, dpo.HasProvider);
                    ctname.GenTableDpo(path, true, cname, true, dict);
                }
            }
        }

        /// <summary>
        /// Upgrade DPO packages from SQL SERVER
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public MessageBuilder UpgradePackage(string path)
        {
            MessageBuilder messages = new MessageBuilder();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType != typeof(DPObject))
                    continue;

                TableAttribute[] A = type.GetAttributes<TableAttribute>();
                if (A.Length == 0 || !A[0].Pack)
                    continue;


                Packing packing = new Packing(type);
                packing.Pack();

                if (!packing)
                {
                    messages.Add(Message.Information(string.Format("Table {0} is empty.", packing.TableName)));
                }
                else
                {
                    string fileName = string.Format("{0}\\{1}.cs", path, packing.ClassName);
                    StreamWriter sw = new StreamWriter(fileName);
                    sw.Write(packing.ToString());
                    sw.Close();

                     messages.Add(Message.Information(string.Format("Table {0} packed into {1}.", packing.TableName, fileName)));
                }
            }


            return messages;
        }


        /// <summary>
        /// Create Tables in SQL Server from DPO classes
        /// </summary>
        /// <returns></returns>
        public MessageBuilder CreateTables()
        {
            return Unpacking.CreateTable(assembly);
        }

        /// <summary>
        /// Upgrade records in SQL SERVER from DPO packages
        /// </summary>
        /// <returns></returns>
        public void UpgradeRecords()
        {
            Unpacking.Unpack(assembly, false);
        }

        /// <summary>
        /// Insert new records into SQL Server from DPO package
        /// </summary>
        public void InsertRecords()
        {
            Unpacking.Unpack(assembly, true);
        }

       

    }
}
