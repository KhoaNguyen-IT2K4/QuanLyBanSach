namespace PMQL_BookStores.GUI
{
    partial class frm_HoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_HoaDon));
            this.tcAddHoaDon = new System.Windows.Forms.TabControl();
            this.tpHoaDon = new System.Windows.Forms.TabPage();
            this.dgvAddHD = new System.Windows.Forms.DataGridView();
            this.pnlAddHD = new System.Windows.Forms.Panel();
            this.lbldvttHD = new System.Windows.Forms.Label();
            this.txtTongSoLuongHD = new System.Windows.Forms.TextBox();
            this.txtTongTienHD = new System.Windows.Forms.TextBox();
            this.picInHoaDon = new System.Windows.Forms.PictureBox();
            this.picSearchHD = new System.Windows.Forms.PictureBox();
            this.txtSearchHD = new System.Windows.Forms.TextBox();
            this.picClearHD = new System.Windows.Forms.PictureBox();
            this.picUDHD = new System.Windows.Forms.PictureBox();
            this.picDelHD = new System.Windows.Forms.PictureBox();
            this.lblTongSoLuongHD = new System.Windows.Forms.Label();
            this.picAddHD = new System.Windows.Forms.PictureBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.cboMaKHHD = new System.Windows.Forms.ComboBox();
            this.lblMaKHHD = new System.Windows.Forms.Label();
            this.cboMaNVHD = new System.Windows.Forms.ComboBox();
            this.lblMaNVHD = new System.Windows.Forms.Label();
            this.tpCTHD = new System.Windows.Forms.TabPage();
            this.dgvAddCTHD = new System.Windows.Forms.DataGridView();
            this.pnlAddCTHD = new System.Windows.Forms.Panel();
            this.txtGiaThanhCTHD = new System.Windows.Forms.TextBox();
            this.lbldvgtCTHD = new System.Windows.Forms.Label();
            this.cboMaHDCTHD = new System.Windows.Forms.ComboBox();
            this.lblMaHDCTHD = new System.Windows.Forms.Label();
            this.picSearchCTHD = new System.Windows.Forms.PictureBox();
            this.txtSearchCTHD = new System.Windows.Forms.TextBox();
            this.picClearCTHD = new System.Windows.Forms.PictureBox();
            this.picUDCTHD = new System.Windows.Forms.PictureBox();
            this.picDelCTHD = new System.Windows.Forms.PictureBox();
            this.picAddCTHD = new System.Windows.Forms.PictureBox();
            this.lblGiaThanhCTHD = new System.Windows.Forms.Label();
            this.nudSoLuongBan = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongBan = new System.Windows.Forms.Label();
            this.cboMaSachCTHD = new System.Windows.Forms.ComboBox();
            this.lblMaSachCTHD = new System.Windows.Forms.Label();
            this.tltInHoaDon = new System.Windows.Forms.ToolTip(this.components);
            this.pdocHoaDon = new System.Drawing.Printing.PrintDocument();
            this.ppdHoaDon = new System.Windows.Forms.PrintPreviewDialog();
            this.tcAddHoaDon.SuspendLayout();
            this.tpHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddHD)).BeginInit();
            this.pnlAddHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddHD)).BeginInit();
            this.tpCTHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddCTHD)).BeginInit();
            this.pnlAddCTHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongBan)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAddHoaDon
            // 
            this.tcAddHoaDon.Controls.Add(this.tpHoaDon);
            this.tcAddHoaDon.Controls.Add(this.tpCTHD);
            this.tcAddHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddHoaDon.Location = new System.Drawing.Point(1, 2);
            this.tcAddHoaDon.Name = "tcAddHoaDon";
            this.tcAddHoaDon.SelectedIndex = 0;
            this.tcAddHoaDon.Size = new System.Drawing.Size(1211, 635);
            this.tcAddHoaDon.TabIndex = 0;
            this.tcAddHoaDon.SelectedIndexChanged += new System.EventHandler(this.tcAddHoaDon_SelectedIndexChanged);
            // 
            // tpHoaDon
            // 
            this.tpHoaDon.Controls.Add(this.dgvAddHD);
            this.tpHoaDon.Controls.Add(this.pnlAddHD);
            this.tpHoaDon.Location = new System.Drawing.Point(4, 34);
            this.tpHoaDon.Name = "tpHoaDon";
            this.tpHoaDon.Padding = new System.Windows.Forms.Padding(3);
            this.tpHoaDon.Size = new System.Drawing.Size(1203, 597);
            this.tpHoaDon.TabIndex = 0;
            this.tpHoaDon.Text = "Hóa đơn";
            this.tpHoaDon.UseVisualStyleBackColor = true;
            // 
            // dgvAddHD
            // 
            this.dgvAddHD.AllowUserToAddRows = false;
            this.dgvAddHD.AllowUserToDeleteRows = false;
            this.dgvAddHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddHD.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAddHD.Location = new System.Drawing.Point(7, 215);
            this.dgvAddHD.Name = "dgvAddHD";
            this.dgvAddHD.ReadOnly = true;
            this.dgvAddHD.RowHeadersVisible = false;
            this.dgvAddHD.RowHeadersWidth = 51;
            this.dgvAddHD.RowTemplate.Height = 24;
            this.dgvAddHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddHD.Size = new System.Drawing.Size(1188, 373);
            this.dgvAddHD.TabIndex = 1;
            this.dgvAddHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddHD_CellClick);
            this.dgvAddHD.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAddHD_CellFormatting);
            // 
            // pnlAddHD
            // 
            this.pnlAddHD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAddHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddHD.Controls.Add(this.lbldvttHD);
            this.pnlAddHD.Controls.Add(this.txtTongSoLuongHD);
            this.pnlAddHD.Controls.Add(this.txtTongTienHD);
            this.pnlAddHD.Controls.Add(this.picInHoaDon);
            this.pnlAddHD.Controls.Add(this.picSearchHD);
            this.pnlAddHD.Controls.Add(this.txtSearchHD);
            this.pnlAddHD.Controls.Add(this.picClearHD);
            this.pnlAddHD.Controls.Add(this.picUDHD);
            this.pnlAddHD.Controls.Add(this.picDelHD);
            this.pnlAddHD.Controls.Add(this.lblTongSoLuongHD);
            this.pnlAddHD.Controls.Add(this.picAddHD);
            this.pnlAddHD.Controls.Add(this.lblTongTien);
            this.pnlAddHD.Controls.Add(this.dtpNgayLap);
            this.pnlAddHD.Controls.Add(this.lblNgayLap);
            this.pnlAddHD.Controls.Add(this.cboMaKHHD);
            this.pnlAddHD.Controls.Add(this.lblMaKHHD);
            this.pnlAddHD.Controls.Add(this.cboMaNVHD);
            this.pnlAddHD.Controls.Add(this.lblMaNVHD);
            this.pnlAddHD.Location = new System.Drawing.Point(7, 7);
            this.pnlAddHD.Name = "pnlAddHD";
            this.pnlAddHD.Size = new System.Drawing.Size(1188, 202);
            this.pnlAddHD.TabIndex = 0;
            // 
            // lbldvttHD
            // 
            this.lbldvttHD.AutoSize = true;
            this.lbldvttHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldvttHD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbldvttHD.Location = new System.Drawing.Point(1014, 59);
            this.lbldvttHD.Name = "lbldvttHD";
            this.lbldvttHD.Size = new System.Drawing.Size(47, 20);
            this.lbldvttHD.TabIndex = 43;
            this.lbldvttHD.Text = "VNĐ";
            // 
            // txtTongSoLuongHD
            // 
            this.txtTongSoLuongHD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTongSoLuongHD.Enabled = false;
            this.txtTongSoLuongHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoLuongHD.Location = new System.Drawing.Point(815, 14);
            this.txtTongSoLuongHD.Name = "txtTongSoLuongHD";
            this.txtTongSoLuongHD.ReadOnly = true;
            this.txtTongSoLuongHD.Size = new System.Drawing.Size(184, 27);
            this.txtTongSoLuongHD.TabIndex = 0;
            this.txtTongSoLuongHD.Text = "0";
            // 
            // txtTongTienHD
            // 
            this.txtTongTienHD.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTongTienHD.Enabled = false;
            this.txtTongTienHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienHD.Location = new System.Drawing.Point(815, 56);
            this.txtTongTienHD.Name = "txtTongTienHD";
            this.txtTongTienHD.ReadOnly = true;
            this.txtTongTienHD.Size = new System.Drawing.Size(184, 27);
            this.txtTongTienHD.TabIndex = 0;
            this.txtTongTienHD.Text = "0";
            // 
            // picInHoaDon
            // 
            this.picInHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.picInHoaDon.Image = global::PMQL_BookStores.Properties.Resources.printLightGrey;
            this.picInHoaDon.Location = new System.Drawing.Point(1100, 9);
            this.picInHoaDon.Name = "picInHoaDon";
            this.picInHoaDon.Size = new System.Drawing.Size(75, 70);
            this.picInHoaDon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInHoaDon.TabIndex = 42;
            this.picInHoaDon.TabStop = false;
            this.tltInHoaDon.SetToolTip(this.picInHoaDon, "In Hóa Đơn");
            this.picInHoaDon.Click += new System.EventHandler(this.picInHoaDon_Click);
            // 
            // picSearchHD
            // 
            this.picSearchHD.Image = global::PMQL_BookStores.Properties.Resources.kinh_lup;
            this.picSearchHD.Location = new System.Drawing.Point(33, 158);
            this.picSearchHD.Name = "picSearchHD";
            this.picSearchHD.Size = new System.Drawing.Size(36, 30);
            this.picSearchHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearchHD.TabIndex = 41;
            this.picSearchHD.TabStop = false;
            this.picSearchHD.Click += new System.EventHandler(this.picSearchHD_Click);
            // 
            // txtSearchHD
            // 
            this.txtSearchHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchHD.Location = new System.Drawing.Point(75, 158);
            this.txtSearchHD.Name = "txtSearchHD";
            this.txtSearchHD.Size = new System.Drawing.Size(363, 30);
            this.txtSearchHD.TabIndex = 40;
            this.txtSearchHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchHD_KeyPress);
            // 
            // picClearHD
            // 
            this.picClearHD.BackColor = System.Drawing.Color.Transparent;
            this.picClearHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picClearHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClearHD.Image = global::PMQL_BookStores.Properties.Resources.LamMoi;
            this.picClearHD.Location = new System.Drawing.Point(1043, 147);
            this.picClearHD.Name = "picClearHD";
            this.picClearHD.Size = new System.Drawing.Size(132, 41);
            this.picClearHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClearHD.TabIndex = 39;
            this.picClearHD.TabStop = false;
            this.picClearHD.Click += new System.EventHandler(this.picClearHD_Click);
            // 
            // picUDHD
            // 
            this.picUDHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUDHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUDHD.Image = global::PMQL_BookStores.Properties.Resources.Update;
            this.picUDHD.Location = new System.Drawing.Point(885, 147);
            this.picUDHD.Name = "picUDHD";
            this.picUDHD.Size = new System.Drawing.Size(132, 41);
            this.picUDHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUDHD.TabIndex = 38;
            this.picUDHD.TabStop = false;
            this.picUDHD.Click += new System.EventHandler(this.picUDHD_Click);
            // 
            // picDelHD
            // 
            this.picDelHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDelHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelHD.Image = global::PMQL_BookStores.Properties.Resources.Delete;
            this.picDelHD.Location = new System.Drawing.Point(731, 147);
            this.picDelHD.Name = "picDelHD";
            this.picDelHD.Size = new System.Drawing.Size(132, 41);
            this.picDelHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelHD.TabIndex = 37;
            this.picDelHD.TabStop = false;
            this.picDelHD.Click += new System.EventHandler(this.picDelHD_Click);
            // 
            // lblTongSoLuongHD
            // 
            this.lblTongSoLuongHD.AutoSize = true;
            this.lblTongSoLuongHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSoLuongHD.Location = new System.Drawing.Point(663, 17);
            this.lblTongSoLuongHD.Name = "lblTongSoLuongHD";
            this.lblTongSoLuongHD.Size = new System.Drawing.Size(133, 20);
            this.lblTongSoLuongHD.TabIndex = 6;
            this.lblTongSoLuongHD.Text = "Tổng số lượng:";
            // 
            // picAddHD
            // 
            this.picAddHD.BackColor = System.Drawing.Color.Transparent;
            this.picAddHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAddHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddHD.Image = global::PMQL_BookStores.Properties.Resources.Add;
            this.picAddHD.Location = new System.Drawing.Point(580, 147);
            this.picAddHD.Name = "picAddHD";
            this.picAddHD.Size = new System.Drawing.Size(132, 41);
            this.picAddHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddHD.TabIndex = 36;
            this.picAddHD.TabStop = false;
            this.picAddHD.Click += new System.EventHandler(this.picAddHD_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(703, 59);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(93, 20);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy - HH:mm:ss";
            this.dtpNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(331, 105);
            this.dtpNgayLap.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.dtpNgayLap.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(246, 27);
            this.dtpNgayLap.TabIndex = 5;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayLap.Location = new System.Drawing.Point(219, 110);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(88, 20);
            this.lblNgayLap.TabIndex = 4;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // cboMaKHHD
            // 
            this.cboMaKHHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaKHHD.FormattingEnabled = true;
            this.cboMaKHHD.Location = new System.Drawing.Point(332, 59);
            this.cboMaKHHD.Name = "cboMaKHHD";
            this.cboMaKHHD.Size = new System.Drawing.Size(227, 28);
            this.cboMaKHHD.TabIndex = 3;
            this.cboMaKHHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaKHHD_KeyPress);
            // 
            // lblMaKHHD
            // 
            this.lblMaKHHD.AutoSize = true;
            this.lblMaKHHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKHHD.Location = new System.Drawing.Point(135, 62);
            this.lblMaKHHD.Name = "lblMaKHHD";
            this.lblMaKHHD.Size = new System.Drawing.Size(172, 20);
            this.lblMaKHHD.TabIndex = 2;
            this.lblMaKHHD.Text = "Họ tên khách hàng:";
            // 
            // cboMaNVHD
            // 
            this.cboMaNVHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNVHD.FormattingEnabled = true;
            this.cboMaNVHD.Location = new System.Drawing.Point(332, 14);
            this.cboMaNVHD.Name = "cboMaNVHD";
            this.cboMaNVHD.Size = new System.Drawing.Size(227, 28);
            this.cboMaNVHD.TabIndex = 1;
            this.cboMaNVHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaNVHD_KeyPress);
            // 
            // lblMaNVHD
            // 
            this.lblMaNVHD.AutoSize = true;
            this.lblMaNVHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNVHD.Location = new System.Drawing.Point(150, 17);
            this.lblMaNVHD.Name = "lblMaNVHD";
            this.lblMaNVHD.Size = new System.Drawing.Size(157, 20);
            this.lblMaNVHD.TabIndex = 0;
            this.lblMaNVHD.Text = "Họ tên nhân viên:";
            // 
            // tpCTHD
            // 
            this.tpCTHD.Controls.Add(this.dgvAddCTHD);
            this.tpCTHD.Controls.Add(this.pnlAddCTHD);
            this.tpCTHD.Location = new System.Drawing.Point(4, 34);
            this.tpCTHD.Name = "tpCTHD";
            this.tpCTHD.Padding = new System.Windows.Forms.Padding(3);
            this.tpCTHD.Size = new System.Drawing.Size(1203, 597);
            this.tpCTHD.TabIndex = 1;
            this.tpCTHD.Text = "Chi tiết hóa đơn";
            this.tpCTHD.UseVisualStyleBackColor = true;
            // 
            // dgvAddCTHD
            // 
            this.dgvAddCTHD.AllowUserToAddRows = false;
            this.dgvAddCTHD.AllowUserToDeleteRows = false;
            this.dgvAddCTHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddCTHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddCTHD.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAddCTHD.Location = new System.Drawing.Point(7, 162);
            this.dgvAddCTHD.Name = "dgvAddCTHD";
            this.dgvAddCTHD.ReadOnly = true;
            this.dgvAddCTHD.RowHeadersVisible = false;
            this.dgvAddCTHD.RowHeadersWidth = 51;
            this.dgvAddCTHD.RowTemplate.Height = 24;
            this.dgvAddCTHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddCTHD.Size = new System.Drawing.Size(1188, 426);
            this.dgvAddCTHD.TabIndex = 1;
            this.dgvAddCTHD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddCTHD_CellClick);
            // 
            // pnlAddCTHD
            // 
            this.pnlAddCTHD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAddCTHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddCTHD.Controls.Add(this.txtGiaThanhCTHD);
            this.pnlAddCTHD.Controls.Add(this.lbldvgtCTHD);
            this.pnlAddCTHD.Controls.Add(this.cboMaHDCTHD);
            this.pnlAddCTHD.Controls.Add(this.lblMaHDCTHD);
            this.pnlAddCTHD.Controls.Add(this.picSearchCTHD);
            this.pnlAddCTHD.Controls.Add(this.txtSearchCTHD);
            this.pnlAddCTHD.Controls.Add(this.picClearCTHD);
            this.pnlAddCTHD.Controls.Add(this.picUDCTHD);
            this.pnlAddCTHD.Controls.Add(this.picDelCTHD);
            this.pnlAddCTHD.Controls.Add(this.picAddCTHD);
            this.pnlAddCTHD.Controls.Add(this.lblGiaThanhCTHD);
            this.pnlAddCTHD.Controls.Add(this.nudSoLuongBan);
            this.pnlAddCTHD.Controls.Add(this.lblSoLuongBan);
            this.pnlAddCTHD.Controls.Add(this.cboMaSachCTHD);
            this.pnlAddCTHD.Controls.Add(this.lblMaSachCTHD);
            this.pnlAddCTHD.Location = new System.Drawing.Point(7, 7);
            this.pnlAddCTHD.Name = "pnlAddCTHD";
            this.pnlAddCTHD.Size = new System.Drawing.Size(1188, 149);
            this.pnlAddCTHD.TabIndex = 0;
            // 
            // txtGiaThanhCTHD
            // 
            this.txtGiaThanhCTHD.Enabled = false;
            this.txtGiaThanhCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaThanhCTHD.Location = new System.Drawing.Point(784, 50);
            this.txtGiaThanhCTHD.Name = "txtGiaThanhCTHD";
            this.txtGiaThanhCTHD.ReadOnly = true;
            this.txtGiaThanhCTHD.Size = new System.Drawing.Size(193, 27);
            this.txtGiaThanhCTHD.TabIndex = 48;
            this.txtGiaThanhCTHD.Text = "0";
            // 
            // lbldvgtCTHD
            // 
            this.lbldvgtCTHD.AutoSize = true;
            this.lbldvgtCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldvgtCTHD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbldvgtCTHD.Location = new System.Drawing.Point(983, 52);
            this.lbldvgtCTHD.Name = "lbldvgtCTHD";
            this.lbldvgtCTHD.Size = new System.Drawing.Size(47, 20);
            this.lbldvgtCTHD.TabIndex = 44;
            this.lbldvgtCTHD.Text = "VNĐ";
            // 
            // cboMaHDCTHD
            // 
            this.cboMaHDCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaHDCTHD.FormattingEnabled = true;
            this.cboMaHDCTHD.Location = new System.Drawing.Point(316, 11);
            this.cboMaHDCTHD.Name = "cboMaHDCTHD";
            this.cboMaHDCTHD.Size = new System.Drawing.Size(166, 28);
            this.cboMaHDCTHD.TabIndex = 43;
            this.cboMaHDCTHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaHDCTHD_KeyPress);
            // 
            // lblMaHDCTHD
            // 
            this.lblMaHDCTHD.AutoSize = true;
            this.lblMaHDCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHDCTHD.Location = new System.Drawing.Point(179, 14);
            this.lblMaHDCTHD.Name = "lblMaHDCTHD";
            this.lblMaHDCTHD.Size = new System.Drawing.Size(112, 20);
            this.lblMaHDCTHD.TabIndex = 42;
            this.lblMaHDCTHD.Text = "Mã hóa đơn:";
            // 
            // picSearchCTHD
            // 
            this.picSearchCTHD.Image = global::PMQL_BookStores.Properties.Resources.kinh_lup;
            this.picSearchCTHD.Location = new System.Drawing.Point(24, 100);
            this.picSearchCTHD.Name = "picSearchCTHD";
            this.picSearchCTHD.Size = new System.Drawing.Size(33, 30);
            this.picSearchCTHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearchCTHD.TabIndex = 41;
            this.picSearchCTHD.TabStop = false;
            this.picSearchCTHD.Click += new System.EventHandler(this.picSearchCTHD_Click);
            // 
            // txtSearchCTHD
            // 
            this.txtSearchCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCTHD.Location = new System.Drawing.Point(63, 100);
            this.txtSearchCTHD.Name = "txtSearchCTHD";
            this.txtSearchCTHD.Size = new System.Drawing.Size(363, 30);
            this.txtSearchCTHD.TabIndex = 40;
            this.txtSearchCTHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchCTHD_KeyPress);
            // 
            // picClearCTHD
            // 
            this.picClearCTHD.BackColor = System.Drawing.Color.Transparent;
            this.picClearCTHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picClearCTHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClearCTHD.Image = global::PMQL_BookStores.Properties.Resources.LamMoi;
            this.picClearCTHD.Location = new System.Drawing.Point(1040, 95);
            this.picClearCTHD.Name = "picClearCTHD";
            this.picClearCTHD.Size = new System.Drawing.Size(132, 41);
            this.picClearCTHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClearCTHD.TabIndex = 39;
            this.picClearCTHD.TabStop = false;
            this.picClearCTHD.Click += new System.EventHandler(this.picClearCTHD_Click);
            // 
            // picUDCTHD
            // 
            this.picUDCTHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUDCTHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUDCTHD.Image = global::PMQL_BookStores.Properties.Resources.Update;
            this.picUDCTHD.Location = new System.Drawing.Point(887, 95);
            this.picUDCTHD.Name = "picUDCTHD";
            this.picUDCTHD.Size = new System.Drawing.Size(132, 41);
            this.picUDCTHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUDCTHD.TabIndex = 38;
            this.picUDCTHD.TabStop = false;
            this.picUDCTHD.Click += new System.EventHandler(this.picUDCTHD_Click);
            // 
            // picDelCTHD
            // 
            this.picDelCTHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDelCTHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelCTHD.Image = global::PMQL_BookStores.Properties.Resources.Delete;
            this.picDelCTHD.Location = new System.Drawing.Point(729, 95);
            this.picDelCTHD.Name = "picDelCTHD";
            this.picDelCTHD.Size = new System.Drawing.Size(132, 41);
            this.picDelCTHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelCTHD.TabIndex = 37;
            this.picDelCTHD.TabStop = false;
            this.picDelCTHD.Click += new System.EventHandler(this.picDelCTHD_Click);
            // 
            // picAddCTHD
            // 
            this.picAddCTHD.BackColor = System.Drawing.Color.Transparent;
            this.picAddCTHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAddCTHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddCTHD.Image = global::PMQL_BookStores.Properties.Resources.Add;
            this.picAddCTHD.Location = new System.Drawing.Point(572, 95);
            this.picAddCTHD.Name = "picAddCTHD";
            this.picAddCTHD.Size = new System.Drawing.Size(132, 41);
            this.picAddCTHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddCTHD.TabIndex = 36;
            this.picAddCTHD.TabStop = false;
            this.picAddCTHD.Click += new System.EventHandler(this.picAddCTHD_Click);
            // 
            // lblGiaThanhCTHD
            // 
            this.lblGiaThanhCTHD.AutoSize = true;
            this.lblGiaThanhCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaThanhCTHD.Location = new System.Drawing.Point(647, 52);
            this.lblGiaThanhCTHD.Name = "lblGiaThanhCTHD";
            this.lblGiaThanhCTHD.Size = new System.Drawing.Size(96, 20);
            this.lblGiaThanhCTHD.TabIndex = 4;
            this.lblGiaThanhCTHD.Text = "Giá thành:";
            // 
            // nudSoLuongBan
            // 
            this.nudSoLuongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuongBan.Location = new System.Drawing.Point(316, 51);
            this.nudSoLuongBan.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudSoLuongBan.Name = "nudSoLuongBan";
            this.nudSoLuongBan.Size = new System.Drawing.Size(166, 27);
            this.nudSoLuongBan.TabIndex = 3;
            // 
            // lblSoLuongBan
            // 
            this.lblSoLuongBan.AutoSize = true;
            this.lblSoLuongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongBan.Location = new System.Drawing.Point(163, 52);
            this.lblSoLuongBan.Name = "lblSoLuongBan";
            this.lblSoLuongBan.Size = new System.Drawing.Size(124, 20);
            this.lblSoLuongBan.TabIndex = 2;
            this.lblSoLuongBan.Text = "Số lượng bán:";
            // 
            // cboMaSachCTHD
            // 
            this.cboMaSachCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaSachCTHD.FormattingEnabled = true;
            this.cboMaSachCTHD.Location = new System.Drawing.Point(784, 11);
            this.cboMaSachCTHD.Name = "cboMaSachCTHD";
            this.cboMaSachCTHD.Size = new System.Drawing.Size(246, 28);
            this.cboMaSachCTHD.TabIndex = 1;
            this.cboMaSachCTHD.SelectedIndexChanged += new System.EventHandler(this.cboMaSachCTHD_SelectedIndexChanged);
            this.cboMaSachCTHD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaSachCTHD_KeyPress);
            // 
            // lblMaSachCTHD
            // 
            this.lblMaSachCTHD.AutoSize = true;
            this.lblMaSachCTHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSachCTHD.Location = new System.Drawing.Point(651, 14);
            this.lblMaSachCTHD.Name = "lblMaSachCTHD";
            this.lblMaSachCTHD.Size = new System.Drawing.Size(92, 20);
            this.lblMaSachCTHD.TabIndex = 0;
            this.lblMaSachCTHD.Text = "Tên sách:";
            // 
            // pdocHoaDon
            // 
            this.pdocHoaDon.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocHoaDon_PrintPage);
            // 
            // ppdHoaDon
            // 
            this.ppdHoaDon.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdHoaDon.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdHoaDon.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdHoaDon.Document = this.pdocHoaDon;
            this.ppdHoaDon.Enabled = true;
            this.ppdHoaDon.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdHoaDon.Icon")));
            this.ppdHoaDon.Name = "ppdHoaDon";
            this.ppdHoaDon.Visible = false;
            // 
            // frm_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 636);
            this.Controls.Add(this.tcAddHoaDon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_HoaDon";
            this.Text = "BookStores - Hóa Đơn";
            this.Load += new System.EventHandler(this.frm_HoaDon_Load);
            this.Shown += new System.EventHandler(this.frm_HoaDon_Shown);
            this.tcAddHoaDon.ResumeLayout(false);
            this.tpHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddHD)).EndInit();
            this.pnlAddHD.ResumeLayout(false);
            this.pnlAddHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddHD)).EndInit();
            this.tpCTHD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddCTHD)).EndInit();
            this.pnlAddCTHD.ResumeLayout(false);
            this.pnlAddCTHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAddHoaDon;
        private System.Windows.Forms.TabPage tpHoaDon;
        private System.Windows.Forms.TabPage tpCTHD;
        private System.Windows.Forms.DataGridView dgvAddHD;
        private System.Windows.Forms.Panel pnlAddHD;
        private System.Windows.Forms.ComboBox cboMaNVHD;
        private System.Windows.Forms.Label lblMaNVHD;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.ComboBox cboMaKHHD;
        private System.Windows.Forms.Label lblMaKHHD;
        private System.Windows.Forms.PictureBox picClearHD;
        private System.Windows.Forms.PictureBox picUDHD;
        private System.Windows.Forms.PictureBox picDelHD;
        private System.Windows.Forms.PictureBox picAddHD;
        private System.Windows.Forms.PictureBox picSearchHD;
        private System.Windows.Forms.TextBox txtSearchHD;
        private System.Windows.Forms.Panel pnlAddCTHD;
        private System.Windows.Forms.DataGridView dgvAddCTHD;
        private System.Windows.Forms.ComboBox cboMaSachCTHD;
        private System.Windows.Forms.Label lblMaSachCTHD;
        private System.Windows.Forms.Label lblGiaThanhCTHD;
        private System.Windows.Forms.NumericUpDown nudSoLuongBan;
        private System.Windows.Forms.Label lblSoLuongBan;
        private System.Windows.Forms.PictureBox picClearCTHD;
        private System.Windows.Forms.PictureBox picUDCTHD;
        private System.Windows.Forms.PictureBox picDelCTHD;
        private System.Windows.Forms.PictureBox picAddCTHD;
        private System.Windows.Forms.PictureBox picSearchCTHD;
        private System.Windows.Forms.TextBox txtSearchCTHD;
        private System.Windows.Forms.ComboBox cboMaHDCTHD;
        private System.Windows.Forms.Label lblMaHDCTHD;
        private System.Windows.Forms.PictureBox picInHoaDon;
        private System.Windows.Forms.ToolTip tltInHoaDon;
        private System.Drawing.Printing.PrintDocument pdocHoaDon;
        private System.Windows.Forms.PrintPreviewDialog ppdHoaDon;
        private System.Windows.Forms.Label lbldvttHD;
        private System.Windows.Forms.TextBox txtTongTienHD;
        private System.Windows.Forms.Label lbldvgtCTHD;
        private System.Windows.Forms.TextBox txtTongSoLuongHD;
        private System.Windows.Forms.Label lblTongSoLuongHD;
        private System.Windows.Forms.TextBox txtGiaThanhCTHD;
    }
}