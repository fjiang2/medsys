using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Sys.Platform.DataImporter
{
    //public class DataImportParameter
    //{
    //    public readonly Type type;
    //    public readonly string name;
    //    public readonly string mapping;

    //    public DataImportParameter(string name, Type type)
    //    {
    //        this.name = name;
    //        this.type = type;
    //    }
    //}

    public interface IDataImporter
    {
        //DataImportParameter[] GetImportParameters();
        void ImportDataObject();
    }
}
