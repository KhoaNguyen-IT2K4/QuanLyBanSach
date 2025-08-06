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
    public class PhieuNhapDAL
    {
        private static PhieuNhapDAL instance;

        public static PhieuNhapDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhieuNhapDAL();
                return instance;
            }

            set => instance = value;
        }

        public PhieuNhapDAL() { }

        public List<PhieuNhapDTO> HienThiDanhSachPhieuNhap()
        {
            List<PhieuNhapDTO> phieunhap = new List<PhieuNhapDTO>();

            string query = "SELECT MaPN as N'Mã phiếu nhập',MaNV as N'Mã nhân viên'," +
                "NgayNhap as N'Ngày nhập',MaNCC as N'Mã nhà cung cấp'," +
                "TongTien as N'Tổng tiền',TongSoLuong as N'Tổng số lượng' FROM PhieuNhap";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maPhieuNhap = int.Parse(row["Mã phiếu nhập"].ToString());
                int maNhanVien = int.Parse(row["Mã nhân viên"].ToString());
                DateTime ngayNhap = (DateTime)row["Ngày nhập"];
                int maNhaCungCap = int.Parse(row["Mã nhà cung cấp"].ToString());
                decimal tongTien = decimal.Parse(row["Tổng tiền"].ToString());
                int tongSoLuong = int.Parse(row["Tổng số lượng"].ToString());

                PhieuNhapDTO newPN = new PhieuNhapDTO(maPhieuNhap,maNhanVien,ngayNhap,maNhaCungCap,tongTien,tongSoLuong);

                phieunhap.Add(newPN);
            }

            return phieunhap;
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

        public List<Tuple<int, string>> DuLieuCBOMaNhaCungCap()
        {
            List<Tuple<int, string>> CBOMaNhaCungCap = new List<Tuple<int, string>>();

            string query = "SELECT MaNCC,TenNCC FROM NhaCungCap";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNhaCungCap = int.Parse(row["MaNCC"].ToString());
                string tenNhaCungCap = row["TenNCC"].ToString();

                CBOMaNhaCungCap.Add(new Tuple<int, string>(maNhaCungCap, tenNhaCungCap));
            }

            return CBOMaNhaCungCap;
        }

        public bool ThemPhieuNhap(List<PhieuNhapDTO> PN)
        {
            bool result = false;

            string query = "INSERT INTO PhieuNhap VALUES ('" + PN[0].MaNhanVien + "','" + PN[0].NgayNhap + "','" + PN[0].MaNhaCungCap + "','" + PN[0].TongTien + "',N'" + PN[0].TongSoLuong + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaPhieuNhap(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maPhieuNhap = (int)row.Cells[0].Value;

            string query = "DELETE FROM PhieuNhap WHERE MaPN LIKE '" + maPhieuNhap + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaPhieuNhapTheoNhanVien(int maNhanVien)
        {
            bool result = false;

            string query = "DELETE FROM PhieuNhap WHERE MaNV LIKE '" + maNhanVien + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaPhieuNhapTheoNhaCungCap(int maNhaCungCap)
        {
            bool result = false;

            string query = "DELETE FROM PhieuNhap WHERE MaNCC LIKE '" + maNhaCungCap + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatPhieuNhap(List<PhieuNhapDTO> PN, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maPhieuNhap = (int)row.Cells[0].Value;

            string query = "UPDATE PhieuNhap SET MaNV = N'" + PN[0].MaNhanVien + "',NgayNhap = N'" + PN[0].NgayNhap + "',MaNCC = N'" + PN[0].MaNhaCungCap + "',TongTien = N'" + PN[0].TongTien + "',TongSoLuong = N'" + PN[0].TongSoLuong + "' WHERE MaPN LIKE N'" + maPhieuNhap + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatPhieuNhapTTvaTSL(string UDtongtienPN, string UDtongsoluongPN, int maPhieuNhap)
        {
            bool result = false;

            string query = "UPDATE PhieuNhap SET TongTien = N'" + UDtongtienPN.ToString() + "',TongSoLuong = N'" + UDtongsoluongPN.ToString() + "' WHERE MaPN LIKE N'" + maPhieuNhap + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<PhieuNhapDTO> SearchPhieuNhap(string timkiem)
        {
            List<PhieuNhapDTO> phieunhap = new List<PhieuNhapDTO>();

            string query = "SELECT PhieuNhap.MaPN as N'Mã phiếu nhập',PhieuNhap.MaNV as N'Mã nhân viên'," +
                "PhieuNhap.NgayNhap as N'Ngày nhập',PhieuNhap.MaNCC as N'Mã nhà cung cấp'," +
                "PhieuNhap.TongTien as N'Tổng tiền',PhieuNhap.TongSoLuong as N'Tổng số lượng' FROM PhieuNhap inner join NhanVien on PhieuNhap.MaNV = NhanVien.MaNV inner join NhaCungCap on PhieuNhap.MaNCC = NhaCungCap.MaNCC WHERE FORMAT(PhieuNhap.NgayNhap,'dd/MM/yyyy') LIKE N'" + timkiem.ToString() + "' OR CONCAT(NhanVien.HoNV, ' ' ,NhanVien.TenLotNV, ' ' ,NhanVien.TenNV) LIKE N'" + timkiem.ToString() + "' OR NhaCungCap.TenNCC LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maPhieuNhap = int.Parse(row["Mã phiếu nhập"].ToString());
                int maNhanVien = int.Parse(row["Mã nhân viên"].ToString());
                DateTime ngayNhap = (DateTime)row["Ngày nhập"];
                int maNhaCungCap = int.Parse(row["Mã nhà cung cấp"].ToString());
                decimal tongTien = decimal.Parse(row["Tổng tiền"].ToString());
                int tongSoLuong = int.Parse(row["Tổng số lượng"].ToString());

                PhieuNhapDTO newPN = new PhieuNhapDTO(maPhieuNhap, maNhanVien, ngayNhap, maNhaCungCap, tongTien, tongSoLuong);

                phieunhap.Add(newPN);
            }

            return phieunhap;
        }
    }
}
