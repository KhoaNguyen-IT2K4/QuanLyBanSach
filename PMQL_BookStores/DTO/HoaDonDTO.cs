using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class HoaDonDTO
    {
        private int maHoaDon;
        private int maNhanVien;
        private DateTime ngayLap;
        private int maKhachHang;
        private decimal tongTien;
        private int tongSoLuong;

        public int MaHoaDon 
        { 
            get => maHoaDon; 
            set => maHoaDon = value; 
        }
        public int MaNhanVien 
        { 
            get => maNhanVien; 
            set => maNhanVien = value; 
        }
        public DateTime NgayLap 
        { 
            get => ngayLap; 
            set => ngayLap = value; 
        }
        public int MaKhachHang 
        { 
            get => maKhachHang; 
            set => maKhachHang = value; 
        }
        public decimal TongTien 
        { 
            get => tongTien; 
            set => tongTien = value; 
        }
        public int TongSoLuong 
        { 
            get => tongSoLuong; 
            set => tongSoLuong = value; 
        }

        public HoaDonDTO(int maHoaDon,int maNhanVien, DateTime ngayLap,int maKhachHang,decimal tongTien,int tongSoLuong)
        {
            this.maHoaDon = maHoaDon;
            this.maNhanVien = maNhanVien;
            this.ngayLap = ngayLap;
            this.maKhachHang = maKhachHang;
            this.tongTien = tongTien;
            this.tongSoLuong = tongSoLuong;
        }
    }
}
