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
    public class NhaXuatBanDAL
    {
        private static NhaXuatBanDAL instance;

        public static NhaXuatBanDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaXuatBanDAL();
                return instance;
            }

            set => instance = value;
        }

        public NhaXuatBanDAL() { }

        public List<NhaXuatBanDTO> HienThiDanhSachNhaXuatBan()
        {
            List<NhaXuatBanDTO> nhaxuatban = new List<NhaXuatBanDTO>();

            string query = "SELECT MaNXB as N'Mã nhà xuất bản',TenNXB as N'Tên nhà xuất bản',DiaChi as N'Địa chỉ' FROM NhaXuatBan";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNhaXuatBan = int.Parse(row["Mã nhà xuất bản"].ToString());
                string tenNhaXuatBan = row["Tên nhà xuất bản"].ToString();
                string diaChi = row["Địa chỉ"].ToString();

                NhaXuatBanDTO newNXB = new NhaXuatBanDTO(maNhaXuatBan, tenNhaXuatBan, diaChi);

                nhaxuatban.Add(newNXB);
            }

            return nhaxuatban;
        }

        public bool ThemNhaXuatBan(List<NhaXuatBanDTO> NXB)
        {
            bool result = false;

            string query = "INSERT INTO NhaXuatBan VALUES (N'" + NXB[0].TenNhaXuatBan + "',N'" + NXB[0].DiaChi + "')";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool XoaNhaXuatBan(DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maNhaXuatBan = (int)row.Cells[0].Value;

            string query = "DELETE FROM NhaXuatBan Where MaNXB LIKE '" + maNhaXuatBan + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public bool CapNhatNhaXuatBan(List<NhaXuatBanDTO> NXB, DataGridView dtgv)
        {
            bool result = false;

            DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

            int maNhaXuatBan = (int)row.Cells[0].Value;

            string query = "UPDATE NhaXuatBan SET TenNXB = N'" + NXB[0].TenNhaXuatBan + "',DiaChi = N'" + NXB[0].DiaChi + "' WHERE MaNXB LIKE '" + maNhaXuatBan + "'";

            result = DataProvider.Instance.DataHandle(query);

            return result;
        }

        public List<NhaXuatBanDTO> SearchNhaXuatBan(string timkiem)
        {
            List<NhaXuatBanDTO> nhaxuatban = new List<NhaXuatBanDTO>();

            string query = "SELECT MaNXB as N'Mã nhà xuất bản',TenNXB as N'Tên nhà xuất bản',DiaChi as N'Địa chỉ' FROM NhaXuatBan WHERE TenNXB LIKE N'" + timkiem.ToString() + "' OR DiaChi LIKE N'" + timkiem.ToString() + "'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                int maNhaXuatBan = int.Parse(row["Mã nhà xuất bản"].ToString());
                string tenNhaXuatBan = row["Tên nhà xuất bản"].ToString();
                string diaChi = row["Địa chỉ"].ToString();

                NhaXuatBanDTO newNXB = new NhaXuatBanDTO(maNhaXuatBan, tenNhaXuatBan, diaChi);

                nhaxuatban.Add(newNXB);
            }

            return nhaxuatban;
        }
    }
}
