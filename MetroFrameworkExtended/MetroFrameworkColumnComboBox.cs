using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MetroFramework.Winform
{
    /// <summary>
    /// A special <see cref="ComboBox"/> that shows a <see cref="DataGridView"/> instead of <see cref="ListControl"/> List
    /// </summary>
    [ToolboxBitmap(typeof(ComboBox))]
    public class MetroFrameworkColumnComboBox:TextBox, MetroFrameworkControl
    {
        /// <summary>
        /// Set a <see cref="System.Data.DataTable"/> into <see cref="MetroFrameworkColumnComboBox"/>
        /// </summary>
        public DataTable DataTable
        {
            get
            {
                if (_table == null)
                {
                    _table = new DataTable();
                }
                return _table;
            }
            set
            {
                _table = value.Copy();
                view.DataSource = _table;
                if (!DroppedDown)
                {
                    foreach (DataGridViewRow row in view.Rows)
                    {
                        var datarow = (row.DataBoundItem as DataRowView).Row;
                        if (datarow[ColumnUsed].ToString().ToLower() == Text.ToLower())
                        {
                            row.Selected = true;
                        }
                        else
                        {
                            row.Selected = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string Text
        {
            get => base.Text;
            set
            {
                if (DataTable.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in view.Rows)
                    {
                        var datarow = (row.DataBoundItem as DataRowView).Row;
                        if (datarow[ColumnUsed].ToString().ToLower() == Text.ToLower())
                        {
                            row.Selected = true;
                        }
                        else
                        {
                            row.Selected = false;
                        }
                    }
                }
                base.Text = value;
                OnTextChanged(EventArgs.Empty);
            }
        }

        private DataTable _table;

        private bool DroppedDown = false;

        private MetroGrid view = new MetroGrid();

        private Form parentform;

        private DButton DropDownButton = new DButton();
        /// <summary>
        /// Set which row to be shown in <see cref="MetroFrameworkColumnComboBox"/>
        /// </summary>
        public Dictionary<string, object> Columns
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                if (items != null)
                {
                    view.Columns.Clear();
                    view.AutoGenerateColumns = false;
                    foreach (var item in items)
                    {
                        view.Columns.Add(item.Key, item.Value.ToString());
                        view.Columns[item.Value.ToString()].DataPropertyName = item.Value.ToString();
                    }
                }
            }
        }

        public override Font Font
        {
            get
            {
                return new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            }
            set
            {

            }
        }

        private Dictionary<string, object> items;
        /// <summary>
        /// Set when DataGridView is clicked, which column will be set into the text area
        /// </summary>
        public string ColumnUsed { get; set; } = "id";
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ErrorProvider ErrorProvider { get; set; } = new ErrorProvider();
       
        public MetroFrameworkColumnComboBox()
        {
            SuspendLayout();
            view.MultiSelect = false;
            view.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            view.ReadOnly = true;
            view.AllowUserToAddRows = false;
            view.AllowUserToDeleteRows = false;
            view.TabStop = false;
            view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            view.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                Text = (view.SelectedRows[0].DataBoundItem as DataRowView).Row[ColumnUsed].ToString();
                parentform.Controls.Remove(view);
                DroppedDown = false;
                CCBValueChangedEventArgs c = new CCBValueChangedEventArgs()
                {
                    selectedRow = (view.SelectedRows[0].DataBoundItem as DataRowView).Row
                };
                ValueChanged?.Invoke(this, c);
            };
            view.LostFocus += (sender, e) =>
            {
                if (!Focused && !view.Focused && !DropDownButton.Focused)
                {
                    if (parentform == null)
                    {
                        parentform = FindForm();
                    }
                    parentform.Controls.Remove(view);
                    DroppedDown = false;
                }
            };
            DropDownButton.FlatStyle = FlatStyle.Flat;
            DropDownButton.FlatAppearance.BorderSize = 0;
            DropDownButton.FlatAppearance.BorderColor = BackColor;
            DropDownButton.Dock = DockStyle.Right;
            DropDownButton.Size = new Size(20, 20);
            DropDownButton.Click += DropDownButton_Click;
            DropDownButton.MouseEnter += DropDownButton_MouseEnter;
            DropDownButton.MouseLeave += DropDownButton_MouseLeave;
            DropDownButton.TabStop = false;
            Controls.Add(DropDownButton);
            if (DataTable == null)
            {
                DataTable = new DataTable();
            }
            Cursor = Cursors.Hand;
            ResumeLayout();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete && e.KeyCode != Keys.Back)
            {
                e.Handled = true;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar != (Char)Keys.Delete && e.KeyChar != (Char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void DropDownButton_MouseLeave(object sender, EventArgs e)
        {
            DropDownButton.BackColor = BackColor;
        }

        private void DropDownButton_MouseEnter(object sender, EventArgs e)
        {
            DropDownButton.BackColor = SystemColors.ButtonHighlight;
        }

        private Point PointToCurrentScreen()
        {
            var screenBounds = Screen.FromControl(this).Bounds;
            var globalCoordinates = this.PointToScreen(Point.Empty);
            return new Point(globalCoordinates.X - screenBounds.X, globalCoordinates.Y - screenBounds.Y);
        }

        private void DropDownButton_Click(object sender, EventArgs e)
        {
            if (view == null)
            {
                view = new MetroGrid();
                view.DataSource = DataTable;
                if (items != null)
                {
                    view.Columns.Clear();
                    view.AutoGenerateColumns = false;
                    foreach (var item in items)
                    {
                        view.Columns.Add(item.Key, item.Value.ToString());
                        view.Columns[item.Value.ToString()].DataPropertyName = item.Value.ToString();
                    }
                }
            }
            view.DataSource = DataTable;
            if (!DroppedDown && Enabled && DataTable.Rows.Count > 0)
            {
                parentform = FindForm();
                view.Location = new Point(PointToCurrentScreen().X, PointToCurrentScreen().Y + Height);
                parentform.Controls.Add(view);
                view.BringToFront();
                var height = 40;
                foreach (DataGridViewRow row in view.Rows)
                {
                    if (row.Visible)
                        height += row.Height;
                }

                if (height > 500)
                    height = 500;
                if (height > parentform.Height)
                    height = parentform.Height - Location.Y - 20;
                view.Height = height;
                var width = 60;
                foreach (DataGridViewColumn col in view.Columns)
                {
                    if (col.Visible)
                        width += col.Width;
                }
                if (width > parentform.Width)
                {
                    width = parentform.Width - Location.X;
                }
                view.Width = width;
                view.Height = height;
                DroppedDown = true;
            }
            else
            {
                if (parentform == null)
                {
                    parentform = FindForm();
                }
                parentform.Controls.Remove(view);
                DroppedDown = false;
            }
        }
        /// <summary>
        /// The <see cref="EventArgs"/> when Value is changed
        /// </summary>
        public event CCBValueChangedEventHandler ValueChanged;

        /// <summary>
        /// The <see cref="EventArgs"/> when Value is changed
        /// </summary>
        public class CCBValueChangedEventArgs : EventArgs
        {
            public DataRow selectedRow { get; set; }
        }
        /// <summary>
        /// The <see cref="EventArgs"/> when Value is changed
        /// </summary>
        public delegate void CCBValueChangedEventHandler(object sender, CCBValueChangedEventArgs e);
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!Focused && !view.Focused && !DropDownButton.Focused)
            {
                if (parentform == null)
                {
                    parentform = FindForm();
                }
                parentform.Controls.Remove(view);
                DroppedDown = false;
            }
        }
        #region DropDownButton
        private class DButton : Button
        {
            private bool isHovered = false;
            private bool isPressed = false;
            private bool isFocused = false;

           
            protected override bool ShowFocusCues
            {
                get
                {
                    return false;
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                try
                {
                    if (GetStyle(ControlStyles.AllPaintingInWmPaint))
                    {
                        OnPaintBackground(e);
                    }
                    OnPaintForeground(e);
                }
                catch
                {
                    Invalidate();
                }
            }

            protected virtual void OnPaintForeground(PaintEventArgs e)
            {
                Color foreColor = MetroPaint.GetStyleColor(MetroColorStyle.Silver);
                using (SolidBrush b = new SolidBrush(foreColor))
                {
                    e.Graphics.FillPolygon(b, new Point[] { new Point(Width - 20, (Height / 2) - 2), new Point(Width - 9, (Height / 2) - 2), new Point(Width - 15, (Height / 2) + 4) });
                }

                if (isFocused)
                    ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle);
            }  
        }
        #endregion

    }
}
