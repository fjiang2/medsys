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
    [Table("sys00502", Level.System)]    //Primary Keys = ID + Role_ID + Ty;  Identity = ;
    public class ItemPermissionDpo : DPObject
    {

#pragma warning disable

        [Column(_Role_ID, SqlDbType.Int, Primary = true)]                                         public int Role_ID {get; set;} //int(4) not null
        [Column(_Ty, SqlDbType.Int, Primary = true)]                                              public int Ty {get; set;}     //int(4) not null
        [Column(_ID, SqlDbType.Int, Primary = true)]                                              public int ID {get; set;}     //int(4) not null
        [Column(_Enabled, SqlDbType.Bit, Nullable = true)]                                        public bool? Enabled {get; set;} //bit(1) null
        [Column(_Visible, SqlDbType.Bit, Nullable = true)]                                        public bool? Visible {get; set;} //bit(1) null

#pragma warning restore

        public ItemPermissionDpo()
        {
        }

        public ItemPermissionDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ItemPermissionDpo(int id, int role_id, int ty)
        {
           this.ID = id; this.Role_ID = role_id; this.Ty = ty; 

           this.Load();
           if(!this.Exists)
           {
              this.ID = id; this.Role_ID = role_id; this.Ty = ty;     
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
        


        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ID, _Role_ID, _Ty });
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
              return new ItemPermissionDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _Role_ID = "Role_ID";
        public const string _Ty = "Ty";
        public const string _ID = "ID";
        public const string _Enabled = "Enabled";
        public const string _Visible = "Visible";

       
        #endregion 



    }
}

