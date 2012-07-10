using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sys.ViewManager.Forms
{
    public partial class JSelectorTreeView : UserControl
    {


        DataTable top = new DataTable();
        DataTable bottom = new DataTable();







        public DataSet createRelationships(DataTable Top, DataTable Bottom, DataTable Right)
        {
            DataTable dt = Top;
            dt.TableName = "tracking";
            DataTable d2 = Bottom;
            d2.TableName = "employee";
            DataTable d3 = Right;
            d3.TableName = "relation";

            DataSet ds = new DataSet();
            ds.Tables.Add(dt.Copy());
            ds.Tables.Add(d2.Copy());
            ds.Tables.Add(d3.Copy());


            DataColumn tracking = ds.Tables["tracking"].Columns["uKey"];
            DataColumn employee = ds.Tables["employee"].Columns["EN"];
            DataColumn remployee = ds.Tables["relation"].Columns["EN"];
            DataColumn rtracking = ds.Tables["relation"].Columns["uKey"];

            DataRelation relation1 = new DataRelation("relationtracking", tracking, rtracking);
            DataRelation relation2 = new DataRelation("relationemployee", employee, remployee);

            ds.Relations.Add(relation1);
            ds.Relations.Add(relation2);


            return ds;

        }


        public JSelectorTreeView()
        {
            InitializeComponent();
            this.jGridViewTop.AllowEdit = false;
            this.jGridViewBottom.AllowEdit = false;    
            
        }


       


        public DataTable[] DataSource
        {
            set
            {
                this.jGridViewTop.DataSource = value[0];
                this.jGridViewBottom.DataSource = value[1];
                

                DataTable whee = value[2];

                this.gridControl1.DataSource = value[2];
                gridView1.RefreshData();
            }
        }

        public JGridView GridViewTop
        {
            get
            {
                return this.jGridViewTop;
            }
        }
        public JGridView GridViewBottom
        {
            get
            {
                return this.jGridViewBottom;
            }
        }


        public DataTable DataSourceTop
        {
            get
            {
                return this.jGridViewTop.DataSource;
            }
        }

        public DataTable DataSourceBottom
        {
            get
            {
                return this.jGridViewBottom.DataSource;
            }
        }

        //public DataTable DataSourceRight
        //{
        //    get
        //    {
        //        return this.jGridViewRight.DataSource;
        //    }
        //}
       

      




       



       
        



        int restorept=0;
        private void bShrinkRestoreBottom_Click(object sender, EventArgs e)
        {
            if (this.bShrinkRestoreBottom.Text == "Restore")
            {
                this.splitContainer2.SplitterDistance = restorept;
                this.bShrinkRestoreBottom.Text = "Shrink";
            }
            else
            {
                restorept = this.splitContainer2.Panel1.Height;                                
                this.bShrinkRestoreBottom.Text = "Restore";
                this.splitContainer2.SplitterDistance = this.splitContainer2.Height - 65;
            }
        }

        private void bShrinkRestoreTop_Click(object sender, EventArgs e)
        {

            if (this.bShrinkRestoreTop.Text == "Restore")
            {
                this.splitContainer2.SplitterDistance = restorept;
                this.bShrinkRestoreTop.Text = "Shrink";
            }
            else
            {
                restorept = this.splitContainer2.Panel1.Height;
                this.bShrinkRestoreTop.Text = "Restore";
                this.splitContainer2.SplitterDistance = 65;
            }
        }
    }
}
