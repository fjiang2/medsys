using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Sys.Data
{
    public class DefaultRowValue
    {
        DataRow dataRow;


        public DefaultRowValue(DataRow dataRow)
        {
            this.dataRow = dataRow;
        }


        public object this[string columnName]
        {
            get
            {
                object x = dataRow[columnName];
                Type dataType = dataRow.Table.Columns[columnName].DataType;

                if (x != System.DBNull.Value)
                    return x;
                else
                    return SystemDefaultValue(dataType);
            }
            set
            {
                Type dataType = dataRow.Table.Columns[columnName].DataType;

                if (value != System.DBNull.Value)
                    dataRow[columnName] = value;
                else
                    dataRow[columnName] = SystemDefaultValue(dataType); ;
            }
        }

        public static object SystemDefaultValue(Type dataType)
        {
            if (!dataType.IsValueType)
                return System.DBNull.Value;

            switch (dataType.Name)
            {
                case "Int16":
                    return System.Convert.ToInt16(0);

                case "Int32":
                    return 0;

                case "String":
                    return "";

                case "Boolean":
                    return false;

                case "Double":
                    return 0.0;

                case "Decimal":
                    return new Decimal(0.0);

                case "DateTime":
                    return System.DateTime.MinValue;
                    
            }

            throw new SysException("Type {0} is not supported", dataType);
            
        }

        //------------------------------------------------------------------------------------------------------------

        public T Field<T>(string columnName)
        {
            return (T)this[columnName];
        }


        //------------------------------------------------------------------------------------------------------------
        public T IsNull<T>(string columnName, T defaultValue)
        {
            if (dataRow[columnName] != System.DBNull.Value)
                return (T)dataRow[columnName];
            else
                return defaultValue;
        }

     

    }
}