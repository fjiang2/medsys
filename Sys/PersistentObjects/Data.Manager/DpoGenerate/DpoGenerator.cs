//--------------------------------------------------------------------------------------------------//
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
using System.Text;
using System.Data;
using System.IO;
using Sys.Data;
using System.Reflection;
using Tie;
using Sys.Data.Manager;

namespace Sys.Data.Manager
{
  

    class DpoGenerator
    {
        string sourceCode;
        ClassTableName tname;
        ClassName cname;

        ITable metaTable;
        DpoClass dpoClass;

        public DpoGenerator(ClassTableName ctname, ITable metaTable, ClassName cname, bool hasColumnAttribute, Dictionary<TableName, Type> dict)
        {
            this.tname = ctname;
            this.cname = cname;
            
            //metaTable = ctname.GetMetaTable();
            this.metaTable = metaTable;

            if (metaTable.TableID == -1)
            {
                DictTable.MustRegister(ctname);
            }

            dpoClass = new DpoClass(metaTable, cname, dict);
            dpoClass.HasColumnAttribute = hasColumnAttribute;

            this.sourceCode = dpoClass.Generate(cname.Modifier, ctname);

        }

     

        public bool WriteFile(string fileName, bool mustGenerate)
        {
            if (!mustGenerate)
            {
                if (File.Exists(fileName))
                {
                    if ((File.GetAttributes(fileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)    //this file is not checked out
                    {
                        if (dpoClass.IsTableChanged(tname))
                            throw new JException("{0} is modified, please check out class {1} to refresh", tname, cname.Class);

                        return false;
                    }
                }

                if (!dpoClass.IsTableChanged(tname))
                    return false;
            }

            if (metaTable.TableID == -1)
                throw new JException("Table ID {0} is not defined", tname);
            
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(sourceCode);
            sw.Close();
        
            return true;
        }



     
    }



}
