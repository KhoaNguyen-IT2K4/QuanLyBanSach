using PMQL_BookStores.BUS;
using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.GUI
{
    public partial class frm_HoaDon : Form
    {
        string mahd = ""; // biến toàn cục lấy mã hóa đơn
        string mhdCTHD = ""; // biến toàn cục lấy mã hóa đơn của chi tiết hóa đơn
        string msCTHD = ""; // biến toàn cục lấy mã sách của chi tiết hóa đơn

        bool loadCombobox = false; // Biến cờ hiệu kiểm tra form load

        private frm_Admin _admin; // tạo thuộc tính tham chiếu đến form admin
        public frm_HoaDon()
        {
            InitializeComponent();
        }

        public frm_HoaDon(frm_Admin admin) // Hàm khởi tạo có tham số để tham chiếu đến form admin
        {
            InitializeComponent();
            _admin = admin;
        }

        private void frm_HoaDon_Load(object sender, EventArgs e)
        {
            HoaDonBUS.Instance.HienThiDanhSachHoaDon(dgvAddHD);

            HoaDonBUS.Instance.DuLieuCBOMaNhanVien(cboMaNVHD);

            HoaDonBUS.Instance.DuLieuCBOMaKhachHang(cboMaKHHD);

            ChiTietHoaDonBUS.Instance.HienThiDanhSachChiTietHoaDon(dgvAddCTHD);

            ChiTietHoaDonBUS.Instance.DuLieuCBOMaHoaDon(cboMaHDCTHD);

            ChiTietHoaDonBUS.Instance.DuLieuCBOMaSach(cboMaSachCTHD);

            loadCombobox = true;
        }

        private void picAddHD_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn thêm của hóa đơn
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(cboMaNVHD.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboMaKHHD.SelectedValue.ToString()) && !string.IsNullOrEmpty(dtpNgayLap.Text))
            {
                List<HoaDonDTO> hoadon = new List<HoaDonDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                HoaDonDTO TLS = new HoaDonDTO(0, int.Parse(cboMaNVHD.SelectedValue.ToString()), (DateTime)dtpNgayLap.Value, int.Parse(cboMaKHHD.SelectedValue.ToString()), decimal.Parse(txtTongTienHD.Text), int.Parse(txtTongSoLuongHD.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                hoadon.Add(TLS); // Thêm vào list

                HoaDonBUS.Instance.ThemHoaDon(hoadon, dgvAddHD, cboMaHDCTHD); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelHD_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn xóa của hóa đơn
        {
            if (dgvAddHD.SelectedRows.Count == 0) // Kiểm tra biến toàn cục mã hóa đơn nếu rỗng thì thông báo, khác rỗng thì thực hiện
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                HoaDonBUS.Instance.XoaHoaDon(dgvAddHD, dgvAddCTHD, cboMaHDCTHD);
            }
        }

        private void picUDHD_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật của hóa đơn
        {
            if (dgvAddHD.SelectedRows.Count == 0) // Kiểm tra biến toàn cục mã hóa đơn nếu rỗng thì thông báo, khác rỗng thì thực hiện
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khác rỗng mới thực hiện
                if (!string.IsNullOrEmpty(cboMaNVHD.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboMaKHHD.SelectedValue.ToString()) && !string.IsNullOrEmpty(dtpNgayLap.Text))
                {
                    List<HoaDonDTO> hoadon = new List<HoaDonDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    HoaDonDTO TLS = new HoaDonDTO(0, int.Parse(cboMaNVHD.SelectedValue.ToString()), (DateTime)dtpNgayLap.Value, int.Parse(cboMaKHHD.SelectedValue.ToString()), decimal.Parse(txtTongTienHD.Text), int.Parse(txtTongSoLuongHD.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                    hoadon.Add(TLS); // Thêm vào list

                    HoaDonBUS.Instance.CapNhatHoaDon(hoadon, dgvAddHD); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearHD_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp của hóa đơn
        {
            // Đặt tất cả các control về mặc định
            dtpNgayLap.Text = txtSearchHD.Text = "";
            cboMaNVHD.SelectedIndex = cboMaKHHD.SelectedIndex = 0;
            txtTongSoLuongHD.Text = txtTongTienHD.Text = "0";
            dgvAddHD.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchHD_Click(object sender, EventArgs e) // Hàm xử lý khi tìm kiếm của hóa đơn
        {
            // kiểm tra ô nhập khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchHD.Text))
            {
                // Hiển thị dữ liệu cảu kết quả tìm kiếm lên datagridview
                HoaDonBUS.Instance.SearchHoaDon(txtSearchHD, dgvAddHD);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                HoaDonBUS.Instance.HienThiDanhSachHoaDon(dgvAddHD);
            }
        }

        private void txtSearchHD_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm của hóa đơn
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                picSearchHD_Click((object)sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                HoaDonBUS.Instance.HienThiDanhSachHoaDon(dgvAddHD);
            }
        }

        private void picAddCTHD_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn thêm của chi tiết hóa đơn
        {
            cboMaHDCTHD.Enabled = cboMaSachCTHD.Enabled = true;

            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(cboMaHDCTHD.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboMaSachCTHD.SelectedValue.ToString()) && nudSoLuongBan.Value != 0 && !string.IsNullOrEmpty(txtGiaThanhCTHD.Text))
            {
                List<ChiTietHoaDonDTO> CTHD = new List<ChiTietHoaDonDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO(int.Parse(cboMaHDCTHD.SelectedValue.ToString()),int.Parse(cboMaSachCTHD.SelectedValue.ToString()),(int)nudSoLuongBan.Value,decimal.Parse(txtGiaThanhCTHD.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                CTHD.Add(cthd); // Thêm vào list

                ChiTietHoaDonBUS.Instance.ThemChiTietHoaDon(CTHD, dgvAddCTHD, dgvAddHD); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelCTHD_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn xóa của chi tiết hóa đơn
        {
            cboMaHDCTHD.Enabled = cboMaSachCTHD.Enabled = true;

            // Kiểm tra biến toàn cục mã hóa đơn và mã sách của chi tiết hóa đơn khác rỗng mới thực hiện
            if (dgvAddCTHD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn chi tiết hóa đơn cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ChiTietHoaDonBUS.Instance.XoaChiTietHoaDon(dgvAddCTHD, dgvAddHD);
            }
        }

        private void picUDCTHD_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật của chi tiết hóa đơn
        {
            cboMaHDCTHD.Enabled = cboMaSachCTHD.Enabled = true;

            // Kiểm tra biến toàn cục mã hóa đơn và mã sách của chi tiết hóa đơn khác rỗng mới thực hiện
            if (dgvAddCTHD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn chi tiết hóa đơn cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khác rỗng mới thực hiện
                if (!string.IsNullOrEmpty(cboMaHDCTHD.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboMaSachCTHD.SelectedValue.ToString()) && nudSoLuongBan.Value != 0 && !string.IsNullOrEmpty(txtGiaThanhCTHD.Text))
                {
                    List<ChiTietHoaDonDTO> CTHD = new List<ChiTietHoaDonDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO(int.Parse(cboMaHDCTHD.SelectedValue.ToString()), int.Parse(cboMaSachCTHD.SelectedValue.ToString()), (int)nudSoLuongBan.Value, decimal.Parse(txtGiaThanhCTHD.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                    CTHD.Add(cthd); // Thêm vào list

                    ChiTietHoaDonBUS.Instance.CapNhatChiTietHoaDon(CTHD, dgvAddCTHD, dgvAddHD); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearCTHD_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp của chi tiết hóa đơn
        {
            // Đặt tất cả các control về mặc định
            txtSearchCTHD.Text = "";
            cboMaHDCTHD.SelectedIndex = cboMaSachCTHD.SelectedIndex = 0;
            nudSoLuongBan.Value = 0;
            txtGiaThanhCTHD.Text = "0";
            dgvAddCTHD.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            cboMaHDCTHD.Enabled = cboMaSachCTHD.Enabled = true;

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchCTHD_Click(object sender, EventArgs e) // Hàm xử lý khi tìm kiếm của chi tiết hóa đơn
        {
            // Kiểm tra ô nhập khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchCTHD.Text))
            {
                // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
                ChiTietHoaDonBUS.Instance.SearchChiTietHoaDon(txtSearchCTHD, dgvAddCTHD);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                ChiTietHoaDonBUS.Instance.HienThiDanhSachChiTietHoaDon(dgvAddCTHD);
            }
        }

        private void txtSearchCTHD_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm của chi tiết hóa đơn
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                picSearchCTHD_Click(sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                ChiTietHoaDonBUS.Instance.HienThiDanhSachChiTietHoaDon(dgvAddCTHD);
            }
        }

        public DataGridView dgvHD() // Hàm lấy control datagridview của hóa đơn để thực thi từ form khác
        {
            return dgvAddHD;
        }

        public DataGridView dgvCTHD() // Hàm lấy control datagridview của chi tiết hóa đơn để thực thi từ form khác
        {
            return dgvAddCTHD;
        }

        public ComboBox CBOmahdCTHD() // Hàm lấy control datagridview của chi tiết hóa đơn để thực thi từ form khác
        {
            return cboMaHDCTHD;
        }

        private void cboMaNVHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void cboMaKHHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void cboMaHDCTHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void cboMaSachCTHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        public void pdocHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) // Hàm xử lý in hóa đơn
        {
            HoaDonBUS.Instance.InHoaDon(e,mahd);
        }

        private void picInHoaDon_Click(object sender, EventArgs e) // Hàm xử lý hiện bản xem trước của in hóa đơn
        {
            HoaDonBUS.Instance.XemHoaDon(ppdHoaDon,this,dgvAddHD,mahd);
        }

        private void frm_HoaDon_Shown(object sender, EventArgs e) // Thiết lặp khi form hiển thị thì bỏ chọn tất cả các dòng của datagridview
        {
            dgvAddHD.ClearSelection();
            dgvAddCTHD.ClearSelection();
        }

        private void tcAddHoaDon_SelectedIndexChanged(object sender, EventArgs e) // Thiết lập khi thay đổi tabpage thì text label tiêu đề bên admin thay đổi
        {
            if(tcAddHoaDon.SelectedIndex == 0)
            {
                dgvAddHD.ClearSelection();
                _admin.DoiTieuDeAdmin(tcAddHoaDon.SelectedTab.Text);
            }
            else if(tcAddHoaDon.SelectedIndex == 1)
            {
                dgvAddCTHD.ClearSelection();
                _admin.DoiTieuDeAdmin(tcAddHoaDon.SelectedTab.Text);
            }    
        }

        private void dgvAddHD_CellClick(object sender, DataGridViewCellEventArgs e) // Thiết lập hiển lấy giá trị trong datagridview lên các control của hóa đơn
        {
            int i = dgvAddHD.CurrentRow.Index;
            mahd = dgvAddHD.Rows[i].Cells[0].Value.ToString();
            cboMaNVHD.SelectedValue = dgvAddHD.Rows[i].Cells[1].Value;
            dtpNgayLap.Text = dgvAddHD.Rows[i].Cells[2].Value.ToString();
            cboMaKHHD.SelectedValue = dgvAddHD.Rows[i].Cells[3].Value;
            txtTongTienHD.Text = dgvAddHD.Rows[i].Cells[4].Value.ToString();
            txtTongSoLuongHD.Text = dgvAddHD.Rows[i].Cells[5].Value.ToString();
        }

        private void dgvAddCTHD_CellClick(object sender, DataGridViewCellEventArgs e) // Thiết lập hiển lấy giá trị trong datagridview lên các control của chi tiết hóa đơn
        {
            int i = dgvAddCTHD.CurrentRow.Index;
            mhdCTHD = dgvAddCTHD.Rows[i].Cells[0].Value.ToString();
            msCTHD = dgvAddCTHD.Rows[i].Cells[1].Value.ToString();
            cboMaHDCTHD.SelectedValue = dgvAddCTHD.Rows[i].Cells[0].Value;
            cboMaSachCTHD.SelectedValue = dgvAddCTHD.Rows[i].Cells[1].Value;
            nudSoLuongBan.Value = (int)dgvAddCTHD.Rows[i].Cells[2].Value;
            txtGiaThanhCTHD.Text = dgvAddCTHD.Rows[i].Cells[3].Value.ToString();

            cboMaHDCTHD.Enabled = cboMaSachCTHD.Enabled = false;
        }

        private void dgvAddHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) // format lại datetime của hóa đơn
        {
            if (e.ColumnIndex == 2)
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    DateTime dt = (DateTime)e.Value;

                    e.Value = dt.ToString("dd/MM/yyyy - HH:mm:ss");
                    e.FormattingApplied = true;
                }
            }
        }

        private void cboMaSachCTHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loadCombobox) // Sau khi form load xong mới thực hiện
            {
                if (cboMaSachCTHD.SelectedIndex !=  -1) // Hiển thị giá thành khi chọn tên sách
                {
                    string ms = cboMaSachCTHD.SelectedValue.ToString(); // Lấy mã sách khi chọn tên sách
                    string donGiaBan = ChiTietHoaDonBUS.Instance.HienThiGiaThanhTheoMaSachCTHD(ms.ToString()); // Truy vấn lấy đơn giá bán của mã sách đó
                    txtGiaThanhCTHD.Text = donGiaBan.ToString(); // Hiển thị giá thành
                }
            }    
        }
    }
}
