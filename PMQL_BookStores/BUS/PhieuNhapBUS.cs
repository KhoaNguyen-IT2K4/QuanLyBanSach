using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    public class PhieuNhapBUS
    {
        private static PhieuNhapBUS instance;

        public static PhieuNhapBUS Instance 
        { 
            get 
            { 
                if (instance == null)
                    instance = new PhieuNhapBUS();
                return instance;
            } 

            set => instance = value; 
        }

        public PhieuNhapBUS() { }

        public void HienThiDanhSachPhieuNhap(DataGridView dtgv)
        {
            dtgv.DataSource = PhieuNhapDAL.Instance.HienThiDanhSachPhieuNhap();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgv.Columns[1].HeaderText = "Mã nhân viên";
            dtgv.Columns[2].HeaderText = "Ngày nhập";
            dtgv.Columns[3].HeaderText = "Mã nhà cung cấp";
            dtgv.Columns[4].HeaderText = "Tổng tiền";
            dtgv.Columns[5].HeaderText = "Tổng số lượng";
        }

        public void DuLieuCBOMaNhanVien(ComboBox cbo)
        {
            List<Tuple<int, string>> result = PhieuNhapDAL.Instance.DuLieuCBOMaNhanVien();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void DuLieuCBOMaNhaCungCap(ComboBox cbo)
        {
            List<Tuple<int, string>> result = PhieuNhapDAL.Instance.DuLieuCBOMaNhaCungCap();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void ThemPhieuNhap(List<PhieuNhapDTO> PN, ComboBox mpnCTPN, DataGridView dtgv)
        {
            // Thêm phiếu nhập
            bool result = PhieuNhapDAL.Instance.ThemPhieuNhap(PN);

            if (result) // Kiểm tra thêm phiếu nhập thành công mới thực hiện
            {
                // Cập nhật lại combobox mã phiếu nhập của chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.DuLieuCBOMaPhieuNhap(mpnCTPN);

                // Load lại danh sách phiếu nhập
                HienThiDanhSachPhieuNhap(dtgv);
                MessageBox.Show("Thêm phiếu nhập thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaPhieuNhap(DataGridView dtgv, DataGridView CTPN, ComboBox mpnCTPN)
        {
            DialogResult TBDel = MessageBox.Show("Chi tiết phiếu nhập có mã phiếu nhập này cũng sẽ bị xóa.\nBạn có chắc muốn xóa phiếu nhập này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

                int mapn = (int)row.Cells[0].Value;

                // Lấy số lượng nhập của chi tiết phiếu nhập đang xóa
                string SLND = DataProvider.Instance.TakeData("SELECT SLnhap FROM ChiTietPN WHERE MaPN LIKE N'" + mapn.ToString() + "'", "SLnhap");

                // Lấy mã sách của chi tiết phiếu nhập đang xóa
                string MaSachCTPNdel = DataProvider.Instance.TakeData("SELECT MaSach FROM ChiTietPN WHERE MaPN LIKE N'" + mapn.ToString() + "'", "MaSach");

                if (SLND != "" && MaSachCTPNdel != "")
                {
                    int SoLuongNhapDel = int.Parse(SLND);

                    // Lấy sô lượng sách từ mã sách vừa lấy
                    int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "'", "SoLuong"));

                    if (UDsoluongSach <= SoLuongNhapDel) // Nếu số lượng sách nhỏ hơn số lượng nhập của chi tiết phiếu nhập đang xóa
                    {
                        UDsoluongSach = 0; // số lượng sách bằng 0
                    }
                    else // Nếu số lượng sách lớn hơn số lượng nhập của chi tiết phiếu nhập đang xóa
                    {
                        UDsoluongSach -= SoLuongNhapDel; // số lượng sách trừ số lượng nhập của chi tiết phiếu nhập đang xóa
                    }

                    decimal UDgiathanhSach = 0;

                    // Lấy số lượng chi tiết phiếu nhập mã sách đó
                    string CheckcountCTPN = DataProvider.Instance.TakeData("SELECT COUNT(*) as N'Count' FROM ChiTietPN WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "' GROUP BY MaSach", "Count");

                    // Kiểm tra có tồn tại chi tiết phiếu nhập với mã sách đó có tồn tại không
                    if (CheckcountCTPN != "")
                    {
                        int countCTPN = int.Parse(CheckcountCTPN);

                        if (countCTPN > 1) // Nếu số lượng chi tiết phiếu nhập có mã sách đó lớn hơn 1 thì thực hiện
                        {
                            // Lấy giá thành của chi tiết phiếu nhập với điều kiện phiếu nhập mới nhất
                            string giaThanhSach = DataProvider.Instance.TakeData("SELECT TOP(1) GiaThanh FROM ChiTietPN WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "' ORDER BY MaPN DESC", "GiaThanh");

                            if (giaThanhSach != "") // Nếu có chi tiết phiếu nhập với mã sách đó
                            {
                                UDgiathanhSach = decimal.Parse(giaThanhSach); // giá thành sách bằng giá thành
                            }
                        }
                    }

                    // Cập nhật đơn giá nhập và số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSachDGNvaSLXoaPhieuNhap(UDgiathanhSach, UDsoluongSach, MaSachCTPNdel.ToString(), sh.getDGVsach());
                }

                // Xóa chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.XoaChiTietPNTheoPhieuNhap(mapn, mpnCTPN, CTPN);

                // Xóa phiếu nhập
                bool result = PhieuNhapDAL.Instance.XoaPhieuNhap(dtgv);

                if (result) // Kiểm tra xóa phiếu nhập thành công mới thực hiện
                {
                    // Cập nhật lại dữ liệu trong combobox mã phiếu nhập của chi tiết phiếu nhập
                    ChiTietPhieuNhapBUS.Instance.DuLieuCBOMaPhieuNhap(mpnCTPN);

                    // Load lại danh sách phiếu nhập
                    HienThiDanhSachPhieuNhap(dtgv);
                    MessageBox.Show("Xóa phiếu nhập thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void XoaPhieuNhapTheoNhanVien(int maNhanVien, DataGridView dtgv, DataGridView CTPN, ComboBox mpnCTPN)
        {
            List<string> MPN = DataProvider.Instance.TakeListData("SELECT MaPN FROM PhieuNhap WHERE MaNV LIKE N'" + maNhanVien + "'");

            foreach (string item in MPN)
            {
                string mapn = item.ToString();

                // Lấy số lượng nhập của chi tiết phiếu nhập đang xóa
                string SLND = DataProvider.Instance.TakeData("SELECT SLnhap FROM ChiTietPN WHERE MaPN LIKE N'" + mapn.ToString() + "'", "SLnhap");

                // Lấy mã sách của chi tiết phiếu nhập đang xóa
                string MaSachCTPNdel = DataProvider.Instance.TakeData("SELECT MaSach FROM ChiTietPN WHERE MaPN LIKE N'" + mapn.ToString() + "'", "MaSach");

                if (SLND != "" && MaSachCTPNdel != "")
                {
                    int SoLuongNhapDel = int.Parse(SLND);

                    // Lấy sô lượng sách từ mã sách vừa lấy
                    int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "'", "SoLuong"));

                    if (UDsoluongSach <= SoLuongNhapDel) // Nếu số lượng sách nhỏ hơn số lượng nhập của chi tiết phiếu nhập đang xóa
                    {
                        UDsoluongSach = 0; // số lượng sách bằng 0
                    }
                    else // Nếu số lượng sách lớn hơn số lượng nhập của chi tiết phiếu nhập đang xóa
                    {
                        UDsoluongSach -= SoLuongNhapDel; // số lượng sách trừ số lượng nhập của chi tiết phiếu nhập đang xóa
                    }

                    decimal UDgiathanhSach = 0;

                    // Lấy số lượng chi tiết phiếu nhập mã sách đó
                    string CheckcountCTPN = DataProvider.Instance.TakeData("SELECT COUNT(*) as N'Count' FROM ChiTietPN WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "' GROUP BY MaSach", "Count");

                    // Kiểm tra có tồn tại chi tiết phiếu nhập với mã sách đó có tồn tại không
                    if (CheckcountCTPN != "")
                    {
                        int countCTPN = int.Parse(CheckcountCTPN);

                        if (countCTPN > 1) // Nếu số lượng chi tiết phiếu nhập có mã sách đó lớn hơn 1 thì thực hiện
                        {
                            // Lấy giá thành của chi tiết phiếu nhập với điều kiện phiếu nhập mới nhất
                            string giaThanhSach = DataProvider.Instance.TakeData("SELECT TOP(1) GiaThanh FROM ChiTietPN WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "' ORDER BY MaPN DESC", "GiaThanh");

                            if (giaThanhSach != "") // Nếu có chi tiết phiếu nhập với mã sách đó
                            {
                                UDgiathanhSach = decimal.Parse(giaThanhSach); // giá thành sách bằng giá thành
                            }
                        }
                    }

                    // Cập nhật đơn giá nhập và số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSachDGNvaSLXoaPhieuNhap(UDgiathanhSach, UDsoluongSach, MaSachCTPNdel.ToString(), sh.getDGVsach());
                }

                // Xóa chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.XoaChiTietPNTheoPhieuNhap(int.Parse(mapn), mpnCTPN, CTPN);
            }

            // Xóa phiếu nhập
            bool result = PhieuNhapDAL.Instance.XoaPhieuNhapTheoNhanVien(maNhanVien);

            if (result) // Kiểm tra xóa phiếu nhập thành công mới thực hiện
            {
                // Cập nhật lại dữ liệu trong combobox mã phiếu nhập của chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.DuLieuCBOMaPhieuNhap(mpnCTPN);

                // Load lại danh sách phiếu nhập
                HienThiDanhSachPhieuNhap(dtgv);
            }
        }

        public void XoaPhieuNhapTheoNhaCungCap(int maNhaCungCap, DataGridView dtgv, DataGridView CTPN, ComboBox mpnCTPN)
        {
            List<string> MPN = DataProvider.Instance.TakeListData("SELECT MaPN FROM PhieuNhap WHERE MaNCC LIKE N'" + maNhaCungCap + "'");

            foreach (string item in MPN)
            {
                string mapn = item.ToString();

                // Lấy số lượng nhập của chi tiết phiếu nhập đang xóa
                string SLND = DataProvider.Instance.TakeData("SELECT SLnhap FROM ChiTietPN WHERE MaPN LIKE N'" + mapn.ToString() + "'", "SLnhap");

                // Lấy mã sách của chi tiết phiếu nhập đang xóa
                string MaSachCTPNdel = DataProvider.Instance.TakeData("SELECT MaSach FROM ChiTietPN WHERE MaPN LIKE N'" + mapn.ToString() + "'", "MaSach");

                if (SLND != "" && MaSachCTPNdel != "")
                {
                    int SoLuongNhapDel = int.Parse(SLND);

                    // Lấy sô lượng sách từ mã sách vừa lấy
                    int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "'", "SoLuong"));

                    if (UDsoluongSach <= SoLuongNhapDel) // Nếu số lượng sách nhỏ hơn số lượng nhập của chi tiết phiếu nhập đang xóa
                    {
                        UDsoluongSach = 0; // số lượng sách bằng 0
                    }
                    else // Nếu số lượng sách lớn hơn số lượng nhập của chi tiết phiếu nhập đang xóa
                    {
                        UDsoluongSach -= SoLuongNhapDel; // số lượng sách trừ số lượng nhập của chi tiết phiếu nhập đang xóa
                    }

                    decimal UDgiathanhSach = 0;

                    // Lấy số lượng chi tiết phiếu nhập mã sách đó
                    string CheckcountCTPN = DataProvider.Instance.TakeData("SELECT COUNT(*) as N'Count' FROM ChiTietPN WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "' GROUP BY MaSach", "Count");

                    // Kiểm tra có tồn tại chi tiết phiếu nhập với mã sách đó có tồn tại không
                    if (CheckcountCTPN != "")
                    {
                        int countCTPN = int.Parse(CheckcountCTPN);

                        if (countCTPN > 1) // Nếu số lượng chi tiết phiếu nhập có mã sách đó lớn hơn 1 thì thực hiện
                        {
                            // Lấy giá thành của chi tiết phiếu nhập với điều kiện phiếu nhập mới nhất
                            string giaThanhSach = DataProvider.Instance.TakeData("SELECT TOP(1) GiaThanh FROM ChiTietPN WHERE MaSach LIKE N'" + MaSachCTPNdel.ToString() + "' ORDER BY MaPN DESC", "GiaThanh");

                            if (giaThanhSach != "") // Nếu có chi tiết phiếu nhập với mã sách đó
                            {
                                UDgiathanhSach = decimal.Parse(giaThanhSach); // giá thành sách bằng giá thành
                            }
                        }
                    }

                    // Cập nhật đơn giá nhập và số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSachDGNvaSLXoaPhieuNhap(UDgiathanhSach, UDsoluongSach, MaSachCTPNdel.ToString(), sh.getDGVsach());
                }

                // Xóa chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.XoaChiTietPNTheoPhieuNhap(int.Parse(mapn), mpnCTPN, CTPN);
            }

            // Xóa phiếu nhập
            bool result = PhieuNhapDAL.Instance.XoaPhieuNhapTheoNhaCungCap(maNhaCungCap);

            if (result) // Kiểm tra xóa phiếu nhập thành công mới thực hiện
            {
                // Cập nhật lại dữ liệu trong combobox mã phiếu nhập của chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.DuLieuCBOMaPhieuNhap(mpnCTPN);

                // Load lại danh sách phiếu nhập
                HienThiDanhSachPhieuNhap(dtgv);
            }
        }

        public void CapNhatPhieuNhap(List<PhieuNhapDTO> PN, DataGridView dtgv)
        {
            // Sửa phiếu nhập
            bool result = PhieuNhapDAL.Instance.CapNhatPhieuNhap(PN, dtgv);

            if (result) // Kiểm tra sửa phiếu nhập thành công mới thực hiện
            {
                // Load lại danh sách phiếu nhập
                HienThiDanhSachPhieuNhap(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin phiếu nhập thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void CapNhatPhieuNhapTTvaTSL(string UDtongtienPN, string UDtongsoluongPN, int maPhieuNhap, DataGridView dtgv)
        {
            // Sửa phiếu nhập
            bool result = PhieuNhapDAL.Instance.CapNhatPhieuNhapTTvaTSL(UDtongtienPN, UDtongsoluongPN, maPhieuNhap);

            if (result) // Kiểm tra sửa phiếu nhập thành công mới thực hiện
            {
                // Load lại danh sách phiếu nhập
                HienThiDanhSachPhieuNhap(dtgv);
            }
        }

        public void SearchPhieuNhap(TextBox timkiem, DataGridView dtgv)
        {
            // Hiển thị dữ liệu cẩu kết quả tìm kiếm lên datagridview
            dtgv.DataSource = PhieuNhapDAL.Instance.SearchPhieuNhap(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgv.Columns[1].HeaderText = "Mã nhân viên";
            dtgv.Columns[2].HeaderText = "Ngày nhập";
            dtgv.Columns[3].HeaderText = "Mã nhà cung cấp";
            dtgv.Columns[4].HeaderText = "Tổng tiền";
            dtgv.Columns[5].HeaderText = "Tổng số lượng";
        }

        public void XemPhieuNhap(PrintPreviewDialog ppd,frm_PhieuNhap frm,string mpn,DataGridView dgvPN)
        {
            if (mpn != "")
            {
                ppd.Document = new PrintDocument();
                ppd.Document.PrintPage += frm.pdocPhieuNhap_PrintPage;
                ppd.WindowState = FormWindowState.Maximized;
                ppd.PrintPreviewControl.Zoom = 1.5;
                ppd.ShowDialog();
                mpn = "";
                dgvPN.ClearSelection();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn phiếu nhập để in!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void InPhieuNhap(PrintPageEventArgs e,string mpn)
        {
            Image logoBS = new Bitmap(Application.StartupPath + "\\logoBookStores\\logo_BookStores.jpg");
            Rectangle sizeLogo = new Rectangle(50, 53, 60, 60);

            e.Graphics.DrawString("Phiếu Nhập", new Font("Calibri", 40, FontStyle.Bold), Brushes.Black, new PointF(300, 160));
            e.Graphics.DrawImage(logoBS, sizeLogo);
            e.Graphics.DrawString("Cửa hàng sách\n   BookStores", new Font("Calibri", 20, FontStyle.Bold), Brushes.Black, new PointF(110, 50));
            e.Graphics.DrawString("Thông tin nhà cung cấp", new Font("Calibri", 16, FontStyle.Bold), Brushes.Red, new PointF(50, 270));
            DataProvider.Instance.PrintData("SELECT NhaCungCap.TenNCC,NhaCungCap.DienThoai,NhaCungCap.DiaChi FROM PhieuNhap inner join NhaCungCap on PhieuNhap.MaNCC = NhaCungCap.MaNCC WHERE PhieuNhap.MaPN LIKE N'" + mpn.ToString() + "'", e, "Nhà Cung Cấp", 0);
            DataProvider.Instance.PrintData("SELECT MaPN,FORMAT(CONVERT(DATE,NgayNhap), 'dd/MM/yyyy'),TongSoLuong FROM PhieuNhap WHERE MaPN LIKE N'" + mpn.ToString() + "'", e, "Phiếu Nhập", 0);
            e.Graphics.DrawString("......................................................................", new Font("Calibri", 30, FontStyle.Regular), Brushes.Silver, new PointF(43, 380)); // tiêu đề chấm
            e.Graphics.DrawString("Sách\t\t\tSố lượng\t\tĐơn giá\t\tThành tiền", new Font("Calibri", 16, FontStyle.Bold), Brushes.Black, new PointF(50, 450)); // tiêu đề mục height lớn hơn tiêu đề chấm 70

            int buocnhay = DataProvider.Instance.PrintData("select Sach.TenSach,ChiTietPN.SLnhap,ChiTietPN.GiaThanh,ChiTietPN.ThanhTien from ChiTietPN inner join PhieuNhap on ChiTietPN.MaPN = PhieuNhap.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE PhieuNhap.MaPN LIKE N'" + mpn.ToString() + "'", e, "Phiếu Nhập", 0);
            buocnhay += 50; // tiêu đề tổng lớn hơn height nội dung tiêu đề 50

            if(buocnhay != 50)
            {
                DataProvider.Instance.PrintData("select TongTien from PhieuNhap WHERE PhieuNhap.MaPN LIKE N'" + mpn.ToString() + "'", e, "None", buocnhay);
            }
            else
            {
                DataProvider.Instance.PrintData("select TongTien from PhieuNhap WHERE PhieuNhap.MaPN LIKE N'" + mpn.ToString() + "'", e, "None", 500);
            }
        }
    }
}
