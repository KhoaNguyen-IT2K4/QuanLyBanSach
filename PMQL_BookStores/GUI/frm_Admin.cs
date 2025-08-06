using PMQL_BookStores.BUS;
using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores
{
    public partial class frm_Admin : Form
    {
        //string Conn = "Data Source=LAPTOP-60SQJEQ9\\SQLEXPRESS;Initial Catalog=BookStores;Integrated Security=True";

        //public bool CheckOff = true;

        public bool CheckExit = true; // Tạo biến kiểm tra điều kiện đóng form

        public frm_Admin()
        {
            InitializeComponent();
        }

        public event EventHandler DangXuatAdmin; // Tạo even ủy thác đăng xuất Admin

        public event EventHandler ThoatFromAdmin; // Tạo even ủy thác thoát ứng dụng Admin

        private void TSMIDangXuat_Click(object sender, EventArgs e)
        {
            DangXuatAdmin(this, new EventArgs()); // Sử dụng even ủy thác ở các form khác
        }

        private void TSMIThoat_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBox.Show("Bạn muốn thoát chương trình?", "Thoát Chương Trình", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (thoat == DialogResult.Yes)
            {
                if (CheckExit) // Nếu điều kiện đúng thì sẽ đóng form
                {
                    this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
                    this.wmpWelcome.close(); // đóng chương trình phát video
                    ThoatFromAdmin(this, new EventArgs());
                    Application.Exit();
                }
                else
                {
                    this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
                    this.wmpWelcome.close(); // đóng chương trình phát video
                }
            }
        }

        private void frm_Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(CheckExit) // Nếu điều kiện đúng thì sẽ đóng form
            {
                this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
                this.wmpWelcome.close(); // đóng chương trình phát video
                ThoatFromAdmin(this, new EventArgs());
                Application.Exit();
            }
            else
            {
                this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
                this.wmpWelcome.close(); // đóng chương trình phát video
            }
        }

        private Form formParent; // Khai báo form hiện tại của admin là rỗng

        private void btnSach_Click(object sender, EventArgs e) // Hàm click vào button Sách thì mở frm_Sach
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_Sach(this),pnlBodyAdmin); // Mở form sách với hàm khởi tạo có tham số
            lblTieuDeAdmin.Text = btnSach.Text; // Gán text của label tiêu đề admin
        }

        private void btnNhanVien_Click(object sender, EventArgs e) // Hàm click vào button Nhân Viên thì mở frm_NhanVien
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_NhanVien(), pnlBodyAdmin); // Mở form nhân viên
            lblTieuDeAdmin.Text = btnNhanVien.Text; // Gán text của label tiêu đề admin
        }

        private void btnKhachHang_Click(object sender, EventArgs e) // Hàm click vào button Khách Hàng thì mở frm_KhachHang
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_KhachHang(), pnlBodyAdmin); // Mở form khách hàng
            lblTieuDeAdmin.Text = btnKhachHang.Text; // Gán text của label tiêu đề admin
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e) // Hàm click vào button Phiếu Nhập thì mở frm_PhieuNhap
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_PhieuNhap(this), pnlBodyAdmin); // Mở form phiếu nhập với hàm khởi tạo có tham số
            lblTieuDeAdmin.Text = btnPhieuNhap.Text; // Gán text của label tiêu đề admin
        }

        private void btnHoaDon_Click(object sender, EventArgs e) // Hàm click vào button Hóa Đơn thì mở frm_HoaDon
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_HoaDon(this), pnlBodyAdmin); // Mở form hóa đơn với hàm khởi tạo có tham số
            lblTieuDeAdmin.Text = btnHoaDon.Text; // Gán text của label tiêu đề admin
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e) // Hàm click vào button Tài Khoản thì mở frm_TaiKhoan
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_TaiKhoan(), pnlBodyAdmin); // Mở form tài khoản
            lblTieuDeAdmin.Text = btnTaiKhoan.Text; // Gán text của label tiêu đề admin
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e) // Hàm click vào button Nhà Cung Cấp thì mở frm_NhaCungCap
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_NhaCungCap(), pnlBodyAdmin); // Mở form nhà cung cấp
            lblTieuDeAdmin.Text = btnNhaCungCap.Text; // Gán text của label tiêu đề admin
        }

        private void tsmniBanSach_Click(object sender, EventArgs e)
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_ThongKeBS(), pnlBodyAdmin); // Mở form thống kê bán sách
            lblTieuDeAdmin.Text = "Thống Kê Bán Sách"; // Gán text của label tiêu đề admin
        }

        private void tsmniNhapSach_Click(object sender, EventArgs e)
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_ThongKeNS(), pnlBodyAdmin); // Mở form thống kê nhập sách
            lblTieuDeAdmin.Text = "Thống Kê Nhập Sách"; // Gán text của label tiêu đề admin
        }

        private void tsmniDoanhThu_Click(object sender, EventArgs e)
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_ThongKeDT(), pnlBodyAdmin); // Mở form thống kê doanh thu
            lblTieuDeAdmin.Text = "Thống Kê Doanh Thu"; // Gán text của label tiêu đề admin
        }

        private void tsmniSachTonKho_Click(object sender, EventArgs e)
        {
            this.wmpWelcome.Ctlcontrols.stop(); // dừng video admin
            this.wmpWelcome.close(); // đóng chương trình phát video
            AdminBUS.Instance.openFormChild(new frm_ThongKeSTK(), pnlBodyAdmin); // Mở form thống kê sách tồn kho
            lblTieuDeAdmin.Text = "Sách Tồn Kho"; // Gán text của label tiêu đề admin
        }

        private void picLogoAdmin_Click(object sender, EventArgs e) // Hàm click vào Hình logo trên góc thì đóng form con lại
        {
            AdminBUS.Instance.HomePageBack(this, lblTieuDeAdmin, wmpWelcome);
        }

        private void tsmniTrangChu_Click(object sender, EventArgs e) // Hàm click vào menu trang chủ thì đóng form con lại
        {
            AdminBUS.Instance.HomePageBack(this,lblTieuDeAdmin, wmpWelcome);
        }

        private void frm_Admin_Load(object sender, EventArgs e) // Khi mở form thì hiện thông báo xin chào
        {
            MessageBox.Show("Xin chào Admin", "Đăng Nhập Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information); // Hiện hộp thoại xin chào
        }

        private void frm_Admin_Shown(object sender, EventArgs e) // form được mở lên
        {
            AdminBUS.Instance.AdminShown(this,wmpWelcome);
        }

        public void wmpWelcome_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e) // Thay đổi trang thái phát của video
        {
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsStopped) // Kiểm tra xem video nếu dừng lại thì phát tiếp
            {
                this.wmpWelcome.Ctlcontrols.play();
            }
        }

        private void pnlBodyAdmin_Resize(object sender, EventArgs e) // Điều chỉnh kích thước của control phát video vừa với khung
        {
            this.wmpWelcome.Size = this.pnlBodyAdmin.Size;
        }

        public void DoiTieuDeAdmin(string newText) // Thay đổi text label tiêu đề admin khi thay đổi tabpage trong form sách,phiếu nhập,hóa đơn
        {
            lblTieuDeAdmin.Text = newText;
        }
    }
}
