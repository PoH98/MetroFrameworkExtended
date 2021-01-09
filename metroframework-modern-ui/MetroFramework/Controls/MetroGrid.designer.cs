namespace MetroFramework.Controls
{
    partial class MetroGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._horizontal = new MetroFramework.Controls.MetroScrollBar();
            this._vertical = new MetroFramework.Controls.MetroScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // _horizontal
            // 
            this._horizontal.LargeChange = 10;
            this._horizontal.Location = new System.Drawing.Point(0, 0);
            this._horizontal.Maximum = 100;
            this._horizontal.Minimum = 0;
            this._horizontal.MouseWheelBarPartitions = 10;
            this._horizontal.Name = "_horizontal";
            this._horizontal.Orientation = MetroFramework.Controls.MetroScrollOrientation.Horizontal;
            this._horizontal.ScrollbarSize = 50;
            this._horizontal.Size = new System.Drawing.Size(200, 50);
            this._horizontal.TabIndex = 0;
            this._horizontal.UseSelectable = true;
            // 
            // _vertical
            // 
            this._vertical.LargeChange = 10;
            this._vertical.Location = new System.Drawing.Point(0, 0);
            this._vertical.Maximum = 100;
            this._vertical.Minimum = 0;
            this._vertical.MouseWheelBarPartitions = 10;
            this._vertical.Name = "_vertical";
            this._vertical.Orientation = MetroFramework.Controls.MetroScrollOrientation.Vertical;
            this._vertical.ScrollbarSize = 50;
            this._vertical.Size = new System.Drawing.Size(50, 200);
            this._vertical.TabIndex = 0;
            this._vertical.UseSelectable = true;
            // 
            // MetroGrid
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DefaultCellStyle = dataGridViewCellStyle1;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroScrollBar _horizontal;
        private MetroFramework.Controls.MetroScrollBar _vertical;
    }
}
