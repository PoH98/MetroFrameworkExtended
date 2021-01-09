using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    /// <summary>
    /// Extended Methods
    /// </summary>
    public static class MetroFrameworkDataTableExtension
    {
        /// <summary>
        /// Check the row contains specific field
        /// </summary>
        public static bool ContainsField(this DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) ? true : false;
        }
        /// <summary>
        /// Check the table contains specific field
        /// </summary>
        public static bool ContainsField(this DataTable table, string column)
        {
            return table.Columns.Contains(column) ? true : false;
        }

        /// <summary>
        /// Check DataGridView's Column Collection's Header Text contains any specific keyword in the array
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool Any(this DataGridViewColumnCollection columns, IEnumerable enumerable)
        {
            foreach(var key in enumerable)
            {
                foreach(DataGridViewColumn column in columns)
                {
                    if (column.HeaderText.Contains(key.ToString()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
