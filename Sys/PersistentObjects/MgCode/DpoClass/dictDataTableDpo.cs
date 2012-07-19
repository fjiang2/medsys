//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:04 PM
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
    [Revision(10)]
    [Table("sys00202", Level.System, Pack = false)]    //Primary Keys = database_id + name;  Identity = table_id;
    internal class dictDataTableDpo : DPObject
    {

#pragma warning disable

        [Column(_table_id, SqlDbType.Int, Identity = true)]                                       public int table_id;          //int(4) not null
        [Column(_database_id, SqlDbType.Int, Primary = true)]                                     public int database_id;       //int(4) not null
        [Column(_name, SqlDbType.VarChar, Primary = true, Length = 50)]                           public string name;           //varchar(50) not null
        [Column(_label, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string label;          //nvarchar(50) null
        [Column(_description, SqlDbType.NVarChar, Nullable = true, Length = 50)]                  public string description;    //nvarchar(50) null
        [Column(_enabled, SqlDbType.Bit)]                                                         public bool enabled;          //bit(1) not null
        [Column(_version, SqlDbType.Int)]                                                         public int version;           //int(4) not null

#pragma warning restore

        public dictDataTableDpo()
        {
        }

        public dictDataTableDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public dictDataTableDpo(int database_id, string name)
        {
           this.database_id = database_id; this.name = name; 

           this.Load();
           if(!this.Exists)
           {
              this.database_id = database_id; this.name = name;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.table_id;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _database_id, _name });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _table_id });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new dictDataTableDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _table_id = "table_id";
        public const string _database_id = "database_id";
        public const string _name = "name";
        public const string _label = "label";
        public const string _description = "description";
        public const string _enabled = "enabled";
        public const string _version = "version";

       
        #endregion 



    }
}

