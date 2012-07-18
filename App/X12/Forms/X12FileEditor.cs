using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using X12.File;
using X12.Dpo;
using X12.Specification;
using Sys;
using Sys.Data;
using Sys.ViewManager.Forms;

namespace X12.Forms
{
    [Guid("766CB6A4-3B3F-4992-A94B-3764E5AA51A9")]
    public partial class X12FileEditor : BaseForm
    {

        X12File x12;
        TreeNode rootSegment;
        TreeNode rootSpecLoop;
        TreeNode rootLoop;

        public X12FileEditor()
        {
            InitializeComponent();
            treeView1.ImageList = SpecMaintenance.ImageList;
            this.segmentControl1.AllowCellMerge = true;

            this.rootSpecLoop = new TreeNode("5010A Specification");
            treeView1.Nodes.Add(rootSpecLoop);

            int parentId = 0;
            var tree = new NTree<LoopTemplateDpo>(Spec5010A.Instance.GetLoopTemplates(), parentId);
            tree.BuildTree<LoopTemplateDpo, LoopNode>(rootSpecLoop);
            rootSpecLoop.Expand();

            treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            treeView1.MouseClick += new MouseEventHandler(treeView1_MouseClick);
         
        }




        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == this.rootSegment)
            {
                tabControl1.SelectedTab = tabPageX12;
            }
            else if (e.Node is SegmentTemplateNode)
            {
                SegmentTemplateNode node = (SegmentTemplateNode)e.Node;
                ShowSegment(new SegmentName(node.SegmentDpo.Name));
            }
            else if (e.Node is LoopNode)
            {
                LoopNode node = (LoopNode)e.Node;
                ShowSegment(new LoopName(node.LoopDpo.Name));
            }
            else if (e.Node is ConsumerLoopNode)
            {
                ConsumerLoopNode node = (ConsumerLoopNode)e.Node;
                ShowSegment(node.Loop);
            }

        }

        void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            TreeView treeView1 = (sender as TreeView);

            // Select the clicked node
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            if (treeView1.SelectedNode == null)
                return;

            Point point = (sender as Control).PointToClient(Control.MousePosition);
            TreeNode treeNode = this.treeView1.SelectedNode;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    break;  

                case MouseButtons.Right:
                    this.GetContextMenu(treeNode).Show((Control)sender, point.X, point.Y);
                    break;
            }
        }


        private JGridView segmentGrid = new JGridView();
        public ContextMenuStrip GetContextMenu(TreeNode treeNode)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            if (treeNode is SegmentTemplateNode)
            {
                ToolStripMenuItem menuProperty = new ToolStripMenuItem("Property...");
                
                contextMenu.Items.Add(menuProperty);

                Guid guid = new Guid("7AEC4232-93DA-4B09-B44B-A14C3340C43C");
                
                segmentGrid.GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
                segmentGrid.Dock = DockStyle.Fill;
                segmentGrid.AllowEdit = false;

                menuProperty.Click += delegate(object sender, EventArgs e)
                {
                    X12SegmentTemplateDpo segment = (treeNode as SegmentTemplateNode).SegmentDpo;
                    DataTable dt = Spec5010A.Instance.GetSegmentInstances().Where(dpo => dpo.Name == segment.Name).ToTable();
                    segmentGrid.DataSource = dt;

                    this.AddDockPanel(guid, "Segment: " + segment.Name, DevExpress.XtraBars.Docking.DockingStyle.Bottom, segmentGrid);
                    
                    
                };

            }

            return contextMenu;
        }


        





        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog(this);
            string fileName = openFileDialog1.FileName;

            if (fileName == "")
                return;

            if (!System.IO.File.Exists(fileName))
            {
                MessageBox.Show(string.Format("File {0} does not exist", fileName), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            this.Text = string.Format("X12 File Editor ({0})", fileName);
            this.x12 = new X12File(fileName);
            Init(this.x12);

            this.Cursor = Cursors.Default;
        }

        private void Init(X12File x12)
        {
            ClearTabs();

            //Combox Segments List
            comboSegments.Items.Clear();
            foreach (string seg in this.x12.Segments.AsEnumerable().OrderBy(line => line))
                comboSegments.Items.Add(seg);


            //TreeNode Segments
            if (rootSegment == null)
            {
                rootSegment = new TreeNode(this.x12.FileName);
                treeView1.Nodes.Add(rootSegment);
            }
            else
            {
                rootSegment.Nodes.Clear();
            }

            var theSegments = this.x12.Segments.AsEnumerable().Join(Spec5010A.Instance.GetSegmentTemplates(), o => o, i => i.Name, (o, i) => i);
            foreach (var seg in theSegments)
            {
                TreeNode node = new SegmentTemplateNode(seg);
                rootSegment.Nodes.Add(node);
            }
            rootSegment.Expand();

            this.segmentControl1.SetDataSource(this.x12, SegmentName.DefaultName);

            if (rootLoop != null)
                rootLoop.Nodes.Clear();
        }




        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (this.x12 == null)
                return;

            x12.Save();
        }



        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            ShowSegment(CurrentSegment);
        }

        private void comboSegments_TextChanged(object sender, EventArgs e)
        {
            ShowSegment(CurrentSegment);
        }

        #region Show Segments by SegmentName, LoopName or LoopConsumer

        private void ShowSegment(SegmentName segment)
        {
            if (this.x12 == null)
                return;

            if (!tabControl1.TabPageExists(segment.Name))
            {
                X12SegmentControl seg = new X12SegmentControl();
                seg.SetDataSource(x12, segment);
                tabControl1.AddTabPage(segment.Name, seg);
            }
        }

        private void ShowSegment(LoopName loop)
        {
            if (this.x12 == null)
                return;

            if (!tabControl1.TabPageExists(loop.Name))
            {
                X12SegmentControl seg = new X12SegmentControl();
                if (seg.SetDataSource(x12, loop) == 0)
                {
                    MessageBox.Show(string.Format("Loop {0} is not found", loop), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tabControl1.AddTabPage(loop.Name, seg);
            }

        }


        private TabPage tabPageLoop = null;
        private void ShowSegment(LoopLine loop)
        {
            if (this.x12 == null)
                return;

            if (tabPageLoop == null)
            {
                X12SegmentControl seg = new X12SegmentControl();
                seg.SetDataSource(x12, loop);
                tabPageLoop = tabControl1.AddTabPage("LOOP", seg);
            }
            else
            {
                X12SegmentControl seg = tabPageLoop.Controls[0] as X12SegmentControl;
                seg.SetDataSource(x12, loop);
            }

            tabControl1.SelectedTab = tabPageLoop;
        }

        #endregion


        public SegmentName CurrentSegment
        {
            get
            {
                return new SegmentName(comboSegments.Text);
            }
        }


        private void btnShowGrid_Click(object sender, EventArgs e)
        {
            if (this.x12 == null)
                return;

            SegmentName segment = SegmentName.DefaultName;
            DataTable dt = x12.ToTable(segment);
            GridForm form = new GridForm();

            form.Text = string.Format("{0}", x12.FileName);
            form.DataSource = dt;
            form.Show(this);
        }

        private void toolStripButtonSpec_Click(object sender, EventArgs e)
        {
            var form = new SpecMaintenance();
            form.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.segmentControl1.SetDataSource(this.x12, SegmentName.DefaultName);
            }
        }

        private void btnControlNumber_Click(object sender, EventArgs e)
        {
            Form form = new X12ControlNumber(x12);

            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.segmentControl1.SetDataSource(this.x12, SegmentName.DefaultName);  //fresh

                //close the following tabs
                foreach (TabPage page in this.tabControl1.TabPages)
                {
                    if (new string[] { "ISA", "GS", "GE", "ST", "SE", "IEA" }.Where(segment => segment == page.Text).Count() == 1)
                        this.tabControl1.TabPages.Remove(page);
                }

            }
        }


        private void ClearTabs()
        {
            //Clear
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                if (tabPage != tabPageX12)
                    tabControl1.TabPages.Remove(tabPage);
            }
            tabPageLoop = null;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (this.x12 == null)
                return;

            btnParse.Enabled = false;

           
            ClearTabs();
            
            //TreeNode Loops
            if (rootLoop == null)
            {
                rootLoop = new TreeNode("LOOPS");
                treeView1.Nodes.Add(rootLoop);
            }
            else
            {
                rootLoop.Nodes.Clear();
            }
            
            Worker worker = this.StartProgressBar(delegate(Worker worker1)
            {
                this.x12.Parse(worker1);
            });

            worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs e1)
            {
                this.Cursor = Cursors.WaitCursor;

                x12.Consumer.BuildTree<LoopLine, ConsumerLoopNode>(rootLoop);
                rootLoop.Expand();

                this.segmentControl1.SetDataSource(this.x12, SegmentName.DefaultName);
                
                this.ShowMessage(this.x12.Messages, MessagePlace.ErrorListWindow);
                btnParse.Enabled = true;
                this.Cursor = Cursors.Default;
            };

          
        }

    

        private void btnDeleteSegmentLine_Click(object sender, EventArgs e)
        {
            if (this.x12 == null)
                return;

            InputBox form = new InputBox();
            form.Message = string.Format("Line number is from 1 to {0}", this.x12.TotoalLine);
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                int line = int.Parse(form.Value);
                if (line > this.x12.TotoalLine)
                    return;

                this.x12.RemoveLine(line);
                this.Init(this.x12);
            }
        }



    
        private void X12FileEditor_Load(object sender, EventArgs e)
        {
            base.MessageManager.MessageClicked += new MessageHandler(MessageManager_MessageClicked);
        }

        private void X12FileEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.MessageManager.MessageClicked -= MessageManager_MessageClicked;
        }

        void MessageManager_MessageClicked(object sender, MessageEventArgs e)
        {
            tabControl1.SelectedTab = tabPageX12;
            
            this.segmentControl1.GotoLine(e.Message.Location.Line); 

        }



    }
}
