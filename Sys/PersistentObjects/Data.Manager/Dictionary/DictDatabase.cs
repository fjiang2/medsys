using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Sys.Data;
using Sys.PersistentObjects.DpoClass;
using Sys;

namespace Sys.Data.Manager
{
    class DictDatabase 
    {
     

        private Dictionary<string, int> bases = new Dictionary<string, int>();

        private static DictDatabase instance = null;
        
        private DictDatabase()
        {
            DataTable dt = new TableReader<dictDatabaseDpo>().Table;
            foreach (DataRow row in dt.Rows)
            {
                bases.Add((string)row[dictDatabaseDpo._name], (int)row[dictDatabaseDpo._database_id]);
            }

        }

        private int getId(string databaseName)
        {
            if (databaseName == Const.DB_SYSTEM)
                return Const.DB_SYSTEM_ID;

            //if (databaseName == Constant.DB_DEFAULT)
            //    return 2;

            if (bases.ContainsKey(databaseName))
                return bases[databaseName];
            else
                return -1;
        }

        public static DictDatabase Instance
        {
            get
            {
                if (instance == null)
                    instance = new DictDatabase();

                return instance;
            }
        }


        public static int GetId(string databaseName)
        {
#if SLOW
            dictDatabaseDpo dpo = new dictDatabaseDpo();
            dpo.name = databaseName;
            dpo.Load();

            if (dpo.Exists)
                return dpo.database_id;
            else
                return -1;
#else
            return Instance.getId(databaseName);
#endif

        }



        public static int RegisterOnly(string databaseName)
        {
            dictDatabaseDpo dpo = new dictDatabaseDpo();
            dpo.CreateTable();

            dpo.name = databaseName;
            dpo.enabled = true;
            dpo.version = Const.Revision;
            dpo.Save();

            if(!instance.bases.ContainsKey(databaseName))
                instance.bases.Add(databaseName, dpo.database_id);

            return dpo.database_id;
        }



        public static int Register(string databaseName)
        {
            int database_id = DictDatabase.RegisterOnly(databaseName);

            string[] names = MetaDatabase.GetTableNames(databaseName);
            foreach (string name in names)
                DictTable.Register(database_id, new TableName(databaseName, name));

            return names.Length;

        }
    }
}
