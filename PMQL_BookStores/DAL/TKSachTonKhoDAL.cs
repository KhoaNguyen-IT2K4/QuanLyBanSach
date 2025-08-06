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
    public class TKSachTonKhoDAL
    {
        private static TKSachTonKhoDAL instance;

        public static TKSachTonKhoDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TKSachTonKhoDAL();
                return instance;
            }

            set => instance = value;
        }

        public TKSachTonKhoDAL() { }

        public List<Tuple<int, string>> DuLieuCBOMaLoaiSach()
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

        public List<TKSachTonKhoDTO> HienThiDanhSachTrongKhoTKSTK()
        {
            List<TKSachTonKhoDTO> TKSTK = new List<TKSachTonKhoDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',Sach.SoLuong as N'Số lượng' from Sach";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuong = int.Parse(row["Số lượng"].ToString());

                TKSachTonKhoDTO newTKSTK = new TKSachTonKhoDTO(hinhAnh,tenSach,soLuong);

                TKSTK.Add(newTKSTK);
            }

            return TKSTK;
        }

        public string TongSoLuongSachTrongKhoTKSTK()
        {
            return DataProvider.Instance.TakeData("select SUM(Sach.SoLuong) as N'TSL' from Sach", "TSL");
        }

        public List<TKSachTonKhoDTO> HienThiDanhSachTheoTheLoaiTKSTK(ComboBox cboTheLoai)
        {
            List<TKSachTonKhoDTO> TKSTK = new List<TKSachTonKhoDTO>();

            string query = "select Sach.HinhAnh as N'Hình ảnh',Sach.TenSach as N'Tên sách',Sach.SoLuong as N'Số lượng' from Sach inner join TheLoaiSach on Sach.MaLoaiSach = TheLoaiSach.MaLoaiSach WHERE TheLoaiSach.MaLoaiSach LIKE N'"+ cboTheLoai.SelectedValue.ToString() +"'";

            DataTable data = DataProvider.Instance.DataAccess(query);

            foreach (DataRow row in data.Rows)
            {
                string hinhAnh = row["Hình ảnh"].ToString();
                string tenSach = row["Tên sách"].ToString();
                int soLuong = int.Parse(row["Số lượng"].ToString());

                TKSachTonKhoDTO newTKSTK = new TKSachTonKhoDTO(hinhAnh, tenSach, soLuong);

                TKSTK.Add(newTKSTK);
            }

            return TKSTK;
        }

        public string TongSoLuongSachTheoTheLoaiTKSTK(ComboBox cboTheLoai)
        {
            return DataProvider.Instance.TakeData("select SUM(Sach.SoLuong) as N'TSL' from Sach inner join TheLoaiSach on Sach.MaLoaiSach = TheLoaiSach.MaLoaiSach WHERE TheLoaiSach.MaLoaiSach LIKE N'"+ cboTheLoai.SelectedValue.ToString() +"' GROUP BY TheLoaiSach.MaLoaiSach", "TSL");
        }
    }
}
