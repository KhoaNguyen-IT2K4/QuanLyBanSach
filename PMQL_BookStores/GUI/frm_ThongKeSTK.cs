using PMQL_BookStores.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.GUI
{
    public partial class frm_ThongKeSTK : Form
    {
        public frm_ThongKeSTK()
        {
            InitializeComponent();
        }

        private void frm_ThongKeSTK_Load(object sender, EventArgs e)
        {
            dgvDanhSachTKTK.RowTemplate.Height = 100; // Thiết lập chiều cao của mỗi dòng thành 100 pixels
            TKSachTonKhoBUS.Instance.loadCBOLoaiSach(cboLoaiSachTKTK); // Load dữ liệu cho combobox thể loại sách
        }

        private void btnThongKeTKTK_Click(object sender, EventArgs e)
        {
            TKSachTonKhoBUS.Instance.ThongKeSachTheoLoaiSach(cboLoaiSachTKTK,dgvDanhSachTKTK,lblTongSoLuongTKTK); // Thực thi thống kê sách theo thể loại sách
        }

        private void btnSachTrongKhoTKTK_Click(object sender, EventArgs e)
        {
            TKSachTonKhoBUS.Instance.ThongKeSachTrongKho(cboLoaiSachTKTK, dgvDanhSachTKTK, lblTongSoLuongTKTK); // Thực thi thống kê tất cả sách trong kho
        }

        private void cboLoaiSachTKTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho người dùng nhập vào combobox
            e.Handled = true;
        }
    }
}
