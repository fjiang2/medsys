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
        private string namePattern;

        public readonly DatabaseName DatabaseName;
        public readonly string[] Excludedtables;

        public MatchedDatabase(DatabaseName databaseName, string namePattern, string[] excludedtables)
        {
            this.namePattern = namePattern;
            this.DatabaseName = databaseName;
            
            if(excludedtables != null)
                this.Excludedtables = excludedtables.Select(row => row.ToUpper()).ToArray(); ;
        }


        public string[] MatchedTableNames
        {
            get
            {
                if (namePattern == null)
                    return null;

                var names = Search(namePattern, this.DatabaseName.GetDependencyTableNames());
                return names;
            }
        }

        public string[] DefaultTableNames
        {
            get
            {
                string[] names = this.DatabaseName.GetTableNames();

                names = names.Where(name => Includes(name)).ToArray();
                if (namePattern == null)
                    return names;

                names = Search(namePattern, names);

                return names;
            }
        }

        public string[] DefaultViewNames
        {
            get
            {
                string[] names = this.DatabaseName.GetViewNames();

                names = names.Where(name => Includes(name)).ToArray();
                if (namePattern == null)
                    return names;

                names = Search(namePattern, names);

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
