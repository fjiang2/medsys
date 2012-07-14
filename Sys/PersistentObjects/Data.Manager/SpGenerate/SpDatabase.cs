﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Sys.Data;

namespace Sys.Data.Manager
{
    public class SpDatabase
    {
        public const string SP_NAME = "name";
        public const string SP_DEFINITION = "sp";

     
        private string databaseName;
        private string path;

        public SpDatabase(string databaseName, string path)
        {
            this.databaseName = databaseName;
            this.path = string.Format("{0}\\{1}",path, databaseName);

            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }
        }

        public int Generate(string nameSpace, string sa, string password)
        {
            string SQL = @"
            USE {0}
            SELECT name, OBJECT_DEFINITION(OBJECT_ID) AS sp
            FROM sys.procedures
            WHERE is_ms_shipped <> 1
            ORDER BY name
            ";

            SqlCmd cmd = new SqlCmd(SQL, databaseName);
            cmd.ChangeConnection(sa, password);
            DataTable dt = cmd.FillDataTable();
            
            
            foreach (DataRow row in dt.Rows)
            {
                SpProc proc = new SpProc(databaseName, (string)row[SP_NAME], row[SP_DEFINITION].IsNull<string>(""));
                
                string sourceCode = proc.Proc(nameSpace, databaseName, sa, password);
                WriteFile(proc.SpName, sourceCode, nameSpace, proc.IsSpChanged(nameSpace, databaseName));
            }
            
            return dt.Rows.Count;
        }


        private bool WriteFile(string spName, string sourceCode, string nameSpace, bool isSpChanged)
        {
            string fileName = string.Format("{0}\\{1}.cs",path, spName);
            
            if (File.Exists(fileName))
            {
                if ((File.GetAttributes(fileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)    //this file is not checked out
                {
                    if (isSpChanged)
                        throw new SysException("Stored Procedure {0}..{1} is modified, please check out class {2}.{3} to refresh", databaseName, spName, nameSpace, databaseName);

                    return false;
                }
            }

            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(sourceCode);
            sw.Close();


            return true;
        }
    }
}