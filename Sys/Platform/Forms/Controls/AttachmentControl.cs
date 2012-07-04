using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.DataManager;
using Sys.ViewManager.Forms;
using Sys.BusinessRules;
using Sys.Data;

namespace Sys.Platform.Forms
{
    public partial class AttachmentControl : BaseUserControl
    {
        DocumentList list;
        Dictionary<LinkLabel, Document> attachments = new Dictionary<LinkLabel, Document>();

        public AttachmentControl()
        {
            InitializeComponent();
        }

        public DPObject RowObject
        {
            set
            {
                list = new DocumentList(value);
                foreach (Document document in list.Documents)
                {
                    AddDocument(document);
                }
            }
        }

        public void AddDocument(string path, string label)
        {
            Document doc = new Document(path, label);
            AddDocument(doc);
            list.AddDocument(doc);
        }


        private void AddDocument(Document document)
        {
            LinkLabel linkLabel = new LinkLabel();
            linkLabel.Text = document.ToString();
            linkLabel.Width = flowLayoutPanel1.Width - 8;
            linkLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            linkLabel.MouseClick += new MouseEventHandler(linkLabel_MouseClick);

            this.flowLayoutPanel1.Controls.Add(linkLabel);
            attachments.Add(linkLabel, document);
        }

        void linkLabel_MouseClick(object sender, MouseEventArgs e)
        {
            LinkLabel linkLabel = (LinkLabel)sender;
            Document document = attachments[linkLabel];

            switch (e.Button)
            {

                case System.Windows.Forms.MouseButtons.Left:
                    document.Open();
                    break;

                case System.Windows.Forms.MouseButtons.Right:
                    if (account.IsDeveloper)
                    {
                        ContextMenuStrip menu = new ContextMenuStrip();
                        ToolStripMenuItem menu1 = new ToolStripMenuItem("Delete document");
                        menu1.Click += delegate(object sender1, EventArgs e1)
                        {
                            attachments.Remove(linkLabel);
                            this.flowLayoutPanel1.Controls.Remove(linkLabel);
                            list.RemoveDocument(document);

                        };
                        menu.Items.Add(menu1);


                        Point point = (sender as Control).PointToClient(Control.MousePosition);
                        menu.Show((Control)sender, point.X, point.Y);
                    }
                    break;
            }
            
        }



        private static string InitialDirectory = "c:\\";
        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = InitialDirectory;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|pdf files (*.pdf)|*.pdf|Doc files (*.docx)|*.docx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = openFileDialog1.FileName;
                InitialDirectory = System.IO.Path.GetFullPath(openFileDialog1.FileName);
            }

        }



        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            if (this.validateProvider.Validate())
            {
                AddDocument(this.txtPath.Text, txtDescription.Text);

                this.txtDescription.Text = "";
                this.txtPath.Text = "";
            }
        }


        public override void RuleDefinition(ValidateProvider provider)
        {
            this.txtPath.Required(provider, "Select a file first");

            this.txtDescription.Validate(provider, delegate(Validator validator, object sender)
            {
                if (txtPath.Text != "" && txtDescription.Text =="")
                {
                    validator.error("Please type description");
                    return;
                }
            });
        }
    }
}
