using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Sys.Data.Persistence.Level4
{
    /// <summary>
    /// n..n table mapping(many-to-many)
    /// T1: mapping table, e.g. Table UserRoles
    /// T2: many table, e.g. Table Roles
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class TableReader<T1, T2>
        where T1 : class,  IDPObject, new() 
        where T2 : class,  IDPObject, new() 
    {

        DataSet dataset;

        public TableReader(MappedColumn column1, MappedColumn column2, int value)
        {

            SqlClause relationships = new SqlClause()
                .SELECT.COLUMNS().FROM<T1>().WHERE(column1.RelationName.ColumnName() == value);

            SqlClause many = new SqlClause()
                .SELECT.COLUMNS()
                .FROM<T2>()
                .WHERE(column2.Name.ColumnName()
                    .IN(
                         new SqlClause()
                            .SELECT
                            .COLUMNS(column2.RelationName)
                            .FROM<T1>()
                            .WHERE(column1.RelationName.ColumnName() == value)
                        )
                    );


            this.dataset = (relationships + many).FillDataSet();
            
        }

        public DataTable ManyTable
        {
            get { return this.dataset.Tables[0]; }
        }

        public DataTable MapTable
        {
            get { return this.dataset.Tables[0]; }
        }

    }


  
}
