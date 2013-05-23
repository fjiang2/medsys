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
    [Revision(15)]
    [Table("sys00901", Level.System)]    //Primary Keys = ID;  Identity = ID;
    public class DataImportDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 50)]                        public string Label {get; set;} //nvarchar(50) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 512)]                 public string Description {get; set;} //nvarchar(512) null
        [Column(_DataSource, SqlDbType.NVarChar, Nullable = true, Length = -1)]                   public string DataSource {get; set;} //nvarchar(-1) null
        [Column(_ClassName, SqlDbType.NVarChar, Nullable = true, Length = 256)]                   public string ClassName {get; set;} //nvarchar(256) null
        [Column(_Mapping, SqlDbType.NText, Nullable = true)]                                      public string Mapping {get; set;} //ntext(16) null
        [Column(_ActionButtonName, SqlDbType.NVarChar, Nullable = true, Length = 256)]            public string ActionButtonName {get; set;} //nvarchar(256) null

#pragma warning restore

        public DataImportDpo()
        {
        }

        public DataImportDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public DataImportDpo(int id)
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
              return new DataImportDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _DataSource = "DataSource";
        public const string _ClassName = "ClassName";
        public const string _Mapping = "Mapping";
        public const string _ActionButtonName = "ActionButtonName";

       
        #endregion 



    }
}

