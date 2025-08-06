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
    public class ChiTietHoaDonDAL
    {
        private static ChiTietHoaDonDAL instance;

        public static ChiTietHoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonDAL();
                return instance;
            }

            set => instance = value;
        }

        public ChiTietHoaDonDAL() { }

        public List<ChiTietHoaDonDTO> HienThiDanhSachChiTietHoaDon()
        {
            List<ChiTietHoaDonDTO> CTHD = new List<ChiTietHoaDonDTO>();

            string query = "SELECT MaHD as N'Mã hóa đơn',MaSach as N'Mã sách'," +
                "SLban as N'Số lượng bán',GiaThanh as N'Giá thành' FROM ChiTietHD";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maHoaDon = int.Parse(row["Mã hóa đơn"].ToString());
                int maSach = int.Parse(row["Mã sách"].ToString());
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());

                ChiTietHoaDonDTO newCTHD = new ChiTietHoaDonDTO(maHoaDon,maSach,soLuongBan,giaThanh);

                CTHD.Add(newCTHD);
            }

            return CTHD;
        }

        public List<Tuple<int, string>> DuLieuCBOMaHoaDon()
        {
            List<Tuple<int, string>> CBOMaHoaDon = new List<Tuple<int, string>>();

            string query = "SELECT MaHD FROM HoaDon";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maHoaDon1 = int.Parse(row["MaHD"].ToString());
                string maHoaDon2 = row["MaHD"].ToString();

                CBOMaHoaDon.Add(new Tuple<int, string>(maHoaDon1, maHoaDon2));
            }

            return CBOMaHoaDon;
        }

        public List<Tuple<int, string>> DuLieuCBOMaSach()
        {
            List<Tuple<int, string>> CBOMaSach = new List<Tuple<int, string>>();

            string query = "SELECT MaSach,TenSach FROM Sach";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maSach = int.Parse(row["MaSach"].ToString());
                string tenSach = row["TenSach"].ToString();

                CBOMaSach.Add(new Tuple<int, string>(maSach, tenSach));
            }

            return CBOMaSach;
        }

        public bool ThemChiTietHoaDon(List<ChiTietHoaDonDTO> CTHD)
        {
            bool result = false;

            string query = "INSERT INTO ChiTietHD VALUES (N'" + CTHD[0].MaHoaDon + "',N'" + CTHD[0].MaSach + "',N'" + CTHD[0].SoLuongBan + "',N'" + CTHD[0].GiaThanh + "',N'" + CTHD[0].SoLuongBan * (int)CTHD[0].GiaThanh + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaChiTietHoaDon(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int mhdCTHD = (int)row.Cells[0].Value;

            int msCTHD = (int)row.Cells[1].Value;

            string query = "DELETE FROM ChiTietHD WHERE MaHD LIKE N'" + mhdCTHD.ToString() + "' AND MaSach LIKE N'" + msCTHD.ToString() + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaChiTietHoaDonTheoSach(int maSach)
        {
            bool result = false;

            string query = "DELETE FROM ChiTietHD WHERE MaSach LIKE N'" + maSach.ToString() + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaChiTietHoaDonTheoHoaDon(int maHoaDon)
        {
            bool result = false;

            string query = "DELETE FROM ChiTietHD WHERE MaHD LIKE N'" + maHoaDon + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatChiTietHoaDon(List<ChiTietHoaDonDTO> CTHD, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int mhdCTHD = (int)row.Cells[0].Value;

            int msCTHD = (int)row.Cells[1].Value;

            string query = "UPDATE ChiTietHD SET MaHD = N'"+ CTHD[0].MaHoaDon + "',MaSach = N'"+ CTHD[0].MaSach + "',SLban = N'" + CTHD[0].SoLuongBan + "',GiaThanh = N'" + CTHD[0].GiaThanh + "',ThanhTien = N'" + CTHD[0].SoLuongBan * (int)CTHD[0].GiaThanh + "' WHERE MaHD LIKE N'" + mhdCTHD + "' AND MaSach LIKE N'" + msCTHD + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<ChiTietHoaDonDTO> SearchChiTietHoaDon(string timkiem)
        {
            List<ChiTietHoaDonDTO> CTHD = new List<ChiTietHoaDonDTO>();

            string query = "SELECT ChiTietHD.MaHD as N'Mã hóa đơn',ChiTietHD.MaSach as N'Mã sách'," +
                "ChiTietHD.SLban as N'Số lượng bán',ChiTietHD.GiaThanh as N'Giá thành' FROM ChiTietHD inner join Sach on ChiTietHD.MaSach = Sach.MaSach WHERE ChiTietHD.MaHD LIKE N'" + timkiem.ToString() + "' OR Sach.TenSach LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maHoaDon = int.Parse(row["Mã hóa đơn"].ToString());
                int maSach = int.Parse(row["Mã sách"].ToString());
                int soLuongBan = int.Parse(row["Số lượng bán"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());

                ChiTietHoaDonDTO newCTHD = new ChiTietHoaDonDTO(maHoaDon, maSach, soLuongBan, giaThanh);

                CTHD.Add(newCTHD);
            }

            return CTHD;
        }

        public string HienThiGiaThanhTheoMaSachCTHD(string ms)
        {
            return DataProvider.Instance.TakeData("SELECT DonGiaBan FROM Sach WHERE MaSach LIKE N'" + ms + "'", "DonGiaBan"); // Truy vấn lấy đơn giá bán của mã sách đó
        }
    }
}
