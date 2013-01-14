using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using X12.DpoClass;
using Sys.ViewManager.Forms;
using X12.Specification;

namespace X12.Forms
{
    public partial class SpecMaintenance : BaseForm
    {
        TreeNode root;
        
        public SpecMaintenance()
        {
            InitializeComponent();

            x12LoopControl1.Visible = false;
            x12Segment2Control1.Visible = false;


            treeView1.ImageList = ImageList;
            root = new TreeNode("Transaction Set");
            treeView1.Nodes.Add(root);

            BuildTree(root, 0);
            root.Expand();

            treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            treeView1.MouseClick += new MouseEventHandler(treeView1_MouseClick);
        }


        private void BuildTree(TreeNode root, int parentID)
        {
            foreach (LoopTemplateDpo loopDpo in X12Manager.GetLoopTemplates(parentID))
            {
                LoopNode loopNode = new LoopNode(loopDpo);
                root.Nodes.Add(loopNode);

                foreach (X12SegmentInstanceDpo segment in X12Manager.GetSegementInstances(loopDpo))
                {
                    SegmentInstanceNode segmentNode = new SegmentInstanceNode(segment);
                    loopNode.Nodes.Add(segmentNode);
                }

                BuildTree(loopNode, loopDpo.ID);
            }
        }

        public static ImageList ImageList
        {
            get
            {
                ImageList list = new ImageList();
                list.Images.Add(global::X12.Properties.Resources.folder_picture);
                list.Images.Add(global::X12.Properties.Resources.pictures);
                list.Images.Add(global::X12.Properties.Resources.picture_empty);
                list.Images.Add(TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE, global::X12.Properties.Resources.BreakpointHS);

                return list;
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
                    if (treeNode is LoopNode)
                    {
                        LoopNode loopNode = (LoopNode)treeNode;

                        if (treeNode.Nodes.Count == 0)
                        {
                            foreach (X12SegmentInstanceDpo segment in X12Manager.GetSegementInstances(loopNode.LoopDpo))
                            {
                                SegmentInstanceNode node = new SegmentInstanceNode(segment);
                                treeNode.Nodes.Add(node);
                            }

                            treeNode.Expand();
                        }

                        tabControl1.SelectedTabPage = tabLoop;
                        
                        
                        x12LoopControl1.Dpo = new X12LoopTemplateDpo(loopNode.LoopDpo.Name);
                        x12Segment2Control1.Clear();
                     
                    }
                    else if (treeNode is SegmentInstanceNode)
                    {
                        X12SegmentInstanceDpo segment2 = (treeNode as SegmentInstanceNode).SegmentDpo;

                        if (treeNode.Nodes.Count == 0)
                        {
                            foreach (ElementTemplateDpo element in X12Manager.GetElementTemplates(segment2))
                            {
                                DataElementNode node = new DataElementNode(element);
                                treeNode.Nodes.Add(node);
                            }
                        }

                        tabControl1.SelectedTabPage = tabSegment;

                        x12Segment2Control1.Dpo = segment2;
                    }
                    else if (treeNode is DataElementNode)
                    {
                        ElementTemplateDpo element1 = (ElementTemplateDpo)(treeNode as DataElementNode).ElementDpo;

                        tabControl1.SelectedTabPage = tabDataElement;
                        this.x12Element1Control1.Dpo = element1;

                        X12SegmentInstanceDpo segment2 = (treeNode.Parent as SegmentInstanceNode).SegmentDpo;
                        ElementInstanceDpo element2 = new ElementInstanceDpo(element1.ID, segment2.ID);
                        
                        if(element1.ConditionDesignator== ConditionDesignator.Mandatory)
                            element2.UsageType = UsageType.Required;
                        else if (element1.ConditionDesignator == ConditionDesignator.Optional)
                            element2.UsageType = UsageType.Situational;
                        else
                            element2.UsageType = UsageType.NotUsed;

                        this.x12Element2Control1.Dpo = element2;
                    }
                    break;

                case MouseButtons.Right:
                    this.GetContextMenu(treeNode).Show((Control)sender, point.X, point.Y);
                    break;
            }
        }

        public ContextMenuStrip GetContextMenu(TreeNode treeNode)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem menuAdd = new ToolStripMenuItem("Add");
            ToolStripMenuItem menuRemove = new ToolStripMenuItem("Remove");
            ToolStripMenuItem menuRefresh = new ToolStripMenuItem("Refresh");

            contextMenu.Items.Add(menuAdd);
            contextMenu.Items.Add(menuRemove);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(menuRefresh);


            menuAdd.Click += delegate(object sender, EventArgs e)
            {
                if (treeNode == root)
                {
                    x12LoopControl1.Clear();
                    x12Segment2Control1.Clear();
                    
                    tabControl1.SelectedTabPage = tabLoop;
                }
                else if (treeNode is LoopNode)
                {
                    X12LoopTemplateDpo loop = (treeNode as LoopNode).LoopDpo;

                    var dpo = new X12SegmentInstanceDpo();
                    dpo.LoopName = loop.Name;
                    dpo.Sequence = treeNode.Nodes.Count;
                    dpo.RepeatValue = 1;

                    x12Segment2Control1.Dpo = dpo;
                    tabControl1.SelectedTabPage = tabSegment;
                }
                
            };

            menuRemove.Click += delegate(object sender, EventArgs e)
            {
                if (treeNode is LoopNode)
                {
                    string loop = treeNode.Text;
                    var dpo = new X12LoopTemplateDpo(loop);
                    dpo.Delete();
                }
                else if (treeNode is SegmentInstanceNode)
                {
                    string loop = treeNode.Parent.Text;
                    string segment = treeNode.Text;

                    (treeNode as SegmentInstanceNode).SegmentDpo.Delete();

                }
            };

            menuRefresh.Click += delegate(object sender, EventArgs e)
            {
                treeNode.Nodes.Clear();

                if (treeNode is LoopNode)
                {
                    
                    LoopNode loopNode = (LoopNode)treeNode;
                    foreach (X12SegmentInstanceDpo segment in X12Manager.GetSegementInstances(loopNode.LoopDpo))
                    {
                        SegmentInstanceNode segmentNode = new SegmentInstanceNode(segment);
                        loopNode.Nodes.Add(segmentNode);
                    }
                    BuildTree(loopNode, loopNode.LoopDpo.ID);
                }
                else if(treeNode is SegmentInstanceNode)
                {
                    X12SegmentInstanceDpo segment = (treeNode as SegmentInstanceNode).SegmentDpo;

                    foreach (X12ElementTemplateDpo element in X12Manager.GetElementTemplates(segment))
                    {
                        DataElementNode node = new DataElementNode(element);
                        treeNode.Nodes.Add(node);
                    }
                }

                treeNode.Expand();
            };

            return contextMenu;
        }




        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node == root)
                {
                    e.Node.Expand();
                    return;
                }

                if (e.Node is LoopNode)
                {
                    LoopNode node = (LoopNode)e.Node;

                    //LoadMenuItem(treeNode.Dpo);
                }
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTabPage == tabLoop)
            {
                x12LoopControl1.Save();
                MessageBox.Show("Loop Saved");
            }
            else if (tabControl1.SelectedTabPage == tabSegment)
            {
                x12Segment2Control1.Save();
                MessageBox.Show("Segment Saved");
            }
            else if (tabControl1.SelectedTabPage == tabDataElement)
            {
                x12Element2Control1.Save();
                MessageBox.Show("Data Element Saved");
            }
        }


    }
}
