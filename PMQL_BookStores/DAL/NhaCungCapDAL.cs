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
    public class NhaCungCapDAL
    {
        private static NhaCungCapDAL instance;

        public static NhaCungCapDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaCungCapDAL();
                return instance;
            }

            set => instance = value;
        }

        public NhaCungCapDAL() { }

        public List<NhaCungCapDTO> HienThiDanhSachNhaCungCap()
        {
            List<NhaCungCapDTO> NhaCungCap = new List<NhaCungCapDTO>();

            string query = "SELECT MaNCC as N'Mã nhà cung cấp',TenNCC as N'Tên nhà cung cấp',DiaChi as N'Địa chỉ',DienThoai as N'Số điện thoại' FROM NhaCungCap";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNhaCungCap = int.Parse(row["Mã nhà cung cấp"].ToString());
                string tenNhaCungCap = row["Tên nhà cung cấp"].ToString();
                string diaChi = row["Địa chỉ"].ToString();
                int dienThoai = int.Parse(row["Số điện thoại"].ToString());

                NhaCungCapDTO newNCC = new NhaCungCapDTO(maNhaCungCap, tenNhaCungCap, diaChi, dienThoai);

                NhaCungCap.Add(newNCC);
            }

            return NhaCungCap;
        }

        public bool ThemNhaCungCap(List<NhaCungCapDTO> NCC)
        {
            bool result = false;

            string query = "INSERT INTO NhaCungCap VALUES (N'" + NCC[0].TenNhaCungCap + "',N'" + NCC[0].DiaChi + "',N'" + NCC[0].DienThoai + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaNhaCungCap(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maNhaCungCap = (int)row.Cells[0].Value;

            string query = "DELETE FROM NhaCungCap WHERE MaNCC LIKE N'" + maNhaCungCap + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatNhaCungCap(List<NhaCungCapDTO> NCC, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maNhaCungCap = (int)row.Cells[0].Value;

            string query = "UPDATE NhaCungCap SET TenNCC = N'" + NCC[0].TenNhaCungCap + "',DiaChi = N'" + NCC[0].DiaChi + "',DienThoai = N'" + NCC[0].DienThoai + "' WHERE MaNCC LIKE N'" + maNhaCungCap + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<NhaCungCapDTO> SearchNhaCungCap(string timkiem)
        {
            List<NhaCungCapDTO> NhaCungCap = new List<NhaCungCapDTO>();

            string query = "SELECT MaNCC as N'Mã nhà cung cấp',TenNCC as N'Tên nhà cung cấp'," +
                    "DiaChi as N'Địa chỉ',DienThoai as N'Số điện thoại' FROM NhaCungCap WHERE TenNCC LIKE N'" + timkiem.ToString() + "' OR DiaChi LIKE N'" + timkiem.ToString() + "' OR DienThoai LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNhaCungCap = int.Parse(row["Mã nhà cung cấp"].ToString());
                string tenNhaCungCap = row["Tên nhà cung cấp"].ToString();
                string diaChi = row["Địa chỉ"].ToString();
                int dienThoai = int.Parse(row["Số điện thoại"].ToString());

                NhaCungCapDTO newNCC = new NhaCungCapDTO(maNhaCungCap, tenNhaCungCap, diaChi, dienThoai);

                NhaCungCap.Add(newNCC);
            }

            return NhaCungCap;
        }
    }
}
