using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Sys;

namespace Sys.Platform.Forms
{
    public partial class Splash : Form
    {
        
        public Splash()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

            InitializeComponent();
            this.BackgroundImage = Sys.SysInformation.Logo;


        }

      
        private void SetProgress(int value)
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.Invoke(new Action<int>(SetProgress), new object[] { value });
            }
            else
            {
                if (value > this.progressBar1.Maximum)
                    this.progressBar1.Maximum = value + 20;

                this.progressBar1.Value = value;
            }
        }


       


        private static Splash splash;
        private static bool shouldClose;

        private static void ThreadFunc()
        {
            int i = 10;
            splash = new Splash();
            splash.Show();
            while (!shouldClose)
            {
                Application.DoEvents();
                Thread.Sleep(100);
                splash.SetProgress(i);
                i += 5;
          }
            for (int n = 0; n < 18; n++)
            {
                Application.DoEvents();
                Thread.Sleep(60);
            }
            if (splash != null)
            {
                splash.Close();
                splash = null;
            }
        }

        internal static void ShowSplash()
        {
            shouldClose = false;
            Thread t = new Thread(ThreadFunc);
            t.Priority = ThreadPriority.Lowest;
            t.Start();
        }

        internal static void RemoveSplash()
        {
            shouldClose = true;
        }

   
    }
}
