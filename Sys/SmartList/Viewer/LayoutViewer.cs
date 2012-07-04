using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Customization;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Tie;
using Sys.ViewManager;
using Sys.ViewManager.DevEx;

namespace Sys.SmartList
{
    class LayoutViewer : GridViewer
    {
        
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();

            // 
            // layoutView1
            // 
            this.layoutView1.CardCaptionFormat = "Record # {0}";
            this.layoutView1.GridControl = this.gridControl;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.OptionsBehavior.Editable = false;
            this.layoutView1.TemplateCard = this.layoutViewCard1;

            gridLevelNode1.LevelTemplate = this.layoutView1;
            gridLevelNode1.RelationName = "Level1";
            
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});

            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "layoutViewCard1";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.Text = "layoutViewCard1";

        }


        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;


        public LayoutViewer(Configuration item)
            : base(item)
        { 
        
        }


        public override void InitializeViewLayout(VAL parameters)
        {

            this.layoutView1.Columns.Clear();
            Grid.InitializeLayoutViewColumns(gridControl, layoutView1, Table0);

            UserViewLayout = parameters;
        }

        public override string ActivateView()
        {
            DataTable dataTable = (DataTable)gridControl.DataSource;

            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            Grid.InitializeLayoutViewColumns(gridControl, layoutView1, dataTable);


            gridControl.Focus();
            gridControl.MainView.LayoutChanged();
            Cursor.Current = currentCursor;

            return  "Card View";

        }

    }
}
