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
    public class NhanVienDAL
    {
        private static NhanVienDAL instance;

        public static NhanVienDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienDAL();
                return instance;
            }

            set => instance = value;
        }

        public NhanVienDAL() { }

        public List<NhanVienDTO> HienThiDanhSachNhanVien()
        {
            List<NhanVienDTO> nhanvien = new List<NhanVienDTO>();

            string query = "Select MaNV as N'Mã nhân viên',HoNV as N'Họ',TenLotNV as N'Tên lót',TenNV as N'Tên'," +
                "GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',DienThoai as N'Số điện thoại'," +
                "ChucVu as N'Chức vụ' FROM NhanVien WHERE ChucVu != N'Admin'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNhanVien = int.Parse(row["Mã nhân viên"].ToString());
                string hoNhanVien = row["Họ"].ToString();
                string tenLotNhanVien = row["Tên lót"].ToString();
                string tenNhanVien = row["Tên"].ToString();
                string gioiTinh = row["Giới tính"].ToString();
                DateTime ngaySinh = (DateTime)row["Ngày sinh"];
                string diaChi = row["Địa chỉ"].ToString();
                int dienThoai = int.Parse(row["Số điện thoại"].ToString());
                string chucVu = row["Chức vụ"].ToString();

                NhanVienDTO newNV = new NhanVienDTO(maNhanVien,hoNhanVien,tenLotNhanVien,tenNhanVien, gioiTinh,ngaySinh,diaChi,dienThoai,chucVu);

                nhanvien.Add(newNV);
            }

            return nhanvien;
        }

        public bool ThemNhanVien(List<NhanVienDTO> NV)
        {
            bool result = false;

            string query = "INSERT INTO NhanVien VALUES (N'" + NV[0].HoNhanVien + "',N'" + NV[0].TenLotNhanVien + "',N'" + NV[0].TenNhanVien + "',N'" + NV[0].GioiTinh + "',N'" + NV[0].NgaySinh + "',N'" + NV[0].DiaChi + "',N'" + NV[0].DienThoai + "',N'" + NV[0].ChucVu + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaNhanVien(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maNhanVien = (int)row.Cells[0].Value;

            string query = "DELETE FROM NhanVien WHERE MaNV LIKE N'" + maNhanVien + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatNhanVien(List<NhanVienDTO> NV, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maNhanVien = (int)row.Cells[0].Value;

            string query = "UPDATE NhanVien SET HoNV = N'" + NV[0].HoNhanVien + "',TenLotNV  = N'" + NV[0].TenLotNhanVien + "',TenNV = N'" + NV[0].TenNhanVien + "',GioiTinh = N'" + NV[0].GioiTinh + "',NgaySinh = N'" + NV[0].NgaySinh + "',DiaChi = N'" + NV[0].DiaChi + "',DienThoai = N'" + NV[0].DienThoai + "',ChucVu = N'" + NV[0].ChucVu + "' WHERE MaNV LIKE N'" + maNhanVien + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<NhanVienDTO> SearchNhanVien(string timkiem)
        {
            List<NhanVienDTO> nhanvien = new List<NhanVienDTO>();

            string query = "Select MaNV as N'Mã nhân viên',HoNV as N'Họ',TenLotNV as N'Tên lót',TenNV as N'Tên'," +
                        "GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',DienThoai as N'Số điện thoại'," +
                        "ChucVu as N'Chức vụ' FROM NhanVien WHERE " +
                        "HoNV LIKE N'" + timkiem.ToString() +
                        "' OR TenLotNV  LIKE N'" + timkiem.ToString() +
                        "' OR TenNV LIKE N'" + timkiem.ToString() +
                        "' OR GioiTinh LIKE N'" + timkiem.ToString() +
                        "' OR FORMAT(NgaySinh,'dd/MM/yyyy') LIKE N'" + timkiem.ToString() +
                        "' OR DiaChi LIKE N'" + timkiem.ToString() +
                        "' OR DienThoai LIKE N'" + timkiem.ToString() +
                        "' OR ChucVu LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNhanVien = int.Parse(row["Mã nhân viên"].ToString());
                string hoNhanVien = row["Họ"].ToString();
                string tenLotNhanVien = row["Tên lót"].ToString();
                string tenNhanVien = row["Tên"].ToString();
                string gioiTinh = row["Giới tính"].ToString();
                DateTime ngaySinh = (DateTime)row["Ngày sinh"];
                string diaChi = row["Địa chỉ"].ToString();
                int dienThoai = int.Parse(row["Số điện thoại"].ToString());
                string chucVu = row["Chức vụ"].ToString();

                NhanVienDTO newNV = new NhanVienDTO(maNhanVien, hoNhanVien, tenLotNhanVien, tenNhanVien, gioiTinh, ngaySinh, diaChi, dienThoai, chucVu);

                nhanvien.Add(newNV);
            }

            return nhanvien;
        }
    }
}
