using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using Tie;
using Sys.Data;
using Sys.Import;

namespace Sys.Platform.DataImporter
{

    [Table("DataImports", Level.System)]
    [Locator( new string[] { "Label" })]
    public class DataImportSetting : PersistentObject
    {
        public int ID;    //int(4)
        public string Label;    //nvarchar(100)
        public string Description;    //nvarchar(1024)
        public string DataSource;    //nvarchar(-1)
        public string ClassName;    //nvarchar(512)
        public string Mapping;    //ntext(16)

        public DataImportSetting()
        {
        }

        public DataImportSetting(string label)
        {
            this.Label = label;
            Load();
        }

      
    }


    class DataImportManager
    {
        VAL mapping;
        DataImportSetting setting;
        IDataImporter importer;

        PropertyInfoAttribute[] parameters;
        DataTable dataSource;

        public DataImportManager(string className, string dataSource)
        {
            this.setting = new DataImportSetting();
            this.setting.DataSource = dataSource;
            this.setting.ClassName = className;
            this.setting.Mapping = "";
            this.importer = ReadImporter(setting.ClassName, setting.Mapping);

            if (dataSource != "")
                this.dataSource = SqlCmd.FillDataTable(ConnectionProviderManager.DefaultProvider, setting.DataSource); ;
        }

        public DataImportManager(string importerName)
        {
            this.setting = new DataImportSetting(importerName);
            this.importer = ReadImporter(setting.ClassName, setting.Mapping);
            this.dataSource = SqlCmd.FillDataTable(ConnectionProviderManager.DefaultProvider, setting.DataSource); ;
        }

        private IDataImporter ReadImporter(string className, string savedMapping)
        {
            IDataImporter importer = (IDataImporter)ClassHandshake.NewInstance(className);
            if (importer == null)
                throw new ApplicationException(string.Format("class {0} does not have default constructor or ClassConstructorAttribute does not be defined.", className));

            VAL m = new VAL();
            if (savedMapping != "")
                m = Script.Evaluate(savedMapping, new Memory());


            this.parameters = ClassHandshake.GetPropertyAttributes(importer);
            this.mapping = new VAL(); 
            
            int i=0;
            foreach (DataImportParameterAttribute parameter in parameters)
            {
                VAL v = VAL.Array(2);
                v[0] = new VAL(parameter.Type.FullName);
                v[1] = new VAL("");
                if ((object)m[parameter.Keyword] != null)
                    v[1] = m[parameter.Keyword][1];

                mapping[parameter.Keyword] =v;

                i++;
            }

            return importer;

        }

        public VAL Mapping
        {
            get { return mapping; }
           // set { mapping = value; }
        }



        public static DataTable DecodeMapping(VAL mapping)
        {
            DataTable dtMapping = new DataTable();
            dtMapping.Columns.Add(new DataColumn("propertyName", typeof(string)));
            dtMapping.Columns.Add(new DataColumn("propertyType", typeof(string)));
            dtMapping.Columns.Add(new DataColumn("columnName", typeof(string)));


            for (int i = 0; i < mapping.Size; i++)
            {
                DataRow dataRow = dtMapping.NewRow();
                VAL v = mapping[i];
                dataRow["propertyName"] = v[0].Str;
                dataRow["propertyType"] = v[1][0].Str;
                dataRow["columnName"] = v[1][1].Str;

                dtMapping.Rows.Add(dataRow);
            }

            return dtMapping;
        }

        public static VAL EncodeMapping(DataTable dtMapping)
        {
            VAL mapping = new VAL();

            int i = 0;
            foreach (DataRow dataRow in dtMapping.Rows)
            {
                string propertyName = (string)dataRow["propertyName"];

                VAL v = VAL.Array(2);
                v[0] = new VAL((string)dataRow["propertyType"]);
                v[1] = VAL.Boxing(dataRow["columnName"]);

                mapping[propertyName] = v;
                i++;
            }

            return mapping;
        }

        public string Validate(DataTable dtMapping)
        {
            if (this.dataSource == null)
            {
                return "Data source is not defined.";
            }

            this.mapping = DataImportManager.EncodeMapping(dtMapping);

            for (int i = 0; i < mapping.Size; i++)
            {
                VAL v = mapping[i];
                string propertyName = v[0].Str;
                string propertyType = v[1][0].Str;
                
                //column name is not defined.
                if (v[1][1].Undefined || v[1][1].Str=="")
                    return string.Format("Column name for {0} is not defined.", propertyName);
                
                string columnName = v[1][1].Str;
                
                //column type is mismatched.
                if (propertyType != dataSource.Columns[columnName].DataType.FullName)
                    return string.Format("Data type for {0} is mismatched.", propertyName); ;
            }
            return null;
        }


        public DataTable DataSource
        {
            get
            {
                return dataSource; 
            }
        }

        public void ImportDataRow(DataRow dataRow)
        {
            foreach (DataImportParameterAttribute parameter in parameters)
            {
                string columnName = this.mapping[parameter.Keyword][1].Str;
                parameter.propertyInfo.SetValue(this.importer, dataRow[columnName], null);
            }

            this.importer.ImportDataObject(); 

        }




    }
}
