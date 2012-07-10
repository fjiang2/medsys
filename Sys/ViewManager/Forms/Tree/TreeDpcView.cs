using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Sys.Data;
using System.Drawing;

namespace Sys.ViewManager.Forms
{
    public class TreeDpcView : TreeView
    {
        private List<ITreeNodeDpo> dpc;
        private DisplayTreeDpoNode d;
        private TreeDpoNode mySelectedNode;
        
        private TreeNode root;
        private int rootID;
        private Type nodeType;

        public TreeDpcView()
        {
            this.ContextMenuStrip = new ContextMenuStrip();
            treeMenuContextMenu(this.ContextMenuStrip);

            this.AfterSelect += new TreeViewEventHandler(TreeView_AfterSelect);
            this.ItemDrag += new ItemDragEventHandler(TreeDpcView_ItemDrag);
            this.DragEnter += new DragEventHandler(TreeDpcView_DragEnter);
            this.DragDrop += new DragEventHandler(TreeDpcView_DragDrop);
            this.DragOver += new DragEventHandler(TreeDpcView_DragOver);

            this.MouseDown += delegate(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                    TreeNode node = this.GetNodeAt(e.X, e.Y);
                    if(node is TreeDpoNode)
                        mySelectedNode = (TreeDpoNode)node;
                };

            this.AfterLabelEdit += new NodeLabelEditEventHandler(TreeView_AfterLabelEdit);

        }

        public List<ITreeNodeDpo> DataSource
        {
            get
            {
                return this.dpc;
            }
            set
            {

                if (value.Count > 0)
                    this.nodeType = value[0].GetType();
                else
                    this.nodeType = typeof(TreeNode);

                this.dpc = value;
            }
        }

        public ITreeNodeDpo SelectedDpo
        {
            get
            {
                if (this.SelectedDpoNode == null)
                    return null;

                return this.SelectedDpoNode.Dpo;
            }
        }


        public TreeDpoNode SelectedDpoNode
        {
            get
            {
                if (this.SelectedNode == null)
                    return null;

                if (!(this.SelectedNode is TreeDpoNode))
                    return null;

                return (TreeDpoNode)this.SelectedNode;
            }
        }


        public TreeNodeCollection myNodes
        {
            get
            {
                if (root != null)
                    return root.Nodes;
                else
                    return this.Nodes;
            }
        }

        #region Drag and Drop

        void TreeDpcView_DragDrop(object sender, DragEventArgs e)
        {
            TreeDpoNode node1;

            if (e.Data.GetDataPresent(typeof(TreeDpoNode).FullName, false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeDpoNode node2 = (TreeDpoNode)((TreeView)sender).GetNodeAt(pt);

                node1 = (TreeDpoNode)e.Data.GetData(typeof(TreeDpoNode).FullName);
                if (node2.TreeView == node1.TreeView)
                {
                    MoveNodeAsChild(node1, node2);
                    node2.Expand();
                }
            }

        }

        void TreeDpcView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void TreeDpcView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void TreeDpcView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }


        #endregion



        void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node == root)
                {
                    e.Node.Expand();
                    return;
                }

