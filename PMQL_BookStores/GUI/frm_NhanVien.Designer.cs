namespace PMQL_BookStores.GUI
{
    partial class frm_NhanVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NhanVien));
            this.dgvAddNhanVien = new System.Windows.Forms.DataGridView();
            this.pnlAddNhanVien = new System.Windows.Forms.Panel();
            this.cboChucVuNV = new System.Windows.Forms.ComboBox();
            this.lblChucVuNV = new System.Windows.Forms.Label();
            this.picSearchNV = new System.Windows.Forms.PictureBox();
            this.txtSearchNV = new System.Windows.Forms.TextBox();
            this.picClearNV = new System.Windows.Forms.PictureBox();
            this.picUDNV = new System.Windows.Forms.PictureBox();
            this.picDelNV = new System.Windows.Forms.PictureBox();
            this.picAddNV = new System.Windows.Forms.PictureBox();
            this.txtSDTNV = new System.Windows.Forms.TextBox();
            this.lblSDTNV = new System.Windows.Forms.Label();
            this.txtDiaChiNV = new System.Windows.Forms.TextBox();
            this.lblDiaChiNV = new System.Windows.Forms.Label();
            this.dtpNgaySinhNV = new System.Windows.Forms.DateTimePicker();
            this.lblNgaySinhNV = new System.Windows.Forms.Label();
            this.cboGioiTinhNV = new System.Windows.Forms.ComboBox();
            this.lblGioiTinhNV = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.txtTenLotNV = new System.Windows.Forms.TextBox();
            this.lblTenLotNV = new System.Windows.Forms.Label();
            this.txtHoNV = new System.Windows.Forms.TextBox();
            this.lblHoNV = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddNhanVien)).BeginInit();
            this.pnlAddNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddNV)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAddNhanVien
            // 
            this.dgvAddNhanVien.AllowUserToAddRows = false;
            this.dgvAddNhanVien.AllowUserToDeleteRows = false;
            this.dgvAddNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAddNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAddNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAddNhanVien.Location = new System.Drawing.Point(2, 182);
            this.dgvAddNhanVien.Name = "dgvAddNhanVien";
            this.dgvAddNhanVien.ReadOnly = true;
            this.dgvAddNhanVien.RowHeadersVisible = false;
            this.dgvAddNhanVien.RowHeadersWidth = 51;
            this.dgvAddNhanVien.RowTemplate.Height = 24;
            this.dgvAddNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddNhanVien.Size = new System.Drawing.Size(1210, 453);
            this.dgvAddNhanVien.TabIndex = 3;
            this.dgvAddNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddNhanVien_CellClick);
            this.dgvAddNhanVien.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAddNhanVien_CellFormatting);
            // 
            // pnlAddNhanVien
            // 
            this.pnlAddNhanVien.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAddNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddNhanVien.Controls.Add(this.cboChucVuNV);
            this.pnlAddNhanVien.Controls.Add(this.lblChucVuNV);
            this.pnlAddNhanVien.Controls.Add(this.picSearchNV);
            this.pnlAddNhanVien.Controls.Add(this.txtSearchNV);
            this.pnlAddNhanVien.Controls.Add(this.picClearNV);
            this.pnlAddNhanVien.Controls.Add(this.picUDNV);
            this.pnlAddNhanVien.Controls.Add(this.picDelNV);
            this.pnlAddNhanVien.Controls.Add(this.picAddNV);
            this.pnlAddNhanVien.Controls.Add(this.txtSDTNV);
            this.pnlAddNhanVien.Controls.Add(this.lblSDTNV);
            this.pnlAddNhanVien.Controls.Add(this.txtDiaChiNV);
            this.pnlAddNhanVien.Controls.Add(this.lblDiaChiNV);
            this.pnlAddNhanVien.Controls.Add(this.dtpNgaySinhNV);
            this.pnlAddNhanVien.Controls.Add(this.lblNgaySinhNV);
            this.pnlAddNhanVien.Controls.Add(this.cboGioiTinhNV);
            this.pnlAddNhanVien.Controls.Add(this.lblGioiTinhNV);
            this.pnlAddNhanVien.Controls.Add(this.txtTenNV);
            this.pnlAddNhanVien.Controls.Add(this.lblTenNV);
            this.pnlAddNhanVien.Controls.Add(this.txtTenLotNV);
            this.pnlAddNhanVien.Controls.Add(this.lblTenLotNV);
            this.pnlAddNhanVien.Controls.Add(this.txtHoNV);
            this.pnlAddNhanVien.Controls.Add(this.lblHoNV);
            this.pnlAddNhanVien.Location = new System.Drawing.Point(2, 2);
            this.pnlAddNhanVien.Name = "pnlAddNhanVien";
            this.pnlAddNhanVien.Size = new System.Drawing.Size(1210, 174);
            this.pnlAddNhanVien.TabIndex = 2;
            // 
            // cboChucVuNV
            // 
            this.cboChucVuNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChucVuNV.FormattingEnabled = true;
            this.cboChucVuNV.Items.AddRange(new object[] {
            "Thu Ngân",
            "Quản Lý Kho"});
            this.cboChucVuNV.Location = new System.Drawing.Point(522, 77);
            this.cboChucVuNV.Name = "cboChucVuNV";
            this.cboChucVuNV.Size = new System.Drawing.Size(180, 28);
            this.cboChucVuNV.TabIndex = 43;
            this.cboChucVuNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboChucVuNV_KeyPress);
            // 
            // lblChucVuNV
            // 
            this.lblChucVuNV.AutoSize = true;
            this.lblChucVuNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChucVuNV.Location = new System.Drawing.Point(415, 80);
            this.lblChucVuNV.Name = "lblChucVuNV";
            this.lblChucVuNV.Size = new System.Drawing.Size(83, 20);
            this.lblChucVuNV.TabIndex = 42;
            this.lblChucVuNV.Text = "Chức vụ:";
            // 
            // picSearchNV
            // 
            this.picSearchNV.Image = global::PMQL_BookStores.Properties.Resources.kinh_lup;
            this.picSearchNV.Location = new System.Drawing.Point(49, 122);
            this.picSearchNV.Name = "picSearchNV";
            this.picSearchNV.Size = new System.Drawing.Size(29, 30);
            this.picSearchNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearchNV.TabIndex = 41;
            this.picSearchNV.TabStop = false;
            this.picSearchNV.Click += new System.EventHandler(this.picSearchNV_Click);
            // 
            // txtSearchNV
            // 
            this.txtSearchNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchNV.Location = new System.Drawing.Point(84, 122);
            this.txtSearchNV.Name = "txtSearchNV";
            this.txtSearchNV.Size = new System.Drawing.Size(363, 30);
            this.txtSearchNV.TabIndex = 40;
            this.txtSearchNV.TextChanged += new System.EventHandler(this.txtSearchNV_TextChanged);
            this.txtSearchNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchNV_KeyPress);
            // 
            // picClearNV
            // 
            this.picClearNV.BackColor = System.Drawing.Color.Transparent;
            this.picClearNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picClearNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClearNV.Image = global::PMQL_BookStores.Properties.Resources.LamMoi;
            this.picClearNV.Location = new System.Drawing.Point(1059, 117);
            this.picClearNV.Name = "picClearNV";
            this.picClearNV.Size = new System.Drawing.Size(139, 41);
            this.picClearNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClearNV.TabIndex = 39;
            this.picClearNV.TabStop = false;
            this.picClearNV.Click += new System.EventHandler(this.picClearNV_Click);
            // 
            // picUDNV
            // 
            this.picUDNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUDNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUDNV.Image = global::PMQL_BookStores.Properties.Resources.Update;
            this.picUDNV.Location = new System.Drawing.Point(900, 117);
            this.picUDNV.Name = "picUDNV";
            this.picUDNV.Size = new System.Drawing.Size(139, 41);
            this.picUDNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUDNV.TabIndex = 38;
            this.picUDNV.TabStop = false;
            this.picUDNV.Click += new System.EventHandler(this.picUDNV_Click);
            // 
            // picDelNV
            // 
            this.picDelNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDelNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelNV.Image = global::PMQL_BookStores.Properties.Resources.Delete;
            this.picDelNV.Location = new System.Drawing.Point(738, 117);
            this.picDelNV.Name = "picDelNV";
            this.picDelNV.Size = new System.Drawing.Size(139, 41);
            this.picDelNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelNV.TabIndex = 37;
            this.picDelNV.TabStop = false;
            this.picDelNV.Click += new System.EventHandler(this.picDelNV_Click);
            // 
            // picAddNV
            // 
            this.picAddNV.BackColor = System.Drawing.Color.Transparent;
            this.picAddNV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAddNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddNV.Image = global::PMQL_BookStores.Properties.Resources.Add;
            this.picAddNV.Location = new System.Drawing.Point(581, 117);
            this.picAddNV.Name = "picAddNV";
            this.picAddNV.Size = new System.Drawing.Size(139, 41);
            this.picAddNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddNV.TabIndex = 36;
            this.picAddNV.TabStop = false;
            this.picAddNV.Click += new System.EventHandler(this.picAddNV_Click);
            // 
            // txtSDTNV
            // 
            this.txtSDTNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDTNV.Location = new System.Drawing.Point(924, 44);
            this.txtSDTNV.MaxLength = 11;
            this.txtSDTNV.Name = "txtSDTNV";
            this.txtSDTNV.Size = new System.Drawing.Size(274, 27);
            this.txtSDTNV.TabIndex = 13;
            this.txtSDTNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDTNV_KeyPress);
            // 
            // lblSDTNV
            // 
            this.lblSDTNV.AutoSize = true;
            this.lblSDTNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDTNV.Location = new System.Drawing.Point(767, 50);
            this.lblSDTNV.Name = "lblSDTNV";
            this.lblSDTNV.Size = new System.Drawing.Size(125, 20);
            this.lblSDTNV.TabIndex = 12;
            this.lblSDTNV.Text = "Số điện thoại:";
            // 
            // txtDiaChiNV
            // 
            this.txtDiaChiNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiNV.Location = new System.Drawing.Point(924, 8);
            this.txtDiaChiNV.Name = "txtDiaChiNV";
            this.txtDiaChiNV.Size = new System.Drawing.Size(274, 27);
            this.txtDiaChiNV.TabIndex = 11;
            // 
            // lblDiaChiNV
            // 
            this.lblDiaChiNV.AutoSize = true;
            this.lblDiaChiNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChiNV.Location = new System.Drawing.Point(818, 11);
            this.lblDiaChiNV.Name = "lblDiaChiNV";
            this.lblDiaChiNV.Size = new System.Drawing.Size(74, 20);
            this.lblDiaChiNV.TabIndex = 10;
            this.lblDiaChiNV.Text = "Địa chỉ:";
            // 
            // dtpNgaySinhNV
            // 
            this.dtpNgaySinhNV.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinhNV.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinhNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinhNV.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinhNV.Location = new System.Drawing.Point(522, 45);
            this.dtpNgaySinhNV.Name = "dtpNgaySinhNV";
            this.dtpNgaySinhNV.Size = new System.Drawing.Size(180, 27);
            this.dtpNgaySinhNV.TabIndex = 9;
            this.dtpNgaySinhNV.Value = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            // 
            // lblNgaySinhNV
            // 
            this.lblNgaySinhNV.AutoSize = true;
            this.lblNgaySinhNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinhNV.Location = new System.Drawing.Point(400, 47);
            this.lblNgaySinhNV.Name = "lblNgaySinhNV";
            this.lblNgaySinhNV.Size = new System.Drawing.Size(98, 20);
            this.lblNgaySinhNV.TabIndex = 8;
            this.lblNgaySinhNV.Text = "Ngày sinh:";
            // 
            // cboGioiTinhNV
            // 
            this.cboGioiTinhNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGioiTinhNV.FormattingEnabled = true;
            this.cboGioiTinhNV.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGioiTinhNV.Location = new System.Drawing.Point(522, 8);
            this.cboGioiTinhNV.Name = "cboGioiTinhNV";
            this.cboGioiTinhNV.Size = new System.Drawing.Size(121, 28);
            this.cboGioiTinhNV.TabIndex = 7;
            this.cboGioiTinhNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboGioiTinhNV_KeyPress);
            // 
            // lblGioiTinhNV
            // 
            this.lblGioiTinhNV.AutoSize = true;
            this.lblGioiTinhNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinhNV.Location = new System.Drawing.Point(412, 11);
            this.lblGioiTinhNV.Name = "lblGioiTinhNV";
            this.lblGioiTinhNV.Size = new System.Drawing.Size(86, 20);
            this.lblGioiTinhNV.TabIndex = 6;
            this.lblGioiTinhNV.Text = "Giới tính:";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Location = new System.Drawing.Point(117, 72);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(232, 27);
            this.txtTenNV.TabIndex = 5;
            this.txtTenNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenNV_KeyPress);
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSize = true;
            this.lblTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Location = new System.Drawing.Point(54, 72);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(46, 20);
            this.lblTenNV.TabIndex = 4;
            this.lblTenNV.Text = "Tên:";
            // 
            // txtTenLotNV
            // 
            this.txtTenLotNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLotNV.Location = new System.Drawing.Point(115, 39);
            this.txtTenLotNV.Name = "txtTenLotNV";
            this.txtTenLotNV.Size = new System.Drawing.Size(232, 27);
            this.txtTenLotNV.TabIndex = 3;
            this.txtTenLotNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenLotNV_KeyPress);
            // 
            // lblTenLotNV
            // 
            this.lblTenLotNV.AutoSize = true;
            this.lblTenLotNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLotNV.Location = new System.Drawing.Point(13, 41);
            this.lblTenLotNV.Name = "lblTenLotNV";
            this.lblTenLotNV.Size = new System.Drawing.Size(87, 20);
            this.lblTenLotNV.TabIndex = 2;
            this.lblTenLotNV.Text = "Tên đệm:";
            // 
            // txtHoNV
            // 
            this.txtHoNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoNV.Location = new System.Drawing.Point(115, 5);
            this.txtHoNV.Name = "txtHoNV";
            this.txtHoNV.Size = new System.Drawing.Size(232, 27);
            this.txtHoNV.TabIndex = 1;
            this.txtHoNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoNV_KeyPress);
            // 
            // lblHoNV
            // 
            this.lblHoNV.AutoSize = true;
            this.lblHoNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoNV.Location = new System.Drawing.Point(61, 8);
            this.lblHoNV.Name = "lblHoNV";
            this.lblHoNV.Size = new System.Drawing.Size(39, 20);
            this.lblHoNV.TabIndex = 0;
            this.lblHoNV.Text = "Họ:";
            // 
            // frm_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 636);
            this.Controls.Add(this.dgvAddNhanVien);
            this.Controls.Add(this.pnlAddNhanVien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_NhanVien";
            this.Text = "BookStores - Nhân Viên";
            this.Load += new System.EventHandler(this.frm_NhanVien_Load);
            this.Shown += new System.EventHandler(this.frm_NhanVien_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddNhanVien)).EndInit();
            this.pnlAddNhanVien.ResumeLayout(false);
            this.pnlAddNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAddNhanVien;
        private System.Windows.Forms.Panel pnlAddNhanVien;
        private System.Windows.Forms.PictureBox picSearchNV;
        private System.Windows.Forms.TextBox txtSearchNV;
        private System.Windows.Forms.PictureBox picClearNV;
        private System.Windows.Forms.PictureBox picUDNV;
        private System.Windows.Forms.PictureBox picDelNV;
        private System.Windows.Forms.PictureBox picAddNV;
        private System.Windows.Forms.TextBox txtSDTNV;
        private System.Windows.Forms.Label lblSDTNV;
        private System.Windows.Forms.TextBox txtDiaChiNV;
        private System.Windows.Forms.Label lblDiaChiNV;
        private System.Windows.Forms.DateTimePicker dtpNgaySinhNV;
        private System.Windows.Forms.Label lblNgaySinhNV;
        private System.Windows.Forms.ComboBox cboGioiTinhNV;
        private System.Windows.Forms.Label lblGioiTinhNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.TextBox txtTenLotNV;
        private System.Windows.Forms.Label lblTenLotNV;
        private System.Windows.Forms.TextBox txtHoNV;
        private System.Windows.Forms.Label lblHoNV;
        private System.Windows.Forms.ComboBox cboChucVuNV;
        private System.Windows.Forms.Label lblChucVuNV;
    }
}