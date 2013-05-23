//
// Machine Generated Code
//   by devel at 5/16/2013
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.PersistentObjects.DpoClass
{
    [Revision(13)]
    [Table("sys00302", Level.System, Pack = false)]    //Primary Keys = log_table_id;  Identity = log_table_id;
    public class logDataTableDpo : DPObject
    {

#pragma warning disable

        [Column(_log_table_id, SqlDbType.Int, Identity = true, Primary = true)]                   public int log_table_id {get; set;} //int(4) not null
        [Column(_log_dataset_id, SqlDbType.Int)]                                                  public int log_dataset_id {get; set;} //int(4) not null
        [Column(_table_id, SqlDbType.Int)]                                                        public int table_id {get; set;} //int(4) not null
        [Column(_table_name, SqlDbType.VarChar, Nullable = true, Length = 50)]                    public string table_name {get; set;} //varchar(50) null
        [Column(_row_id, SqlDbType.Int)]                                                          public int row_id {get; set;} //int(4) not null
        [Column(_operation, SqlDbType.Int)]                                                       public int operation {get; set;} //int(4) not null
        [Column(_action, SqlDbType.VarChar, Nullable = true, Length = 10)]                        public string action {get; set;} //varchar(10) null
        [Column(_value_from, SqlDbType.NText, Nullable = true)]                                   public string value_from {get; set;} //ntext(16) null
        [Column(_value_to, SqlDbType.NText, Nullable = true)]                                     public string value_to {get; set;} //ntext(16) null

#pragma warning restore

        public logDataTableDpo()
        {
        }

        public logDataTableDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public logDataTableDpo(int log_table_id)
        {
           this.log_table_id = log_table_id; 

           this.Load();
           if(!this.Exists)
           {
              this.log_table_id = log_table_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.log_table_id;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _log_table_id });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _log_table_id });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new logDataTableDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _log_table_id = "log_table_id";
        public const string _log_dataset_id = "log_dataset_id";
        public const string _table_id = "table_id";
        public const string _table_name = "table_name";
        public const string _row_id = "row_id";
        public const string _operation = "operation";
        public const string _action = "action";
        public const string _value_from = "value_from";
        public const string _value_to = "value_to";

       
        #endregion 



    }
}

