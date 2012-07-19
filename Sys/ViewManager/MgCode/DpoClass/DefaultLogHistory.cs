using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;
using Sys.Foundation.DpoClass;
using System.Data;
using Tie;

namespace Sys.ViewManager.DpoClass
{
    public class DefaultLogHistory 
    {
        private DataTable history;
        private DPObject dpo;

        private List<string> changedFields = new List<string>();

  

        /// <summary>
        /// Construct Log History DataTable
        /// </summary>
        /// <param name="dpo"></param>
        public DefaultLogHistory(DPObject dpo)
            :this(dpo, 0)
        {
        }

        /// <summary>
        /// Construct Log History DataTable
        /// </summary>
        /// <param name="dpo"></param>
        /// <param name="count">Retrieve latest number of records</param>
        public DefaultLogHistory(DPObject dpo, int count)
        {
            this.dpo = dpo;

            history = SqlCmd.FillDataTable(@"
                SELECT  {0}
                        u.User_name, 
                        u.First_Name, 
                        u.Last_Name, 
                        ds.date, 
                        ds.form_name, 
                        dt.*
                FROM {1} dt
                INNER JOIN {2} ds ON dt.log_dataset_id = ds.log_dataset_id
                INNER JOIN {3} u ON u.User_ID = ds.user_id
                WHERE table_name = '{4}' AND row_id = {5}
                ORDER BY date DESC
                ",
                 (count <= 0) ? "" : "TOP " + count,
                logDataTableDpo.TABLE_NAME, 
                logDataSetDpo.TABLE_NAME,
                UserDpo.TABLE_NAME,
                dpo.TableName, 
                dpo.RowId
                );

        }

        private bool showEditing = false;
        public bool ShowEditingRow
        {
            get
            {
                return this.showEditing;
            }
            set
            {
                this.showEditing = value;
            }
        }


        private DataTable CreateHistoryTable(out DataRow currentRow)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("User_name", typeof(string));
            dt.Columns.Add("First_Name", typeof(string));
            dt.Columns.Add("Last_Name", typeof(string));
            dt.Columns.Add("date", typeof(DateTime));
            dt.Columns.Add("action", typeof(string));

            foreach (DataColumn dataColumn in dt.Columns)
                changedFields.Add(dataColumn.ColumnName);

            dt.Columns.Add("form_name", typeof(string));


            DataRow editingRow = dpo.Row;    //current data row in memeory
            foreach (DataColumn dataColumn in editingRow.Table.Columns)
            {
                dt.Columns.Add(dataColumn.ColumnName, dataColumn.DataType);
            }
            
            if(showEditing)
                AddRow(dt, editingRow, "Editing");    //this row is not saved, it is in the memory

            currentRow = dpo.Load();              // latest data row in SQL server
            foreach (DataColumn c in currentRow.Table.Columns)
            {
                if(!editingRow[c.ColumnName].Equals(currentRow[c.ColumnName]))
                {
                    if (changedFields.IndexOf(c.ColumnName) == -1)
                    changedFields.Add(c.ColumnName);
                }
            }

            return dt;
        }

        /// <summary>
        /// is it column value changed?
        /// </summary>
        /// <param name="columName"></param>
        /// <returns></returns>
        public bool ColumnLogged(string columName)
        {
            return changedFields.IndexOf(columName) >= 0;
        }

        public List<string> ChangedColumns
        {
            get
            {
                return this.changedFields;
            }
        }


        public DataTable HistoryTable()
        {
            DataRow current;      
            DataTable historyTable = CreateHistoryTable(out current);

            foreach(DataRow logRow in history.Rows)
            {
                DataRow historyRow = AddRow(historyTable, logRow, current);

                current = NextRow(current, (string)logRow["value_from"]);
            }

            if (current != null)
            {
                if (history.Rows.Count > 0)                         //dataRow is not logged when dataRow was inserted.
                    AddRow(historyTable, current, "Unknown");
                else                                                //no log history
                {
                    AddRow(historyTable, current, "No history");
                }
            }
                

            return historyTable;
        }


        /// <summary>
        /// Coonstruct next history data row based on value_from
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="value_from"></param>
        /// <returns></returns>
        private DataRow NextRow(DataRow dataRow, string value_from)
        {
            DataRow nextRow = dataRow.Clone();

            VAL L = Script.Evaluate(value_from);
            if (L.IsNull)                   //inserted row
                return null;

            foreach (VAL l in L)
            {
                string fieldName = l[0].Str;
                object fieldValue = l[1].HostValue;

                nextRow[fieldName] = fieldValue;

                if (changedFields.IndexOf(fieldName) == -1)
                    changedFields.Add(fieldName);
            }
            

            return nextRow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="historyTable"></param>
        /// <param name="dataRow"></param>
        /// <returns>History Row</returns>
        private DataRow AddRow(DataTable historyTable, DataRow logRow, DataRow dataRow)
        {
            DataRow historyRow = historyTable.NewRow();

            foreach (DataColumn c in dataRow.Table.Columns)
                if (historyTable.Columns.Contains(c.ColumnName))
                    historyRow[c.ColumnName] = dataRow[c.ColumnName];

            if (logRow != null)
            {
                foreach (DataColumn c in logRow.Table.Columns)
                    if (historyRow.Table.Columns.Contains(c.ColumnName))
                        historyRow[c.ColumnName] = logRow[c.ColumnName];
            }

            historyTable.Rows.Add(historyRow);

            return historyRow;
        }

        private DataRow AddRow(DataTable historyTable, DataRow dataRow, string action)
        {
            DataRow historyRow =  AddRow(historyTable, null, dataRow);
            historyRow["action"] = action;
            return historyRow;
        }

    
    }
}
