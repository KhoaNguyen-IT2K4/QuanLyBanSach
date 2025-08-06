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
    public class NhanVienBUS
    {
        private static NhanVienBUS instance;

        public static NhanVienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhanVienBUS();
                return instance;
            }

            set => instance = value;
        }

        public NhanVienBUS() { }

        public void HienThiDanhSachNhanVien(DataGridView dtgv)
        {
            dtgv.DataSource = NhanVienDAL.Instance.HienThiDanhSachNhanVien();
            dtgv.ClearSelection();

            dtgv.Columns[0].HeaderText = "Mã nhân viên";
            dtgv.Columns[1].HeaderText = "Họ";
            dtgv.Columns[2].HeaderText = "Tên lót";
            dtgv.Columns[3].HeaderText = "Tên";
            dtgv.Columns[4].HeaderText = "Giới tính";
            dtgv.Columns[5].HeaderText = "Ngày sinh";
            dtgv.Columns[6].HeaderText = "Địa chỉ";
            dtgv.Columns[7].HeaderText = "Số điện thoại";
            dtgv.Columns[8].HeaderText = "Chức vụ";
        }

        public void ThemNhanVien(List<NhanVienDTO> NV, DataGridView dtgv)
        {
            // Thêm nhân viên
            bool result = NhanVienDAL.Instance.ThemNhanVien(NV);

            if (result) // Kiểm tra thêm nhân viên thành công mới thực hiện
            {
                // Cập nhật lại combobox mã nhân viên của tài khoản
                frm_TaiKhoan tk = new frm_TaiKhoan();
                TaiKhoanBUS.Instance.DuLieuCBOMaNhanVien(tk.manvCBO());

                //Thêm tài khoản mặc định của nhân viên sau khi nhân viên được thêm
                TaiKhoanBUS.Instance.ThemTaiKhoanTuNhanVien(NV);

                // Load lại danh sách nhân viên
                HienThiDanhSachNhanVien(dtgv);
                MessageBox.Show("Thêm nhân viên thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void XoaNhanVien(DataGridView dtgv)
        {
            DialogResult TBDel = MessageBox.Show("Tài khoản,phiếu nhập,hóa đơn của nhân viên này cũng sẽ bị xóa.\nBạn có chắc muốn xóa nhân viên này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (TBDel == DialogResult.Yes)
            {
                DataGridViewRow row = dtgv.SelectedCells[0].OwningRow;

                int maNhanVien = (int)row.Cells[0].Value;

                // Tạo đối tượng tài khoản
                frm_TaiKhoan tk = new frm_TaiKhoan();

                // Tạo đối tượng phiếu nhập
                frm_PhieuNhap pn = new frm_PhieuNhap();

                // Tạo đối tượng hóa đơn
                frm_HoaDon hd = new frm_HoaDon();

                // Xóa tài khoản
                TaiKhoanBUS.Instance.XoaTaiKhoanTheoNhanVien(dtgv, tk.dgvTK());

                // Xóa hóa đơn
                HoaDonBUS.Instance.XoaHoaDonTheoNhanVien(maNhanVien, hd.dgvHD(), hd.dgvCTHD(), hd.CBOmahdCTHD());

                // Xóa phiếu nhập
                PhieuNhapBUS.Instance.XoaPhieuNhapTheoNhanVien(maNhanVien, pn.dgvPN(), pn.dgvCTPN(), pn.cboMPNCTPN());

                // Xóa nhân viên
                bool result = NhanVienDAL.Instance.XoaNhanVien(dtgv);

                if (result) // Kiểm tra xóa nhân viên thành công mới thực hiện
                {
                    // Cập nhật lại combobox mã nhân viên của tài khoản
                    TaiKhoanBUS.Instance.DuLieuCBOMaNhanVien(tk.manvCBO());

                    // Load lại danh sách nhân viên
                    HienThiDanhSachNhanVien(dtgv);
                    MessageBox.Show("Xóa nhân viên thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void CapNhatNhanVien(List<NhanVienDTO> NV, DataGridView dtgv)
        {
            // Sửa nhân viên
            bool result = NhanVienDAL.Instance.CapNhatNhanVien(NV, dtgv);

            if (result) // Kiểm tra sửa nhân viên thành công mới thực hiện
            {
                // Cập nhật lại combobox mã nhân viên của tài khoản
                frm_TaiKhoan tk = new frm_TaiKhoan();
                TaiKhoanBUS.Instance.DuLieuCBOMaNhanVien(tk.manvCBO());

                // Load lại danh sách nhân viên
                HienThiDanhSachNhanVien(dtgv);
                MessageBox.Show("Chỉnh sửa thông tin nhân viên thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SearchNhanVien(TextBox timkiem, DataGridView dtgv)
        {
            // không cho hiển thị nhân viên admin
            if (timkiem.Text != "Admin" && timkiem.Text != "admin" && timkiem.Text != "0")
            {
                // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
                dtgv.DataSource = NhanVienDAL.Instance.SearchNhanVien(timkiem.Text);
                dtgv.ClearSelection();

                dtgv.Columns[0].HeaderText = "Mã nhân viên";
                dtgv.Columns[1].HeaderText = "Họ";
                dtgv.Columns[2].HeaderText = "Tên lót";
                dtgv.Columns[3].HeaderText = "Tên";
                dtgv.Columns[4].HeaderText = "Giới tính";
                dtgv.Columns[5].HeaderText = "Ngày sinh";
                dtgv.Columns[6].HeaderText = "Địa chỉ";
                dtgv.Columns[7].HeaderText = "Số điện thoại";
                dtgv.Columns[8].HeaderText = "Chức vụ";
            }
        }
    }
}
