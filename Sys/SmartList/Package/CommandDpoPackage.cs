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
using Sys.Data.Manager;
using Sys.SmartList.Dpo;

namespace Sys.SmartList.Package
{
	public class CommandDpoPackage : BasePackage<CommandDpo>
	{

		public CommandDpoPackage()
		{
		}

		protected override void Pack()
		{
			var dpo = new CommandDpo();
			dpo.ID = 2;
			dpo.ParentID = 28;
			dpo.OrderBy = 0;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Menus(sys00801)";
			dpo.Description = "";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = "USE $DB_SYSTEM\nSELECT * FROM sys00801";
			dpo.User_Layout = "";
			dpo.Setting_Script = @"class(gridViewer, container) 
{    
   this.gridViewer = gridViewer;    
   this.gridControl = gridViewer.ViewControl;    
   this.gridView = this.gridControl.MainView;     
   this.Initialize = function()    
   {  
     this.gridView.BestFitColumns();    
   }; 
}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 3;
			dpo.ParentID = 28;
			dpo.OrderBy = 10;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Commands(sys01101)";
			dpo.Description = "Source of SmartList";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = "USE $DB_SYSTEM\nSELECT * FROM sys01101";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 4;
			dpo.ParentID = 20;
			dpo.OrderBy = 10;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Security Permission:  Window Form";
			dpo.Description = "Security";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"USE $DB_SYSTEM
SELECT 
	U.User_Name AS [Badge],  
	U.First_Name AS [First Name],   
	U.Last_Name AS [Last Name], 
	R.Role_ID AS [ Role ID],  
	R.Role_Name  AS [Role Name],
	P.Key_Name
 FROM sys00103 UR
	INNER JOIN sys00101 U ON U.User_ID = UR.User_ID
	INNER JOIN sys00102 R ON R.Role_ID = UR.Role_ID
	INNER JOIN sys00503 P ON P.Role_ID = R.Role_ID 
WHERE UR.Role_ID <> 99999 AND  U.User_Name = @User_Name
ORDER BY U.User_Name, P.Key_Name";
			dpo.User_Layout = @"{
Title :  ""Input Bage ID"",
Parameters : {""User_Name""},
Controls:
   [
     {  Class:""System.Windows.Forms.Label"",   
        Text:""Badge ID"",   
        Width:200,
        Position:{1,1}   
     },
     {  
        Class: ""System.Windows.Forms.TextBox"",
        Return: ""Text"",
        Text: User_Name.isnull(UserName), 
        Name: ""User_Name"", 
        Position:{1,2}
     }
  ]

}";
			dpo.Setting_Script = @"class(gridViewer, container) 
{
   this.gridViewer = gridViewer;   
   this.gridControl = gridViewer.ViewControl;
   this.gridView = this.gridControl.MainView;
   
   this.Initialize =function()
   {
        this.gridView.Columns[""Key_Name""].Caption=""Form Class Name"";
        this.gridView.Columns[""Key_Name""].Width=300;
        this.gridView.Columns[""Role Name""].Width=180;

   };

  

}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 5;
			dpo.ParentID = 20;
			dpo.OrderBy = 20;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Security Permission:  SmartList";
			dpo.Description = "Security";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"USE $DB_SYSTEM
SELECT  U.User_Name AS [Badge] ,
        U.First_Name AS [First Name] ,
        U.Last_Name AS [Last Name] ,
        R.Role_ID AS [ Role ID] ,
        R.Role_Name AS [Role Name] ,
        C.ID AS [Smartlist ID] ,
        C.ParentID ,
        C.Description ,
        C.Label
FROM    sys00103 UR
        INNER JOIN sys00101 U ON U.User_ID = UR.User_ID
        INNER JOIN sys00102 R ON R.Role_ID = UR.Role_ID
        INNER JOIN sys00502 P ON P.Role_ID = R.Role_ID
                                               AND Ty = 4
        INNER JOIN sys01101 C ON C.ID = P.ID
WHERE   UR.Role_ID <> 99999
        AND U.User_Name = @User_Name
ORDER BY U.User_Name ,
        C.Label";
			dpo.User_Layout = @"{
Title :  ""Input Bage ID"",
Parameters : {""User_Name""},
Controls:
   [
     {  Class:""System.Windows.Forms.Label"",   
        Text:""Badge ID"",   
        Width:200,
        Position:{1,1}   
     },
     {  
        Class: ""System.Windows.Forms.TextBox"",
        Return: ""Text"",
        Text: User_Name.isnull(UserName), 
        Name: ""User_Name"", 
        Position:{1,2}
     }
  ]

}";
			dpo.Setting_Script = @"class(gridViewer, container) 
{
   this.gridViewer = gridViewer;   
   this.gridControl = gridViewer.ViewControl;
   this.gridView = this.gridControl.MainView;
   
   this.Initialize =function()
   {
        this.gridView.Columns[""Label""].Caption=""Smart List Item"";
        this.gridView.Columns[""Label""].Width=300;
        this.gridView.Columns[""Role Name""].Width=180;

   };
}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 6;
			dpo.ParentID = 20;
			dpo.OrderBy = 30;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Security Permission:  Menu";
			dpo.Description = "Security";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"USE $DB_SYSTEM
SELECT  U.User_Name AS [Badge] ,
        U.First_Name AS [First Name] ,
        U.Last_Name AS [Last Name] ,
        R.Role_ID AS [ Role ID] ,
        R.Role_Name AS [Role Name] ,
        C.ID AS [Menu ID] ,
        C.ParentID ,
        C.Description ,
        C.Label
FROM    sys00103 UR
        INNER JOIN sys00101 U ON U.User_ID = UR.User_ID
        INNER JOIN sys00102 R ON R.Role_ID = UR.Role_ID
        INNER JOIN sys00502 P ON P.Role_ID = R.Role_ID
                                               AND Ty = 2
        INNER JOIN sys00801 C ON C.ID = P.ID
WHERE   UR.Role_ID <> 99999
        AND U.User_Name = @User_Name
ORDER BY U.User_Name ,
        C.Label";
			dpo.User_Layout = @"{
Title :  ""Input Bage ID"",
Parameters : {""User_Name""},
Controls:
   [
     {  Class:""System.Windows.Forms.Label"",   
        Text:""Badge ID"",   
        Width:200,
        Position:{1,1}   
     },
     {  
        Class: ""System.Windows.Forms.TextBox"",
        Return: ""Text"",
        Text: User_Name.isnull(UserName), 
        Name: ""User_Name"", 
        Position:{1,2}
     }
  ]

}";
			dpo.Setting_Script = @"class(gridViewer, container) 
{
   this.gridViewer = gridViewer;   
   this.gridControl = gridViewer.ViewControl;
   this.gridView = this.gridControl.MainView;
   
   this.Initialize =function()
   {
        this.gridView.Columns[""Label""].Caption=""Menu Item"";
        this.gridView.Columns[""Label""].Width=300;
        this.gridView.Columns[""Role Name""].Width=180;

   };

  

}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 7;
			dpo.ParentID = 30;
			dpo.OrderBy = 0;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Chart Control Demo";
			dpo.Description = "DEMO";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"SELECT  TOP 10
  P.ProductName, 
  OD.UnitPrice, 
  OD.UnitPrice*OD.Discount AS [Discount]
