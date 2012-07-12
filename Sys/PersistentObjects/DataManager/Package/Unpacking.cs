using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Sys;
using Sys.Data;
using Sys.PersistentObjects.Dpo;

namespace Sys.DataManager
{
 

    public class Unpacking
    {

        public static void Unpack(Level level, Worker worker, bool insert)
        {
            SqlTrans transaction = new SqlTrans();

            Assembly[] assemblies = SysExtension.GetInstalledAssemblies();
            
            int i = 0;
            foreach (Assembly asm in assemblies)
            {
                int progress = (int)(i * 100.0 / assemblies.Length);
                worker.SetProgress(progress, 0, asm.GetName().Name);

                Unpack(level, asm, worker, transaction, insert);
                
                i++;
            }

            transaction.Commit();

            return;
        }

        private static void Unpack(Level level, Assembly asm, Worker worker, SqlTrans transaction, bool insert)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Type type in asm.GetExportedTypes())
            {
                if (type.HasInterface<IPacking>() && type != typeof(BasePackage<>))
                {
                    IPacking packing = (IPacking)Activator.CreateInstance(type);
                    if (level == packing.Level)
                    {
                        worker.SetProgress(0, string.Format("Unpacking #record={0} of table [{1}].", packing.Count, packing.TableName));
                        packing.Unpack(worker, transaction, insert);
                    }
                }
            }

            return;
        }


        public static void Unpack(Assembly asm, bool insert)
        {
            SqlTrans transaction = new SqlTrans();

            StringBuilder sb = new StringBuilder();
            foreach (Type type in asm.GetExportedTypes())
            {
                if (type.HasInterface<IPacking>())
                {
                    IPacking packing = (IPacking)Activator.CreateInstance(type);
                    packing.Unpack(transaction, insert);
                }
            }

            transaction.Commit();
            return;
        }

        #region Create Table
        
        
        /// <summary>
        ///  Create basic tables of PersistentObjects
        /// </summary>
        private static Type[] CreateBasicTable()
        {
            
            Type[] basicTypes = new Type[] { 
                typeof(dictDatabaseDpo), 
                typeof(dictDataTableDpo), 
                typeof(dictDataColumnDpo), 
                typeof(dictEnumTypeDpo), 
                typeof(logDataSetDpo), 
                typeof(logDataTableDpo), 
                typeof(logDataColumnDpo),
                typeof(RecordLockDpo)
            };

            foreach (Type type in basicTypes)
            {
                DPObject dpo = (DPObject)Activator.CreateInstance(type);
                dpo.CreateTable();
            }

            foreach (Type type in basicTypes)
            {
                DPObject dpo = (DPObject)Activator.CreateInstance(type);
                dpo.RegisterEntireTable();
            }

            return basicTypes;
        }



        /// <summary>
        /// Create tables used for installation
        /// </summary>
        /// <param name="level"></param>
        /// <param name="worker"></param>
        public static void CreateTable(Level level, Worker worker)
        {

            Type[] baiscTypes = CreateBasicTable();
            Assembly basicAssembly = baiscTypes[0].Assembly;

            Assembly[] assemblies = SysExtension.GetInstalledAssemblies();
            
            int i = 0;
            foreach (Assembly asm in assemblies)
            {

                StringBuilder sb = new StringBuilder();
                foreach (Type type in asm.GetTypes())
                {
                    if (type.BaseType != typeof(DPObject))
                        continue;

                    if (asm == basicAssembly && Array.IndexOf(baiscTypes, type) >= 0)
                        continue;

                    TableAttribute[] A = type.GetAttributes<TableAttribute>();
                    if (A.Length == 0)
                        continue;

      
                    if (A[0].Level == level)
                        sb.Append(CreateTable(type));
                }

                worker.ReportProgress((int)(i * 100.0 / assemblies.Length), sb.ToString());
                i++;

            }

        }

       
        public static string CreateTable(Assembly assembly)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType != typeof(DPObject))
                    continue;

                if (!type.HasAttribute<TableAttribute>())
                    continue;

                sb.Append(CreateTable(type));
            }

            return sb.ToString();

        }


        private static string CreateTable(Type dpoType)
        {
            StringBuilder sb = new StringBuilder();

            DPObject dpo = (DPObject)Activator.CreateInstance(dpoType);

            int tableId = dpo.TableName.Id;

            if (dpo.CreateTable())
            {
                sb.AppendLine(string.Format("Table {0} created.", dpo.TableName));

                if (tableId == -1)  //register new table to dictionary
                    tableId = dpo.RegisterEntireTable();
            }
            else
                sb.AppendLine(string.Format("Table {0} exists, cannot be created.", dpo.TableName));

            return sb.ToString();

        }
        
        #endregion

    }
}
