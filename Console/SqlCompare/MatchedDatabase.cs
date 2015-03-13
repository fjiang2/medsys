using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Sys.Data;

namespace SqlCompare
{
    class MatchedDatabase  
    {
        private string tableNamePattern;

        public readonly DatabaseName DatabaseName;
        public readonly string[] Excludedtables;

        public MatchedDatabase(DatabaseName databaseName, string tableNamePattern, string[] excludedtables)
        {
            this.tableNamePattern = tableNamePattern;
            this.DatabaseName = databaseName;
            
            if(excludedtables != null)
                this.Excludedtables = excludedtables.Select(row => row.ToUpper()).ToArray(); ;
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

        public bool Includes(string tableName)
        {
            if (Excludedtables == null)
                return true;

              return !Excludedtables.Contains(tableName.ToUpper());
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
