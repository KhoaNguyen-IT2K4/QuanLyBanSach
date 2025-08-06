using PMQL_BookStores.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.DAL
{
    public class HoaDonDAL
    {
        private static HoaDonDAL instance;

        public static HoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonDAL();
                return instance;
            }

            set => instance = value;
        }

        public HoaDonDAL() { }

        public List<HoaDonDTO> HienThiDanhSachHoaDon()
        {
            List<HoaDonDTO> hoadon = new List<HoaDonDTO>();

            string query = "SELECT MaHD as N'Mã hóa đơn',MaNV as N'Mã nhân viên'," +
                "NgayLap as N'Ngày lập',MaKH as N'Mã khách hàng'," +
                "TongTien as N'Tổng tiền',TongSoLuong as N'Tổng số lượng' FROM HoaDon";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maHoaDon = int.Parse(row["Mã hóa đơn"].ToString());
                int maNhanVien = int.Parse(row["Mã nhân viên"].ToString());
                DateTime ngayLap = (DateTime)row["Ngày lập"];
                int maKhachHang = int.Parse(row["Mã khách hàng"].ToString());
                decimal tongTien = decimal.Parse(row["Tổng tiền"].ToString());
                int tongSoLuong = int.Parse(row["Tổng số lượng"].ToString());

                HoaDonDTO newHD = new HoaDonDTO(maHoaDon,maNhanVien,ngayLap, maKhachHang,tongTien,tongSoLuong);

                hoadon.Add(newHD);
            }

            return hoadon;
        }

        public List<Tuple<int, string>> DuLieuCBOMaNhanVien()
        {
            List<Tuple<int, string>> CBOMaNhanVien = new List<Tuple<int, string>>();

            string query = "SELECT MaNV,HoNV+' '+TenLotNV+' '+TenNV as N'HoTenNV' FROM NhanVien WHERE ChucVu != N'Admin'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNhanVien = int.Parse(row["MaNV"].ToString());
                string hoTenNhanVien = row["HoTenNV"].ToString();

                CBOMaNhanVien.Add(new Tuple<int, string>(maNhanVien, hoTenNhanVien));
            }

            return CBOMaNhanVien;
        }

        public List<Tuple<int, string>> DuLieuCBOMaKhachHang()
        {
            List<Tuple<int, string>> CBOMaKhachHang = new List<Tuple<int, string>>();

            string query = "SELECT MaKH,HoTenKH FROM KhachHang";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maKhachHang = int.Parse(row["MaKH"].ToString());
                string hoTenKhachHang = row["HoTenKH"].ToString();

                CBOMaKhachHang.Add(new Tuple<int, string>(maKhachHang, hoTenKhachHang));
            }

            return CBOMaKhachHang;
        }

        public bool ThemHoaDon(List<HoaDonDTO> HD)
        {
            bool result = false;

            string query = "INSERT INTO HoaDon VALUES (N'" + HD[0].MaNhanVien + "',N'" + HD[0].NgayLap + "',N'" + HD[0].MaKhachHang + "',N'" + HD[0].TongTien + "',N'" + HD[0].TongSoLuong + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaHoaDon(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maHoaDon = (int)row.Cells[0].Value;

            string query = "DELETE FROM HoaDon WHERE MaHD LIKE N'" + maHoaDon + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaHoaDonTheoNhanVien(int maNhanVien)
        {
            bool result = false;

            string query = "DELETE FROM HoaDon WHERE MaNV LIKE N'" + maNhanVien + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaHoaDonTheoKhachHang(int maKhachHang)
        {
            bool result = false;

            string query = "DELETE FROM HoaDon WHERE MaKH LIKE N'" + maKhachHang + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatHoaDon(List<HoaDonDTO> HD, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maHoaDon = (int)row.Cells[0].Value;

            string query = "UPDATE HoaDon SET MaNV = N'" + HD[0].MaNhanVien + "',NgayLap = N'" + HD[0].NgayLap + "',MaKH = N'" + HD[0].MaKhachHang + "',TongTien = N'" + HD[0].TongTien + "',TongSoLuong = N'" + HD[0].TongSoLuong + "' WHERE MaHD LIKE N'" + maHoaDon + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatHoaDonTTvaTSL(string UDtongtienHD, string UDtongsoluongHD, int maHoaDon)
        {
            bool result = false;

            string query = "UPDATE HoaDon SET TongTien = N'" + UDtongtienHD.ToString() + "',TongSoLuong = N'" + UDtongsoluongHD.ToString() + "' WHERE MaHD LIKE N'" + maHoaDon + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<HoaDonDTO> SearchHoaDon(string timkiem)
        {
            List<HoaDonDTO> hoadon = new List<HoaDonDTO>();

            string query = "SELECT HoaDon.MaHD as N'Mã hóa đơn',HoaDon.MaNV as N'Mã nhân viên'," +
                    "HoaDon.NgayLap as N'Ngày lập',HoaDon.MaKH as N'Mã khách hàng'," +
                    "HoaDon.TongTien as N'Tổng tiền',TongSoLuong as N'Tổng số lượng' FROM HoaDon inner join NhanVien on HoaDon.MaNV = NhanVien.MaNV inner join KhachHang on HoaDon.MaKH = KhachHang.MaKH WHERE FORMAT(HoaDon.NgayLap,'dd/MM/yyyy') LIKE N'" + timkiem.ToString() + "' OR CONCAT(NhanVien.HoNV, ' ' ,NhanVien.TenLotNV, ' ' ,NhanVien.TenNV) LIKE N'" + timkiem.ToString() + "' OR KhachHang.HoTenKH LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maHoaDon = int.Parse(row["Mã hóa đơn"].ToString());
                int maNhanVien = int.Parse(row["Mã nhân viên"].ToString());
                DateTime ngayLap = (DateTime)row["Ngày lập"];
                int maKhachHang = int.Parse(row["Mã khách hàng"].ToString());
                decimal tongTien = decimal.Parse(row["Tổng tiền"].ToString());
                int tongSoLuong = int.Parse(row["Tổng số lượng"].ToString());

                HoaDonDTO newHD = new HoaDonDTO(maHoaDon, maNhanVien, ngayLap, maKhachHang, tongTien, tongSoLuong);

                hoadon.Add(newHD);
            }

            return hoadon;
        }
    }
}
