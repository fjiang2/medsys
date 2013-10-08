using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using X12.File;
using DevExpress.XtraLayout;
using X12.Specification;

namespace X12.Forms
{
    public partial class SegmentEdit : UserControl
    {
        SegmentLine segmentLine;

        public SegmentEdit()
        {
            InitializeComponent();
        }

        public SegmentLine SegmentLine
        {
            get { return this.segmentLine; }
            set 
            {
                if (value == null)
                    return;

                this.segmentLine = value;

                int i = 1;
                foreach (ElementTemplateDpo element in this.segmentLine.Segment.ElementTemplates)
                {
                    object obj;
                    if (i < segmentLine.Count)
                        obj = segmentLine[i].Text;
                    else
                        obj = "";

                    Add(element, segmentLine.Segment, obj);

                    i++;
                }
            }
        }



        private void Add(ElementTemplateDpo element, SegmentInstanceDpo elementInstance, object value)
        {
            int count = this.layoutControl1.Root.Count;
            string caption = string.Format("{0} : {1}({2})", element.RefDes, element.Description, element.ConditionDesignator);

            TextBox textBox = new TextBox();
            textBox.Name = "EditControl" + count;
            textBox.Text = value.ToString();

            LayoutControlItem item = this.layoutControl1.Root.AddItem();
            item.Name = "layoutControlItem" + count;
            item.Control = textBox;
            item.CustomizationFormText = caption;
            item.Text = caption;
        }
    }


    class ElementEditor
    {
        Control control;

        public ElementEditor(ElementTemplateDpo element)
        {

            switch (element.ElementType)
            {
                case DataELemenType.String:
                    control = new TextBox();
                    break;

                case DataELemenType.Numeric:
                    control = new TextBox();
                    break;

                case DataELemenType.Date:
                    control = new DateTimePicker();
                    break;

                case DataELemenType.Time:
                    control = new TextBox();
                    break;
            }

        }

        public Control Control
        {
            get { return this.control; }
        }
    }
}
