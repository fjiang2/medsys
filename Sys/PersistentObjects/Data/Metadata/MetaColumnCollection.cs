using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sys.Data
{
    public class MetaColumnCollection : List<MetaColumn>
    {
        MetaTable metaTable;

        internal MetaColumnCollection(MetaTable metaTable)
        {
            this.metaTable = metaTable;
        }

        public void UpdatePrimary(PrimaryKeys primary)
        {

            var columns = this.Where(column => Array.IndexOf<string>(primary.Keys, column.ColumnName) >= 0);
            foreach (MetaColumn column in columns)
            {
                column.IsPrimary = true;
            }

        }

        internal void UpdateForeign(ForeignKeys foreign)
        {
            foreach (ForeignKey key in foreign.Keys)
            {
                MetaColumn column = this.Find(col => col.ColumnName == key.FK_Column);
                column.ForeignKey = key;
            }
        }

        /// <summary>
        /// Create SQL INSERT INTO ... VALUES() command 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public string InsertCommand(string line, char[] separator)
        {
            string DELIMETER = "'";
            string[] items = line.Split(separator);

            if (items.Length < this.Count)
                throw new JException("#line(#{0}) data not match to table(#{1})", items.Length, this.Count);

            string[] values = new string[this.Count];
            int i = 0;
            foreach (MetaColumn column in this)
            {
                object obj = column.ToObject(items[i]);
                if (obj == null)
                    values[i] = "NULL";
                else if (obj is DateTime)
                    values[i] = DELIMETER + ((DateTime)obj).ToShortDateString() + DELIMETER;
                else if (obj is string)
                    values[i] = "N" + DELIMETER + (obj as string).Replace("'", "''") + DELIMETER;
                else
                    values[i] = obj.ToString();

                i++;
            }

            return string.Format("INSERT INTO {0} VALUES ({1})", this.metaTable.TableName, string.Join(",", values));
        }
    }
}
