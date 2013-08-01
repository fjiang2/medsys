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
    [Table("sys00806", Level.System)]    //Primary Keys = Image_Index + Ty;  Identity = ID;
    public class ImageDpo : DPObject
    {

#pragma warning disable

        [Column(_ID, CType.Int, Identity = true)]                                             public int ID {get; set;}     //int(4) not null
        [Column(_Ty, CType.Int, Primary = true)]                                              public int Ty {get; set;}     //int(4) not null
        [Column(_Image_Index, CType.Int, Primary = true)]                                     public int Image_Index {get; set;} //int(4) not null
        [Column(_Label, CType.NVarChar, Length = 50)]                                         public string Label {get; set;} //nvarchar(50) not null
        [Column(_Description, CType.NVarChar, Nullable = true, Length = 128)]                 public string Description {get; set;} //nvarchar(128) null
        [Column(_Picture, CType.Image)]                                                       public byte[] Picture {get; set;} //image(16) not null

        #region IMAGE PROPERTIES
        public Image PictureImage
        {
            get
            {
                if (Picture != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Picture);
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
                    Picture = stream.ToArray();
                }
            }
        }

        #endregion
#pragma warning restore

        public ImageDpo()
        {
        }

        public ImageDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ImageDpo(int image_index, int ty)
        {
           this.Image_Index = image_index; this.Ty = ty; 

           this.Load();
           if(!this.Exists)
           {
              this.Image_Index = image_index; this.Ty = ty;     
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
                return new PrimaryKeys(new string[]{ _Image_Index, _Ty });
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
              return new ImageDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _ID = "ID";
        public const string _Ty = "Ty";
        public const string _Image_Index = "Image_Index";
        public const string _Label = "Label";
        public const string _Description = "Description";
        public const string _Picture = "Picture";

       
        #endregion 



    }
}

