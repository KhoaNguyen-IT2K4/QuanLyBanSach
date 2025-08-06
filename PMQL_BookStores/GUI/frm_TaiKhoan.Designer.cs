namespace PMQL_BookStores.GUI
{
    partial class frm_TaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaiKhoan));
            this.dgvAddTaiKhoan = new System.Windows.Forms.DataGridView();
            this.pnlAddTaiKhoan = new System.Windows.Forms.Panel();
            this.chk_PassTK = new System.Windows.Forms.CheckBox();
            this.picSearchTaiKhoan = new System.Windows.Forms.PictureBox();
            this.txtSearchTaiKhoan = new System.Windows.Forms.TextBox();
            this.picClearTaiKhoan = new System.Windows.Forms.PictureBox();
            this.picUDTaiKhoan = new System.Windows.Forms.PictureBox();
            this.picDelTaiKhoan = new System.Windows.Forms.PictureBox();
            this.picAddTaiKhoan = new System.Windows.Forms.PictureBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtEmailTK = new System.Windows.Forms.TextBox();
            this.lblEmailTK = new System.Windows.Forms.Label();
            this.txtRePassTK = new System.Windows.Forms.TextBox();
            this.lblRePassTK = new System.Windows.Forms.Label();
            this.txtPassTK = new System.Windows.Forms.TextBox();
            this.lblPassTK = new System.Windows.Forms.Label();
            this.txtUnameTK = new System.Windows.Forms.TextBox();
            this.lblUnameTK = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddTaiKhoan)).BeginInit();
            this.pnlAddTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAddTaiKhoan
            // 
            this.dgvAddTaiKhoan.AllowUserToAddRows = false;
            this.dgvAddTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvAddTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAddTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAddTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAddTaiKhoan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAddTaiKhoan.Location = new System.Drawing.Point(6, 185);
            this.dgvAddTaiKhoan.Name = "dgvAddTaiKhoan";
            this.dgvAddTaiKhoan.ReadOnly = true;
            this.dgvAddTaiKhoan.RowHeadersVisible = false;
            this.dgvAddTaiKhoan.RowHeadersWidth = 51;
            this.dgvAddTaiKhoan.RowTemplate.Height = 24;
            this.dgvAddTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddTaiKhoan.Size = new System.Drawing.Size(1200, 447);
            this.dgvAddTaiKhoan.TabIndex = 3;
            this.dgvAddTaiKhoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddTaiKhoan_CellClick);
            this.dgvAddTaiKhoan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAddTaiKhoan_CellFormatting);
            // 
            // pnlAddTaiKhoan
            // 
            this.pnlAddTaiKhoan.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlAddTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddTaiKhoan.Controls.Add(this.chk_PassTK);
            this.pnlAddTaiKhoan.Controls.Add(this.picSearchTaiKhoan);
            this.pnlAddTaiKhoan.Controls.Add(this.txtSearchTaiKhoan);
            this.pnlAddTaiKhoan.Controls.Add(this.picClearTaiKhoan);
            this.pnlAddTaiKhoan.Controls.Add(this.picUDTaiKhoan);
            this.pnlAddTaiKhoan.Controls.Add(this.picDelTaiKhoan);
            this.pnlAddTaiKhoan.Controls.Add(this.picAddTaiKhoan);
            this.pnlAddTaiKhoan.Controls.Add(this.cboTrangThai);
            this.pnlAddTaiKhoan.Controls.Add(this.lblTrangThai);
            this.pnlAddTaiKhoan.Controls.Add(this.cboMaNV);
            this.pnlAddTaiKhoan.Controls.Add(this.lblMaNV);
            this.pnlAddTaiKhoan.Controls.Add(this.txtEmailTK);
            this.pnlAddTaiKhoan.Controls.Add(this.lblEmailTK);
            this.pnlAddTaiKhoan.Controls.Add(this.txtRePassTK);
            this.pnlAddTaiKhoan.Controls.Add(this.lblRePassTK);
            this.pnlAddTaiKhoan.Controls.Add(this.txtPassTK);
            this.pnlAddTaiKhoan.Controls.Add(this.lblPassTK);
            this.pnlAddTaiKhoan.Controls.Add(this.txtUnameTK);
            this.pnlAddTaiKhoan.Controls.Add(this.lblUnameTK);
            this.pnlAddTaiKhoan.Location = new System.Drawing.Point(6, 2);
            this.pnlAddTaiKhoan.Name = "pnlAddTaiKhoan";
            this.pnlAddTaiKhoan.Size = new System.Drawing.Size(1200, 177);
            this.pnlAddTaiKhoan.TabIndex = 2;
            // 
            // chk_PassTK
            // 
            this.chk_PassTK.AutoSize = true;
            this.chk_PassTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_PassTK.ForeColor = System.Drawing.Color.Red;
            this.chk_PassTK.Location = new System.Drawing.Point(499, 66);
            this.chk_PassTK.Name = "chk_PassTK";
            this.chk_PassTK.Size = new System.Drawing.Size(76, 24);
            this.chk_PassTK.TabIndex = 42;
            this.chk_PassTK.Text = "Show";
            this.chk_PassTK.UseVisualStyleBackColor = true;
            this.chk_PassTK.CheckedChanged += new System.EventHandler(this.chk_PassTK_CheckedChanged);
            // 
            // picSearchTaiKhoan
            // 
            this.picSearchTaiKhoan.Image = global::PMQL_BookStores.Properties.Resources.kinh_lup;
            this.picSearchTaiKhoan.Location = new System.Drawing.Point(31, 128);
            this.picSearchTaiKhoan.Name = "picSearchTaiKhoan";
            this.picSearchTaiKhoan.Size = new System.Drawing.Size(41, 30);
            this.picSearchTaiKhoan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearchTaiKhoan.TabIndex = 41;
            this.picSearchTaiKhoan.TabStop = false;
            this.picSearchTaiKhoan.Click += new System.EventHandler(this.picSearchTaiKhoan_Click);
            // 
            // txtSearchTaiKhoan
            // 
            this.txtSearchTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTaiKhoan.Location = new System.Drawing.Point(78, 128);
            this.txtSearchTaiKhoan.Name = "txtSearchTaiKhoan";
            this.txtSearchTaiKhoan.Size = new System.Drawing.Size(363, 30);
            this.txtSearchTaiKhoan.TabIndex = 40;
            this.txtSearchTaiKhoan.TextChanged += new System.EventHandler(this.txtSearchTaiKhoan_TextChanged);
            this.txtSearchTaiKhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchTaiKhoan_KeyPress);
            // 
            // picClearTaiKhoan
            // 
            this.picClearTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.picClearTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picClearTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClearTaiKhoan.Image = global::PMQL_BookStores.Properties.Resources.LamMoi;
            this.picClearTaiKhoan.Location = new System.Drawing.Point(1026, 123);
            this.picClearTaiKhoan.Name = "picClearTaiKhoan";
            this.picClearTaiKhoan.Size = new System.Drawing.Size(158, 41);
            this.picClearTaiKhoan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClearTaiKhoan.TabIndex = 39;
            this.picClearTaiKhoan.TabStop = false;
            this.picClearTaiKhoan.Click += new System.EventHandler(this.picClearTaiKhoan_Click);
            // 
            // picUDTaiKhoan
            // 
            this.picUDTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUDTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUDTaiKhoan.Image = global::PMQL_BookStores.Properties.Resources.Update;
            this.picUDTaiKhoan.Location = new System.Drawing.Point(844, 123);
            this.picUDTaiKhoan.Name = "picUDTaiKhoan";
            this.picUDTaiKhoan.Size = new System.Drawing.Size(158, 41);
            this.picUDTaiKhoan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUDTaiKhoan.TabIndex = 38;
            this.picUDTaiKhoan.TabStop = false;
            this.picUDTaiKhoan.Click += new System.EventHandler(this.picUDTaiKhoan_Click);
            // 
            // picDelTaiKhoan
            // 
            this.picDelTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDelTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelTaiKhoan.Image = global::PMQL_BookStores.Properties.Resources.Delete;
            this.picDelTaiKhoan.Location = new System.Drawing.Point(667, 123);
            this.picDelTaiKhoan.Name = "picDelTaiKhoan";
            this.picDelTaiKhoan.Size = new System.Drawing.Size(158, 41);
            this.picDelTaiKhoan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelTaiKhoan.TabIndex = 37;
            this.picDelTaiKhoan.TabStop = false;
            this.picDelTaiKhoan.Click += new System.EventHandler(this.picDelTaiKhoan_Click);
            // 
            // picAddTaiKhoan
            // 
            this.picAddTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.picAddTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAddTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAddTaiKhoan.Image = global::PMQL_BookStores.Properties.Resources.Add;
            this.picAddTaiKhoan.Location = new System.Drawing.Point(485, 123);
            this.picAddTaiKhoan.Name = "picAddTaiKhoan";
            this.picAddTaiKhoan.Size = new System.Drawing.Size(158, 41);
            this.picAddTaiKhoan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAddTaiKhoan.TabIndex = 36;
            this.picAddTaiKhoan.TabStop = false;
            this.picAddTaiKhoan.Click += new System.EventHandler(this.picAddTaiKhoan_Click);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Online",
            "Offline"});
            this.cboTrangThai.Location = new System.Drawing.Point(834, 87);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(181, 28);
            this.cboTrangThai.TabIndex = 9;
            this.cboTrangThai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTrangThai_KeyPress);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(705, 90);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 20);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboMaNV
            // 
            this.cboMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(834, 48);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(261, 28);
            this.cboMaNV.TabIndex = 9;
            this.cboMaNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMaNV_KeyPress);
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Location = new System.Drawing.Point(648, 51);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(157, 20);
            this.lblMaNV.TabIndex = 8;
            this.lblMaNV.Text = "Họ tên nhân viên:";
            // 
            // txtEmailTK
            // 
            this.txtEmailTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailTK.Location = new System.Drawing.Point(831, 10);
            this.txtEmailTK.Name = "txtEmailTK";
            this.txtEmailTK.Size = new System.Drawing.Size(264, 27);
            this.txtEmailTK.TabIndex = 7;
            // 
            // lblEmailTK
            // 
            this.lblEmailTK.AutoSize = true;
            this.lblEmailTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailTK.Location = new System.Drawing.Point(743, 13);
            this.lblEmailTK.Name = "lblEmailTK";
            this.lblEmailTK.Size = new System.Drawing.Size(62, 20);
            this.lblEmailTK.TabIndex = 6;
            this.lblEmailTK.Text = "Email:";
            // 
            // txtRePassTK
            // 
            this.txtRePassTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRePassTK.Location = new System.Drawing.Point(225, 84);
            this.txtRePassTK.Name = "txtRePassTK";
            this.txtRePassTK.Size = new System.Drawing.Size(245, 27);
            this.txtRePassTK.TabIndex = 5;
            this.txtRePassTK.UseSystemPasswordChar = true;
            // 
            // lblRePassTK
            // 
            this.lblRePassTK.AutoSize = true;
            this.lblRePassTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRePassTK.Location = new System.Drawing.Point(18, 87);
            this.lblRePassTK.Name = "lblRePassTK";
            this.lblRePassTK.Size = new System.Drawing.Size(175, 20);
            this.lblRePassTK.TabIndex = 4;
            this.lblRePassTK.Text = "Xác nhận mật khẩu:";
            // 
            // txtPassTK
            // 
            this.txtPassTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassTK.Location = new System.Drawing.Point(225, 45);
            this.txtPassTK.Name = "txtPassTK";
            this.txtPassTK.Size = new System.Drawing.Size(245, 27);
            this.txtPassTK.TabIndex = 3;
            this.txtPassTK.UseSystemPasswordChar = true;
            // 
            // lblPassTK
            // 
            this.lblPassTK.AutoSize = true;
            this.lblPassTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassTK.Location = new System.Drawing.Point(102, 48);
            this.lblPassTK.Name = "lblPassTK";
            this.lblPassTK.Size = new System.Drawing.Size(91, 20);
            this.lblPassTK.TabIndex = 2;
            this.lblPassTK.Text = "Mật khẩu:";
            // 
            // txtUnameTK
            // 
            this.txtUnameTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnameTK.Location = new System.Drawing.Point(225, 10);
            this.txtUnameTK.Name = "txtUnameTK";
            this.txtUnameTK.Size = new System.Drawing.Size(245, 27);
            this.txtUnameTK.TabIndex = 1;
            // 
            // lblUnameTK
            // 
            this.lblUnameTK.AutoSize = true;
            this.lblUnameTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnameTK.Location = new System.Drawing.Point(65, 13);
            this.lblUnameTK.Name = "lblUnameTK";
            this.lblUnameTK.Size = new System.Drawing.Size(128, 20);
            this.lblUnameTK.TabIndex = 0;
            this.lblUnameTK.Text = "Tên tài khoản:";
            // 
            // frm_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 636);
            this.Controls.Add(this.dgvAddTaiKhoan);
            this.Controls.Add(this.pnlAddTaiKhoan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_TaiKhoan";
            this.Text = " BookStores - Tài Khoản";
            this.Load += new System.EventHandler(this.frm_TaiKhoan_Load);
            this.Shown += new System.EventHandler(this.frm_TaiKhoan_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddTaiKhoan)).EndInit();
            this.pnlAddTaiKhoan.ResumeLayout(false);
            this.pnlAddTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearchTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClearTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUDTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAddTaiKhoan;
        private System.Windows.Forms.Panel pnlAddTaiKhoan;
        private System.Windows.Forms.PictureBox picSearchTaiKhoan;
        private System.Windows.Forms.TextBox txtSearchTaiKhoan;
        private System.Windows.Forms.PictureBox picClearTaiKhoan;
        private System.Windows.Forms.PictureBox picUDTaiKhoan;
        private System.Windows.Forms.PictureBox picDelTaiKhoan;
        private System.Windows.Forms.PictureBox picAddTaiKhoan;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtEmailTK;
        private System.Windows.Forms.Label lblEmailTK;
        private System.Windows.Forms.TextBox txtRePassTK;
        private System.Windows.Forms.Label lblRePassTK;
        private System.Windows.Forms.TextBox txtPassTK;
        private System.Windows.Forms.Label lblPassTK;
        private System.Windows.Forms.TextBox txtUnameTK;
        private System.Windows.Forms.Label lblUnameTK;
        private System.Windows.Forms.CheckBox chk_PassTK;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
    }
}