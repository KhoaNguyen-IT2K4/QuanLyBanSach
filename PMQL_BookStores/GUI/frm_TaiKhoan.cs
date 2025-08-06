using PMQL_BookStores.BUS;
using PMQL_BookStores.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using PMQL_BookStores.DTO;

namespace PMQL_BookStores.GUI
{
    public partial class frm_TaiKhoan : Form
    {
        string matk = "";
        public frm_TaiKhoan()
        {
            InitializeComponent();
        }

        private void chk_PassTK_CheckedChanged(object sender, EventArgs e) // Thiết lập khi người dùng check showpass
        {
            if(chk_PassTK.Checked == true)
            {
                txtPassTK.UseSystemPasswordChar = false;
                txtRePassTK.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassTK.UseSystemPasswordChar = true;
                txtRePassTK.UseSystemPasswordChar = true;
            }
        }

        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            cboTrangThai.SelectedIndex = 1;

            TaiKhoanBUS.Instance.HienThiDanhSachTaiKhoan(dgvAddTaiKhoan);

            TaiKhoanBUS.Instance.DuLieuCBOMaNhanVien(cboMaNV);
        }

        private void picAddTaiKhoan_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn thêm
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtUnameTK.Text) && !string.IsNullOrEmpty(txtPassTK.Text) && !string.IsNullOrEmpty(txtRePassTK.Text)
                && !string.IsNullOrEmpty(txtEmailTK.Text) && !string.IsNullOrEmpty(cboMaNV.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboTrangThai.Text))
            {
                // Tạo chuỗi kiểm tra email
                string emailPattern = @"^[a-zA-Z0-9!@#$%^&*()-_+=]+@gmail\.com$";
                Regex regex = new Regex(emailPattern); // Phương thức kiểm tra chuỗi

                if (!regex.IsMatch(txtEmailTK.Text)) // Nếu đúng định dạng email mới thực hiện,sai thì xuất thông abso
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailTK.Focus();
                }
                else
                {
                    // Kiểm tra mật khẩu và xác nhận mật khẩu trùng khớp mới thực hiện
                    if (txtPassTK.Text == txtRePassTK.Text)
                    {
                        List<TaiKhoanDTO> taikhoan = new List<TaiKhoanDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                        TaiKhoanDTO TK = new TaiKhoanDTO(0, txtUnameTK.Text, txtPassTK.Text, txtEmailTK.Text, int.Parse(cboMaNV.SelectedValue.ToString()), cboTrangThai.Text); // Khởi tạo đối tượng NhaCungCapDTO

                        taikhoan.Add(TK); // Thêm vào list

                        TaiKhoanBUS.Instance.ThemTaiKhoan(taikhoan, dgvAddTaiKhoan); // Gửi lên tầng BUS xử lý
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không trùng khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRePassTK.Focus(); // mật khẩu và xác nhận mật khẩu không trùng khớp thì con trỏ ở ô xác nhận mật khẩu để nhập lại
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelTaiKhoan_Click(object sender, EventArgs e) // hàm xử lý khi nhấn xóa
        {
            // Kiểm tra biến toàn cục mã tài khoản khác rỗng mới thực hiện
            if (dgvAddTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TaiKhoanBUS.Instance.XoaTaiKhoan(dgvAddTaiKhoan);
            }
        }

        private void picUDTaiKhoan_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật
        {
            // Kiểm tra biến toàn cục mã tài khoản khác rỗng mới thực hiện
            if (dgvAddTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khác rỗng mới thực hiện
                if (!string.IsNullOrEmpty(txtUnameTK.Text) && !string.IsNullOrEmpty(txtPassTK.Text) && !string.IsNullOrEmpty(txtRePassTK.Text)
                    && !string.IsNullOrEmpty(txtEmailTK.Text) && !string.IsNullOrEmpty(cboMaNV.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboTrangThai.Text))
                {
                    // Tạo chuỗi kiểm tra email
                    string emailPattern = @"^[a-zA-Z0-9!@#$%^&*()-_+=]+@gmail\.com$";
                    Regex regex = new Regex(emailPattern); // Phương thức kiểm tra chuỗi

                    if (!regex.IsMatch(txtEmailTK.Text)) // Nếu đúng định dạng email mới thực hiện,sai thì xuất thông abso
                    {
                        MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmailTK.Focus();
                    }
                    else
                    {
                        // Kiểm tra mật khẩu và xác nhận mật khẩu trùng khớp mới thực hiện
                        if (txtPassTK.Text == txtRePassTK.Text)
                        {
                            List<TaiKhoanDTO> taikhoan = new List<TaiKhoanDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                            TaiKhoanDTO TK = new TaiKhoanDTO(0, txtUnameTK.Text, txtPassTK.Text, txtEmailTK.Text, int.Parse(cboMaNV.SelectedValue.ToString()), cboTrangThai.Text); // Khởi tạo đối tượng NhaCungCapDTO

                            taikhoan.Add(TK); // Thêm vào list

                            TaiKhoanBUS.Instance.CapNhatTaiKhoan(taikhoan, dgvAddTaiKhoan); // Gửi lên tầng BUS xử lý
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không trùng khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtRePassTK.Focus(); // mật khẩu và xác nhận mật khẩu không trùng khớp thì con trỏ ở ô xác nhận mật khẩu để nhập lại
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picSearchTaiKhoan_Click(object sender, EventArgs e) // Hàm xử lý tìm kiếm
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchTaiKhoan.Text))
            {
                // Không cho hiển thị tài khoản admin
                if (txtSearchTaiKhoan.Text != "Admin" && txtSearchTaiKhoan.Text != "admin")
                {
                    // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
                    TaiKhoanBUS.Instance.SearchTaiKhoan(txtSearchTaiKhoan, dgvAddTaiKhoan);
                }
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                TaiKhoanBUS.Instance.HienThiDanhSachTaiKhoan(dgvAddTaiKhoan);
            }
        }

        private void txtSearchTaiKhoan_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                picSearchTaiKhoan_Click(sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                TaiKhoanBUS.Instance.HienThiDanhSachTaiKhoan(dgvAddTaiKhoan);
            }

            if(e.KeyChar == (char)Keys.Back) // Thiết lập khi người dùng nhấn backspace
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                TaiKhoanBUS.Instance.HienThiDanhSachTaiKhoan(dgvAddTaiKhoan);
            }    
        }


        public DataGridView dgvTK() // Lấy datagridview để tham chiếu xử lý ở form khác
        {
            return dgvAddTaiKhoan;
        }

        public ComboBox manvCBO()
        {
            return cboMaNV;
        }

        private void cboMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void picClearTaiKhoan_Click(object sender, EventArgs e) // Hàm xư lý khi nhấn dọn dẹp
        {
            // Đặt tất cả các control về mặc định
            txtUnameTK.Text = txtPassTK.Text = txtRePassTK.Text = txtEmailTK.Text = txtSearchTaiKhoan.Text = "";
            cboMaNV.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 1;
            dgvAddTaiKhoan.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frm_TaiKhoan_Shown(object sender, EventArgs e) // Thiết lập khi form hiển thị thì bỏ chọn tất cả các dòng trong datagridview
        {
            dgvAddTaiKhoan.ClearSelection();
        }

        private void dgvAddTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e) // Lấy dữ liệu trong datagridview lên tất cả các control
        {
            int i = dgvAddTaiKhoan.CurrentRow.Index;
            matk = dgvAddTaiKhoan.Rows[i].Cells[0].Value.ToString();
            txtUnameTK.Text = dgvAddTaiKhoan.Rows[i].Cells[1].Value.ToString();
            txtPassTK.Text = dgvAddTaiKhoan.Rows[i].Cells[2].Value.ToString();
            txtRePassTK.Text = "";
            txtEmailTK.Text = dgvAddTaiKhoan.Rows[i].Cells[3].Value.ToString();
            cboMaNV.SelectedValue = dgvAddTaiKhoan.Rows[i].Cells[4].Value;
            cboTrangThai.Text = dgvAddTaiKhoan.Rows[i].Cells[5].Value.ToString();
        }

        private void txtSearchTaiKhoan_TextChanged(object sender, EventArgs e) // hàm xử lý khi giá trị trong ô tìm kiếm thay đổi
        {
            //TaiKhoanBUS TKB = new TaiKhoanBUS(txtUnameTK, txtPassTK, txtRePassTK, txtEmailTK, cboMaNV, cboTrangThai, dgvAddTaiKhoan, txtSearchTaiKhoan, matk);
            //TKB.SearchTaiKhoanKeyPress1();

            // Hiển thị dữ liệu mặc định lên datagridview
            TaiKhoanBUS.Instance.HienThiDanhSachTaiKhoan(dgvAddTaiKhoan);
        }

        private void dgvAddTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) // format passwword trong datagridview
        {
            if(e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = new string('*',e.Value.ToString().Length);
            }
        }

        private void cboTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }
    }
}
