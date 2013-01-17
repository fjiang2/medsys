#define UsingForm
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using Sys.Security;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Drawing;
using Tie;
using Sys.Xmpp;
using Sys.BusinessRules;
using Sys.Data.Manager;
using Sys.ViewManager.Manager;
using Sys.ViewManager.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors.Repository;

namespace Sys.ViewManager.Forms
{
    /// <summary>
    /// base form for security/log
    /// F1: Help
    /// F2: Edit Help HTML
    /// </summary>
    public class BaseForm : XmppForm, IMaintenanceForm, IRuleDefinition
    {
        private IContainer components;

        protected Account account = Account.CurrentUser;
        protected bool allAccess = false;
   
  

        #region Constructors

        public BaseForm()
            :this(null)
        {           
        }

        /// <summary>
        /// Uniquely identify an instance of this class
        /// </summary>
        /// <param name="instanceId"></param>
        /// 
        public BaseForm(string instanceID)
            : this(instanceID, null)
        {
        }

        /// <summary>
        /// identify an instance of this class, and which instances share the same appearance setting
        /// </summary>
        /// <param name="instanceId">Uniquely identify an instance of this class</param>
        /// <param name="appearanceId">Form appearance</param>
        public BaseForm(string instanceId, string appearanceId)
        {
            this.instanceId = instanceId;       //allow to open this form multiple instances in the tab
            this.appearanceId = appearanceId;   //memorize the Form appearance such as Location, Size, ....
    
            InitializeComponent();
            
            this.Name = GetType().Name;
            this.ShowInTaskbar = false;


            WinFormEngine engine = new WinFormEngine(this, this.toolTip1, this.errorProvider1);
            validateProvider = engine.ValidatorProvider;

            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.Icon = SysInformation.Icon;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(BaseWinForm_KeyDown);
        }

    
        
        #endregion



        #region MainForm

        private ContainerControl owner = null;


        public ContainerControl ParentControl
        {
            get { return owner; }
            set { owner = value; }
        }

 
         
        private static Form GetMdiContainer(Control Container)
        {
            if (Container.Parent == null)
                return (Form)Container;
            
            while (Container != null)
            {
                if (Container is Form && ((Form)Container).IsMdiContainer)
                    return (Form)Container;
                else
                    Container = Container.Parent;
            }

            return null;
        }


        internal static IMainForm Mainform = null;
        private IMainForm MainForm
        {
            get
            {
                IMainForm mainForm = GetMainForm(this.owner);
                if (mainForm != null)
                    return GetMainForm(this.owner);
                else if (Mainform != null)
                    return Mainform;
                else
                    throw new Exception("MainForm is not instantiated before using");
                    
            }

        }

 

        private static IMainForm GetMainForm(Control Container)
        {
            while (Container != null)
            {
                if (Container is IMainForm)
                    return (IMainForm)Container;
                else if (Container is BaseForm)
                    Container = (Container as BaseForm).owner;
                else
                    Container = Container.Parent;
            }

            return null;
        }


        #endregion


        
        #region Form Load/Close

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = this.GetType().Name;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        private void BaseForm_Load(object sender, EventArgs e)
        {


            /// Get the Handle for the Forms System Menu
            IntPtr systemMenuHandle = GetSystemMenu(this.Handle, false);

            /// Create our new System Menu items just before the Close menu item
            InsertMenu(systemMenuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty); // <-- Add a menu seperator
            InsertMenu(systemMenuHandle, 6, MF_BYPOSITION, _AddShortCutSysMenuID, "Add Shortcut");
            InsertMenu(systemMenuHandle, 7, MF_BYPOSITION, _HelpSysMenuID, "Help...");

            //if (account.IsDeveloper)
            //    InsertMenu(systemMenuHandle, 8, MF_BYPOSITION, _BusinessRuleEditorSysMenuID, "Rule Editor...");


            InitAppearance();


        }

        private string appearanceId;
        public string AppearanceId
        {
            get
            {
                if (appearanceId == null)
                    return this.GetType().FullName;
                else
                {
                    string id = this.GetType().FullName + appearanceId;
                    return id.Replace(" ", "_").Replace("-", "_");
                }
            }
        }


        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Closed();

            VAL p = new VAL();
            Appearance(p, true);

