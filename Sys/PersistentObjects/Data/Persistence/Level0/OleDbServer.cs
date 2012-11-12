using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public class OleDbServer
    {
        private const string Excel2010 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=@XLS;Extended Properties=\"Excel 12.0 Xml;HDR=No\"";
        private const string Excel2007 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=@XLS;Extended Properties=\"Excel 8.0;HDR=NO;\"";


        public static DataProvider RegisterExcel2007(string xlsName)
        {
            return DataProviderManager.Register(xlsName, DataProviderType.Excel2007, Excel2007.Replace("@XLS", xlsName));
        }

        public static DataProvider RegisterExcel2010(string xlsName)
        {
            return DataProviderManager.Register(xlsName, DataProviderType.Excel2010, Excel2010.Replace("@XLS", xlsName));
        }

    }
}
