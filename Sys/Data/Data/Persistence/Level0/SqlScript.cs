using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sys.Data
{
    public class SqlScript
    {
        private string scriptFile;
        private ConnectionProvider provider;

        public event EventHandler<EventArgs<int, string>> Reported;
        public event EventHandler<EventArgs> Completed;
        public event EventHandler<EventArgs<string>> Err;

        public SqlScript(ConnectionProvider provider, string scriptFile)
        {
            this.provider = provider;
            this.scriptFile = scriptFile;

            if (!File.Exists(scriptFile))
                throw new FileNotFoundException("cannot find file", scriptFile);
        }

        protected void OnReported(EventArgs<int, string> e)
        {
            if (Reported != null)
                Reported(this, e);
        }

        protected void OnCompleted(EventArgs e)
        {
            if (Completed != null)
                Completed(this, e);
        }

        protected void OnError(EventArgs<string> e)
        {
            if (Err != null)
                Err(this, e);
        }


       

        public void Execute()
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;

            using (var reader = new StreamReader(scriptFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    i++;

                    string formatedLine = line.Trim();
                    string upperLine = formatedLine.ToUpper();
                    if (upperLine.StartsWith("INSERT")
                        || upperLine.StartsWith("UPDATE")
                        || upperLine.StartsWith("DELETE")
                        || upperLine.StartsWith("CREATE")
                        || upperLine.StartsWith("DROP")
                        || upperLine.StartsWith("ALTER")
                        || upperLine.StartsWith("GO")
                        )
                    {
                        string sql = builder.ToString();
                        if (!string.IsNullOrEmpty(sql))
                        {
                            new SqlCmd(provider, sql).ExecuteNonQuery();
                            OnReported(new EventArgs<int, string>(i, sql));
                        }

                        builder.Clear();
                        if (!upperLine.StartsWith("GO"))
                            builder.AppendLine(line);
                    }
                    else if (formatedLine != string.Empty)
                    {
                        builder.AppendLine(line);
                    }
                }
            }

            if (builder.Length != 0)
            {
                string sql = builder.ToString();
                new SqlCmd(provider, sql).ExecuteNonQuery();
                OnReported(new EventArgs<int, string>(i, sql));
            }

            OnCompleted(new EventArgs());
        }




        public void ExecuteTransaction(string[] clauses)
        {
            using (SqlConnection connection = (SqlConnection)provider.NewDbConnection)
            {
                connection.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    // Execute two separate commands.
                    foreach (string clause in clauses)
                    {
                        command.CommandText = clause;
                        command.ExecuteNonQuery();
                    }

                    // Commit the transaction.
                    sqlTran.Commit();

                    OnCompleted(new EventArgs());
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    OnError(new EventArgs<string>(ex.Message));

                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        // Throws an InvalidOperationException if the connection 
                        // is closed or the transaction has already been rolled 
                        // back on the server.
                        OnError(new EventArgs<string>(exRollback.Message));
                    }
                }
            }

        }

    }


}
