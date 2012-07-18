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
        /// <param name="tableNames"></param>
        /// <param name="path"></param>
        /// <param name="nameSpace"></param>
        /// <param name="level"></param>
        /// <param name="isPack"></param>
        public static void CreateClass(string[] tableNames, string path, string nameSpace, Level level, bool isPack)
        {
            foreach (string fullName in tableNames)
            {
                TableName tableName = new TableName(fullName);
                ClassTableName tname = new ClassTableName(tableName.DatabaseName, tableName.Name);

                ClassName cname = new ClassName(nameSpace, AccessModifier.Public, tname);
                tname.SetLevel(level, isPack);
                tname.GenTableDpo(path, true, cname, true);
            }
        }

        /// <summary>
        /// Upgrade DPO classes from SQL SERVER
        /// </summary>
        /// <param name="path"></param>
        public void UpgradeClass(string path)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType != typeof(DPObject))
                    continue;
                {

                    DPObject dpo = (DPObject)Activator.CreateInstance(type);
                    ClassTableName tname = new ClassTableName(dpo.TableName.DatabaseName, dpo.TableName.Name);

                    ClassName cname = new ClassName(dpo);
                    tname.SetLevel(dpo.Level, dpo.IsPack);
                    tname.GenTableDpo(path, true, cname, true);
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

        /// <summary>
        /// Crearte DPO classes for all tables in a database
        /// </summary>
        /// <param name="path"></param>
        /// <param name="mustGenerate"></param>
        /// <param name="databaseName"></param>
        /// <param name="nameSpace"></param>
        /// <param name="hasColumnAttribute"></param>
        /// <param name="modifier"></param>
        /// <param name="subNameSpace"></param>
        /// <returns></returns>
        public static int CreateClass(string path, bool mustGenerate, string databaseName, string nameSpace, bool hasColumnAttribute, AccessModifier modifier, bool subNameSpace)
        {

            string[] tableNames = MetaDatabase.GetTableNames(databaseName);
            if (tableNames.Length == 0)
                return 0;


            int count = 0;
            foreach (string tableName in tableNames)
            {
                if (tableName.StartsWith(Sys.Const.DB_SYSTEM_TABLE_PREFIX)) //================SKIP system tables
                    continue;

                ClassTableName tname = new ClassTableName(databaseName, tableName);
                ClassName cname = new ClassName(nameSpace, modifier, tname, subNameSpace);
                DpoGenerator gen = new DpoGenerator(tname, cname, hasColumnAttribute);

                string p = path;
                if (subNameSpace)  //create folder for each database
                    p = path + "\\" + tname.SubNamespace;


                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }

                if (gen.WriteFile(string.Format("{0}\\{1}.cs", p, cname.Class), mustGenerate))
                    count++;
            }

            return count;
        }

    }
}
