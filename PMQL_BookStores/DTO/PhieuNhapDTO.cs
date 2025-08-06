using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class PhieuNhapDTO
    {
        private int maPhieuNhap;
        private int maNhanVien;
        private DateTime ngayNhap;
        private int maNhaCungCap;
        private decimal tongTien;
        private int tongSoLuong;

        public int MaPhieuNhap 
        { 
            get => maPhieuNhap; 
            set => maPhieuNhap = value; 
        }
        public int MaNhanVien 
        { 
            get => maNhanVien; 
            set => maNhanVien = value; 
        }
        public DateTime NgayNhap 
        { 
            get => ngayNhap; 
            set => ngayNhap = value; 
        }
        public int MaNhaCungCap 
        { 
            get => maNhaCungCap; 
            set => maNhaCungCap = value; 
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

        public PhieuNhapDTO(int maPhieuNhap,int maNhanVien, DateTime ngayNhap,int maNhaCungCap,decimal tongTien,int tongSoLuong)
        {
            this.maPhieuNhap = maPhieuNhap;
            this.maNhanVien = maNhanVien;
            this.ngayNhap = ngayNhap;
            this.maNhaCungCap = maNhaCungCap;
            this.tongTien = tongTien;
            this.tongSoLuong = tongSoLuong;
        }
    }
}
