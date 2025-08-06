using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class TKBanSachDTO
    {
        private string hinhAnh;
        private string tenSach;
        private int soLuongBan;

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

        public TKBanSachDTO(string hinhAnh,string tenSach,int soLuongBan)
        {
            this.hinhAnh = hinhAnh;
            this.tenSach = tenSach;
            this.soLuongBan = soLuongBan;
        }
    }
}
