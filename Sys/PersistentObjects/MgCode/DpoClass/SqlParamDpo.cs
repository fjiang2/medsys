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
    [Revision(14)]
    [Table("sys00805", Level.System)]    //Primary Keys = ID;  Identity = ID;
    public class SqlParamDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true, Primary = true)]                             public int ID {get; set;}     //int(4) not null
        [Column(_Label, SqlDbType.NVarChar, Length = 50)]                                         public string Label {get; set;} //nvarchar(50) not null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 128)]                 public string Description {get; set;} //nvarchar(128) null
        [Column(_Command, SqlDbType.NVarChar, Length = 128)]                                      public string Command {get; set;} //nvarchar(128) not null
        [Column(_Icon, SqlDbType.Image, Nullable = true)]                                         public byte[] Icon {get; set;} //image(16) null
        [Column(_OrderBy, SqlDbType.Int, Nullable = true)]                                        public int? OrderBy {get; set;} //int(4) null

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

        public SqlParamDpo()
        {
        }

        public SqlParamDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public SqlParamDpo(int id)
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
              return new SqlParamDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Command = "Command";
        public const string _Icon = "Icon";
        public const string _OrderBy = "OrderBy";

       
        #endregion 



    }
}

