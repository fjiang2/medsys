//
// Machine Generated Code
//   by devel at 7/19/2012 12:12:49 AM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.DataManager.DpoClass
{
    [Revision(10)]
    [Table("sys01402", Level.System)]    //Primary Keys = Doc_Id + Version;  Identity = ID;
    public class sysDOC02Dpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_Doc_Id, SqlDbType.Int, Primary = true)]                                          public int Doc_Id;            //int(4) not null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 120)]                       public string Label;          //nvarchar(120) null
        [Column(_Version, SqlDbType.Int, Primary = true)]                                         public int Version;           //int(4) not null
        [Column(_Doc_Name, SqlDbType.VarChar, Length = 50)]                                       public string Doc_Name;       //varchar(50) not null
        [Column(_User_Id, SqlDbType.Int)]                                                         public int User_Id;           //int(4) not null
        [Column(_Date_Modified, SqlDbType.DateTime)]                                              public DateTime Date_Modified;//datetime(8) not null
        [Column(_Comment, SqlDbType.NVarChar, Nullable = true, Length = 256)]                     public string Comment;        //nvarchar(256) null

#pragma warning restore

        public sysDOC02Dpo()
        {
        }

        public sysDOC02Dpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public sysDOC02Dpo(int doc_id, int version)
        {
           this.Doc_Id = doc_id; this.Version = version; 

           this.Load();
           if(!this.Exists)
           {
              this.Doc_Id = doc_id; this.Version = version;     
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
                return new PrimaryKeys(new string[]{ _Doc_Id, _Version });
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
              return new sysDOC02Dpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Doc_Id = "Doc_Id";
        public const string _Label = "Label";
        public const string _Version = "Version";
        public const string _Doc_Name = "Doc_Name";
        public const string _User_Id = "User_Id";
        public const string _Date_Modified = "Date_Modified";
        public const string _Comment = "Comment";

       
        #endregion 



    }
}

