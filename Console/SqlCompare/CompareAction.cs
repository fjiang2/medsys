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
        ParimaryKey = 3,
        ForeignKey = 4,
        TableRows = 5,
        Name = 6,
        GenerateScript = 7,
        Input = 8
    }
}
