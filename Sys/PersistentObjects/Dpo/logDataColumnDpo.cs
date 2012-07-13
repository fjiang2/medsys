//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:05 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.PersistentObjects.Dpo
{
    [Revision(11)]
    [Table("sys00303", Level.System, Pack = false)]    //Primary Keys = log_column_id;  Identity = log_column_id;
    internal class logDataColumnDpo : DPObject
    {

#pragma warning disable

        [Column(_log_column_id, SqlDbType.Int, Identity = true, Primary = true)]                  public int log_column_id;     //int(4) not null
        [Column(_log_table_id, SqlDbType.Int)]                                                    public int log_table_id;      //int(4) not null
        [Column(_table_name, SqlDbType.VarChar, Nullable = true, Length = 80)]                    public string table_name;     //varchar(80) null
        [Column(_column_name, SqlDbType.VarChar, Nullable = true, Length = 50)]                   public string column_name;    //varchar(50) null
        [Column(_column_id, SqlDbType.Int)]                                                       public int column_id;         //int(4) not null
        [Column(_data_type, SqlDbType.VarChar, Length = 50)]                                      public string data_type;      //varchar(50) not null
        [Column(_value_from, SqlDbType.NText)]                                                    public string value_from;     //ntext(16) not null
        [Column(_value_to, SqlDbType.NText)]                                                      public string value_to;       //ntext(16) not null

#pragma warning restore

        public logDataColumnDpo()
        {
        }

        public logDataColumnDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public logDataColumnDpo(int log_column_id)
        {
           this.log_column_id = log_column_id; 

           this.Load();
           if(!this.Exists)
           {
              this.log_column_id = log_column_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.log_column_id;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _log_column_id });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _log_column_id });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new logDataColumnDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _log_column_id = "log_column_id";
        public const string _log_table_id = "log_table_id";
        public const string _table_name = "table_name";
        public const string _column_name = "column_name";
        public const string _column_id = "column_id";
        public const string _data_type = "data_type";
        public const string _value_from = "value_from";
        public const string _value_to = "value_to";

       
        #endregion 



    }
}

