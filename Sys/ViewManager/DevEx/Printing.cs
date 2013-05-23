using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Columns;
using System.Drawing;
using DevExpress.XtraPrintingLinks;

namespace Sys.ViewManager.DevEx
{    
    public class Printing
    {


        private string[] header;
        private string[] footer;

        CompositeLink compositeLink = new CompositeLink(new PrintingSystem());

        
        public Printing()
        {
            this.compositeLink.Landscape = true;
        }

        public Printing(string[] header, string[] footer)
            :this()
        {
            this.header = header;
            this.footer = footer;
        }

        public Printing(IPrintable viewControl)
            :this()
        {
            AddControl(viewControl);
        }

        public Printing(IPrintable viewControl, string[] header, string[] footer)
            : this(header, footer)
        {
            AddControl(viewControl);
        }

        public string[] Header
        {
            get { return this.header; }
            set { this.header = value; }
        }
        public string[] Footer
        {
            get { return this.footer; }
            set { this.footer = value; }
        }

        public LinkCollection Links
        {
            get { return this.compositeLink.Links; }
        }

        public void AddControl(IPrintable viewControl)
        {
            PrintableComponentLink pcLink1 = new PrintableComponentLink();
            pcLink1.Component = viewControl;
            compositeLink.Links.Add(pcLink1);
        }

        public void AddSeparator()
        {
            Link link = new Link();
            link.CreateDetailArea += new CreateAreaEventHandler(Separator_CreateArea);
            compositeLink.Links.Add(link);
        }
        
        // Creates an interval between the grids and fills it with color.
        void Separator_CreateArea(object sender, CreateAreaEventArgs e)
        {

            TextBrick tb = new TextBrick();
            tb.Rect = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            tb.BackColor = Color.Gray;
            e.Graph.DrawBrick(tb);
        }


        class TextLink : Link
        {
            private string text;

            public TextLink(string text)
            {
                this.text = text;
                this.CreateDetailArea += new CreateAreaEventHandler(Text_CreateArea);
            }

            // Creates a text header for the first grid.
            void Text_CreateArea(object sender, CreateAreaEventArgs e)
            {
                TextBrick tb = new TextBrick();
                tb.Text = this.text;
                tb.Font = new Font("Arial", 15);
                tb.Rect = new RectangleF(0, 0, 300, 25);
                tb.BorderWidth = 0;
                tb.BackColor = Color.Transparent;
                tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
                e.Graph.DrawBrick(tb);
            }


        }

        public void AddText(string text)
        {
            Link link = new TextLink(text);
            compositeLink.Links.Add(link);
        }

        
        public void DataPrint()
        {
           
            if (header != null)
                Printing.CreateHeader(compositeLink, header);

            if(footer==null)
                Printing.CreateDefaultFooter(compositeLink);

            compositeLink.PrintDlg();
        }


        public void DataPrintPreview()
        {

            if (header != null)
                Printing.CreateHeader(compositeLink, header);
            
            if (footer == null)
                Printing.CreateDefaultFooter(compositeLink);

            compositeLink.ShowPreview();
        }





        //---------------------------------------------------------------------------------------------------------------------------

        private static void CreateHeader(CompositeLink link, string[] header)
        {
            PageHeaderFooter pageHeaderFooter = (PageHeaderFooter)link.PageHeaderFooter;

            Image image = SysInformation.Logo;
            link.Images.Add(image);

            PageArea pageArea = pageHeaderFooter.Header;
            pageArea.Content.Clear();

            pageArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pageArea.LineAlignment = BrickAlignment.Center;

            if (header == null || header.Length == 0)
                pageArea.Content.Add("[Image 0]");
            else
            {
                pageArea.Content.Add("[Image 0]" + header[0].Replace("\\n", "\r\n"));

                for (int i = 1; i < header.Length; i++)
                {
                    pageArea.Content.Add(header[i].Replace("\\n", "\r\n"));
                }
            }
        }

        private static void CreateFooter(LinkBase link, string[] footer)
        {
            PageHeaderFooter pageHeaderFooter = (PageHeaderFooter)link.PageHeaderFooter;

            PageArea pageArea = pageHeaderFooter.Footer;
            pageArea.Content.Clear();
            pageArea.LineAlignment = BrickAlignment.Center;
            foreach (string s in footer)
                pageArea.Content.Add(s);

        }

        private static void CreateDefaultFooter(LinkBase link)
        {
            CreateFooter(link, new string[] { "Printed: [Date Printed][Time Printed]", "", "Page: [Page # of Pages #]" });
        }




    }

}
