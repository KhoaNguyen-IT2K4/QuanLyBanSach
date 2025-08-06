using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class DangNhapDTO
    {
        private string Quyen;
        private string tenTaiKhoan;
        private string matKhau;


        public string Quyen1
        {
            get => Quyen;
            set => Quyen = value;
        }

        public string TenTaiKhoan
        {
            get => tenTaiKhoan;
            set => tenTaiKhoan = value;
        }
        public string MatKhau
        {
            get => matKhau;
            set => matKhau = value;
        }

        public DangNhapDTO(string quyen, string tentaikhoan, string matkhau)
        {
            this.Quyen = quyen;
            this.tenTaiKhoan = tentaikhoan;
            this.matKhau = matkhau;
        }
    }
}
