using Microsoft.SqlServer.Server;
using PMQL_BookStores.BUS;
using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.GUI
{
    public partial class frm_NhanVien : Form
    {
        string manv = "";
        public frm_NhanVien()
        {
            InitializeComponent();
        }

        private void txtSDTNV_KeyPress(object sender, KeyPressEventArgs e) // Thiết lập không cho người dùng nhập chữ vào ô nhập số điện thoại
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHoNV_KeyPress(object sender, KeyPressEventArgs e) // Thiết lập không cho người dùng nhập số vào ô nhập họ
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTenLotNV_KeyPress(object sender, KeyPressEventArgs e) // Thiết lập không cho người dùng nhập số vào ô nhập tên lót
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e) // Thiết lập không cho người dùng nhập số vào ô nhập tên
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void frm_NhanVien_Load(object sender, EventArgs e) // Khi load form thì bỏ chọn tất cả các difng trong datagridview
        {
            cboGioiTinhNV.SelectedIndex = 0;
            cboChucVuNV.SelectedIndex = 0;

            NhanVienBUS.Instance.HienThiDanhSachNhanVien(dgvAddNhanVien);
        }

        private void picAddNV_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn xóa
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtHoNV.Text) && !string.IsNullOrEmpty(txtTenLotNV.Text) && !string.IsNullOrEmpty(txtTenNV.Text)
                && !string.IsNullOrEmpty(cboGioiTinhNV.Text) && !string.IsNullOrEmpty(dtpNgaySinhNV.Text) && !string.IsNullOrEmpty(cboChucVuNV.Text)
                && !string.IsNullOrEmpty(txtDiaChiNV.Text) && !string.IsNullOrEmpty(txtSDTNV.Text))
            {
                List<NhanVienDTO> nhanvien = new List<NhanVienDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                NhanVienDTO NV = new NhanVienDTO(0, txtHoNV.Text, txtTenLotNV.Text, txtTenNV.Text, cboGioiTinhNV.Text, (DateTime)dtpNgaySinhNV.Value, txtDiaChiNV.Text, int.Parse(txtSDTNV.Text), cboChucVuNV.Text); // Khởi tạo đối tượng NhaCungCapDTO

                nhanvien.Add(NV); // Thêm vào list

                NhanVienBUS.Instance.ThemNhanVien(nhanvien, dgvAddNhanVien); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelNV_Click(object sender, EventArgs e) // hàm xử lý khi nhấn xóa
        {
            // Kiểm tra biến toàn cục mã nhân viên khác rỗng mới thực hiện
            if (dgvAddNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NhanVienBUS.Instance.XoaNhanVien(dgvAddNhanVien);
            }
        }

        private void picUDNV_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật
        {
            if (dgvAddNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khác rỗng mới thực hiện
                if (!string.IsNullOrEmpty(txtHoNV.Text) && !string.IsNullOrEmpty(txtTenLotNV.Text) && !string.IsNullOrEmpty(txtTenNV.Text)
                    && !string.IsNullOrEmpty(cboGioiTinhNV.Text) && !string.IsNullOrEmpty(dtpNgaySinhNV.Text) && !string.IsNullOrEmpty(cboChucVuNV.Text)
                    && !string.IsNullOrEmpty(txtDiaChiNV.Text) && !string.IsNullOrEmpty(txtSDTNV.Text))
                {
                    List<NhanVienDTO> nhanvien = new List<NhanVienDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    NhanVienDTO NV = new NhanVienDTO(0, txtHoNV.Text, txtTenLotNV.Text, txtTenNV.Text, cboGioiTinhNV.Text, (DateTime)dtpNgaySinhNV.Value, txtDiaChiNV.Text, int.Parse(txtSDTNV.Text), cboChucVuNV.Text); // Khởi tạo đối tượng NhaCungCapDTO

                    nhanvien.Add(NV); // Thêm vào list

                    NhanVienBUS.Instance.CapNhatNhanVien(nhanvien, dgvAddNhanVien); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearNV_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp
        {
            // Đặt tất cả các control về mặc định
            txtHoNV.Text = txtTenLotNV.Text = txtTenNV.Text = dtpNgaySinhNV.Text = txtDiaChiNV.Text = txtSDTNV.Text = txtSearchNV.Text = manv = "";
            cboGioiTinhNV.SelectedIndex = cboChucVuNV.SelectedIndex = 0;
            dgvAddNhanVien.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchNV_Click(object sender, EventArgs e) // Hàm xử lý tìm kiếm
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchNV.Text))
            {
                NhanVienBUS.Instance.SearchNhanVien(txtSearchNV, dgvAddNhanVien);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                NhanVienBUS.Instance.HienThiDanhSachNhanVien(dgvAddNhanVien);
            }
        }

        private void txtSearchNV_KeyPress(object sender, KeyPressEventArgs e) // hàm xử lý khi nhấn enter trong ô tìm kiếm
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                picSearchNV_Click((object)sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                NhanVienBUS.Instance.HienThiDanhSachNhanVien(dgvAddNhanVien);
            }

            if(e.KeyChar == (char)Keys.Back) // Thiết lập nếu nhập backspace
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                NhanVienBUS.Instance.HienThiDanhSachNhanVien(dgvAddNhanVien);
            }    
        }

        private void cboChucVuNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void frm_NhanVien_Shown(object sender, EventArgs e) // Thiết lập khi form hiển thị thì bỏ chọn tất cả các dòng trong datagridview
        {
            dgvAddNhanVien.ClearSelection();
        }

        private void dgvAddNhanVien_CellClick(object sender, DataGridViewCellEventArgs e) // Lấy giá trị trong datagridview lên tất cả các control
        {
            int i = dgvAddNhanVien.CurrentRow.Index;
            manv = dgvAddNhanVien.Rows[i].Cells[0].Value.ToString();
            txtHoNV.Text = dgvAddNhanVien.Rows[i].Cells[1].Value.ToString();
            txtTenLotNV.Text = dgvAddNhanVien.Rows[i].Cells[2].Value.ToString();
            txtTenNV.Text = dgvAddNhanVien.Rows[i].Cells[3].Value.ToString();
            cboGioiTinhNV.Text = dgvAddNhanVien.Rows[i].Cells[4].Value.ToString();
            dtpNgaySinhNV.Text = dgvAddNhanVien.Rows[i].Cells[5].Value.ToString();
            txtDiaChiNV.Text = dgvAddNhanVien.Rows[i].Cells[6].Value.ToString();
            txtSDTNV.Text = dgvAddNhanVien.Rows[i].Cells[7].Value.ToString();
            cboChucVuNV.Text = dgvAddNhanVien.Rows[i].Cells[8].Value.ToString();
        }

        private void txtSearchNV_TextChanged(object sender, EventArgs e) // Thiết lập khi giá trị trong ô tìm kiếm thay đổi
        {
            //NhanVienBUS NVB = new NhanVienBUS(txtHoNV, txtTenLotNV, txtTenNV, cboGioiTinhNV, dtpNgaySinhNV, txtDiaChiNV, txtSDTNV, cboChucVuNV, dgvAddNhanVien, txtSearchNV, manv);
            //NVB.SearchNhanVienKeyPress1();

            // Hiển thị dữ liệu mặc định lên datagridview
            NhanVienBUS.Instance.HienThiDanhSachNhanVien(dgvAddNhanVien);
        }

        private void dgvAddNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) // format date trong datagridview
        {
            if (e.ColumnIndex == 5)
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    DateTime dt = (DateTime)e.Value;

                    e.Value = dt.ToString("dd/MM/yyyy"); 
                    e.FormattingApplied = true; 
                }
            }
        }

        private void cboGioiTinhNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }
    }
}
