using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Sử dụng thư viện kết nối database
using PMQL_BookStores.GUI;
using PMQL_BookStores.BUS; 

namespace PMQL_BookStores
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e) // Hàm hiện mật khẩu
        {
            if (chkShowPass.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DangNhapBUS DNB = new DangNhapBUS(this,txtTaiKhoan);
            DNB.DangNhap(txtTaiKhoan,txtMatKhau,chkShowPass);    
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtTaiKhoan.Text)) // Kiểm tra nhập tên tài khoản chưa
                {
                    MessageBox.Show("Bạn chưa nhập tên tài khoản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtMatKhau.Focus();
                }
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtMatKhau.Text)) // Kiểm tra nhập mật khẩu chưa
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    btnLogin_Click(sender, e);
                }
            }
        }
    }
}