                TreeDpoNode treeNode = (TreeDpoNode)e.Node;
                //if (treeNode != null)
                    //LoadMenuItem(treeNode.Dpo);
            }
        }


        void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        // Stop editing without canceling the label change.
                        e.Node.EndEdit(false);
                        if (e.Node is TreeDpoNode)
                        {
                            TreeDpoNode dpoNode = (TreeDpoNode)e.Node;
                            dpoNode.Dpo.NodeText = e.Node.Text;
                            //dpoNode.Text = d(dpoNode.Dpo);
                            dpoNode.Dpo.NodeSave();
                        }
                    }
                    else
                    {
                        // Cancel the label edit action, inform the user, and place the node in edit mode again.
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n The invalid characters are: '@','.', ',', '!'",  "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    // Cancel the label edit action, inform the user, and place the node in edit mode again.
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",    "Node Label Edit");
                    e.Node.BeginEdit();
                }
            }

        }




        #region Add/Move/Delete Node

        private ITreeNodeDpo AddNode(TreeDpoNode selectedNode, string nodeText)
        {
            return AddNode(selectedNode, selectedNode.Dpo.NodeId, nodeText);
        }


        private ITreeNodeDpo AddNode(TreeNode selectedNode, int parentID, string nodeText)
        {
            ITreeNodeDpo dpo = (ITreeNodeDpo)Activator.CreateInstance(this.nodeType);
            dpo.NodeText = nodeText;
            dpo.NodeParentId = parentID;
            if (selectedNode.Nodes.Count > 0)
            {
                TreeDpoNode last = (TreeDpoNode)selectedNode.Nodes[selectedNode.Nodes.Count - 1];
                dpo.NodeOrderBy = last.Dpo.NodeOrderBy + 1;
            }
            else
                dpo.NodeOrderBy = 0;

            dpo.NodeSave();
            dpc.Add(dpo);

            selectedNode.Nodes.Add(new TreeDpoNode(dpo, d));

            return dpo;
        }

        private bool MoveNodeAsChild(TreeDpoNode from, TreeDpoNode to)
        {
            if (from == to)
                return false;

            from.Dpo.NodeParentId = to.Dpo.NodeId;
            if (to.Nodes.Count > 0)
            {
                TreeDpoNode last = (TreeDpoNode)to.Nodes[to.Nodes.Count - 1];
                from.Dpo.NodeOrderBy = last.Dpo.NodeOrderBy + 1;
            }
            else
                from.Dpo.NodeOrderBy = 0;

            from.Remove(); //from.Parent.Nodes.Remove(from);
            to.Nodes.Add(from);

            
            from.AcceptChanges();
            from.Dpo.NodeSave();
            return true;
        }


        private bool MoveNodeAsSibling(TreeDpoNode from, TreeDpoNode to)
        {
            if (from == to)
                return false;

            if (from.Parent == to.Parent)
            {
                TreeNodeCollection nodes = from.Parent.Nodes;
                int index = nodes.IndexOf(to);
                from.Dpo.NodeOrderBy = to.Dpo.NodeOrderBy + 1;
                from.Remove();
                nodes.Insert(index, from);
            }

            from.AcceptChanges();
            from.Dpo.NodeSave();
            return true;
        }


        private void RemoveNode(TreeDpoNode dpoNode)
        {
            dpoNode.Remove();
            dpc.Remove(SelectedDpo);
            dpoNode.Dpo.Delete();
        }

        #endregion


        private void treeMenuContextMenu(ContextMenuStrip contextMenuStrip)
        {
            ToolStripMenuItem addNode = new ToolStripMenuItem("Add blank tree node");
            ToolStripMenuItem deleteNode = new ToolStripMenuItem("Delete this tree node");
            ToolStripMenuItem addSeperator = new ToolStripMenuItem("Add Seperator");
            ToolStripMenuItem renameNode = new ToolStripMenuItem("Rename");

            contextMenuStrip.Items.Add(addNode);
            contextMenuStrip.Items.Add(deleteNode);
            contextMenuStrip.Items.Add(renameNode);
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add(addSeperator);

            addSeperator.Click += delegate(object sender, EventArgs e)
            {
                if (this.SelectedNode == null)
                    return;

                if (this.SelectedNode == root)
                    AddNode(root, rootID, "------");
                else
                    AddNode(SelectedDpoNode, "------");
            };


            addNode.Click += delegate(object sender, EventArgs e)
            {
                if (this.SelectedNode == null)
                    return;

                if (this.SelectedNode == root)
                    AddNode(root, rootID, "Undefined");
                else
                    AddNode(SelectedDpoNode, "Undefined");

            };

            deleteNode.Click += delegate(object sender, EventArgs e)
            {
                if (SelectedDpo == null)
                    return;

                if (MessageBox.Show(
                    string.Format("Menu item [{0}] {1} is about to be deleted, continue?", SelectedDpo.NodeId, SelectedDpo.NodeText),
                    "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    RemoveNode(SelectedDpoNode);
                }
            };


            renameNode.Click += delegate(object sender, EventArgs e)
            {
                if (mySelectedNode != null && mySelectedNode.Parent != null)
                {
                    this.SelectedNode = mySelectedNode;
                    this.LabelEdit = true;
                    if (!mySelectedNode.IsEditing)
                    {
                        mySelectedNode.BeginEdit();
                    }
                }
                else
                {
                    MessageBox.Show("No tree node selected or selected node is a root node.\nEditing of root nodes is not allowed.", "Invalid selection");
                }

            };



        }


        #region BuildTreeView

        public void BuildTreeView()
        {
            BuildTreeView(null, 0);
        }

      
        public void BuildTreeView(TreeNode root, int parentID)
        {

            BuildTreeView(root, parentID, DisplayDelegate);
        }

        public void BuildTreeView(TreeNode root, int parentID, DisplayTreeDpoNode d)
        {
            this.root = root;
            this.rootID = parentID;

            TreeNodeCollection nodes;
            if (root == null)
                nodes = this.Nodes;
            else
                nodes = root.Nodes;

            this.d = d;
            nodes.Clear();
            BuildTreeView(nodes, parentID, d);
            this.ExpandAll();
        }


        private void BuildTreeView(TreeNodeCollection nodes, int parentID, DisplayTreeDpoNode d)
        {
            foreach(ITreeNodeDpo dpo in dpc)
            {
                if (dpo.NodeParentId != parentID)
                    continue;

                dpo.NodeOrderBy = nodes.Count * 10;
                TreeDpoNode treeNode2 = new TreeDpoNode(dpo, d);
                nodes.Add(treeNode2);

                treeNode2.AcceptChanges();    //UPDATE dpc's DataTable

                BuildTreeView(treeNode2.Nodes, dpo.NodeId, d);
            }

        }


        private string DisplayDelegate(ITreeNodeDpo dpo)
        {
            return dpo.NodeText;
        }
        
        #endregion


        public TreeDpoNode SearchTreeNode(int ID)
        {
            return SearchTreeNode(ID, myNodes);
        }

        private TreeDpoNode SearchTreeNode(int ID, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node is TreeDpoNode)
                {
                    TreeDpoNode n = (TreeDpoNode)node;
                    if(n.Dpo.NodeId == ID)
                        return n;

                    SearchTreeNode(ID, n.Nodes);
                }
            }

            return null;
        }

        public void SaveOrderBy()
        {
             SaveOrderBy(myNodes);
        }


        private void SaveOrderBy(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node is TreeDpoNode)
                {
                    TreeDpoNode n = (TreeDpoNode)node;
                    n.Dpo.NodeSave();
                    SaveOrderBy(n.Nodes);
                }
            }
        }
    }
}
