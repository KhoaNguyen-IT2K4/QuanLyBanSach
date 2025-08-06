using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class SachDTO
    {
        private int maSach;
        private string tenSach;
        private string tacGia;
        private int maLoaiSach;
        private int maNhaXuatBan;
        private decimal donGiaNhap;
        private decimal donGiaBan;
        private int soTrang;
        private decimal trongLuong;
        private string hinhAnh;
        private int soLuong;

        public int MaSach 
        { 
            get => maSach; 
            set => maSach = value; 
        }
        public string TenSach 
        { 
            get => tenSach; 
            set => tenSach = value; 
        }
        public string TacGia 
        { 
            get => tacGia; 
            set => tacGia = value; 
        }
        public int MaLoaiSach 
        { 
            get => maLoaiSach; 
            set => maLoaiSach = value; 
        }
        public int MaNhaXuatBan 
        { 
            get => maNhaXuatBan; 
            set => maNhaXuatBan = value; 
        }
        public decimal DonGiaNhap 
        { 
            get => donGiaNhap; 
            set => donGiaNhap = value; 
        }
        public decimal DonGiaBan 
        { 
            get => donGiaBan; 
            set => donGiaBan = value; 
        }
        public int SoTrang 
        { 
            get => soTrang; 
            set => soTrang = value; 
        }
        public decimal TrongLuong 
        { 
            get => trongLuong; 
            set => trongLuong = value; 
        }
        public string HinhAnh 
        { 
            get => hinhAnh; 
            set => hinhAnh = value; 
        }
        public int SoLuong 
        { 
            get => soLuong; 
            set => soLuong = value; 
        }

        public SachDTO(int maSach,string tenSach,string tacGia,int maLoaiSach,int maNhaXuatBan,decimal donGiaNhap,decimal donGiaBan,int soTrang,decimal trongLuong,string hinhAnh,int soLuong)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.tacGia = tacGia;
            this.maLoaiSach = maLoaiSach;
            this.maNhaXuatBan = maNhaXuatBan;
            this.donGiaNhap = donGiaNhap;
            this.donGiaBan = donGiaBan;
            this.soTrang = soTrang;
            this.trongLuong = trongLuong;
            this.hinhAnh = hinhAnh;
            this.soLuong = soLuong;
        }
    }
}
