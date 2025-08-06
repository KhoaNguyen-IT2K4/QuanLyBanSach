using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using System.Text.RegularExpressions;
using System.Reflection.Emit;

namespace PMQL_BookStores.BUS
{
    internal class SachBUS
    {
        private static SachBUS instance;

        public static SachBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new SachBUS();
                return instance;
            }

            set => instance = value;
        }

        // Khởi tạo một hộp thoại để chọn file hình ảnh
        OpenFileDialog openFDL = new OpenFileDialog(); // tạo đối tượng openfiledialog
        string locationPresent = ""; // biến toàn cục lấy đường dẫn của hình ảnh

        public SachBUS(){}

        public void HienThiDanhSachSach(DataGridView dtgv)
        {
            // Hiển thị dữ liệu lên datagridview của sách
            dtgv.DataSource = SachDAL.Instance.HienThiDanhSachSach();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã sách";
            dtgv.Columns[1].HeaderText = "Tên sách";
            dtgv.Columns[2].HeaderText = "Tác giả";
            dtgv.Columns[3].HeaderText = "Mã loại sách";
            dtgv.Columns[4].HeaderText = "Mã NXB";
            dtgv.Columns[5].HeaderText = "Đơn giá nhập";
            dtgv.Columns[6].HeaderText = "Đơn giá bán";
            dtgv.Columns[7].HeaderText = "Số trang";
            dtgv.Columns[8].HeaderText = "Trọng lượng";
            dtgv.Columns[9].HeaderText = "Tên file hình";
            dtgv.Columns[10].HeaderText = "Số lượng";
        }

        public void DuLieuCBOMaLoaiSach(ComboBox cbo)
        {
            // Hiển thị dữ liệu lên combobox mã loại sách của sách
            List<Tuple<int,string>> result = SachDAL.Instance.DuLieuCBOMaLoaiSach();
            
            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void DuLieuCBOMaNXB(ComboBox cbo)
        {
            // Hiển thị dữ liệu lên combobox mã nhà xuất bản của sách
            List<Tuple<int, string>> result = SachDAL.Instance.DuLieuCBOMaNXB();
            
            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void ThemSach(List<SachDTO> S,DataGridView dtgv)
        {
            // Thêm sách
            bool result = SachDAL.Instance.ThemSach(S);

            if(result) // Kiểm tra thêm sách thành công mới thực hiện
            {
                // Load lại danh sách sách
                HienThiDanhSachSach(dtgv);
                MessageBox.Show("Thêm sách thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool XoaSachTheoTheLoaiSach(DataGridView dtgv,PictureBox pic,int maLoaiSach) // Hàm kiểm tra đã xóa sách hay chưa
        {
            bool checkdelsuscess = false;

            string masach = DataProvider.Instance.TakeData("SELECT MaSach FROM Sach WHERE MaLoaiSach LIKE N'" + maLoaiSach + "'", "MaSach");

            // Kiểm tra nếu biến toàn cục mã sách khác rỗng thì mới thực hiện
            if (masach == "")
            {
                checkdelsuscess = true;
            }
            else
            {
                DialogResult TBDel = MessageBox.Show("Chi tiết phiếu nhập,chi tiết hóa đơn của sách có thể loại sách này cũng sẽ bị xóa.\nBạn có chắc muốn xóa sách có thể loại sách này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (TBDel == DialogResult.Yes)
                {
                    // Tạo đối tượng phiếu nhập
                    frm_PhieuNhap pn = new frm_PhieuNhap();

                    // Tạo đối tượng hóa đơn
                    frm_HoaDon hd = new frm_HoaDon();

                    // Xóa chi tiết phiếu nhập
                    ChiTietPhieuNhapBUS.Instance.XoaChiTietPNTheoSach(int.Parse(masach.ToString()), pn.dgvPN(), pn.cboMPNCTPN(), pn.dgvCTPN());

                    // Xóa chi tiết hóa đơn
                    ChiTietHoaDonBUS.Instance.XoaChiTietHoaDonTheoSach(int.Parse(masach.ToString()), hd.dgvCTHD(), hd.dgvHD());

                    // Xóa hinh ảnh của sách
                    XoaHinhAnhTheoMaSach(pic, masach);

                    // Xóa sách
                    bool result = SachDAL.Instance.XoaSachTheoMaSach(masach);

                    if (result) // Kiểm tra xóa sách thành công mới thực hiện
                    {
                        // Load lại danh sách sách
                        HienThiDanhSachSach(dtgv);
                    }

                    checkdelsuscess = true;
                }
            }
            return checkdelsuscess;
        }

        public bool XoaSachTheoNhaXuatBan(DataGridView dtgv, PictureBox pic, int maNhaXuatBan) // Hàm kiểm tra đã xóa sách hay chưa
        {
            bool checkdelsuscess = false;

            string masach = DataProvider.Instance.TakeData("SELECT MaSach FROM Sach WHERE MaNXB LIKE N'" + maNhaXuatBan + "'", "MaSach");

            // Kiểm tra nếu biến toàn cục mã sách khác rỗng thì mới thực hiện
            if (masach == "")
            {
                checkdelsuscess = true;
            }
            else
            {
                DialogResult TBDel = MessageBox.Show("Chi tiết phiếu nhập,chi tiết hóa đơn của sách có nhà xuất bản này cũng sẽ bị xóa.\nBạn có chắc muốn xóa sách có nhà xuất bản này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (TBDel == DialogResult.Yes)
                {
                    // Tạo đối tượng phiếu nhập
                    frm_PhieuNhap pn = new frm_PhieuNhap();

                    // Tạo đối tượng hóa đơn
                    frm_HoaDon hd = new frm_HoaDon();

                    // Xóa chi tiết phiếu nhập
                    ChiTietPhieuNhapBUS.Instance.XoaChiTietPNTheoSach(int.Parse(masach.ToString()), pn.dgvPN(), pn.cboMPNCTPN(), pn.dgvCTPN());

                    // Xóa chi tiết hóa đơn
                    ChiTietHoaDonBUS.Instance.XoaChiTietHoaDonTheoSach(int.Parse(masach.ToString()), hd.dgvCTHD(), hd.dgvHD());

                    // Xóa hinh ảnh của sách
                    XoaHinhAnhTheoMaSach(pic, masach);

                    // Xóa sách
                    bool result = SachDAL.Instance.XoaSachTheoMaSach(masach);

                    if (result) // Kiểm tra xóa sách thành công mới thực hiện
                    {
                        // Load lại danh sách sách
                        HienThiDanhSachSach(dtgv);
                    }

                    checkdelsuscess = true;
                }
            }
            return checkdelsuscess;
        }

        public void DelSach(DataGridView dtgv, PictureBox anhSach, Button hinhAnh)
        {
            DialogResult TBDel = MessageBox.Show("Chi tiết phiếu nhập,chi tiết hóa đơn có mã sách này cũng sẽ bị xóa.\nBạn có chắc muốn xóa sách này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

                int maSach = (int)row.Cells[0].Value;

                // Tạo đối tượng phiếu nhập
                frm_PhieuNhap pn = new frm_PhieuNhap();

                // Tạo đối tượng hóa đơn
                frm_HoaDon hd = new frm_HoaDon();

                // Xóa chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.XoaChiTietPNTheoSach(maSach, pn.dgvPN(), pn.cboMPNCTPN(), pn.dgvCTPN());

                // Xóa chi tiết hóa đơn
                ChiTietHoaDonBUS.Instance.XoaChiTietHoaDonTheoSach(maSach, hd.dgvCTHD(), hd.dgvHD());

                XoaHinhAnh(anhSach, hinhAnh);

                // Xóa sách
                bool result = SachDAL.Instance.DelSach(dtgv);

                if (result) // Kiểm tra xóa sách thành công mới thực hiện
                {
                    // Load lại danh sách sách
                    HienThiDanhSachSach(dtgv);
                    MessageBox.Show("Xóa sách thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void CapNhatSach(List<SachDTO> S, DataGridView dtgv) // Hàm xử lý khi nhấn cập nhật của sách
        {
            
            // Sửa sách
            bool result = SachDAL.Instance.CapNhatSach(S,dtgv);

            if (result) // Kiểm tra sửa sách thành công mới thực hiện
            {
                // Load lại danh sách sách
                HienThiDanhSachSach(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin sách thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void CapNhatSachDGNvaSLThemCTPN(decimal UDgiathanhSach, int UDsoluongSach, List<ChiTietPhieuNhapDTO> CTPN, DataGridView sach)
        {
            bool result = SachDAL.Instance.CapNhatSachDGNvaSLThemCTPN(UDgiathanhSach, UDsoluongSach, CTPN);

            if (result) // Kiểm tra cấp nhật sách thành công mới thực hiện
            {
                // Load lại danh sách sách
                HienThiDanhSachSach(sach);
            }
        }

        public void CapNhatSachDGNvaSLXoaPhieuNhap(decimal UDgiathanhSach, int UDsoluongSach, string maSach, DataGridView sach)
        {
            bool result = SachDAL.Instance.CapNhatSachDGNvaSLXoaPhieuNhap(UDgiathanhSach, UDsoluongSach, maSach);

            if (result) // kiểm tra cập nhật sách thành công mới thực hiện
            {
                // Load lại danh sách sách
                HienThiDanhSachSach(sach);
            }
        }

        public void CapNhatSachDGNvaSL(decimal UDgiathanhSach, int UDsoluongSach, DataGridView dtgv, DataGridView sach)
        {
            bool result = SachDAL.Instance.CapNhatSachDGNvaSL(UDgiathanhSach, UDsoluongSach, dtgv);

            if (result) // kiểm tra cập nhật sách thành công mới thực hiện
            {
                // Load lại danh sách sách
                HienThiDanhSachSach(sach);
            }
        }

        public void CapNhatSoLuongSachThemCTHD(int UDsoluongSach, int soLuongBan, int maSach, DataGridView sach)
        {
            bool result = SachDAL.Instance.CapNhatSoLuongSachThemCTHD(UDsoluongSach, soLuongBan, maSach);

            if (result) // Kiểm tra cập nhật sách tahfnh công mới thực hiện
            {
                // Load lại danh sách sách
                HienThiDanhSachSach(sach);
            }
        }

        public void CapNhatSoLuongSachXoaCTHD(int UDsoluongSach, int soLuongBan, int maSach, DataGridView sach)
        {
            bool result = SachDAL.Instance.CapNhatSoLuongSachXoaCTHD(UDsoluongSach, soLuongBan, maSach);

            if (result) // Kiểm tra cập nhật sách thành công mới thực hiện
            {
                // Load lại danh sách sách
                HienThiDanhSachSach(sach);
            }
        }

        public void CapNhatSoLuongSach(int UDsoluongSach, DataGridView dtgv, DataGridView sach)
        {
            bool result = SachDAL.Instance.CapNhatSoLuongSach(UDsoluongSach, dtgv);

            if (result) // Kiểm tra cập nhật sách thành công mới thực hiện
            {
                // Load lại danh sách sách
                HienThiDanhSachSach(sach);
            }
        }

        public void SearchSach(TextBox timkiem, DataGridView dtgv) // Hàm xử lý tìm kiếm của sách
        {
            // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
            dtgv.DataSource = SachDAL.Instance.SearchSach(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã sách";
            dtgv.Columns[1].HeaderText = "Tên sách";
            dtgv.Columns[2].HeaderText = "Tác giả";
            dtgv.Columns[3].HeaderText = "Mã loại sách";
            dtgv.Columns[4].HeaderText = "Mã NXB";
            dtgv.Columns[5].HeaderText = "Đơn giá nhập";
            dtgv.Columns[6].HeaderText = "Đơn giá bán";
            dtgv.Columns[7].HeaderText = "Số trang";
            dtgv.Columns[8].HeaderText = "Trọng lượng";
            dtgv.Columns[9].HeaderText = "Tên file hình";
            dtgv.Columns[10].HeaderText = "Số lượng";
        }

        public string ThemHinhAnh(Button hinhAnh)
        {
            // Tạo biến lưu tên hình ảnh
            string hinhanh = hinhAnh.Text;

            // Nếu không có hình ảnh thì giá trị bằng X
            if (hinhAnh.Text == "Choose Image")
            {
                hinhanh = "X";
            }
            else
            {
                // Kiểm tra người dùng đã chọn ảnh
                if (locationPresent.ToString() != "")
                {
                    // Tạo đường dẫn mới để copy hình ảnh
                    string locationNew = Application.StartupPath + "\\imgs\\" + Path.GetFileName(locationPresent);

                    // Kiểm tra nếu hình ảnh chưa tồn tại mới thực hiện copy hình hình ành
                    if (!File.Exists(locationNew))
                    {
                        // Thực hiện thêm hình ảnh
                        File.Copy(locationPresent, locationNew);
                    }

                    locationPresent = "";
                }
            }

            return hinhanh;
        }

        public void XoaHinhAnh(PictureBox anhSach, Button hinhAnh)
        {
            // Bẫy lỗi xóa hình ảnh
            try
            {
                // Kiểm tra hình ảnh tồn tại mới thực hiện
                if (File.Exists(Application.StartupPath + "\\imgs\\" + hinhAnh.Text))
                {
                    // Lấy ra số dòng sử dụng hình ảnh vào biến
                    string number = DataProvider.Instance.TakeData("SELECT COUNT(HinhAnh) as N'SL' FROM Sach WHERE HinhAnh LIKE N'" + hinhAnh.Text + "'", "SL");

                    // Nếu chỉ có 1 dòng sử dụng hình ảnh thì thực hiện xóa
                    if (number.ToString() == "1")
                    {
                        anhSach.Image.Dispose();
                        anhSach.Image = null;
                        File.Delete(Application.StartupPath + "\\imgs\\" + hinhAnh.Text);
                        hinhAnh.Text = "Choose Image";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hình ảnh đang được sử dụng! hoặc không tồn tại! => " + ex.Message, "Xóa hình ảnh thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XoaHinhAnhTheoMaSach(PictureBox anhSach, string maSach)
        {
            // Bẫy lỗi xóa hình ảnh
            try
            {
                // Lấy tên hình ảnh cần xóa
                string hinhAnh = DataProvider.Instance.TakeData("SELECT HinhAnh FROM Sach WHERE MaSach LIKE N'" + maSach.ToString() + "'", "HinhAnh");

                // Kiểm tra hình ảnh tồn tại mới thực hiện
                if (File.Exists(Application.StartupPath + "\\imgs\\" + hinhAnh.ToString()))
                {
                    // Lấy ra số dòng sử dụng hình ảnh vào biến
                    string number = DataProvider.Instance.TakeData("SELECT COUNT(HinhAnh) as N'SL' FROM Sach WHERE HinhAnh LIKE N'" + hinhAnh.ToString() + "'", "SL");

                    // Nếu chỉ có 1 dòng sử dụng hình ảnh thì thực hiện xóa
                    if (number.ToString() == "1")
                    {
                        if(anhSach.Image != null)
                        {
                            anhSach.Image.Dispose();
                            anhSach.Image = null;
                            File.Delete(Application.StartupPath + "\\imgs\\" + hinhAnh.ToString());
                        }
                        else
                        {
                            File.Delete(Application.StartupPath + "\\imgs\\" + hinhAnh.ToString());
                        }    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hình ảnh đang được sử dụng! hoặc không tồn tại! => " + ex.Message, "Xóa hình ảnh thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string CapNhatHinhAnh(DataGridView dtgv,Button hinhAnh)
        {
            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maSach = (int)row.Cells[0].Value;

            // Lưu tên hình ảnh vào biến
            string hinhanh = hinhAnh.Text;

            // Nếu không có hình ảnh thì giá trị bằng X
            if (hinhAnh.Text == "Choose Image")
            {
                hinhanh = "X";
            }
            else
            {
                // Kiểm tra người dùng chọn hình ảnh
                if (locationPresent.ToString() != "")
                {
                    // Bẫy lỗi xóa hình ảnh củ
                    try
                    {
                        // Lấy tên hình ảnh củ
                        string ImageOld = DataProvider.Instance.TakeData("SELECT HinhAnh FROM Sach WHERE MaSach LIKE N'" + maSach.ToString() + "'", "HinhAnh");

                        // Kiểm tra đường dẫn hình ảnh có tồn tại không, tồn tại mới thực hiện
                        if (File.Exists(Application.StartupPath + "\\imgs\\" + ImageOld.ToString()))
                        {
                            // Lấy số dòng dữ liệu sử dụng hình ảnh
                            string number = DataProvider.Instance.TakeData("SELECT COUNT(HinhAnh) as N'SL' FROM Sach WHERE HinhAnh LIKE N'" + ImageOld.ToString() + "'", "SL");

                            // Nếu số dòng dữ liệu dử dụng hình ảnh đó là 1 thì thực hiện xóa
                            if (number.ToString() == "1")
                            {
                                File.Delete(Application.StartupPath + "\\imgs\\" + ImageOld.ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hình ảnh đang được sử dụng! hoặc không tồn tại! => " + ex.Message, "Xóa hình ảnh thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Tạo đường dẫn để copy hình ảnh
                    string locationNew = Application.StartupPath + "\\imgs\\" + Path.GetFileName(locationPresent);

                    // Kiểm tra hình ảnh đã tồn tại chưa, chư tồn tại mới thực hiện copy hình ảnh
                    if (!File.Exists(locationNew))
                    {
                        // Thực hiện thêm hình ảnh
                        File.Copy(locationPresent, locationNew);
                    }

                    locationPresent = "";
                }
            }

            return hinhanh;
        }

        public void HienThiHinhAnh(PictureBox anhSach, Button hinhAnh) // hàm xử lý khi nhấn vào nút Choose Image để thêm hình ảnh
        {
            // Định dạng chỉ lấy file hình ảnh
            openFDL.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";

            // Hiển thị hộp thoại và xác nhận người dùng đã chọn file hình ảnh
            if (openFDL.ShowDialog() == DialogResult.OK)
            {
                // bẩy lỗi thêm hình ảnh
                try
                {
                    // Kiểm tra nếu picturebox có hình ảnh mới thực hiện
                    if (anhSach.Image != null)
                    {
                        anhSach.Image.Dispose(); // Xóa hình ảnh khỏi bộ nhớ picturebox
                        anhSach.Image = null; // đặt picturebox về mặc định
                    }

                    // Lấy đường dẫn của file hình ảnh đã chọn
                    locationPresent = openFDL.FileName;

                    // đưa tên file hình ảnh vào text button
                    hinhAnh.Text = Path.GetFileName(locationPresent);
                    // show hình ảnh lên picturebox
                    anhSach.Image = Image.FromFile(locationPresent);

                }
                catch (Exception ex)
                {
                    // Thông báo hiển thị hình ảnh thất bại
                    MessageBox.Show("Lỗi hiển thị hình ảnh => Chi tiết: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
