using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    public class NhaCungCapBUS
    {
        private static NhaCungCapBUS instance;

        public static NhaCungCapBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhaCungCapBUS();
                return instance;
            }

            set => instance = value;
        }

        public NhaCungCapBUS() { }

        public void HienThiDanhSachNhaCungCap(DataGridView dtgv)
        {
            // Hiển thị dữ liệu lên datagridview
            dtgv.DataSource = NhaCungCapDAL.Instance.HienThiDanhSachNhaCungCap(); // Lấy dữ liệu từ tầng DAL trả về tầng GUI
            dtgv.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            // Đặt lại tên cột trong datagridview
            dtgv.Columns[0].HeaderText = "Mã nhà cung cấp";
            dtgv.Columns[1].HeaderText = "Tên nhà cung cấp";
            dtgv.Columns[2].HeaderText = "Địa chỉ";
            dtgv.Columns[3].HeaderText = "Số điện thoại";
        }

        public void ThemNhaCungCap(List<NhaCungCapDTO> nhacungcap, DataGridView dtgv)
        {
            // Thêm nhà cung cấp
            bool result = NhaCungCapDAL.Instance.ThemNhaCungCap(nhacungcap); // Gửi list có kiểu NhaCungCapDTO lên tầng DAL xử lý và lấy kết quả

            if (result) // Kiểm tra thành công
            {
                HienThiDanhSachNhaCungCap(dtgv); // Hiển thị lại danh sách sau khi xử lý
                MessageBox.Show("Thêm nhà cung cấp thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaNhaCungCap(DataGridView dtgv)
        {
            DialogResult TBDel = MessageBox.Show("Phiếu nhập và chi tiết phiếu nhâp có mã nhà cung cấp này cung sẽ bị xóa.\nBạn có chắc muốn xóa nhà cung cấp này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

                int maNhaCungCap = (int)row.Cells[0].Value;

                // Tạo đối tượng phiếu nhập
                frm_PhieuNhap pn = new frm_PhieuNhap();

                // Lấy mã phiếu nhập có liên quan đến mã nhà cung cấp
                string delctpn = DataProvider.Instance.TakeData("SELECT MaPN FROM PhieuNhap WHERE MaNCC LIKE N'" + maNhaCungCap.ToString() + "'", "MaPN");

                // Xóa phiếu nhập
                PhieuNhapBUS.Instance.XoaPhieuNhapTheoNhaCungCap(maNhaCungCap, pn.dgvPN(), pn.dgvCTPN(), pn.cboMPNCTPN());

                // Xóa nhà cung cấp
                bool result = NhaCungCapDAL.Instance.XoaNhaCungCap(dtgv);

                if (result) // Kiểm tra xóa nhà cung cấp thành công mới thực hiện
                {
                    // Load lại danh sách nhà cung cấp
                    HienThiDanhSachNhaCungCap(dtgv);
                    MessageBox.Show("Xóa nhà cung cấp thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void CapNhatNhaCungCap(List<NhaCungCapDTO> nhacungcap, DataGridView dtgv)
        {
            // Sửa nhà cung cấp
            bool result = NhaCungCapDAL.Instance.CapNhatNhaCungCap(nhacungcap, dtgv); // Gửi list có kiểu NhaCungCapDTO và datagridview lên tầng DAL xử lý và lấy kết quả

            if (result) // Kiểm tra thành công
            {
                HienThiDanhSachNhaCungCap(dtgv); // Hiển thị lại danh sách sau khi xử lý
                MessageBox.Show("Chỉnh sửa thông tin nhà cung cấp thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchNhaCungCap(TextBox txt, DataGridView dtgv)
        {
            // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
            dtgv.DataSource = NhaCungCapDAL.Instance.SearchNhaCungCap(txt.Text);
            dtgv.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            // Đặt lại tên cột trong datagridview
            dtgv.Columns[0].HeaderText = "Mã nhà cung cấp";
            dtgv.Columns[1].HeaderText = "Tên nhà cung cấp";
            dtgv.Columns[2].HeaderText = "Địa chỉ";
            dtgv.Columns[3].HeaderText = "Số điện thoại";
        }
    }
}
