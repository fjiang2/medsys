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
    [Table("sys00804", Level.System)]    //Primary Keys = ID;  Identity = ID;
    public class SqlProcDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_ParentID, SqlDbType.Int, Nullable = true)]                                       public int? ParentID {get; set;} //int(4) null
        [Column(_OrderBy, SqlDbType.Int, Nullable = true)]                                        public int? OrderBy {get; set;} //int(4) null
        [Column(_Ty, SqlDbType.Int)]                                                              public int Ty {get; set;}     //int(4) not null
        [Column(_Company_ID, SqlDbType.Int, Nullable = true)]                                     public int? Company_ID {get; set;} //int(4) null
        [Column(_Application, SqlDbType.NVarChar, Nullable = true, Length = 50)]                  public string Application {get; set;} //nvarchar(50) null
        [Column(_Module, SqlDbType.VarChar, Nullable = true, Length = 128)]                       public string Module {get; set;} //varchar(128) null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 128)]                       public string Label {get; set;} //nvarchar(128) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 512)]                 public string Description {get; set;} //nvarchar(512) null
        [Column(_Key_Name, SqlDbType.NVarChar, Nullable = true, Length = 128)]                    public string Key_Name {get; set;} //nvarchar(128) null
        [Column(_Command, SqlDbType.NVarChar, Nullable = true, Length = 4000)]                    public string Command {get; set;} //nvarchar(4000) null
        [Column(_Icon, SqlDbType.Image, Nullable = true)]                                         public byte[] Icon {get; set;} //image(16) null
        [Column(_Controlled, SqlDbType.Bit)]                                                      public bool Controlled {get; set;} //bit(1) not null
        [Column(_Enabled, SqlDbType.Bit)]                                                         public bool Enabled {get; set;} //bit(1) not null
        [Column(_Visible, SqlDbType.Bit)]                                                         public bool Visible {get; set;} //bit(1) not null
        [Column(_Released, SqlDbType.Bit)]                                                        public bool Released {get; set;} //bit(1) not null
        [Column(_Form_Class, SqlDbType.VarChar, Nullable = true, Length = 128)]                   public string Form_Class {get; set;} //varchar(128) null
        [Column(_Form_Place, SqlDbType.Int, Nullable = true)]                                     public int? Form_Place {get; set;} //int(4) null

        #region IMAGE PROPERTIES
        public Image IconImage
        {
            get
            {
                if (Icon != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Icon);
                    return System.Drawing.Image.FromStream(stream);
                }
                
                return null;
            }
            set
            {
                if (value != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    value.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Icon = stream.ToArray();
                }
            }
        }

        #endregion
#pragma warning restore

        public SqlProcDpo()
        {
        }

        public SqlProcDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public SqlProcDpo(int id)
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
              return new SqlProcDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _ParentID = "ParentID";
        public const string _OrderBy = "OrderBy";
        public const string _Ty = "Ty";
        public const string _Company_ID = "Company_ID";
        public const string _Application = "Application";
        public const string _Module = "Module";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Key_Name = "Key_Name";
        public const string _Command = "Command";
        public const string _Icon = "Icon";
        public const string _Controlled = "Controlled";
        public const string _Enabled = "Enabled";
        public const string _Visible = "Visible";
        public const string _Released = "Released";
        public const string _Form_Class = "Form_Class";
        public const string _Form_Place = "Form_Place";

       
        #endregion 



    }
}

