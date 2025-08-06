using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;

        public static TaiKhoanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoanBUS();
                return instance;
            }

            set => instance = value;
        }

        public TaiKhoanBUS() { }

        public void HienThiDanhSachTaiKhoan(DataGridView dtgv)
        {
            dtgv.DataSource = TaiKhoanDAL.Instance.HienThiDanhSachTaiKhoan();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã tài khoản";
            dtgv.Columns[1].HeaderText = "Tên tài khoản";
            dtgv.Columns[2].HeaderText = "Mật khẩu";
            dtgv.Columns[3].HeaderText = "Email";
            dtgv.Columns[4].HeaderText = "Mã nhân viên";
            dtgv.Columns[5].HeaderText = "Trạng thái";
        }

        public void DuLieuCBOMaNhanVien(ComboBox cbo)
        {
            // Hiển thi dữ liệu lên combobox mã nhân viên của tài khoản
            List<Tuple<int, string>> result = TaiKhoanDAL.Instance.DuLieuCBOMaNhanVien();

            cbo.DataSource = result;

            cbo.DisplayMember = "Item2";

            cbo.ValueMember = "Item1";
        }

        public void ThemTaiKhoan(List<TaiKhoanDTO> TK, DataGridView dtgv)
        {
            // Thêm tài khoản
            bool result = TaiKhoanDAL.Instance.ThemTaiKhoan(TK);

            if (result) // Kiểm tra thêm tài khoản thành công mới thực hiện
            {
                // Load lại danh sách tài khoản
                HienThiDanhSachTaiKhoan(dtgv);
                MessageBox.Show("Thêm tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThemTaiKhoanTuNhanVien(List<NhanVienDTO> NV)
        {
            //Thêm tài khoản mặc định của nhân viên sau khi nhân viên được thêm
            TaiKhoanDAL.Instance.ThemTaiKhoanTuNhanVien(NV);
        }

        public void XoaTaiKhoan(DataGridView dtgv)
        {
            DialogResult TBDel = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                // Xóa tài khoản
                bool result = TaiKhoanDAL.Instance.XoaTaiKhoan(dtgv);

                if (result) // Kiểm tra xóa tài khoản thành công mới thực hiện
                {
                    // Load lại danh sách tài khoản
                    HienThiDanhSachTaiKhoan(dtgv);
                    MessageBox.Show("Xóa tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void XoaTaiKhoanTheoNhanVien(DataGridView NV, DataGridView TK)
        {
            bool result = TaiKhoanDAL.Instance.XoaTaiKhoanTheoNhanVien(NV);

            if (result) // Kiểm tra xóa tài khoản thành công mới thực hiện
            {
                // Load lại danh sách tài khoản
                HienThiDanhSachTaiKhoan(TK);
            }
        }

        public void CapNhatTaiKhoan(List<TaiKhoanDTO> TK, DataGridView dtgv)
        {
            // Sửa tài khoản
            bool result = TaiKhoanDAL.Instance.CapNhatTaiKhoan(TK, dtgv);

            if (result) // Kiểm tra sửa tài khoản thành công mới thực hiện
            {
                // Load lại danh sách tài khoản
                HienThiDanhSachTaiKhoan(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin tài khoản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchTaiKhoan(TextBox timkiem, DataGridView dtgv)
        {
            // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
            dtgv.DataSource = TaiKhoanDAL.Instance.SearchTaiKhoan(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã tài khoản";
            dtgv.Columns[1].HeaderText = "Tên tài khoản";
            dtgv.Columns[2].HeaderText = "Mật khẩu";
            dtgv.Columns[3].HeaderText = "Email";
            dtgv.Columns[4].HeaderText = "Mã nhân viên";
            dtgv.Columns[5].HeaderText = "Trạng thái";
        }
    }
}
