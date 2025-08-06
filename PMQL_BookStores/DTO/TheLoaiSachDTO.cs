using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class TheLoaiSachDTO
    {
        private int maLoaiSach;
        private string tenLoai;

        public int MaLoaiSach 
        { 
            get => maLoaiSach; 
            set => maLoaiSach = value; 
        }
        public string TenLoai 
        { 
            get => tenLoai; 
            set => tenLoai = value; 
        }

        public TheLoaiSachDTO(int maLoaiSach,string tenLoai)
        {
            this.maLoaiSach = maLoaiSach;
            this.tenLoai = tenLoai;
        }
    }
}
