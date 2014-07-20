﻿//--------------------------------------------------------------------------------------------------//
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

namespace Sys.Data
{
    public class TableName : IComparable<TableName>, IComparable
    {
        protected DatabaseName baseName;
        protected string tableName;

        public TableName(DataProvider provider, string fullTableName)
        {
            //tableName may have format like [db.dbo.tableName], [db..tableName], or [tableName]
            string[] t = fullTableName.Split(new char[] { '.' });

            string databaseName = "";
            this.tableName = "";
            if (t.Length > 1)
            {
                databaseName = t[0];
                this.tableName = t[2];
            }
            else
                this.tableName = fullTableName;

            databaseName = databaseName.Replace("[", "").Replace("]", "");
            this.tableName = this.tableName.Replace("[", "").Replace("]", "");

            if (databaseName == "")
                databaseName = MetaDatabase.CurrentDatabaseName(provider);

            this.baseName = new DatabaseName(provider, databaseName);
        }

      

        public TableName(DatabaseName databaseName, string tableName)
        {
            this.baseName = databaseName;
            this.tableName = tableName;
        }

        public TableName(DataProvider provider, string databaseName, string tableName)
        {
            this.baseName = new DatabaseName(provider, databaseName);
            this.tableName = tableName;
        }

        public int CompareTo(object obj)
        {
            return CompareTo((TableName)obj);
        }

        public int CompareTo(TableName n)
        {
            if (this.baseName.CompareTo(n.baseName) == 0)
                return this.tableName.CompareTo(n.tableName);

            return this.baseName.CompareTo(n.baseName);
        }

        public override bool Equals(object obj)
        {
            TableName name = (TableName)obj;
            return FullName.Equals(name.FullName) && this.baseName.Equals(name.baseName);
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode()*100 + this.baseName.GetHashCode();
        }
    
        public string Name
        {
            get { return this.tableName; }
        }


        public DatabaseName DatabaseName
        {
            get { return this.baseName; }
        }

        public string FullName
        {
            get 
            {
                if (this.baseName.Name != "")
                {
                    //Visual Studio 2010 Windows Form Design Mode, does not support format [database]..[table]
                    if(baseName.Provider.DpType != DbProviderType.SqlCe)
                        return string.Format("{0}..[{1}]", this.baseName.Name, this.tableName);
                    else
                        return string.Format("[{0}]", this.tableName);
                }
                else
                    return this.tableName;
            }
        }

            
        public override string ToString()
        {
            return FullName;
        }


        
        public int Id
        {
            get
            {
                return this.GetCachedMetaTable().TableID;
            }
        }



        public int ColumnId(string columnName)
        {
            if (Id == -1)
                return -1;

            return this.GetCachedMetaTable().ColumnId(columnName);
        }


      



        public DataProvider Provider
        {
            get { return this.baseName.Provider; }
        }
    }
}