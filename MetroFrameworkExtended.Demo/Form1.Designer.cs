namespace OLEWinForm.Demo
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            OLE.Winform.OLEComboBox.OLEComboObjectCollection oleComboObjectCollection1 = new OLE.Winform.OLEComboBox.OLEComboObjectCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.oleTab1 = new OLE.Winform.OLETab();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.oleDataGridView1 = new OLE.Winform.OLEDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.olePictureBox1 = new OLE.Winform.OLEPictureBox();
            this.oleFixedPictureBox1 = new OLE.Winform.OLEFixedPictureBox();
            this.oleSubmit1 = new OLE.Winform.OLESubmit();
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.oleTextBox1 = new OLE.Winform.OLETextBox();
            this.oleComboBox1 = new OLE.Winform.OLEComboBox();
            this.oleColumnComboBox1 = new OLE.Winform.OLEColumnComboBox();
            this.oleCaptcha1 = new OLE.Winform.OLECaptcha();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.oleBarChart1 = new OLE.Winform.OLEBarChart();
            this.oleTab1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oleDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.olePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleFixedPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleCaptcha1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oleBarChart1)).BeginInit();
            this.SuspendLayout();
            // 
            // oleTab1
            // 
            this.oleTab1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.oleTab1.Controls.Add(this.tabPage1);
            this.oleTab1.Controls.Add(this.tabPage2);
            this.oleTab1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.oleTab1.ErrorProvider = null;
            this.oleTab1.ItemSize = new System.Drawing.Size(40, 200);
            this.oleTab1.Location = new System.Drawing.Point(1, 63);
            this.oleTab1.Multiline = true;
            this.oleTab1.Name = "oleTab1";
            this.oleTab1.Required = false;
            this.oleTab1.SelectedIndex = 0;
            this.oleTab1.Size = new System.Drawing.Size(797, 385);
            this.oleTab1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.oleTab1.TabIndex = 0;
            this.oleTab1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.oleTab1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.oleDataGridView1);
            this.tabPage1.Controls.Add(this.olePictureBox1);
            this.tabPage1.Controls.Add(this.oleFixedPictureBox1);
            this.tabPage1.Controls.Add(this.oleSubmit1);
            this.tabPage1.Controls.Add(this.htmlLabel1);
            this.tabPage1.Controls.Add(this.oleTextBox1);
            this.tabPage1.Controls.Add(this.oleComboBox1);
            this.tabPage1.Controls.Add(this.oleColumnComboBox1);
            this.tabPage1.Controls.Add(this.oleCaptcha1);
            this.tabPage1.Location = new System.Drawing.Point(204, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 377);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // oleDataGridView1
            // 
            this.oleDataGridView1.AllowUserToResizeRows = false;
            this.oleDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.oleDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.oleDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oleDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.oleDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.oleDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.oleDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oleDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.oleDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.oleDataGridView1.EnableHeadersVisualStyles = false;
            this.oleDataGridView1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.oleDataGridView1.FontSize = 11F;
            this.oleDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.oleDataGridView1.Location = new System.Drawing.Point(143, 152);
            this.oleDataGridView1.Name = "oleDataGridView1";
            this.oleDataGridView1.Required = false;
            this.oleDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.oleDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.oleDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.oleDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.oleDataGridView1.SetMoneyFormat = true;
            this.oleDataGridView1.Size = new System.Drawing.Size(429, 186);
            this.oleDataGridView1.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // olePictureBox1
            // 
            this.olePictureBox1.Base64 = null;
            this.olePictureBox1.Location = new System.Drawing.Point(6, 269);
            this.olePictureBox1.Name = "olePictureBox1";
            this.olePictureBox1.Required = false;
            this.olePictureBox1.Size = new System.Drawing.Size(131, 69);
            this.olePictureBox1.TabIndex = 8;
            this.olePictureBox1.TabStop = false;
            this.olePictureBox1.Text = null;
            // 
            // oleFixedPictureBox1
            // 
            this.oleFixedPictureBox1.Base64 = null;
            this.oleFixedPictureBox1.Location = new System.Drawing.Point(6, 203);
            this.oleFixedPictureBox1.Name = "oleFixedPictureBox1";
            this.oleFixedPictureBox1.Required = false;
            this.oleFixedPictureBox1.Size = new System.Drawing.Size(131, 60);
            this.oleFixedPictureBox1.TabIndex = 7;
            this.oleFixedPictureBox1.TabStop = false;
            this.oleFixedPictureBox1.Text = null;
            // 
            // oleSubmit1
            // 
            this.oleSubmit1.API = null;
            this.oleSubmit1.Location = new System.Drawing.Point(6, 152);
            this.oleSubmit1.Name = "oleSubmit1";
            this.oleSubmit1.Size = new System.Drawing.Size(131, 45);
            this.oleSubmit1.TabIndex = 5;
            this.oleSubmit1.Text = "oleSubmit1";
            this.oleSubmit1.UseVisualStyleBackColor = true;
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(391, 23);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Location = new System.Drawing.Point(6, 100);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(296, 46);
            this.htmlLabel1.TabIndex = 4;
            this.htmlLabel1.Text = "Testing a very long long long long long long long long long long long long text";
            // 
            // oleTextBox1
            // 
            this.oleTextBox1.Location = new System.Drawing.Point(6, 68);
            this.oleTextBox1.Mask = OLE.Winform.MaskType.None;
            this.oleTextBox1.Name = "oleTextBox1";
            this.oleTextBox1.Required = false;
            this.oleTextBox1.Size = new System.Drawing.Size(296, 26);
            this.oleTextBox1.TabIndex = 3;
            // 
            // oleComboBox1
            // 
            this.oleComboBox1.FormattingEnabled = true;
            this.oleComboBox1.ItemHeight = 23;
            this.oleComboBox1.Location = new System.Drawing.Point(6, 33);
            this.oleComboBox1.Name = "oleComboBox1";
            this.oleComboBox1.Objects = oleComboObjectCollection1;
            this.oleComboBox1.Required = false;
            this.oleComboBox1.Size = new System.Drawing.Size(296, 29);
            this.oleComboBox1.TabIndex = 2;
            this.oleComboBox1.UseSelectable = true;
            this.oleComboBox1.Value = null;
            // 
            // oleColumnComboBox1
            // 
            this.oleColumnComboBox1.Columns = null;
            this.oleColumnComboBox1.ColumnUsed = "id";
            this.oleColumnComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oleColumnComboBox1.Location = new System.Drawing.Point(6, 6);
            this.oleColumnComboBox1.Name = "oleColumnComboBox1";
            this.oleColumnComboBox1.Required = false;
            this.oleColumnComboBox1.Size = new System.Drawing.Size(296, 26);
            this.oleColumnComboBox1.TabIndex = 1;
            // 
            // oleCaptcha1
            // 
            this.oleCaptcha1.Image = ((System.Drawing.Image)(resources.GetObject("oleCaptcha1.Image")));
            this.oleCaptcha1.Location = new System.Drawing.Point(308, 6);
            this.oleCaptcha1.Name = "oleCaptcha1";
            this.oleCaptcha1.Size = new System.Drawing.Size(275, 140);
            this.oleCaptcha1.TabIndex = 0;
            this.oleCaptcha1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.oleBarChart1);
            this.tabPage2.Location = new System.Drawing.Point(204, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // oleBarChart1
            // 
            chartArea1.Name = "ChartArea1";
            this.oleBarChart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.oleBarChart1.Legends.Add(legend1);
            this.oleBarChart1.Location = new System.Drawing.Point(29, 48);
            this.oleBarChart1.Name = "oleBarChart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.oleBarChart1.Series.Add(series1);
            this.oleBarChart1.Size = new System.Drawing.Size(300, 300);
            this.oleBarChart1.TabIndex = 0;
            this.oleBarChart1.Text = "oleBarChart1";
            this.oleBarChart1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.oleBarChart1.UseSelectable = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.oleTab1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.oleTab1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oleDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.olePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleFixedPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oleCaptcha1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oleBarChart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OLE.Winform.OLETab oleTab1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private OLE.Winform.OLECaptcha oleCaptcha1;
        private OLE.Winform.OLETextBox oleTextBox1;
        private OLE.Winform.OLEComboBox oleComboBox1;
        private OLE.Winform.OLEColumnComboBox oleColumnComboBox1;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
        private OLE.Winform.OLESubmit oleSubmit1;
        private OLE.Winform.OLEPictureBox olePictureBox1;
        private OLE.Winform.OLEFixedPictureBox oleFixedPictureBox1;
        private OLE.Winform.OLEDataGridView oleDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private OLE.Winform.OLEBarChart oleBarChart1;
    }
}

