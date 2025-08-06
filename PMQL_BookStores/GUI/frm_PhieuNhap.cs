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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.GUI
{
    public partial class frm_PhieuNhap : Form
    {
        string mapn = "";
        string mpnCTPN = "";
        string msCTPN = "";

        bool loadCombobox = false; // Cờ hiệu kiểm tra form load xong

        private frm_Admin _admin; // Tạo thuộc tính tham chiếu đến form admin

        public frm_PhieuNhap()
        {
            InitializeComponent();
        }

        public frm_PhieuNhap(frm_Admin admin) // Hàm khởi tạo có tham số để tham chiếu đến form admin và thay đổi text label tiêu đề của admin
        {
            InitializeComponent();
            _admin = admin;
        }

        private void frm_PhieuNhap_Load(object sender, EventArgs e)
        {
            // Load datagridview phiếu nhập
            PhieuNhapBUS.Instance.HienThiDanhSachPhieuNhap(dgvAddPhieuNhap);

            // Load combobox mã nhân viên của phiếu nhập
            PhieuNhapBUS.Instance.DuLieuCBOMaNhanVien(cboMaNVPN);

            // Load combobox mã nhà cung cấp của phiếu nhập
            PhieuNhapBUS.Instance.DuLieuCBOMaNhaCungCap(cboMaNCC);

            // Load datagridview chi tiết phiếu nhập
            ChiTietPhieuNhapBUS.Instance.HienThiDanhSachChiTietPhieuNhap(dgvAddCTPN);

            // Load combobox mã phiếu nhập của chi tiết phiếu nhập
            ChiTietPhieuNhapBUS.Instance.DuLieuCBOMaPhieuNhap(cboMaPNCTPN);

            // Load combobox mã sách của chi tiết phiếu nhập
            ChiTietPhieuNhapBUS.Instance.DuLieuCBOMaSach(cboMaSachCTPN);

            loadCombobox = true;
        }



        // =========================================================================== Phiếu Nhập ===================================================================================================== //
        private void picAddPN_Click(object sender, EventArgs e) // Hàm xử lý khi nhán thêm của phiếu nhập
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(cboMaNVPN.Text) && !string.IsNullOrEmpty(cboMaNCC.Text) && !string.IsNullOrEmpty(dtpNgayNhap.Text))
            {
                List<PhieuNhapDTO> phieunhap = new List<PhieuNhapDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                PhieuNhapDTO PN = new PhieuNhapDTO(0, int.Parse(cboMaNVPN.SelectedValue.ToString()),(DateTime)dtpNgayNhap.Value, int.Parse(cboMaNCC.SelectedValue.ToString()),decimal.Parse(txtTongTienPN.Text),int.Parse(txtTongSoLuongPN.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                phieunhap.Add(PN); // Thêm vào list

                PhieuNhapBUS.Instance.ThemPhieuNhap(phieunhap, cboMaPNCTPN, dgvAddPhieuNhap); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelPN_Click(object sender, EventArgs e) // hàm xử lý khi nhấn xóa của phiếu nhập
        {
            // Kiểm tra biến toàn cục mã phiếu nhập khác rỗng miws thực hiện
            if (dgvAddPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn phiếu nhập cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                PhieuNhapBUS.Instance.XoaPhieuNhap(dgvAddPhieuNhap, dgvAddCTPN, cboMaPNCTPN);
            }
        }

        private void picUDPN_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật của phiếu nhập
        {
            if (dgvAddPhieuNhap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn phiếu nhập cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!string.IsNullOrEmpty(cboMaNVPN.Text) && !string.IsNullOrEmpty(cboMaNCC.Text) && !string.IsNullOrEmpty(dtpNgayNhap.Text))
                {
                    List<PhieuNhapDTO> phieunhap = new List<PhieuNhapDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    PhieuNhapDTO PN = new PhieuNhapDTO(0, int.Parse(cboMaNVPN.SelectedValue.ToString()), (DateTime)dtpNgayNhap.Value, int.Parse(cboMaNCC.SelectedValue.ToString()), decimal.Parse(txtTongTienPN.Text), int.Parse(txtTongSoLuongPN.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                    phieunhap.Add(PN); // Thêm vào list

                    PhieuNhapBUS.Instance.CapNhatPhieuNhap(phieunhap, dgvAddPhieuNhap); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearPN_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp của phiếu nhập
        {
            // Đặt taasst cả các control về mặc định
            dtpNgayNhap.Text = txtSearchPN.Text = "";
            cboMaNVPN.SelectedIndex = cboMaNCC.SelectedIndex = 0;
            txtTongSoLuongPN.Text = txtTongTienPN.Text = "0";
            dgvAddPhieuNhap.ClearSelection(); // Bổ chọn tất cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchPN_Click(object sender, EventArgs e) // Hàm xử lý tìm kiếm của phiếu nhập
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchPN.Text))
            {
                // Hiển thị dữ liệu cẩu kết quả tìm kiếm lên datagridview
                PhieuNhapBUS.Instance.SearchPhieuNhap(txtSearchPN, dgvAddPhieuNhap);
            }
            else
            {
                // Hiển thị giá trị mặc định lên datagridveiw
                PhieuNhapBUS.Instance.HienThiDanhSachPhieuNhap(dgvAddPhieuNhap);
            }
        }

        private void txtSearchPN_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm của phiếu nhập
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                picSearchPN_Click((object)sender, e);
            }
            else
            {
                // Hiển thị giá trị mặc định lên datagridveiw
                PhieuNhapBUS.Instance.HienThiDanhSachPhieuNhap(dgvAddPhieuNhap);
            }
        }

        public DataGridView dgvPN() // Lấy datagridview của phiếu nhập để tham chiếu xử lý ở form khác
        {
            return dgvAddPhieuNhap;
        }

        private void cboMaNVPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void cboMaNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void dgvAddPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e) // lấy giá trị trong datagridview hiển thi lên tất cả các control của phiếu nhập
        {
            int i = dgvAddPhieuNhap.CurrentRow.Index;
            mapn = dgvAddPhieuNhap.Rows[i].Cells[0].Value.ToString();
            cboMaNVPN.SelectedValue = dgvAddPhieuNhap.Rows[i].Cells[1].Value;
            dtpNgayNhap.Text = dgvAddPhieuNhap.Rows[i].Cells[2].Value.ToString();
            cboMaNCC.SelectedValue = dgvAddPhieuNhap.Rows[i].Cells[3].Value;
            txtTongTienPN.Text = dgvAddPhieuNhap.Rows[i].Cells[4].Value.ToString();
            txtTongSoLuongPN.Text = dgvAddPhieuNhap.Rows[i].Cells[5].Value.ToString();
        }

        private void picInPhieuNhap_Click(object sender, EventArgs e) // Hàm xử lý in phiếu nhập
        {
            PhieuNhapBUS.Instance.XemPhieuNhap(ppdPhieuNhap, this, mapn, dgvAddPhieuNhap);
        }

        public void pdocPhieuNhap_PrintPage(object sender, PrintPageEventArgs e) // Hàm xử lý xem trước in phiếu nhập
        {
            PhieuNhapBUS.Instance.InPhieuNhap(e, mapn);
        }

        private void dgvAddPhieuNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) // format datetime trong datagridview
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



        // =========================================================================== Chi Tiết Phiếu Nhập ===================================================================================================== //

        private void picAddCTPN_Click(object sender, EventArgs e) // hàm xử lý khi nhấn thêm của chi tiết phiếu nhập
        {
            cboMaPNCTPN.Enabled = cboMaSachCTPN.Enabled = true;

            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(cboMaPNCTPN.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboMaSachCTPN.SelectedValue.ToString()) && nudSoLuongNhap.Value != 0 && nudGiaThanhCTPN.Value != 0)
            {
                List<ChiTietPhieuNhapDTO> CTPN = new List<ChiTietPhieuNhapDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO(int.Parse(cboMaPNCTPN.SelectedValue.ToString()), int.Parse(cboMaSachCTPN.SelectedValue.ToString()), (int)nudSoLuongNhap.Value, (decimal)nudGiaThanhCTPN.Value/*, (decimal)0*/); // Khởi tạo đối tượng NhaCungCapDTO

                CTPN.Add(ctpn); // Thêm vào list

                ChiTietPhieuNhapBUS.Instance.ThemChiTietPN(CTPN, dgvAddCTPN, dgvAddPhieuNhap); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelCTPN_Click(object sender, EventArgs e) // hàm xử lý khi nhấn xóa của chi tiết phiếu nhập
        {
            cboMaPNCTPN.Enabled = cboMaSachCTPN.Enabled = true;

            // Kiểm tra biến toàn cục mã phiếu nhập và mã sách của chi tiết phiếu nhập khác rỗng mới thực hiện
            if (dgvAddCTPN.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn chi tiết phiếu nhập cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ChiTietPhieuNhapBUS.Instance.XoaChiTietPN(dgvAddCTPN, dgvAddPhieuNhap);
            }
        }

        private void picUDCTPN_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật của chi tiết phiếu nhập
        {
            cboMaPNCTPN.Enabled = cboMaSachCTPN.Enabled = true;

            // Kiểm tra biến toàn cục mã phiếu nhập và mã sách của chi tiết phiếu nhập khác rỗng mới thực hiện
            if (dgvAddCTPN.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn chi tiết phiếu nhập cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khác rỗng mới thực hiện
                if (!string.IsNullOrEmpty(cboMaPNCTPN.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboMaSachCTPN.SelectedValue.ToString()) && nudSoLuongNhap.Value != 0 && nudGiaThanhCTPN.Value != 0)
                {
                    List<ChiTietPhieuNhapDTO> CTPN = new List<ChiTietPhieuNhapDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    ChiTietPhieuNhapDTO ctpn = new ChiTietPhieuNhapDTO(int.Parse(cboMaPNCTPN.SelectedValue.ToString()), int.Parse(cboMaSachCTPN.SelectedValue.ToString()), (int)nudSoLuongNhap.Value, (decimal)nudGiaThanhCTPN.Value/*, (decimal)0*/); // Khởi tạo đối tượng NhaCungCapDTO

                    CTPN.Add(ctpn); // Thêm vào list

                    ChiTietPhieuNhapBUS.Instance.CapNhatChiTietPN(CTPN, dgvAddCTPN, dgvAddPhieuNhap); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearCTPN_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp của chi tiết phiếu nhập
        {
            // Đặt tất cả các control về mặc định
            txtSearchCTPN.Text = "";
            cboMaPNCTPN.SelectedIndex = cboMaSachCTPN.SelectedIndex = 0;
            nudSoLuongNhap.Value = 0;
            nudGiaThanhCTPN.Value = 0;
            dgvAddCTPN.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            cboMaPNCTPN.Enabled = cboMaSachCTPN.Enabled = true;

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchCTPN_Click(object sender, EventArgs e) // hàm xử lý tìm kiếm của chi tiết phiếu nhập
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchCTPN.Text))
            {
                // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
                ChiTietPhieuNhapBUS.Instance.SearchCchiTietPN(txtSearchCTPN, dgvAddCTPN);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                ChiTietPhieuNhapBUS.Instance.HienThiDanhSachChiTietPhieuNhap(dgvAddCTPN);
            }
        }

        private void txtSearchCTPN_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm của chi tiết phiếu nhập
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                picSearchCTPN_Click((object)sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                ChiTietPhieuNhapBUS.Instance.HienThiDanhSachChiTietPhieuNhap(dgvAddCTPN);
            }
        }

        public DataGridView dgvCTPN() // Lấy datagridview của chi tiết phiếu nhập để tham chiếu xử lý ở form khác
        {
            return dgvAddCTPN;
        }

        public ComboBox cboMPNCTPN() // Lấy datagridview của chi tiết phiếu nhập để tham chiếu xử lý ở form khác
        {
            return cboMaPNCTPN;
        }

        private void cboMaPNCTPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void frm_PhieuNhap_Shown(object sender, EventArgs e) // Thiết lập khi form hiển thị thì bỏ chọn tất cả các dòng trong datagridview
        {
            dgvAddPhieuNhap.ClearSelection();
            dgvAddCTPN.ClearSelection();
        }

        private void tcAddPN_SelectedIndexChanged(object sender, EventArgs e) // Thiết lập khi tabpage thay đổi thì text label tiêu đề của admin thay đổi
        {
            if(tcAddPN.SelectedIndex == 0)
            {
                dgvAddPhieuNhap.ClearSelection();
                _admin.DoiTieuDeAdmin(tcAddPN.SelectedTab.Text);
            }   
            else if(tcAddPN.SelectedIndex == 1)
            {
                dgvAddCTPN.ClearSelection();
                _admin.DoiTieuDeAdmin(tcAddPN.SelectedTab.Text);
            }
        }

        private void dgvAddCTPN_CellClick(object sender, DataGridViewCellEventArgs e) // lấy giá trị trong datagridview hiển thi lên tất cả các control của chi tiết phiếu nhập
        {
            int i = dgvAddCTPN.CurrentRow.Index;
            mpnCTPN = dgvAddCTPN.Rows[i].Cells[0].Value.ToString();
            msCTPN = dgvAddCTPN.Rows[i].Cells[1].Value.ToString();
            cboMaPNCTPN.Text = dgvAddCTPN.Rows[i].Cells[0].Value.ToString();
            cboMaSachCTPN.SelectedValue = dgvAddCTPN.Rows[i].Cells[1].Value;
            nudSoLuongNhap.Value = (int)dgvAddCTPN.Rows[i].Cells[2].Value;
            nudGiaThanhCTPN.Value = (decimal)dgvAddCTPN.Rows[i].Cells[3].Value;

            cboMaPNCTPN.Enabled = cboMaSachCTPN.Enabled = false;
        }

        private void cboMaSachCTPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loadCombobox) // Kiểm tra form load xong mới thực hiện
            {
                if(cboMaSachCTPN.SelectedIndex != -1) // Hiển thị giá thành khi chọn tên sách
                {
                    string ms = cboMaSachCTPN.SelectedValue.ToString(); // Lấy mã sách khi chọn tên sách
                    string donGiaNhap = ChiTietPhieuNhapBUS.Instance.HienThiGiaThanhTheoMaSachCTPN(ms); // Truy vấn đơn giá nhập của mã sách đó
                    nudGiaThanhCTPN.Value = int.Parse(donGiaNhap); // Hiển thị giá thành
                }
            }
        }
    }
}
