using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Data;
using System.Windows.Forms;
using Sys.ViewManager;

namespace Sys.ViewManager.Utils
{
    public static class Function
    {
        public static void WaitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        public static void DefaultCursor()
        {
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Create a solid color block
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image ColorBox(Color color, int width, int height)
        {
            Bitmap bitMap = new Bitmap(width, height);

            for (int x = 0; x < bitMap.Width; x++)
            {
                for (int y = 0; y < bitMap.Height; y++)
                {
                    Color pixelColor = bitMap.GetPixel(x, y);
                    bitMap.SetPixel(x, y, color);
                }
            }

            return bitMap;
        }

     

     
        public static object GetResourceObject(string dllName, string name)
        {
            return GetResourceObject(dllName, dllName, name);
        }

        public static object GetResourceObject(string baseName, string dllName, string name)
        {
            System.Globalization.CultureInfo resourceCulture = new System.Globalization.CultureInfo("en-US");
            Assembly assembly = Assembly.Load(dllName);
            System.Resources.ResourceManager manager = new System.Resources.ResourceManager(baseName + ".Properties.Resources", assembly);
            object obj = manager.GetObject(name, resourceCulture);
            return obj;
        }

    

        public static Form Popup(IWin32Window owner, Control control, string caption, Size size)
        { 
            return Popup(owner, control, caption, size, new Point(-1,-1));
        }

        public static Form Popup(IWin32Window owner, Control control, string caption, Size size, Point location)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form f = new Form();
            if (location.X != -1 && location.Y != -1)
            {
                f.Location = location;
            }

            f.Text = caption;
            control.Dock = DockStyle.Fill;
            f.Controls.Add(control);
            f.Size = size;
            f.ShowInTaskbar = false;
            f.Show(owner);
            Cursor.Current = Cursors.Default;
            return f;
        }



    }
}
