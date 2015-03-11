using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCompare
{
    public enum CompareAction
    {
        CompareSchema = 1,
        CompareData = 2,
        ShowTableStructure = 4,
        ShowParimaryKey = 5,
        ShowForeignKey = 6,
        ShowTableName = 7,
        GenerateTableRows = 8,
        GenerateScript = 9,
        Execute = 10,
        Command = 11
    }
}
