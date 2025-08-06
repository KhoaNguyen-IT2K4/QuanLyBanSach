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
    public class KhachHangDAL
    {
        private static KhachHangDAL instance;

        public static KhachHangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAL();
                return instance;
            }

            set => instance = value;
        }

        public KhachHangDAL() { }

        public List<KhachHangDTO> HienThiDanhSachKhachHang()
        {
            List<KhachHangDTO> khachhang = new List<KhachHangDTO>();

            string query = "SELECT MaKH as N'Mã khách hàng',HoTenKH as N'Họ tên KH'," +
                "GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ'," +
                "DienThoai as N'Số điện thoại' FROM KhachHang";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maKhachHang = int.Parse(row["Mã khách hàng"].ToString());
                string hoTenKhachHang = row["Họ tên KH"].ToString();
                string gioiTinh = row["Giới tính"].ToString();
                DateTime ngaySinh = (DateTime)row["Ngày sinh"];
                string diaChi = row["Địa chỉ"].ToString();
                int dienThoai = int.Parse(row["Số điện thoại"].ToString());

                KhachHangDTO newKH = new KhachHangDTO(maKhachHang, hoTenKhachHang, gioiTinh, ngaySinh, diaChi, dienThoai);

                khachhang.Add(newKH);
            }

            return khachhang;
        }

        public bool ThemKhachHang(List<KhachHangDTO> KH)
        {
            bool result = false;

            string query = "INSERT INTO KhachHang VALUES (N'" + KH[0].HoTenKhachHang + "',N'" + KH[0].GioiTinh + "',N'" + KH[0].NgaySinh + "',N'" + KH[0].DiaChi + "',N'" + KH[0].DienThoai + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaKhachHang(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maKhachHang = (int)row.Cells[0].Value;

            string query = "DELETE FROM KhachHang WHERE MaKH LIKE N'" + maKhachHang + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatKhachHang(List<KhachHangDTO> KH, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maKhachHang = (int)row.Cells[0].Value;

            string query = "UPDATE KhachHang SET HoTenKH = N'" + KH[0].HoTenKhachHang + "',GioiTinh = N'" + KH[0].GioiTinh + "',NgaySinh = N'" + KH[0].NgaySinh + "',DiaChi = N'" + KH[0].DiaChi + "',DienThoai = N'" + KH[0].DienThoai + "' WHERE MaKH LIKE N'" + maKhachHang + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<KhachHangDTO> SearchKhachHang(string timkiem)
        {
            List<KhachHangDTO> khachhang = new List<KhachHangDTO>();

            string query = "SELECT MaKH as N'Mã khách hàng',HoTenKH as N'Họ tên KH'," +
                    "GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ'," +
                    "DienThoai as N'Số điện thoại' FROM KhachHang WHERE HoTenKH LIKE N'" + timkiem.ToString() + "' OR GioiTinh LIKE N'" + timkiem.ToString() + "' OR FORMAT(NgaySinh,'dd/MM/yyyy') LIKE N'" + timkiem.ToString() + "' OR DiaChi LIKE N'" + timkiem.ToString() + "' OR DienThoai LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maKhachHang = int.Parse(row["Mã khách hàng"].ToString());
                string hoTenKhachHang = row["Họ tên KH"].ToString();
                string gioiTinh = row["Giới tính"].ToString();
                DateTime ngaySinh = (DateTime)row["Ngày sinh"];
                string diaChi = row["Địa chỉ"].ToString();
                int dienThoai = int.Parse(row["Số điện thoại"].ToString());

                KhachHangDTO newKH = new KhachHangDTO(maKhachHang, hoTenKhachHang, gioiTinh, ngaySinh, diaChi, dienThoai);

                khachhang.Add(newKH);
            }

            return khachhang;
        }
    }
}
