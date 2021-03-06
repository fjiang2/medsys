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


namespace Sys.DataManager.DpoClass
{
    [Revision(12)]
    [Table("sys01401", Level.System)]    //Primary Keys = File_Name + Row_Id + Table_Id;  Identity = ID;
    public class sysDOC01Dpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_ParentID, CType.Int, Nullable = true)]                                       public int? ParentID {get; set;} //int(4) null
        [Column(_Table_Id, CType.Int, Primary = true)]                                        public int Table_Id {get; set;} //int(4) not null
        [Column(_Table_Name, CType.VarChar, Nullable = true, Length = 50)]                    public string Table_Name {get; set;} //varchar(50) null
        [Column(_Row_Id, CType.Int, Primary = true)]                                          public int Row_Id {get; set;} //int(4) not null
        [Column(_Label, CType.NVarChar, Nullable = true, Length = 128)]                       public string Label {get; set;} //nvarchar(128) null
        [Column(_File_Name, CType.VarChar, Primary = true, Length = 100)]                     public string File_Name {get; set;} //varchar(100) not null
        [Column(_File_Type, CType.VarChar, Nullable = true, Length = 50)]                     public string File_Type {get; set;} //varchar(50) null
        [Column(_Owner, CType.Int, Nullable = true)]                                          public int? Owner {get; set;} //int(4) null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _File_Name, _Row_Id, _Table_Id });
            }
        }



        public override IIdentityKeys Identity
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

