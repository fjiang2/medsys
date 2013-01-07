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
    public interface INTreeNode : ITreeDpoNode
    {
        Image IconImage { get; }
        string Expression { get; }
    }

    public class NTreeView : TreeView
    {
        ImageList imageList = new ImageList();
        NTree<INTreeNode> tree;

        public NTreeView(IEnumerable<INTreeNode<INTreeNode>> collection, int parentID)
        {

            tree = new NTree<INTreeNode>(collection, 0);

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
                NTreeNode treeNode = new NTreeNode(node.Item);
                this.Nodes.Add(treeNode);
                BuildTree(treeNode, node.Nodes);
            }

            this.AfterSelect += new TreeViewEventHandler(MainMenu_AfterSelect);
        }

        public NTree<INTreeNode> Tree
        {
            get { return this.tree; }
        }

      
        void MainMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                NTreeNode node = (NTreeNode)(e.Node);
                INTreeNode item = node.Item;
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

                    Cursor = Cursors.Default;
                }
                else
                {
                    e.Node.Expand();
                    return;
                }
            }
        }

        private void BuildTree(NTreeNode root, TreeNodeCollection<INTreeNode> nodes)
        {
            foreach (var node in nodes)
            {
                NTreeNode treeNode = new NTreeNode(node.Item);
                root.Nodes.Add(treeNode);
                BuildTree(treeNode, node.Nodes);
            }
        }

    }


    public class NTreeNode : TreeNode
    {
        INTreeNode item;

        public NTreeNode(INTreeNode item)
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

        public INTreeNode Item
        {
            get { return this.item; }
        }
    }
}
