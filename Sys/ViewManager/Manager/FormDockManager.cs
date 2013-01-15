using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010.Views;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using Sys.ViewManager.Forms;
using Sys.ViewManager.Modules;
using System.Linq;

namespace Sys.ViewManager.Manager
{
    public class FormDockManager
    {
        private Form owner;

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;

        public FormDockManager(Form owner, IContainer components)
        {
            this.owner = owner;

            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(components);
            this.dockManager1.Controller = this.barAndDockingController1;
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(components);
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "VS2010";

            

            this.dockManager1.TopZIndexControls.AddRange(new string[] {
                "DevExpress.XtraBars.BarDockControl",
                "System.Windows.Forms.MenuStrip",
                "System.Windows.Forms.ToolStrip",
                "System.Windows.Forms.StatusStrip"
            });

            dockManager1.Form = owner;
            dockManager1.DockMode = DevExpress.XtraBars.Docking.Helpers.DockMode.VS2005;
            
            this.dockManager1.DockingOptions.ShowMaximizeButton = true;
            this.dockManager1.DockingOptions.ShowAutoHideButton = true;


            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);

            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            this.documentManager.BarAndDockingController = this.barAndDockingController1;
            this.documentManager.MdiParent = owner;
            //this.documentManager.MenuManager =  this.mainRibbon;
            this.documentManager.View = this.tabbedView;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView});

            tabbedView.DocumentAdded += tabbedView_DocumentAdded;
            tabbedView.DocumentRemoved += tabbedView_DocumentRemoved;
            tabbedView.FloatDocuments.CollectionChanged += tabbedView_FloatDocumentsCollectionChanged;
        }

        public DockManager DockManager
        {
            get
            {
                return this.dockManager1;
            }
        }

        public void HidePanel(params DockPanel[] dockPanels)
        {
            dockManager1.BeginUpdate();
            foreach (DockPanel dockPanel in dockPanels)
            {
                if (dockPanel == null)
                    continue;

                dockPanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                dockPanel.HideSliding();
            }

            dockManager1.EndUpdate();
        }


        public DockPanel FindPanel(Guid Id)
        {
            foreach (DockPanel dockPanel in dockManager1.Panels)
            {
                if (dockPanel.ID.Equals(Id))
                    return dockPanel;
            }

            return null;
        }

        public DockPanel AddPanel(string caption, Control control, DockingStyle dockingStyle)
        {
            DockPanel dockPanel = AddPanel(control, dockingStyle);

            if (!string.IsNullOrEmpty(caption))
                dockPanel.Text = caption;

            //Dock as tab
            foreach (DockPanel panel in dockManager1.RootPanels)
            {
                if (panel.Dock == dockingStyle)
                {
                    ///Usage: currentPanel.DockAsTab(targetPanel); currentPanel.DockAsTab(targetPanel, index); 
                    ///If targetPanel doesn't represent a tab container, a new tab container will be created and this will contain targetPanel and currentPanel. 
                    ///If targetPanel is a tab container, currentPanel will be appended to this container. 
                    dockPanel.DockAsTab(panel.RootPanel);
                    break;
                }
            }
            return dockPanel;
        }


        private int panelCount = 0;
        private int floatPanelCount = 0;
        private DockPanel AddPanel(Control control, DockingStyle dockingStyle)
        {
            DockPanel dockPanel = dockManager1.AddPanel(dockingStyle);

            dockPanel.Text = control.Text;
            dockPanel.Size = control.Size;
            dockPanel.FloatSize = control.Size;
            dockPanel.Name  = "dockPanel" + panelCount;
            //dockPanel.ID = new Guid(dockPanel.Name);

            control.Dock = DockStyle.Fill;

            if (dockPanel.Dock == DockingStyle.Float)
            {
                Point point = new System.Drawing.Point(4, 24);
                Size size = new System.Drawing.Size(339, 222);
                int width = floatPanelCount * 40;
                int height = 50 + (floatPanelCount * 22);

                if (width + control.Width > size.Width)
                    floatPanelCount = 0;

                if (height + control.Height > size.Height)
                    floatPanelCount = 0;

                point += new Size(width, height);
                dockPanel.FloatLocation = point;
                
                floatPanelCount++;
            }
            
           

            dockPanel.ControlContainer.Controls.Add(control);
            if (!this.controls.ContainsKey(control.GetType()))
                this.controls.Add(control.GetType(), control);
            else
            {
                this.invalidLayoutData = true;
                throw new Exception("invalid layout data, restart application to clear layout data in User Profile");
            }

            dockPanel.ControlContainer.Name = "controlContainer" + panelCount;
                 
            panelCount++;

            return dockPanel;
        }


        private Dictionary<Type, Control> controls = new Dictionary<Type, Control>();
        public Control this[Type type]
        {
            get
            {
                if (controls.ContainsKey(type))
                    return controls[type];
                else
                    return null;
            }
        }

        


        #region Tabbed Document

        IDictionary<object, BaseDocument> documentsCore = new Dictionary<object, BaseDocument>();
        public IDictionary<object, BaseDocument> Documents
        {
            get { return documentsCore; }
        }


        private Form activeForm = null;
        public Form ActiveForm { get { return this.activeForm; } }

        public void OpenTabbedForm(Form form)
        {
            BaseDocument document = null;

            activeForm = form;

            if (!Documents.TryGetValue(GetId(form), out document))
            {

                try
                {
                    form.Owner = owner;
                }
                catch (Exception)
                {
                }
                
                form.MdiParent = owner;     //Dock on tab
                if (form is BaseForm)
                    (form as BaseForm).ShowFormImpl(null);
                else
                    form.Show();
            }
            else
            {
                tabbedView.Controller.Activate(document);
                if (document.Control is Form)
                {
                    Form f = (Form)(document.Control);
                    if (f.WindowState == FormWindowState.Minimized)
                        f.WindowState = FormWindowState.Normal;
                }
            }
        }

        public void OpenFloatingForm(Form form)
        {
                //form.Owner = owner;
                form.MdiParent = owner;
                form.Show();
                //if (tabbedView.Documents.TryGetValue(album, out document))
                //{
                //    document.Caption = album.Text;
                //}
        }

        public void CloseTabbedForm(Form form)
        {
            BaseDocument document = null;

            if (Documents.TryGetValue(GetId(form), out document))
            {
                tabbedView.Controller.Close(document);
            }
        }

        void tabbedView_DocumentAdded(object sender, DocumentEventArgs e)
        {
            RegisterDocument(e.Document);
        }
        
        void tabbedView_DocumentRemoved(object sender, DocumentEventArgs e)
        {
            UnregisterDocument(e.Document);
        }

        void RegisterDocument(BaseDocument document)
        {
            BaseForm form = document.Form as BaseForm;
            
            Image image = null;
            if (form.IconImage != null)
                image = form.IconImage;
            else
            {
                FormClass formClass = new FormClass(form.GetType());
                if (formClass.Exists)
                    image = formClass.IconImage;
            }

            if (image != null)
            {
                tabbedView.BeginUpdate();
                document.Image = image;
                document.Form.Icon = image.CreateIcon16X16();
                tabbedView.EndUpdate();
            }

            if (form != null)
                Documents.Add(GetId(form), document);

        }

        void UnregisterDocument(BaseDocument document)
        {
            BaseForm form = document.Form as BaseForm;
            if (form != null)
                Documents.Remove(GetId(form));
        }


        void tabbedView_FloatDocumentsCollectionChanged(DevExpress.XtraBars.Docking2010.Base.CollectionChangedEventArgs<BaseDocument> ea)
        {
            if (ea.ChangedType == DevExpress.XtraBars.Docking2010.Base.CollectionChangedType.ElementAdded)
                RegisterDocument(ea.Element);

            if (ea.ChangedType == DevExpress.XtraBars.Docking2010.Base.CollectionChangedType.ElementRemoved)
                UnregisterDocument(ea.Element);
        }


        private static string GetId(Form form)
        {

            if (form is BaseForm)
                return  ((BaseForm)form).InstanceId;

            return form.GetType().FullName;
        }

        #endregion

        private bool invalidLayoutData = false;
        public void RestoreLayout()
        {
            if (Sys.Security.Profile.Instance.Configuration != null)
            {
                System.IO.MemoryStream stream = null;
                try
                {
                    dockManager1.BeginUpdate();
                    stream = new System.IO.MemoryStream(Sys.Security.Profile.Instance.Configuration);
                    this.DockManager.RestoreLayoutFromStream(stream);
                    dockManager1.EndUpdate();
                    
                }
                catch (Exception)
                {
                    invalidLayoutData = true;
                }
                finally
                {
                    if(stream!=null)
                        stream.Close(); 
                }
            }
        }

        public void SaveLayout()
        {
            if (!invalidLayoutData)
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                this.DockManager.SaveLayoutToStream(stream);
                Sys.Security.Profile.Instance.Configuration = stream.GetBuffer();
                stream.Close();
            }
            else
            {
                Sys.Security.Profile.Instance.Configuration = null;
            }
        }
    }
}
