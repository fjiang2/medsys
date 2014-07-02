using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public interface ITable
    {
        TableName TableName { get; }
        int TableID { get; }

        IIdentityKeys Identity { get; }
        IPrimaryKeys PrimaryKeys { get; }
        IForeignKeys ForeignKeys { get; }

        ColumnCollection Columns { get; }
    }


    public interface IColumn
    {
        string ColumnName { get; }
        string DataType { get; }
        short Length { get; }
        bool Nullable { get; }
        byte Precision { get; }
        byte Scale { get; }
        bool IsPrimary { get; }
        bool IsIdentity { get; }
        bool IsComputed { get; }
        int ColumnID { get; }

        IForeignKey ForeignKey { get; set; }
        CType CType { get; }
    }


    public interface IPrimaryKeys
    {
        string[] Keys { get; }
        int Length { get; }
    }

    public interface IForeignKeys
    {
        IForeignKey[] Keys { get; }
        int Length { get; }
    }


    public interface IForeignKey
    {
        string FK_Table { get; }
        string FK_Column { get; }
        string PK_Table { get; }
        string PK_Column { get; }

        string DatabaseName { get;  }
        DataProvider Provider { get; }
    }

    public interface IIdentityKeys
    {
        string[] ColumnNames { get; }
        int Length { get; }
    }
}
