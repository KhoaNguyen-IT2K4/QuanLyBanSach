using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    public class HoaDonBUS
    {
        private static HoaDonBUS instance;

        public static HoaDonBUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new HoaDonBUS();
                return instance;
            } 

            set => instance = value; 
        }

        public HoaDonBUS() { }

        public void HienThiDanhSachHoaDon(DataGridView dtgv)
        {
            dtgv.DataSource = HoaDonDAL.Instance.HienThiDanhSachHoaDon();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã hóa đơn";
            dtgv.Columns[1].HeaderText = "Mã nhân viên";
            dtgv.Columns[2].HeaderText = "Ngày lập";
            dtgv.Columns[3].HeaderText = "Mã khách hàng";
            dtgv.Columns[4].HeaderText = "Tổng tiền";
            dtgv.Columns[5].HeaderText = "Tổng số lượng";
        }

        public void DuLieuCBOMaNhanVien(ComboBox cbo)
        {
            List<Tuple<int, string>> result = HoaDonDAL.Instance.DuLieuCBOMaNhanVien();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void DuLieuCBOMaKhachHang(ComboBox cbo)
        {
            List<Tuple<int, string>> result = HoaDonDAL.Instance.DuLieuCBOMaKhachHang();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void ThemHoaDon(List<HoaDonDTO> HD, DataGridView dtgv, ComboBox cboMHD)
        {
            // Thêm hóa đơn
            bool result = HoaDonDAL.Instance.ThemHoaDon(HD);

            if (result) // Kiểm tra thêm hóa đơn thành công mới thực hiện
            {
                // Cập nhật lại dữ liệu combobox mã hóa đơn của chi tiết hóa đơn
                ChiTietHoaDonBUS.Instance.DuLieuCBOMaHoaDon(cboMHD);

                // Load lại danh sách hóa đơn
                HienThiDanhSachHoaDon(dtgv);
                MessageBox.Show("Thêm hóa đơn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaHoaDon(DataGridView dtgv, DataGridView CTHD , ComboBox cboMHD)
        {
            DialogResult TBDel = MessageBox.Show("Chi tiết hóa đơn có mã hóa đơn này cũng sẽ bị xóa.\nBạn có chắc muốn xóa hóa đơn này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

                int mahd = (int)row.Cells[0].Value;

                // Lấy số lượng bán của chi tiết hóa đơn đang xóa
                string SLBD = DataProvider.Instance.TakeData("SELECT SLban FROM ChiTietHD WHERE MaHD LIKE N'" + mahd.ToString() + "'", "SLban");

                // Lấy ra mã sách của chi tiết hóa đơn đó
                string MSD = DataProvider.Instance.TakeData("SELECT MaSach FROM ChiTietHD WHERE MaHD LIKE N'" + mahd.ToString() + "'", "MaSach");


                if (SLBD != "" && MSD != "")
                {
                    int SoLuongBanDEL = int.Parse(SLBD);
                    int MaSachCTHDdel = int.Parse(MSD);

                    // Lấy số lượng sách từ mã sách vừa lấy được
                    int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + MaSachCTHDdel.ToString() + "'", "SoLuong"));

                    // Cập nhật số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSoLuongSachXoaCTHD(UDsoluongSach, SoLuongBanDEL, MaSachCTHDdel, sh.getDGVsach());

                }

                // Xóa chi tiết hóa đơn
                ChiTietHoaDonBUS.Instance.XoaChiTietHoaDonTheoHoaDon(mahd, CTHD);

                // Xóa hóa đơn
                bool result = HoaDonDAL.Instance.XoaHoaDon(dtgv);

                if (result)
                {
                    // Cập nhật lại dữ liệu combobox mã hóa đơn của chi tiết hóa đơn
                    ChiTietHoaDonBUS.Instance.DuLieuCBOMaHoaDon(cboMHD);

                    // Load lại danh sách hóa đơn
                    HienThiDanhSachHoaDon(dtgv);
                    MessageBox.Show("Xóa hóa đơn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void XoaHoaDonTheoNhanVien(int maNhanVien ,DataGridView dtgv, DataGridView CTHD, ComboBox cboMHD)
        {
            List<string> MHD = DataProvider.Instance.TakeListData("SELECT MaHD FROM HoaDon WHERE MaNV LIKE N'" + maNhanVien + "'");

            foreach (string item in MHD)
            {
                string mahd = item.ToString();

                // Lấy số lượng bán của chi tiết hóa đơn đang xóa
                string SLBD = DataProvider.Instance.TakeData("SELECT SLban FROM ChiTietHD WHERE MaHD LIKE N'" + mahd.ToString() + "'", "SLban");

                // Lấy ra mã sách của chi tiết hóa đơn đó
                string MSD = DataProvider.Instance.TakeData("SELECT MaSach FROM ChiTietHD WHERE MaHD LIKE N'" + mahd.ToString() + "'", "MaSach");


                if (SLBD != "" && MSD != "")
                {
                    int SoLuongBanDEL = int.Parse(SLBD);
                    int MaSachCTHDdel = int.Parse(MSD);

                    // Lấy số lượng sách từ mã sách vừa lấy được
                    int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + MaSachCTHDdel.ToString() + "'", "SoLuong"));

                    // Cập nhật số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSoLuongSachXoaCTHD(UDsoluongSach, SoLuongBanDEL, MaSachCTHDdel, sh.getDGVsach());

                }

                // Xóa chi tiết hóa đơn
                ChiTietHoaDonBUS.Instance.XoaChiTietHoaDonTheoHoaDon(int.Parse(mahd), CTHD);
            }

            // Xóa hóa đơn
            bool result = HoaDonDAL.Instance.XoaHoaDonTheoNhanVien(maNhanVien);

            if (result)
            {
                // Cập nhật lại dữ liệu combobox mã hóa đơn của chi tiết hóa đơn
                ChiTietHoaDonBUS.Instance.DuLieuCBOMaHoaDon(cboMHD);


                // Load lại danh sách hóa đơn
                HienThiDanhSachHoaDon(dtgv);
            }
        }

        public void XoaHoaDonTheoKhachHang(int maKhachHang, DataGridView dtgv, DataGridView CTHD, ComboBox cboMHD)
        {
            List<string> MHD = DataProvider.Instance.TakeListData("SELECT MaHD FROM HoaDon WHERE MaKH LIKE N'" + maKhachHang + "'");

            foreach (string item in MHD)
            {
                string mahd = item.ToString();

                // Lấy số lượng bán của chi tiết hóa đơn đang xóa
                string SLBD = DataProvider.Instance.TakeData("SELECT SLban FROM ChiTietHD WHERE MaHD LIKE N'" + mahd.ToString() + "'", "SLban");

                // Lấy ra mã sách của chi tiết hóa đơn đó
                string MSD = DataProvider.Instance.TakeData("SELECT MaSach FROM ChiTietHD WHERE MaHD LIKE N'" + mahd.ToString() + "'", "MaSach");


                if (SLBD != "" && MSD != "")
                {
                    int SoLuongBanDEL = int.Parse(SLBD);
                    int MaSachCTHDdel = int.Parse(MSD);

                    // Lấy số lượng sách từ mã sách vừa lấy được
                    int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + MaSachCTHDdel.ToString() + "'", "SoLuong"));

                    // Cập nhật số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSoLuongSachXoaCTHD(UDsoluongSach, SoLuongBanDEL, MaSachCTHDdel, sh.getDGVsach());

                }

                // Xóa chi tiết hóa đơn
                ChiTietHoaDonBUS.Instance.XoaChiTietHoaDonTheoHoaDon(int.Parse(mahd), CTHD);
            }

            // Xóa hóa đơn
            bool result = HoaDonDAL.Instance.XoaHoaDonTheoKhachHang(maKhachHang);

            if (result)
            {
                // Cập nhật lại dữ liệu combobox mã hóa đơn của chi tiết hóa đơn
                ChiTietHoaDonBUS.Instance.DuLieuCBOMaHoaDon(cboMHD);

                // Load lại danh sách hóa đơn
                HienThiDanhSachHoaDon(dtgv);
            }
        }

        public void CapNhatHoaDon(List<HoaDonDTO> HD, DataGridView dtgv)
        {
            // Sửa hóa đơn
            bool result = HoaDonDAL.Instance.CapNhatHoaDon(HD, dtgv);

            if(result)
            {
                // Load lại danh sách hóa đơn
                HienThiDanhSachHoaDon(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin hóa đơn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void CapNhatHoaDonTTvaTSL(string UDtongtienHD, string UDtongsoluongHD, int maHoaDon, DataGridView dtgv)
        {
            // Sửa hóa đơn
            bool result = HoaDonDAL.Instance.CapNhatHoaDonTTvaTSL(UDtongtienHD, UDtongsoluongHD, maHoaDon);

            if (result) // Kiểm tra sửa hóa đơn thành công mới thực hiện
            {
                // Load lại danh sach hóa đơn
                HienThiDanhSachHoaDon(dtgv);
            }
        }

        public void SearchHoaDon(TextBox timkiem, DataGridView dtgv)
        {
            // Hiển thị dữ liệu cảu kết quả tìm kiếm lên datagridview
            dtgv.DataSource = HoaDonDAL.Instance.SearchHoaDon(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã hóa đơn";
            dtgv.Columns[1].HeaderText = "Mã nhân viên";
            dtgv.Columns[2].HeaderText = "Ngày lập";
            dtgv.Columns[3].HeaderText = "Mã khách hàng";
            dtgv.Columns[4].HeaderText = "Tổng tiền";
            dtgv.Columns[5].HeaderText = "Tổng số lượng";
        }

        public void XemHoaDon(PrintPreviewDialog ppd,frm_HoaDon frm,DataGridView dgvHD,string MHD)
        {
            if (MHD != "")
            {
                ppd.Document = new PrintDocument();
                ppd.Document.PrintPage += frm.pdocHoaDon_PrintPage;
                ppd.WindowState = FormWindowState.Maximized;
                ppd.PrintPreviewControl.Zoom = 1.5;
                ppd.ShowDialog();
                MHD = "";
                dgvHD.ClearSelection();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn để in!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void InHoaDon(PrintPageEventArgs e, string mhd)
        {
            // 1. Xử lý Logo an toàn
            string logoPath = Path.Combine(Application.StartupPath, "logoBookStores", "logo_BookStores.jpg");
            Image logoBS = null;
            if (File.Exists(logoPath))
            {
                logoBS = new Bitmap(logoPath);
            }

            // 2. Định nghĩa Font chữ (Dùng xong nên Dispose hoặc khai báo tập trung)
            Font fontTitle = new Font("Calibri", 40, FontStyle.Bold);
            Font fontHeader = new Font("Calibri", 16, FontStyle.Bold);
            Font fontInfo = new Font("Calibri", 20, FontStyle.Bold);

            // 3. Vẽ Tiêu đề và Logo
            e.Graphics.DrawString("HÓA ĐƠN", fontTitle, Brushes.Black, new PointF(50, 50));

            if (logoBS != null)
            {
                Rectangle sizeLogo = new Rectangle(550, 53, 60, 60);
                e.Graphics.DrawImage(logoBS, sizeLogo);
                logoBS.Dispose(); // Giải phóng ảnh sau khi đã vẽ xong vào buffer
            }

            e.Graphics.DrawString("Cửa hàng sách\n   BookStores", fontInfo, Brushes.Black, new PointF(610, 50));

            // 4. In thông tin Khách hàng và Hóa đơn (Phần thông tin chung)
            e.Graphics.DrawString("Thông tin khách hàng", fontHeader, Brushes.Red, new PointF(50, 150));

            // Lưu ý: Dùng mhd.ToString() trong SQL cần cẩn thận với SQL Injection, nhưng ở mức đồ án thì ổn
            DataProvider.Instance.PrintData("SELECT KhachHang.HoTenKH, KhachHang.DienThoai, KhachHang.DiaChi FROM HoaDon INNER JOIN KhachHang ON HoaDon.MaKH = KhachHang.MaKH WHERE HoaDon.MaHD = N'" + mhd + "'", e, "Khách Hàng", 0);
            DataProvider.Instance.PrintData("SELECT MaHD, FORMAT(CONVERT(DATE, NgayLap), 'dd/MM/yyyy'), TongSoLuong FROM HoaDon WHERE MaHD = N'" + mhd + "'", e, "Hóa Đơn", 0);

            // 5. Vẽ kẻ ngang và Tiêu đề bảng
            e.Graphics.DrawString("......................................................................", new Font("Calibri", 30, FontStyle.Regular), Brushes.Silver, new PointF(43, 270));
            e.Graphics.DrawString("Sách\t\t\tSố lượng\t\tĐơn giá\t\tThành tiền", fontHeader, Brushes.Black, new PointF(50, 340));

            // 6. In chi tiết các mặt hàng (Lấy bước nhảy để in Tổng tiền)
            // Cột giá trong ChiTietHD là GiaThanh (Khớp với SQL bạn gửi)
            string queryCT = "SELECT Sach.TenSach, ChiTietHD.SLban, ChiTietHD.GiaThanh, ChiTietHD.ThanhTien FROM ChiTietHD " +
                             "INNER JOIN HoaDon ON ChiTietHD.MaHD = HoaDon.MaHD " +
                             "INNER JOIN Sach ON ChiTietHD.MaSach = Sach.MaSach WHERE HoaDon.MaHD = N'" + mhd + "'";

            int buocnhay = DataProvider.Instance.PrintData(queryCT, e, "Hóa Đơn", 0);

            // 7. In Tổng tiền
            int yTongTien = (buocnhay > 390) ? buocnhay + 50 : 390 + 50;
            DataProvider.Instance.PrintData("SELECT TongTien FROM HoaDon WHERE MaHD = N'" + mhd + "'", e, "None", yTongTien);

            // Giải phóng Font để tránh tràn bộ nhớ GDI
            fontTitle.Dispose();
            fontHeader.Dispose();
            fontInfo.Dispose();
        }
    }
}
