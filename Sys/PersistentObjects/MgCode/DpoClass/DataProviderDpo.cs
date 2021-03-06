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
    [Revision(3)]
    [Table("sys00704", Level.System)]    //Primary Keys = handle;  Identity = ;
    public class DataProviderDpo : DPObject
    {

#pragma warning disable

        [Column(_handle, CType.Int, Primary = true)]                                          public int handle {get; set;} //int(4) not null
        [Column(_name, CType.NVarChar, Length = 50)]                                          public string name {get; set;} //nvarchar(50) not null
        [Column(_type, CType.Int)]                                                            public int type {get; set;}   //int(4) not null
        [Column(_connection, CType.NVarChar, Length = 250)]                                   public string connection {get; set;} //nvarchar(250) not null
        [Column(_user_id, CType.NVarChar, Nullable = true, Length = 50)]                      public string user_id {get; set;} //nvarchar(50) null
        [Column(_password, CType.NVarChar, Nullable = true, Length = 50)]                     public string password {get; set;} //nvarchar(50) null
        [Column(_inactive, CType.Bit)]                                                        public bool inactive {get; set;} //bit(1) not null

#pragma warning restore

        public DataProviderDpo()
        {
        }

        public DataProviderDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public override void Collect(DataRow row)
        {
            SetValue(row, _handle, handle);
            SetValue(row, _name, name);
            SetValue(row, _type, type);
            SetValue(row, _connection, connection);
            SetValue(row, _user_id, user_id);
            SetValue(row, _password, password);
            SetValue(row, _inactive, inactive);
        }

        public override void Fill(DataRow row)
        {
            handle = GetValue<int>(row, _handle);
            name = GetValue<string>(row, _name);
            type = GetValue<int>(row, _type);
            connection = GetValue<string>(row, _connection);
            user_id = GetValue<string>(row, _user_id);
            password = GetValue<string>(row, _password);
            inactive = GetValue<bool>(row, _inactive);
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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _handle });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys();
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

