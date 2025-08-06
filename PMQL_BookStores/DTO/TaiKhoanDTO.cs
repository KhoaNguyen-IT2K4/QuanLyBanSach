using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class TaiKhoanDTO
    {
        private int maTaiKhoan;
        private string tenTaiKhoan;
        private string matKhau;
        private string email;
        private int maNhanVien;
        private string trangThai;

        public int MaTaiKhoan 
        { 
            get => maTaiKhoan; 
            set => maTaiKhoan = value; 
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
        public string Email 
        { 
            get => email; 
            set => email = value; 
        }
        public int MaNhanVien 
        { 
            get => maNhanVien; 
            set => maNhanVien = value; 
        }
        public string TrangThai 
        { 
            get => trangThai; 
            set => trangThai = value; 
        }

        public TaiKhoanDTO(int maTaiKhoan,string tenTaiKhoan,string matKhau,string email,int maNhanVien,string trangThai)
        {
            this.maTaiKhoan = maTaiKhoan;
            this.tenTaiKhoan = tenTaiKhoan;
            this.matKhau = matKhau;
            this.email = email;
            this.maNhanVien = maNhanVien;
            this.trangThai = trangThai;
        }
    }
}
