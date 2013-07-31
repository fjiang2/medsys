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
    [Revision(13)]
    [Table("sys00702", Level.System)]    //Primary Keys = Form_Class;  Identity = ID;
    public class FormClassDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, SqlDbType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Form_Class, SqlDbType.NVarChar, Primary = true, Length = 128)]                   public string Form_Class {get; set;} //nvarchar(128) not null
        [Column(_Label, SqlDbType.NVarChar, Nullable = true, Length = 100)]                       public string Label {get; set;} //nvarchar(100) null
        [Column(_Description, SqlDbType.NVarChar, Nullable = true, Length = 256)]                 public string Description {get; set;} //nvarchar(256) null
        [Column(_Icon, SqlDbType.Image, Nullable = true)]                                         public byte[] Icon {get; set;} //image(16) null
        [Column(_Help, SqlDbType.NText, Nullable = true)]                                         public string Help {get; set;} //ntext(16) null

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

        public FormClassDpo()
        {
        }

        public FormClassDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public FormClassDpo(string form_class)
        {
           this.Form_Class = form_class; 

           this.Load();
           if(!this.Exists)
           {
              this.Form_Class = form_class;     
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
                return new PrimaryKeys(new string[]{ _Form_Class });
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
              return new FormClassDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Form_Class = "Form_Class";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Icon = "Icon";
        public const string _Help = "Help";

       
        #endregion 



    }
}

