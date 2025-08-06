using PMQL_BookStores.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace PMQL_BookStores.DAL
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDAL instance;

        public static TaiKhoanDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanDAL();
                return instance;
            }

            set => instance = value;
        }

        public TaiKhoanDAL() { }

        public List<TaiKhoanDTO> HienThiDanhSachTaiKhoan()
        {
            List<TaiKhoanDTO> taikhoan = new List<TaiKhoanDTO>();

            string query = "SELECT MaTK as N'Mã tài khoản',Uname as N'Tên tài khoản',Pass as N'Mật khẩu'," +
                "Email as N'Email',MaNV as N'Mã nhân viên',TrangThai as N'Trạng thái' FROM TaiKhoan WHERE Uname != N'Admin' AND Pass != N'admin'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maTaiKhoan = int.Parse(row["Mã tài khoản"].ToString());
                string tenTaiKhoan = row["Tên tài khoản"].ToString();
                string matKhau = row["Mật khẩu"].ToString();
                string email = row["Email"].ToString();
                int maNhanVien = int.Parse(row["Mã nhân viên"].ToString());
                string trangThai = row["Trạng thái"].ToString();

                TaiKhoanDTO newTK = new TaiKhoanDTO(maTaiKhoan, tenTaiKhoan, matKhau, email, maNhanVien, trangThai);

                taikhoan.Add(newTK);
            }

            return taikhoan;
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
        public bool ThemTaiKhoan(List<TaiKhoanDTO> TK)
        {
            bool result = false;
            string query = "INSERT INTO TaiKhoan VALUES (N'" + TK[0].TenTaiKhoan + "',N'" + TK[0].MatKhau + "',N'" + TK[0].Email + "',N'" + TK[0].MaNhanVien + "',N'" + TK[0].TrangThai + "')";
            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool ThemTaiKhoanTuNhanVien(List<NhanVienDTO> TK)
        {
            bool result = false;

            //Thêm tài khoản mặc định của nhân viên sau khi nhân viên được thêm
            string mnvTK = DataProvider.Instance.TakeData("SELECT TOP(1) MaNV FROM NhanVien ORDER BY MaNV DESC", "MaNV");

            if (mnvTK != "")
            {
                string query = "INSERT INTO TaiKhoan VALUES (N'" + (TK[0].HoNhanVien + TK[0].TenNhanVien) + "',N'" + (TK[0].HoNhanVien + TK[0].TenNhanVien + "123") + "',N'" + (TK[0].HoNhanVien + TK[0].TenNhanVien + "@gmail.com") + "',N'" + mnvTK.ToString() + "',N'Offline')";
                result = DataProvider.Instance.DataHandle(query);
            }

            return result;
        }

        public bool XoaTaiKhoan(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maTaiKhoan = (int)row.Cells[0].Value;

            string query = "DELETE FROM TaiKhoan WHERE MaTK LIKE N'" + maTaiKhoan + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaTaiKhoanTheoNhanVien(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maNhanVien = (int)row.Cells[0].Value;

            string query = "DELETE FROM TaiKhoan WHERE MaNV LIKE N'" + maNhanVien + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatTaiKhoan(List<TaiKhoanDTO> TK, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maTaiKhoan = (int)row.Cells[0].Value;

            string query = "UPDATE TaiKhoan SET Uname = N'" + TK[0].TenTaiKhoan + "',Pass = N'" + TK[0].MatKhau + "',Email = N'" + TK[0].Email + "',MaNV = N'" + TK[0].MaNhanVien + "',TrangThai = N'" + TK[0].TrangThai + "' WHERE MaTK LIKE N'" + maTaiKhoan + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<TaiKhoanDTO> SearchTaiKhoan(string timkiem)
        {
            List<TaiKhoanDTO> taikhoan = new List<TaiKhoanDTO>();

            string query = "SELECT TaiKhoan.MaTK as N'Mã tài khoản',TaiKhoan.Uname as N'Tên tài khoản',TaiKhoan.Pass as N'Mật khẩu'," +
                        "TaiKhoan.Email as N'Email',TaiKhoan.MaNV as N'Mã nhân viên',TaiKhoan.TrangThai as N'Trạng thái' FROM TaiKhoan inner join NhanVien on TaiKhoan.MaNV = NhanVien.MaNV WHERE TaiKhoan.Uname LIKE N'" + timkiem.ToString() + "' OR TaiKhoan.Email LIKE N'" + timkiem.ToString() + "' OR CONCAT(NhanVien.HoNV, ' ' ,NhanVien.TenLotNV, ' ' ,NhanVien.TenNV) LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maTaiKhoan = int.Parse(row["Mã tài khoản"].ToString());
                string tenTaiKhoan = row["Tên tài khoản"].ToString();
                string matKhau = row["Mật khẩu"].ToString();
                string email = row["Email"].ToString();
                int maNhanVien = int.Parse(row["Mã nhân viên"].ToString());
                string trangThai = row["Trạng thái"].ToString();

                TaiKhoanDTO newTK = new TaiKhoanDTO(maTaiKhoan, tenTaiKhoan, matKhau, email, maNhanVien, trangThai);

                taikhoan.Add(newTK);
            }

            return taikhoan;
        }
    }
}