FROM Northwind..[Order Details] OD
INNER JOIN Northwind..Products P ON OD.ProductID = P.ProductID

SELECT TOP 10
ProductName, UnitPrice
FROM Northwind..products";
			dpo.User_Layout = "";
			dpo.Setting_Script = @"class(chartViewer, container) 
{

   this.chartViewer= chartViewer;   
   this.chartControl = this.chartViewer.ViewControl;
   this.Diagram= this.chartControl.Diagram;
   
   this.Initialize =function()
   {
	var title = new DevExpress.XtraCharts.ChartTitle();
      title.Text = ""Chart Demo"";
      this.chartControl.Titles.Add(title);
            
      var series1 = new DevExpress.XtraCharts.Series(""Product"", DevExpress.XtraCharts.ViewType.Bar);
      series1.DataSource = this.chartViewer.DataSet.Tables[0];
      series1.ArgumentDataMember = ""ProductName"";
      series1.ValueDataMembers.AddRange({""UnitPrice"",""Discount""}); 
      this.chartControl.Series.Add(series1);

      var series2 = new DevExpress.XtraCharts.Series(""Product Price"", DevExpress.XtraCharts.ViewType.Spline);
      series2.DataSource = this.chartViewer.DataSet.Tables[1];
      series2.ArgumentDataMember = ""ProductName"";
      series2.ValueDataMembers.AddRange({""UnitPrice""}); 
      this.chartControl.Series.Add(series2);

	this.chartControl.Diagram.AxisX.Label.Angle = -90;


   };


   this.ContextMenu=function()
   {
      var contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();

      var menuItem = new System.Windows.Forms.ToolStripMenuItem(""Products"");
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
	      var form = new Sys.SmartList.Forms.MainForm(4); 	
            form.PopUp(container);
           };


     menuItem = new System.Windows.Forms.ToolStripMenuItem(""Orders"");
     contextMenuStrip.Items.Add(menuItem);
     menuItem.Click += function(sender, e)
          { 
	       var form =new Sys.SmartList.Forms.MainForm(24); 
             var parameters;
             parameters = this.ganttChartControl.Selected; 
             form.MaintenanceEntry = parameters;
             form.ChangeCaption(format(""[{0}] {1}"", parameters.Series.Name, form.Text));
             form.PopUp(container);
           };

      return contextMenuStrip;
   };


}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 5;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 8;
			dpo.ParentID = 30;
			dpo.OrderBy = 10;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Chart Control Pane Demo";
			dpo.Description = "DEMO";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"SELECT TOP 10
  ProductName, 
  UnitPrice
FROM Northwind..products


SELECT TOP 10
  ProductName,  
  UnitsInStock
FROM Northwind..products";
			dpo.User_Layout = "";
			dpo.Setting_Script = @"class(chartViewer, container) 
{
   this.chartViewer= chartViewer;   
   this.chartControl = this.chartViewer.ViewControl;
   this.Diagram= this.chartControl.Diagram;
   
   this.Initialize =function()
   {
	var title = new DevExpress.XtraCharts.ChartTitle();
      title.Text = ""Chart Pane Demo"";
      this.chartControl.Titles.Add(title);
            
      var series1 = new DevExpress.XtraCharts.Series(""UnitPrice"", DevExpress.XtraCharts.ViewType.Bar);
      series1.DataSource = this.chartViewer.DataSet.Tables[0];
      series1.ArgumentDataMember = ""ProductName"";
      series1.ValueDataMembers.AddRange({""UnitPrice""}); 
      this.chartControl.Series.Add(series1);

      var series2 = new DevExpress.XtraCharts.Series(""UnitsInStock"", DevExpress.XtraCharts.ViewType.Line);
      series2.DataSource = this.chartViewer.DataSet.Tables[1];
      series2.ArgumentDataMember = ""ProductName"";
      series2.ValueDataMembers.AddRange({""UnitsInStock""}); 
      this.chartControl.Series.Add(series2);

       var myPane = new DevExpress.XtraCharts.XYDiagramPane();
       var diagram = this.chartControl.Diagram;
       diagram.Panes.Add(myPane);
       series2.View.Pane = myPane;

      this.chartControl.Diagram.AxisX.Label.Angle = -45;
   };


   this.ContextMenu=function()
   {
      var contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();

      var menuItem = new System.Windows.Forms.ToolStripMenuItem(""Demo1"");
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
	      var form = new Sys.SmartList.Forms.MainForm(4); 	
            form.PopUp(container);
           };


     menuItem = new System.Windows.Forms.ToolStripMenuItem(""Demo2"");
     contextMenuStrip.Items.Add(menuItem);
     menuItem.Click += function(sender, e)
          { 
 	       var form = new Sys.SmartList.Forms.MainForm(14); 	
             var parameters;
             parameters = this.ganttChartControl.Selected; 
             form.MaintenanceEntry = parameters;
             form.ChangeCaption(format(""[{0}] {1}"", parameters.Series.Name, form.Text));
             form.PopUp(container);
           };

    

      return contextMenuStrip;
   };


} ;";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 5;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 9;
			dpo.ParentID = 30;
			dpo.OrderBy = 20;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Generic Chart+Grid Demo";
			dpo.Description = "DEMO";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"SELECT TOP 10
  ProductName, 
  UnitPrice
