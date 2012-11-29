using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using System.Threading;
using System.ComponentModel;
using Sys.PersistentObjects.DpoClass;
using System.IO;
using System.Reflection;

namespace Sys.Data.Manager
{
    public static class ManagerExtension
    {

        #region Logger

        /// <summary>
        /// register user defined transaction logee
        /// </summary>
        /// <param name="transactionType"></param>
        /// <param name="logee"></param>
        public static void Register(this TransactionLogeeType transactionType, ITransactionLogee logee)
        {
            LogManager.Instance.Register(transactionType, logee);
        }

        /// <summary>
        /// register user defined record/row logee
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="logee"></param>
        public static void Register(this TableName tableName, IRowLogee logee)
        {
            LogManager.Instance.Register(tableName, logee);
        }


        #endregion




        #region Register Dictionary
        /// <summary>
        /// Register Table and its columns
        /// </summary>
        /// <param name="dpo"></param>
        /// <returns></returns>
        public static int RegisterEntireTable(this PersistentObject dpo)
        {
            return DictTable.Register(dpo);
        }


        /// <summary>
        /// Register Database, its Tables, and their Columns
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="thread"></param>
        /// <returns></returns>
        public static int RegisterEntireDatabase(this DatabaseName databaseName, BackgroundWorker thread)
        {
            int database_id = DictDatabase.RegisterOnly(databaseName);

            string[] names = MetaDatabase.GetTableNames(databaseName);

            int i = 0;
            foreach (string name in names)
            {
                thread.ReportProgress((int)(i * 100.0 / names.Length));
                i++;

                DictTable.Register(database_id, new TableName(databaseName, name));
            }

            return names.Length;

        }

      

        #endregion



        #region Dpo Generate


        public static bool GenTableDpo(this ClassTableName tname, string path, bool mustGenerate, ClassName cname, bool hasColumnAttribute, Dictionary<TableName, Type> dict)
        {
            //make description to sys tables
            if (tname.Level == Level.System)
            {
                dictDatabaseDpo db = new dictDatabaseDpo();
                db.name = tname.DatabaseName.Name;
                db.provider_id = (int)tname.Provider;
                db.Load();

                dictDataTableDpo dt = new dictDataTableDpo();
                dt.database_id = db.database_id;
                dt.name = tname.Name;
                dt.description = cname.Class;
                dt.Save();
            }

            DpoGenerator gen = new DpoGenerator(tname, cname, hasColumnAttribute, dict);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            bool result =  gen.WriteFile(string.Format("{0}\\{1}.cs", path, cname.Class), mustGenerate);

            //log class dpo 
            LogDpoClass.Log(tname, path, cname);
            return result;
        }

    



        #endregion


        public static string InsertCommand(this TableName tableName, string line, char[] separator)
        {
            MetaTable meta = MetaTable.GetCachedInstance(tableName);
            return meta.InsertCommand(line, separator);
        }

        /// <summary>
        /// Import text file into table in the SQL server
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="reader"></param>
        /// <param name="separator"></param>
        public static void ImportFromTextStream(this TableName tableName, TextReader reader, char[] separator)
        {
            SqlCmd cmd;
            string line;
            while (true)
            {
                line = reader.ReadLine();
                if (line == null)
                    break;

                string insertCommand = tableName.InsertCommand(line, separator);
                cmd = new SqlCmd(tableName.Provider, insertCommand);
                cmd.ExecuteNonQuery();
            }
        }   
    }
}
