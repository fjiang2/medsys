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


        private Dictionary<DatabaseName, int> bases = new Dictionary<DatabaseName, int>();

        private static DictDatabase instance = null;
        
        private DictDatabase()
        {
            DataTable dt = new TableReader<dictDatabaseDpo>().Table;
            foreach (DataRow row in dt.Rows)
            {
                DataProvider provider = new DataProvider((int)row[dictDatabaseDpo._provider_id]);
                DatabaseName databaseName = new DatabaseName(provider, (string)row[dictDatabaseDpo._name]);
                bases.Add(databaseName, (int)row[dictDatabaseDpo._database_id]);
            }

        }

        private int getId(DatabaseName databaseName)
        {
            if (databaseName.Provider.Equals(DataProvider.DefaultProvider) 
                && databaseName.Name == Const.DB_SYSTEM)
                
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


        public static int GetId(DatabaseName databaseName)
        {
#if SLOW
            dictDatabaseDpo dpo = new dictDatabaseDpo();
            dpo.name = databaseName.Name;
            dpo.provider_id = databaseName.Provider.Handle;
            dpo.Load();

            if (dpo.Exists)
                return dpo.database_id;
            else
                return -1;
#else
            return Instance.getId(databaseName);
#endif

        }



        public static int RegisterOnly(DatabaseName databaseName)
        {
            dictDatabaseDpo dpo = new dictDatabaseDpo();
            dpo.CreateTable();

            dpo.name = databaseName.Name;
            dpo.provider_id = (int)databaseName.Provider;
            dpo.enabled = true;
            dpo.version = Const.Revision;
            dpo.Save();

            if(!instance.bases.ContainsKey(databaseName))
                instance.bases.Add(databaseName, dpo.database_id);

            return dpo.database_id;
        }



        public static int Register(DatabaseName databaseName)
        {
            int database_id = DictDatabase.RegisterOnly(databaseName);

            string[] names = MetaDatabase.GetTableNames(databaseName);
            foreach (string name in names)
                DictTable.Register(database_id, new TableName(databaseName.Name, name));

            return names.Length;

        }
    }
}