FROM Northwind..products


SELECT TOP 10
    ProductName,  
    UnitsInStock
FROM Northwind..products

SELECT *
FROM Northwind..products";
			dpo.User_Layout = "";
			dpo.Setting_Script = @"class(viewer, container) 
{
   this.viewer= viewer;   
   this.panel = this.viewer.ViewControl;
   
    this.Initialize =function()
   {
       var tabControl = new System.Windows.Forms.TabControl();
       var page1 = new System.Windows.Forms.TabPage(""Chart"");
       var page2 = new System.Windows.Forms.TabPage(""Grid"");
       var page3 = new System.Windows.Forms.TabPage(""Chart+Grid"");

       tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
       tabControl.Controls.Add(page1);
       tabControl.Controls.Add(page2);
       tabControl.Controls.Add(page3);

       this.panel.Controls.Add(tabControl);

//page1      
       var chartControl = new DevExpress.XtraCharts.ChartControl();
       chartControl.Dock = System.Windows.Forms.DockStyle.Fill;

      var series1 = new DevExpress.XtraCharts.Series(""UnitPrice"", DevExpress.XtraCharts.ViewType.Bar);
      series1.DataSource = this.viewer.DataSet.Tables[0];
      series1.ArgumentDataMember = ""ProductName"";
      series1.ValueDataMembers.AddRange({""UnitPrice""}); 
      chartControl.Series.Add(series1);

      var series2 = new DevExpress.XtraCharts.Series(""UnitsInStock"", DevExpress.XtraCharts.ViewType.Spline);
      series2.DataSource = this.viewer.DataSet.Tables[1];
      series2.ArgumentDataMember = ""ProductName"";
      series2.ValueDataMembers.AddRange({""UnitsInStock""}); 
      chartControl.Series.Add(series2);

      page1.Controls.Add(chartControl);

//page2
      var gridControl = new Sys.ViewManager.WinControls.JGridView(); //new DevExpress.XtraGrid.GridControl();
      gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      gridControl.DataSource = this.viewer.DataSet.Tables[2];

      page2.Controls.Add(gridControl);


//page3
      var panel1 = new System.Windows.Forms.Panel();
      panel1.Dock = System.Windows.Forms.DockStyle.Top;
	panel1.Location = new System.Drawing.Point(0, 0);
      panel1.Size = new System.Drawing.Size(746, 300);

      var panel2 = new System.Windows.Forms.Panel();
      panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
	panel2.Location = new System.Drawing.Point(0, 300);
      panel2.Size = new System.Drawing.Size(746, 300);
      panel2.Anchor = 15;

      //Chart
	chartControl = new DevExpress.XtraCharts.ChartControl();
      chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
             
      series1 = new DevExpress.XtraCharts.Series(""UnitPrice"", DevExpress.XtraCharts.ViewType.Pie);
      series1.DataSource = this.viewer.DataSet.Tables[0];
      series1.ArgumentDataMember = ""ProductName"";
      series1.ValueDataMembers.AddRange({""UnitPrice""}); 
      chartControl.Series.Add(series1);

// Adjust the point options of the series. 
series1.PointOptions.PointView =  DevExpress.XtraCharts.PointView.ArgumentAndValues; 
series1.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent; 
series1.PointOptions.ValueNumericOptions.Precision = 0; 



      series2 = new DevExpress.XtraCharts.Series(""UnitsInStock"", DevExpress.XtraCharts.ViewType.Pie);
      series2.DataSource = this.viewer.DataSet.Tables[1];
      series2.ArgumentDataMember = ""ProductName"";
      series2.ValueDataMembers.AddRange({""UnitsInStock""}); 
      chartControl.Series.Add(series2);

	this.series3 = new DevExpress.XtraCharts.Series(""Dynamic"", DevExpress.XtraCharts.ViewType.Doughnut);
      chartControl.Series.Add(this.series3);
		
	chartControl.Legend.Visible = false; 


      //Grid
	this.gridView = new Sys.ViewManager.WinControls.JGridView(); 
      this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
	this.gridView.DataSource = this.viewer.DataSet.Tables[2];
	this.gridView.GridControl.MouseClick += this.GridMouseClick;

      panel1.Controls.Add(chartControl); 
      panel2.Controls.Add(this.gridView); 

      page3.Controls.Add(panel1);
      page3.Controls.Add(panel2);
   };


   this.GridMouseClick = delegate(sender, e)
	{
          //used by DEBUG, see log file c:\	ie.log
	    //loginfo(""series3="", this.series3);
	    //loginfo(""Name="", this.gridView.SelectedRow[""ProductName""]);
	    //loginfo(""Duration="", this.gridView.SelectedRow[""UnitsInStock""]);

          var point = new DevExpress.XtraCharts.SeriesPoint(
			this.gridView.SelectedRow[""ProductName""], 
			this.gridView.SelectedRow[""UnitsInStock""]
		);

	    this.series3.Points.Add(point);

      };



}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 6;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 10;
			dpo.ParentID = 30;
			dpo.OrderBy = 30;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "PivotGrid+Chart Demo";
			dpo.Description = "DEMO";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"SELECT 
	C.CustomerID, 
	C.ContactName, 
	P.ProductName,
	O.OrderDate,
	OD.Quantity Quantity, 
	OD.UnitPrice*OD.Quantity*OD.Discount AS Price
FROM Northwind..Customers C
	INNER JOIN Northwind..Orders O ON O.CustomerID = C.CustomerID
	INNER JOIN Northwind..[Order Details] OD ON OD.OrderID = O.OrderID
	INNER JOIN Northwind..Products P ON P.ProductID = OD.ProductID
