using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQL_BookStores.DTO
{
    public class NhanVienDTO
    {
        private int maNhanVien;
        private string hoNhanVien;
        private string tenLotNhanVien;
        private string tenNhanVien;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string diaChi;
        private int dienThoai;
        private string chucVu;

        public int MaNhanVien 
        { 
            get => maNhanVien; 
            set => maNhanVien = value; 
        }
        public string HoNhanVien 
        { 
            get => hoNhanVien; 
            set => hoNhanVien = value; 
        }
        public string TenLotNhanVien 
        { 
            get => tenLotNhanVien; 
            set => tenLotNhanVien = value; 
        }
        public string TenNhanVien 
        { 
            get => tenNhanVien; 
            set => tenNhanVien = value; 
        }
        public string GioiTinh 
        { 
            get => gioiTinh; 
            set => gioiTinh = value; 
        }
        public DateTime NgaySinh 
        { 
            get => ngaySinh; 
            set => ngaySinh = value; 
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
        public string ChucVu 
        { 
            get => chucVu; 
            set => chucVu = value; 
        }

        public NhanVienDTO(int maNhanVien,string hoNhanVien,string tenLotNhanVien,string tenNhanVien,string gioiTinh,DateTime ngaySinh,string diaChi,int dienThoai,string chucVu)
        {
            this.maNhanVien = maNhanVien;
            this.hoNhanVien = hoNhanVien;
            this.tenLotNhanVien = tenLotNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.chucVu = chucVu;
        }
    }
}
