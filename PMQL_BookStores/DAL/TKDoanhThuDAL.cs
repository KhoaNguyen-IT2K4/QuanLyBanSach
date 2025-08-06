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
    public class TKDoanhThuDAL
    {
        private static TKDoanhThuDAL instance;

        public static TKDoanhThuDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TKDoanhThuDAL();
                return instance;
            }

            set => instance = value;
        }

        public TKDoanhThuDAL() { }


        // --------------------------------------------------------------------- Thống kê Nhập sách theo ngày -------------------------------------------------------------------------//

        public List<TKDoanhThuDTO> HienThiDanhSachTKDTTheoNgay(DateTimePicker ngay)
        {
            List<TKDoanhThuDTO> TKDTngay = new List<TKDoanhThuDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành',ChiTietHD.ThanhTien as N'Thành tiền' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE FORMAT(HoaDon.NgayLap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());
                decimal thanhTien = decimal.Parse(row["Thành tiền"].ToString());

                TKDoanhThuDTO newTKDT = new TKDoanhThuDTO(hinhAnh,tenSach,soLuongBan,giaThanh,thanhTien);

                TKDTngay.Add(newTKDT);
            }

            return TKDTngay;
        }

        public string TongTienBanTKDTNgay(DateTimePicker ngay)
        {
            return DataProvider.Instance.TakeData("select SUM(TongTien) as N'TT' from HoaDon WHERE FORMAT(NgayLap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "'", "TT");
        }

        public string LoiNhuanTKDTNgay(DateTimePicker ngay)
        {
            return DataProvider.Instance.TakeData("select SUM(HoaDon.TongTien - (Sach.DonGiaNhap * ChiTietHD.SLban)) as N'LN' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE FORMAT(NgayLap,'dd/MM/yyyy') LIKE N'" + ngay.Text + "'", "LN");
        }


        // --------------------------------------------------------------------- Thống kê Nhập sách theo ngày hiện tại -------------------------------------------------------------------------//

        public List<TKDoanhThuDTO> HienThiDanhSachTKDTTheoNgayHienTai()
        {
            List<TKDoanhThuDTO> TKDTngay = new List<TKDoanhThuDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành',ChiTietHD.ThanhTien as N'Thành tiền' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE CONVERT(DATE,HoaDon.NgayLap) = CONVERT(DATE,GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());
                decimal thanhTien = decimal.Parse(row["Thành tiền"].ToString());

                TKDoanhThuDTO newTKDT = new TKDoanhThuDTO(hinhAnh, tenSach, soLuongBan, giaThanh, thanhTien);

                TKDTngay.Add(newTKDT);
            }

            return TKDTngay;
        }

        public string TongTienBanTKDTNgayHienTai()
        {
            return DataProvider.Instance.TakeData("select SUM(TongTien) as N'TT' from HoaDon WHERE CONVERT(DATE,NgayLap) = CONVERT(DATE,GETDATE())", "TT");
        }

        public string LoiNhuanTKDTNgayHienTai()
        {
            return DataProvider.Instance.TakeData("select SUM(HoaDon.TongTien - (Sach.DonGiaNhap * ChiTietHD.SLban)) as N'LN' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE CONVERT(DATE,NgayLap) = CONVERT(DATE,GETDATE())", "LN");
        }

        // --------------------------------------------------------------------- Thống kê Nhập sách theo tháng -------------------------------------------------------------------------//
        public List<TKDoanhThuDTO> HienThiDanhSachTKDTTheoThang(ListBox thang, ListBox nam)
        {
            List<TKDoanhThuDTO> TKDTthang = new List<TKDoanhThuDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành',ChiTietHD.ThanhTien as N'Thành tiền' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE MONTH(HoaDon.NgayLap) LIKE N'" + thang.Text + "' AND YEAR(HoaDon.NgayLap) LIKE N'" + nam.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());
                decimal thanhTien = decimal.Parse(row["Thành tiền"].ToString());

                TKDoanhThuDTO newTKDT = new TKDoanhThuDTO(hinhAnh, tenSach, soLuongBan, giaThanh, thanhTien);

                TKDTthang.Add(newTKDT);
            }

            return TKDTthang;
        }

        public string TongTienBanTKDTThang(ListBox thang, ListBox nam)
        {
            return DataProvider.Instance.TakeData("select SUM(TongTien) as N'TT' from HoaDon WHERE MONTH(HoaDon.NgayLap) LIKE N'" + thang.Text + "' AND YEAR(HoaDon.NgayLap) LIKE N'" + nam.Text + "'", "TT");
        }

        public string LoiNhuanTKDTThang(ListBox thang, ListBox nam)
        {
            return DataProvider.Instance.TakeData("select SUM(HoaDon.TongTien - (Sach.DonGiaNhap * ChiTietHD.SLban)) as N'LN' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE MONTH(HoaDon.NgayLap) LIKE N'" + thang.Text + "' AND YEAR(HoaDon.NgayLap) LIKE N'" + nam.Text + "'", "LN");
        }


        // --------------------------------------------------------------------- Thống kê Nhập sách theo tháng hiện tại -------------------------------------------------------------------------//

        public List<TKDoanhThuDTO> HienThiDanhSachTKDTTheoThangHienTai()
        {
            List<TKDoanhThuDTO> TKDTthang = new List<TKDoanhThuDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành',ChiTietHD.ThanhTien as N'Thành tiền' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE MONTH(HoaDon.NgayLap) = MONTH(GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());
                decimal thanhTien = decimal.Parse(row["Thành tiền"].ToString());

                TKDoanhThuDTO newTKDT = new TKDoanhThuDTO(hinhAnh, tenSach, soLuongBan, giaThanh, thanhTien);

                TKDTthang.Add(newTKDT);
            }

            return TKDTthang;
        }
        public string TongTienBanTKDTThangHienTai()
        {
            return DataProvider.Instance.TakeData("select SUM(TongTien) as N'TT' from HoaDon WHERE MONTH(HoaDon.NgayLap) = MONTH(GETDATE())", "TT");
        }

        public string LoiNhuanTKDTThangHienTai()
        {
            return DataProvider.Instance.TakeData("select SUM(HoaDon.TongTien - (Sach.DonGiaNhap * ChiTietHD.SLban)) as N'LN' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE MONTH(HoaDon.NgayLap) = MONTH(GETDATE())", "LN");
        }


        // --------------------------------------------------------------------- Thống kê Nhập sách theo quý -------------------------------------------------------------------------//

        public List<TKDoanhThuDTO> HienThiDanhSachTKDTTheoQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            List<TKDoanhThuDTO> TKDTquy = new List<TKDoanhThuDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành',ChiTietHD.ThanhTien as N'Thành tiền' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "' AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());
                decimal thanhTien = decimal.Parse(row["Thành tiền"].ToString());

                TKDoanhThuDTO newTKDT = new TKDoanhThuDTO(hinhAnh, tenSach, soLuongBan, giaThanh, thanhTien);

                TKDTquy.Add(newTKDT);
            }

            return TKDTquy;
        }

        public string TongTienBanTKDTQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            return DataProvider.Instance.TakeData("select SUM(TongTien) as N'TT' from HoaDon WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "' AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'", "TT");
        }

        public string LoiNhuanTKDTQuy(ListBox nam, string BatDauQuy, string KetThucQuy)
        {
            return DataProvider.Instance.TakeData("select SUM(HoaDon.TongTien - (Sach.DonGiaNhap * ChiTietHD.SLban)) as N'LN' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "' AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'", "LN");
        }

        // --------------------------------------------------------------------- Thống kê Nhập sách theo quý hiện tại -------------------------------------------------------------------------//

        public List<TKDoanhThuDTO> HienThiDanhSachTKDTTheoQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            List<TKDoanhThuDTO> TKDTquy = new List<TKDoanhThuDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành',ChiTietHD.ThanhTien as N'Thành tiền' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE()) AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());
                decimal thanhTien = decimal.Parse(row["Thành tiền"].ToString());

                TKDoanhThuDTO newTKDT = new TKDoanhThuDTO(hinhAnh, tenSach, soLuongBan, giaThanh, thanhTien);

                TKDTquy.Add(newTKDT);
            }

            return TKDTquy;
        }
        public string TongTienBanTKDTQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            return DataProvider.Instance.TakeData("select SUM(TongTien) as N'TT' from HoaDon WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE()) AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'", "TT");
        }

        public string LoiNhuanTKDTQuyHienTai(string BatDauQuy, string KetThucQuy)
        {
            return DataProvider.Instance.TakeData("select SUM(HoaDon.TongTien - (Sach.DonGiaNhap * ChiTietHD.SLban)) as N'LN' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE()) AND MONTH(HoaDon.NgayLap) BETWEEN N'" + BatDauQuy.ToString() + "' AND N'" + KetThucQuy.ToString() + "'", "LN");
        }

        // --------------------------------------------------------------------- Thống kê Nhập sách theo năm -------------------------------------------------------------------------//

        public List<TKDoanhThuDTO> HienThiDanhSachTKDTTheoNam(ListBox nam)
        {
            List<TKDoanhThuDTO> TKDTnam = new List<TKDoanhThuDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành',ChiTietHD.ThanhTien as N'Thành tiền' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());
                decimal thanhTien = decimal.Parse(row["Thành tiền"].ToString());

                TKDoanhThuDTO newTKDT = new TKDoanhThuDTO(hinhAnh, tenSach, soLuongBan, giaThanh, thanhTien);

                TKDTnam.Add(newTKDT);
            }

            return TKDTnam;
        }

        public string TongTienBanTKDTNam(ListBox nam)
        {
            return DataProvider.Instance.TakeData("select SUM(TongTien) as N'TT' from HoaDon WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "'", "TT");
        }

        public string LoiNhuanTKDTNam(ListBox nam)
        {
            return DataProvider.Instance.TakeData("select SUM(HoaDon.TongTien - (Sach.DonGiaNhap * ChiTietHD.SLban)) as N'LN' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = N'" + nam.Text + "'", "LN");
        }

        // --------------------------------------------------------------------- Thống kê Nhập sách theo năm hiện tại -------------------------------------------------------------------------//

        public List<TKDoanhThuDTO> HienThiDanhSachTKDTTheoNamHienTai()
        {
            List<TKDoanhThuDTO> TKDTnam = new List<TKDoanhThuDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành',ChiTietHD.ThanhTien as N'Thành tiền' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE())";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());
                decimal thanhTien = decimal.Parse(row["Thành tiền"].ToString());

                TKDoanhThuDTO newTKDT = new TKDoanhThuDTO(hinhAnh, tenSach, soLuongBan, giaThanh, thanhTien);

                TKDTnam.Add(newTKDT);
            }

            return TKDTnam;
        }
        public string TongTienBanTKDTNamHienTai()
        {
            return DataProvider.Instance.TakeData("select SUM(TongTien) as N'TT' from HoaDon WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE())", "TT");
        }

        public string LoiNhuanTKDTNamHienTai()
        {
            return DataProvider.Instance.TakeData("select SUM(HoaDon.TongTien - (Sach.DonGiaNhap * ChiTietHD.SLban)) as N'LN' from HoaDon inner join ChiTietHD on HoaDon.MaHD = ChiTietHD.MaHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE YEAR(HoaDon.NgayLap) = YEAR(GETDATE())", "LN");
        }
    }
}