ORDER BY ContactName";
			dpo.User_Layout = @"{
{""Title"",""Enter Starting Values""},
{""Parameters"",{""Start"", ""End""}},
{""Controls"",
   {
     {{""Class"",""System.Windows.Forms.Label""},{""Text"",""Start Date""}, {""Position"",{1,1}} },
     {{""Class"",""DevExpress.XtraEditors.DateEdit""},{""Return"",""EditValue""},{""EditValue"",Start==null?Date(2010,1,1):Start},{""Name"",""Start""}, {""Position"",{1,2}} },
     {{""Class"",""System.Windows.Forms.Label""},{""Text"",""End Date""}, {""Position"",{2,1}} },
     {{""Class"",""DevExpress.XtraEditors.DateEdit""},{""Return"",""EditValue""},{""EditValue"",End==null?Date(2010,1,1):End},{""Name"",""End""}, {""Position"",{2,2}} }
  }
}}";
			dpo.Setting_Script = @"//  this is GenericViwer
//  To Support print(preview), function DataPrint() must be defined.
//

class(viewer, container) 
{
   this.viewer= viewer;   
   this.panel = this.viewer.ViewControl;
   
   this.Initialize =function()
   {
     
      this.pivotChartControl= new Sys.SmartList.PivotChartControl();
      this.pivotChartControl.Dock = System.Windows.Forms.DockStyle.Fill;
	this.pivotChartControl.DataSource = this.viewer.DataSet.Tables[0];

	var pivotGridControl = this.pivotChartControl.PivotGridControl;
	var PivotArea = typeof(""DevExpress.XtraPivotGrid.PivotArea"");

	pivotGridControl.Fields[""CustomerID""].Area = PivotArea.RowArea;
	pivotGridControl.Fields[""ContactName""].Area = PivotArea.RowArea;
	pivotGridControl.Fields[""OrderDate""].Area = PivotArea.ColumnArea;
	pivotGridControl.Fields[""ProductName""].Area = PivotArea.DataArea;
	pivotGridControl.Fields[""Quantity""].Area = PivotArea.DataArea;
	pivotGridControl.Fields[""Price""].Area = PivotArea.DataArea;

	var chartControl = this.pivotChartControl.ChartControl;
	chartControl.Diagram.AxisX.Label.Angle = -45;

      this.panel.Controls.Add( this.pivotChartControl);
   };


   //to support print in the SmartList
   this.DataPrint=function()
   {
	 //loginfo(""PivotChartControl="", this.pivotChartControl);

      this.pivotChartControl.DataPrint({"""",""Pivot Grid + Chart Demo"",""""});
   };

 

}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 6;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 11;
			dpo.ParentID = 30;
			dpo.OrderBy = 40;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Workflow Demo";
			dpo.Description = "DEMO";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"USE $DB_SYSTEM

--Workflow requres 2 tables
-- 1st table is State Table with 3 columns at least
--     string State_Name; 
--     double Offset; 
--     double Duration; 
--
-- 2nd table is Transition Table with 2 columns
--	 string S1_Name;    
--     string S2_Name; 
--
--If want to display Workflow Tracking information, 3rd table required, columns are
--    string State_Name;
--    DateTime AStart;
--    DateTime AComplete;
--    decimal Actual;
--    int status;

SELECT 
	Name AS State_Name,
	Duration,
	Offset
FROM sys01302
WHERE Workflow_Name =@WorkflowName

SELECT
	S1_Name,
	S2_Name
FROM  sys01303
WHERE Workflow_Name =@WorkflowName



--SELECT 
--	State_Name,
--	Start_Date AS AStart,
--	Complete_Date AS AComplete,
--	Time_Spent AS Actual 
--FROM  sys01305
--WHERE Workflow_Name =@WorkflowName";
			dpo.User_Layout = @"{
{""Title"",""Input Sales Order""},
{""Parameters"",{""WorkflowName""}},
{""Controls"",
   {
     {{""Class"",""System.Windows.Forms.Label""},{""Text"",""Workflow Name:""}, {""Position"",{1,1}} },
     {{""Class"",""System.Windows.Forms.TextBox""},
	{""Return"",""Text""},
	{""Text"",WorkflowName.isnull(SO)},
	{""Name"",""WorkflowName""},
	{""Format"",2}, 
	{""Position"",{1,2}} }
  }
}}";
			dpo.Setting_Script = @"class(viewer, container) 
{
   this.workflowViewer= viewer;   
   this.workflowChartControl = this.workflowViewer.ViewControl;
   this.chartControl = this.workflowChartControl.ChartControl;
   
   this.Initialize =function()
   {
	//
	//ActualTime View: planned budget/actual hours
	//  WorkTime View: {baseworktime + offset, baseworktime + offset + duration} / { actualstarttime, acutalcompletetime}
	//
	this.workflowChartControl.ActivityPointType = typeof(""Sys.Workflow.ActivityPointType"").ActualTime;

	this.workflowChartControl.ReadOnly = true;

      this.chartControl.Titles[0].Text = ""Workflow Name: ""+ WorkflowName;
	this.chartControl.Diagram.AxisY.DateTimeMeasureUnit 
		= typeof(""DevExpress.XtraCharts.DateTimeMeasurementUnit"").Hour;

      this.chartControl.Legend.Visible = true;

	var Series0 = this.chartControl.Series[0];
	var Series1 = this.chartControl.Series[1];

	Series0.PointOptions.PointView =  typeof(""DevExpress.XtraCharts.PointView"").Values;
	Series0.View.ColorEach = false;
	Series0.View.BarWidth = 0.6;

	Series1.View.BarWidth = 0.4;
	Series1.Label.Position =  typeof(""DevExpress.XtraCharts.RangeBarLabelPosition"").Inside;
	Series1.Label.Visible = false;

	this.chartControl.Diagram.AxisY.Label.Angle = -90;



     var Diagram = this.chartControl.Diagram;
//            Diagram.AxisX.Range.Auto = false;
            Diagram.AxisX.Range.MinValueInternal = 0.0;
            Diagram.AxisX.Range.MaxValueInternal = 15.0;
//            Diagram.AxisY.Range.Auto = false;
            Diagram.AxisY.Range.MinValueInternal = 0.0;
            Diagram.AxisY.Range.MaxValueInternal = 200.0;
            Diagram.EnableScrolling = true;
            Diagram.EnableZooming = true;
   };


   this.ContextMenu=function()
   {
      var contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();

      var menuItem = new System.Windows.Forms.ToolStripMenuItem(""Edit Propterties"");
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
            var form = new System.Windows.Forms.Form();
            form.ShowInTaskbar = false;
            form.Text = ""Property Editor"";
            form.Size = new System.Drawing.Size(500, 800);
            var propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            propertyGridControl1.Dock = typeof(""System.Windows.Forms.DockStyle"").Fill;
            propertyGridControl1.SelectedObject = this.workflowChartControl.ChartControl;
            form.Controls.Add(propertyGridControl1);
            form.Show(container);
      };

      return contextMenuStrip;
   };


} ;";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 7;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 13;
			dpo.ParentID = 20;
			dpo.OrderBy = 50;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Global Scripts";
			dpo.Description = "Global variable, data type, common functions for sharing.";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = "USE $DB_SYSTEM\nSELECT * FROM sys01102";
			dpo.User_Layout = "";
			dpo.Setting_Script = @"class(gridViewer, container) 
{
   this.gridViewer = gridViewer;
   this.gridControl = gridViewer.ViewControl;
   this.gridView = this.gridControl.MainView;

   this.Initialize =function()
   {
      register(typeof(""Sys.Data.SqlCmd""));
      register(typeof(""Sys.ViewManager.Forms.TieEditor""));


	this.gridView.BestFitColumns();

	this.gridView.Columns[""Module""].Width = 120;
	this.gridView.Columns[""Script""].Width = 500;
	this.gridView.Columns[""Notes""].Width = 200;
	this.gridView.Columns[""Released""].Width = 40;


   };


this.ContextMenu=function()
   {
      var contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();

      

	var menuItem = new System.Windows.Forms.ToolStripMenuItem(""Script Editor"");
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
		var view = sender;		
		var title = this.gridViewer.SelectedDataRow[""Module""];
		var script = this.gridViewer.SelectedDataRow[""Script""];

		script = Sys.ViewManager.Forms.TieEditor.Show(dataViewContainer, ""Edit: ""+title, script);
		if(script != null)
		{
               Sys.Data.SqlCmd.ExecuteScalar(""UPDATE sys01102 SET Script='{0}' WHERE [Module]='{1}'"",{script,title});
		   Sys.Systems.File.BackupFile(""Commands.GlobalScript"",""tie"",script);
		   container.InformationMessage=""Script is saved."";
		}
           };

	menuItem = new System.Windows.Forms.ToolStripMenuItem(""Property Editor: GridControl"");
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
		this.gridControl.PropertyShow(container);
          };

	menuItem = new System.Windows.Forms.ToolStripMenuItem(""Property Editor: GridView"");
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
		this.gridView.PropertyShow(container);
          };
	

 return contextMenuStrip;
   };



}";
			dpo.Access_Level = 1;
			dpo.Released = false;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 14;
			dpo.ParentID = 30;
			dpo.OrderBy = 50;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Grid Color Legend Demo";
			dpo.Description = "";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"set nocount on

