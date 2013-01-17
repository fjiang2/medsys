using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    class JComboBox : JWinControl
    {
        public JComboBox(ComboBox comboBox, DataField field)
            : base(comboBox, field)
        {
            comboBox.DataSource = null;
        }

        public JComboBox(ComboBox comboBox, DataField field, DataTable dataTable)
            : base(comboBox, field)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = dataTable.Columns[0].ColumnName;
            comboBox.ValueMember = dataTable.Columns[1].ColumnName;
        }

        public JComboBox(ComboBox comboBox, DataField field, DataTable dataTable, string displayMember, string valueMember)
            : base(comboBox, field)
        {
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = dataTable.Columns[displayMember].ColumnName;
            comboBox.ValueMember = dataTable.Columns[valueMember].ColumnName;
        }

        public override void Fill()
        {
            base.Fill();
            ComboBox comboBox = Control as ComboBox;

            if (value != System.DBNull.Value)
            {
                comboBox.SelectedValue = Convert(value); 
                if (comboBox.DataSource != null)
                {
                    if (comboBox.SelectedIndex == -1)
                        comboBox.Text = value.ToString();
                }
                else
                    comboBox.Text = value.ToString();
            }
            else
            {
                comboBox.SelectedIndex = -1;
                comboBox.Text = "";
            }

            return;
        }

        public override void Collect()
        {
         
            ComboBox comboBox = Control as ComboBox;

            if (comboBox.DataSource != null)
            {
                if (comboBox.SelectedIndex == -1)
                {
                    value = Convert(comboBox.Text);
                    Control.Text = value.ToString();
                }
                else
                {
                    object val = comboBox.SelectedValue;

                    if (val == null)
                        value = System.DBNull.Value;
                    else
                        value = Convert(val);
                }
            }
            else
            {
                value = Convert(comboBox.Text);
                Control.Text = value.ToString();
            }

            base.Collect();
            return;
        }


    }
}
