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
    public class TKBanSachDAL
    {
        private static TKBanSachDAL instance;

        public static TKBanSachDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TKBanSachDAL();
                return instance;
            }

            set => instance = value;
        }

        public TKBanSachDAL() { }


        // --------------------------------------------------------------------- Thống kê bán sách theo ngày -------------------------------------------------------------------------//

        public List<TKBanSachDTO> HienThiDanhSachTKBSTheoNgay(DateTimePicker ngay)
        {
            List<TKBanSachDTO> TKBSngay = new List<TKBanSachDTO>();

            string query = "Select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE FORMAT(HoaDon.NgayLap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh,tenSach,soLuongBan);

                TKBSngay.Add(newTKBS);
            }

            return TKBSngay;
        }

        public List<TKBanSachDTO> HienThiTopSachTKBSTheoNgay(DateTimePicker ngay)
        {
            List<TKBanSachDTO> TKBSngay = new List<TKBanSachDTO>();

            string query = "Select TOP(1) Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE FORMAT(HoaDon.NgayLap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "' ORDER BY SLban DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSngay.Add(newTKBS);
            }

            return TKBSngay;
        }

        public string TongSoLuongBanTKBSNgay(DateTimePicker ngay)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from HoaDon WHERE FORMAT(NgayLap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "'", "TSL");
        }


        // --------------------------------------------------------------------- Thống kê bán sách theo ngày hiện tại -------------------------------------------------------------------------//

        public List<TKBanSachDTO> HienThiDanhSachTKBSTheoNgayHienTai()
        {
            List<TKBanSachDTO> TKBSngay = new List<TKBanSachDTO>();

            string query = "Select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE CONVERT(DATE,HoaDon.NgayLap) = CONVERT(DATE,GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSngay.Add(newTKBS);
            }

            return TKBSngay;
        }

        public List<TKBanSachDTO> HienThiTopSachTKBSTheoNgayHienTai()
        {
            List<TKBanSachDTO> TKBSngay = new List<TKBanSachDTO>();

            string query = "Select TOP(1) Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE CONVERT(DATE,HoaDon.NgayLap) = CONVERT(DATE,GETDATE()) ORDER BY SLban DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSngay.Add(newTKBS);
            }

            return TKBSngay;
        }

        public string TongSoLuongBanTKBSNgayHienTai()
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from HoaDon WHERE CONVERT(DATE,NgayLap) = CONVERT(DATE,GETDATE())", "TSL");
        }

        // --------------------------------------------------------------------- Thống kê bán sách theo tháng -------------------------------------------------------------------------//
        public List<TKBanSachDTO> HienThiDanhSachTKBSTheoThang(ListBox thang, ListBox nam)
        {
            List<TKBanSachDTO> TKBSthang = new List<TKBanSachDTO>();

            string query = "Select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE MONTH(HoaDon.NgayLap) LIKE N'" + thang.Text + "' AND YEAR(HoaDon.NgayLap) LIKE N'" + nam.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSthang.Add(newTKBS);
            }

            return TKBSthang;
        }

        public List<TKBanSachDTO> HienThiTopSachTKBSTheoThang(ListBox thang, ListBox nam)
        {
            List<TKBanSachDTO> TKBSthang = new List<TKBanSachDTO>();

            string query = "Select TOP(1) Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE MONTH(HoaDon.NgayLap) LIKE N'" + thang.Text + "' AND YEAR(HoaDon.NgayLap) LIKE N'" + nam.Text + "' ORDER BY SLban DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSthang.Add(newTKBS);
            }

            return TKBSthang;
        }

        public string TongSoLuongBanTKBSThang(ListBox thang, ListBox nam)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from HoaDon WHERE MONTH(HoaDon.NgayLap) LIKE N'" + thang.Text + "' AND YEAR(HoaDon.NgayLap) LIKE N'" + nam.Text + "'", "TSL");
        }


        // --------------------------------------------------------------------- Thống kê bán sách theo tháng hiện tại -------------------------------------------------------------------------//

        public List<TKBanSachDTO> HienThiDanhSachTKBSTheoThangHienTai()
        {
            List<TKBanSachDTO> TKBSthang = new List<TKBanSachDTO>();

            string query = "Select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE MONTH(HoaDon.NgayLap) = MONTH(GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSthang.Add(newTKBS);
            }

            return TKBSthang;
        }

        public List<TKBanSachDTO> HienThiTopSachTKBSTheoThangHienTai()
        {
            List<TKBanSachDTO> TKBSthang = new List<TKBanSachDTO>();

            string query = "Select TOP(1) Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE MONTH(HoaDon.NgayLap) = MONTH(GETDATE()) ORDER BY SLban DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSthang.Add(newTKBS);
            }

            return TKBSthang;
        }

        public string TongSoLuongBanTKBSThangHienTai()
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from HoaDon WHERE MONTH(HoaDon.NgayLap) = MONTH(GETDATE())", "TSL");
        }


        // --------------------------------------------------------------------- Thống kê bán sách theo quý -------------------------------------------------------------------------//

        public List<TKBanSachDTO> HienThiDanhSachTKBSTheoQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            List<TKBanSachDTO> TKBSquy = new List<TKBanSachDTO>();

            string query = "Select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "' AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSquy.Add(newTKBS);
            }

            return TKBSquy;
        }

        public List<TKBanSachDTO> HienThiTopSachTKBSTheoQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            List<TKBanSachDTO> TKBSquy = new List<TKBanSachDTO>();

            string query = "Select TOP(1) Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "' AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "' ORDER BY SLban DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSquy.Add(newTKBS);
            }

            return TKBSquy;
        }

        public string TongSoLuongBanTKBSQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from HoaDon WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "' AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'", "TSL");
        }

        // --------------------------------------------------------------------- Thống kê bán sách theo quý hiện tại -------------------------------------------------------------------------//

        public List<TKBanSachDTO> HienThiDanhSachTKBSTheoQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            List<TKBanSachDTO> TKBSquy = new List<TKBanSachDTO>();

            string query = "Select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE()) AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSquy.Add(newTKBS);
            }

            return TKBSquy;
        }

        public List<TKBanSachDTO> HienThiTopSachTKBSTheoQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            List<TKBanSachDTO> TKBSquy = new List<TKBanSachDTO>();

            string query = "Select TOP(1) Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE()) AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "' ORDER BY SLban DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSquy.Add(newTKBS);
            }

            return TKBSquy;
        }

        public string TongSoLuongBanTKBSQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from HoaDon WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE()) AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'", "TSL");
        }

        // --------------------------------------------------------------------- Thống kê bán sách theo năm -------------------------------------------------------------------------//

        public List<TKBanSachDTO> HienThiDanhSachTKBSTheoNam(ListBox nam)
        {
            List<TKBanSachDTO> TKBSnam = new List<TKBanSachDTO>();

            string query = "Select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSnam.Add(newTKBS);
            }

            return TKBSnam;
        }

        public List<TKBanSachDTO> HienThiTopSachTKBSTheoNam(ListBox nam)
        {
            List<TKBanSachDTO> TKBSnam = new List<TKBanSachDTO>();

            string query = "Select TOP(1) Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "' ORDER BY SLban DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSnam.Add(newTKBS);
            }

            return TKBSnam;
        }

        public string TongSoLuongBanTKBSNam(ListBox nam)
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from HoaDon WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "'", "TSL");
        }

        // --------------------------------------------------------------------- Thống kê bán sách theo năm hiện tại -------------------------------------------------------------------------//

        public List<TKBanSachDTO> HienThiDanhSachTKBSTheoNamHienTai()
        {
            List<TKBanSachDTO> TKBSnam = new List<TKBanSachDTO>();

            string query = "Select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSnam.Add(newTKBS);
            }

            return TKBSnam;
        }

        public List<TKBanSachDTO> HienThiTopSachTKBSTheoNamHienTai()
        {
            List<TKBanSachDTO> TKBSnam = new List<TKBanSachDTO>();

            string query = "Select TOP(1) Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE()) ORDER BY SLban DESC";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());

                TKBanSachDTO newTKBS = new TKBanSachDTO(hinhAnh, tenSach, soLuongBan);

                TKBSnam.Add(newTKBS);
            }

            return TKBSnam;
        }

        public string TongSoLuongBanTKBSNamHienTai()
        {
            return DataProvider.Instance.TakeData("Select Sum(TongSoLuong) as N'TSL' from HoaDon WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE())", "TSL");
        }

    }
}
