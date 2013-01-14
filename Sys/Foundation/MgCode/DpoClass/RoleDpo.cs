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
    [Table("sys00102", Level.System)]    //Primary Keys = Role_ID;  Identity = ;
    public class RoleDpo : DPObject
    {

#pragma warning disable

        [Column(_Role_ID, SqlDbType.Int, Primary = true)]                                         public int Role_ID;           //int(4) not null
        [Column(_Role_Name, SqlDbType.NVarChar, Length = 256)]                                    public string Role_Name;      //nvarchar(256) not null
        [Column(_Parent_Role_ID, SqlDbType.Int, Nullable = true)]                                 public int? Parent_Role_ID;   //int(4) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 1024)]                public string Description;    //nvarchar(1024) null

#pragma warning restore

        public RoleDpo()
        {
        }

        public RoleDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public RoleDpo(int role_id)
        {
           this.Role_ID = role_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Role_ID = role_id;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.Role_ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Role_ID });
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
              return new RoleDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Role_ID = "Role_ID";
        public const string _Role_Name = "Role_Name";
        public const string _Parent_Role_ID = "Parent_Role_ID";
        public const string _Description = "Description";

       
        #endregion 



    }
}

