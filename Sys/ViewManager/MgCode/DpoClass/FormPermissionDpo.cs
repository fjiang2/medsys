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


namespace Sys.ViewManager.DpoClass
{
    [Revision(13)]
    [Table("sys00503", Level.System)]    //Primary Keys = Key_Name + Role_ID;  Identity = ;
    public class FormPermissionDpo : DPObject
    {

#pragma warning disable

        [Column(_Role_ID, SqlDbType.Int, Primary = true)]                                         public int Role_ID {get; set;} //int(4) not null
        [Column(_Ty, SqlDbType.Int, Nullable = true)]                                             public int? Ty {get; set;}    //int(4) null
        [Column(_Key_Name, SqlDbType.NVarChar, Primary = true, Length = 128)]                     public string Key_Name {get; set;} //nvarchar(128) not null
        [Column(_Value, SqlDbType.NText, Nullable = true)]                                        public string Value {get; set;} //ntext(16) null

#pragma warning restore

        public FormPermissionDpo()
        {
        }

        public FormPermissionDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public FormPermissionDpo(string key_name, int role_id)
        {
           this.Key_Name = key_name; this.Role_ID = role_id; 

           this.Load();
           if(!this.Exists)
           {
              this.Key_Name = key_name; this.Role_ID = role_id;     
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
                return new PrimaryKeys(new string[]{ _Key_Name, _Role_ID });
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
              return new FormPermissionDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Role_ID = "Role_ID";
        public const string _Ty = "Ty";
        public const string _Key_Name = "Key_Name";
        public const string _Value = "Value";

       
        #endregion 



    }
}

