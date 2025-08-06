using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class ChiTietHoaDonDTO
    {
        private int maHoaDon;
        private int maSach;
        private int soLuongBan;
        private decimal giaThanh;
        //private decimal thanhTien;

        public int MaHoaDon 
        { 
            get => maHoaDon; 
            set => maHoaDon = value; 
        }
        public int MaSach 
        { 
            get => maSach; 
            set => maSach = value; 
        }
        public int SoLuongBan 
        { 
            get => soLuongBan; 
            set => soLuongBan = value; 
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

        public ChiTietHoaDonDTO(int maHoaDon,int maSach,int soLuongBan,decimal giaThanh/*,decimal thanhTien*/) 
        {
            this.maHoaDon = maHoaDon;
            this.maSach = maSach;
            this.soLuongBan = soLuongBan;
            this.giaThanh = giaThanh;
            //this.thanhTien = thanhTien;
        }
    }
}
