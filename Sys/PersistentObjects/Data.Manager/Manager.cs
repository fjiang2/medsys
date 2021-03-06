﻿//--------------------------------------------------------------------------------------------------//
//                                                                                                  //
//        DPO(Data Persistent Object)                                                               //
//                                                                                                  //
//          Copyright(c) Datum Connect Inc.                                                         //
//                                                                                                  //
// This source code is subject to terms and conditions of the Datum Connect Software License. A     //
// copy of the license can be found in the License.html file at the root of this distribution. If   //
// you cannot locate the  Datum Connect Software License, please send an email to                   //
// datconn@gmail.com. By using this source code in any fashion, you are agreeing to be bound        //
// by the terms of the Datum Connect Software License.                                              //
//                                                                                                  //
// You must not remove this notice, or any other, from this software.                               //
//                                                                                                  //
//                                                                                                  //
//--------------------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Sys.Data;
using Sys.CodeBuilder;

namespace Sys.Data.Manager
{
    public class Manager
    {
        Assembly assembly;

        public Manager(Assembly assembly)
        {
            this.assembly = assembly;
        }


        /// <summary>
        /// Create DPO classes from SQL SERVER
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="tableNames"></param>
        /// <param name="path"></param>
        /// <param name="nameSpace"></param>
        /// <param name="level"></param>
        /// <param name="isPack"></param>
        /// <param name="hasProvider"></param>
        /// <param name="dict"></param>
        public static void CreateClass(ConnectionProvider provider, string[] tableNames, string path, string nameSpace, 
            Level level, bool isPack, bool hasProvider,
            Dictionary<TableName, Type> dict)
        {
            foreach (string fullName in tableNames)
            {
                TableName tableName = new TableName(provider, fullName);
                ClassTableName ctname = new ClassTableName(tableName)
                {
                    Level = level,
                    Pack = isPack,
                    HasProvider = hasProvider
                };

                ClassName cname = new ClassName(nameSpace, AccessModifier.Public, ctname);
                
                ctname.GenTableDpo(path, true, cname, true, dict);
            }
        }

   

        /// <summary>
        /// Upgrade DPO classes from SQL SERVER
        /// </summary>
        /// <param name="path"></param>
        public void UpgradeClass(string path, Dictionary<TableName, Type> dict)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType != typeof(DPObject))
                    continue;
                {

                    DPObject dpo = (DPObject)Activator.CreateInstance(type);
                    ClassTableName ctname = new ClassTableName(dpo.TableName)
                     {
                         Level = dpo.Level,
                         Pack = dpo.IsPack,
                         HasProvider = dpo.HasProvider
                     };
                    ClassName cname = new ClassName(dpo);
                    ctname.GenTableDpo(path, true, cname, true, dict);
                }
            }
        }

        /// <summary>
        /// Upgrade DPO packages from SQL SERVER
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public MessageBuilder UpgradePackage(string path)
        {
            MessageBuilder messages = new MessageBuilder();
            foreach (Type type in assembly.GetTypes())
            {
                if (type.BaseType != typeof(DPObject))
                    continue;

                TableAttribute[] A = type.GetAttributes<TableAttribute>();
                if (A.Length == 0 || !A[0].Pack)
                    continue;


                Packing packing = new Packing(type);
                packing.Pack();

                if (!packing)
                {
                    messages.Add(Message.Information(string.Format("Table {0} is empty.", packing.TableName)));
                }
                else
                {
                    string fileName = string.Format("{0}\\{1}.cs", path, packing.ClassName);
                    StreamWriter sw = new StreamWriter(fileName);
                    sw.Write(packing.ToString());
                    sw.Close();

                     messages.Add(Message.Information(string.Format("Table {0} packed into {1}.", packing.TableName, fileName)));
                }
            }


            return messages;
        }


        /// <summary>
        /// Create Tables in SQL Server from DPO classes
        /// </summary>
        /// <returns></returns>
        public MessageBuilder CreateTables()
        {
            return Unpacking.CreateTable(assembly);
        }

        /// <summary>
        /// Upgrade records in SQL SERVER from DPO packages
        /// </summary>
        /// <returns></returns>
        public void UpgradeRecords()
        {
            Unpacking.Unpack(assembly, false);
        }

        /// <summary>
        /// Insert new records into SQL Server from DPO package
        /// </summary>
        public void InsertRecords()
        {
            Unpacking.Unpack(assembly, true);
        }

       

    }
}
