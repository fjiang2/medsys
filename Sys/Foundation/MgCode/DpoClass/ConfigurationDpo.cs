//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:06 PM
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
    [Revision(10)]
    [Table("sys00501", Level.System)]    //Primary Keys = key_name;  Identity = ;
    public class ConfigurationDpo : DPObject
    {

#pragma warning disable

        [Column(_key_name, SqlDbType.NVarChar, Primary = true, Length = 50)]                      public string key_name;       //nvarchar(50) not null
        [Column(_value, SqlDbType.NVarChar, Nullable = true, Length = 512)]                       public string value;          //nvarchar(512) null
        [Column(_Inactive, SqlDbType.Bit)]                                                        public bool Inactive;         //bit(1) not null

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
        


        //must override when logger is used
        protected override int DPObjectId
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        


        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _key_name });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
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

        public const string _key_name = "key_name";
        public const string _value = "value";
        public const string _Inactive = "Inactive";

       
        #endregion 



    }
}

