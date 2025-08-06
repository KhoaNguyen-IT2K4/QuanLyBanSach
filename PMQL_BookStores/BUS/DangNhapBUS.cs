using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;

namespace PMQL_BookStores.BUS
{
    public class DangNhapBUS
    {
        private static DangNhapBUS instance;

        private frm_Login _login; // Biến tham chiếu form frm_login
        private TextBox _tenTaiKhoan; // Biến tham biến txtTaiKhoan từ frm_login

        public static DangNhapBUS Instance 
        { 
            get 
            {
                if (instance == null)
                    instance = new DangNhapBUS();
                return instance;
            }

            set => instance = value; 
        }

        public DangNhapBUS(){}

        public DangNhapBUS(frm_Login login, TextBox tenTaiKhoan) // Hàm khởi tạo 2 tham số
        {
            _login = login;
            _tenTaiKhoan = tenTaiKhoan;
        }

        public void DangNhap(TextBox tenTaiKhoan,TextBox matKhau,CheckBox chkShowPass) // Hàm xử lý đăng nhập
        {
            string sqlAdmin = "select TaiKhoan.TrangThai from NhanVien inner join TaiKhoan on NhanVien.MaNV = TaiKhoan.MaNV where TaiKhoan.Uname COLLATE Latin1_General_CS_AS LIKE '" + tenTaiKhoan.Text + "' and TaiKhoan.Pass COLLATE Latin1_General_CS_AS LIKE '" + matKhau.Text + "' and NhanVien.ChucVu like N'Admin'";
            string sqlThuNgan = "select TaiKhoan.TrangThai from NhanVien inner join TaiKhoan on NhanVien.MaNV = TaiKhoan.MaNV where TaiKhoan.Uname COLLATE Latin1_General_CS_AS LIKE '" + tenTaiKhoan.Text + "' and TaiKhoan.Pass COLLATE Latin1_General_CS_AS LIKE '" + matKhau.Text + "' and NhanVien.ChucVu like N'Thu Ngân'";
            string sqlQuanLyKho = "select TaiKhoan.TrangThai from NhanVien inner join TaiKhoan on NhanVien.MaNV = TaiKhoan.MaNV where TaiKhoan.Uname COLLATE Latin1_General_CS_AS LIKE '" + tenTaiKhoan.Text + "' and TaiKhoan.Pass COLLATE Latin1_General_CS_AS LIKE '" + matKhau.Text + "' and NhanVien.ChucVu like N'Quản Lý Kho'";

            if (string.IsNullOrEmpty(tenTaiKhoan.Text) && string.IsNullOrEmpty(matKhau.Text)) // Kiểm tra nhập tên tài khoản và mật khẩu chưa
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản và mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(tenTaiKhoan.Text)) // Kiểm tra nhập tên tài khoản chưa
            {
                MessageBox.Show("Bạn chưa nhập tên tài khoản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(matKhau.Text)) // Kiểm tra nhập mật khẩu chưa
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else // Nếu đã nhập đầy đủ thông tin thì thực thi
            {
                if (DangNhapDAL.Instance.CheckLogin(sqlAdmin)) // kiểm tra đăng nhập tài khoản Admin
                {
                    DangNhapDAL.Instance.listTKOnline = new List<DangNhapDTO>(); // Khởi tạo list
                    DangNhapDAL.Instance.listTKOnline.Add(new DangNhapDTO("Admin", tenTaiKhoan.Text, matKhau.Text)); // Lưu thông tin đăng nhập vào list

                    DangNhapDAL.Instance.UDloginTK(tenTaiKhoan.Text, matKhau.Text); // Chuyển trạng thái tài khoản thành Online

                    // Đăng nhập thành công thì dọn dẹp textbox tên tài khoản và mật khẩu
                    tenTaiKhoan.Clear();
                    matKhau.Clear();
                    frm_Admin FAD = new frm_Admin(); // Khởi tạo đối tượng của frm_Admin để mở form lên
                    FAD.Show(); // Mở form Admin lên
                    _login.Hide(); // Ẩn form đăng nhập đi
                    chkShowPass.Checked = false; // Tắt hiện mật khẩu form login
                    FAD.DangXuatAdmin += FAD_DangXuatAdmin; // Sử dụng even ủy thác đăng xuất Admin 
                    FAD.ThoatFromAdmin += FAD_ThoatFromAdmin; // Sử dụng even ủy thác khi đóng ứng dụng thì chuyển trạng thái tài khoản về Offline
                }
                else if (DangNhapDAL.Instance.CheckLogin(sqlThuNgan)) // Kiểm tra đăng nhập tài khoản Thu Ngân
                {
                    DangNhapDAL.Instance.listTKOnline = new List<DangNhapDTO>(); // Khởi tạo list
                    DangNhapDAL.Instance.listTKOnline.Add(new DangNhapDTO("Thu Ngân", tenTaiKhoan.Text, matKhau.Text)); // Lưu thông tin đăng nhập vào list

                    DangNhapDAL.Instance.UDloginTK(tenTaiKhoan.Text, matKhau.Text); // Chuyển trạng thái tài khoản thành Online

                    // Đăng nhập thành công thì dọn dẹp textbox tên tài khoản và mật khẩu
                    tenTaiKhoan.Clear();
                    matKhau.Clear();
                    frm_ThuNgan FTN = new frm_ThuNgan(); // Khởi tạo đối tượng của frm_ThuNgan để mở form lên
                    FTN.Show(); // Mở form thu ngân lên
                    _login.Hide(); // Ẩn form đăng nhập đi
                    chkShowPass.Checked = false; // Tắt hiện mật khẩu form login
                    FTN.DangXuatTN += FTN_DangXuatTN; // Sử dụng even ủy thác đăng xuất thu ngân
                    FTN.ThoatFormTN += FTN_ThoatFormTN; // Sử dụng even ủy thác khi đóng ứng dụng thì chuyển trạng thái tài khoản về Offline
                }
                else if (DangNhapDAL.Instance.CheckLogin(sqlQuanLyKho)) // Kiểm tra đăng nhập tài khoản Quản Lý Kho
                {
                    DangNhapDAL.Instance.listTKOnline = new List<DangNhapDTO>(); // Khởi tạo list
                    DangNhapDAL.Instance.listTKOnline.Add(new DangNhapDTO("Quản Lý Kho", tenTaiKhoan.Text, matKhau.Text)); // Lưu thông tin đăng nhập vào list

                    DangNhapDAL.Instance.UDloginTK(tenTaiKhoan.Text, matKhau.Text); // Chuyển trạng thái tài khoản thành Online

                    // Đăng nhập thành công thì dọn dẹp textbox tên tài khoản và mật khẩu
                    tenTaiKhoan.Clear();
                    matKhau.Clear();
                    frm_QuanLyKho FQLK = new frm_QuanLyKho(); // Khởi tạo đối tượng của frm_QuanLyKho để mở form lên
                    FQLK.Show(); // Mở form quản lý kho lên
                    _login.Hide(); // Ẩn form đăng nhập đi
                    chkShowPass.Checked = false; // Tắt hiện mật khẩu form login
                    FQLK.DangXuatQLK += FQLK_DangXuatQLK; // Sử dụng even ủy thác đăng xuất quản lý kho
                    FQLK.ThoatFormQLK += FQLK_ThoatFormQLK; // Sử dụng even ủy thác khi đóng ứng dụng thì chuyển trạng thái tài khoản về Offline
                }
                else if (DangNhapDAL.Instance.getAccOnLine() != "") // Nếu tài khoản đang đăng nhập thì thông báo tài khoản đang Online
                {
                    MessageBox.Show("Tài khoản đang online!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else // Nếu tài khoản và mật khẩu không đúng với các tài khoản thì xuất thông báo sai tài khoản và mật khẩu
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FAD_ThoatFromAdmin(object sender, EventArgs e) // Hàm even thoát form Admin
        {
            DangNhapDAL.Instance.UDlogoutTK("Admin"); // Chuyển trang thái tài khoản về Offline
        }

        private void FQLK_ThoatFormQLK(object sender, EventArgs e) // Hàm even thoát form Quản Lý Kho
        {
            DangNhapDAL.Instance.UDlogoutTK("Quản Lý Kho"); // Chuyển trang thái tài khoản về Offline
        }

        private void FTN_ThoatFormTN(object sender, EventArgs e) // Hàm even thoát form Thu Ngân
        {
            DangNhapDAL.Instance.UDlogoutTK("Thu Ngân"); // Chuyển trang thái tài khoản về Offline
        }

        private void FQLK_DangXuatQLK(object sender, EventArgs e) // Hàm even đăng xuất form Quản Lý Kho
        {
            DialogResult tb = MessageBox.Show("Bạn muốn đăng xuất?", "Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // Hiện hộp thoại xác nhận đăng xuất
            if (tb == DialogResult.Yes)
            {
                (sender as frm_QuanLyKho).CheckExit = false; // Tham chiếu đến biến CheckExit ở quản lý kho
                (sender as frm_QuanLyKho).Close(); // Đóng form quản lý kho
                _login.Show(); // Mở lại form đăng nhập
                _tenTaiKhoan.Focus(); // Con trỏ chuột nháy ở textbox tên tài khoản

                DangNhapDAL.Instance.UDlogoutTK("Quản Lý Kho"); // Chuyển trạng thái tài khoản về Offline
            }
        }

        private void FTN_DangXuatTN(object sender, EventArgs e) // Hàm even đăng xuất form Thu Ngân
        {
            DialogResult tb = MessageBox.Show("Bạn muốn đăng xuất?", "Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // Hiện hộp thoại xác nhận đăng xuất
            if (tb == DialogResult.Yes)
            {
                (sender as frm_ThuNgan).CheckExit = false; // Tham chiếu đến biến CheckExit ở Thu ngân
                (sender as frm_ThuNgan).Close(); // Đóng form thu ngân
                _login.Show(); // Mở lại form đăng nhập
                _tenTaiKhoan.Focus(); // Con trỏ chuột nháy ở textbox tên dăng nhập

                DangNhapDAL.Instance.UDlogoutTK("Thu Ngân"); // Chuyển trạng thái tài khoản về Offline   
            }
        }

        private void FAD_DangXuatAdmin(object sender, EventArgs e) // Hàm even đăng xuất form Admin
        {
            DialogResult tb = MessageBox.Show("Bạn muốn đăng xuất?", "Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question); // Hiện hộp thoại xác nhận đăng xuất
            if (tb == DialogResult.Yes)
            {
                (sender as frm_Admin).CheckExit = false; // Tham chiếu đến biến CheckExit ở Admin
                (sender as frm_Admin).Close(); // Đóng form Admin
                _login.Show(); // Mở lại form đăng nhập
                _tenTaiKhoan.Focus(); // Con trỏ chuột nháy ở textbox tên tài khoản

                DangNhapDAL.Instance.UDlogoutTK("Admin"); // Chuyển trạng thái tài khoản về Offline
            }
        }
    }
}
