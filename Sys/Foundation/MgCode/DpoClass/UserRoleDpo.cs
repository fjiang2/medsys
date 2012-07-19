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


namespace Sys.Foundation.DpoClass
{
    [Revision(12)]
    [Table("sys00103", Level.System)]    //Primary Keys = Role_ID + User_ID;  Identity = UR_ID;
    public class UserRoleDpo : DPObject
    {

#pragma warning disable

        [Column(_UR_ID, SqlDbType.Int, Identity = true)]                                          public int UR_ID;             //int(4) not null
        [Column(_User_ID, SqlDbType.Int, Primary = true)]                                         public int User_ID;           //int(4) not null
        [Column(_Role_ID, SqlDbType.Int, Primary = true)]                                         public int Role_ID;           //int(4) not null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 128)]                 public string Description;    //nvarchar(128) null
        [Column(_Date_Activated, SqlDbType.DateTime, Nullable = true)]                            public DateTime? Date_Activated;//datetime(8) null
        [Column(_Date_Expired, SqlDbType.DateTime, Nullable = true)]                              public DateTime? Date_Expired;//datetime(8) null

#pragma warning restore

        public UserRoleDpo()
        {
        }

        public UserRoleDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public UserRoleDpo(int role_id, int user_id)
        {
           this.Role_ID = role_id; this.User_ID = user_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Role_ID = role_id; this.User_ID = user_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.UR_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Role_ID, _User_ID });
            }
        }



        public override IdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _UR_ID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new UserRoleDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _UR_ID = "UR_ID";
        public const string _User_ID = "User_ID";
        public const string _Role_ID = "Role_ID";
        public const string _Description = "Description";
        public const string _Date_Activated = "Date_Activated";
        public const string _Date_Expired = "Date_Expired";

       
        #endregion 



    }
}

