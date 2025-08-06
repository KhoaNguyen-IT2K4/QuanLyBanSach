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
    public class TKNhapSachDAL
    {
        private static TKNhapSachDAL instance;

        public static TKNhapSachDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TKNhapSachDAL();
                return instance;
            }

            set => instance = value;
        }

        public TKNhapSachDAL() { }


        // --------------------------------------------------------------------- Thống kê Nhập sách theo ngày -------------------------------------------------------------------------//

        public List<TKNhapSachDTO> HienThiDanhSachTKNSTheoNgay(DateTimePicker ngay)
        {
            List<TKNhapSachDTO> TKNSngay = new List<TKNhapSachDTO>();

            string query = "Select Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE FORMAT(PhieuNhap.NgayNhap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach,soLuongNhap);

                TKNSngay.Add(newTKDT);
            }

            return TKNSngay;
        }

        public List<TKNhapSachDTO> HienThiTopSachTKNSTheoNgay(DateTimePicker ngay)
        {
            List<TKNhapSachDTO> TKNSngay = new List<TKNhapSachDTO>();

            string query = "Select TOP(1) Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE FORMAT(PhieuNhap.NgayNhap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "' ORDER BY SLnhap DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSngay.Add(newTKDT);
            }

            return TKNSngay;
        }

        public string TongSoLuongBanTKNSNgay(DateTimePicker ngay)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from PhieuNhap WHERE FORMAT(NgayNhap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "'", "TSL");
        }


        // --------------------------------------------------------------------- Thống kê Nhập sách theo ngày hiện tại -------------------------------------------------------------------------//

        public List<TKNhapSachDTO> HienThiDanhSachTKNSTheoNgayHienTai()
        {
            List<TKNhapSachDTO> TKNSngay = new List<TKNhapSachDTO>();

            string query = "Select Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE CONVERT(DATE,PhieuNhap.NgayNhap) = CONVERT(DATE,GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSngay.Add(newTKDT);
            }

            return TKNSngay;
        }

        public List<TKNhapSachDTO> HienThiTopSachTKNSTheoNgayHienTai()
        {
            List<TKNhapSachDTO> TKNSngay = new List<TKNhapSachDTO>();

            string query = "Select TOP(1) Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE CONVERT(DATE,PhieuNhap.NgayNhap) = CONVERT(DATE,GETDATE()) ORDER BY SLnhap DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSngay.Add(newTKDT);
            }

            return TKNSngay;
        }

        public string TongSoLuongBanTKNSNgayHienTai()
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from PhieuNhap WHERE CONVERT(DATE,NgayNhap) = CONVERT(DATE,GETDATE())", "TSL");
        }

        // --------------------------------------------------------------------- Thống kê Nhập sách theo tháng -------------------------------------------------------------------------//
        public List<TKNhapSachDTO> HienThiDanhSachTKNSTheoThang(ListBox thang, ListBox nam)
        {
            List<TKNhapSachDTO> TKNSthang = new List<TKNhapSachDTO>();

            string query = "Select Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE MONTH(PhieuNhap.NgayNhap) LIKE N'" + thang.Text + "' AND YEAR(PhieuNhap.NgayNhap) LIKE N'" + nam.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSthang.Add(newTKDT);
            }

            return TKNSthang;
        }

        public List<TKNhapSachDTO> HienThiTopSachTKNSTheoThang(ListBox thang, ListBox nam)
        {
            List<TKNhapSachDTO> TKNSthang = new List<TKNhapSachDTO>();

            string query = "Select TOP(1) Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE MONTH(PhieuNhap.NgayNhap) LIKE N'" + thang.Text + "' AND YEAR(PhieuNhap.NgayNhap) LIKE N'" + nam.Text + "' ORDER BY SLnhap DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSthang.Add(newTKDT);
            }

            return TKNSthang;
        }

        public string TongSoLuongBanTKNSThang(ListBox thang, ListBox nam)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from PhieuNhap WHERE MONTH(PhieuNhap.NgayNhap) LIKE N'" + thang.Text + "' AND YEAR(PhieuNhap.NgayNhap) LIKE N'" + nam.Text + "'", "TSL");
        }


        // --------------------------------------------------------------------- Thống kê Nhập sách theo tháng hiện tại -------------------------------------------------------------------------//

        public List<TKNhapSachDTO> HienThiDanhSachTKNSTheoThangHienTai()
        {
            List<TKNhapSachDTO> TKNSthang = new List<TKNhapSachDTO>();

            string query = "Select Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE MONTH(PhieuNhap.NgayNhap) = MONTH(GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSthang.Add(newTKDT);
            }

            return TKNSthang;
        }

        public List<TKNhapSachDTO> HienThiTopSachTKNSTheoThangHienTai()
        {
            List<TKNhapSachDTO> TKNSthang = new List<TKNhapSachDTO>();

            string query = "Select TOP(1) Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE MONTH(PhieuNhap.NgayNhap) = MONTH(GETDATE()) ORDER BY SLnhap DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSthang.Add(newTKDT);
            }

            return TKNSthang;
        }

        public string TongSoLuongBanTKNSThangHienTai()
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from PhieuNhap WHERE MONTH(PhieuNhap.NgayNhap) = MONTH(GETDATE())", "TSL");
        }


        // --------------------------------------------------------------------- Thống kê Nhập sách theo quý -------------------------------------------------------------------------//

        public List<TKNhapSachDTO> HienThiDanhSachTKNSTheoQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            List<TKNhapSachDTO> TKNSquy = new List<TKNhapSachDTO>();

            string query = "Select Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE YEAR(PhieuNhap.NgayNhap) = N'" + nam.Text + "' AND MONTH(PhieuNhap.NgayNhap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSquy.Add(newTKDT);
            }

            return TKNSquy;
        }

        public List<TKNhapSachDTO> HienThiTopSachTKNSTheoQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            List<TKNhapSachDTO> TKNSquy = new List<TKNhapSachDTO>();

            string query = "Select TOP(1) Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE YEAR(PhieuNhap.NgayNhap) = N'" + nam.Text + "' AND MONTH(PhieuNhap.NgayNhap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "' ORDER BY SLnhap DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSquy.Add(newTKDT);
            }

            return TKNSquy;
        }

        public string TongSoLuongBanTKNSQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from PhieuNhap WHERE YEAR(PhieuNhap.NgayNhap) = N'" + nam.Text + "' AND MONTH(PhieuNhap.NgayNhap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'", "TSL");
        }

        // --------------------------------------------------------------------- Thống kê Nhập sách theo quý hiện tại -------------------------------------------------------------------------//

        public List<TKNhapSachDTO> HienThiDanhSachTKNSTheoQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            List<TKNhapSachDTO> TKNSquy = new List<TKNhapSachDTO>();

            string query = "Select Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE YEAR(PhieuNhap.NgayNhap) = YEAR(GETDATE()) AND MONTH(PhieuNhap.NgayNhap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSquy.Add(newTKDT);
            }

            return TKNSquy;
        }

        public List<TKNhapSachDTO> HienThiTopSachTKNSTheoQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            List<TKNhapSachDTO> TKNSquy = new List<TKNhapSachDTO>();

            string query = "Select TOP(1) Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE YEAR(PhieuNhap.NgayNhap) = YEAR(GETDATE()) AND MONTH(PhieuNhap.NgayNhap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "' ORDER BY SLnhap DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSquy.Add(newTKDT);
            }

            return TKNSquy;
        }

        public string TongSoLuongBanTKNSQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from PhieuNhap WHERE YEAR(PhieuNhap.NgayNhap) = YEAR(GETDATE()) AND MONTH(PhieuNhap.NgayNhap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'", "TSL");
        }

        // --------------------------------------------------------------------- Thống kê Nhập sách theo năm -------------------------------------------------------------------------//

        public List<TKNhapSachDTO> HienThiDanhSachTKNSTheoNam(ListBox nam)
        {
            List<TKNhapSachDTO> TKNSnam = new List<TKNhapSachDTO>();

            string query = "Select Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE YEAR(PhieuNhap.NgayNhap) = N'" + nam.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSnam.Add(newTKDT);
            }

            return TKNSnam;
        }

        public List<TKNhapSachDTO> HienThiTopSachTKNSTheoNam(ListBox nam)
        {
            List<TKNhapSachDTO> TKNSnam = new List<TKNhapSachDTO>();

            string query = "Select TOP(1) Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE YEAR(PhieuNhap.NgayNhap) = N'" + nam.Text + "' ORDER BY SLnhap DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSnam.Add(newTKDT);
            }

            return TKNSnam;
        }

        public string TongSoLuongBanTKNSNam(ListBox nam)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from PhieuNhap WHERE YEAR(PhieuNhap.NgayNhap) = N'" + nam.Text + "'", "TSL");
        }

        // --------------------------------------------------------------------- Thống kê Nhập sách theo năm hiện tại -------------------------------------------------------------------------//

        public List<TKNhapSachDTO> HienThiDanhSachTKNSTheoNamHienTai()
        {
            List<TKNhapSachDTO> TKNSnam = new List<TKNhapSachDTO>();

            string query = "Select Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE YEAR(PhieuNhap.NgayNhap) = YEAR(GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSnam.Add(newTKDT);
            }

            return TKNSnam;
        }

        public List<TKNhapSachDTO> HienThiTopSachTKNSTheoNamHienTai()
        {
            List<TKNhapSachDTO> TKNSnam = new List<TKNhapSachDTO>();

            string query = "Select TOP(1) Sach.TenSach as N'Tên sách',ChiTietPN.SLnhap as N'Số lượng nhập' from PhieuNhap inner join ChiTietPN on PhieuNhap.MaPN = ChiTietPN.MaPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE YEAR(PhieuNhap.NgayNhap) = YEAR(GETDATE()) ORDER BY SLnhap DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string tenSach = row["Tên sách"].ToString();
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());

                TKNhapSachDTO newTKDT = new TKNhapSachDTO(tenSach, soLuongNhap);

                TKNSnam.Add(newTKDT);
            }

            return TKNSnam;
        }

        public string TongSoLuongBanTKNSNamHienTai()
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from PhieuNhap WHERE YEAR(PhieuNhap.NgayNhap) = YEAR(GETDATE())", "TSL");
        }
    }
}
