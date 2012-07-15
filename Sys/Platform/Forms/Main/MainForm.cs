using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Sys.ViewManager.Forms;
using Sys.Workflow.Collaborative.Forms;
using Sys.Security;
using Sys.OS;
using Sys.ViewManager.Security;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars.Docking;
using Sys.ViewManager.Manager;
using System.Reflection;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace Sys.Platform.Forms
{

    public partial class MainForm : XtraForm, IMainForm
    {
        private MenuConsumer menuConsumer;
        private WindowManager windowManager;
        private FormDockManager formDockManager;

        #region IMainForm

        private Form activeForm = null;

        public Form Form
        { 
            get { return this; } 
        }

        public Bar ToolStrip
        { 
            get { return barTools; } 
        }

        public Bar StatusStrip
        { 
            get { return barStatus; } 
        }

        public FormDockManager FormDockManager
        {
            get { return this.formDockManager; }
        }

        public IReport Report
        { 
            get { return null ; } 
        }

        
        public void ShowForm(BaseForm form, FormPlace place)
        {
            activeForm = form;
            switch (place)
            {
                case FormPlace.TabbedAera:
                    windowManager.AddWindow(form);
                    formDockManager.OpenTabbedForm(form);
                    break;

                case FormPlace.WindowForm:
                    windowManager.AddWindow(form);
                    form.Show(this);
                    break;

                case FormPlace.Floating :
                    windowManager.AddWindow(form);
                    form.Show(this);

                    //formManager.OpenFloatingForm(form);
                    break;
     
                default:
                    throw new ApplicationException("cannot open a form in the docking panel."); 
            }

            return;

        }

        public ContainerControl Show(Control control, FormPlace formPlace)
        {
            if (control is Form)
                activeForm = (Form)control;
            else
                activeForm = null;

            switch (formPlace)
            { 
                case FormPlace.WindowForm:
                    if (control is Form)
                        ((Form)control).Show(this);

                    else
                    {
                        Form form = new Form();
                        form.Controls.Add(control);
                        control.Dock = DockStyle.Fill;
                        form.ShowInTaskbar = false;
                        form.Show(this);
                        return form;
                    }
                    break;

                case FormPlace.TabbedAera:
                    if (control is Form)
                        formDockManager.OpenTabbedForm((Form)control);
                    else
                    {
                        BaseForm form = new BaseForm(control.Name); //control.Name is instanceId
                        form.Text = control.Text;
                        form.Controls.Add(control);
                        control.Dock = DockStyle.Fill;
                        form.ShowInTaskbar = false;
                        formDockManager.OpenTabbedForm(form);
                        return form;
                    }
                    break;

                default:
                    return formDockManager.AddPanel(control.Text, control, (DockingStyle)formPlace);
        
            }

            return (Form)control;
            
        }


     
        public void CloseForm(BaseForm form)
        {
            if (form.Owner == this || form.FormPlace == FormPlace.TabbedAera)
                formDockManager.CloseTabbedForm(form);
            
            if (form.ParentControl == null)
                return;

            else if (form.ParentControl is DockPanel)
            {
                formDockManager.DockManager.RemovePanel(form.ParentControl as DockPanel);
            }
        }

        public void ChangeCaption(BaseForm form)
        {
                form.Text = form.Text;
        }
    
        public void BringFormToFront(BaseForm form)
        {
            form.BringToFront();
        }


        #endregion




        public MainForm()
        {

            Splash.ShowSplash();
            SysInformation.Start(Account.CurrentUser);  //Insert Activity Logs for Server

            InitializeComponent();

            this.Icon = SysInformation.Icon;
            this.repositoryItemMarqueeProgressBar1.Stopped = true;
            this.Visible = false;
            this.Text = SysInformation.ApplicatioName + " Unreleased Version";
            string version = App.ApplicationVersion();
            if (version != "0.0.0.0")
                this.Text = string.Format("{0} - v{1}", SysInformation.ApplicatioName, version);

            if (!Constant.SINGLE_USER_SYSTEM)
            {
                this.Text += string.Format(" : {0}({1}) @{2} of {3}", 
                    Account.CurrentUser.Name, 
                    Account.CurrentUser.UserName, 
                    SystemInformation.ComputerName, 
                    SysInformation.CompanyName);
            }

            App.AddShortcutToDesktop();
     
#if !DEBUG
            // Only want to start this if we are in release mode.
            //  Otherwise when we are debugging may end up in a infinite loop.
            timerCheckForUpdates.Start();
#endif         
            this.formDockManager = new FormDockManager(this, this.components);
            this.formDockManager.DockManager.MenuManager = barManager1;
            this.menuConsumer = new MenuConsumer(this, this.formDockManager, this.barManager1, this.barMainMenu);
            this.formDockManager.DockManager.Images = menuConsumer.ImageList;

            //build main menu
            this.menuConsumer.Build();
            this.windowManager = new WindowManager(this.menuConsumer);
            BuildHelpMenu();




            #region NavBar 

            
            //somebody may not have permission to access these Dock Panles below:
            menuConsumer.AddDockPanel("Shortcuts");
            DockPanel dpSO = menuConsumer.AddDockPanel("Sales Order");
            DockPanel dpWF = menuConsumer.AddDockPanel("Work List");
            formDockManager.HidePanel(dpSO, dpWF);
            
            DockPanel messagePanel = menuConsumer.AddDockPanel("Error List");
            DockPanel outputPanel = menuConsumer.AddDockPanel("Output");

            //formDockManager.HidePanel(messagePanel, outputPanel);
            formDockManager.DockManager.ActivePanel = messagePanel;

            if (Sys.Constant.USE_XMPP)
            {
                DockPanel dpMessenger = menuConsumer.AddDockPanel("Messenger");

                if (SystemInformation.PrimaryMonitorSize.Width < 1440)
                    formDockManager.HidePanel(dpMessenger);

                dpMessenger.Size = new Size(260, 600);
            }

            #endregion

            ShowForm(new HomeForm(this), FormPlace.TabbedAera);

            //formDockManager.RestoreLayout();
            Splash.RemoveSplash();
        }


      

        private void BuildHelpMenu()
        {
            BarSubItem menuHelp = menuConsumer.AddBarSubItem("&Help");
            
            BarButtonItem menu;
            menu = menuConsumer.AddWebLink(menuHelp, "Report a Bug", (string)Configuration.Instance["URL.ReportIssue"]);
            menu.Glyph = global::Sys.Platform.Properties.Resources.bug;

            menu = menuConsumer.AddBarButtonItem(menuHelp, "Check for Updates");
            menu.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                if (App.IsNewerVersionAvailable() != null)
                    timerCheckForUpdates_Tick(sender, e);
                else
                    MessageBox.Show("You already have the latest version installed.", "Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            menuConsumer.AddWebLink(menuHelp, "Release Notes", (string)Configuration.Instance["URL.ReleaseNotes"]);
            menu.Glyph = global::Sys.Platform.Properties.Resources.page_edit;

            menu = menuConsumer.AddBarButtonItem(menuHelp, "About...");
            menu.ItemClick += delegate(object sender1, ItemClickEventArgs e1)
            {
                AboutBox about = new AboutBox();
                Point p = new Point((this.ClientSize.Width - about.Size.Width) / 2, (this.ClientSize.Height - about.Size.Height) / 2);
                about.Location = p;
                about.ShowDialog(this);
            };
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
           
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDockManager.SaveLayout();
            
            ShortcutControl shortcutControl = (ShortcutControl)formDockManager[typeof(ShortcutControl)];
            if(shortcutControl != null)
                shortcutControl.Save();

            if (this.DialogResult != DialogResult.Abort && this.DialogResult != DialogResult.Retry) //click [X] to close window
                this.DialogResult = DialogResult.Abort;
        }

      
        public void Exit()
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        public void LogOff()
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }
    

        private void timerCheckForUpdates_Tick(object sender, EventArgs e)
        {
            string version = App.IsNewerVersionAvailable();
            if (version != null)
            {
   
                Image img = global::Sys.Platform.Properties.Resources.WarningHS;
                string caption = string.Format("<b><u>{0} UPDATE</u></b>", SysInformation.ApplicatioName);
                string text = string.Format("There is a new version {1} of {0} available. Download by clicking <u><b><color=Blue>here</color></b></u> or by restarting {0}. Reporting problems on old versions of {0} will delay software development time.", 
                    SysInformation.ApplicatioName, 
                    version);
                
                AlertNewVersion.Show(this, caption, text, text, img);
            }
        }

        private void toolStripButtonHome_Click(object sender, EventArgs e)
        {
            foreach (DockPanel panel in formDockManager.DockManager.RootPanels)
                panel.Show();

            ShowForm(new HomeForm(this), FormPlace.TabbedAera); 
        }


        private void AlertNewVersion_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            App.RestartApplication();
        }

        private void AlertNewVersion_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Size = new Size(250, 150);
        }

        private void btnAddFavorite_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (activeForm is BaseForm)
            {
                if (BaseForm.AddShortCut((BaseForm)activeForm))
                {
                    BarStaticItem label = (BarStaticItem)(barTools.LinksPersistInfo[1].Item);
                    label.Caption = "shortcut is added";
                }
            }
        }

    }



}
