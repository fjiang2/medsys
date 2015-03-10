using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCompare
{
    public enum CompareAction
    {
        Schema = 1,
        Data = 2,
        Columns = 4,
        ParimaryKey = 5,
        ForeignKey = 6,
        TableRows = 7,
        Name = 8,
        GenerateScript = 9,
        Execute = 10,
        Command = 11
    }
}
