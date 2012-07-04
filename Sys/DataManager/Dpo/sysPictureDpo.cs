//
// Machine Generated Code
//   by devel at 4/19/2012 5:59:15 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.DataManager;


namespace Sys.DataManager.Dpo
{
    [Revision(9)]
    [Table("sys01403", Level.System)]    //Primary Keys = ID;  Identity = ID;
    public class sysPictureDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID;                //int(4) not null
        [Column(_Table_Id, SqlDbType.Int)]                                                        public int Table_Id;          //int(4) not null
        [Column(_Table_Name, SqlDbType.VarChar, Nullable = true, Length = 50)]                    public string Table_Name;     //varchar(50) null
        [Column(_Row_Id, SqlDbType.Int)]                                                          public int Row_Id;            //int(4) not null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 128)]                       public string Label;          //nvarchar(128) null
        [Column(_File_Name, SqlDbType.VarChar, Length = 50)]                                      public string File_Name;      //varchar(50) not null
        [Column(_Date_Created, SqlDbType.DateTime)]                                               public DateTime Date_Created; //datetime(8) not null
        [Column(_Owner, SqlDbType.Int, Nullable = true)]                                          public int? Owner;            //int(4) null

#pragma warning restore

        public sysPictureDpo()
        {
        }

        public sysPictureDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public sysPictureDpo(int id)
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
              return new sysPictureDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Table_Id = "Table_Id";
        public const string _Table_Name = "Table_Name";
        public const string _Row_Id = "Row_Id";
        public const string _Label = "Label";
        public const string _File_Name = "File_Name";
        public const string _Date_Created = "Date_Created";
        public const string _Owner = "Owner";

       
        #endregion 



    }
}

