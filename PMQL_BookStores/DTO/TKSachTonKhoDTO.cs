using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class TKSachTonKhoDTO
    {
        private string hinhAnh;
        private string tenSach;
        private int soLuong;

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
        public int SoLuong 
        { 
            get => soLuong; 
            set => soLuong = value; 
        }

        public TKSachTonKhoDTO(string hinhAnh,string tenSach,int soLuong)
        {
            this.hinhAnh = hinhAnh;
            this.tenSach = tenSach;
            this.soLuong = soLuong;
        }
    }
}
