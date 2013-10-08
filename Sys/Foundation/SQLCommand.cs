using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sys.Data
{
    public class SQLCommand : SqlCmd
    {
        public delegate void DataSetLoadedCallback(DataSet dataSet, object arg);
        public delegate void DataSetLoadingCallback(DataRow dataRow);
        private delegate DataSet RetrieveDataSetDelegate(Control sender, SQLCommand cmd);

        public event DataSetLoadedCallback DataSetLoaded;
        public event DataSetLoadingCallback DataRowLoading;
        
        

        public bool LoadDataTableCancelled = false;
        private bool isDataLoaded = false;


        public SQLCommand(DataProvider provider, string script)
            : base(provider, script)
        { 
        
        }



        public void StartLoadingDataSet(Control sender, object args)
        {
            RetrieveDataSetDelegate work = new RetrieveDataSetDelegate(RetrieveDataSet);
            work.BeginInvoke(sender, this, new AsyncCallback(DataSetRetrieved), new object[] { sender, work, args });
        }


        private DataSet RetrieveDataSet(Control sender, SQLCommand cmd)
        {
            try
            {
                return cmd.ReadDataSet(sender);
                //return cmd.FillDataTable();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {

            }
        }

        private void DataSetRetrieved(IAsyncResult ar)
        {
            object[] o = (object[])ar.AsyncState;

            Control sender = (Control)o[0];
            RetrieveDataSetDelegate work = (RetrieveDataSetDelegate)o[1];
            object args = o[2];

            DataSet dataSet = work.EndInvoke(ar);

            if (dataSet == null)
                return;


            if (DataSetLoaded != null)
            {
                if (isDataLoaded)
                    return;

                if (!sender.IsDisposed)
                    sender.Invoke(DataSetLoaded, new object[] { dataSet, args });

                isDataLoaded = true; 
            }

        }







        public DataSet ReadDataSet(Control sender)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable;
            SqlDataReader reader = null;

            try
            {
                connection.Open();

                using (connection)
                {
                    reader = ((SqlCommand)this.command).ExecuteReader();
                    
                    do
                    {
                        DataTable schemaTable = reader.GetSchemaTable();

                        if (schemaTable == null)
                            break;

                        dataTable = new DataTable();
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            DataColumn column = new DataColumn();
                            column.ColumnName = (string)row["ColumnName"];
                            column.DataType = (Type)row["DataType"];
                            dataTable.Columns.Add(column);
                        }

                        dataSet.Tables.Add(dataTable);

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (LoadDataTableCancelled)
                                    break;

                                DataRow x = dataTable.NewRow();
                                foreach (DataColumn column in dataTable.Columns)
                                    x[column.ColumnName] = reader[column.ColumnName];
                                dataTable.Rows.Add(x);


                                if (DataRowLoading != null)
                                {
                                    if (!sender.IsDisposed)
                                        sender.Invoke(DataRowLoading, new object[] { x});
                                }
                            }

                            dataTable.AcceptChanges();
                        }


                    }  while (reader.NextResult());


                    

                }

                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(reader!=null)
                    reader.Close();

                connection.Close();
            }

            return null;
        }
    
    }
}
