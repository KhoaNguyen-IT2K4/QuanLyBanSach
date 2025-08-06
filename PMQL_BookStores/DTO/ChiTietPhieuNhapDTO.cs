using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class ChiTietPhieuNhapDTO
    {
        private int maPhieuNhap;
        private int maSach;
        private int soLuongNhap;
        private decimal giaThanh;
        //private decimal thanhTien;

        public int MaPhieuNhap 
        { 
            get => maPhieuNhap; 
            set => maPhieuNhap = value; 
        }
        public int MaSach 
        { 
            get => maSach; 
            set => maSach = value; 
        }
        public int SoLuongNhap 
        { 
            get => soLuongNhap; 
            set => soLuongNhap = value; 
        }
        public decimal GiaThanh 
        { 
            get => giaThanh; 
            set => giaThanh = value; 
        }
        //public decimal ThanhTien 
        //{ 
        //    get => thanhTien; 
        //    set => thanhTien = value; 
        //}

        public ChiTietPhieuNhapDTO(int maPhieuNhap,int maSach,int soLuongNhap,decimal giaThanh/*,decimal thanhTien*/)
        {
            this.maPhieuNhap = maPhieuNhap;
            this.maSach = maSach;
            this.soLuongNhap = soLuongNhap;
            this.giaThanh = giaThanh;
            //this.thanhTien = thanhTien;
        }
    }
}
