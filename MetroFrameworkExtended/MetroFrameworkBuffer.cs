using MetroFramework.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace MetroFramework.Winform
{
    /// <summary>
    /// Buffered MetroFramework components Shared Variables
    /// </summary>
    public class MetroFrameworkBuffer:IDisposable
    {
        /// <summary>
        /// Singleton Instance
        /// </summary>
        public static MetroFrameworkBuffer Instance { 
            get
            {
                if(instance == null)
                {
                    instance = new MetroFrameworkBuffer();
                }
                return instance;
            }
        }
        private Dictionary<string, DataTable> tables;
        private static MetroFrameworkBuffer instance;
        private MetroFrameworkBuffer()
        {
            tables = new Dictionary<string, DataTable>();
            Manager = new MetroStyleManager();
            DataGridFontSize = 11f;
        }

        /// <summary>
        /// Buffer the <see cref="DataTable"/> and share through whMetroFramework program
        /// </summary>
        public static void BufferTable(string TableName, DataTable Table)
        {
            if(!Instance.tables.ContainsKey(TableName))
                Instance.tables.Add(TableName, Table);
            else
            {
                Instance.tables[TableName].Dispose();
                Instance.tables[TableName] = Table;
            }
        }
        /// <summary>
        /// The name of <see cref="DataTable"/> to get
        /// </summary>
        public static DataTable GetTable(string TableName, bool ThrowIfNotFound = true)
        {
            if (Instance.tables.ContainsKey(TableName))
                return Instance.tables[TableName];
            else
            {
                if (ThrowIfNotFound)
                    throw new ArgumentException("Table Named as " + TableName + " is not found in buffer!");
                else
                    return new DataTable();
            }
        }

        /// <summary>
        /// Release the tables stored in buffer
        /// </summary>
        public void Dispose()
        {
            Instance.tables.Clear();
            GC.Collect();
        }

        internal MetroStyleManager Manager;

        internal float DataGridFontSize;
    }
}
