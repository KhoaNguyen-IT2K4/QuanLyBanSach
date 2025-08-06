using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMQL_BookStores.BUS;
using PMQL_BookStores.DTO;

namespace PMQL_BookStores.DAL
{
    public class DangNhapDAL
    {
        private static DangNhapDAL instance;

        private string Conn = DataProvider.Instance.Conn;

        string accOnline = ""; // biến kiểm tra tài khoản nếu đang đăng nhập thì xuất ra thông báo

        public List<DangNhapDTO> listTKOnline; // list lưu thông thông tin tài khoản khi đăng nhập

        internal List<DangNhapDTO> ListTKOnline
        {
            get => listTKOnline;
            set => listTKOnline = value;
        }

        public static DangNhapDAL Instance 
        { 
            get 
            {
                if (instance == null)
                    instance = new DangNhapDAL();
                return instance;
            }
            
            set => instance = value; 
        }

        DangNhapDAL() { }

        public bool CheckLogin(string Str) // Hàm kiểm tra đăng nhập
        {
            bool user = false;

            // Câu lệnh kết nối database
            SqlConnection Sqlconn = new SqlConnection(Conn);

            Sqlconn.Open(); // Mở kết nối
            SqlCommand cmd = new SqlCommand(Str, Sqlconn); // Thực thi câu lệnh
            SqlDataReader rdr = cmd.ExecuteReader(); // đọc câu lệnh
            if (rdr.Read() == true)
            {
                if (rdr[0].ToString() == "Offline") // Kiểm tra trang thái tài khoản có Offline không
                {
                    user = true;
                }
                else if (rdr[0].ToString() == "Online") // Kiểm tra trạng thái tài khoản có online không
                {
                    accOnline = "On";
                }
            }

            return user;
        }

        public void UDlogoutTK(string str) // Hàm xử lý cập nhật trang thái Offline của tài khoản
        {
            for (int i = 0; i < ListTKOnline.Count; i++)
            {
                if (ListTKOnline[i].Quyen1 == str)
                {
                    frm_TaiKhoan tk = new frm_TaiKhoan();

                    bool result = DataProvider.Instance.DataHandle("UPDATE TaiKhoan SET TrangThai = N'Offline' WHERE Uname LIKE N'" + ListTKOnline[i].TenTaiKhoan.ToString() + "' AND Pass LIKE N'" + ListTKOnline[i].MatKhau.ToString() + "'");

                    if (result)
                    {
                        TaiKhoanBUS.Instance.HienThiDanhSachTaiKhoan(tk.dgvTK());
                    }

                    //dbACCESS.Instance.HandleDuLieu("UPDATE TaiKhoan SET TrangThai = N'Offline' WHERE Uname LIKE N'" + ListTKOnline[i].TenTaiKhoan.ToString() + "' AND Pass LIKE N'" + ListTKOnline[i].MatKhau.ToString() + "'",
                    //"SELECT MaTK as N'Mã tài khoản',Uname as N'Tên tài khoản',Pass as N'Mật khẩu',Email as N'Email',MaNV as N'Mã nhân viên',TrangThai as N'Trạng thái' FROM TaiKhoan", tk.dgvTK());
                }
            }
        }

        public void UDloginTK(string str1, string str2) // Hàm xử lý cập nhật trạng thái online của tài khoản
        {
            frm_TaiKhoan acc = new frm_TaiKhoan();

            bool result = DataProvider.Instance.DataHandle("UPDATE TaiKhoan SET TrangThai = N'Online' WHERE Uname LIKE N'" + str1 + "' AND Pass LIKE N'" + str2 + "'");

            if (result)
            {
                TaiKhoanBUS.Instance.HienThiDanhSachTaiKhoan(acc.dgvTK());
            }

            //dbACCESS.Instance.HandleDuLieu("UPDATE TaiKhoan SET TrangThai = N'Online' WHERE Uname LIKE N'" + str1 + "' AND Pass LIKE N'" + str2 + "'",
            //"SELECT MaTK as N'Mã tài khoản',Uname as N'Tên tài khoản',Pass as N'Mật khẩu',Email as N'Email',MaNV as N'Mã nhân viên',TrangThai as N'Trạng thái' FROM TaiKhoan", acc.dgvTK());
        }

        public string getAccOnLine()
        {
            return accOnline;
        }
    }
}
