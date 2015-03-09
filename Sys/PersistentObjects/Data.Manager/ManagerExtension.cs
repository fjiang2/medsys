//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using System.Threading;
using System.ComponentModel;
using Sys.PersistentObjects.DpoClass;
using System.IO;
using System.Reflection;
using Sys.Data.Log;

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

            string[] names = databaseName.GetTableNames();

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
            bool result = GenTableDpo(tname, tname.GetMetaTable(), path, mustGenerate, cname, true, hasColumnAttribute, dict);
            LogDpoClass.Log(tname, path, cname);

            return result;
        }

        public static bool GenTableDpo(this DataTable table,  string path, ClassName cname)
        {

            ITable metatable = new DataTableDpoClass(table);
            ClassTableName tname = new ClassTableName(metatable.TableName);
            return GenTableDpo(tname, metatable, path, true, cname, false, false, new Dictionary<TableName, Type>());
        }


        private static bool GenTableDpo(this ClassTableName tname, ITable metatable, string path, bool mustGenerate, ClassName cname, bool hasTableAttribute, bool hasColumnAttribute, Dictionary<TableName, Type> dict)
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


            DpoGenerator gen = new DpoGenerator(tname, metatable, cname, hasTableAttribute, hasColumnAttribute, dict);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            bool result =  gen.WriteFile(string.Format("{0}\\{1}.cs", path, cname.Class), mustGenerate);

           
            return result;
        }

    



        #endregion

        public static ColumnCollection MetaColumns(this TableName tableName)
        {
            ITable meta = tableName.GetCachedMetaTable();
            return meta.Columns;
        }

     

    }
}