IF OBJECT_ID('tempdb..#partsNeeded') IS NOT NULL drop table #partsNeeded
IF OBJECT_ID('tempdb..#partsNeededAndLate') IS NOT NULL drop table #partsNeededAndLate
IF OBJECT_ID('tempdb..#engineeringWorkQueue') IS NOT NULL drop table #engineeringWorkQueue


--Engineering Work Queue
SELECT count(tracking.taskcard) as ttl, tracking.taskcard into #engineeringWorkQueue
FROM Engineering.dbo.EngParent 
INNER JOIN Tracking ON Engineering.dbo.EngParent.SO = Tracking.SO AND Engineering.dbo.EngParent.Taskcard = Tracking.Taskcard 

where Engineering.dbo.EngParent.so = @mySO and FinalClose = 0
group by tracking.taskcard

-- partsNeeded
Select  
count(taskcard) as ttl, p.taskcard into #partsNeeded

from PaqViewPCParts p

left join 
      (SELECT b.ITEMNMBR, b.QTYONHND, b.LOCNCODE
      FROM eas..IV00101 a 
       JOIN eas..IV00102 b ON a.ITEMNMBR = b.ITEMNMBR 
       WHERE b.LOCNCODE <> '') stock on stock.itemnmbr = p.part

where  p.so = @mySO and p.cured = 0 and p.qty > stock.qtyonhnd
group by taskcard

-- partsNeededAndLate
Select  
count(taskcard) as ttl, p.taskcard into #partsNeededAndLate

from PaqViewPCParts p

left join 
      (SELECT b.ITEMNMBR, b.QTYONHND, b.LOCNCODE
      FROM eas..IV00101 a 
       JOIN eas..IV00102 b ON a.ITEMNMBR = b.ITEMNMBR 
       WHERE b.LOCNCODE <> '') stock on stock.itemnmbr = p.part

where  p.so = @mySO and p.cured = 0 and p.qty > stock.qtyonhnd and DateDiff(d, [need Date], getDate()) < 0
group by taskcard

--get SO Start Date
declare @startdate datetime
select @startdate = [start_date] from sales_order where wo = @mySO

