using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public enum Provider
    {
       /// <summary>
       /// Default database provider
       /// </summary>
        DefaultDataSource = DataProvider.DEFAULT_HANDLE,

        DataSource1 = DataProvider.DEFAULT_HANDLE + 1,
        DataSource2 = DataProvider.DEFAULT_HANDLE + 2,
        DataSource3 = DataProvider.DEFAULT_HANDLE + 3,
        DataSource4 = DataProvider.DEFAULT_HANDLE + 4,
        DataSource5 = DataProvider.DEFAULT_HANDLE + 5
    }
}
