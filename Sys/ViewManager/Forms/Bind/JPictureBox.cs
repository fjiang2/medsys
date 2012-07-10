using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JPictureBox : JWinControl
    {

        public JPictureBox(System.Windows.Forms.PictureBox pictureBox, DataField field)
            : base(pictureBox, field)
        {
        }


        public override void Fill()
        {
            base.Fill();

            if (value != System.DBNull.Value)
            {
                MemoryStream stream = new MemoryStream((byte[])value);
                (Control as PictureBox).Image = Image.FromStream(stream);
            }
            else
                (Control as PictureBox).Image = null;

            return;
        }

        public override void Collect()
        {
            PictureBox pictureBox = Control as PictureBox;

            if (pictureBox.Image == null)
            {
                value = System.DBNull.Value;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                pictureBox.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                value = stream.ToArray();
            }
            
            base.Collect();

            return;
        }
    }
}