            string sent = string.Format("WinForm.{0}={1};", this.AppearanceId, p);
            Script.Execute(sent, Profile.Instance.Memory);

            //Close log transaction if somebody forgets closing it
            this.EndLog();
        }

        private void InitAppearance()
        {
            try
            {

                VAL p = Script.Evaluate(string.Format("WinForm.{0}", this.AppearanceId), Profile.Instance.Memory);
                if (p.IsNull)
                    return;

                Appearance(p, false);
            }
            catch (Exception)
            {

            }

        }


        /// <summary>
        /// keep win form size,location,... into user's profile
        /// </summary>
        /// <param name="val">setting</param>
        /// <param name="saved">true: saving setting; false: loading setting</param>
        protected virtual void Appearance(VAL val, bool saved)
        {
            if (saved)
            {
                val["Location"] = new VAL();
                val["Size"] = new VAL();
                val["Location"]["X"] = new VAL(this.Location.X);
                val["Location"]["Y"] = new VAL(this.Location.Y);
                val["Size"]["Width"] = new VAL(this.Size.Width);
                val["Size"]["Height"] = new VAL(this.Size.Height);
                //     val["WindowState"] = new VAL((int)this.WindowState);
            }
            else
            {
              

                System.Drawing.Rectangle box = SystemInformation.VirtualScreen;

                int x = val["Location"]["X"].Intcon;
                if (x < 0) x = 0;
                if (x > box.Width)
                    x = box.Width - 50;

                int y = val["Location"]["Y"].Intcon;
                if (y < 0) y = 0;
                if (y > box.Height)
                    y = box.Height - 50;

                this.Location = new System.Drawing.Point(x, y);

                int w = val["Size"]["Width"].Intcon;
                if (w < 0) w = 320;

                int h = val["Size"]["Height"].Intcon;
                if (h < 0) h = 240;

                if (this.FormBorderStyle == FormBorderStyle.Sizable)
                    this.Size = new System.Drawing.Size(w, h);

                //if (val["WindowState"].Defined)
                //{
                //    FormWindowState windowState = (FormWindowState)val["WindowState"].Intcon;

                //    if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.Sizable) //tabbed windows don't restore state of Maximized/Minimized
                //        this.WindowState = windowState;
                //}
            }
        }


        protected virtual void Form_Init()
        {

        }

        protected virtual void Form_Closed()
        {

        }

       public void ChangeCaption(string caption)
       {
           this.Text = caption;

           if (MainForm != null)
               MainForm.ChangeCaption(this);
       }

       public void BringFormToFront()
       {
           IMainForm mainForm = GetMainForm(owner);
           if (mainForm != null)
           {
               mainForm.BringFormToFront(this);
           }
           else
               this.BringToFront();
       }

       public new void Close()
       {
           IMainForm mainForm = GetMainForm(owner);
           if (mainForm != null)
           {
               mainForm.CloseForm(this);

               if (!this.IsDisposed)
                   base.Close();
           }
           else
           {
               base.Close();
           }
       }

