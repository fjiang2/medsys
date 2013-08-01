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


namespace App.Data.DpoClass
{
    [Revision(23)]
    [Table("Northwind..[Categories]", Level.Fixed)]    //Primary Keys = CategoryID;  Identity = CategoryID;
    public class CategorieDpo : DPObject
    {

#pragma warning disable

        [Column(_CategoryID, CType.Int, Identity = true, Primary = true)]                     public int CategoryID {get; set;} //int(4) not null
        [Column(_CategoryName, CType.NVarChar, Length = 15)]                                  public string CategoryName {get; set;} //nvarchar(15) not null
        [Column(_Description, CType.NText, Nullable = true)]                                  public string Description {get; set;} //ntext(16) null
        [Column(_Picture, CType.Image, Nullable = true)]                                      public byte[] Picture {get; set;} //image(16) null

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

        public CategorieDpo()
        {
        }

        public CategorieDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        public CategorieDpo(int categoryid)
        {
           this.CategoryID = categoryid; 

           this.Load();
           if(!this.Exists)
           {
              this.CategoryID = categoryid;     
           }
        }
        


        protected override int DPObjectId
        {
            get
            {
                return this.CategoryID;
            }
        }



        public override IPrimaryKeys Primary
        {
            get
            {
                return new PrimaryKeys(new string[]{ _CategoryID });
            }
        }



        public override IIdentityKeys Identity
        {
            get
            {
                return new IdentityKeys(new string[]{ _CategoryID });
            }
        }


        public static string TABLE_NAME
        { 
            get
            {
              return new CategorieDpo().TableName.FullName;
            }
        }



        #region CONSTANT

        public const string _CategoryID = "CategoryID";
        public const string _CategoryName = "CategoryName";
        public const string _Description = "Description";
        public const string _Picture = "Picture";

       
        #endregion 



    }
}

