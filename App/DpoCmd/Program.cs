using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Sys;
using Sys.Data;
using Sys.Data.Manager;
using Sys.CodeBuilder;

namespace App.DpoCmd
{
    class Program
    {

      
        static void Main(string[] args)
        {
            DataTable table = new DataTable();
            table.TableName = "DEMO";

            table.Columns.Add("TOTAL", typeof(string));
            table.Columns.Add("OK", typeof(string));
            table.Columns.Add("OKPERC", typeof(string));
            table.Columns.Add("FAIL", typeof(string));
            table.Columns.Add("FAILPERC", typeof(string));

            table.Columns.Add("PATTERNSTR", typeof(string));
            table.Columns.Add("PATTERN_NO", typeof(int));
            table.Columns.Add("CYCLESTR", typeof(string));
            table.Columns.Add("CYCLE_NO", typeof(int));
            table.Columns.Add("OFFSETSTR", typeof(string));
            table.Columns.Add("SEQSTR", typeof(string));
            table.Columns.Add("PREEMPTSTR", typeof(string));

            table.Columns.Add("TBC", typeof(string));
            table.Columns.Add("LocalCounter", typeof(string));

            table.Columns.Add("MODESTR", typeof(string));
            table.Columns.Add("SPLITINDEXSTR", typeof(string));


            table.GenTableDpo("C:\\temp", new ClassName("AVL", AccessModifier.Public, "Fake"));
        }

        static void Main1(string[] args)
        {
             ConnectionProvider provider = ConnectionProviderManager.RegisterDefaultProvider("data source=localhost\\sqlexpress;initial catalog=medsys;integrated security=SSPI;packet size=4096");

             DatabaseName databaseName = new DatabaseName(provider, "medsys");
             TableName[] tablenames = databaseName.GetTableNames();

             Dictionary<TableName, Type> dpoDict = new Dictionary<TableName, Type>();

            foreach (var tablename in tablenames)
             {

                 ClassTableName ctname = new ClassTableName(provider, databaseName.Name, tablename.Name);
                 if (!dpoDict.ContainsKey(ctname))
                     continue;

                 Type ty = dpoDict[ctname];
                 string path = ""; // Library.AssemblyPath(ty.Assembly, Setting.DPO_CLASS_PATH);

                 DPObject dpo = (DPObject)Activator.CreateInstance(ty);
                 ClassName cname = new ClassName(dpo);
                 ctname.SetProperties(dpo.Level, dpo.IsPack, dpo.HasProvider);

                 string output = "";
                 if (ctname.GenTableDpo(path, true, cname, true, dpoDict))
                     output += string.Format("class {0} is upgraded from table {1} at {2}\r\n", cname, ctname, path);
                 else
                     output += string.Format("class {0} is skipped from table {1}\r\n", cname, ctname);

                 Console.WriteLine(output);
             }
        }
    }
}
