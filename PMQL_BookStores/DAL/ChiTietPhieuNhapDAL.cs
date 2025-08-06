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
    public class ChiTietPhieuNhapDAL
    {
        private static ChiTietPhieuNhapDAL instance;

        public static ChiTietPhieuNhapDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietPhieuNhapDAL();
                return instance;
            }

            set => instance = value;
        }

        public ChiTietPhieuNhapDAL() { }

        public List<ChiTietPhieuNhapDTO> HienThiDanhSachChiTietPhieuNhap()
        {
            List<ChiTietPhieuNhapDTO> CTPN = new List<ChiTietPhieuNhapDTO>();

            string query = "SELECT MaPN as N'Mã phiếu nhập',MaSach as N'Mã sách'," +
                "SLnhap as N'Số lượng nhập',GiaThanh as N'Giá thành' FROM ChiTietPN";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maPhieuNhap = int.Parse(row["Mã phiếu nhập"].ToString());
                int maSach = int.Parse(row["Mã sách"].ToString());
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());

                ChiTietPhieuNhapDTO newCTPN = new ChiTietPhieuNhapDTO(maPhieuNhap, maSach, soLuongNhap, giaThanh);

                CTPN.Add(newCTPN);
            }

            return CTPN;
        }

        public List<Tuple<int, string>> DuLieuCBOMaPhieuNhap()
        {
            List<Tuple<int, string>> CBOMaPhieuNhap = new List<Tuple<int, string>>();

            string query = "SELECT MaPN FROM PhieuNhap";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maPhieuNhap1 = int.Parse(row["MaPN"].ToString());
                string maPhieuNhap2 = row["MaPN"].ToString();

                CBOMaPhieuNhap.Add(new Tuple<int, string>(maPhieuNhap1, maPhieuNhap2));
            }

            return CBOMaPhieuNhap;
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

        public bool ThemChiTietPN(List<ChiTietPhieuNhapDTO> CTPN)
        {
            bool result = false;

            string query = "INSERT INTO ChiTietPN VALUES (N'" + CTPN[0].MaPhieuNhap + "',N'" + CTPN[0].MaSach + "',N'" + CTPN[0].SoLuongNhap + "',N'" + CTPN[0].GiaThanh + "',N'" + CTPN[0].SoLuongNhap * CTPN[0].GiaThanh + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaChiTietPN(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int mpnCTPN = (int)row.Cells[0].Value;

            int msCTPN = (int)row.Cells[1].Value;

            string query = "DELETE FROM ChiTietPN WHERE MaPN LIKE N'" + mpnCTPN.ToString() + "' and MaSach LIKE N'" + msCTPN.ToString() + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaChiTietPNTheoSach(int maSach)
        {
            bool result = false;

            string query = "DELETE FROM ChiTietPN WHERE MaSach LIKE N'" + maSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaChiTietPNTheoPhieuNhap(int maPhieuNhap)
        {
            bool result = false;

            string query = "DELETE FROM ChiTietPN WHERE MaPN LIKE N'" + maPhieuNhap + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatChiTietPN(List<ChiTietPhieuNhapDTO> CTPN, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int mpnCTPN = (int)row.Cells[0].Value;

            int msCTPN = (int)row.Cells[1].Value;

            string query = "UPDATE ChiTietPN SET MaPN = N'" + CTPN[0].MaPhieuNhap + "',MaSach = N'" + CTPN[0].MaSach + "',SLnhap = N'" + CTPN[0].SoLuongNhap + "',GiaThanh = N'" + CTPN[0].GiaThanh + "',ThanhTien = N'" + CTPN[0].SoLuongNhap * CTPN[0].GiaThanh + "' WHERE MaPN LIKE N'" + mpnCTPN.ToString() + "' AND MaSach LIKE N'" + msCTPN.ToString() + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<ChiTietPhieuNhapDTO> SearchCchiTietPN(string timkiem)
        {
            List<ChiTietPhieuNhapDTO> CTPN = new List<ChiTietPhieuNhapDTO>();

            string query = "SELECT ChiTietPN.MaPN as N'Mã phiếu nhập',ChiTietPN.MaSach as N'Mã sách'," +
                "ChiTietPN.SLnhap as N'Số lượng nhập',ChiTietPN.GiaThanh as N'Giá thành' FROM ChiTietPN inner join Sach on ChiTietPN.MaSach = Sach.MaSach WHERE ChiTietPN.MaPN LIKE N'" + timkiem.ToString() + "' OR Sach.TenSach LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maPhieuNhap = int.Parse(row["Mã phiếu nhập"].ToString());
                int maSach = int.Parse(row["Mã sách"].ToString());
                int soLuongNhap = int.Parse(row["Số lượng nhập"].ToString());
                decimal giaThanh = decimal.Parse(row["Giá thành"].ToString());

                ChiTietPhieuNhapDTO newCTPN = new ChiTietPhieuNhapDTO(maPhieuNhap, maSach, soLuongNhap, giaThanh);

                CTPN.Add(newCTPN);
            }

            return CTPN;
        }

        public string HienThiGiaThanhTheoMaSachCTPN(string ms)
        {
            return DataProvider.Instance.TakeData("SELECT DonGiaNhap FROM Sach WHERE MaSach LIKE N'" + ms + "'", "DonGiaNhap"); // Truy vấn đơn giá nhập của mã sách đódbACCESS.Instance.LenhShow("SELECT DonGiaNhap FROM Sach WHERE MaSach LIKE N'" + ms + "'", "DonGiaNhap"); // Truy vấn đơn giá nhập của mã sách đó
        }
    }
}
