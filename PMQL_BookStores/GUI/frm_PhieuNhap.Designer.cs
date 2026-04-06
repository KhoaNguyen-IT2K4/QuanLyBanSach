namespace PMQL_BookStores.GUI
{
    partial class frm_PhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuNhap));
            this.tcAddPN = new System.Windows.Forms.TabControl();
            this.tpPhieuNhap = new System.Windows.Forms.TabPage();
            this.dgvAddPhieuNhap = new System.Windows.Forms.DataGridView();
            this.pnlAddPhieuNhap = new System.Windows.Forms.Panel();
            this.lbldvttPN = new System.Windows.Forms.Label();
            this.txtTongSoLuongPN = new System.Windows.Forms.TextBox();
            this.txtTongTienPN = new System.Windows.Forms.TextBox();
            this.lblTongSoLuongPN = new System.Windows.Forms.Label();
            this.picInPhieuNhap = new System.Windows.Forms.PictureBox();
            this.lblTongTienPN = new System.Windows.Forms.Label();
            this.cboMaNCC = new System.Windows.Forms.ComboBox();
            this.cboMaNVPN = new System.Windows.Forms.ComboBox();
            this.picSearchPN = new System.Windows.Forms.PictureBox();
            this.txtSearchPN = new System.Windows.Forms.TextBox();
            this.picClearPN = new System.Windows.Forms.PictureBox();
            this.picUDPN = new System.Windows.Forms.PictureBox();
            this.picDelPN = new System.Windows.Forms.PictureBox();
            this.picAddPN = new System.Windows.Forms.PictureBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.lblMaNVPN = new System.Windows.Forms.Label();
            this.tpCTPN = new System.Windows.Forms.TabPage();
            this.dgvAddCTPN = new System.Windows.Forms.DataGridView();
            this.pnlAddCTPN = new System.Windows.Forms.Panel();
            this.lbldvgtCTPN = new System.Windows.Forms.Label();
            this.nudGiaThanhCTPN = new System.Windows.Forms.NumericUpDown();
            this.lblGiaThanhCTPN = new System.Windows.Forms.Label();
            this.picSearchCTPN = new System.Windows.Forms.PictureBox();
            this.txtSearchCTPN = new System.Windows.Forms.TextBox();
            this.picClearCTPN = new System.Windows.Forms.PictureBox();
            this.picUDCTPN = new System.Windows.Forms.PictureBox();
            this.picDelCTPN = new System.Windows.Forms.PictureBox();
            this.picAddCTPN = new System.Windows.Forms.PictureBox();
            this.nudSoLuongNhap = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongNhap = new System.Windows.Forms.Label();
            this.cboMaSachCTPN = new System.Windows.Forms.ComboBox();
            this.lblMaSachCTPN = new System.Windows.Forms.Label();
            this.cboMaPNCTPN = new System.Windows.Forms.ComboBox();
            this.lblMaPNCTPN = new System.Windows.Forms.Label();
            this.tltInPhieuNhap = new System.Windows.Forms.ToolTip(this.components);
            this.pdocPhieuNhap = new System.Drawing.Printing.PrintDocument();
            this.ppdPhieuNhap = new System.Windows.Forms.PrintPreviewDialog();
            this.tcAddPN.SuspendLayout();
            this.tpPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddPhieuNhap)).BeginInit();
            this.pnlAddPhieuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddPN)).BeginInit();
            this.tpCTPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddCTPN)).BeginInit();
            this.pnlAddCTPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaThanhCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAddPN
            // 
            this.tcAddPN.Controls.Add(this.tpPhieuNhap);
            this.tcAddPN.Controls.Add(this.tpCTPN);
            this.tcAddPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddPN.Location = new System.Drawing.Point(2, 3);
            this.tcAddPN.Name = "tcAddPN";
            this.tcAddPN.SelectedIndex = 0;
            this.tcAddPN.Size = new System.Drawing.Size(1209, 631);
            this.tcAddPN.TabIndex = 0;
            this.tcAddPN.SelectedIndexChanged += new System.EventHandler(this.tcAddPN_SelectedIndexChanged);
            // 
            // tpPhieuNhap
            // 
            this.tpPhieuNhap.Controls.Add(this.dgvAddPhieuNhap);
            this.tpPhieuNhap.Controls.Add(this.pnlAddPhieuNhap);
            this.tpPhieuNhap.Location = new System.Drawing.Point(4, 34);
            this.tpPhieuNhap.Name = "tpPhieuNhap";
            this.tpPhieuNhap.Padding = new System.Windows.Forms.Padding(3);
            this.tpPhieuNhap.Size = new System.Drawing.Size(1201, 593);
            this.tpPhieuNhap.TabIndex = 0;
            this.tpPhieuNhap.Text = "Phiếu nhập";
            this.tpPhieuNhap.UseVisualStyleBackColor = true;
            // 
            // dgvAddPhieuNhap
            // 
            this.dgvAddPhieuNhap.AllowUserToAddRows = false;
            this.dgvAddPhieuNhap.AllowUserToDeleteRows = false;
            this.dgvAddPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddPhieuNhap.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAddPhieuNhap.Location = new System.Drawing.Point(6, 205);
            this.dgvAddPhieuNhap.Name = "dgvAddPhieuNhap";
            this.dgvAddPhieuNhap.ReadOnly = true;
            this.dgvAddPhieuNhap.RowHeadersVisible = false;
            this.dgvAddPhieuNhap.RowHeadersWidth = 51;
            this.dgvAddPhieuNhap.RowTemplate.Height = 24;
            this.dgvAddPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddPhieuNhap.Size = new System.Drawing.Size(1188, 382);
            this.dgvAddPhieuNhap.TabIndex = 1;
            this.dgvAddPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddPhieuNhap_CellClick);
            this.dgvAddPhieuNhap.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAddPhieuNhap_CellFormatting);
            // 
            // pnlAddPhieuNhap
            // 
            this.pnlAddPhieuNhap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAddPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddPhieuNhap.Controls.Add(this.lbldvttPN);
            this.pnlAddPhieuNhap.Controls.Add(this.txtTongSoLuongPN);
            this.pnlAddPhieuNhap.Controls.Add(this.txtTongTienPN);
            this.pnlAddPhieuNhap.Controls.Add(this.lblTongSoLuongPN);
            this.pnlAddPhieuNhap.Controls.Add(this.picInPhieuNhap);
            this.pnlAddPhieuNhap.Controls.Add(this.lblTongTienPN);
            this.pnlAddPhieuNhap.Controls.Add(this.cboMaNCC);
            this.pnlAddPhieuNhap.Controls.Add(this.cboMaNVPN);
            this.pnlAddPhieuNhap.Controls.Add(this.picSearchPN);
            this.pnlAddPhieuNhap.Controls.Add(this.txtSearchPN);
            this.pnlAddPhieuNhap.Controls.Add(this.picClearPN);
            this.pnlAddPhieuNhap.Controls.Add(this.picUDPN);
            this.pnlAddPhieuNhap.Controls.Add(this.picDelPN);
            this.pnlAddPhieuNhap.Controls.Add(this.picAddPN);
            this.pnlAddPhieuNhap.Controls.Add(this.dtpNgayNhap);
            this.pnlAddPhieuNhap.Controls.Add(this.lblNgayNhap);
            this.pnlAddPhieuNhap.Controls.Add(this.lblMaNCC);
            this.pnlAddPhieuNhap.Controls.Add(this.lblMaNVPN);
            this.pnlAddPhieuNhap.Location = new System.Drawing.Point(7, 7);
            this.pnlAddPhieuNhap.Name = "pnlAddPhieuNhap";
            this.pnlAddPhieuNhap.Size = new System.Drawing.Size(1187, 192);
            this.pnlAddPhieuNhap.TabIndex = 0;
            // 
            // lbldvttPN
            // 
            this.lbldvttPN.AutoSize = true;
            this.lbldvttPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldvttPN.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbldvttPN.Location = new System.Drawing.Point(1008, 61);
            this.lbldvttPN.Name = "lbldvttPN";
            this.lbldvttPN.Size = new System.Drawing.Size(47, 20);
            this.lbldvttPN.TabIndex = 48;
            this.lbldvttPN.Text = "VNĐ";
            // 
            // txtTongSoLuongPN
            // 
            this.txtTongSoLuongPN.Enabled = false;
            this.txtTongSoLuongPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoLuongPN.Location = new System.Drawing.Point(791, 14);
            this.txtTongSoLuongPN.Name = "txtTongSoLuongPN";
            this.txtTongSoLuongPN.ReadOnly = true;
            this.txtTongSoLuongPN.Size = new System.Drawing.Size(211, 27);
            this.txtTongSoLuongPN.TabIndex = 47;
            this.txtTongSoLuongPN.Text = "0";
            // 
            // txtTongTienPN
            // 
            this.txtTongTienPN.Enabled = false;
            this.txtTongTienPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienPN.Location = new System.Drawing.Point(791, 57);
            this.txtTongTienPN.Name = "txtTongTienPN";
            this.txtTongTienPN.ReadOnly = true;
            this.txtTongTienPN.Size = new System.Drawing.Size(211, 27);
            this.txtTongTienPN.TabIndex = 47;
            this.txtTongTienPN.Text = "0";
            // 
            // lblTongSoLuongPN
            // 
            this.lblTongSoLuongPN.AutoSize = true;
            this.lblTongSoLuongPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSoLuongPN.Location = new System.Drawing.Point(621, 16);
            this.lblTongSoLuongPN.Name = "lblTongSoLuongPN";
            this.lblTongSoLuongPN.Size = new System.Drawing.Size(133, 20);
            this.lblTongSoLuongPN.TabIndex = 44;
            this.lblTongSoLuongPN.Text = "Tổng số lượng:";
            // 
            // picInPhieuNhap
            // 
            this.picInPhieuNhap.Image = global::PMQL_BookStores.Properties.Resources.printLightGrey;
            this.picInPhieuNhap.Location = new System.Drawing.Point(1098, 9);
            this.picInPhieuNhap.Name = "picInPhieuNhap";
            this.picInPhieuNhap.Size = new System.Drawing.Size(75, 70);
            this.picInPhieuNhap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInPhieuNhap.TabIndex = 46;
            this.picInPhieuNhap.TabStop = false;
            this.tltInPhieuNhap.SetToolTip(this.picInPhieuNhap, "In Phiếu Nhập");
            this.picInPhieuNhap.Click += new System.EventHandler(this.picInPhieuNhap_Click);
            // 
            // lblTongTienPN
            // 
            this.lblTongTienPN.AutoSize = true;
            this.lblTongTienPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienPN.Location = new System.Drawing.Point(661, 62);
            this.lblTongTienPN.Name = "lblTongTienPN";
            this.lblTongTienPN.Size = new System.Drawing.Size(93, 20);
            this.lblTongTienPN.TabIndex = 44;
            this.lblTongTienPN.Text = "Tổng tiền:";
            // 
            // cboMaNCC
            // 
            this.cboMaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNCC.FormattingEnabled = true;
            this.cboMaNCC.Location = new System.Drawing.Point(315, 57);
            this.cboMaNCC.Name = "cboMaNCC";
            this.cboMaNCC.Size = new System.Drawing.Size(229, 28);
            this.cboMaNCC.TabIndex = 43;
            this.cboMaNCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaNCC_KeyPress);
            // 
            // cboMaNVPN
            // 
            this.cboMaNVPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNVPN.FormattingEnabled = true;
            this.cboMaNVPN.Location = new System.Drawing.Point(315, 11);
            this.cboMaNVPN.Name = "cboMaNVPN";
            this.cboMaNVPN.Size = new System.Drawing.Size(229, 28);
            this.cboMaNVPN.TabIndex = 42;
            this.cboMaNVPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaNVPN_KeyPress);
            // 
            // picSearchPN
            // 
            this.picSearchPN.Image = global::PMQL_BookStores.Properties.Resources.kinh_lup;
            this.picSearchPN.Location = new System.Drawing.Point(66, 146);
            this.picSearchPN.Name = "picSearchPN";
            this.picSearchPN.Size = new System.Drawing.Size(31, 30);
            this.picSearchPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearchPN.TabIndex = 41;
            this.picSearchPN.TabStop = false;
            this.picSearchPN.Click += new System.EventHandler(this.picSearchPN_Click);
            // 
            // txtSearchPN
            // 
            this.txtSearchPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchPN.Location = new System.Drawing.Point(103, 146);
            this.txtSearchPN.Name = "txtSearchPN";
            this.txtSearchPN.Size = new System.Drawing.Size(363, 30);
            this.txtSearchPN.TabIndex = 40;
            this.txtSearchPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPN_KeyPress);
            // 
            // picClearPN
            // 
            this.picClearPN.BackColor = System.Drawing.Color.Transparent;
            this.picClearPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picClearPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClearPN.Image = global::PMQL_BookStores.Properties.Resources.LamMoi;
            this.picClearPN.Location = new System.Drawing.Point(1017, 141);
            this.picClearPN.Name = "picClearPN";
            this.picClearPN.Size = new System.Drawing.Size(156, 41);
            this.picClearPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClearPN.TabIndex = 39;
            this.picClearPN.TabStop = false;
            this.picClearPN.Click += new System.EventHandler(this.picClearPN_Click);
            // 
            // picUDPN
            // 
            this.picUDPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUDPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUDPN.Image = global::PMQL_BookStores.Properties.Resources.Update;
            this.picUDPN.Location = new System.Drawing.Point(836, 141);
            this.picUDPN.Name = "picUDPN";
            this.picUDPN.Size = new System.Drawing.Size(156, 41);
            this.picUDPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUDPN.TabIndex = 38;
            this.picUDPN.TabStop = false;
            this.picUDPN.Click += new System.EventHandler(this.picUDPN_Click);
            // 
            // picDelPN
            // 
            this.picDelPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDelPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelPN.Image = global::PMQL_BookStores.Properties.Resources.Delete;
            this.picDelPN.Location = new System.Drawing.Point(659, 141);
            this.picDelPN.Name = "picDelPN";
            this.picDelPN.Size = new System.Drawing.Size(156, 41);
            this.picDelPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelPN.TabIndex = 37;
            this.picDelPN.TabStop = false;
            this.picDelPN.Click += new System.EventHandler(this.picDelPN_Click);
            // 
            // picAddPN
            // 
            this.picAddPN.BackColor = System.Drawing.Color.Transparent;
            this.picAddPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAddPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddPN.Image = global::PMQL_BookStores.Properties.Resources.Add;
            this.picAddPN.Location = new System.Drawing.Point(486, 141);
            this.picAddPN.Name = "picAddPN";
            this.picAddPN.Size = new System.Drawing.Size(156, 41);
            this.picAddPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddPN.TabIndex = 36;
            this.picAddPN.TabStop = false;
            this.picAddPN.Click += new System.EventHandler(this.picAddPN_Click);
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy - HH:mm:ss";
            this.dtpNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(315, 100);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(262, 27);
            this.dtpNgayNhap.TabIndex = 5;
            this.dtpNgayNhap.Value = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayNhap.Location = new System.Drawing.Point(154, 105);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(103, 20);
            this.lblNgayNhap.TabIndex = 4;
            this.lblNgayNhap.Text = "Ngày nhập:";
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNCC.Location = new System.Drawing.Point(93, 59);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(164, 20);
            this.lblMaNCC.TabIndex = 2;
            this.lblMaNCC.Text = "Tên nhà cung cấp:";
            // 
            // lblMaNVPN
            // 
            this.lblMaNVPN.AutoSize = true;
            this.lblMaNVPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNVPN.Location = new System.Drawing.Point(100, 16);
            this.lblMaNVPN.Name = "lblMaNVPN";
            this.lblMaNVPN.Size = new System.Drawing.Size(157, 20);
            this.lblMaNVPN.TabIndex = 0;
            this.lblMaNVPN.Text = "Họ tên nhân viên:";
            // 
            // tpCTPN
            // 
            this.tpCTPN.Controls.Add(this.dgvAddCTPN);
            this.tpCTPN.Controls.Add(this.pnlAddCTPN);
            this.tpCTPN.Location = new System.Drawing.Point(4, 34);
            this.tpCTPN.Name = "tpCTPN";
            this.tpCTPN.Padding = new System.Windows.Forms.Padding(3);
            this.tpCTPN.Size = new System.Drawing.Size(1201, 593);
            this.tpCTPN.TabIndex = 1;
            this.tpCTPN.Text = "Chi tiết phiếu nhập";
            this.tpCTPN.UseVisualStyleBackColor = true;
            // 
            // dgvAddCTPN
            // 
            this.dgvAddCTPN.AllowUserToAddRows = false;
            this.dgvAddCTPN.AllowUserToDeleteRows = false;
            this.dgvAddCTPN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddCTPN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddCTPN.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAddCTPN.Location = new System.Drawing.Point(7, 168);
            this.dgvAddCTPN.Name = "dgvAddCTPN";
            this.dgvAddCTPN.ReadOnly = true;
            this.dgvAddCTPN.RowHeadersVisible = false;
            this.dgvAddCTPN.RowHeadersWidth = 51;
            this.dgvAddCTPN.RowTemplate.Height = 24;
            this.dgvAddCTPN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddCTPN.Size = new System.Drawing.Size(1187, 419);
            this.dgvAddCTPN.TabIndex = 1;
            this.dgvAddCTPN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddCTPN_CellClick);
            // 
            // pnlAddCTPN
            // 
            this.pnlAddCTPN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAddCTPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddCTPN.Controls.Add(this.lbldvgtCTPN);
            this.pnlAddCTPN.Controls.Add(this.nudGiaThanhCTPN);
            this.pnlAddCTPN.Controls.Add(this.lblGiaThanhCTPN);
            this.pnlAddCTPN.Controls.Add(this.picSearchCTPN);
            this.pnlAddCTPN.Controls.Add(this.txtSearchCTPN);
            this.pnlAddCTPN.Controls.Add(this.picClearCTPN);
            this.pnlAddCTPN.Controls.Add(this.picUDCTPN);
            this.pnlAddCTPN.Controls.Add(this.picDelCTPN);
            this.pnlAddCTPN.Controls.Add(this.picAddCTPN);
            this.pnlAddCTPN.Controls.Add(this.nudSoLuongNhap);
            this.pnlAddCTPN.Controls.Add(this.lblSoLuongNhap);
            this.pnlAddCTPN.Controls.Add(this.cboMaSachCTPN);
            this.pnlAddCTPN.Controls.Add(this.lblMaSachCTPN);
            this.pnlAddCTPN.Controls.Add(this.cboMaPNCTPN);
            this.pnlAddCTPN.Controls.Add(this.lblMaPNCTPN);
            this.pnlAddCTPN.Location = new System.Drawing.Point(7, 7);
            this.pnlAddCTPN.Name = "pnlAddCTPN";
            this.pnlAddCTPN.Size = new System.Drawing.Size(1187, 155);
            this.pnlAddCTPN.TabIndex = 0;
            // 
            // lbldvgtCTPN
            // 
            this.lbldvgtCTPN.AutoSize = true;
            this.lbldvgtCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldvgtCTPN.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbldvgtCTPN.Location = new System.Drawing.Point(996, 63);
            this.lbldvgtCTPN.Name = "lbldvgtCTPN";
            this.lbldvgtCTPN.Size = new System.Drawing.Size(47, 20);
            this.lbldvgtCTPN.TabIndex = 49;
            this.lbldvgtCTPN.Text = "VNĐ";
            // 
            // nudGiaThanhCTPN
            // 
            this.nudGiaThanhCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGiaThanhCTPN.Location = new System.Drawing.Point(815, 61);
            this.nudGiaThanhCTPN.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudGiaThanhCTPN.Name = "nudGiaThanhCTPN";
            this.nudGiaThanhCTPN.Size = new System.Drawing.Size(175, 27);
            this.nudGiaThanhCTPN.TabIndex = 47;
            // 
            // lblGiaThanhCTPN
            // 
            this.lblGiaThanhCTPN.AutoSize = true;
            this.lblGiaThanhCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaThanhCTPN.Location = new System.Drawing.Point(672, 63);
            this.lblGiaThanhCTPN.Name = "lblGiaThanhCTPN";
            this.lblGiaThanhCTPN.Size = new System.Drawing.Size(96, 20);
            this.lblGiaThanhCTPN.TabIndex = 46;
            this.lblGiaThanhCTPN.Text = "Giá thành:";
            // 
            // picSearchCTPN
            // 
            this.picSearchCTPN.Image = global::PMQL_BookStores.Properties.Resources.kinh_lup;
            this.picSearchCTPN.Location = new System.Drawing.Point(23, 110);
            this.picSearchCTPN.Name = "picSearchCTPN";
            this.picSearchCTPN.Size = new System.Drawing.Size(41, 30);
            this.picSearchCTPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearchCTPN.TabIndex = 41;
            this.picSearchCTPN.TabStop = false;
            this.picSearchCTPN.Click += new System.EventHandler(this.picSearchCTPN_Click);
            // 
            // txtSearchCTPN
            // 
            this.txtSearchCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCTPN.Location = new System.Drawing.Point(70, 110);
            this.txtSearchCTPN.Name = "txtSearchCTPN";
            this.txtSearchCTPN.Size = new System.Drawing.Size(363, 30);
            this.txtSearchCTPN.TabIndex = 40;
            this.txtSearchCTPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchCTPN_KeyPress);
            // 
            // picClearCTPN
            // 
            this.picClearCTPN.BackColor = System.Drawing.Color.Transparent;
            this.picClearCTPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picClearCTPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClearCTPN.Image = global::PMQL_BookStores.Properties.Resources.LamMoi;
            this.picClearCTPN.Location = new System.Drawing.Point(1025, 99);
            this.picClearCTPN.Name = "picClearCTPN";
            this.picClearCTPN.Size = new System.Drawing.Size(148, 41);
            this.picClearCTPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClearCTPN.TabIndex = 39;
            this.picClearCTPN.TabStop = false;
            this.picClearCTPN.Click += new System.EventHandler(this.picClearCTPN_Click);
            // 
            // picUDCTPN
            // 
            this.picUDCTPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUDCTPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUDCTPN.Image = global::PMQL_BookStores.Properties.Resources.Update;
            this.picUDCTPN.Location = new System.Drawing.Point(853, 99);
            this.picUDCTPN.Name = "picUDCTPN";
            this.picUDCTPN.Size = new System.Drawing.Size(148, 41);
            this.picUDCTPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUDCTPN.TabIndex = 38;
            this.picUDCTPN.TabStop = false;
            this.picUDCTPN.Click += new System.EventHandler(this.picUDCTPN_Click);
            // 
            // picDelCTPN
            // 
            this.picDelCTPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDelCTPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelCTPN.Image = global::PMQL_BookStores.Properties.Resources.Delete;
            this.picDelCTPN.Location = new System.Drawing.Point(680, 99);
            this.picDelCTPN.Name = "picDelCTPN";
            this.picDelCTPN.Size = new System.Drawing.Size(148, 41);
            this.picDelCTPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelCTPN.TabIndex = 37;
            this.picDelCTPN.TabStop = false;
            this.picDelCTPN.Click += new System.EventHandler(this.picDelCTPN_Click);
            // 
            // picAddCTPN
            // 
            this.picAddCTPN.BackColor = System.Drawing.Color.Transparent;
            this.picAddCTPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAddCTPN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddCTPN.Image = global::PMQL_BookStores.Properties.Resources.Add;
            this.picAddCTPN.Location = new System.Drawing.Point(510, 99);
            this.picAddCTPN.Name = "picAddCTPN";
            this.picAddCTPN.Size = new System.Drawing.Size(148, 41);
            this.picAddCTPN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddCTPN.TabIndex = 36;
            this.picAddCTPN.TabStop = false;
            this.picAddCTPN.Click += new System.EventHandler(this.picAddCTPN_Click);
            // 
            // nudSoLuongNhap
            // 
            this.nudSoLuongNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuongNhap.Location = new System.Drawing.Point(349, 61);
            this.nudSoLuongNhap.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudSoLuongNhap.Name = "nudSoLuongNhap";
            this.nudSoLuongNhap.Size = new System.Drawing.Size(149, 27);
            this.nudSoLuongNhap.TabIndex = 5;
            // 
            // lblSoLuongNhap
            // 
            this.lblSoLuongNhap.AutoSize = true;
            this.lblSoLuongNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuongNhap.Location = new System.Drawing.Point(173, 63);
            this.lblSoLuongNhap.Name = "lblSoLuongNhap";
            this.lblSoLuongNhap.Size = new System.Drawing.Size(134, 20);
            this.lblSoLuongNhap.TabIndex = 4;
            this.lblSoLuongNhap.Text = "Số lượng nhập:";
            // 
            // cboMaSachCTPN
            // 
            this.cboMaSachCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaSachCTPN.FormattingEnabled = true;
            this.cboMaSachCTPN.Location = new System.Drawing.Point(815, 13);
            this.cboMaSachCTPN.Name = "cboMaSachCTPN";
            this.cboMaSachCTPN.Size = new System.Drawing.Size(228, 28);
            this.cboMaSachCTPN.TabIndex = 3;
            this.cboMaSachCTPN.SelectedIndexChanged += new System.EventHandler(this.cboMaSachCTPN_SelectedIndexChanged);
            this.cboMaSachCTPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaPNCTPN_KeyPress);
            // 
            // lblMaSachCTPN
            // 
            this.lblMaSachCTPN.AutoSize = true;
            this.lblMaSachCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaSachCTPN.Location = new System.Drawing.Point(676, 16);
            this.lblMaSachCTPN.Name = "lblMaSachCTPN";
            this.lblMaSachCTPN.Size = new System.Drawing.Size(92, 20);
            this.lblMaSachCTPN.TabIndex = 2;
            this.lblMaSachCTPN.Text = "Tên sách:";
            // 
            // cboMaPNCTPN
            // 
            this.cboMaPNCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaPNCTPN.FormattingEnabled = true;
            this.cboMaPNCTPN.Location = new System.Drawing.Point(349, 13);
            this.cboMaPNCTPN.Name = "cboMaPNCTPN";
            this.cboMaPNCTPN.Size = new System.Drawing.Size(149, 28);
            this.cboMaPNCTPN.TabIndex = 1;
            this.cboMaPNCTPN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaPNCTPN_KeyPress);
            // 
            // lblMaPNCTPN
            // 
            this.lblMaPNCTPN.AutoSize = true;
            this.lblMaPNCTPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPNCTPN.Location = new System.Drawing.Point(170, 16);
            this.lblMaPNCTPN.Name = "lblMaPNCTPN";
            this.lblMaPNCTPN.Size = new System.Drawing.Size(137, 20);
            this.lblMaPNCTPN.TabIndex = 0;
            this.lblMaPNCTPN.Text = "Mã phiếu nhập:";
            // 
            // pdocPhieuNhap
            // 
            this.pdocPhieuNhap.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdocPhieuNhap_PrintPage);
            // 
            // ppdPhieuNhap
            // 
            this.ppdPhieuNhap.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdPhieuNhap.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdPhieuNhap.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdPhieuNhap.Document = this.pdocPhieuNhap;
            this.ppdPhieuNhap.Enabled = true;
            this.ppdPhieuNhap.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdPhieuNhap.Icon")));
            this.ppdPhieuNhap.Name = "ppdPhieuNhap";
            this.ppdPhieuNhap.Visible = false;
            // 
            // frm_PhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 636);
            this.Controls.Add(this.tcAddPN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_PhieuNhap";
            this.Text = "BookStores - Phiếu Nhập";
            this.Load += new System.EventHandler(this.frm_PhieuNhap_Load);
            this.Shown += new System.EventHandler(this.frm_PhieuNhap_Shown);
            this.tcAddPN.ResumeLayout(false);
            this.tpPhieuNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddPhieuNhap)).EndInit();
            this.pnlAddPhieuNhap.ResumeLayout(false);
            this.pnlAddPhieuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddPN)).EndInit();
            this.tpCTPN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddCTPN)).EndInit();
            this.pnlAddCTPN.ResumeLayout(false);
            this.pnlAddCTPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaThanhCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAddPN;
        private System.Windows.Forms.TabPage tpPhieuNhap;
        private System.Windows.Forms.TabPage tpCTPN;
        private System.Windows.Forms.DataGridView dgvAddPhieuNhap;
        private System.Windows.Forms.Panel pnlAddPhieuNhap;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.Label lblMaNVPN;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.PictureBox picClearPN;
        private System.Windows.Forms.PictureBox picUDPN;
        private System.Windows.Forms.PictureBox picDelPN;
        private System.Windows.Forms.PictureBox picAddPN;
        private System.Windows.Forms.PictureBox picSearchPN;
        private System.Windows.Forms.TextBox txtSearchPN;
        private System.Windows.Forms.DataGridView dgvAddCTPN;
        private System.Windows.Forms.Panel pnlAddCTPN;
        private System.Windows.Forms.ComboBox cboMaPNCTPN;
        private System.Windows.Forms.Label lblMaPNCTPN;
        private System.Windows.Forms.NumericUpDown nudSoLuongNhap;
        private System.Windows.Forms.Label lblSoLuongNhap;
        private System.Windows.Forms.ComboBox cboMaSachCTPN;
        private System.Windows.Forms.Label lblMaSachCTPN;
        private System.Windows.Forms.PictureBox picClearCTPN;
        private System.Windows.Forms.PictureBox picUDCTPN;
        private System.Windows.Forms.PictureBox picDelCTPN;
        private System.Windows.Forms.PictureBox picAddCTPN;
        private System.Windows.Forms.PictureBox picSearchCTPN;
        private System.Windows.Forms.TextBox txtSearchCTPN;
        private System.Windows.Forms.ComboBox cboMaNVPN;
        private System.Windows.Forms.ComboBox cboMaNCC;
        private System.Windows.Forms.Label lblTongTienPN;
        private System.Windows.Forms.Label lblGiaThanhCTPN;
        private System.Windows.Forms.NumericUpDown nudGiaThanhCTPN;
        private System.Windows.Forms.PictureBox picInPhieuNhap;
        private System.Windows.Forms.ToolTip tltInPhieuNhap;
        private System.Windows.Forms.Label lbldvttPN;
        private System.Windows.Forms.TextBox txtTongTienPN;
        private System.Windows.Forms.Label lbldvgtCTPN;
        private System.Windows.Forms.TextBox txtTongSoLuongPN;
        private System.Windows.Forms.Label lblTongSoLuongPN;
        private System.Drawing.Printing.PrintDocument pdocPhieuNhap;
        private System.Windows.Forms.PrintPreviewDialog ppdPhieuNhap;
    }
}