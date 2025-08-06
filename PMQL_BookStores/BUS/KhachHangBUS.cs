using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    public class KhachHangBUS
    {
        private static KhachHangBUS instance;

        public static KhachHangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangBUS();
                return instance;
            }

            set => instance = value;
        }

        public KhachHangBUS() { }

        public void HienThiDanhSachKhachHang(DataGridView dtgv)
        {
            dtgv.DataSource = KhachHangDAL.Instance.HienThiDanhSachKhachHang();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã khách hàng";
            dtgv.Columns[1].HeaderText = "Họ tên KH";
            dtgv.Columns[2].HeaderText = "Giới tính";
            dtgv.Columns[3].HeaderText = "Ngày sinh";
            dtgv.Columns[4].HeaderText = "Địa chỉ";
            dtgv.Columns[5].HeaderText = "Số điện thoại";
        }

        public void ThemKhachHang(List<KhachHangDTO> KH, DataGridView dtgv)
        {
            // Thêm khách hàng
            bool result = KhachHangDAL.Instance.ThemKhachHang(KH);

            if (result) // Kiểm tra thêm khách hàng thành công mới thực hiện
            {
                // Load lại danh sách khách hàng
                HienThiDanhSachKhachHang(dtgv);
                MessageBox.Show("Thêm khách hàng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaKhachHang(DataGridView dtgv)
        {
            DialogResult TBDel = MessageBox.Show("Hóa đơn và chi tiết hóa đơn của khách hàng này cũng sẽ bị xóa.\nBạn có chắc muốn xóa khách hàng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

                int maKhachHang = (int)row.Cells[0].Value;

                // Tạo đối tượng hóa đơn
                frm_HoaDon hd = new frm_HoaDon();

                // Lấy mã hóa đơn có liên quan đến mã khách hàng
                string delcthd = DataProvider.Instance.TakeData("SELECT MaHD FROM HoaDon WHERE MaKH LIKE N'" + maKhachHang + "'", "MaHD");

                // Xóa hóa đơn
                HoaDonBUS.Instance.XoaHoaDonTheoKhachHang(maKhachHang, hd.dgvHD(), hd.dgvCTHD(), hd.CBOmahdCTHD());

                // Xóa khách hàng
                bool result = KhachHangDAL.Instance.XoaKhachHang(dtgv);

                if (result) // Kiểm tra xóa khách hàng thành công mới thực hiện
                {
                    // Load lại danh sách khách hàng
                    HienThiDanhSachKhachHang(dtgv);
                    MessageBox.Show("Xóa khách hàng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void CapNhatKhachHang(List<KhachHangDTO> KH, DataGridView dtgv)
        {
            // Sửa khách hàng
            bool result = KhachHangDAL.Instance.CapNhatKhachHang(KH, dtgv);

            if (result) // Kiểm tra sửa khách hàng thành công mới thực hiện
            {
                // Load lại danh sách khách hàng
                HienThiDanhSachKhachHang(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin khách hàng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchKhachHang(TextBox timkiem, DataGridView dtgv)
        {
            // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
            dtgv.DataSource = KhachHangDAL.Instance.SearchKhachHang(timkiem.Text);
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã khách hàng";
            dtgv.Columns[1].HeaderText = "Họ tên KH";
            dtgv.Columns[2].HeaderText = "Giới tính";
            dtgv.Columns[3].HeaderText = "Ngày sinh";
            dtgv.Columns[4].HeaderText = "Địa chỉ";
            dtgv.Columns[5].HeaderText = "Số điện thoại";
        }
    }
}
