namespace PMQL_BookStores.GUI
{
    partial class frm_ThongKeSTK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpTopTKTK = new System.Windows.Forms.GroupBox();
            this.lblTongSoLuongTKTK = new System.Windows.Forms.Label();
            this.btnSachTrongKhoTKTK = new System.Windows.Forms.Button();
            this.btnThongKeTKTK = new System.Windows.Forms.Button();
            this.cboLoaiSachTKTK = new System.Windows.Forms.ComboBox();
            this.lblLoaiSachTKTK = new System.Windows.Forms.Label();
            this.lblTieuDeTKTK = new System.Windows.Forms.Label();
            this.dgvDanhSachTKTK = new System.Windows.Forms.DataGridView();
            this.gpTopTKTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachTKTK)).BeginInit();
            this.SuspendLayout();
            // 
            // gpTopTKTK
            // 
            this.gpTopTKTK.BackColor = System.Drawing.Color.Transparent;
            this.gpTopTKTK.BackgroundImage = global::PMQL_BookStores.Properties.Resources.BGNhapLieu3;
            this.gpTopTKTK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gpTopTKTK.Controls.Add(this.lblTongSoLuongTKTK);
            this.gpTopTKTK.Controls.Add(this.btnSachTrongKhoTKTK);
            this.gpTopTKTK.Controls.Add(this.btnThongKeTKTK);
            this.gpTopTKTK.Controls.Add(this.cboLoaiSachTKTK);
            this.gpTopTKTK.Controls.Add(this.lblLoaiSachTKTK);
            this.gpTopTKTK.Controls.Add(this.lblTieuDeTKTK);
            this.gpTopTKTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpTopTKTK.Location = new System.Drawing.Point(13, -12);
            this.gpTopTKTK.Name = "gpTopTKTK";
            this.gpTopTKTK.Size = new System.Drawing.Size(1187, 209);
            this.gpTopTKTK.TabIndex = 0;
            this.gpTopTKTK.TabStop = false;
            // 
            // lblTongSoLuongTKTK
            // 
            this.lblTongSoLuongTKTK.AutoSize = true;
            this.lblTongSoLuongTKTK.BackColor = System.Drawing.Color.Transparent;
            this.lblTongSoLuongTKTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSoLuongTKTK.ForeColor = System.Drawing.Color.Yellow;
            this.lblTongSoLuongTKTK.Location = new System.Drawing.Point(6, 172);
            this.lblTongSoLuongTKTK.Name = "lblTongSoLuongTKTK";
            this.lblTongSoLuongTKTK.Size = new System.Drawing.Size(209, 25);
            this.lblTongSoLuongTKTK.TabIndex = 5;
            this.lblTongSoLuongTKTK.Text = "Tổng số lượng sách:";
            // 
            // btnSachTrongKhoTKTK
            // 
            this.btnSachTrongKhoTKTK.BackColor = System.Drawing.Color.Maroon;
            this.btnSachTrongKhoTKTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSachTrongKhoTKTK.ForeColor = System.Drawing.Color.Lime;
            this.btnSachTrongKhoTKTK.Location = new System.Drawing.Point(954, 157);
            this.btnSachTrongKhoTKTK.Name = "btnSachTrongKhoTKTK";
            this.btnSachTrongKhoTKTK.Size = new System.Drawing.Size(227, 46);
            this.btnSachTrongKhoTKTK.TabIndex = 4;
            this.btnSachTrongKhoTKTK.Text = "Sách trong kho";
            this.btnSachTrongKhoTKTK.UseVisualStyleBackColor = false;
            this.btnSachTrongKhoTKTK.Click += new System.EventHandler(this.btnSachTrongKhoTKTK_Click);
            // 
            // btnThongKeTKTK
            // 
            this.btnThongKeTKTK.BackColor = System.Drawing.Color.Lime;
            this.btnThongKeTKTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeTKTK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThongKeTKTK.Location = new System.Drawing.Point(783, 64);
            this.btnThongKeTKTK.Name = "btnThongKeTKTK";
            this.btnThongKeTKTK.Size = new System.Drawing.Size(132, 46);
            this.btnThongKeTKTK.TabIndex = 3;
            this.btnThongKeTKTK.Text = "Thống kê";
            this.btnThongKeTKTK.UseVisualStyleBackColor = false;
            this.btnThongKeTKTK.Click += new System.EventHandler(this.btnThongKeTKTK_Click);
            // 
            // cboLoaiSachTKTK
            // 
            this.cboLoaiSachTKTK.FormattingEnabled = true;
            this.cboLoaiSachTKTK.Location = new System.Drawing.Point(469, 72);
            this.cboLoaiSachTKTK.Name = "cboLoaiSachTKTK";
            this.cboLoaiSachTKTK.Size = new System.Drawing.Size(275, 33);
            this.cboLoaiSachTKTK.TabIndex = 2;
            this.cboLoaiSachTKTK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboLoaiSachTKTK_KeyPress);
            // 
            // lblLoaiSachTKTK
            // 
            this.lblLoaiSachTKTK.AutoSize = true;
            this.lblLoaiSachTKTK.BackColor = System.Drawing.Color.Blue;
            this.lblLoaiSachTKTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiSachTKTK.ForeColor = System.Drawing.SystemColors.Control;
            this.lblLoaiSachTKTK.Location = new System.Drawing.Point(275, 75);
            this.lblLoaiSachTKTK.Name = "lblLoaiSachTKTK";
            this.lblLoaiSachTKTK.Size = new System.Drawing.Size(149, 25);
            this.lblLoaiSachTKTK.TabIndex = 1;
            this.lblLoaiSachTKTK.Text = "Thể loại sách:";
            // 
            // lblTieuDeTKTK
            // 
            this.lblTieuDeTKTK.AutoSize = true;
            this.lblTieuDeTKTK.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDeTKTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTKTK.ForeColor = System.Drawing.Color.Red;
            this.lblTieuDeTKTK.Location = new System.Drawing.Point(405, 21);
            this.lblTieuDeTKTK.Name = "lblTieuDeTKTK";
            this.lblTieuDeTKTK.Size = new System.Drawing.Size(348, 29);
            this.lblTieuDeTKTK.TabIndex = 0;
            this.lblTieuDeTKTK.Text = "THỐNG KÊ SÁCH TỒN KHO";
            // 
            // dgvDanhSachTKTK
            // 
            this.dgvDanhSachTKTK.AllowUserToAddRows = false;
            this.dgvDanhSachTKTK.AllowUserToDeleteRows = false;
            this.dgvDanhSachTKTK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachTKTK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDanhSachTKTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachTKTK.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDanhSachTKTK.Location = new System.Drawing.Point(13, 203);
            this.dgvDanhSachTKTK.Name = "dgvDanhSachTKTK";
            this.dgvDanhSachTKTK.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachTKTK.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDanhSachTKTK.RowHeadersVisible = false;
            this.dgvDanhSachTKTK.RowHeadersWidth = 51;
            this.dgvDanhSachTKTK.RowTemplate.Height = 24;
            this.dgvDanhSachTKTK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachTKTK.Size = new System.Drawing.Size(1187, 421);
            this.dgvDanhSachTKTK.TabIndex = 1;
            // 
            // frm_ThongKeSTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1212, 636);
            this.Controls.Add(this.dgvDanhSachTKTK);
            this.Controls.Add(this.gpTopTKTK);
            this.Name = "frm_ThongKeSTK";
            this.Text = "BookStores - Thống kê sách tồn kho";
            this.Load += new System.EventHandler(this.frm_ThongKeSTK_Load);
            this.gpTopTKTK.ResumeLayout(false);
            this.gpTopTKTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachTKTK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpTopTKTK;
        private System.Windows.Forms.Label lblLoaiSachTKTK;
        private System.Windows.Forms.Label lblTieuDeTKTK;
        private System.Windows.Forms.Label lblTongSoLuongTKTK;
        private System.Windows.Forms.Button btnSachTrongKhoTKTK;
        private System.Windows.Forms.Button btnThongKeTKTK;
        private System.Windows.Forms.ComboBox cboLoaiSachTKTK;
        private System.Windows.Forms.DataGridView dgvDanhSachTKTK;
    }
}