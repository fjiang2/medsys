using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


namespace Sys.Platform.DataImporter
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DataImportParameterAttribute : Sys.Import.PropertyInfoAttribute 
    {
        public readonly string Keyword;

        public DataImportParameterAttribute(string keyword)
        {
            this.Keyword = keyword;
        }

    }
}
