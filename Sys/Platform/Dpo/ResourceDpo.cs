//
// Machine Generated Code
//   by devel at 4/27/2012 3:20:04 PM
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using Sys.Data;
using Sys.Data.Manager;


namespace Sys.Platform.Dpo
{
    [Revision(1)]
    [Table("Resources", Level.System, Pack = false)]    //Primary Keys = UniqueID;  Identity = UniqueID;
    public class ResourceDpo : DPObject
    {

#pragma warning disable

        [Column(_UniqueID, SqlDbType.Int, Identity = true, Primary = true)]                       public int UniqueID;          //int(4) not null
        [Column(_ResourceID, SqlDbType.Int)]                                                      public int ResourceID;        //int(4) not null
        [Column(_ResourceName, SqlDbType.NVarChar, Nullable = true, Length = 50)]                 public string ResourceName;   //nvarchar(50) null
        [Column(_Color, SqlDbType.Int, Nullable = true)]                                          public int? Color;            //int(4) null
        [Column(_Image, SqlDbType.Image, Nullable = true)]                                        public byte[] Image;          //image(16) null
        [Column(_CustomField1, SqlDbType.NVarChar, Nullable = true, Length = -1)]                 public string CustomField1;   //nvarchar(-1) null

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



        public override PrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _UniqueID });
            }
        }



        public override IdentityKeys Identity
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

