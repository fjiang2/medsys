using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCompare
{
    public enum ActionType
    {
        CompareSchema = 1,
        CompareData = 2,
        Shell = 3,
        GenerateTableRows = 10,
        GenerateScript = 11,
        Execute = 20
    }
}
