using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sys;
using Sys.Data;


namespace sqlcon
{
    partial class PathManager
    {
        public void TypeFile(TreeNode<IDataPath> pt, Command cmd)
        {
            if (TypeFileData(pt, cmd)) return;
            if (TypeLocatorData(pt, cmd)) return;
            if (TypeLocatorColumnData(pt, cmd)) return;
        }

     
        public static bool TypeFileData(TreeNode<IDataPath> pt, Command cmd)
        {
            if (!(pt.Item is TableName))
                return false;

            TableName tname = (TableName)pt.Item;

            return new TableOut(tname).Display(cmd);
        }

      
        private bool TypeLocatorData(TreeNode<IDataPath> pt, Command cmd)
        {
            if (!(pt.Item is Locator))
                return false;

            TableName tname = this.GetCurrentPath<TableName>();
            Locator locator = GetCombinedLocator(pt);

            var xnode = pt;
            while (xnode.Parent.Item is Locator)
            {
                xnode = xnode.Parent;
                locator.And((Locator)xnode.Item);
            }

            return new TableOut(tname).Display(cmd, "*", locator);

        }

        private static bool TypeLocatorColumnData(TreeNode<IDataPath> pt, Command cmd)
        {
            if (!(pt.Item is ColumnPath))
                return false;

            ColumnPath column = (ColumnPath)pt.Item;
            Locator locator = null;
            TableName tname = null;

            if (pt.Parent.Item is Locator)
            {
                locator = (Locator)pt.Parent.Item;
                tname = (TableName)pt.Parent.Parent.Item;
            }
            else
                tname = (TableName)pt.Parent.Item;

            return new TableOut(tname).Display(cmd, column.Columns, locator);
        }

    }
}
