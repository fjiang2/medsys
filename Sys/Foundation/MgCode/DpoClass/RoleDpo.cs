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
    [Revision(14)]
    [Table("sys00102", Level.System)]    //Primary Keys = Role_ID;  Identity = ;
    public class RoleDpo : DPObject
    {

#pragma warning disable

        [Column(_Role_ID, CType.Int, Primary = true)]                                         public int Role_ID {get; set;} //int(4) not null
        [Column(_Role_Name, CType.NVarChar, Length = 256)]                                    public string Role_Name {get; set;} //nvarchar(256) not null
        [Column(_Parent_Role_ID, CType.Int, Nullable = true)]                                 public int? Parent_Role_ID {get; set;} //int(4) null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 1024)]                public string Description {get; set;} //nvarchar(1024) null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _Role_ID });
            }
        }



        public override IIdentityKeys Identity
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

