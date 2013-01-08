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
        Tie.Memory ds = new Tie.Memory();

        public NTreeView()
        {
            //in case of no icon in the NTreeNode
            imageList.Images.Add("Unknown", global::Sys.ViewManager.Properties.Resources.application);
            
            //TreeNode selected image
            imageList.Images.Add(TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE, global::Sys.ViewManager.Properties.Resources.BreakpointHS);

            this.ImageList = imageList;

            this.AfterSelect += new TreeViewEventHandler(NTreeView_AfterSelect);
        }

        public object DataSource
        {

            get { return this.tree;}

            set
            {
                if (value == null)
                    return;

                if (value is NTree<T>)
                {
                    this.tree = (NTree<T>)value;
                }
                else if (value is IEnumerable<INTreeNode<T>>)
                {
                    this.tree = new NTree<T>((IEnumerable<INTreeNode<T>>)value, 0);
                }

                foreach (var node in tree.Collection)
                {
                    if (node.NodeItem.IconImage != null)
                        imageList.Images.Add(node.NodeId.ToString(), node.NodeItem.IconImage);
                }

                this.Nodes.Clear();
                foreach (var node in tree.Nodes)
                {
                    NTreeNode<T> treeNode = new NTreeNode<T>(node.Item);
                    this.Nodes.Add(treeNode);
                    BuildTree(treeNode, node.Nodes);
                }
            }
        }

        public NTree<T> Tree
        {
            get { return this.tree; }
        }


        public Tie.Memory DS
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        private void NTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                NTreeNode<T> node = (NTreeNode<T>)(e.Node);
                INTreeDpoNode item = node.Item;
                string code = item.Expression;
                if (!string.IsNullOrEmpty(code))
                {
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        string scope = "$NodeItem";
                        DS.AddHostObject(scope, item);
                        Tie.Script.Execute(scope, code, ds, null);
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


 
}
