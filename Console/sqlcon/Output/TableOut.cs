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
    class TableOut
    {
        private TableName tname;

        public TableOut(TableName tableName)
        {
            this.tname = tableName;
        }

        private string LikeExpr(string wildcard, string[] columns)
        {
            wildcard = wildcard.Replace("*", "%").Replace("?", "_");

            if (columns.Length == 0)
            {
                var schema = new TableSchema(tname);
                List<string> L = new List<string>();
                foreach (var c in schema.Columns)
                {
                    if (c.CType == CType.NVarChar || c.CType == CType.NChar || c.CType == CType.NText)
                        L.Add(c.ColumnName);
                }
                columns = L.ToArray();
            }

            string where = "";
            foreach (string column in columns)
            {
                if (where != "")
                    where += " OR ";
                where += string.Format("[{0}] LIKE '{1}'", column, wildcard);
            }

            return where;
        }

        private static void _DisplayTable(DataTable table, bool vert)
        {
            if (table == null)
                return;

            if (vert)
                table.ToVConsole();
            else
                table.ToConsole();
        }

        private static bool Display(Command cmd, SqlBuilder builder)
        {
            try
            {
                DataTable table = builder.SqlCmd.FillDataTable();
                List<byte[]> L = PhyslocTable(table);
                _DisplayTable(table, cmd.IsVertical);
            }
            catch (Exception ex)
            {
                stdio.ShowError(ex.Message);
                return false;
            }

            return true;
        }


        public bool Display(Command cmd)
        {
            SqlBuilder builder;
            int top = cmd.top;
            string[] columns = cmd.Columns;

            if (cmd.wildcard != null)
            {
                string where = LikeExpr(cmd.wildcard, cmd.Columns);
                builder = new SqlBuilder().SELECT.ROWID.COLUMNS().FROM(tname).WHERE(where);
            }
            else if (cmd.where != null)
            {
                var locator = new Locator(cmd.where);
                builder = new SqlBuilder().SELECT.TOP(top).ROWID.COLUMNS(columns).FROM(tname).WHERE(locator);
            }
            else
                builder = new SqlBuilder().SELECT.TOP(top).ROWID.COLUMNS(columns).FROM(tname);

            return Display(cmd, builder);
        }

      
        public bool Display(Command cmd, string columns, Locator locator)
        {
            SqlBuilder builder;
            if (cmd.wildcard == null)
            {
                builder = new SqlBuilder().SELECT.TOP(cmd.top).COLUMNS(columns).FROM(tname);
                if (locator != null)
                    builder.WHERE(locator);
            }
            else
            {
                string where = LikeExpr(cmd.wildcard, cmd.Columns);
                if (locator != null)
                    where = string.Format("({0}) AND ({1})", locator.Path, where);

                builder = new SqlBuilder().SELECT.COLUMNS(columns).FROM(tname).WHERE(where);
            }

            return Display(cmd, builder);
        }


        public static List<byte[]> PhyslocTable(DataTable table)
        {

            int i = 0;
            int index = -1;
            DataColumn C1 = null;
            foreach (DataColumn column in table.Columns)
            {
                if (column.ColumnName == SqlExpr.PHYSLOC)
                {
                    C1 = column;
                    index = i;
                    break;
                }

                i++;
            }

            if (C1 == null)
                return null;


            List<byte[]> L = new List<byte[]>();
            i = 1;
            foreach (DataRow row in table.Rows)
            {
                L.Add((byte[])row[index]);
                row[index + 1] = i++;
            }

            table.Columns.Remove(C1);

            return L;
        }
    }
}
