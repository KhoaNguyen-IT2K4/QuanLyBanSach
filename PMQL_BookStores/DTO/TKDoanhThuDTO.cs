using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class TKDoanhThuDTO
    {
        private string hinhAnh;
        private string tenSach;
        private int soLuongBan;
        private decimal giaThanh;
        private decimal thanhTien;

        public string HinhAnh 
        { 
            get => hinhAnh; 
            set => hinhAnh = value; 
        }
        public string TenSach 
        { 
            get => tenSach; 
            set => tenSach = value; 
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
        public decimal ThanhTien 
        { 
            get => thanhTien; 
            set => thanhTien = value; 
        }

        public TKDoanhThuDTO(string hinhAnh,string tenSach,int soLuongBan,decimal giaThanh,decimal thanhTien)
        {
            this.hinhAnh = hinhAnh;
            this.tenSach = tenSach;
            this.soLuongBan = soLuongBan;
            this.giaThanh = giaThanh;
            this.thanhTien = thanhTien;
        }
    }
}
