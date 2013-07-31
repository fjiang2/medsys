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


namespace Sys.Foundation.DpoClass
{
    [Revision(13)]
    [Table("sys00501", Level.System)]    //Primary Keys = key_name;  Identity = ID;
    public class ConfigurationDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_ParentID, SqlDbType.Int, Nullable = true)]                                       public int? ParentID {get; set;} //int(4) null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string Label {get; set;} //nvarchar(50) null
        [Column(_OrderBy, SqlDbType.Int, Nullable = true)]                                        public int? OrderBy {get; set;} //int(4) null
        [Column(_key_name, SqlDbType.NVarChar, Primary = true, Length = 50)]                      public string key_name {get; set;} //nvarchar(50) not null
        [Column(_value, SqlDbType.NVarChar, Nullable = true, Length = 512)]                       public string value {get; set;} //nvarchar(512) null
        [Column(_Inactive, SqlDbType.Bit)]                                                        public bool Inactive {get; set;} //bit(1) not null

#pragma warning restore

        public ConfigurationDpo()
        {
        }

        public ConfigurationDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ConfigurationDpo(string key_name)
        {
           this.key_name = key_name; 

           this.Load();
           if(!this.Exists)
           {
              this.key_name = key_name;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.ID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _key_name });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new ConfigurationDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ParentID = "ParentID";
        public const string _Label = "Label";
        public const string _OrderBy = "OrderBy";
        public const string _key_name = "key_name";
        public const string _value = "value";
        public const string _Inactive = "Inactive";

       
        #endregion 



    }
}

