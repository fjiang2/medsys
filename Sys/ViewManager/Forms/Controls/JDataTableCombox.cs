using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Sys.ViewManager;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public class JDataTableComboBox : ComboBox
    {
        DataTable dataTable;
        string displayField;
        string valueField;


        public JDataTableComboBox()
        {
           
        }

        public string ValueField
        {
            set
            {
                this.valueField = value;
            }
        }

        public string DisplayField
        {
            set
            {
                this.displayField = value;
            }
        }


    
        public DataTable DataTable
        {
            set
            {
                this.dataTable = value;
                foreach (DataRow dataRow in this.dataTable.Rows)
                {
                    JDataRowItem item = new JDataRowItem(dataRow, valueField, displayField);
                    this.Items.Add(item);
                }

            }
        }


        public new object SelectedValue
        {
            get
            {
                JDataRowItem item = this.SelectedItem as JDataRowItem;
                return item.Value;
            }
        }

    }


    class JDataRowItem
    {

        public string displayField;
        public string valueField;
        DataRow dataRow;

        public JDataRowItem(DataRow dataRow, string valueField)
            : this(dataRow, valueField, valueField)
        { }

        public JDataRowItem(DataRow dataRow, string valueField, string displayField)
        {
            this.dataRow = dataRow;
            this.valueField = valueField;
            this.displayField = displayField;

        }

        public object Value
        {
            get
            {
                return this.dataRow[valueField];
            }
        }

        public override string ToString()
        {
            return this.dataRow[displayField].ToString();
        }

    }
}
