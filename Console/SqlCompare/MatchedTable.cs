using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Sys.Data;

namespace SqlCompare
{
    class MatchedTable : stdio
    {
        private string tableNamePattern;

        public readonly DatabaseName DatabaseName;

        public MatchedTable(DatabaseName databaseName, string tableNamePattern)
        {
            this.tableNamePattern = tableNamePattern;
            this.DatabaseName = databaseName;
        }


        public string[] MatchedTableNames
        {
            get
            {
                if (tableNamePattern == null)
                    return null;

                var names = Search(tableNamePattern, this.DatabaseName.GetDependencyTableNames());
                return names;
            }
        }

        public string[] DefaultTableNames
        {
            get
            {
                string[] names = this.DatabaseName.GetTableNames();
                if (tableNamePattern == null)
                    return names;

                names = Search(tableNamePattern, names);

                return names;
            }
        }



        public static string[] Search(string pattern, string[] tableNames)
        {
            string x = "^" + Regex.Escape(pattern)
                                  .Replace(@"\*", ".*")
                                  .Replace(@"\?", ".")
                           + "$";

            Regex regex = new Regex(x, RegexOptions.IgnoreCase);
            var result = tableNames.Where(row => regex.IsMatch(row)).ToArray();

            return result;
        }


   
    }
}
