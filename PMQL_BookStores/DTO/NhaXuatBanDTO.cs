using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class NhaXuatBanDTO
    {
        private int maNhaXuatBan;
        private string tenNhaXuatBan;
        private string diaChi;

        public int MaNhaXuatBan 
        { 
            get => maNhaXuatBan; 
            set => maNhaXuatBan = value; 
        }
        public string TenNhaXuatBan 
        { 
            get => tenNhaXuatBan; 
            set => tenNhaXuatBan = value; 
        }
        public string DiaChi 
        { 
            get => diaChi; 
            set => diaChi = value; 
        }

        public NhaXuatBanDTO(int maNhaXuatBan,string tenNhaXuatBan,string diaChi)
        {
            this.maNhaXuatBan = maNhaXuatBan;
            this.tenNhaXuatBan = tenNhaXuatBan;
            this.diaChi = diaChi;
        }
    }
}