--main query
select
	CASE WHEN t.AComplete IS NULL THEN 'FALSE' ELSE 'TRUE' END AS Complete
	, ms.Milestone      	
	, t.Taskcard	
	, t.Tracking
	, rtrim(t.Nomen) as 'Nomen'
	, isNull(rtrim(TrackingDescr), '') as 'Phase Description'	
	, isNull(rtrim(upper(notes.NoteText)), '') as 'Note'
	, t.crew	
	, isnull(t.actual, 0) as 'Actual'
	, t.Budget
	, tk.budget as 'Banked LUs'
	, t.Doctype
	, t.Phase
	, t.Sequence
	, t.cardstatus as 'Card Status'
	, t.NRCriteria
	, t.aczone
	, convert(varchar(10), case when t.ms_ukey is not null then dateAdd(d, ms.offset + isNull(t.ms_offset, 0), @startdate) else @startdate end, 101) as 'Start Date'
	, t.Duration
	,convert(varchar(10), dateAdd(hh, t.duration, case when t.ms_ukey is not null then dateAdd(d, ms.offset + isNull(t.ms_offset, 0), @startdate) else @startdate end), 101) as 'Est. Completion Date'
	,(select count([key]) from timekeeping where so = t.so and taskcard = t.tracking and tcstart is not null and tcstop is null) as 'Employees on Job'
	, case when dateDiff(d, dateAdd(hh, t.duration, case when t.ms_ukey is not null then dateAdd(d, ms.offset + isNull(t.ms_offset, 0), @startdate) else @startdate end), getDate()) > 0 then 'Yes' else 'No' end as 'Is Late'
	, case when t.actual > t.budget then 'Yes' else 'No' end as 'Over Budget'
	, case when p.ttl is null then 0 else p.ttl end as 'Parts on Order'
	, case when pLate.ttl is null then 0 else pLate.ttl end as 'Parts on Order and Late'
	, case when eWQueue.ttl is null then 0 else eWQueue.ttl end as 'Engineering Work Queue'
	, case when qc.ttlMinsWaiting is not null then t.taskcard else 'No' end as 'Waiting on QC'
	, case when qc.ttlMinsWaiting is not null then qc.ttlMinsWaiting else 0 end as 'Total Mins Waiting on QC'
	--,cast(case when t.nomen like '%corrosion%' then 1 else 0 end as bit) as 'Corrosion'
	, case when cast(isNull((select count(*)
					from tracking
					join
						(select s1_name, so from trackingrelations where s2_name = t.tracking and so = @mySO) d on d.s1_name = tracking.tracking
					where
					tracking.so = @mySO
					and tracking.acomplete is null), 0) as bit) = 0 then 'No' else 'Yes' end as 'Waiting on Dependency'
	, t.uKey
from tracking t

left join trackingmilestones ms on ms.ukey = t.ms_ukey
left join #partsNeeded p on p.taskcard = t.taskcard
left join #partsNeededAndLate pLate on pLate.taskcard = t.taskcard
left join #engineeringWorkQueue eWQueue on eWQueue.taskcard = t.taskcard
left join (SELECT NoteText, key1, key2 FROM Notes where NoteType = 1) notes on notes.key1 = t.so and notes.key2 = t.taskcard
left join --budget stuff
(select sum(tk.budget) as 'budget', taskcard
	from timekeeping tk
	where tk.so = @mySO and tk.LUPdStatus IN ('PAID', 'InQueue')
	group by taskcard) tk on tk.taskcard = t.taskcard

left join --qc stuff
(select max(dateDiff(n, datetimeofcall, coalesce(inspectoroncall ,getDate()))) as ttlMinsWaiting, taskcard from aeronet..callsheetdetail where so = @mySO and inspectorOffCall is null group by taskcard) qc on qc.taskcard = t.taskcard

WHERE t.SO = @mySO AND t.MS_uKey IS NULL
order by [start date], t.taskcard, t.tracking	

