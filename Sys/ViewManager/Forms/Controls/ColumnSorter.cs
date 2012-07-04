using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;

namespace Sys.ViewManager.Forms
{
    public class ColumnSorter : IComparer //Column Sorter for ListViews
    {
        public int CurrentColumn = 0;
        public int[] _ColumnOrder;  //  ... 0 for ASC ... 1 for DESC ...

        public int Compare(object x, object y)
        {
            ListViewItem columnA = (ListViewItem)x;
            ListViewItem columnB = (ListViewItem)y;


            if (this._ColumnOrder[CurrentColumn] == 0)
            {
                return String.Compare(columnA.SubItems[CurrentColumn].Text, columnB.SubItems[CurrentColumn].Text);
            }
            else
            {
                return -(String.Compare(columnA.SubItems[CurrentColumn].Text, columnB.SubItems[CurrentColumn].Text));
            }
        }

        public ColumnSorter(int pNumOfColumns)
        {
            _ColumnOrder = new int[pNumOfColumns];
        }
    }
}
