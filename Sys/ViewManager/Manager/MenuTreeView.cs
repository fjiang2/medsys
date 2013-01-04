using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Sys;
using Sys.ViewManager;
using Sys.ViewManager.Forms;
using Sys.Data;
using Sys.ViewManager.DpoClass;
using Sys.ViewManager.Security;

namespace Sys.ViewManager.Manager
{
    public class MenuTreeView : TreeView
    {
        ImageList imageList = new ImageList();
        NTree<UserMenuItem> tree;

        public MenuTreeView()
        {
            var list = new TableReader<UserMenuItem>().ToList().Where(dpo => dpo.Released).OrderBy(dpo => dpo.OrderBy);

            tree = new NTree<UserMenuItem>(list, 0);

            foreach (var dpo in list)
            {
                if(dpo.IconImage != null)
                    imageList.Images.Add(dpo.ID.ToString(), dpo.IconImage);
            }

            //TreeNode selected image
            imageList.Images.Add(TreeRowNode.TREE_ROW_NODE_SELECTED_IMAGE, global::Sys.ViewManager.Properties.Resources.BreakpointHS);

            this.ImageList = imageList;
            this.Nodes.Clear();
            foreach (var node in tree.Nodes)
            {
                MenuTreeNode treeNode = new MenuTreeNode(node.Item);
                this.Nodes.Add(treeNode);
                BuildTree(treeNode, node.Nodes);
            }

            this.AfterSelect += new TreeViewEventHandler(MainMenu_AfterSelect);
        }

        public NTree<UserMenuItem> Tree
        {
            get { return this.tree; }
        }

        public UserMenuItem GetMenuItem(int menuId)
        {
            var node = tree.Collection.Where(menuItem => menuItem.NodeId == menuId).FirstOrDefault();

            if (node != null)
            {
                return node.NodeItem;
            }
            else
                return null;
        }

        void MainMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                UserMenuItem item = (e.Node as MenuTreeNode).Item;
                string code = item.Command;
                if (code != "")
                {
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        string scope = "MenuItem";
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

        private void BuildTree(MenuTreeNode root, TreeNodeCollection<UserMenuItem> nodes)
        {
            foreach (var node in nodes)
            {
                MenuTreeNode treeNode = new MenuTreeNode(node.Item);
                root.Nodes.Add(treeNode);
                BuildTree(treeNode, node.Nodes);
            }
        }

    }


    public class MenuTreeNode : TreeNode
    {
        UserMenuItem item;

        public MenuTreeNode(UserMenuItem item)
            : base(item.NodeText)
        {
            this.item = item;
            if (item.IconImage != null)
            {
                this.ImageKey = item.ID.ToString();
            }
            
            this.SelectedImageKey = item.NodeSelectedImageKey;
            this.Checked = item.NodeChecked;
        }

        public UserMenuItem Item
        {
            get { return this.item; }
        }
    }
}
