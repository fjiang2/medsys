using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace Sys.ViewManager.Forms
{
    public static class FormExtension
    {

        /// <summary>
        /// T2 must have constructor: public T2(T1 item)
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="tree"></param>
        /// <param name="root"></param>
        public static void BuildTree<T1, T2>(this Tree<T1> tree, TreeNode root)
            where T1 : class
            where T2 : TreeNode
        {
            foreach (TreeNode<T1> n1 in tree.Nodes)
            {
                TreeNode n2 = (TreeNode)Activator.CreateInstance(typeof(T2), new object[] { n1.Item });
                root.Nodes.Add(n2);
                BuildTree<T1, T2>(n1, n2);
            }
        }

        private static void BuildTree<T1, T2>(TreeNode<T1> node1, TreeNode node2)
            where T1 : class
            where T2 : TreeNode
        {
            foreach (TreeNode<T1> n1 in node1.Nodes)
            {
                TreeNode n2 = (TreeNode)Activator.CreateInstance(typeof(T2), new object[] { n1.Item });
                node2.Nodes.Add(n2);
                BuildTree<T1, T2>(n1, n2);
            }
        }


        public static Icon CreateIcon16X16(this Image image)
        {
            if (image == null) 
                return null;

            using (System.Drawing.Bitmap newIcon = new System.Drawing.Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newIcon))
                {
                    g.DrawImageUnscaled(image, 0, 0, 16, 16);
                    return System.Drawing.Icon.FromHandle(newIcon.GetHicon());
                }
            }
        }

        public static Icon CreateIcon16X16(this Icon icon)
        {
            if (icon == null) 
                return null;

            Image image = icon.ToBitmap();
            return CreateIcon16X16(image);
        }
    }
}
