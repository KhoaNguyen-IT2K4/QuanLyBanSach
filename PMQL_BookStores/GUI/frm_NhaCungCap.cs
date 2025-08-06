using PMQL_BookStores.BUS;
using PMQL_BookStores.DAL;
using PMQL_BookStores.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PMQL_BookStores.GUI
{
    public partial class frm_NhaCungCap : Form
    {
        string mancc = "";
        public frm_NhaCungCap()
        {
            InitializeComponent();
        }

        private void txtSDTNCC_KeyPress(object sender, KeyPressEventArgs e) // Thiết lập không cho người dùng nhập chữ vào ô nhập số điện thoại
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenNCC_KeyPress(object sender, KeyPressEventArgs e) // Thiết lập không cho người dùng nhập số vào ô nhập tên
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void frm_NhaCungCap_Load(object sender, EventArgs e)
        {
            NhaCungCapBUS.Instance.HienThiDanhSachNhaCungCap(dtgvAddNCC); // Gửi datagridview lên tầng BUS xử lý
        }

        private void picAddNCC_Click(object sender, EventArgs e) // Hàm xử lý nhấn thêm
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtTenNCC.Text) && !string.IsNullOrEmpty(txtDiaChiNCC.Text) && !string.IsNullOrEmpty(txtSDTNCC.Text))
            {
                List<NhaCungCapDTO> nhacungcap = new List<NhaCungCapDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                NhaCungCapDTO NCC = new NhaCungCapDTO(0, txtTenNCC.Text, txtDiaChiNCC.Text, int.Parse(txtSDTNCC.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                nhacungcap.Add(NCC); // Thêm vào list

                NhaCungCapBUS.Instance.ThemNhaCungCap(nhacungcap, dtgvAddNCC); // Gửi lên tầng BUS xử lý
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picDelNCC_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn xóa
        {
            // Kiểm tra biến cục bộ mã nhà cung cấp khác rỗng mới thực hiện
            if (dtgvAddNCC.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NhaCungCapBUS.Instance.XoaNhaCungCap(dtgvAddNCC);
            }
        }

        private void picUDNCC_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn cập nhật
        {
            if(dtgvAddNCC.SelectedRows.Count > 0)
            {
                // Kiểm tra khác rỗng mới thực hiện
                if (!string.IsNullOrEmpty(txtTenNCC.Text) && !string.IsNullOrEmpty(txtDiaChiNCC.Text) && !string.IsNullOrEmpty(txtSDTNCC.Text))
                {
                    List<NhaCungCapDTO> nhacungcap = new List<NhaCungCapDTO>(); // Khởi tạo đối tượng list kiểu class NhaCungCapDTO

                    NhaCungCapDTO NCC = new NhaCungCapDTO(0, txtTenNCC.Text, txtDiaChiNCC.Text, int.Parse(txtSDTNCC.Text)); // Khởi tạo đối tượng NhaCungCapDTO

                    nhacungcap.Add(NCC); // Thêm vào list

                    NhaCungCapBUS.Instance.CapNhatNhaCungCap(nhacungcap, dtgvAddNCC); // Gửi datagridview lên tầng BUS xử lý
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn nhà cung cấp cần chỉnh sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void picSearchNCC_Click(object sender, EventArgs e) // Hàm xử lý khi tìm kiếm
        {
            // Kiểm tra khác rỗng mới thực hiện
            if (!string.IsNullOrEmpty(txtSearchNCC.Text))
            {
                // Hiển thị dữ liệu của kết quả tìm kiếm lên datagridview
                NhaCungCapBUS.Instance.SearchNhaCungCap(txtSearchNCC, dtgvAddNCC);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                NhaCungCapBUS.Instance.HienThiDanhSachNhaCungCap(dtgvAddNCC);
            }
        }

        private void txtSearchNCC_KeyPress(object sender, KeyPressEventArgs e) // Hàm xử lý khi nhấn enter trong ô tìm kiếm
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                picSearchNCC_Click(sender, e);
            }
            else
            {
                // Hiển thị dữ liệu mặc định lên datagridview
                NhaCungCapBUS.Instance.HienThiDanhSachNhaCungCap(dtgvAddNCC);
            }
        }

        private void picClearNCC_Click(object sender, EventArgs e) // Hàm xử lý khi nhấn dọn dẹp
        {
            // Đặt tất cả các control về mặc định
            txtTenNCC.Text = txtDiaChiNCC.Text = txtSDTNCC.Text = txtSearchNCC.Text = "";
            dtgvAddNCC.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview

            MessageBox.Show("Đã làm mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frm_NhaCungCap_Shown(object sender, EventArgs e) // Khi form hiển thị thì bỏ chọn tất cả các dòng trong datagridview
        {
            dtgvAddNCC.ClearSelection(); // Bỏ chọn tất cả các dòng trong datagridview
        }

        private void dtgvAddNCC_CellClick(object sender, DataGridViewCellEventArgs e) // Thiết lập lấy giá trị trong datagridview lên các control
        {
            int i = dtgvAddNCC.CurrentRow.Index;
            mancc = dtgvAddNCC.Rows[i].Cells[0].Value.ToString();
            txtTenNCC.Text = dtgvAddNCC.Rows[i].Cells[1].Value.ToString();
            txtDiaChiNCC.Text = dtgvAddNCC.Rows[i].Cells[2].Value.ToString();
            txtSDTNCC.Text = dtgvAddNCC.Rows[i].Cells[3].Value.ToString();
        }
    }
}
