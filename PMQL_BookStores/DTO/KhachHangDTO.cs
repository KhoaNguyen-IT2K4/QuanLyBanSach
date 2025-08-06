using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class KhachHangDTO
    {
        private int maKhachHang;
        private string hoTenKhachHang;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string diaChi;
        private int dienThoai;

        public int MaKhachHang 
        { 
            get => maKhachHang; 
            set => maKhachHang = value; 
        }
        public string HoTenKhachHang 
        { 
            get => hoTenKhachHang; 
            set => hoTenKhachHang = value; 
        }
        public string GioiTinh 
        { 
            get => gioiTinh; 
            set => gioiTinh = value; 
        }
        public DateTime NgaySinh 
        { 
            get => ngaySinh; 
            set => ngaySinh = value; 
        }
        public string DiaChi 
        { 
            get => diaChi; 
            set => diaChi = value; 
        }
        public int DienThoai 
        { 
            get => dienThoai; 
            set => dienThoai = value; 
        }

        public KhachHangDTO(int maKhachHang,string hoTenKhachHang,string gioiTinh, DateTime ngaySinh,string diaChi,int dienThoai)
        {
            this.maKhachHang = maKhachHang;
            this.hoTenKhachHang = hoTenKhachHang;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
        }
    }
}
