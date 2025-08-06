using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    internal class TheLoaiSachBUS
    {
        private static TheLoaiSachBUS instance;

        public static TheLoaiSachBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TheLoaiSachBUS();
                return instance;
            }

            set => instance = value;
        }

        public TheLoaiSachBUS() { }

        SachBUS SB = new SachBUS();

        public void HienThiDanhSachTheLoaiSach(DataGridView dtgv)
        {
            dtgv.DataSource = TheLoaiSachDAL.Instance.HienThiDanhSachTheLoaiSach();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã loại sách";
            dtgv.Columns[1].HeaderText = "Tên loại sách";
        }

        public void ThemTheLoaiSach(List<TheLoaiSachDTO> TLS, DataGridView dtgv, ComboBox cboMLS) // hàm xử lý khi nhấn thêm cảu thể loại sách
        {
            // Thêm thể loại sách
            bool result = TheLoaiSachDAL.Instance.ThemTheLoaiSach(TLS);

            if (result) // Kiểm tra thêm thể loại sách thành công mới thực hiện
            {
                // Load lại dữ liệu combobox thể loại sách của sách
                SachBUS.Instance.DuLieuCBOMaLoaiSach(cboMLS);

                // Load lại danh sách thể loại sách
                HienThiDanhSachTheLoaiSach(dtgv);
                MessageBox.Show("Thêm thể loại sách thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaTheLoaiSach(DataGridView TLS, DataGridView S, PictureBox anhSach, ComboBox cboMLS) // Hàm xử lý khi nhấn xóa của thể loại sách
        {
            DialogResult TBDel = MessageBox.Show("Sách có thể loại sách này cũng sẽ bị xóa.\nBạn có chắc muốn xóa thể loại sách này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = TLS.SelectedCells[0].OwningRow;

                int maLoaiSach = (int)row.Cells[0].Value;

                // Kiểm tra đã xóa sách liên quan đến mã thể loại sách chưa, Nếu đã xóa rồi thì mới thực hiện
                if (SachBUS.Instance.XoaSachTheoTheLoaiSach(S, anhSach, maLoaiSach))
                {
                    // Xóa thể loại sách
                    bool result = TheLoaiSachDAL.Instance.XoaTheLoaiSach(TLS);

                    if (result) // Kiểm tra xóa thể loại sách thành công mới thực hiện
                    {
                        // Load lại dữ liệu combobox thể loại sách của sách
                        SachBUS.Instance.DuLieuCBOMaLoaiSach(cboMLS);

                        // Load lại danh sách thể loại sách
                        HienThiDanhSachTheLoaiSach(TLS);
                        MessageBox.Show("Xóa thể loại sách thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void CapNhatTheLoaiSach(List<TheLoaiSachDTO> TLS, DataGridView dtgv, ComboBox cboMLS) // Hàm xử lý khi nhấn cập nhật của thể loại sách
        {
            // Sửa thể loại sách
            bool result = TheLoaiSachDAL.Instance.CapNhatTheLoaiSach(TLS, dtgv);

            if (result) // Kiểm tra sửa thể loại sách thành công mới thực hiện
            {
                // Load lại dữ liệu combobox thể loại sách của sách
                SachBUS.Instance.DuLieuCBOMaLoaiSach(cboMLS);

                // Load lại danh sách thể loại sách
                HienThiDanhSachTheLoaiSach(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin thể loại sách thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchTheLoaiSach(TextBox timkiem, DataGridView dtgv) // Hàm xử lý tìm kiếm của thể loại sách
        {
            // Hiển thị dữ liệu của kết qur tìm kiếm lên datagridview
            dtgv.DataSource = TheLoaiSachDAL.Instance.SearchTheLoaiSach(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã loại sách";
            dtgv.Columns[1].HeaderText = "Tên loại sách";
        }
    }
}
