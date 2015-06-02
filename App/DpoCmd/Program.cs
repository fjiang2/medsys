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
using System.Reflection;
using System.IO;

namespace App.DpoCmd
{
    class Program
    {

        static void Main()
        {
            ConnectionProvider provider = ConnectionProviderManager.RegisterDefaultProvider("data source=localhost\\sqlexpress;initial catalog=northwind;integrated security=SSPI;packet size=4096");

            ServerName sname = new ServerName(provider);
            DatabaseName dname = new DatabaseName(sname, "northwind");
            string path = "D:\\devel\\GitHub\\medsys\\App\\DpoCmd";

            TableName tname = new TableName(dname, TableName.dbo, "Products");
            ClassTableName ctname = new ClassTableName(tname) 
            { 
                Level = Level.Application 
            };

            ClassName cname = new ClassName("Northwind", AccessModifier.Public, tname.Name);
            DpoGenerator gen = new DpoGenerator(ctname, tname.GetSchema(), cname)
            {
                HasTableAttribute = true,
                HasColumnAttribute = true,
                RegisterTable = false,
                OutputPath = path
            };

            gen.Generate();
            bool result = gen.Save();

        }
      
        static void Main1(string[] args)
        {
            DataTable table = new DataTable();
            table.TableName = "Fruit";

            table.Columns.Add("Apple", typeof(string));
            table.Columns.Add("Orange", typeof(string));
            table.Columns.Add("Apple Tree", typeof(string));

            table.Columns.Add("Number", typeof(int));
            table.Columns.Add("Flag", typeof(bool));

            table.GenTableDpo("D:\\devel\\GitHub\\medsys\\App\\DpoCmd", new ClassName("Fruit", AccessModifier.Public, table.TableName));
        }

       
    }
}
