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
    public class TreeDpoView<T> : NTreeView<T> where T : class, INTreeDpoNode
    {
        private List<T> list;
        private NTreeNode<T> mySelectedNode;
        
        private TreeNode root;
        private int rootID;

        public TreeDpoView()
        {
            this.Mode = TreeViewMode.Edit;
            this.ContextMenuStrip = new ContextMenuStrip();
            treeMenuContextMenu(this.ContextMenuStrip);

            this.AfterSelect += new TreeViewEventHandler(TreeView_AfterSelect);
            this.ItemDrag += new ItemDragEventHandler(TreeDpoView_ItemDrag);
            this.DragEnter += new DragEventHandler(TreeDpoView_DragEnter);
            this.DragDrop += new DragEventHandler(TreeDpoView_DragDrop);
            this.DragOver += new DragEventHandler(TreeDpoView_DragOver);

            this.MouseDown += delegate(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                    TreeNode node = this.GetNodeAt(e.X, e.Y);
                    if(node is NTreeNode<T>)
                        mySelectedNode = (NTreeNode<T>)node;
                };

            this.AfterLabelEdit += new NodeLabelEditEventHandler(TreeView_AfterLabelEdit);

        }

        public new IEnumerable<T> DataSource
        {
            get
            {
                return this.list;
            }
            set
            {
                if (value == null)
                    return;

                this.list = new List<T>();
                foreach(var item in value)
                    this.list.Add(item);
            }
        }

        public T SelectedDpo
        {
            get
            {
                if (this.SelectedDpoNode == null)
                    return null;

                return this.SelectedDpoNode.Item;
            }
        }


        public NTreeNode<T> SelectedDpoNode
        {
            get
            {
                if (this.SelectedNode == null)
                    return null;

                if (!(this.SelectedNode is NTreeNode<T>))
                    return null;

                return (NTreeNode<T>)this.SelectedNode;
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

        void TreeDpoView_DragDrop(object sender, DragEventArgs e)
        {
            NTreeNode<T> node1;

            if (e.Data.GetDataPresent(typeof(NTreeNode<T>).FullName, false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                NTreeNode<T> node2 = (NTreeNode<T>)((TreeView)sender).GetNodeAt(pt);

                node1 = (NTreeNode<T>)e.Data.GetData(typeof(NTreeNode<T>).FullName);
                if (node2.TreeView == node1.TreeView)
                {
                    MoveNodeAsChild(node1, node2);
                    node2.Expand();
                }
            }

        }

        void TreeDpoView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void TreeDpoView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        void TreeDpoView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }


        #endregion



        void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.Mode != TreeViewMode.Edit)
                return;

            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node == root)
                {
                    e.Node.Expand();
                    return;
                }

                NTreeNode<T> treeNode = (NTreeNode<T>)e.Node;
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
                        if (e.Node is NTreeNode<T>)
                        {
                            NTreeNode<T> dpoNode = (NTreeNode<T>)e.Node;
                            dpoNode.Item.NodeText = e.Node.Text;
                            //dpoNode.Text = d(dpoNode.Dpo);
                            dpoNode.Item.NodeSave();
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

        private T AddNode(NTreeNode<T> selectedNode, string nodeText)
        {
            return AddNode(selectedNode, selectedNode.Item.NodeId, nodeText);
        }


        private T AddNode(TreeNode selectedNode, int parentID, string nodeText)
        {
            T dpo = (T)Activator.CreateInstance(typeof(T));
            dpo.NodeText = nodeText;
            dpo.NodeParentId = parentID;
            if (selectedNode.Nodes.Count > 0)
            {
                NTreeNode<T> last = (NTreeNode<T>)selectedNode.Nodes[selectedNode.Nodes.Count - 1];
                dpo.NodeOrderBy = last.Item.NodeOrderBy + 1;
            }
            else
                dpo.NodeOrderBy = 0;

            dpo.NodeSave();
            list.Add(dpo);

            selectedNode.Nodes.Add(new NTreeNode<T>(dpo, toText));

            return dpo;
        }

        private bool MoveNodeAsChild(NTreeNode<T> from, NTreeNode<T> to)
        {
            if (from == to)
                return false;

            from.Item.NodeParentId = to.Item.NodeId;
            if (to.Nodes.Count > 0)
            {
                NTreeNode<T> last = (NTreeNode<T>)to.Nodes[to.Nodes.Count - 1];
                from.Item.NodeOrderBy = last.Item.NodeOrderBy + 1;
            }
            else
                from.Item.NodeOrderBy = 0;

            from.Remove(); //from.Parent.Nodes.Remove(from);
            to.Nodes.Add(from);

            
            from.AcceptChanges();
            from.Item.NodeSave();
            return true;
        }


        private bool MoveNodeAsSibling(NTreeNode<T> from, NTreeNode<T> to)
        {
            if (from == to)
                return false;

            if (from.Parent == to.Parent)
            {
                TreeNodeCollection nodes = from.Parent.Nodes;
                int index = nodes.IndexOf(to);
                from.Item.NodeOrderBy = to.Item.NodeOrderBy + 1;
                from.Remove();
                nodes.Insert(index, from);
            }

            from.AcceptChanges();
            from.Item.NodeSave();
            return true;
        }


        private void RemoveNode(NTreeNode<T> dpoNode)
        {
            dpoNode.Remove();
            list.Remove(SelectedDpo);
            dpoNode.Item.Delete();
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
                    string.Format("Item [{0}] {1} is about to be deleted, continue?", SelectedDpo.NodeId, SelectedDpo.NodeText),
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
            BuildTreeView((TreeNode)null, 0);
        }

      

        public void BuildTreeView(TreeNode root, int parentID)
        {
            this.root = root;
            this.rootID = parentID;

            TreeNodeCollection nodes;
            if (root == null)
                nodes = this.Nodes;
            else
                nodes = root.Nodes;

            nodes.Clear();
            BuildTreeView(nodes, parentID);
            this.ExpandAll();
        }


        private void BuildTreeView(TreeNodeCollection nodes, int parentID)
        {
            foreach(T dpo in list)
            {
                if (dpo.NodeParentId != parentID)
                    continue;

                dpo.NodeOrderBy = nodes.Count * 10;
                NTreeNode<T> treeNode2 = new NTreeNode<T>(dpo, base.toText);
                nodes.Add(treeNode2);

                if (treeNode2.Item.IconImage != null)
                    this.ImageList.Images.Add(treeNode2.Item.NodeId.ToString(), treeNode2.Item.IconImage);

                treeNode2.AcceptChanges();    //UPDATE dpc's DataTable

                BuildTreeView(treeNode2.Nodes, dpo.NodeId);
            }

        }


    
        
        #endregion


        public NTreeNode<T> SearchTreeNode(int ID)
        {
            return SearchTreeNode(ID, myNodes);
        }

        private NTreeNode<T> SearchTreeNode(int ID, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node is NTreeNode<T>)
                {
                    NTreeNode<T> n = (NTreeNode<T>)node;
                    if(n.Item.NodeId == ID)
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
                if (node is NTreeNode<T>)
                {
                    NTreeNode<T> n = (NTreeNode<T>)node;
                    n.Item.NodeSave();
                    SaveOrderBy(n.Nodes);
                }
            }
        }
    }
}
