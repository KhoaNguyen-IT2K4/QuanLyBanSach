using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class TKNhapSachDTO
    {
        private string tenSach;
        private int soLuongNhap;

        public string TenSach 
        { 
            get => tenSach; 
            set => tenSach = value; 
        }
        public int SoLuongNhap 
        { 
            get => soLuongNhap; 
            set => soLuongNhap = value; 
        }

        public TKNhapSachDTO(string tenSach,int soLuongNhap)
        {
            this.tenSach = tenSach;
            this.soLuongNhap = soLuongNhap;
        }
    }
}
