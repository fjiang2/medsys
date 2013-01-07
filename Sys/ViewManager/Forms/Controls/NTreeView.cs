using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Sys;
using Sys.ViewManager;
using Sys.ViewManager.Forms;
using Sys.Data;
using Sys.ViewManager.DpoClass;
using Sys.ViewManager.Security;

namespace Sys.ViewManager.Forms
{

    public class NTreeView<T> : TreeView where T : class, INTreeDpoNode
    {
        ImageList imageList = new ImageList();
        NTree<T> tree;

        public NTreeView(IEnumerable<INTreeNode<T>> collection, int parentID)
        {

            tree = new NTree<T>(collection, 0);

            foreach (var node in collection)
            {
                if(node.NodeItem.IconImage != null)
                    imageList.Images.Add(node.NodeId.ToString(), node.NodeItem.IconImage);
            }

            //TreeNode selected image
            imageList.Images.Add(TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE, global::Sys.ViewManager.Properties.Resources.BreakpointHS);

            this.ImageList = imageList;
            this.Nodes.Clear();
            foreach (var node in tree.Nodes)
            {
                NTreeNode<T> treeNode = new NTreeNode<T>(node.Item);
                this.Nodes.Add(treeNode);
                BuildTree(treeNode, node.Nodes);
            }

            this.AfterSelect += new TreeViewEventHandler(MainMenu_AfterSelect);
        }

        public NTree<T> Tree
        {
            get { return this.tree; }
        }

      
        void MainMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                NTreeNode<T> node = (NTreeNode<T>)(e.Node);
                INTreeDpoNode item = node.Item;
                string code = item.Expression;
                if (code != "")
                {
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        string scope = "$NodeItem";
                        Tie.Memory DS = new Tie.Memory();
                        DS.AddHostObject(scope, item);
                        Tie.Script.Evaluate(scope, code, DS, null);
                    }
                    catch (Exception ex)
                    {
                        string message = string.Format("invalid code [{0}], {1}", code, ex.Message);
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    e.Node.Expand();
                    return;
                }
            }
        }

        private void BuildTree(NTreeNode<T> root, TreeNodeCollection<T> nodes)
        {
            foreach (var node in nodes)
            {
                NTreeNode<T> treeNode = new NTreeNode<T>(node.Item);
                root.Nodes.Add(treeNode);
                BuildTree(treeNode, node.Nodes);
            }
        }

    }


    public class NTreeNode<T> : TreeNode where T : class, INTreeDpoNode
    {
        T item;

        public NTreeNode(T item)
            : base(item.NodeText)
        {
            this.item = item;
            if (item.IconImage != null)
            {
                this.ImageKey = item.NodeId.ToString();
            }
            
            this.SelectedImageKey = item.NodeSelectedImageKey;
            this.Checked = item.NodeChecked;
        }

        public T Item
        {
            get { return this.item; }
        }
    }
}
