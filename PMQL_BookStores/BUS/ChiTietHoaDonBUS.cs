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
    public class ChiTietHoaDonBUS
    {
        private static ChiTietHoaDonBUS instance;

        public static ChiTietHoaDonBUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonBUS();
                return instance;
            } 

            set => instance = value; 
        }

        public ChiTietHoaDonBUS() { }

        public void HienThiDanhSachChiTietHoaDon(DataGridView dtgv)
        {
            dtgv.DataSource = ChiTietHoaDonDAL.Instance.HienThiDanhSachChiTietHoaDon();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã hóa đơn";
            dtgv.Columns[1].HeaderText = "Mã sách";
            dtgv.Columns[2].HeaderText = "Số lượng bán";
            dtgv.Columns[3].HeaderText = "Giá thành";
        }

        public void DuLieuCBOMaHoaDon(ComboBox cbo)
        {
            List<Tuple<int, string>> result = ChiTietHoaDonDAL.Instance.DuLieuCBOMaHoaDon();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void DuLieuCBOMaSach(ComboBox cbo)
        {
            List<Tuple<int, string>> result = ChiTietHoaDonDAL.Instance.DuLieuCBOMaSach();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void ThemChiTietHoaDon(List<ChiTietHoaDonDTO> CTHD, DataGridView dtgv, DataGridView HD)
        {
            int maHD = CTHD[0].MaHoaDon;

            int maSach = CTHD[0].MaSach;

            int soLuongBan = CTHD[0].SoLuongBan;

            // Lấy số lượng sách hiện tại
            int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + maSach + "'", "SoLuong"));

            if (UDsoluongSach >= soLuongBan)
            {
                // Thêm chi tiết hóa đơn và lấy kết quả
                bool suscess = ChiTietHoaDonDAL.Instance.ThemChiTietHoaDon(CTHD);

                if (suscess)
                {
                    // Lấy tổng tiền và tổng số lượng của chi tiết hóa đơn vào biến
                    string UDtongtienHD = DataProvider.Instance.TakeData("SELECT SUM(ThanhTien) as N'Tổng tiền' FROM ChiTietHD WHERE MaHD LIKE N'" + maHD + "' GROUP BY MaHD", "Tổng tiền");
                    string UDtongsoluongHD = DataProvider.Instance.TakeData("SELECT SUM(SLban) as N'Tổng số lượng' FROM ChiTietHD WHERE MaHD LIKE N'" + maHD + "' GROUP BY MaHD", "Tổng số lượng");

                    // Cập nhật lại tổng tiền và tổng số lượng của hóa đơn
                    HoaDonBUS.Instance.CapNhatHoaDonTTvaTSL(UDtongtienHD, UDtongsoluongHD, maHD, HD);


                    // Cập nhật số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSoLuongSachThemCTHD(UDsoluongSach, soLuongBan, maSach, sh.getDGVsach());

                    // load lại danh sách chi tiết hóa đơn
                    HienThiDanhSachChiTietHoaDon(dtgv);
                    MessageBox.Show("Thêm chi tiết hóa đơn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chi tiết hóa đơn có mã hóa đơn và mã sách này đã tồn tại!", "Thêm không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Số lượng sách trong kho không đáp ứng được nhu cầu của bạn!", "Thêm không thành công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void XoaChiTietHoaDon(DataGridView dtgv, DataGridView HD)
        {
            DialogResult TBDel = MessageBox.Show("Bạn có chắc muốn xóa chi tiết hóa đơn này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                // Xóa chi tiết hóa đơn
                bool result = ChiTietHoaDonDAL.Instance.XoaChiTietHoaDon(dtgv);

                if (result) // Kiểm tra xóa chi tiết hóa đơn thành công mới thực hiện
                {
                    DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

                    int mhdCTHD = (int)row.Cells[0].Value;

                    int msCTHD = (int)row.Cells[1].Value;

                    int soLuongBan = (int)row.Cells[2].Value;

                    // Lấy tổng tiền và tổng số lượng của chi tiết hóa đơn vào biến
                    string UDtongtienHD = DataProvider.Instance.TakeData("SELECT SUM(ThanhTien) as N'Tổng tiền' FROM ChiTietHD WHERE MaHD LIKE N'" + mhdCTHD.ToString() + "' GROUP BY MaHD", "Tổng tiền");
                    string UDtongsoluongHD = DataProvider.Instance.TakeData("SELECT SUM(SLban) as N'Tổng số lượng' FROM ChiTietHD WHERE MaHD LIKE N'" + mhdCTHD.ToString() + "' GROUP BY MaHD", "Tổng số lượng");

                    // Kiểm tra nếu kết quả là rỗng thì tổng tiền và tổng số lượng bằng 0
                    if (UDtongtienHD.ToString() == "" && UDtongsoluongHD.ToString() == "")
                    {
                        UDtongtienHD = UDtongsoluongHD = "0";
                    }

                    // Cập nhật tổng tiền và tổng số lượng của hóa đơn
                    HoaDonBUS.Instance.CapNhatHoaDonTTvaTSL(UDtongtienHD, UDtongsoluongHD, mhdCTHD, HD);

                    // Lấy số lượng sách hiện tại
                    int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + msCTHD.ToString() + "'", "SoLuong"));

                    // Cập nhật số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSoLuongSachXoaCTHD(UDsoluongSach, soLuongBan, msCTHD, sh.getDGVsach());

                    // load lại danh sách chi tiết hóa đơn
                    HienThiDanhSachChiTietHoaDon(dtgv);
                    MessageBox.Show("Xóa chi tiết hóa đơn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void XoaChiTietHoaDonTheoSach(int maSach,DataGridView dtgv, DataGridView HD)
        {
            List<string> MHD = DataProvider.Instance.TakeListData("SELECT MaHD FROM ChiTietHD Where MaSach LIKE N'" + maSach + "'");

            // Xóa chi tiết hóa đơn
            bool result = ChiTietHoaDonDAL.Instance.XoaChiTietHoaDonTheoSach(maSach);

            if (result) // Kiểm tra xóa chi tiết hóa đơn thành công mới thực hiện
            {
                foreach (string item in MHD)
                {
                    string mhdCTHD = item.ToString();

                    // Lấy tổng tiền và tổng số lượng của chi tiết hóa đơn vào biến
                    string UDtongtienHD = DataProvider.Instance.TakeData("SELECT SUM(ThanhTien) as N'Tổng tiền' FROM ChiTietHD WHERE MaHD LIKE N'" + mhdCTHD.ToString() + "' GROUP BY MaHD", "Tổng tiền");
                    string UDtongsoluongHD = DataProvider.Instance.TakeData("SELECT SUM(SLban) as N'Tổng số lượng' FROM ChiTietHD WHERE MaHD LIKE N'" + mhdCTHD.ToString() + "' GROUP BY MaHD", "Tổng số lượng");

                    // Kiểm tra nếu kết quả là rỗng thì tổng tiền và tổng số lượng bằng 0
                    if (UDtongtienHD.ToString() == "" && UDtongsoluongHD.ToString() == "")
                    {
                        UDtongtienHD = UDtongsoluongHD = "0";
                    }

                    // Cập nhật tổng tiền và tổng số lượng của hóa đơn
                    HoaDonBUS.Instance.CapNhatHoaDonTTvaTSL(UDtongtienHD, UDtongsoluongHD, int.Parse(mhdCTHD.ToString()), HD);

                }

                // Load lại danh sách chi tiết hóa đơn
                HienThiDanhSachChiTietHoaDon(dtgv);
            }
        }

        public void XoaChiTietHoaDonTheoHoaDon(int maHoaDon, DataGridView dtgv)
        {
            // Xóa chi tiết hóa đơn
            bool result = ChiTietHoaDonDAL.Instance.XoaChiTietHoaDonTheoHoaDon(maHoaDon);

            if (result) // Kiểm tra xóa chi tiết hóa đơn thành công mới thực hiện
            {
                // Load lại danh sách chi tiết hóa đơn
                HienThiDanhSachChiTietHoaDon(dtgv);
            }
        }

        public void CapNhatChiTietHoaDon(List<ChiTietHoaDonDTO> CTHD, DataGridView dtgv, DataGridView HD) 
        {
            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int mhdCTHD = (int)row.Cells[0].Value;

            int msCTHD = (int)row.Cells[1].Value;

            int soLuongBan = CTHD[0].SoLuongBan;

            // Lấy số lượng sách hiện tại và số lượng sách củ
            int UDsoluongSach = int.Parse(DataProvider.Instance.TakeData("SELECT SoLuong FROM Sach WHERE MaSach LIKE N'" + msCTHD.ToString() + "'", "SoLuong"));
            int SLbanOLD = int.Parse(DataProvider.Instance.TakeData("SELECT SLban FROM ChiTietHD WHERE MaSach LIKE N'" + msCTHD.ToString() + "' AND MaHD LIKE N'" + mhdCTHD.ToString() + "'", "SLban"));

            int checkUDsoLuongBan = UDsoluongSach + SLbanOLD;

            if (checkUDsoLuongBan >= soLuongBan)
            {
                if (soLuongBan < SLbanOLD) // Nếu số lượng bán củ lớn hơn số lượng bán mới
                {
                    UDsoluongSach += (SLbanOLD - soLuongBan); // Lấy số lượng bán củ trừ số lượng bán mới sau đó lấy số lượng sách cộng cho kết quả
                }
                else // Nếu số lượng bán mới lớn hơn số lượng bán củ
                {
                    UDsoluongSach -= (soLuongBan - SLbanOLD); // Lấy số lượng bán mới trừ số lượng bán củ sau đó lấy số lượng sách trừ cho kết quả
                }

                // Cập nhật chi tiết hóa đơn
                bool suscess = ChiTietHoaDonDAL.Instance.CapNhatChiTietHoaDon(CTHD, dtgv);

                if (suscess)
                {
                    // Lấy tổng tiền và tổng số lượng của chi tiết hóa dơn vào biến
                    string UDtongtienHD = DataProvider.Instance.TakeData("SELECT SUM(ThanhTien) as N'Tổng tiền' FROM ChiTietHD WHERE MaHD LIKE N'" + mhdCTHD.ToString() + "' GROUP BY MaHD", "Tổng tiền");
                    string UDtongsoluongHD = DataProvider.Instance.TakeData("SELECT SUM(SLban) as N'Tổng số lượng' FROM ChiTietHD WHERE MaHD LIKE N'" + mhdCTHD.ToString() + "' GROUP BY MaHD", "Tổng số lượng");

                    // Cập nhật tổng tiền và tổng số lượng của hóa đơn
                    HoaDonBUS.Instance.CapNhatHoaDonTTvaTSL(UDtongtienHD, UDtongsoluongHD, mhdCTHD, HD);

                    // Cập nhật số lượng của sách
                    frm_Sach sh = new frm_Sach();
                    SachBUS.Instance.CapNhatSoLuongSach(UDsoluongSach, dtgv, sh.getDGVsach());

                    // Load lại danh sách chi tiết hóa đơn
                    HienThiDanhSachChiTietHoaDon(dtgv);
                    MessageBox.Show("Chỉnh sửa thông tin chi tiết hóa đơn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Mã hóa đơn và mã sách này đã tồn tại!", "Chỉnh sửa không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Số lượng sách trong kho không đáp ứng được nhu cầu của bạn!", "Chỉnh sửa không thành công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SearchChiTietHoaDon(TextBox timkiem, DataGridView dtgv) 
        {
            // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
            dtgv.DataSource = ChiTietHoaDonDAL.Instance.SearchChiTietHoaDon(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã hóa đơn";
            dtgv.Columns[1].HeaderText = "Mã sách";
            dtgv.Columns[2].HeaderText = "Số lượng bán";
            dtgv.Columns[3].HeaderText = "Giá thành";
        }

        public string HienThiGiaThanhTheoMaSachCTHD(string ms)
        {
            string result = ChiTietHoaDonDAL.Instance.HienThiGiaThanhTheoMaSachCTHD(ms);
            return result;
        }
    }
}
