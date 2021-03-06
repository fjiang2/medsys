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
    [Table("sys01403", Level.System)]    //Primary Keys = ID;  Identity = ID;
    public class sysPictureDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_Table_Id, CType.Int)]                                                        public int Table_Id {get; set;} //int(4) not null
        [Column(_Table_Name, CType.VarChar, Nullable = true, Length = 50)]                    public string Table_Name {get; set;} //varchar(50) null
        [Column(_Row_Id, CType.Int)]                                                          public int Row_Id {get; set;} //int(4) not null
        [Column(_Label, CType.NVarChar, Nullable = true, Length = 128)]                       public string Label {get; set;} //nvarchar(128) null
        [Column(_File_Name, CType.VarChar, Length = 50)]                                      public string File_Name {get; set;} //varchar(50) not null
        [Column(_Date_Created, CType.DateTime)]                                               public DateTime Date_Created {get; set;} //datetime(8) not null
        [Column(_Owner, CType.Int, Nullable = true)]                                          public int? Owner {get; set;} //int(4) null

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



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _ID });
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

