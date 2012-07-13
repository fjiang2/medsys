using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys.Data;

namespace Sys.Data.Manager
{
    public sealed class ClassTableName : TableName
    {
        private Level level = Level.Fixed;
        private bool pack = true;

        public ClassTableName(string databaseName, string tableName)
            : base(databaseName, tableName)
        { 
        
        }

        public Level Level
        {
            get { return this.level; }
        }

        public bool Pack
        {
            get { return this.pack; }
        }

        public void SetLevel(Level level, bool pack)
        {
            this.level = level;
            this.pack = pack;
        }

        private static string Identifier(string s)
        {
            return s.Replace("-", "_").Replace(" ", "_").Replace("$", "_");
        }

        public string SubNamespace
        {
            get { return Identifier(this.DatabaseName); }
        }


        public string ClassName
        {
            get { return toClassName(this.tableName); }
        }


        private static string toClassName(string tableName)
        {
            string className = Identifier(tableName);

            //remove plural
            if (className.EndsWith("s"))
                className = className.Substring(0, className.Length - 1);

            //Add "Dpo"
            className += "Dpo";

            return className;

        }
    }
}
