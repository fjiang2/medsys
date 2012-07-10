using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Sys.DataManager;
using Sys.Data;
using Sys.ViewManager;
using Sys.ViewManager.Forms;


namespace Sys.Platform.Forms
{
    public enum ImageStyle
    { 
        ActualSize,
        FitWidth,
        FitHeight,
        Stretch,
        Zoom
    }

    public partial class ImageViewer : BaseForm
    {
        private ImageStyle imageStyle = ImageStyle.ActualSize;
        
        private string dataMember = "Image";
        double ratio = 1.0;
        double zoom = 1.0;

        public ImageViewer()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.DataBindings.Add(new Binding("Image", bindingSource1, dataMember));
        }


      

        public DataTable DataSource
        {
            get
            {
                return (DataTable)bindingSource1.DataSource;
            }
            set
            {
                bindingSource1.DataSource = value;
            }
        }


        public string DataMember
        {
            get
            {
                return dataMember;
            }
            set
            {
                if (dataMember == value)
                    return;

                this.dataMember = value;
                pictureBox1.DataBindings.Clear();
                pictureBox1.DataBindings.Add(new Binding("Image", bindingSource1, dataMember));
            }
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
            imageStyle = ImageStyle.ActualSize;
            pictureBox1.Dock = DockStyle.Fill;
    
        }

        public Image Image
        {
            get
            {
                return pictureBox1.Image;
            }
        }




        private void toolStripButtonActualSize_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            imageStyle = ImageStyle.ActualSize;
            RefreshSize();

        }

        private void RefreshSize()
        {
            switch (imageStyle)
            {
                case ImageStyle.ActualSize:
                    pictureBox1.Dock = DockStyle.Fill;
                    if (Image.Size.Height > pictureBox1.Height)
                    {
                        pictureBox1.Dock = DockStyle.None;
                        pictureBox1.Height = Image.Size.Height;
                    }
                    else
                        pictureBox1.Height = panel1.Height;

                    if (Image.Size.Width > pictureBox1.Width)
                    {
                        pictureBox1.Dock = DockStyle.None;
                        pictureBox1.Width = Image.Size.Width;
                    }
                    else
                        pictureBox1.Width = panel1.Width;

                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                    return;

                case ImageStyle.Stretch:

                    pictureBox1.Dock = DockStyle.Fill;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    return;

                case ImageStyle.FitWidth:
                    pictureBox1.Dock = DockStyle.None;

                    ratio = Image.Width * 1.0 / Image.Height;
                    pictureBox1.Width = panel1.Width;
                    pictureBox1.Height = (int)(pictureBox1.Width / ratio);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    return;

                case ImageStyle.FitHeight:
                    pictureBox1.Dock = DockStyle.None;

                    ratio = Image.Width * 1.0 / Image.Height;
                    pictureBox1.Height = panel1.Height;
                    pictureBox1.Width = (int)(pictureBox1.Height * ratio);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    return;

                case ImageStyle.Zoom:
                    pictureBox1.Dock = DockStyle.None;
                    pictureBox1.Height = (int)(zoom * Image.Height);
                    pictureBox1.Width = (int)(zoom * Image.Width);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    return;

            }
        }


        private void toolStripButtonFillWindow_Click(object sender, EventArgs e)
        {
            imageStyle = ImageStyle.Stretch;
            RefreshSize();
           
        }


   

        private void toolStripButtonFitSize_Click(object sender, EventArgs e)
        {
            imageStyle = ImageStyle.FitHeight;
            RefreshSize();
        }

        private void toolStripButtonFitWidth_Click(object sender, EventArgs e)
        {
            imageStyle = ImageStyle.FitWidth;
            RefreshSize();
        }

        private void toolStripButtonRotateRight_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            RefreshSize();
            pictureBox1.Refresh();
        }

        private void toolStripButtonRotateLeft_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            RefreshSize();
            pictureBox1.Refresh();
        }


        #region Print

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            doc.Print();
        }


        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        #endregion

        private void PictureForm_SizeChanged(object sender, EventArgs e)
        {
            RefreshSize();
            pictureBox1.Refresh();
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem item = (System.Windows.Forms.ToolStripMenuItem)sender;
            zoom = Double.Parse(item.Text.Replace("%","")) / 100.0;
            imageStyle = ImageStyle.Zoom;
            RefreshSize();
        }

        private void btnZoomCustom_Click(object sender, EventArgs e)
        {
            string value= string.Format("{0:0.00}", zoom*100.0);
            if (InputTool.InputBox("Zoom", "Magnification %","999.99", ref value) == System.Windows.Forms.DialogResult.OK)
            {
                double x;
                if (double.TryParse(value, out x))
                {
                    zoom = x/100.0;
                    imageStyle = ImageStyle.Zoom;
                    RefreshSize();
                }
            }

        }



        //private RowImageList images;
        //public DPObject Dpo
        //{
        //    set
        //    {
        //        DPObject dpo = value;
        //        images = new DpoImageList(dpo);
        //        bindingSource1.DataSource = images.DataTable;
        //    }
        //}

        private void toolStripButtonSnapshot_Click(object sender, EventArgs e)
        {
#if VIDEO_CAPTURE
            VideoCapture.SnapshotForm snapshot = new VideoCapture.SnapshotForm();
            
            if (snapshot.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {

                //get image from Camera
                Image[] photos = snapshot.Images;

                foreach (Image image in photos)
                {
                    if (images != null)
                        images.AddImage(image);
                    else
                    {
                        DataRow row = DataSource.NewRow();
                        row[dataMember] = image;
                        DataSource.Rows.Add(row);
                    }

                }
                bindingSource1.MoveLast();
            }
#endif
        }
     

    
    }
}
