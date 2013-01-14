//
// Machine Generated Code
//   by devel at 11/12/2012
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
    [Revision(15)]
    [Table("sys00201", Level.System, Pack = false)]    //Primary Keys = name + provider_id;  Identity = database_id;
    internal class dictDatabaseDpo : DPObject
    {

#pragma warning disable

        [Column(_database_id, SqlDbType.Int, Identity = true)]                                    public int database_id;       //int(4) not null
        [Column(_name, SqlDbType.VarChar, Primary = true, Length = 50)]                           public string name;           //varchar(50) not null
        [Column(_provider_id, SqlDbType.Int, Primary = true)]                                     public int provider_id;       //int(4) not null
        [Column(_label, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string label;          //nvarchar(50) null
        [Column(_description, SqlDbType.NVarChar, Nullable = true, Length = 128)]                 public string description;    //nvarchar(128) null
        [Column(_enabled, SqlDbType.Bit)]                                                         public bool enabled;          //bit(1) not null
        [Column(_version, SqlDbType.Int)]                                                         public int version;           //int(4) not null

#pragma warning restore

        public dictDatabaseDpo()
        {
        }

        public dictDatabaseDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public dictDatabaseDpo(string name, int provider_id)
        {
           this.name = name; this.provider_id = provider_id; 

           this.Load();
           if(!this.Exists)
           {
              this.name = name; this.provider_id = provider_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.database_id;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _name, _provider_id });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _database_id });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new dictDatabaseDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _database_id = "database_id";
        public const string _name = "name";
        public const string _provider_id = "provider_id";
        public const string _label = "label";
        public const string _description = "description";
        public const string _enabled = "enabled";
        public const string _version = "version";

       
        #endregion 



    }
}

