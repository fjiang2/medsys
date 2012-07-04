using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using Sys.Data;
using Sys.DataManager.Dpo;

namespace Sys.DataManager
{
    public class PictureDpo : sysPictureDpo
    {
        public const string _Image = "Image";
     

        Image image;
        bool newImage;

        public PictureDpo()
        { 
        }

        public PictureDpo(DataRow dataRow)
            :base(dataRow)
        {
        }


        /// <summary>
        /// Add new image into database
        /// </summary>
        /// <param name="label"></param>
        /// <param name="image"></param>
        public PictureDpo(DPObject dpo, Image image)
        {
            this.Table_Id = dpo.TableId;
            this.Table_Name = dpo.TableName.FullName;
            this.Row_Id = dpo.RowId;

            this.Label = "";
            this.image = image;

            this.newImage = true;
        }


        public Image Image
        {
            get
            {
                return this.image;
            }
        }

      
        public override void Fill(DataRow dataRow)
        {
            base.Fill(dataRow);

            if (dataRow.RowState != DataRowState.Added)
            {
                ImageMan imageMan = new ImageMan(this.File_Name, (DateTime)this.Date_Created);
                this.image = imageMan.Image;
            }
            else
            {
                //PictureDpo pic = new PictureDpo(dpo,  dataRow[_Image]);
                //pic.Save();
            }
        }

        public override void Collect(DataRow dataRow)
        {
            base.Collect(dataRow);
        }

        public override DataRow Load()
        {
            DataRow dataRow = base.Load();
            if (Exists)
            {
                this.newImage = false;

                ImageMan imageMan = new ImageMan(this.File_Name, (DateTime)this.Date_Created);
                this.image = imageMan.Image;
            }
            else
                this.newImage = true;

            return dataRow;
        }

        public override DataRow Save()
        {
            if (image == null)
                return null;
            
            if (newImage)
            {
                this.ID = -1;
                this.File_Name = Guid.NewGuid().ToString() + ".jpg";
                this.Date_Created = DateTime.Now;
                this.Owner = Sys.Security.Account.CurrentUser.User_ID;

                ImageMan imageMan = new ImageMan(this.image, File_Name);
                imageMan.Save(ImageFormat.Jpeg);
            }

            return base.Save();
        }
     
    }
}
