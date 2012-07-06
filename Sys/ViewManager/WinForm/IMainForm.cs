using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager;
using Sys.Xmpp;
using Sys.ViewManager.Manager;
using DevExpress.XtraBars;
using Sys.ViewManager.Security;
using DevExpress.XtraBars.Docking;

namespace Sys.ViewManager.Forms
{
    public enum FormPlace
    {
        Floating = 0,
        DockTop = 1,
        DockBottom = 2,
        DockLeft = 3,
        DockRight = 4,
        TabbedAera = 5,
        WindowForm = 6,
        Auto = 7
    }

    public interface IMainForm
    {
        Form Form { get;}

        FormDockManager FormDockManager { get; }

        Bar ToolStrip { get; }
        Bar StatusStrip { get; }

        ContainerControl Show(Control control, FormPlace formPlace);
        void ShowForm(BaseForm form, FormPlace place);
        void CloseForm(BaseForm form);
        void BringFormToFront(BaseForm form);
        void ChangeCaption(BaseForm form);

        IReport Report { get;}
    }


    public enum WorkMode
    {
        Working,
        Reading,
        Reviewing
    }

}