drop table #partsNeeded
drop table #partsNeededAndLate
drop table #engineeringWorkQueue";
			dpo.User_Layout = @"{
{""Title"",""Input SO#""},
{""Parameters"",{""mySO""}},
{""Controls"",
   {
   {{""Class"",""System.Windows.Forms.Label""},{""Text"",""Sales Order""}, {""Position"",{1,1}} },
   {{""Class"",""System.Windows.Forms.TextBox""},{""Return"",""Text""},{""Name"",""mySO""},{""Format"",2} , {""Position"",{1,2}} }
  }
}}";
			dpo.Setting_Script = @"class(gridViewer, container) 
{
   this.gridViewer = gridViewer;
   this.gridControl = gridViewer.ViewControl;
   this.gridView = this.gridControl.MainView;

   this.Initialize =function()
   {
	var filterType = typeof(""DevExpress.XtraGrid.Columns.ColumnFilterType"");

	this.gridView.Columns[""Card Status""].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(filterType.Custom, null, ""[Card Status] != 'records' and [Card Status] != 'closed'"");

	this.gridView.Columns[""uKey""].Visible=false;

	var green = System.Drawing.Color.FromArgb(191, 254, 177);
	var red =  System.Drawing.Color.FromArgb(255, 175, 175);
	var yellow = System.Drawing.Color.FromArgb(253, 254, 177);

	var sit = typeof(""DevExpress.Data.SummaryItemType"");

	/*
	Green = Card Ready to Work
	Red = Card not Ready to Work
	Yellow = General Caution
	*/

	this.gridView.BestFitColumns();

	this.gridView.Columns[""Nomen""].Width = 300;
	this.gridView.Columns[""Phase Description""].Width = 300;
	this.gridView.Columns[""Note""].Width = 300;


	this.gridView.Columns[""Actual""].SummaryItem.DisplayFormat = ""SUM={0:#.##}"";
      this.gridView.Columns[""Actual""].SummaryItem.SummaryType = sit.Sum;


	this.gridView.Columns[""Budget""].SummaryItem.DisplayFormat = ""SUM={0:#.##}"";
      this.gridView.Columns[""Budget""].SummaryItem.SummaryType = sit.Sum;

	//this.gridViewer.OptionsView.ShowFooter = true;

	//green - ready to work
	this.gridViewer.SetDataRowBackColor(""1 = 1"", green);
      this.expr = 
      {
	 {""1. Parts on Order"", 		""[Parts on Order] > 0"", red},
	 {""2. Card Status != Open"", 	""[Card Status] != 'OPEN'"", red},
	 {""3. Waiting on QC"", 		""[Waiting on QC] != 'No'"", red},
 	 {""4. Actuals > Budget"", 	""Actual > Budget"", red },
	 {""5. Card Status == New"", 	""[Card Status] = 'NEW'"", yellow},
	 {""6. Banked LUs >= Budget"",	""[Banked LUs] >= Budget"", yellow},
	 {""7. Zero Hrs clocked & OverDue"",""[Is Late] == 'Yes' and Actual = 0"", red},
	 {""8. Parts on Order and Late"",""[Parts on Order and Late] > 0"", red},
	 {""9. Phases in Engineering work Queue (by tasckard)"",""[Engineering Work Queue] > 0"", red},

	//10. Scheduled but shift over & no hours clocked **This is not possible with current scheduling software as it is not specific to any day and they may schedule cards ahead of time?

	{""11. Waiting on Dependency"",""[Waiting on Dependency] != 'No'"", red}
     };
	
	foreach(var exp in this.expr)
	 this.gridViewer.SetDataRowBackColor(exp[1], exp[2]);


   };




this.ContextMenu=function()
   {
      var contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
	var selected = this.gridViewer.SelectedDataRow != null;
      

	var menuItem = new System.Windows.Forms.ToolStripMenuItem(""Adjust Milestone"");
      contextMenuStrip.Items.Add(menuItem);
	menuItem.Image = ViewManager.Utils.GetResourceObject(""PAQ_Client"",""PAQ"", ""pencil"");		//(DllName,ImageName)
      menuItem.Click += function(sender, e)
          { 
		var view = sender;		
		var tracking= this.gridViewer.SelectedDataRow[""Tracking""];

		var frm = new Scheduling.Aircraft.AdjustMilestone();
		frm.SalesOrder = mySO;
		frm.Tracking = tracking;           
		frm.PopUp(container);		

           };

	menuItem = new System.Windows.Forms.ToolStripMenuItem(""Project Info"");
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
		var view = sender;		
		var taskcard = this.gridViewer.SelectedDataRow[""Taskcard""];

		var frmProjInfo = new Aeroframe.Manager.ProjectInfoDrillDown();
			frmProjInfo.SalesOrder = mySO;
            	frmProjInfo.Taskcard = taskcard;
            	frmProjInfo.OMSCall = false;

		frmProjInfo.PopUp(container);		

           };
	
	contextMenuStrip.Items.Add(new System.Windows.Forms.ToolStripSeparator());
	
	menuItem = new System.Windows.Forms.ToolStripMenuItem(""Clear Filters"");
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
		this.gridView.ActiveFilterString = """";
            this.gridView.ActiveFilterEnabled = true;
           };
	


	foreach(var exp in this.expr)
	{
	  menuItem = new System.Windows.Forms.ToolStripMenuItem(exp[0]);
	  contextMenuStrip.Items.Add(menuItem);
	  menuItem.Image = ViewManager.Utils.ColorBox(exp[2],16,16);
	  menuItem.Enabled = selected;
	  menuItem.Tag = exp[1];
        menuItem.Click += function(sender, e)
          { 
		this.gridView.ActiveFilterString = sender.Tag;
            this.gridView.ActiveFilterEnabled = true;
           };
	}



	contextMenuStrip.Items.Add(new System.Windows.Forms.ToolStripSeparator());
	
	menuItem = new System.Windows.Forms.ToolStripMenuItem(""About"");
	menuItem.Image = ViewManager.Utils.GetResourceObject(""SmartList"", ""information"");		//(DllName,ImageName)
      contextMenuStrip.Items.Add(menuItem);
      menuItem.Click += function(sender, e)
          { 
		   container.About();
           };




	var currentRow = this.gridViewer.SelectedDataRowView;
      for(i=0; i< size(expr); i++)
	{
	  var exp = expr[i];
	  if( ViewManager.Utils.EvaluateRowExpression(this.gridView, currentRow, exp[1]) == true)
	  {
		contextMenuStrip.Items[4+i].Font = new System.Drawing.Font(""MS Gothic"", (float)11.25, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
	  }
	}



	return contextMenuStrip;
   };



} ;";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 19;
			dpo.ParentID = 20;
			dpo.OrderBy = 40;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Stored Procedures";
			dpo.Description = "";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"Command List\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"SELECT OBJECT_DEFINITION(OBJECT_ID) AS sp,
	*
FROM sys.procedures
WHERE is_ms_shipped <> 1
ORDER BY name";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 20;
			dpo.ParentID = 0;
			dpo.OrderBy = 40;
			dpo.Image_Index = 0;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Developer Used Only";
			dpo.Description = "Developer";
			dpo.Header_Footer = "";
			dpo.Sql_Command = "";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 0;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 21;
			dpo.ParentID = 0;
			dpo.OrderBy = 20;
			dpo.Image_Index = 0;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Security";
			dpo.Description = "Security";
			dpo.Header_Footer = "";
			dpo.Sql_Command = "";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 0;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 22;
			dpo.ParentID = 21;
			dpo.OrderBy = 10;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Users & Roles";
			dpo.Description = "Security";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"USE $DB_SYSTEM
SELECT  U.User_Name AS [Badge] ,
        U.First_Name AS [First Name] ,
        U.Last_Name AS [Last Name] ,
        R.Role_ID AS [ Role ID] ,
        R.Role_Name AS [Role Name]
FROM    sys00103 UR
        INNER JOIN sys00101 U ON U.User_ID = UR.User_ID
        INNER JOIN sys00102 R ON R.Role_ID = UR.Role_ID
WHERE   U.Inactive = 0
        AND UR.Role_ID <> 99999
ORDER BY U.User_Name";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 23;
			dpo.ParentID = 21;
			dpo.OrderBy = 20;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Users & Roles Unassigned";
			dpo.Description = "Security";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"USE $DB_SYSTEM
SELECT  U.User_Name AS [Badge] ,
        U.First_Name AS [First Name] ,
        U.Last_Name AS [Last Name]
FROM    sys00101 U
        LEFT JOIN sys00103 UR ON U.User_ID = UR.User_ID
        LEFT JOIN sys00102 R ON R.Role_ID = UR.Role_ID
WHERE   U.Inactive = 0
        AND UR.Role_ID IS NULL
ORDER BY U.User_Name";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 24;
			dpo.ParentID = 21;
			dpo.OrderBy = 0;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "User Activity I2";
			dpo.Description = "Security";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = @"USE $DB_SYSTEM
SELECT DISTINCT
        A.[User_Name] AS [User Name],
        First_Name AS [First Name] ,
        Application_Name AS [Application],
        Computer_Name AS Computer,
        Version ,
        DateEntered AS [Logon Date] ,
        CAST(DATEPART(hh, DateEntered) AS VARCHAR) + ':'
			+ CAST(DATEPART(mi, DateEntered) AS VARCHAR) + ':'
			+ CAST(DATEPART(ss, DateEntered) AS VARCHAR) AS [Logon Time] ,
        DATEDIFF(mi, DateEntered, GETDATE()) / 60 AS [Duration (Hour) ] ,
        DATEDIFF(mi, DateEntered, GETDATE()) % 60 AS [Duration (Min) ]
FROM    sys00304 A
        INNER JOIN sys00101 U ON A.User_Name = U.User_Name AND U.Inactive = 0
ORDER BY A.[User_NAME]";
			dpo.User_Layout = "";
			dpo.Setting_Script = @"//User Live Activity  
class(gridViewer, container) 
{    
	this.gridViewer = gridViewer;       
	this.gridControl = gridViewer.ViewControl;    
	this.gridView = this.gridControl.MainView;        
	this.Initialize =function()    
	{         
	   //this.gridView.Columns[""Name""].Caption=""Badge"";         
  	   //this.gridView.Columns[""IP""].Caption=""Computer"";         
	   //this.gridView.Columns[""System""].Caption=""Application"";    
      };     

      this.DataSave =function()    
	{       
	  var columns;       
	  columns[0].ColumnName = ""Name"";       
        columns[1].ColumnName = ""System"";       
	  columns[2].ColumnName = ""IP"";         
	  this.gridViewer.SaveDataTable(""sys00304"",VAL(columns));  //CAST to VAL    
      };  

}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.csA62DFD6A{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:italic; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""csA62DFD6A"">Show all users Activities</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 25;
			dpo.ParentID = 28;
			dpo.OrderBy = 20;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Dictionary Tables(sys00202)";
			dpo.Description = "Dictionary Tables";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = "USE $DB_SYSTEM\nSELECT * FROM sys00202";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 26;
			dpo.ParentID = 28;
			dpo.OrderBy = 30;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Configuration (sys00501)";
			dpo.Description = "Configuration";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = "USE $DB_SYSTEM\nSELECT * FROM sys00501";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 28;
			dpo.ParentID = 20;
			dpo.OrderBy = 0;
			dpo.Image_Index = 0;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "System Tables";
			dpo.Description = "";
			dpo.Header_Footer = "";
			dpo.Sql_Command = "";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 0;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 29;
			dpo.ParentID = 28;
			dpo.OrderBy = 40;
			dpo.Image_Index = 1;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Assemblies(sys00701)";
			dpo.Description = "Module List";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = "USE $DB_SYSTEM\nSELECT * FROM sys00701";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 30;
			dpo.ParentID = 0;
			dpo.OrderBy = 30;
			dpo.Image_Index = 0;
			dpo.Ty = 4;
			dpo.Company_ID = 0;
			dpo.Application = "";
			dpo.Label = "Demo";
			dpo.Description = "Demo";
			dpo.Header_Footer = "";
			dpo.Sql_Command = "";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 0;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 31;
			dpo.ParentID = 21;
			dpo.OrderBy = 30;
			dpo.Image_Index = 0;
			dpo.Ty = 4;
			dpo.Company_ID = 1;
			dpo.Application = "";
			dpo.Label = "Undefined";
			dpo.Description = "";
			dpo.Header_Footer = "";
			dpo.Sql_Command = "";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 32;
			dpo.ParentID = 31;
			dpo.OrderBy = 0;
			dpo.Image_Index = 0;
			dpo.Ty = 4;
			dpo.Company_ID = 1;
			dpo.Application = "";
			dpo.Label = "Undefined3";
			dpo.Description = "";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = "";
			dpo.User_Layout = "";
			dpo.Setting_Script = "";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 1;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

			dpo = new CommandDpo();
			dpo.ID = 34;
			dpo.ParentID = 30;
			dpo.OrderBy = 60;
			dpo.Image_Index = 2;
			dpo.Ty = 4;
			dpo.Company_ID = 1;
			dpo.Application = "";
			dpo.Label = "Report Demo";
			dpo.Description = "";
			dpo.Header_Footer = "{{\"Header\",{\"\",\"\",\"\"}},{\"Footer\",{\"\",\"\",\"\"}}}";
			dpo.Sql_Command = "SELECT *\nFROM Northwind..Categories\n\nSELECT *\nFROM Northwind..Products";
			dpo.User_Layout = "";
			dpo.Setting_Script = @"class(viewer, container) 
{    
	this.reportViewer = viewer;       
	this.printControl= this.reportViewer.ViewControl;    
	this.report = this.reportViewer.Report;

	this.dataSet = this.reportViewer.DataSet;
	this.tableCategories= this.dataSet.Tables[0];
	this.tableProducts = this.dataSet.Tables[1];


	this.Initialize =function()    
	{         
	   var relation = new System.Data.DataRelation(""FK_Products_Categories"", 
	         new System.Data.DataColumn[] { this.tableCategories.Columns[""CategoryID""]}, 
		   new System.Data.DataColumn[] { this.tableProducts.Columns[""CategoryID""]}, 
               false);
            
	this.dataSet.Relations.Add(relation);
	this.tableCategories.TableName = ""Categories"";
      this.tableProducts .TableName = ""Products"";

      this.report.DataSource = this.dataSet;
      };     


      this.DataSave =function()    
	{       
	
      };  

}";
			dpo.Access_Level = 1;
			dpo.Released = true;
			dpo.Controlled = true;
			dpo.Enabled = true;
			dpo.Visible = true;
			dpo.ViewMode = 8;
			dpo.Owner_ID = 0;
			dpo.Help = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html>
	<head>
		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=utf-8"" /><title>
		</title>
		<style type=""text/css"">
			.cs95E872D0{text-align:left;text-indent:0pt;margin:0pt 0pt 0pt 0pt}
			.cs5EFED22F{color:#000000;background-color:transparent;font-family:Times New Roman; font-size:12pt; font-weight:normal; font-style:normal; }
		</style>
	</head>
	<body>
		<span><p class=""cs95E872D0""><span class=""cs5EFED22F"">&nbsp;</span></p></span></body>
</html>
";
			list.Add(dpo);

		}

	}
}
