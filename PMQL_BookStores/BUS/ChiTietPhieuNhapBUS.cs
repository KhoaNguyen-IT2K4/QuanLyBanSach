using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    public class ChiTietPhieuNhapBUS
    {
        private static ChiTietPhieuNhapBUS instance;

        public static ChiTietPhieuNhapBUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new ChiTietPhieuNhapBUS();
                return instance;
            } 

            set => instance = value; 
        }

        public ChiTietPhieuNhapBUS() { }

        public void HienThiDanhSachChiTietPhieuNhap(DataGridView dtgv)
        {
            dtgv.DataSource = ChiTietPhieuNhapDAL.Instance.HienThiDanhSachChiTietPhieuNhap();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgv.Columns[1].HeaderText = "Mã sách";
            dtgv.Columns[2].HeaderText = "Số lượng nhập";
            dtgv.Columns[3].HeaderText = "Giá thành";
        }

        public void DuLieuCBOMaPhieuNhap(ComboBox cbo)
        {
            List<Tuple<int, string>> result = ChiTietPhieuNhapDAL.Instance.DuLieuCBOMaPhieuNhap();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void DuLieuCBOMaSach(ComboBox cbo)
        {
            List<Tuple<int, string>> result = ChiTietPhieuNhapDAL.Instance.DuLieuCBOMaSach();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void ThemChiTietPN(List<ChiTietPhieuNhapDTO> CTPN, DataGridView dtgv, DataGridView PN)
        {
            bool ketqua = ChiTietPhieuNhapDAL.Instance.ThemChiTietPN(CTPN);

            if (ketqua) // Kiểm tra thêm chi tiết phiếu nhập thành công mới thực hiện
            {
                int maPhieuNhap = CTPN[0].MaPhieuNhap;
                int maSach = CTPN[0].MaSach;
                int soLuongNhap = CTPN[0].SoLuongNhap;

                // Lấy tổng tiền và tổng số lượng của chi tiết phiếu nhập
                string UDtongtienPN = DataProvider.Instance.TakeData("SELECT SUM(ThanhTien) as N'Tổng tiền' FROM ChiTietPN WHERE MaPN LIKE N'" + maPhieuNhap + "' GROUP BY MaPN", "Tổng tiền");
                string UDtongsoluongPN = DataProvider.Instance.TakeData("SELECT SUM(SLnhap) as N'Tổng số lượng' FROM ChiTietPN WHERE MaPN LIKE N'" + maPhieuNhap + "' GROUP BY MaPN", "Tổng số lượng");

                // Cập nhật tổng tiền và tổng số lượng của phiếu nhập
                PhieuNhapBUS.Instance.CapNhatPhieuNhapTTvaTSL(UDtongtienPN, UDtongsoluongPN, maPhieuNhap, PN);

                // Lấy số lượng của sách và giá thành của chi tiết phiếu nhập với điều kiện phiếu nhập mới nhất
                string giaThanhSach = DataProvider.Instance.TakeData("SELECT TOP(1) GiaThanh FROM ChiTietPN WHERE MaSach LIKE N'" + maSach + "' ORDER BY MaPN DESC", "GiaThanh");
                decimal UDgiathanhSach = 0;
                int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + maSach + "'", "SoLuong"));

                if (giaThanhSach != "") // Nếu có chi tiết phiếu nhập với mã sách đó
                {
                    UDgiathanhSach = decimal.Parse(giaThanhSach); // giá thành sách bằng giá thành
                }

                if (UDsoluongSach == 0) // Nếu số lượng sách hiện tại là 0
                {
                    UDsoluongSach = soLuongNhap; // Số lượng sách sẽ bằng số lượng nhập
                }
                else // Nếu số lượng sách hiện tại khác 0
                {
                    UDsoluongSach += soLuongNhap; // Số lượng sách sẽ cộng số lượng nhập
                }

                // Cập nhật đơn giá nhập và số lượng của sách
                frm_Sach sh = new frm_Sach();
                SachBUS.Instance.CapNhatSachDGNvaSLThemCTPN(UDgiathanhSach, UDsoluongSach, CTPN, sh.getDGVsach());

                // Load lại danh sách chi tiết phiếu nhập
                HienThiDanhSachChiTietPhieuNhap(dtgv);
                MessageBox.Show("Thêm chi tiết phiếu nhập thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Chi tiết phiếu nhập có mã phiếu nhập và mã sách này đã tồn tại!", "Thêm không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XoaChiTietPN(DataGridView dtgv, DataGridView PN)
        {
            DialogResult TBDel = MessageBox.Show("Bạn có chắc muốn xóa chi tiết phiếu nhập này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

                int mpnCTPN = (int)row.Cells[0].Value;

                int msCTPN = (int)row.Cells[1].Value;

                // Lấy sô lượng sách hiện tại của sách và số lượng nhập của chi tiết phiếu nhập đang xóa
                int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + msCTPN.ToString() + "'", "SoLuong"));
                int SLnhapHT = int.Parse(DataProvider.Instance.TakeData("SELECT SLnhap FROM ChiTietPN WHERE MaSach LIKE N'" + msCTPN.ToString() + "' AND MaPN LIKE N'" + mpnCTPN.ToString() + "'", "SLnhap"));

                if (UDsoluongSach <= SLnhapHT) // Nếu số lượng sách nhỏ hơn số lượng nhập của chi tiết phiếu nhập đang xóa
                {
                    UDsoluongSach = 0; // số lượng sách bằng 0
                }
                else // Nếu số lượng sách lớn hơn số lượng nhập của chi tiết phiếu nhập đang xóa
                {
                    UDsoluongSach -= SLnhapHT; // số lượng sách trừ số lượng nhập của chi tiết phiếu nhập đang xóa
                }

                // Xóa chi tiết phiếu nhập
                bool result = ChiTietPhieuNhapDAL.Instance.XoaChiTietPN(dtgv);

                if (result)
                {
                    // lấy tổng tiền và tổng số lượng của chi tiết phiếu nhập
                    string UDtongtienPN = DataProvider.Instance.TakeData("SELECT SUM(ThanhTien) as N'Tổng tiền' FROM ChiTietPN WHERE MaPN LIKE N'" + mpnCTPN.ToString() + "' GROUP BY MaPN", "Tổng tiền");
                    string UDtongsoluongPN = DataProvider.Instance.TakeData("SELECT SUM(SLnhap) as N'Tổng số lượng' FROM ChiTietPN WHERE MaPN LIKE N'" + mpnCTPN.ToString() + "' GROUP BY MaPN", "Tổng số lượng");

                    // Nếu kết quả trả về là rỗng thì tổng tiền và tổng số lượng bằng 0
                    if (UDtongtienPN.ToString() == "" && UDtongsoluongPN.ToString() == "")
                    {
                        UDtongtienPN = UDtongsoluongPN = "0";
                    }

                    // Cập nhật tổng tiền và tổng số lượng của phiếu nhập
                    PhieuNhapBUS.Instance.CapNhatPhieuNhapTTvaTSL(UDtongtienPN, UDtongsoluongPN, mpnCTPN, PN);

                    // Lấy giá thành của chi tiết phiếu nhập với điều kiện phiếu nhập mới nhất
                    string giaThanhSach = DataProvider.Instance.TakeData("SELECT TOP(1) GiaThanh FROM ChiTietPN WHERE MaSach LIKE N'" + msCTPN.ToString() + "' ORDER BY MaPN DESC", "GiaThanh");
                    decimal UDgiathanhSach = 0;

                    if (giaThanhSach != "") // Nếu có chi tiết phiếu nhập với mã sách đó
                    {
                        UDgiathanhSach = decimal.Parse(giaThanhSach); // giá thành sách bằng giá thành
                    }

                    // Cập nhật đơn giá nhập và số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSachDGNvaSL(UDgiathanhSach, UDsoluongSach, dtgv, sh.getDGVsach());

                    // Load lại danh sách chi tiết phiếu nhập
                    HienThiDanhSachChiTietPhieuNhap(dtgv);
                    MessageBox.Show("Xóa chi tiết phiếu nhập thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void XoaChiTietPNTheoSach(int maSach, DataGridView PN, ComboBox CBOmpnCTPN, DataGridView dtgv)
        {
            List<string> MPN = DataProvider.Instance.TakeListData("SELECT MaPN FROM ChiTietPN Where MaSach LIKE N'" + maSach + "'");

            // Xóa chi tiết phiếu nhập
            bool result = ChiTietPhieuNhapDAL.Instance.XoaChiTietPNTheoSach(maSach);

            if (result)
            {
                foreach (string item in MPN)
                {
                    string mpnCTPN = item.ToString();

                    // lấy tổng tiền và tổng số lượng của chi tiết phiếu nhập
                    string UDtongtienPN = DataProvider.Instance.TakeData("SELECT SUM(ThanhTien) as N'Tổng tiền' FROM ChiTietPN WHERE MaPN LIKE N'" + mpnCTPN.ToString() + "' GROUP BY MaPN", "Tổng tiền");
                    string UDtongsoluongPN = DataProvider.Instance.TakeData("SELECT SUM(SLnhap) as N'Tổng số lượng' FROM ChiTietPN WHERE MaPN LIKE N'" + mpnCTPN.ToString() + "' GROUP BY MaPN", "Tổng số lượng");

                    // Nếu kết quả trả về là rỗng thì tổng tiền và tổng số lượng bằng 0
                    if (UDtongtienPN.ToString() == "" && UDtongsoluongPN.ToString() == "")
                    {
                        UDtongtienPN = UDtongsoluongPN = "0";
                    }

                    // Cập nhật tổng tiền và tổng số lượng của phiếu nhập
                    PhieuNhapBUS.Instance.CapNhatPhieuNhapTTvaTSL(UDtongtienPN, UDtongsoluongPN, int.Parse(mpnCTPN), PN);

                }

                // Cập nhật lại dữ liệu trong combobox mã phiếu nhập của chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.DuLieuCBOMaPhieuNhap(CBOmpnCTPN);

                // Load lại danh sách chi tiết phiếu nhập
                HienThiDanhSachChiTietPhieuNhap(dtgv);
            }
        }

        public void XoaChiTietPNTheoPhieuNhap(int maPhieuNhap, ComboBox CBOmpnCTPN, DataGridView dtgv)
        {
            // Xóa chi tiết phiếu nhập
            bool result = ChiTietPhieuNhapDAL.Instance.XoaChiTietPNTheoPhieuNhap(maPhieuNhap);

            if (result)
            {
                // Cập nhật lại dữ liệu trong combobox mã phiếu nhập của chi tiết phiếu nhập
                ChiTietPhieuNhapBUS.Instance.DuLieuCBOMaPhieuNhap(CBOmpnCTPN);

                // Load lại danh sách chi tiết phiếu nhập
                HienThiDanhSachChiTietPhieuNhap(dtgv);
            }
        }

        public void CapNhatChiTietPN(List<ChiTietPhieuNhapDTO> CTPN, DataGridView dtgv, DataGridView PN) 
        {
            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int mpnCTPN = (int)row.Cells[0].Value;

            int msCTPN = (int)row.Cells[1].Value;

            int soLuongNhap = CTPN[0].SoLuongNhap;

            // Lấy sô lượng sách hiện tại của sách và số lượng nhập củ của chi tiết phiếu nhập
            int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + msCTPN.ToString() + "'", "SoLuong"));
            int SLnhapOLD = int.Parse(DataProvider.Instance.TakeData("SELECT SLnhap FROM ChiTietPN WHERE MaSach LIKE N'" + msCTPN.ToString() + "' AND MaPN LIKE N'" + mpnCTPN.ToString() + "'", "SLnhap"));

            if (soLuongNhap < SLnhapOLD) // Nếu số lượng củ lớn hơn số lượng mới
            {
                UDsoluongSach -= (SLnhapOLD - soLuongNhap); // lấy số lượng củ trừ số lượng mới sau đó số lượng sách trừ cho kết quả 
            }
            else // Nếu số lượng mới lớn hơn số lượng củ
            {
                UDsoluongSach += (soLuongNhap - SLnhapOLD); // lấy số lượng mới trừ số lượng củ sau đó số lượng sách cộng cho kết quả 
            }


            // Sửa chi tiết phiếu nhập
            bool suscess = ChiTietPhieuNhapDAL.Instance.CapNhatChiTietPN(CTPN, dtgv);

            if (suscess) // Kiểm tra sửa chi tiết phiếu nhập thành công mới thực hiện
            {
                // Lấy tổng tiền vào tổng số lượng của chi tiết phiếu nhập
                string UDtongtienPN = DataProvider.Instance.TakeData("SELECT SUM(ThanhTien) as N'Tổng tiền' FROM ChiTietPN WHERE MaPN LIKE N'" + mpnCTPN.ToString() + "' GROUP BY MaPN", "Tổng tiền");
                string UDtongsoluongPN = DataProvider.Instance.TakeData("SELECT SUM(SLnhap) as N'Tổng số lượng' FROM ChiTietPN WHERE MaPN LIKE N'" + mpnCTPN.ToString() + "' GROUP BY MaPN", "Tổng số lượng");

                // Cập nhật tổng tiền và tổng số lượng của phiếu nhập
                PhieuNhapBUS.Instance.CapNhatPhieuNhapTTvaTSL(UDtongtienPN, UDtongsoluongPN, mpnCTPN, PN);

                // Lấy giá thành của chi tiết phiếu nhập điều kiện phiếu nhập mới nhất
                string giaThanhSach = DataProvider.Instance.TakeData("SELECT TOP(1) GiaThanh FROM ChiTietPN WHERE MaSach LIKE N'" + msCTPN.ToString() + "' ORDER BY MaPN DESC", "GiaThanh");
                decimal UDgiathanhSach = 0;

                if (giaThanhSach != "") // Nếu có chi tiết phiếu nhập với mã sách đó
                {
                    UDgiathanhSach = decimal.Parse(giaThanhSach); // giá thành sách bằng giá thành
                }

                // Cập nhật đơn giá nhập và số lượng của sách
                frm_Sach sh = new frm_Sach();
                SachBUS.Instance.CapNhatSachDGNvaSL(UDgiathanhSach, UDsoluongSach, dtgv, sh.getDGVsach());

                // Load lại danh sách chi tiết phiếu nhập
                HienThiDanhSachChiTietPhieuNhap(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin chi tiết phiếu nhập thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Chi tiết phiếu nhập có mã phiếu nhập và mã sách này đã tồn tại!", "Chỉnh sửa không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchCchiTietPN(TextBox timkiem, DataGridView dtgv)
        {
            // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
            dtgv.DataSource = ChiTietPhieuNhapDAL.Instance.SearchCchiTietPN(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgv.Columns[1].HeaderText = "Mã sách";
            dtgv.Columns[2].HeaderText = "Số lượng nhập";
            dtgv.Columns[3].HeaderText = "Giá thành";
        }

        public string HienThiGiaThanhTheoMaSachCTPN(string ms)
        {
            string result = ChiTietPhieuNhapDAL.Instance.HienThiGiaThanhTheoMaSachCTPN(ms);
            return result;
        }
    }
}
