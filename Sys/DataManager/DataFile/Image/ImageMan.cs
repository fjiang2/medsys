using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;

namespace Sys.DataManager
{
    class ImageMan : FilePath
    {
        public const string IMAGE_PATH = "Path.Image";

        private Image image;
        
        /// <summary>
        /// Add new Image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="simpleFileName"></param>
        public ImageMan(Image image, string simpleFileName)
            : base(simpleFileName, new DateDirectory(IMAGE_PATH, DateTime.Today))
        {
           
            this.image = image;
        }

        /// <summary>
        /// Load existed image
        /// </summary>
        /// <param name="simpleFileName"></param>
        /// <param name="dateCreated"></param>
        public ImageMan(string simpleFileName, DateTime dateCreated)
            : base(simpleFileName, new DateDirectory(IMAGE_PATH, dateCreated))
        {
            System.IO.FileStream stream = FileReader();
            this.image = Image.FromStream(stream);
            stream.Close();
        }

        public Image Image
        {
            get
            {
                return this.image;
            }
        }

        

        public void Save(ImageFormat imageFormat)
        {
            System.IO.FileStream stream = FileWriter();
            image.Save(stream, imageFormat);
            stream.Close();
        }


      
    }
}
