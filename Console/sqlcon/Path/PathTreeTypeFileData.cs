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

            if (cmd.wildcard != null)
            {
                string wildcard = cmd.wildcard.Replace("*", "%").Replace("?", "_");
                if (cmd.column == null)
                {
                    stdio.ShowError("column not found");
                    return false;
                }

                string where = string.Format("{0} LIKE '{1}'", cmd.column, wildcard);

                var builder = new SqlBuilder().SELECT.COLUMNS().FROM(tname).WHERE(where);

                try
                {
                    DataTable table = builder.SqlCmd.FillDataTable();
                    if (cmd.IsVertical)
                        table.ToVConsole();
                    else
                        table.ToConsole();
                }
                catch (Exception ex)
                {
                    stdio.ShowError(ex.Message);
                    return false;
                }
            }
            else if (cmd.where != null)
            {
                try
                {
                    var locator = new Locator(cmd.where);
                    DataTable table = new SqlBuilder().SELECT.TOP(cmd.top).COLUMNS().FROM(tname).WHERE(locator).SqlCmd.FillDataTable();
                    if (cmd.IsVertical)
                        table.ToVConsole();
                    else
                        table.ToConsole();
                    return true;
                }
                catch (Exception ex)
                {
                    stdio.ShowError(ex.Message);
                    return false;
                }
            }
            else
            {
                var builder = new SqlBuilder().SELECT.TOP(cmd.top).COLUMNS().FROM(tname);
                DataTable table = builder.SqlCmd.FillDataTable();
                if (cmd.IsVertical)
                    table.ToVConsole();
                else
                    table.ToConsole();
            }
            return true;
        }


        private bool TypeLocatorData(TreeNode<IDataPath> pt, Command cmd)
        {
            if (!(pt.Item is Locator))
                return false;

            TableName tname = this.GetCurrentPath<TableName>();
            Locator locator = new Locator((Locator)pt.Item);

            var xnode = pt;
            while (xnode.Parent.Item is Locator)
            {
                xnode = xnode.Parent;
                locator.And((Locator)xnode.Item);
            }

            try
            {
                DataTable table = new SqlBuilder().SELECT.TOP(cmd.top).COLUMNS().FROM(tname).WHERE(locator).SqlCmd.FillDataTable();
                if (cmd.IsVertical)
                    table.ToVConsole();
                else
                    table.ToConsole();
                return true;
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
                return false;
            }

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

            try
            {

                SqlBuilder builder;
                if (cmd.wildcard == null)
                {
                    builder = new SqlBuilder().SELECT.TOP(cmd.top).COLUMNS(column.Columns).FROM(tname);
                    if (locator != null)
                        builder.WHERE(locator);
                }
                else
                {
                    string columnName = cmd.column;
                    string wildcard = cmd.wildcard.Replace("*", "%").Replace("?", "_");
                    if (columnName == null)
                    {
                        stdio.ShowError("column not found");
                        return false;
                    }

                    string where = string.Format("{0} LIKE '{1}'", columnName, wildcard);
                    if (locator != null)
                        where = string.Format("({0}) AND ({1})", locator.Path, where);


                    builder = new SqlBuilder().SELECT.TOP(cmd.top).COLUMNS(column.Columns).FROM(tname).WHERE(where);
                }

                DataTable table = builder.SqlCmd.FillDataTable();
                if (cmd.IsVertical)
                    table.ToVConsole();
                else
                    table.ToConsole();

                return true;
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
                return false;
            }
        }

    }
}
