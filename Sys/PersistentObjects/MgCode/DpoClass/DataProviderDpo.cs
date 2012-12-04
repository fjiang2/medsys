//
// Machine Generated Code
//   by devel at 11/14/2012
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
    [Revision(1)]
    [Table("sys00704", Level.System)]    //Primary Keys = handle;  Identity = ;
    public class DataProviderDpo : DPObject
    {

#pragma warning disable

        [Column(_handle, SqlDbType.Int, Primary = true)]                                          public int handle;            //int(4) not null
        [Column(_name, SqlDbType.NVarChar, Length = 50)]                                          public string name;           //nvarchar(50) not null
        [Column(_type, SqlDbType.Int)]                                                            public int type;              //int(4) not null
        [Column(_connection, SqlDbType.NVarChar, Length = 250)]                                   public string connection;     //nvarchar(250) not null
        [Column(_user_id, SqlDbType.NVarChar, Nullable = true, Length = 50)]                      public string user_id;        //nvarchar(50) null
        [Column(_password, SqlDbType.NVarChar, Nullable = true, Length = 50)]                     public string password;       //nvarchar(50) null
        [Column(_inactive, SqlDbType.Bit)]                                                        public bool inactive;         //bit(1) not null

#pragma warning restore

        public DataProviderDpo()
        {
        }

        public DataProviderDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public DataProviderDpo(int handle)
        {
           this.handle = handle; 

           this.Load();
           if(!this.Exists)
           {
              this.handle = handle;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.handle;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _handle });
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
              return new DataProviderDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _handle = "handle";
        public const string _name = "name";
        public const string _type = "type";
        public const string _connection = "connection";
        public const string _user_id = "user_id";
        public const string _password = "password";
        public const string _inactive = "inactive";

       
        #endregion 



    }
}
