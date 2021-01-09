using MetroFramework;
using MetroFramework.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    public class MetroFrameworkDataGridView : MetroGrid, MetroFrameworkControl
    {
        #region Variables
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ErrorProvider ErrorProvider { get; set; } = new ErrorProvider();

        /// <summary>
        /// Used to set the money key when '<see cref="SetMoneyFormat"/>' is true, default will be $ and ￥ sign only to automatically set the column format.
        /// </summary>
        public virtual char[] MoneyKey { get; } = defaultMoneyKey;
        /// <summary>
        /// Auto set money format into the columns which contains any keyword from <see cref="MoneyKey"/>
        /// </summary>
        public bool SetMoneyFormat { get; set; } = true;

        private static readonly char[] defaultMoneyKey = new char[] { '$', '￥' };

        /// <summary>
        /// Set the table font size, auto set columns width too according to settings
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public float FontSize
        {
            get
            {
                return MetroFrameworkBuffer.Instance.DataGridFontSize;
            }
            set
            {
                SuspendLayout();
                var difference = value / MetroFrameworkBuffer.Instance.DataGridFontSize;
                MetroFrameworkBuffer.Instance.DataGridFontSize = value;
                Font = new Font(this.Font.FontFamily, MetroFrameworkBuffer.Instance.DataGridFontSize, this.Font.Style, GraphicsUnit.Pixel);
                foreach(DataGridViewColumn col in Columns)
                {
                    col.Width = Convert.ToInt32(Math.Round(col.Width * difference));
                }
                ResumeLayout();
            }
        }
        /// <summary>
        /// Set the DataSource as <see cref="DataTable"/> or get it back
        /// </summary>
        public new DataTable DataSource
        {
            get
            {
                if (this.DataSource != null)
                    return (base.DataSource as DataTable);
                else
                {
                    base.DataSource = new DataTable();
                    return this.DataSource;
                }
            }
            set
            {
                SuspendLayout();
                base.DataSource = value;
                ResumeLayout();
            }
        }
        #endregion

        /// <summary>
        /// Get selected <see cref="DataRow"/> from this <see cref="MetroFrameworkDataGridView"/>. Return <see cref="true"/> if found with the <see cref="DataRow"/> returned, else <see cref="false"/> with <see cref="null"/>
        /// </summary>
        /// <param name="selectedRow">The selected <see cref="DataRow"></see></param>
        /// <returns><see cref="true"/> if found with the <see cref="DataRow"/> returned, else <see cref="false"/> with <see cref="null"/></returns>
        public bool GetSelectedRow(out DataRow selectedRow)
        {
            if (SelectedRows.Count < 1)
            {
                MetroMessageBox.Show(this, "Select a row first!", "Error");
                selectedRow = null;
                return false;
            }
            else if (SelectedRows[0].Index == NewRowIndex)
            {
                MetroMessageBox.Show(this, "Select a row first!", "Error");
                selectedRow = null;
                return false;
            }
            else
            {
                selectedRow = (SelectedRows[0].DataBoundItem as DataRowView).Row;
                return true;
            }
        }


        public MetroFrameworkDataGridView()
        {
            if(!DesignMode)
            StyleManager = MetroFrameworkBuffer.Instance.Manager;
            if (!DesignMode)
            {
                Font = new Font(this.Font.FontFamily, MetroFrameworkBuffer.Instance.DataGridFontSize, this.Font.Style, GraphicsUnit.Pixel);
                CellFormatting += MetroFrameworkDataGridView_CellFormatting;
                if (!this.ReadOnly)
                {
                    this.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    this.CellBeginEdit += (sender, e) =>
                    {
                        this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                        this.Rows[e.RowIndex].Height = Convert.ToInt32(FontSize * 4);
                    };
                    this.CellEndEdit += (sender, e) =>
                    {
                        this.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    };
                }
                else
                {
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }
            }
        }

        private void MetroFrameworkDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(Columns.Count > 0 && Rows.Count > 0)
            {
                bool Match = false;
                Parallel.ForEach(MoneyKey, (key) =>
                {
                    if (Columns[e.ColumnIndex].HeaderText.Any(x => x == key))
                    {
                        Match = true;
                    }
                });
                if(Match)
                {
                    var value = Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (value != DBNull.Value && value != null && !string.IsNullOrEmpty(value.ToString()) && !value.ToString().Any(char.IsLetter))
                    {
                        if (decimal.TryParse(value.ToString(), out decimal dec))
                        {
                            Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dec.ToString("N2");
                        }
                    }
                }
            }
        }
    }
}
