using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Data
{
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ConstraintForeignKeyAttribute : Attribute
    {
        public readonly Type PK_Table;
        public readonly string PK_Column;
        public readonly string FK_Column;

        /// <summary>
        /// CONSTRAINT FOREIGN KEY (pkColumn) REFERENCES pkTable(pkColumn)
        /// </summary>
        /// <param name="fkColumn"></param>
        /// <param name="pkTable"></param>
        /// <param name="pkColumn"></param>
        public ConstraintForeignKeyAttribute(string fkColumn, Type pkTable, string pkColumn)
        {
            this.FK_Column = fkColumn;
            this.PK_Table = pkTable;
            this.PK_Column = pkColumn;
        }

        public override string ToString()
        {
            return string.Format("CONSTRAINT FOREIGN KEY ({0}) REFERENCES {1}({2})", this.FK_Column, this.PK_Table.TableName(), this.PK_Column);
        }
    }


    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class ForeignKeyAttribute : Attribute
    {
        public readonly Type PK_Table;
        public readonly string PK_Column;

        /// <summary>
        /// FOREIGN KEY (this) REFERENCES pkTable(pkColumn)
        /// </summary>
        /// <param name="pkTable"></param>
        /// <param name="pkColumn"></param>
        public ForeignKeyAttribute(Type pkTable, string pkColumn)
        {
            this.PK_Table = pkTable;
            this.PK_Column = pkColumn;
        }

        public override string ToString()
        {
            return string.Format("REFERENCES {0}({1})", this.PK_Table.TableName(), this.PK_Column);
        }
    }
}
