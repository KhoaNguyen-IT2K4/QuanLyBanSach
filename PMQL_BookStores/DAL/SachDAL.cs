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
    public class SachDAL
    {
        private static SachDAL instance;

        public static SachDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SachDAL();
                return instance;
            }

            set => instance = value;
        }

        public SachDAL() { }

        public List<SachDTO> HienThiDanhSachSach()
        {
            List<SachDTO> sach = new List<SachDTO>();

            string query = "SELECT MaSach as N'Mã sách',TenSach as N'Tên sách',TacGia as N'Tác giả',MaLoaiSach as N'Mã loại sách'," +
                "MaNXB as N'Mã NXB',DonGiaNhap as N'Đơn giá nhập',DonGiaBan as N'Đơn giá bán',SoTrang as N'Số trang'," +
                "TrongLuong as N'Trọng lượng',HinhAnh as N'Tên file hình',SoLuong as N'Số lượng' FROM Sach";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maSach = int.Parse(row["Mã sách"].ToString());
                string tenSach = row["Tên sách"].ToString();
                string tacGia = row["Tác giả"].ToString();
                int maLoaiSach = int.Parse(row["Mã loại sách"].ToString());
                int maNhaXuatBan = int.Parse(row["Mã NXB"].ToString());
                decimal donGiaNhap = decimal.Parse(row["Đơn giá nhập"].ToString());
                decimal donGiaBan = decimal.Parse(row["Đơn giá bán"].ToString());
                int soTrang = int.Parse(row["Số trang"].ToString());
                decimal trongLuong = decimal.Parse(row["Trọng lượng"].ToString());
                string hinhAnh = row["Tên file hình"].ToString();
                int soLuong = int.Parse(row["Số lượng"].ToString());

                SachDTO newS = new SachDTO( maSach, tenSach, tacGia, maLoaiSach, maNhaXuatBan, donGiaNhap, donGiaBan, soTrang, trongLuong, hinhAnh, soLuong);

                sach.Add(newS);
            }

            return sach;
        }

        public List<Tuple<int,string>> DuLieuCBOMaLoaiSach()
        {
            List<Tuple<int, string>> CBOMaLoaiSach = new List<Tuple<int, string>>();

            string query = "SELECT MaLoaiSach,TenLoai FROM TheLoaiSach";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maLoaiSach = int.Parse(row["MaLoaiSach"].ToString());
                string tenLoaiSach = row["TenLoai"].ToString();

                CBOMaLoaiSach.Add(new Tuple<int, string>(maLoaiSach, tenLoaiSach));
            }

            return CBOMaLoaiSach;
        }

        public List<Tuple<int, string>> DuLieuCBOMaNXB()
        {
            List<Tuple<int, string>> CBOMaNXB = new List<Tuple<int, string>>();

            string query = "SELECT MaNXB,TenNXB FROM NhaXuatBan";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNXB = int.Parse(row["MaNXB"].ToString());
                string tenNXB = row["TenNXB"].ToString();

                CBOMaNXB.Add(new Tuple<int, string>(maNXB, tenNXB));
            }

            return CBOMaNXB;
        }

        public bool ThemSach(List<SachDTO> S)
        {
            bool result = false;

            string query = "INSERT INTO Sach VALUES (N'" + S[0].TenSach + "',N'" + S[0].TacGia + "',N'" + S[0].MaLoaiSach + "',N'" + S[0].MaNhaXuatBan + "'," +
                    "N'" + S[0].DonGiaNhap + "',N'" + S[0].DonGiaBan + "',N'" + S[0].SoTrang + "',N'" + S[0].TrongLuong + "'," +
                    "N'" + S[0].HinhAnh + "',N'" + S[0].SoLuong + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool DelSach(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maSach = (int)row.Cells[0].Value;

            string query = "DELETE FROM Sach WHERE MaSach LIKE N'" + maSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaSachTheoMaSach(string maSach)
        {
            bool result = false;

            string query = "DELETE FROM Sach WHERE MaSach LIKE N'" + maSach.ToString() + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatSach(List<SachDTO> S, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maSach = (int)row.Cells[0].Value;

            string query = "UPDATE Sach SET TenSach = N'" + S[0].TenSach + "',TacGia = N'" + S[0].TacGia + "',MaLoaiSach = N'" + S[0].MaLoaiSach + "',MaNXB = N'" + S[0].MaNhaXuatBan + "',DonGiaNhap = N'" + S[0].DonGiaNhap + "',DonGiaBan = N'" + S[0].DonGiaBan + "',SoTrang = N'" + S[0].SoTrang + "',TrongLuong = N'" + S[0].TrongLuong + "',HinhAnh = N'" + S[0].HinhAnh + "',SoLuong = N'" + S[0].SoLuong + "' WHERE MaSach LIKE '" + maSach.ToString() + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }
        public bool CapNhatSachDGNvaSLThemCTPN(decimal UDgiathanhSach, int UDsoluongSach, List<ChiTietPhieuNhapDTO> CTPN)
        {
            bool result = false;

            //DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            //int maSach = (int)row.Cells[1].Value;
            int maSach = CTPN[0].MaSach;

            string query = "UPDATE Sach SET DonGiaNhap = N'" + UDgiathanhSach + "',DonGiaBan = N'" + (UDgiathanhSach + (UDgiathanhSach * (decimal)0.5)) + "',SoLuong = N'" + UDsoluongSach + "' WHERE MaSach LIKE '" + maSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatSachDGNvaSLXoaPhieuNhap(decimal UDgiathanhSach, int UDsoluongSach, string maSach)
        {
            bool result = false;

            //DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            //int maSach = (int)row.Cells[1].Value;
            //int maSach = CTPN[0].MaSach;

            string query = "UPDATE Sach SET DonGiaNhap = N'" + UDgiathanhSach + "',DonGiaBan = N'" + (UDgiathanhSach + (UDgiathanhSach * (decimal)0.5)) + "',SoLuong = N'" + UDsoluongSach + "' WHERE MaSach LIKE '" + maSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatSachDGNvaSL(decimal UDgiathanhSach, int UDsoluongSach, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maSach = (int)row.Cells[1].Value;

            string query = "UPDATE Sach SET DonGiaNhap = N'" + UDgiathanhSach + "',DonGiaBan = N'" + (UDgiathanhSach + (UDgiathanhSach * (decimal)0.5)) + "',SoLuong = N'" + UDsoluongSach + "' WHERE MaSach LIKE '" + maSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatSoLuongSachThemCTHD(int UDsoluongSach, int soLuongBan, int maSach)
        {
            bool result = false;

            string query = "UPDATE Sach SET SoLuong = N'" + (UDsoluongSach - soLuongBan) + "' WHERE MaSach LIKE '" + maSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatSoLuongSachXoaCTHD(int UDsoluongSach, int soLuongBan, int maSach)
        {
            bool result = false;

            string query = "UPDATE Sach SET SoLuong = N'" + (UDsoluongSach + soLuongBan) + "' WHERE MaSach LIKE '" + maSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatSoLuongSach(int UDsoluongSach, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maSach = (int)row.Cells[1].Value;

            string query = "UPDATE Sach SET SoLuong = N'" + (UDsoluongSach) + "' WHERE MaSach LIKE '" + maSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }


        public List<SachDTO> SearchSach(string timkiem)
        {
            List<SachDTO> sach = new List<SachDTO>();

            string query = "SELECT Sach.MaSach as N'Mã sách',Sach.TenSach as N'Tên sách',Sach.TacGia as N'Tác giả',TheLoaiSach.MaLoaiSach as N'Mã loại sách',NhaXuatBan.MaNXB as N'Mã NXB',Sach.DonGiaNhap as N'Đơn giá nhập',Sach.DonGiaBan as N'Đơn giá bán',Sach.SoTrang as N'Số trang',Sach.TrongLuong as N'Trọng lượng',Sach.HinhAnh as N'Tên file hình',Sach.SoLuong as N'Số lượng' FROM Sach inner join TheLoaiSach on Sach.MaLoaiSach = TheLoaiSach.MaLoaiSach inner join NhaXuatBan on Sach.MaNXB = NhaXuatBan.MaNXB" +
                " WHERE Sach.TenSach LIKE N'" + timkiem.ToString() + 
                "' OR Sach.TacGia LIKE N'" + timkiem.ToString() + 
                "' OR TheLoaiSach.TenLoai LIKE N'" + timkiem.ToString() + 
                "' OR NhaXuatBan.TenNXB LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maSach = int.Parse(row["Mã sách"].ToString());
                string tenSach = row["Tên sách"].ToString();
                string tacGia = row["Tác giả"].ToString();
                int maLoaiSach = int.Parse(row["Mã loại sách"].ToString());
                int maNhaXuatBan = int.Parse(row["Mã NXB"].ToString());
                decimal donGiaNhap = decimal.Parse(row["Đơn giá nhập"].ToString());
                decimal donGiaBan = decimal.Parse(row["Đơn giá bán"].ToString());
                int soTrang = int.Parse(row["Số trang"].ToString());
                decimal trongLuong = decimal.Parse(row["Trọng lượng"].ToString());
                string hinhAnh = row["Tên file hình"].ToString();
                int soLuong = int.Parse(row["Số lượng"].ToString());

                SachDTO newS = new SachDTO(maSach, tenSach, tacGia, maLoaiSach, maNhaXuatBan, donGiaNhap, donGiaBan, soTrang, trongLuong, hinhAnh, soLuong);

                sach.Add(newS);
            }

            return sach;
        }
    }
}
