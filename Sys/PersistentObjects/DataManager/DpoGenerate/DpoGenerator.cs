using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Sys.Data;
using System.Reflection;
using Tie;
using Sys.DataManager;

namespace Sys.DataManager
{
  

    class DpoGenerator
    {
        string sourceCode;
        ClassTableName tname;
        ClassName cname;

        MetaTable metaTable;
        DpoClass dpoClass;



        public DpoGenerator(ClassTableName tname, ClassName cname, bool hasColumnAttribute)
        {
            this.tname = tname;
            this.cname = cname;

            metaTable = tname.GetMetaTable();

            if (metaTable.TableID == -1)
            {
                DictTable.MustRegister(tname);
            }

            dpoClass = new DpoClass(metaTable, cname);
            dpoClass.HasColumnAttribute = hasColumnAttribute;

            this.sourceCode = dpoClass.Generate(cname.Modifier, tname.Level, tname.Pack);

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
                            throw new SysException("{0} is modified, please check out class {1} to refresh", tname, cname.Class);

                        return false;
                    }
                }

                if (!dpoClass.IsTableChanged(tname))
                    return false;
            }

            if (metaTable.TableID == -1)
                throw new SysException("Table ID {0} is not defined", tname);
            
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(sourceCode);
            sw.Close();
        
            return true;
        }



     
    }



}
