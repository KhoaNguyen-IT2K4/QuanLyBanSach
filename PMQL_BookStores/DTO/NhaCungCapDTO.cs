using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class NhaCungCapDTO
    {
        private int maNhaCungCap;
        private string tenNhaCungCap;
        private string diaChi;
        private int dienThoai;

        public int MaNhaCungCap 
        { 
            get => maNhaCungCap; 
            set => maNhaCungCap = value; 
        }
        public string TenNhaCungCap 
        { 
            get => tenNhaCungCap; 
            set => tenNhaCungCap = value; 
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

        public NhaCungCapDTO(int maNhaCungCap,string tenNhaCungCap,string diaChi,int dienThoai)
        {
            this.maNhaCungCap = maNhaCungCap;
            this.tenNhaCungCap = tenNhaCungCap;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
        }
    }
}
