//
// Machine Packed Data
//   by devel at 7/9/2012 3:33:34 PM
//
using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Sys;
using Sys.Data;
using Sys.DataManager;
using Sys.Foundation.Dpo;

namespace Sys.Foundation.Package
{
	public class ScriptDpoPackage : BasePackage<ScriptDpo>
	{

		public ScriptDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new ScriptDpo();
			dpo.Module = "Sys.SmartList";
			dpo.Library = "Commands";
			dpo.Script = @"/*
  SmartList global script shared by all smart list items.

  version 0.1   03/02/2012


*/

  register(typeof(""System.Drawing.Color""));
  register(typeof(""System.Windows.Forms.DockStyle""));
  register(typeof(""System.Drawing.FontStyle""));
  register(typeof(""System.Drawing.GraphicsUnit""));
  register(typeof(""System.Windows.Forms.MessageBox""));
  register(typeof(""System.Windows.Forms.MessageBoxButtons""));
  register(typeof(""System.Windows.Forms.DialogResult""));

  register(typeof(""Sys.ViewManager.Utils.Function""));
  register(typeof(""Sys.ViewManager.DevEx.Grid""));
  register(typeof(""Sys.IO.File""));

  register(typeof(""DevExpress.XtraGrid.Views.Grid.GridView""));
  register(typeof(""DevExpress.Utils.AppearanceOptionsEx""));
  register(typeof(""DevExpress.XtraGrid.FormatConditionEnum""));
  register(typeof(""DevExpress.Data.SummaryItemType""));
  account = typeof(""Sys.Security.Account"").CurrentUser;



  PropertyShow = function(control, owner)
   {
	var form = new System.Windows.Forms.Form();
      form.ShowInTaskbar = false;
      form.Text = ""Property Editor : ["" + control.GetType().FullName + ""]"";
      form.Size = new System.Drawing.Size(500, 800);
      var propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
      propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      propertyGridControl1.SelectedObject = control;
      form.Controls.Add(propertyGridControl1);
      form.Show(owner);
  };


   StyleFormatBackColor = function(expression, color)
   {
            var styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.BackColor = color;
            styleFormatCondition.Appearance.BackColor2 = color;
            styleFormatCondition.Appearance.propertyof(DevExpress.Utils.AppearanceOptionsEx,""Options"").UseBackColor = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Expression = expression;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            return styleFormatCondition;
   };

   StyleFormatForeColor = function(expression, color)
   {
            var styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition.Appearance.ForeColor = color;
            styleFormatCondition.Appearance.propertyof(DevExpress.Utils.AppearanceOptionsEx,""Options"").UseForeColor = true;
            styleFormatCondition.ApplyToRow = true;
            styleFormatCondition.Expression = expression;
            styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            return styleFormatCondition;
   };

   DataRowBackColor = function(gridview, expression, color)
   {
	gridview.FormatConditions.Add(StyleFormatBackColor(expression,color));
   };

   DataRowForeColor = function(gridview, expression, color)
   {
	gridview.FormatConditions.Add(StyleFormatForeColor(expression,color));
   };



   SetDataSource = function(gridControl1, dataTable)
	{
	  if(gridControl1.GetType() == typeof(DevExpress.XtraGrid.GridControl))
        {
          gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;

    	    gridControl1.DataSource = dataTable;
          var gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
	    gridControl1.ViewCollection.Add(gridView1);

          Sys.ViewManager.Grid.InitializeGridViewColumns(gridControl1, gridView1, dataTable);
	    Sys.ViewManager.Grid.GridViewSetting(gridView1);	
          return gridView1;
         }

        return null;
	};



";
			dpo.Released = true;
			list.Add(dpo);

		}

	}
}
