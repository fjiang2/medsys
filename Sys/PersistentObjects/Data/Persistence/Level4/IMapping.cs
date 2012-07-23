using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public interface IColumnMapping
    {
        string ColumnName { get; }
    }

    public interface IMany2ManyMapping
    {
        string ColumnName1 { get; }
        string ColumnName2 { get; }

        string MapName1 { get; }
        string MapName2 { get; }
    }
}
