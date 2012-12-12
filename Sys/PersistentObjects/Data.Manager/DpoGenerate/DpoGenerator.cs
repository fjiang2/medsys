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

        MetaTable metaTable;
        DpoClass dpoClass;

        public DpoGenerator(ClassTableName ctname, ClassName cname, bool hasColumnAttribute, Dictionary<TableName, Type> dict)
        {
            this.tname = ctname;
            this.cname = cname;
            
            metaTable = ctname.GetMetaTable();

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
