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
    public partial class frm_KhachHang : Form
    {
        string makh = "";
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e) // Thiết lập không cho người dùng nhập chữ vào ô nhập số điện thoại
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }    
        }

        private void txtHoTenKH_KeyPress(object sender, KeyPressEventArgs e) // Thiết lập không cho người dùng nhập số vào ô nhập họ tên
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            cboGioiTinhKH.SelectedIndex = 0; // đặt mặc định hiển thị giới tính là nam

            KhachHangBUS.Instance.HienThiDanhSachKhachHang(dgvAddKH);
        }

        private void picAddKH_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn thêm
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtHoTenKH.Text) && !string.IsNullOrEmpty(cboGioiTinhKH.Text) && !string.IsNullOrEmpty(dtpNgaySinhKH.Text)
                && !string.IsNullOrEmpty(txtDiaChiKH.Text) && !string.IsNullOrEmpty(txtSDTKH.Text))
            {
                List<KhachHangDTO> khachhang = new List<KhachHangDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                KhachHangDTO KH = new KhachHangDTO(0, txtHoTenKH.Text, cboGioiTinhKH.Text, (DateTime)dtpNgaySinhKH.Value, txtDiaChiKH.Text, int.Parse(txtSDTKH.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                khachhang.Add(KH); // Thêm vào list

                KhachHangBUS.Instance.ThemKhachHang(khachhang, dgvAddKH); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelKH_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn xóa
        {
            // Kiểm tra biến toàn cục mã khách hàng khác rỗng mới thực hiện
            if (dgvAddKH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần xóa!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                KhachHangBUS.Instance.XoaKhachHang(dgvAddKH);
            }
        }

        private void picUDKH_Click(object sender, EventArgs e) // hàm xử lý khi nhấn cập nhật
        {
            if (dgvAddKH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần chỉnh sửa!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khác rỗng mới thực hiện
                if (!string.IsNullOrEmpty(txtHoTenKH.Text) && !string.IsNullOrEmpty(cboGioiTinhKH.Text) && !string.IsNullOrEmpty(dtpNgaySinhKH.Text)
                    && !string.IsNullOrEmpty(txtDiaChiKH.Text) && !string.IsNullOrEmpty(txtSDTKH.Text))
                {
                    List<KhachHangDTO> khachhang = new List<KhachHangDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    KhachHangDTO KH = new KhachHangDTO(0, txtHoTenKH.Text, cboGioiTinhKH.Text, (DateTime)dtpNgaySinhKH.Value, txtDiaChiKH.Text, int.Parse(txtSDTKH.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                    khachhang.Add(KH); // Thêm vào list

                    KhachHangBUS.Instance.CapNhatKhachHang(khachhang, dgvAddKH); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearKH_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp
        {
            // Đặt các control về mặc định
            txtHoTenKH.Text = dtpNgaySinhKH.Text = txtDiaChiKH.Text = txtSDTKH.Text = txtSearchKH.Text = "";
            cboGioiTinhKH.SelectedIndex = 0;
            dgvAddKH.ClearSelection(); // Bỏ chọn taast cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchKH_Click(object sender, EventArgs e) // Hàm xử lý tìm kiếm
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchKH.Text))
            {
                // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
                KhachHangBUS.Instance.SearchKhachHang(txtSearchKH, dgvAddKH);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                KhachHangBUS.Instance.HienThiDanhSachKhachHang(dgvAddKH);
            }
        }

        private void txtSearchKH_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                picSearchKH_Click((object)sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                KhachHangBUS.Instance.HienThiDanhSachKhachHang(dgvAddKH);
            }
        }

        private void frm_KhachHang_Shown(object sender, EventArgs e) // Thiết lập khi form hiển thị thì bỏ chọn tất cả các dòng trong datagridview
        {
            dgvAddKH.ClearSelection();
        }

        private void dgvAddKH_CellClick(object sender, DataGridViewCellEventArgs e) // Thiết lập lấy dữ liệu trong datagridview lên các control
        {
            int i = dgvAddKH.CurrentRow.Index;
            makh = dgvAddKH.Rows[i].Cells[0].Value.ToString();
            txtHoTenKH.Text = dgvAddKH.Rows[i].Cells[1].Value.ToString();
            cboGioiTinhKH.Text = dgvAddKH.Rows[i].Cells[2].Value.ToString();
            dtpNgaySinhKH.Text = dgvAddKH.Rows[i].Cells[3].Value.ToString();
            txtDiaChiKH.Text = dgvAddKH.Rows[i].Cells[4].Value.ToString();
            txtSDTKH.Text = dgvAddKH.Rows[i].Cells[5].Value.ToString();
        }

        private void dgvAddKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) // format date trong datagridview
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    DateTime dt = (DateTime)e.Value;

                    e.Value = dt.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }
        }

        private void cboGioiTinhKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }
    }
}
