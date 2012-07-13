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
using Sys.Data.Manager;


namespace Sys.DataManager.Dpo
{
    [Revision(9)]
    [Table("sys01401", Level.System)]    //Primary Keys = File_Name + Row_Id + Table_Id;  Identity = ID;
    public class sysDOC01Dpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID;                //int(4) not null
        [Column(_ParentID, SqlDbType.Int, Nullable = true)]                                       public int? ParentID;         //int(4) null
        [Column(_Table_Id, SqlDbType.Int, Primary = true)]                                        public int Table_Id;          //int(4) not null
        [Column(_Table_Name, SqlDbType.VarChar, Nullable = true, Length = 50)]                    public string Table_Name;     //varchar(50) null
        [Column(_Row_Id, SqlDbType.Int, Primary = true)]                                          public int Row_Id;            //int(4) not null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 128)]                       public string Label;          //nvarchar(128) null
        [Column(_File_Name, SqlDbType.VarChar, Primary = true, Length = 100)]                     public string File_Name;      //varchar(100) not null
        [Column(_File_Type, SqlDbType.VarChar, Nullable = true, Length = 50)]                     public string File_Type;      //varchar(50) null
        [Column(_Owner, SqlDbType.Int, Nullable = true)]                                          public int? Owner;            //int(4) null

#pragma warning restore

        public sysDOC01Dpo()
        {
        }

        public sysDOC01Dpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public sysDOC01Dpo(string file_name, int row_id, int table_id)
        {
           this.File_Name = file_name; this.Row_Id = row_id; this.Table_Id = table_id; 

           this.Load();
           if(!this.Exists)
           {
              this.File_Name = file_name; this.Row_Id = row_id; this.Table_Id = table_id;     
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
                return new PrimaryKeys(new string[]{ _File_Name, _Row_Id, _Table_Id });
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
              return new sysDOC01Dpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ParentID = "ParentID";
        public const string _Table_Id = "Table_Id";
        public const string _Table_Name = "Table_Name";
        public const string _Row_Id = "Row_Id";
        public const string _Label = "Label";
        public const string _File_Name = "File_Name";
        public const string _File_Type = "File_Type";
        public const string _Owner = "Owner";

       
        #endregion 



    }
}

