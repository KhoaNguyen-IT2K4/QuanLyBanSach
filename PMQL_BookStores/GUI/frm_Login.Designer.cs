namespace PMQL_BookStores
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.pnlTieuDeLG = new System.Windows.Forms.Panel();
            this.lblTenTieuDeLG = new System.Windows.Forms.Label();
            this.pnlDangNhap = new System.Windows.Forms.Panel();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.picMatKhau = new System.Windows.Forms.PictureBox();
            this.picTaiKhoan = new System.Windows.Forms.PictureBox();
            this.picLogoTK = new System.Windows.Forms.PictureBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.picLogoLG = new System.Windows.Forms.PictureBox();
            this.pnlTieuDeLG.SuspendLayout();
            this.pnlDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMatKhau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoLG)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTieuDeLG
            // 
            this.pnlTieuDeLG.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlTieuDeLG.Controls.Add(this.lblTenTieuDeLG);
            this.pnlTieuDeLG.Location = new System.Drawing.Point(0, 2);
            this.pnlTieuDeLG.Name = "pnlTieuDeLG";
            this.pnlTieuDeLG.Size = new System.Drawing.Size(892, 56);
            this.pnlTieuDeLG.TabIndex = 3;
            // 
            // lblTenTieuDeLG
            // 
            this.lblTenTieuDeLG.AutoSize = true;
            this.lblTenTieuDeLG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTieuDeLG.Location = new System.Drawing.Point(287, 9);
            this.lblTenTieuDeLG.Name = "lblTenTieuDeLG";
            this.lblTenTieuDeLG.Size = new System.Drawing.Size(306, 32);
            this.lblTenTieuDeLG.TabIndex = 0;
            this.lblTenTieuDeLG.Text = "Đăng Nhập Hệ Thống";
            // 
            // pnlDangNhap
            // 
            this.pnlDangNhap.BackgroundImage = global::PMQL_BookStores.Properties.Resources.Bg_pnl_DangNhap;
            this.pnlDangNhap.Controls.Add(this.chkShowPass);
            this.pnlDangNhap.Controls.Add(this.btnLogin);
            this.pnlDangNhap.Controls.Add(this.txtMatKhau);
            this.pnlDangNhap.Controls.Add(this.picMatKhau);
            this.pnlDangNhap.Controls.Add(this.picTaiKhoan);
            this.pnlDangNhap.Controls.Add(this.picLogoTK);
            this.pnlDangNhap.Controls.Add(this.txtTaiKhoan);
            this.pnlDangNhap.Location = new System.Drawing.Point(442, 55);
            this.pnlDangNhap.Name = "pnlDangNhap";
            this.pnlDangNhap.Size = new System.Drawing.Size(450, 407);
            this.pnlDangNhap.TabIndex = 5;
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.BackColor = System.Drawing.Color.Transparent;
            this.chkShowPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPass.Location = new System.Drawing.Point(100, 276);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(118, 24);
            this.chkShowPass.TabIndex = 6;
            this.chkShowPass.Text = "ShowPass";
            this.chkShowPass.UseVisualStyleBackColor = false;
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Location = new System.Drawing.Point(148, 318);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(144, 43);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(100, 235);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(312, 34);
            this.txtMatKhau.TabIndex = 4;
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatKhau_KeyPress);
            // 
            // picMatKhau
            // 
            this.picMatKhau.Image = global::PMQL_BookStores.Properties.Resources.anh_o_khoa;
            this.picMatKhau.Location = new System.Drawing.Point(39, 235);
            this.picMatKhau.Name = "picMatKhau";
            this.picMatKhau.Size = new System.Drawing.Size(32, 31);
            this.picMatKhau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMatKhau.TabIndex = 3;
            this.picMatKhau.TabStop = false;
            // 
            // picTaiKhoan
            // 
            this.picTaiKhoan.Image = global::PMQL_BookStores.Properties.Resources.User;
            this.picTaiKhoan.Location = new System.Drawing.Point(39, 182);
            this.picTaiKhoan.Name = "picTaiKhoan";
            this.picTaiKhoan.Size = new System.Drawing.Size(32, 36);
            this.picTaiKhoan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTaiKhoan.TabIndex = 2;
            this.picTaiKhoan.TabStop = false;
            // 
            // picLogoTK
            // 
            this.picLogoTK.Image = global::PMQL_BookStores.Properties.Resources.anh_account;
            this.picLogoTK.Location = new System.Drawing.Point(121, 29);
            this.picLogoTK.Name = "picLogoTK";
            this.picLogoTK.Size = new System.Drawing.Size(205, 123);
            this.picLogoTK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoTK.TabIndex = 1;
            this.picLogoTK.TabStop = false;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(100, 184);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(312, 34);
            this.txtTaiKhoan.TabIndex = 0;
            this.txtTaiKhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaiKhoan_KeyPress);
            // 
            // picLogoLG
            // 
            this.picLogoLG.Image = global::PMQL_BookStores.Properties.Resources.Logo_BookStores;
            this.picLogoLG.Location = new System.Drawing.Point(0, 55);
            this.picLogoLG.Name = "picLogoLG";
            this.picLogoLG.Size = new System.Drawing.Size(442, 407);
            this.picLogoLG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogoLG.TabIndex = 4;
            this.picLogoLG.TabStop = false;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 462);
            this.Controls.Add(this.pnlDangNhap);
            this.Controls.Add(this.picLogoLG);
            this.Controls.Add(this.pnlTieuDeLG);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - BookStores";
            this.pnlTieuDeLG.ResumeLayout(false);
            this.pnlTieuDeLG.PerformLayout();
            this.pnlDangNhap.ResumeLayout(false);
            this.pnlDangNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMatKhau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoLG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDangNhap;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.PictureBox picMatKhau;
        private System.Windows.Forms.PictureBox picTaiKhoan;
        private System.Windows.Forms.PictureBox picLogoTK;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.PictureBox picLogoLG;
        private System.Windows.Forms.Panel pnlTieuDeLG;
        private System.Windows.Forms.Label lblTenTieuDeLG;
        private System.Windows.Forms.CheckBox chkShowPass;
    }
}