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
        private UniqueTable rTable = null;

        public TableOut(TableName tableName)
        {
            this.tname = tableName;
        }

        public TableName TableName
        {
            get { return this.tname; }
        }

        public UniqueTable Table
        {
            get { return this.rTable; }
        }


        public bool HasPhysloc
        {
            get
            {
                if (this.rTable == null)
                    return false;

                return rTable.HasPhysloc;
            }
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


        private bool Display(Command cmd, SqlBuilder builder)
        {
            try
            {
                DataTable table = builder.SqlCmd.FillDataTable();
                rTable = new UniqueTable(tname, table);
                _DisplayTable(rTable.Table, cmd.IsVertical);
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
                builder = new SqlBuilder().SELECT.ROWID(cmd.HasRowId).COLUMNS().FROM(tname).WHERE(where);
            }
            else if (cmd.where != null)
            {
                var locator = new Locator(cmd.where);
                builder = new SqlBuilder().SELECT.TOP(top).ROWID(cmd.HasRowId).COLUMNS(columns).FROM(tname).WHERE(locator);
            }
            else
                builder = new SqlBuilder().SELECT.TOP(top).ROWID(cmd.HasRowId).COLUMNS(columns).FROM(tname);

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


    }
}
