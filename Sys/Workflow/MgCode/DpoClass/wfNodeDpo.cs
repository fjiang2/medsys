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


namespace Sys.Workflow.DpoClass
{
    [Revision(14)]
    [Table("sys01306", Level.System, Pack = false)]    //Primary Keys = ChildID + ParentID + Ty;  Identity = ID;
    public class wfNodeDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Ty, SqlDbType.Int, Primary = true)]                                              public int Ty {get; set;}     //int(4) not null
        [Column(_ParentID, SqlDbType.Int, Primary = true)]                                        public int ParentID {get; set;} //int(4) not null
        [Column(_ChildID, SqlDbType.Int, Primary = true)]                                         public int ChildID {get; set;} //int(4) not null

#pragma warning restore

        public wfNodeDpo()
        {
        }

        public wfNodeDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public wfNodeDpo(int childid, int parentid, int ty)
        {
           this.ChildID = childid; this.ParentID = parentid; this.Ty = ty; 

           this.Load();
           if(!this.Exists)
           {
              this.ChildID = childid; this.ParentID = parentid; this.Ty = ty;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.ID;
            }
        }



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ChildID, _ParentID, _Ty });
            }
        }



        public override IdentityKeys Identity
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
              return new wfNodeDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Ty = "Ty";
        public const string _ParentID = "ParentID";
        public const string _ChildID = "ChildID";

       
        #endregion 



    }
}

