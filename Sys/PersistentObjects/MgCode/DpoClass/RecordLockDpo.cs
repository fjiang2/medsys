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
    [Revision(13)]
    [Table("sys00601", Level.System, Pack = false)]    //Primary Keys = ID;  Identity = ID;
    public class RecordLockDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_Ty, SqlDbType.Int)]                                                              public int Ty {get; set;}     //int(4) not null
        [Column(_LockID, SqlDbType.Int)]                                                          public int LockID {get; set;} //int(4) not null
        [Column(_CO_User_ID, SqlDbType.Int)]                                                      public int CO_User_ID {get; set;} //int(4) not null
        [Column(_CO_Time, SqlDbType.DateTime)]                                                    public DateTime CO_Time {get; set;} //datetime(8) not null
        [Column(_CI_User_ID, SqlDbType.Int, Nullable = true)]                                     public int? CI_User_ID {get; set;} //int(4) null
        [Column(_CI_Time, SqlDbType.DateTime, Nullable = true)]                                   public DateTime? CI_Time {get; set;} //datetime(8) null
        [Column(_Last_Access_Time, SqlDbType.DateTime)]                                           public DateTime Last_Access_Time {get; set;} //datetime(8) not null

#pragma warning restore

        public RecordLockDpo()
        {
        }

        public RecordLockDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public RecordLockDpo(int id)
        {
           this.ID = id; 

           this.Load();
           if(!this.Exists)
           {
              this.ID = id;     
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
                return new PrimaryKeys(new string[]{ _ID });
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
              return new RecordLockDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Ty = "Ty";
        public const string _LockID = "LockID";
        public const string _CO_User_ID = "CO_User_ID";
        public const string _CO_Time = "CO_Time";
        public const string _CI_User_ID = "CI_User_ID";
        public const string _CI_Time = "CI_Time";
        public const string _Last_Access_Time = "Last_Access_Time";

       
        #endregion 



    }
}

