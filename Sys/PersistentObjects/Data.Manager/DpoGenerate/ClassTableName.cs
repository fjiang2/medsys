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
        private bool hasProvider = true;

        public ClassTableName(DataProvider provider, string databaseName, string tableName)
            : base(provider, databaseName, tableName)
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

        public bool HasProvider
        {
            get { return this.hasProvider; }
        }

        public void SetProperties(Level level, bool pack, bool hasProvider)
        {
            this.level = level;
            this.pack = pack;
            this.hasProvider = hasProvider;
        }

      

        public string SubNamespace
        {
            get { return ident.Identifier(this.DatabaseName.Name); }
        }


        public string ClassName
        {
            get { return toClassName(this.tableName); }
        }


        private static string toClassName(string tableName)
        {
            string className = ident.Identifier(tableName);

            //remove plural
            if (className.EndsWith("s"))
                className = className.Substring(0, className.Length - 1);

            //Add "Dpo"
            className += Setting.DPO_CLASS_SUFFIX_CLASS_NAME;

            return className;

        }
    }
}
