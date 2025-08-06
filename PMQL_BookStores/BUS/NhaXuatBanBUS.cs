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
    internal class NhaXuatBanBUS
    {
        private static NhaXuatBanBUS instance;

        public static NhaXuatBanBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaXuatBanBUS();
                return instance;
            }

            set => instance = value;
        }

        SachBUS SB = new SachBUS();

        public NhaXuatBanBUS() { }

        public void HienThiDanhSachNhaXuatBan(DataGridView dtgv)
        {
            dtgv.DataSource = NhaXuatBanDAL.Instance.HienThiDanhSachNhaXuatBan();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã nhà xuất bản";
            dtgv.Columns[1].HeaderText = "Tên nhà xuất bản";
            dtgv.Columns[2].HeaderText = "Địa chỉ";
        }

        public void ThemNhaXuatBan(List<NhaXuatBanDTO> NXB, DataGridView dtgv, ComboBox cboNXB) // hàm xử lý khi nhấn thêm của nhà xuất bản
        {
            // Thêm nhà xuất bản
            bool result = NhaXuatBanDAL.Instance.ThemNhaXuatBan(NXB);

            if (result) // Kiểm tra thêm nhà xuất bản thành công mới thực hiện
            {
                // Load lại dữ liệu combobox nhà xuất bản của sách
                SachBUS.Instance.DuLieuCBOMaNXB(cboNXB);

                // Load lại danh sách nhà xuất bản
                HienThiDanhSachNhaXuatBan(dtgv);
                MessageBox.Show("Thêm nhà xuất bản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaNhaXuatBan(DataGridView NXB, DataGridView S, PictureBox anhSach, ComboBox cboMNXB) // Hàm xử lý khi nhấn xóa của nhà xuất bản
        {
            DialogResult TBDel = MessageBox.Show("Sách có nhà xuất bản này cũng sẽ bị xóa.\nBạn có chắc muốn xóa nhà xuất bản này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = NXB.SelectedCells[0].OwningRow;

                int maNhaXuatBan = (int)row.Cells[0].Value;

                // Kiểm tra đã xóa sách có liên quan đến mã nhà xuất bản chưa, nếu rồi thì mới thực hiện
                if (SachBUS.Instance.XoaSachTheoNhaXuatBan(S, anhSach, maNhaXuatBan))
                {
                    // Xóa nhà xuất bản
                    bool result = NhaXuatBanDAL.Instance.XoaNhaXuatBan(NXB);

                    if (result) // Kiểm tra xóa nhà xuất bản thành công mới thực hiện
                    {
                        // Load lại dữ liệu combobox nhà xuất bản của sách
                        SachBUS.Instance.DuLieuCBOMaLoaiSach(cboMNXB);

                        // Load lại danh sách nhà xuất bản
                        HienThiDanhSachNhaXuatBan(NXB);
                        MessageBox.Show("Xóa nhà xuất bản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public void CapNhatNhaXuatBan(List<NhaXuatBanDTO> NXB, DataGridView dtgv, ComboBox cboMNXB) // Hàm xử lý khi nhấn cập nhật của nhà xuát bản
        {
            // Sửa nhà xuất bản
            bool result = NhaXuatBanDAL.Instance.CapNhatNhaXuatBan(NXB, dtgv);

            if (result) // Kiểm tra sửa nhà xuất bản thành công mới thực hiện
            {
                // Load lại dữ liệu combobox nhà xuất bản của sách
                SachBUS.Instance.DuLieuCBOMaNXB(cboMNXB);

                // Load lại danh sách nhà xuất bản
                HienThiDanhSachNhaXuatBan(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin nhà xuất bản thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchNhaXuatBan(TextBox timkiem, DataGridView dtgv) // hàm xử lý tìm kiếm của nhà xuất bản
        {
            // hHieern thị dữ liệu của kết qur tìm kiếm lên datagridview
            dtgv.DataSource = NhaXuatBanDAL.Instance.SearchNhaXuatBan(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã nhà xuất bản";
            dtgv.Columns[1].HeaderText = "Tên nhà xuất bản";
            dtgv.Columns[2].HeaderText = "Địa chỉ";
        }
    }
}
