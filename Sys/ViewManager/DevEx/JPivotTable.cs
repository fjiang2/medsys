using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Sys.ViewManager.DevEx
{
    public enum PivotArea
    {
        // Summary:
        //     Corresponds to the Row Header Area.
        RowArea = 0,
        //
        // Summary:
        //     Corresponds to the Column Header Area.
        ColumnArea = 1,
        //
        // Summary:
        //     Corresponds to the Filter Header Area.
        FilterArea = 2,
        //
        // Summary:
        //     Corresponds to the Data Header Area.
        DataArea = 3,
    }

    public delegate object PivotGroupInterval(object data);
    public delegate object PivotAggregatedFunction(object data);

    public class PivotField
    { 
        private PivotArea area = PivotArea.FilterArea;
        private DataColumn dataColumn;
        
        public PivotGroupInterval groupInterval;
        public PivotAggregatedFunction PivotAggregatedFunction;

        public PivotField(DataColumn dataColumn, PivotArea pivotArea)
        {
            this.dataColumn = dataColumn;
            this.area = pivotArea;
        }
        
        public DataColumn DataColumn
        {
            get { return dataColumn; }
            set { dataColumn = value; }
        }

        public PivotArea Area
        {
            get { return area;}
            set { area = value;}
        }


    }

    public class JPivotTable2
    {

        DataTable dataTable;
        Dictionary<string, PivotField> fields = new Dictionary<string, PivotField>();

      

        public JPivotTable2(DataTable dataTable)
        {
            this.dataTable = dataTable;
            
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                PivotField field = new PivotField(dataColumn, PivotArea.FilterArea);
                fields.Add(dataColumn.ColumnName, field);
            }
        }


        public Dictionary<string, PivotField> Fields
        {
            get { return fields; }
        }

        public PivotField[] RowFields
        { 
            get 
            {
                List<PivotField> list = new List<PivotField>();
                foreach (KeyValuePair<string, PivotField> kvp in fields)
                {
                    if (kvp.Value.Area == PivotArea.RowArea)
                        list.Add(kvp.Value);
                }
                return list.ToArray();

            }
        }

        public PivotField[] ColumnFields
        {
            get
            {
                List<PivotField> list = new List<PivotField>();
                foreach (KeyValuePair<string, PivotField> kvp in fields)
                {
                    if (kvp.Value.Area == PivotArea.ColumnArea)
                        list.Add(kvp.Value);
                }
                return list.ToArray();

            }
        }

        public PivotField[] DataFields
        {
            get
            {
                List<PivotField> list = new List<PivotField>();
                foreach (KeyValuePair<string, PivotField> kvp in fields)
                {
                    if (kvp.Value.Area == PivotArea.DataArea)
                        list.Add(kvp.Value);
                }
                return list.ToArray();

            }
        }




        private DataTable CreateStructure()
        {
            DataTable dt = new DataTable();

            foreach (PivotField columnField in ColumnFields)
            { 
            
            
            }

            return dt;
        }


    }








    #region OLD Version
    public class JPivotTable
    {
        DataTable dataTable;
        string rowField;
        string columnField;
        string dataField;
        Type columnType;

         
        public JPivotTable(DataTable dataTable, string rowField, string columnField, string dataField)
        {
            this.dataTable = dataTable;
            this.rowField = rowField;
            this.columnField = columnField;
            this.dataField = dataField;

            this.columnType = dataTable.Columns[columnField].DataType;
        }


        private DataTable CreateStructure()
        {

            DataTable dt = new DataTable();
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                if (   dataColumn.ColumnName != columnField 
                    && dataColumn.ColumnName != dataField)
                    dt.Columns.Add(new DataColumn(dataColumn.ColumnName, dataColumn.DataType));
            }

            Type cellType = dataTable.Columns[dataField].DataType;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                DataColumn dataColumn = DataAreaColumn(dataRow);
                dataColumn.DataType = cellType;

                if (!dt.Columns.Contains(dataColumn.ColumnName))
                    dt.Columns.Add(dataColumn);

            }
            return dt;
        }


        
        private DataColumn DataAreaColumn(DataRow dataRow)
        {
            string columnName = dataRow[columnField].ToString();
            string caption = columnName;
 
            if (columnType == typeof(DateTime))
            {
                DateTime dateTime = (DateTime)dataRow[columnField];
                columnName = dateTime.ToShortDateString();
                caption = columnName;
            }

            DataColumn dataColumn = new DataColumn(columnName);
            dataColumn.Caption = caption;
            return dataColumn;
        }

        public DataTable GenerateDataTable()
        {
            DataTable dt = CreateStructure();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                DataRow[] dataRows = dt.Select(string.Format("{0}='{1}'",rowField, dataRow[rowField]));
                DataRow newRow;
                if (dataRows.Length == 0)
                {
                    newRow = dt.NewRow();
                    foreach (DataColumn dataColumn in dataTable.Columns)
                    {
                        if (dataColumn.ColumnName != columnField && dataColumn.ColumnName != dataField)
                            newRow[dataColumn.ColumnName] = dataRow[dataColumn.ColumnName];
                    }
                    dt.Rows.Add(newRow);
                }
                else
                    newRow = dataRows[0];

                newRow[DataAreaColumn(dataRow).ColumnName] = dataRow[dataField];

            }

            return dt;
        }


    }
    #endregion
}
