using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sys.ViewManager.Forms
{
    public partial class CheckBoxList : UserControl
    {
        public CheckBoxList()
        {
            InitializeComponent();
        }

        private void Add(string item)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Text= item;
            Items.Add(checkBox);
        }

        private Control.ControlCollection Items
        {
            get
            {
                return this.Panel.Controls;
            }
        }

        private Type enumType;
        public Type EnumType
        {
            set
            {
                this.enumType = value;

                foreach (object e in Enum.GetValues(enumType))
                {
                    Add(e.ToString());
                }
            }
        }

        public int Value
        {
            get
            {
                if (enumType == null)
                    return -1;

                int value = 0;
                foreach (Control item in Items)
                {
                    CheckBox checkBox = (CheckBox)item;
                    int v = (int)Enum.Parse(enumType, checkBox.Text);
                    if (checkBox.Checked)
                    {
                        value |= v;
                    }
                }

                return value;
            }
            set
            {
                foreach (Control item in Items)
                {
                    CheckBox checkBox = (CheckBox)item;
                    int v = (int)Enum.Parse(enumType, checkBox.Text);
                    checkBox.Checked = (value & v) != 0;
                }

            }
        }


    }
}
