//
// Machine Generated Code
//   by devel at 7/19/2012 12:12:39 AM
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
    [Revision(11)]
    [Table("sys00203", Level.System, Pack = false)]    //Primary Keys = name + table_id;  Identity = column_id;
    internal class dictDataColumnDpo : DPObject
    {

#pragma warning disable

        [Column(_column_id, SqlDbType.Int, Identity = true)]                                      public int column_id;         //int(4) not null
        [Column(_table_id, SqlDbType.Int, Primary = true)]                                        public int table_id;          //int(4) not null
        [Column(_name, SqlDbType.VarChar, Primary = true, Length = 50)]                           public string name;           //varchar(50) not null
        [Column(_label, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string label;          //nvarchar(50) null
        [Column(_description, SqlDbType.NVarChar, Nullable = true, Length = 128)]                 public string description;    //nvarchar(128) null
        [Column(_version, SqlDbType.Int)]                                                         public int version;           //int(4) not null

#pragma warning restore

        public dictDataColumnDpo()
        {
        }

        public dictDataColumnDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public dictDataColumnDpo(string name, int table_id)
        {
           this.name = name; this.table_id = table_id; 

           this.Load();
           if(!this.Exists)
           {
              this.name = name; this.table_id = table_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.column_id;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _name, _table_id });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _column_id });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new dictDataColumnDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _column_id = "column_id";
        public const string _table_id = "table_id";
        public const string _name = "name";
        public const string _label = "label";
        public const string _description = "description";
        public const string _version = "version";

       
        #endregion 



    }
}
