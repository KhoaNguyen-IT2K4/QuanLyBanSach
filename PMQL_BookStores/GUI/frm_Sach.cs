using PMQL_BookStores.BUS;
using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.GUI
{
    public partial class frm_Sach : Form
    {
        string masach = "", matls = "", manxb = "";

        private frm_Admin _admin; // Tạo thuộc tính tham chiếu đến form admin
        public frm_Sach()
        {
            InitializeComponent();
        }

        public frm_Sach(frm_Admin admin) // Hàm khởi tạo có tham số để tham chiếu đến form admin và thay đổi text label tiêu đề của admin
        {
            InitializeComponent();
            _admin = admin;
        }

        private void frm_Sach_Load(object sender, EventArgs e)
        {
            SachBUS.Instance.HienThiDanhSachSach(dtgvListSach);
            SachBUS.Instance.DuLieuCBOMaLoaiSach(cboMaLoaiSach);
            SachBUS.Instance.DuLieuCBOMaNXB(cboMaNXB);

            TheLoaiSachBUS.Instance.HienThiDanhSachTheLoaiSach(dgvAddTLS);

            NhaXuatBanBUS.Instance.HienThiDanhSachNhaXuatBan(dgvAddNXB);
        }

        private void tcSach_SelectedIndexChanged(object sender, EventArgs e) // Thiết lập khi thay đổi tabpage thì text label tiêu đề của admin thay đổi
        {
            if (tcSach.SelectedIndex == 0)
            {
                dtgvListSach.ClearSelection();
                _admin.DoiTieuDeAdmin(tcSach.SelectedTab.Text);
            }
            else if (tcSach.SelectedIndex == 1)
            {
                dgvAddTLS.ClearSelection();
                _admin.DoiTieuDeAdmin(tcSach.SelectedTab.Text);
            }
            else if (tcSach.SelectedIndex == 2)
            {
                dgvAddNXB.ClearSelection();
                _admin.DoiTieuDeAdmin(tcSach.SelectedTab.Text);
            }
        }

        private void frm_Sach_Shown(object sender, EventArgs e) // Thiết lập khi form hiển thị thì bỏ chọn tất cả các dòng trong datagridview của sách
        {
            dtgvListSach.ClearSelection();
        }




        // =============================================================================== Sách ================================================================================= //
        private void picAddSach_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn thêm của sách
        {
            // Kiểm tra khác rông mới thực hiện
            if (!string.IsNullOrEmpty(txtTenSach.Text) && !string.IsNullOrEmpty(txtTacGia.Text) && !string.IsNullOrEmpty(cboMaLoaiSach.SelectedValue.ToString())
                && !string.IsNullOrEmpty(cboMaNXB.SelectedValue.ToString()) && !string.IsNullOrEmpty(txtDonGiaNhap.Text) && !string.IsNullOrEmpty(txtDonGiaBan.Text)
                && !string.IsNullOrEmpty(txtSoLuong.Text) && nudTrongLuong.Value != (decimal)0.0 && nudSoTrang.Value != 0)
            {
                // Thêm hình ảnh
                string hinhAnh = SachBUS.Instance.ThemHinhAnh(btnHinhAnh);

                List<SachDTO> sach = new List<SachDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                SachDTO S = new SachDTO(0, txtTenSach.Text, txtTacGia.Text, int.Parse(cboMaLoaiSach.SelectedValue.ToString()),int.Parse(cboMaNXB.SelectedValue.ToString()),decimal.Parse(txtDonGiaNhap.Text),decimal.Parse(txtDonGiaNhap.Text),(int)nudSoTrang.Value, (decimal)nudTrongLuong.Value, hinhAnh.ToString(),int.Parse(txtSoLuong.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                sach.Add(S); // Thêm vào list

                SachBUS.Instance.ThemSach(sach, dtgvListSach); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin.\n(hình ảnh để trống nếu không có ảnh)!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelSach_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu biến toàn cục mã sách khác rỗng thì mới thực hiện
            if (dtgvListSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách cần xóa!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //SachBUS.Instance.XoaHinhAnh(picAnhSach,btnHinhAnh);
                SachBUS.Instance.DelSach(dtgvListSach, picAnhSach, btnHinhAnh);
            }
        }

        private void picUDSach_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật của sách
        {
            if (dtgvListSach.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sách cần chỉnh sửa!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khác rông mới thực hiện
                if (!string.IsNullOrEmpty(txtTenSach.Text) && !string.IsNullOrEmpty(txtTacGia.Text) && !string.IsNullOrEmpty(cboMaLoaiSach.SelectedValue.ToString())
                    && !string.IsNullOrEmpty(cboMaNXB.SelectedValue.ToString()) && !string.IsNullOrEmpty(txtDonGiaNhap.Text) && !string.IsNullOrEmpty(txtDonGiaBan.Text)
                    && !string.IsNullOrEmpty(txtSoLuong.Text) && nudTrongLuong.Value != (decimal)0.0 && nudSoTrang.Value != 0)
                {
                    // Cập nhật hình ảnh
                    string hinhAnh = SachBUS.Instance.CapNhatHinhAnh(dtgvListSach, btnHinhAnh);

                    List<SachDTO> sach = new List<SachDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    SachDTO S = new SachDTO(0, txtTenSach.Text, txtTacGia.Text, int.Parse(cboMaLoaiSach.SelectedValue.ToString()), int.Parse(cboMaNXB.SelectedValue.ToString()), decimal.Parse(txtDonGiaNhap.Text), decimal.Parse(txtDonGiaNhap.Text), (int)nudSoTrang.Value, (decimal)nudTrongLuong.Value, hinhAnh.ToString(), int.Parse(txtSoLuong.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                    sach.Add(S); // Thêm vào list

                    SachBUS.Instance.CapNhatSach(sach, dtgvListSach); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin.\n(hình ảnh để trống nếu không có ảnh)!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearSach_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp của sách
        {
            // Đặt tất cả các control về mặc định
            txtTenSach.Text = txtTacGia.Text = txtSearchSach.Text = "";
            txtDonGiaNhap.Text = txtDonGiaBan.Text = txtSoLuong.Text = "0";
            cboMaLoaiSach.SelectedIndex = cboMaNXB.SelectedIndex = 0;
            btnHinhAnh.Text = "Choose Image";
            nudTrongLuong.Value = (decimal)0.0;
            nudSoTrang.Value = 0;
            picAnhSach.Image = null;

            dtgvListSach.ClearSelection(); // bỏ chọn tất cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchSach_Click(object sender, EventArgs e) // Hàm xử lý tìm kiếm của sách
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchSach.Text))
            {
                // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
                SachBUS.Instance.SearchSach(txtSearchSach, dtgvListSach);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                SachBUS.Instance.HienThiDanhSachSach(dtgvListSach);
            }
        }

        private void txtSearchSach_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm của sách
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                picSearchSach_Click(sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                SachBUS.Instance.HienThiDanhSachSach(dtgvListSach);
            }
        }

        private void cboMaLoaiSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void cboMaNXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }

        private void dtgvListSach_CellClick(object sender, DataGridViewCellEventArgs e) // Lấy giá trị trong datagridview hiển thị lên tất cả các control của sách
        {
            int i;
            i = dtgvListSach.CurrentRow.Index;
            masach = dtgvListSach.Rows[i].Cells[0].Value.ToString();
            txtTenSach.Text = dtgvListSach.Rows[i].Cells[1].Value.ToString();
            txtTacGia.Text = dtgvListSach.Rows[i].Cells[2].Value.ToString();
            cboMaLoaiSach.SelectedValue = dtgvListSach.Rows[i].Cells[3].Value;
            cboMaNXB.SelectedValue = dtgvListSach.Rows[i].Cells[4].Value;
            txtDonGiaNhap.Text = dtgvListSach.Rows[i].Cells[5].Value.ToString();
            txtDonGiaBan.Text = dtgvListSach.Rows[i].Cells[6].Value.ToString();
            nudSoTrang.Value = (int)dtgvListSach.Rows[i].Cells[7].Value;
            nudTrongLuong.Value = (decimal)dtgvListSach.Rows[i].Cells[8].Value;
            if (dtgvListSach.Rows[i].Cells[9].Value.ToString() != "X")
            {
                btnHinhAnh.Text = dtgvListSach.Rows[i].Cells[9].Value.ToString();
            }
            else
            {
                btnHinhAnh.Text = "Choose Image";
            }
            txtSoLuong.Text = dtgvListSach.Rows[i].Cells[10].Value.ToString();

            if (File.Exists(Application.StartupPath + "\\imgs\\" + btnHinhAnh.Text)) // Kiểm tra hình ảnh có tồn tại không
            {
                picAnhSach.Image = new Bitmap(Application.StartupPath + "\\imgs\\" + btnHinhAnh.Text); // nếu tồn tại thì ddauw hình ảnh lên pictrurebox
            }
            else
            {
                picAnhSach.Image = null; // nếu không tồn tại thì không hiển thị hình ảnh
            }
        }

        private void btnHinhAnh_Click(object sender, EventArgs e) // hàm xử lý khi nhấn vào nút Choose Image để thêm hình ảnh
        {
            //SachBUS SB = new SachBUS(dtgvListSach, dgvAddTLS, dgvAddNXB, txtTenSach, txtTacGia, cboMaLoaiSach, cboMaNXB, txtDonGiaNhap, txtDonGiaBan, nudSoTrang, nudTrongLuong, btnHinhAnh, txtSoLuong, picAnhSach, txtSearchSach, masach);
            //SB.HienThiHinhAnh();

            SachBUS.Instance.HienThiHinhAnh(picAnhSach, btnHinhAnh);
        }

        public DataGridView getDGVsach() // Lấy datagridview của sách để tham chiếu thực thi ở form khác
        {
            return dtgvListSach;
        }




        // =============================================================================== Thể Loại Sách ================================================================================= //
        private void picAddTLS_Click(object sender, EventArgs e) // hàm xử lý khi nhấn thêm cảu thể loại sách
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtTenLoaiSach.Text))
            {
                List<TheLoaiSachDTO> theloaisach = new List<TheLoaiSachDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                TheLoaiSachDTO TLS = new TheLoaiSachDTO(0, txtTenLoaiSach.Text); // Khởi tạo đối tượng NhaCungCapDTO

                theloaisach.Add(TLS); // Thêm vào list

                TheLoaiSachBUS.Instance.ThemTheLoaiSach(theloaisach, dgvAddTLS, cboMaLoaiSach); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picDelTLS_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn xóa của thể loại sách
        {
            // Kiểm tra biến toàn cục mã thể loại sách khác rỗng mới thực hiện
            if (dgvAddTLS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn thể loại sách cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TheLoaiSachBUS.Instance.XoaTheLoaiSach(dgvAddTLS, dtgvListSach, picAnhSach, cboMaLoaiSach);
            }
        }

        private void picUDTLS_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật của thể loại sách
        {
            // Kiểm tra biến toàn cục mã thể loại sách khác rỗng mới thực hiện
            if (dgvAddTLS.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn thể loại sách cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khác rỗng mới thực hiện
                if (!string.IsNullOrEmpty(txtTenLoaiSach.Text))
                {
                    List<TheLoaiSachDTO> theloaisach = new List<TheLoaiSachDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    TheLoaiSachDTO TLS = new TheLoaiSachDTO(0, txtTenLoaiSach.Text); // Khởi tạo đối tượng NhaCungCapDTO

                    theloaisach.Add(TLS); // Thêm vào list

                    TheLoaiSachBUS.Instance.CapNhatTheLoaiSach(theloaisach, dgvAddTLS, cboMaLoaiSach); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearTLS_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dep của thể loại sách
        {
            // Đặt tất cả các control về mặc định
            txtTenLoaiSach.Text = txtSearchTLS.Text = "";
            dgvAddTLS.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchTLS_Click(object sender, EventArgs e) // Hàm xử lý tìm kiếm của thể loại sách
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchTLS.Text))
            {
                // Hiển thị dữ liệu của kết qur tìm kiếm lên datagridview
                TheLoaiSachBUS.Instance.SearchTheLoaiSach(txtSearchTLS, dgvAddTLS);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                TheLoaiSachBUS.Instance.HienThiDanhSachTheLoaiSach(dgvAddTLS);
            }
        }

        private void txtSearchTLS_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm của thể loại sách
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                picSearchTLS_Click((object)sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                TheLoaiSachBUS.Instance.HienThiDanhSachTheLoaiSach(dgvAddTLS);
            }
        }
        private void dgvAddTLS_CellClick(object sender, DataGridViewCellEventArgs e) // Lấy giá trị trong datagridview lên tất cả các control của thể loại sách
        {
            int i = dgvAddTLS.CurrentRow.Index;
            matls = dgvAddTLS.Rows[i].Cells[0].Value.ToString();
            txtTenLoaiSach.Text = dgvAddTLS.Rows[i].Cells[1].Value.ToString();
        }





        // =============================================================================== Nhà Xuất Bản ================================================================================= //
        private void picAddNXB_Click(object sender, EventArgs e) // hàm xử lý khi nhấn thêm của nhà xuất bản
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtTenNXB.Text) && !string.IsNullOrEmpty(txtDiaChiNXB.Text))
            {
                List<NhaXuatBanDTO> nhaxuatban = new List<NhaXuatBanDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                NhaXuatBanDTO NXB = new NhaXuatBanDTO(0, txtTenNXB.Text, txtDiaChiNXB.Text); // Khởi tạo đối tượng NhaCungCapDTO

                nhaxuatban.Add(NXB); // Thêm vào list

                NhaXuatBanBUS.Instance.ThemNhaXuatBan(nhaxuatban, dgvAddNXB, cboMaNXB); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void picDelNXB_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn xóa của nhà xuất bản
        {
            // Kiểm tra biến toàn cục mã nhà xuất bản khác rỗng mới thực hiện
            if (dgvAddNXB.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhà xuất bản cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //NhaXuatBanBUS.Instance.XoaNhaXuatBan(dgvAddNXB, dtgvListSach, picAnhSach, cboMaNXB);
                NhaXuatBanBUS.Instance.XoaNhaXuatBan(dgvAddNXB, dtgvListSach, picAnhSach, cboMaNXB);
            }
        }

        private void picUDNXB_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật của nhà xuát bản
        {
            // Kiểm tra biến toàn cục mã nhà xuất bản khác rỗng mới thực hiện
            if (dgvAddNXB.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhà xuất bản cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra khasc rỗng mới thực hiện
                if (!string.IsNullOrEmpty(txtTenNXB.Text) && !string.IsNullOrEmpty(txtDiaChiNXB.Text))
                {
                    List<NhaXuatBanDTO> nhaxuatban = new List<NhaXuatBanDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    NhaXuatBanDTO NXB = new NhaXuatBanDTO(0, txtTenNXB.Text, txtDiaChiNXB.Text); // Khởi tạo đối tượng NhaCungCapDTO

                    nhaxuatban.Add(NXB); // Thêm vào list

                    NhaXuatBanBUS.Instance.CapNhatNhaXuatBan(nhaxuatban, dgvAddNXB, cboMaNXB); // Gửi lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picClearNXB_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp của nhà xuất bản
        {
            // Đặt tất cả các control về mặc định
            txtTenNXB.Text = txtDiaChiNXB.Text = txtSearchNXB.Text = "";
            dgvAddNXB.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSearchNXB_Click(object sender, EventArgs e) // hàm xử lý tìm kiếm của nhà xuất bản
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchNXB.Text))
            {
                // hHieern thị dữ liệu của kết qur tìm kiếm lên datagridview
                NhaXuatBanBUS.Instance.SearchNhaXuatBan(txtSearchNXB, dgvAddNXB);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                NhaXuatBanBUS.Instance.HienThiDanhSachNhaXuatBan(dgvAddNXB);
            }
        }

        private void txtSearchNXB_KeyPress(object sender, KeyPressEventArgs e) // Hàm xư lý khi nhấn enter trong ô tìm kiếm của nhà xuất bản
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                picSearchNXB_Click(sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                NhaXuatBanBUS.Instance.HienThiDanhSachNhaXuatBan(dgvAddNXB);
            }
        }
        private void dgvAddNXB_CellClick(object sender, DataGridViewCellEventArgs e) // Lấy giá trị trong datagridview hiển thị lên tất cả các control của nhà xuất bản
        {
            int i = dgvAddNXB.CurrentRow.Index;
            manxb = dgvAddNXB.Rows[i].Cells[0].Value.ToString();
            txtTenNXB.Text = dgvAddNXB.Rows[i].Cells[1].Value.ToString();
            txtDiaChiNXB.Text = dgvAddNXB.Rows[i].Cells[2].Value.ToString();
        }
    }
}