       private void BaseWinForm_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.F1)
           {
               ShowHelpForm();
               e.Handled = true;
           }
           else if (e.KeyCode == Keys.F2)
           {
               EditHelpForm();
               e.Handled = true;
           }
       }

       #endregion



       #region PopUp functions

        private FormPlace formPlace = FormPlace.WindowForm;
        public FormPlace FormPlace { get { return this.formPlace; } }

  

        public virtual DialogResult PopUp()
        {
            return PopUp(MainForm.Form);
        }
        public virtual DialogResult PopUp(ContainerControl owner)
        {
            return PopUp(owner, FormPlace.Auto);
        }

        public virtual DialogResult PopUp(ContainerControl owner, FormPlace place)
        {
            if (owner != this)
                this.owner = owner;
            else
                this.owner = (owner as BaseForm).owner;

            if (place == FormPlace.Auto)
            {
                if (this.FormBorderStyle == FormBorderStyle.Sizable) // || this.instanceId != null)
                    place = FormPlace.TabbedAera;
                else
                    place = FormPlace.WindowForm;
            }


            Security.FormConsumer setting = new Security.FormConsumer(this.GetType().FullName);
            if (setting.CanOpenForm || this.allAccess)
            {
				this.Cursor = Cursors.WaitCursor;

                IMainForm mainForm = GetMainForm(owner);
                
                Form_Init();
                this.RuleDefinition(this.validateProvider); 

                AddShortCut(false);

                if (mainForm != null)
                {
                    if(!this.allAccess && !account.IsDeveloper)
                        setting.SetFieldSecurity(this);
                    
                    this.formPlace = place;
                    mainForm.ShowForm(this, place);
                }
                else
                    ShowFormImpl(this.owner);

                this.Cursor = Cursors.Default;
            }
            else
            {

                this.ErrorMessage = "You are not allowed to open the form you clicked.";

                //Sys.ViewManager.Security.Forms.AuthorizeForm x = new Sys.ViewManager.Security.Forms.AuthorizeForm(this.GetType().FullName);
                //DialogResult dialogResult = x.ShowDialog(this.Parent);
                //switch (dialogResult)
                //{
                //    case DialogResult.OK:
                //        SendMailForm email = new SendMailForm();
                //        MailKeyWord keyword = new MailKeyWord();
                //        keyword.Parse(1, email, this.Name);
                //        email.ShowDialog(this.Parent);
                //        break;

                //}
            }

            return DialogResult.OK;

        }


        public DialogResult PopDialog(ContainerControl owner)
        {
            if (owner != this)
                this.owner = owner;
            else
                this.owner = (owner as BaseForm).owner;

            Security.FormConsumer setting = new Security.FormConsumer(this.GetType().FullName);
            if (setting.CanOpenForm || this.allAccess)
            {
                Form_Init();

                this.RuleDefinition(this.validateProvider);
                if (!this.allAccess && !account.IsDeveloper)
                    setting.SetFieldSecurity(this);

                return ShowDialogImpl(owner);
            }
            else
            {
                this.ErrorMessage = "You are not allowed to open the form you clicked.";
            }

            return DialogResult.Abort;
        }

        
        /// <summary>
        /// It can be implemented in other platform
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public virtual DialogResult ShowDialogImpl(IWin32Window owner)
        {
            if (owner != null)
                return this.ShowDialog(owner);
            else
                return this.ShowDialog();
        }


        /// <summary>
        /// It can be implemented in other platform
        /// </summary>
        public virtual void ShowFormImpl(IWin32Window owner)
        {
            if (owner != null)
                this.Show(owner);
            else
                this.Show();
        }

       #endregion


        public virtual object MaintenanceEntry
        {
            set { }
        }

        protected virtual string Serialization
        {
            get { return null; }
            set { }
        }

        public virtual bool DataOpen() { return true; }
        public virtual bool DataSave() { return true; }
        public virtual bool DataLoad() { return true; }
        public virtual bool DataDelete() { return true; }
        public virtual bool DataClear() { return true; }
        public virtual bool DataPrint() { return true; }
        public virtual bool DataHistory() { return true; }
        public virtual bool DataCancel() { return true; }



     

        #region StatusStrip Function

        private Bar MainStatusStrip
        {
            get
            {
                IMainForm mainForm = GetMainForm(this.owner);
                if (mainForm != null)
                    return mainForm.StatusStrip;
                else
                    return null;
            }
        }


        protected bool SetStatusBarText(Color foreColor, string description, int index)
        {
            if (MainStatusStrip != null)
            {
                BarItem host = MainStatusStrip.LinksPersistInfo[index].Item;
                BarStaticItem label = (BarStaticItem)host;
                label.Caption = description;
                label.ItemAppearance.Normal.ForeColor = foreColor;
            }

            return MainStatusStrip != null;
        }

        private BarEditItem ProgressBarItem
        {
            get
            {
                if (MainStatusStrip == null)
                    return null;

                BarItem item = MainStatusStrip.LinksPersistInfo[0].Item;

                return (BarEditItem)item;
            }
        }


        protected void ShowProgressBar(string message)
        {
            RepositoryItemMarqueeProgressBar progressBar = (RepositoryItemMarqueeProgressBar)ProgressBarItem.Edit;
            ProgressBarItem.EditValue = message;
            progressBar.ShowTitle = true;
            progressBar.Stopped = false; 
        }

        protected void StopProgressBar()
        {
            RepositoryItemMarqueeProgressBar progressBar = (RepositoryItemMarqueeProgressBar)ProgressBarItem.Edit;
            ProgressBarItem.EditValue = "";
            progressBar.ShowTitle = false;
            progressBar.Stopped = true;
        }

        /// <summary>
        /// background worker
        /// </summary>
        private Progress progress;
        protected JBackgroundWorker StartProgressBar(Action<JBackgroundWorker> action)
        {
            this.progress = new Progress(this.ProgressBarItem);
            progress.Action = action;
            progress.Start();

            return progress.Worker;
        }
        

        

    #endregion


        
        #region Show Message

        //private ErrorListControl errorListControl
        //{
        //    get  { return (ErrorListControl)this.MainForm.FormDockManager[typeof(ErrorListControl)]; }
        //}

        //private OutputControl outputControl
        //{
        //    get { return (OutputControl)this.MainForm.FormDockManager[typeof(OutputControl)]; }
        //}

        protected MessageManager MessageManager
        {
            get
            {
                return MessageManager.Instance;
            }
        }


        protected string ErrorMessage
        {
            set
            {
                ShowMessage(Message.Error(value), MessagePlace.MessageBox|MessagePlace.StatusBar);
            }
        }


        protected string WarningMessage
        {
            set
            {
                ShowMessage(Message.Warning(value),  MessagePlace.MessageBox | MessagePlace.StatusBar);
            }
        }

        protected string InformationMessage
        {
            set
            {
                ShowMessage(Message.Information(value) , MessagePlace.StatusBar);
            }
        }

        protected void ShowMessageBox(Exception ex)
        {
            ShowMessageBox(Message.Error(ex.Message));
        }

        protected void ShowMessageBox(Message message)
        {
            ShowMessage(message, MessagePlace.MessageBox);
        }



        protected void ShowMessage(MessageBuilder messages, MessagePlace place)
        {
            this.MessageManager.ClearWindow(place);
            this.MessageManager.Add(messages);
            this.MessageManager.Commit(place);
        }

       

        protected void ShowMessage(Message message, MessagePlace place)
        { 
            if (message == null)
                return;


            string text = message.ToString();
            if ((place & MessagePlace.MessageBox) == MessagePlace.MessageBox)
            {
                MessageBoxIcon icon = MessageBoxIcon.None;
                switch (message.Level)
                {
                    case MessageLevel.Error:
                    case MessageLevel.Fatal:
                        icon = MessageBoxIcon.Error;
                        break;

                    case MessageLevel.Warning:
                        icon = MessageBoxIcon.Warning;
                        break;

                    case MessageLevel.Information:
                        icon = MessageBoxIcon.Information;
                        break;
                }

                MessageBox.Show(this, text, message.Level.ToString(), MessageBoxButtons.OK, icon);
            }

            if (MainStatusStrip != null)
            {
                if (((place & MessagePlace.StatusBar) == MessagePlace.StatusBar) || ((place & MessagePlace.StatusBar2) == MessagePlace.StatusBar2))
                {

                    int index;
                    if (((place & MessagePlace.StatusBar) == MessagePlace.StatusBar))
                        index = 1;
                    else
                        index = 2;

                    Color color = Color.Black;
                    switch (message.Level)
                    {

                        case MessageLevel.Error:
                        case MessageLevel.Fatal:
                            color = Color.Red;
                            break;

                        case MessageLevel.Warning:
                            color = Color.Brown;
                            break;

                        case MessageLevel.Information:
                            color = Color.Blue;
                            break;

                        default:
                            break;

                    }

                    SetStatusBarText(color, text, index);

                }
            }

            if ((place & MessagePlace.ErrorListWindow) == MessagePlace.ErrorListWindow || (place & MessagePlace.OutputWindow) == MessagePlace.OutputWindow)
            {
                this.MessageManager.Add(message);
            }
            
        }

     

        protected void ShowMessageOn(Control control, string message)
        {
            if (message != "" && message != null)
                this.validateProvider.DisplayMessageOn(control, message);
            else
                this.validateProvider.ClearMessageOn(control);
        }

        #endregion




        #region System Menu

        #region Win32 API Stuff

        // Define the Win32 API methods we are going to use
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);

        //[DllImport("user32.dll")]
        //static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        /// Define our Constants we will use
        public const Int32 WM_SYSCOMMAND = 0x112;
	
        public const Int32 MF_SEPARATOR = 0x800;
        public const Int32 MF_BYPOSITION = 0x400;
        //public const Int32 MF_STRING = 0x0;

        #endregion

        // The constants we'll use to identify our custom system menu items
        public const Int32 _AddShortCutSysMenuID = 1000;
        public const Int32 _HelpSysMenuID = 1001;
        public const Int32 _BusinessRuleEditorSysMenuID = 1002;


        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // Check if a System Command has been executed
            if (m.Msg == WM_SYSCOMMAND)
            {
                // Execute the appropriate code for the System Menu item that was clicked
                switch (m.WParam.ToInt32())
                {
                    case _AddShortCutSysMenuID:
                        AddShortCut(true);
                        break;
                    case _HelpSysMenuID:
                        ShowHelpForm();
                        break;

                    case _BusinessRuleEditorSysMenuID:
                        //FormRuleDpo r = new FormRuleDpo();
                        //r.FormClass = this.GetType().FullName;
                        //r.Load();
                        //r.Script = TieEditor.Show(this, "Business Rule Editor: " + r.FormClass, r.Script);
                        //if (r.Script != null)
                        //{
                        //    r.FormClass = this.GetType().FullName;
                        //    r.Released = true;
                        //    r.Save();
                        //    this.InformationMessage="Script is saved.";
                        //}
                        break;
                }
            }

            base.WndProc(ref m);
        }

        #endregion



        #region Shortcut/Help


        protected virtual ShortcutControl ShortcutManager
        {
            get
            {
                return (ShortcutControl)MainForm.FormDockManager[typeof(ShortcutControl)];
            }
        }
        


        /// <summary>
        /// used for Form Dock Manager, uniquely identify a BaseForm instance
        /// </summary>
        protected string instanceId = null;   
     
        /// <summary>
        /// Uniquely identify a Windows Form instance, used for FormDockMananger
        /// </summary>
        public string InstanceId
        {
            get
            {
                if (instanceId == null)
                    return this.GetType().FullName;
                else
                {
                    string id = this.GetType().FullName + instanceId;
                    return id.Replace(" ", "_").Replace("-", "_");
                }
            }
        }

        protected virtual void EditHelpForm()
        {
            Modules.FormClass dpo = new Modules.FormClass(this);
            if (!dpo.Exists)
                dpo.Label = this.Text;

            HtmlEditor editor = new HtmlEditor();
            editor.HtmlText = dpo.Help;
            if (account.IsAdmin)
                editor.Text = string.Format("Help Editor: {0} ({1})", dpo.Label, this.GetType().FullName);
            else
                editor.Text = string.Format("Help Editor: {0}", dpo.Label);

            if (editor.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                dpo.Form_Class = this.GetType().FullName;
                dpo.Help = editor.HtmlText;
                dpo.Save();
            }

        }

        protected virtual void ShowHelpForm()
        {
            Modules.FormClass dpo = new Modules.FormClass(this);
            if (!dpo.Exists)
                dpo.Label = this.Text;

            HelpForm helpForm = new HelpForm(dpo.Label, dpo.Help);
            if (account.IsAdmin)
                helpForm.Text += string.Format(" ({0})", this.GetType().FullName);

            helpForm.PopUp(this, FormPlace.Floating);
        }

        /// <summary>
        /// Define how to add shortcut
        /// </summary>
        /// <param name="pinned">true: favorite, false: recently used</param>
        /// <returns></returns>
        protected virtual bool AddShortCut(bool pinned)
        {
            //when shorcut panel is not shown up
            if (ShortcutManager == null)
                return false;

            Type type = this.GetType();


            /*
            //Used for OpenFormBySO
            if (type.GetConstructor(new Type[]{ typeof(string) }) != null)
            {
                if(instanceId != null)
                    return ShortcutManager.Add(pinned, this, new object[] { this.instanceId });
            }

            */

            if (type.GetConstructor(new Type[] { }) == null)
            {
                //this.WarningMessage = string.Format("This Form [{0}] does not have default constructor, you can't add it into shortcuts list. \nPlease call IT Help Desk.", type.FullName);
                return false;
            }

            if (ShortcutManager.Add(pinned, this))
            {
                //this.InformationMessage = "Shortcut is added.";
                ShortcutManager.Save();
            }
            return true;
        }


        public static bool AddShortCut(BaseForm form)
        {
            return form.AddShortCut(true);
        }


        protected Image iconImage;
        public Image IconImage
        {
            get
            {
                if (iconImage == null)
                {
                    if (this.Icon.Size.Height <= 16)
                        return this.Icon.ToBitmap();
                    else
                        try
                        {
                            return SysInformation.Icon.CreateIcon16X16().ToBitmap();
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                }

                return iconImage;
            }
            set { this.iconImage = value; }
        }


        #endregion



        #region Business Rules

        private ToolTip toolTip1;
        private ErrorProvider errorProvider1;

        /// <summary>
        /// validateProvider LINEARLY iterates all controls
        /// </summary>
        protected ValidateProvider validateProvider;

        internal ValidateProvider ValidateProvider
        {
            get
            {
                return this.validateProvider;
            }
        }

    

        /// <summary>
        /// Define Business Rule for this Windows Form, called before Form Popup()
        /// </summary>
        /// <param name="provider"></param>
        public virtual void RuleDefinition(ValidateProvider provider)
        {
            RuleDefinition(Controls, provider);
        }

        private void RuleDefinition(Control.ControlCollection Controls, ValidateProvider provider)
        {
            foreach (Control control in Controls)
            {
                if (control is BaseUserControl)
                {
                    BaseUserControl buc = (BaseUserControl)control;
                    
                    //ignore rule checking in ReadOnly Control
                    if(buc.WorkMode == WorkMode.Working)
                        buc.RuleDefinition(provider);
                }
                else if (control is TabControl)
                {
                    foreach (TabPage page in ((TabControl)control).TabPages)
                    {
                        RuleDefinition(page.Controls, provider);
                    }
                }
                else if (control is DevExpress.XtraTab.XtraTabControl)
                {
                    foreach (DevExpress.XtraTab.XtraTabPage page in ((DevExpress.XtraTab.XtraTabControl)control).TabPages)
                    {
                        RuleDefinition(page.Controls, provider);
                    }
                }
                else if (control is ScrollableControl)
                {
                    RuleDefinition(((ScrollableControl)control).Controls, provider);
                }

            }
        }


        /// <summary>
        /// Validate Rules
        /// </summary>
        /// <returns></returns>
        protected virtual bool RuleValidated()
        {
            bool result =  RuleValidated(false);

            this.ShowMessage(this.validateProvider.ToMessageList(), MessagePlace.ErrorListWindow);
            
            return result;
        }

        /// <summary>
        /// Display broken rules in the Grid
        /// </summary>
        /// <returns></returns>
        protected virtual bool RuleValidated(bool showSummary)
        {
            bool result = this.validateProvider.Validate();

            if (showSummary)
            {
                this.InformationMessage = "Please correct data fields with RED color before save.";
                Sys.ViewManager.Forms.JGridView grid = new Sys.ViewManager.Forms.JGridView();
                grid.DataSource = this.validateProvider.ToDataTable();
                grid.AllowEdit = false;
                Utils.Function.Popup(this, grid, "Broken Rules", new Size(800, 360), this.Location + new Size(200, 300));
            }
            return result;
        }

        #endregion



        #region DPO log transaction

        internal LogTransaction logTransaction = null;

       /// <summary>
       /// Begin Log Transaction, all DPOs in Form are logged as a Transaction
       /// </summary>
        protected LogTransaction BeginLog()
        {
            return this.logTransaction = LogTransaction.BeginTransaction(new TransactionType(this.GetType()));
        }

        protected LogTransaction BeginLog(TransactionLogeeType typeName, params ILogable[] logs)
        {
            this.logTransaction = LogTransaction.BeginTransaction(typeName, new TransactionType(this.GetType()));
            
            AddLog(logs);
            
            return this.logTransaction;
        }

        /// <summary>
        /// Begin log Transaction, and register DPO into Logger
        /// </summary>
        /// <param name="logs"></param>
        protected LogTransaction BeginLog(params ILogable[] logs)
        {
            BeginLog();
            AddLog(logs);

            return logTransaction;
        }

        protected void AddLog(params ILogable[] logs)
        {
            foreach (ILogable log in logs)
                this.logTransaction.Add(log);
        }

        protected void RemoveLog(ILogable log)
        {
            this.logTransaction.Remove(log);
        }

        /// <summary>
        /// Close log transaction, it can be closed many times
        /// </summary>
        protected void EndLog()
        {
            if (this.logTransaction == null)
                return;

            this.logTransaction.EndTransaction();
            this.logTransaction = null;
        }

        #endregion


        #region Reviewable

        WorkMode state = WorkMode.Working;
        public WorkMode WorkMode
        {
            get { return this.state; }
            set
            {
                if (state == value)
                    return;

                this.state = value;

                Editable(state);
            }

        }

        protected virtual void Editable(WorkMode state)
        {
            switch (state)
            {
                case WorkMode.Reading:
                case WorkMode.Reviewing:
                    EnableControls(this.Controls, false);
                    break;

                case WorkMode.Working:
                    EnableControls(this.Controls, true);
                    break;

            }

        }





        internal static void EnableControls(Control.ControlCollection Controls, bool enabled)
        {

            foreach (Control control in Controls)
            {
                if (control is Label)
                {
                }
                else if (control is TextBox)
                {
                    ((TextBox)control).ReadOnly = !enabled;
                }
                else if (control is RichTextBox)
                {
                    ((RichTextBox)control).ReadOnly = !enabled;
                }
                else if (control is DevExpress.XtraEditors.MemoExEdit)
                {
                    ((DevExpress.XtraEditors.MemoExEdit)control).Properties.ReadOnly = !enabled;
                }
                else if (control.GetType() == typeof(DevExpress.XtraEditors.TextEdit))  //DevExpress.XtraEditors.DateEdit is subclass of TextEdit
                {
                    ((DevExpress.XtraEditors.TextEdit)control).Properties.ReadOnly = !enabled;
                }
                else if (control is DevExpress.XtraGrid.GridControl)
                {
                    DevExpress.XtraGrid.GridControl c = (DevExpress.XtraGrid.GridControl)control;
                    if (c.MainView is DevExpress.XtraGrid.Views.Grid.GridView)
                    {
                        ((DevExpress.XtraGrid.Views.Grid.GridView)(c.MainView)).OptionsBehavior.Editable = enabled;
                    }
                }
                else if (control is TabControl)
                {
                    foreach (TabPage page in ((TabControl)control).TabPages)
                    {
                        EnableControls(page.Controls, enabled);
                    }
                }
                else if (control is DevExpress.XtraTab.XtraTabControl)
                {
                    foreach (DevExpress.XtraTab.XtraTabPage page in ((DevExpress.XtraTab.XtraTabControl)control).TabPages)
                    {
                        EnableControls(page.Controls, enabled);
                    }
                }
                else if (control is ToolStrip)
                {
                    foreach (ToolStripItem item in ((ToolStrip)control).Items)
                    {
                        if (item is ToolStripButton)
                            item.Enabled = enabled;
                    }
                }
                else if (control is BaseUserControl)
                {
                    ((BaseUserControl)control).WorkMode = WorkMode.Reading;
                }
                else if (control is ScrollableControl)
                {
                    EnableControls(((ScrollableControl)control).Controls, enabled);
                }
                else
                {
                    control.Enabled = enabled;
                }
            }
        }
        
        #endregion


        public static BaseForm Popup(ContainerControl owner, Control control, string caption, Size size, FormPlace formPlace)
        {
            Cursor.Current = Cursors.WaitCursor;
            BaseForm f = new BaseForm();
            f.Text = caption;
            control.Dock = DockStyle.Fill;
            f.Controls.Add(control);
            f.Size = size;
            f.ShowInTaskbar = false;
            IMainForm mainForm = BaseForm.GetMainForm(owner);
             mainForm.ShowForm(f, formPlace);
            Cursor.Current = Cursors.Default;
            return f;
        }

        protected bool DockPanelExists(Guid guid)
        {
            return this.MainForm.FormDockManager.FindPanel(guid) != null;
        }

        public DockPanel AddDockPanel(Guid guid, string caption, DockingStyle dockingStyle, Control control)
        {
            FormDockManager manager = this.MainForm.FormDockManager;
            DockPanel dockPanel = manager.FindPanel(guid);
            if (dockPanel == null)
            {
                dockPanel = manager.AddPanel(caption, control, dockingStyle);
                dockPanel.ID = guid;
            }
            else
            {
                dockPanel.Text = caption;
                dockPanel.Show();
            }

            manager.DockManager.ActivePanel = dockPanel;
            return dockPanel;
        }
      
    }
}
