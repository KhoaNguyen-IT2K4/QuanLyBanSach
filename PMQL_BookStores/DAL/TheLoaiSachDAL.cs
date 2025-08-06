using PMQL_BookStores.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.DAL
{
    public class TheLoaiSachDAL
    {
        private static TheLoaiSachDAL instance;

        public static TheLoaiSachDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TheLoaiSachDAL();
                return instance;
            }

            set => instance = value;
        }

        public TheLoaiSachDAL() { }

        public List<TheLoaiSachDTO> HienThiDanhSachTheLoaiSach()
        {
            List<TheLoaiSachDTO> theloaisach = new List<TheLoaiSachDTO>();

            string query = "SELECT MaLoaiSach as N'Mã loại sách',TenLoai as 'Tên loại sách' FROM TheLoaiSach";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maLoaiSach = int.Parse(row["Mã loại sách"].ToString());
                string tenLoai = row["Tên loại sách"].ToString();

                TheLoaiSachDTO newTLS = new TheLoaiSachDTO(maLoaiSach, tenLoai);

                theloaisach.Add(newTLS);
            }

            return theloaisach;
        }

        public bool ThemTheLoaiSach(List<TheLoaiSachDTO> TLS)
        {
            bool result = false;

            string query = "INSERT INTO TheLoaiSach VALUES (N'" + TLS[0].TenLoai + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaTheLoaiSach(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maLoaiSach = (int)row.Cells[0].Value;

            string query = "DELETE FROM TheLoaiSach WHERE MaLoaiSach LIKE '" + maLoaiSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatTheLoaiSach(List<TheLoaiSachDTO> TLS, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maLoaiSach = (int)row.Cells[0].Value;

            string query = "UPDATE TheLoaiSach SET TenLoai = N'" + TLS[0].TenLoai + "' WHERE MaLoaiSach LIKE '" + maLoaiSach + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<TheLoaiSachDTO> SearchTheLoaiSach(string timkiem)
        {
            List<TheLoaiSachDTO> theloaisach = new List<TheLoaiSachDTO>();

            string query = "SELECT MaLoaiSach as N'Mã loại sách',TenLoai as 'Tên loại sách' FROM TheLoaiSach WHERE TenLoai LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maLoaiSach = int.Parse(row["Mã loại sách"].ToString());
                string tenLoai = row["Tên loại sách"].ToString();

                TheLoaiSachDTO newTLS = new TheLoaiSachDTO(maLoaiSach, tenLoai);

                theloaisach.Add(newTLS);
            }

            return theloaisach;
        }
    }
}
