using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;
using System.Reflection;

namespace Sys.Data.Manager
{
    class DictTable 
    {

      

        public static int Register(PersistentObject obj)
        {
            return MustRegister(obj.TableName);
        }


    


        public static int GetId(TableName tname)
        {

            int database_id = DictDatabase.GetId(tname.DatabaseName);
            if (database_id == -1)
                return -1;

            dictDataTableDpo dpo = new dictDataTableDpo();
            dpo.database_id = database_id;
            dpo.name = tname.Name;
            dpo.Load();

            if (dpo.Exists)
                return dpo.table_id;
            else
                return -1;
        }




        public static int RegisterOnly(int database_id, string tableName)
        {
            dictDataTableDpo dpo = new dictDataTableDpo();
            dpo.CreateTable();
            
            dpo.database_id = database_id;
            dpo.name = tableName;
            dpo.version = Const.Revision;
            dpo.Save();

            return dpo.table_id;
        }


        public static int Register(int database_id, TableName tname)
        {
            int table_id = RegisterOnly(database_id, tname.Name);

            DataTable dataTable = tname.GetMetaTable().EmptyDataTable;

            //Create Table if not exist
            dictDataColumnDpo dpo = new dictDataColumnDpo();
            dpo.CreateTable();
            
            foreach (DataColumn dataColumn in dataTable.Columns)
                DictColumn.RegisterOnly(table_id, dataColumn.ColumnName);

            return table_id;
        }



        internal static int MustRegister(TableName tname)
        {
            int database_id = DictDatabase.GetId(tname.DatabaseName);
            if (database_id == -1)
                database_id = DictDatabase.RegisterOnly(tname.DatabaseName);

            return Register(database_id, tname);
        }

     
    }
}
