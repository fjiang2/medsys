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


namespace Sys.Platform.DpoClass
{
    [Revision(4)]
    [Table("Resources", Level.System, Pack = false)]    //Primary Keys = UniqueID;  Identity = UniqueID;
    public class ResourceDpo : DPObject
    {

#pragma warning disable

        [Column(_UniqueID, CType.Int, Identity = true, Primary = true)]                       public int UniqueID {get; set;} //int(4) not null
        [Column(_ResourceID, CType.Int)]                                                      public int ResourceID {get; set;} //int(4) not null
        [Column(_ResourceName, CType.NVarChar, Nullable = true, Length = 50)]                 public string ResourceName {get; set;} //nvarchar(50) null
        [Column(_Color, CType.Int, Nullable = true)]                                          public int? Color {get; set;} //int(4) null
        [Column(_Image, CType.Image, Nullable = true)]                                        public byte[] Image {get; set;} //image(16) null
        [Column(_CustomField1, CType.NVarChar, Nullable = true, Length = -1)]                 public string CustomField1 {get; set;} //nvarchar(-1) null

        #region IMAGE PROPERTIES
        public Image ImageImage
        {
            get
            {
                if (Image != null)
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(Image);
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
                    Image = stream.ToArray();
                }
            }
        }

        #endregion
#pragma warning restore

        public ResourceDpo()
        {
        }

        public ResourceDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public ResourceDpo(int uniqueid)
        {
           this.UniqueID = uniqueid; 

           this.Load();
           if(!this.Exists)
           {
              this.UniqueID = uniqueid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.UniqueID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _UniqueID });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _UniqueID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new ResourceDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _UniqueID = "UniqueID";
        public const string _ResourceID = "ResourceID";
        public const string _ResourceName = "ResourceName";
        public const string _Color = "Color";
        public const string _Image = "Image";
        public const string _CustomField1 = "CustomField1";

       
        #endregion 



    }
}

