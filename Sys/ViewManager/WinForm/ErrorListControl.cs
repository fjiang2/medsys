using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.Data;

namespace Sys.ViewManager.Forms
{
    public partial class ErrorListControl : UserControl
    {
        DPCollection<ErrorItem> errors = new DPCollection<ErrorItem>();

        private int errorCount = 0;
        private int warningCount = 0;
        private int messageCount = 0;

        public ErrorListControl()
        {
            InitializeComponent();
            imageList1.Images.Add(txtMessages.Image);
            imageList1.Images.Add(txtWarnings.Image);
            imageList1.Images.Add(txtErrors.Image);

            gridControl1.DataSource = errors.Table;

            Error(1, "Error Demo", "line 21");
            Warning(2, "Warning Demo", "line 300");
        }

        public void Clear()
        {
            errors.Table.Rows.Clear();
            errorCount = 0;
            warningCount = 0;
            messageCount = 0;
        }

        public void Error(int code, string description, string location)
        {
            ErrorItem item = new ErrorItem();
            item.ID = code;
            item.Type = MessageLevel.error;
            item.Description = description;
            item.Location = location;
            Add(item);
        }

        public void Warning(int code, string description, string location)
        {
            ErrorItem item = new ErrorItem();
            item.ID = code;
            item.Type = MessageLevel.warning;
            item.Description = description;
            item.Location = location;
            Add(item);
        }

        public void Message(int code, string description, string location)
        {
            ErrorItem item = new ErrorItem();
            item.ID = code;
            item.Type = MessageLevel.information;
            item.Description = description;
            item.Location = location;
            Add(item);
        }

        /// <summary>
        /// Value in ImageComboBoxItem must match MessageLevel
        /// </summary>
        /// <param name="item"></param>
        public void Add(ErrorItem item)
        {
            switch(item.Type)
            {
                case MessageLevel.error:
                    errorCount++;
                    break;

                case MessageLevel.warning:
                    warningCount++;
                    break;

                case MessageLevel.information:
                    messageCount++;
                    break;
            }
            
            this.errors.Add(item);

            txtErrors.Text = string.Format("{0} Errors", errorCount);
            txtWarnings.Text = string.Format("{0} Warnings", warningCount);
            txtMessages.Text = string.Format("{0} Messages", messageCount);
        }
    }

 

    public class ErrorItem : PersistentObject
    {
        public int ID;
        public int ErrorTy;
        public string Description;
        public string Location;

        public ErrorItem()
        { 
        }

        internal MessageLevel Type
        {
            get { return (MessageLevel)ErrorTy; }
            set { this.ErrorTy = (int)value; }
        }
    }
}
