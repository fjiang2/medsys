using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys;
using Sys.Data;
using Sys.Data.Manager;

namespace App.DpoCmd
{
    class Program
    {
        static void Main(string[] args)
        {
             DataProvider provider = DataProviderManager.RegisterDefaultProvider("data source=localhost\\sqlexpress;initial catalog=medsys;integrated security=SSPI;packet size=4096");

             DatabaseName databaseName = new DatabaseName(provider, "medsys");
             string[] tablenames = MetaDatabase.GetTableNames(databaseName);

             Dictionary<TableName, Type> dpoDict = new Dictionary<TableName, Type>();

            foreach (string tablename in tablenames)
             {

                 ClassTableName ctname = new ClassTableName(provider, databaseName.Name, tablename);
                 if (!dpoDict.ContainsKey(ctname))
                     continue;

                 Type ty = dpoDict[ctname];
                 string path = Library.AssemblyPath(ty.Assembly, Setting.DPO_CLASS_PATH);

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
