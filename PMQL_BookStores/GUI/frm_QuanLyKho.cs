using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMQL_BookStores
{
    public partial class frm_QuanLyKho : Form
    {
        public bool CheckExit = true; // Biến xét điều kiện đóng form
        public string connectionString = "Data Source=LAPTOP-60SQJEQ9\\SQLEXPRESS;Initial Catalog=BookStores;Integrated Security=True";
        public string SelectNXS = "SELECT * FROM NhaXuatBan";
        public string SelectNCC = "SELECT * FROM NhaCungCap";
        public string SelectPN = "SELECT * FROM PhieuNhap";
        public string SelectCTPN = "SELECT * FROM ChiTietPN";
        public string SelectNV = "SELECT * FROM NhanVien";
        public string SelectSach = "SELECT * FROM Sach";
        public string SelectLoaiSach = "SELECT * FROM TheLoaiSach";
        int TongSoLuong = 0;
        decimal TongThanhTien = 0;
        string img = "";
        string selectedImagePath = "";
        private bool cellClicked = false;

        public frm_QuanLyKho()
        {
            InitializeComponent();
        }

        public event EventHandler DangXuatQLK; // Tạo even ủy thác form quản lý kho

        public event EventHandler ThoatFormQLK;

        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frm_QuanLyKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CheckExit) // Nếu điều kiện đúng thì đsong form
            {
                ThoatFormQLK(this, new EventArgs());
                Application.Exit();
            }
        }

        private void btnDangXuatQLK_Click(object sender, EventArgs e)
        {
            DangXuatQLK(this, new EventArgs()); // sử dụng mở even ủy thác ở các form khác
        }

        private void frm_QuanLyKho_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Xin chào Quản Lý Kho", "Đăng Nhập Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information); // Hiện hộp thoại xin chào
            HienDsNXB(SelectNXS);
            HienDSNCC(SelectNCC);
            HienDsPN(SelectPN);
            HienDsCTPN(SelectCTPN);
            HienDSLoaiSach(SelectLoaiSach);
            HienDsSach(SelectSach);

            LoadNCCIntoCbx(SelectNCC);
            LoadNVPNIntoCbx(SelectNV);
            LoadMPNIntoCbx(SelectPN);
            LoadMaSachIntoCbx(SelectSach);
            LoadLoaiSachIntoCbx(SelectLoaiSach);
            LoaiNXBIntoCbx(SelectNXS);
        }

        private void btnAdd_NXB_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenNXB.Text) || string.IsNullOrWhiteSpace(txt_NXBDChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cho nhà xuất bản.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlConnection connection = new SqlConnection(connectionString);

            string tenNXB = txt_TenNXB.Text;
            string dChi = txt_NXBDChi.Text;
            string sql = "INSERT INTO NhaXuatBan (TenNXB, DiaChi) VALUES (@TenNXB, @DChi)";

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenNXB", tenNXB);
                    command.Parameters.AddWithValue("@DChi", dChi);
                    command.ExecuteNonQuery();
                }
                HienDsNXB(SelectNXS);
                MessageBox.Show("Đã thêm thành công", "THÔNG BÁO", MessageBoxButtons.OK);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void HienDSNCC(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter ds = new SqlDataAdapter(sql, connection);
                DataSet dsach = new DataSet();
                ds.Fill(dsach);

                grid_NCC.DataSource = dsach.Tables[0];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            txt_TenNCC.Text = "";
            txt_DchiNCC.Text = "";
            txt_SDTNCC.Text = "";
        }
        public void HienDsNXB(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter ds = new SqlDataAdapter(sql, connection);
                DataSet dsach = new DataSet();
                ds.Fill(dsach);

                grid_NXB.DataSource = dsach.Tables[0];

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            txt_TenNCC.Text = "";
            txt_DchiNCC.Text = "";
            txt_TenNXB.Text = "";
            txt_NXBDChi.Text = "";
        }
        public void HienDsPN(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter ds = new SqlDataAdapter(sql, connection);
                DataSet dsach = new DataSet();
                ds.Fill(dsach);

                grid_PN.DataSource = dsach.Tables[0];

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void HienDsCTPN(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter ds = new SqlDataAdapter(sql, connection);
                DataSet dsach = new DataSet();
                ds.Fill(dsach);

                grid_CTPN.DataSource = dsach.Tables[0];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            cbx_MaPN.SelectedIndex = -1;
            cbx_MS.SelectedIndex = -1;
            txtSLNhap.Text = "";
            txtDonGia.Text = "";
        }

        public void HienDSLoaiSach(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter ds = new SqlDataAdapter(sql, connection);
                DataSet dsach = new DataSet();
                ds.Fill(dsach);

                grid_LoaiSach.DataSource = dsach.Tables[0];

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            txt_TenNCC.Text = "";
            txt_DchiNCC.Text = "";
            txt_SDTNCC.Text = "";
        }
        public void HienDsSach(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                SqlDataAdapter ds = new SqlDataAdapter(sql, connection);
                DataSet dsach = new DataSet();
                ds.Fill(dsach);

                grid_Sach.DataSource = dsach.Tables[0];

                connection.Close ();
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void XoaNCC(int MaNCC)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "DELETE FROM NhaCungCap WHERE MaNCC = @maNCC";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@maNCC", MaNCC);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void XoaNXB(int MaNXB)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "DELETE FROM NhaXuatBan WHERE MaNXB = @maNXB";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@maNXB", MaNXB);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void XoaLoaiSach(int MaLoai)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "DELETE FROM TheLoaiSach WHERE MaLoaiSach = @maloai";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@maloai", MaLoai);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void XoaCTPN(int MaPN)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "DELETE FROM ChiTietPN WHERE MaPN = @maPN";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@maPN", MaPN);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDel_NXB_Click(object sender, EventArgs e)
        {

            if (grid_NXB.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_NXB.SelectedRows[0];

                // cột đầu tiên chứa MaNXB, có thể truy cập giá trị của cột này
                int maNXB = Convert.ToInt32(selectedRow.Cells["MaNXB"].Value);
                DialogResult dlq = MessageBox.Show("Bạn có muốn xoá?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlq == DialogResult.Yes)
                {
                    XoaNXB(maNXB);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                grid_NXB.Rows.Remove(selectedRow);
                HienDsNXB(SelectNXS);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_TenNXB.Text = "";
            txt_NXBDChi.Text = "";
            HienDsNXB(SelectNXS);
        }

        public void ThoatChuongTrinh(object sender, EventArgs e)
        {
            DialogResult dlq = MessageBox.Show("Bạn có muốn thoát chương trình?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlq == DialogResult.Yes)
            {
                Close();
            }
        }

        private void cbx_TK_NXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_TK_NXB.SelectedItem == "Tìm theo Tên")
            {
                txt_TimKiem_NXB.Name = "txt_TimTen_NXB";
            }
            else
            {
                txt_TimKiem_NXB.Name = "txt_TimDChi_NXB";
            }
        }

        private void btn_Tk_NXB_Click(object sender, EventArgs e)
        {
            string name = txt_TimKiem_NXB.Name;
            string tk = txt_TimKiem_NXB.Text;

            if ((name == "txt_TimTen_NXB"))
            {
                HienDsNXB("SELECT * FROM NhaXuatBan WHERE TenNXB LIKE N'%" + tk + "%'");
            }
            else
            {
                HienDsNXB("SELECT * FROM NhaXuatBan WHERE DiaChi LIKE N'%" + tk + "%'");
            }
        }

        private void btnFix_NXB_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (grid_NXB.SelectedRows.Count > 0)
                {
                    // Lấy dòng dữ liệu đầu tiên được chọn
                    DataGridViewRow selectedRow = grid_NXB.SelectedRows[0];

                    string tenNXB = txt_TenNXB.Text;
                    string dChi = txt_NXBDChi.Text;

                    // Cập nhật dữ liệu của dòng được chọn từ các TextBox
                    selectedRow.Cells["TenNXB"].Value = tenNXB;
                    selectedRow.Cells["DiaChi"].Value = dChi;

                    SqlConnection connection = new SqlConnection(connectionString);

                    int maNXB = Convert.ToInt32(selectedRow.Cells["MaNXB"].Value);

                    try
                    {
                        connection.Open();

                        string sql = "UPDATE NhaXuatBan SET TenNXB = @tenNXB, DiaChi = @dChi WHERE MaNXB = @maNXB";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@tenNXB", tenNXB);
                            command.Parameters.AddWithValue("@dchi", dChi);
                            command.Parameters.AddWithValue("@maNXB", maNXB);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                    MessageBox.Show("Đã sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                    // Xóa dữ liệu từ các TextBox sau khi đã cập nhật
                    txt_TenNXB.Clear();
                    txt_NXBDChi.Clear();
                    HienDsNXB(SelectNXS);
                }
            }
        }

        private void grid_NXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            if (grid_NXB.SelectedRows.Count > 0)
            {
                // Lấy dòng dữ liệu đầu tiên được chọn
                DataGridViewRow selectedRow = grid_NXB.SelectedRows[0];

                // Lấy dữ liệu từ các cột trong dòng được chọn
                string tenNXB = selectedRow.Cells["TenNXB"].Value.ToString();
                string DChi = selectedRow.Cells["DiaChi"].Value.ToString();

                // Hiển thị dữ liệu lên các TextBox
                txt_TenNXB.Text = tenNXB;
                txt_NXBDChi.Text = DChi;
            }
        }
        //
        //Tab Nhà Cung Cấp
        //
        private void btnAdd_NCC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenNCC.Text) ||
                string.IsNullOrWhiteSpace(txt_DchiNCC.Text) ||
                string.IsNullOrWhiteSpace(txt_SDTNCC.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cho nhà cung cấp.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu có điều kiện không đạt
            }
            SqlConnection connection = new SqlConnection(connectionString);

            string tenNCC = txt_TenNCC.Text;
            string dChi = txt_DchiNCC.Text;
            int SDT = int.Parse(txt_SDTNCC.Text);
            string sql = "INSERT INTO NhaCungCap (TenNCC, DiaChi,DienThoai) VALUES (@TenNCC, @DiaChi,@DienThoai)";

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenNCC", tenNCC);
                    command.Parameters.AddWithValue("@DiaChi", dChi);
                    command.Parameters.AddWithValue("@DienThoai", SDT);
                    command.ExecuteNonQuery();
                }
                HienDSNCC(SelectNCC);
                MessageBox.Show("Đã thêm thành công", "THÔNG BÁO", MessageBoxButtons.OK);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void grid_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            if (grid_NCC.SelectedRows.Count > 0)
            {
                // Lấy dòng dữ liệu đầu tiên được chọn
                DataGridViewRow selectedRow = grid_NCC.SelectedRows[0];

                // Lấy dữ liệu từ các cột trong dòng được chọn
                string tenNCC = selectedRow.Cells["TenNCC"].Value.ToString();
                string DChi = selectedRow.Cells["DiaChi"].Value.ToString();
                string SDT = selectedRow.Cells["DienThoai"].Value.ToString();

                // Hiển thị dữ liệu lên các TextBox
                txt_TenNCC.Text = tenNCC;
                txt_DchiNCC.Text = DChi;
                txt_SDTNCC.Text = SDT;
            }
        }

        private void btnDel_NCC_Click(object sender, EventArgs e)
        {
            if (grid_NCC.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_NCC.SelectedRows[0];

                // cột đầu tiên chứa MaNXB, có thể truy cập giá trị của cột này
                int maNCC = Convert.ToInt32(selectedRow.Cells["MaNCC"].Value);
                DialogResult dlq = MessageBox.Show("Bạn có muốn xoá?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlq == DialogResult.Yes)
                {
                    XoaNCC(maNCC);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                grid_NCC.Rows.Remove(selectedRow);
                HienDSNCC(SelectNCC);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLM_NCC_Click(object sender, EventArgs e)
        {
            txt_TenNCC.Text = "";
            txt_DchiNCC.Text = "";
            txt_SDTNCC.Text = "";
            HienDSNCC(SelectNCC);
        }

        private void cbx_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_NCC.SelectedItem == "Tìm theo Tên")
            {
                txtTK_NCC.Name = "txt_TimTen_NCC";
            }
            else
            {
                txtTK_NCC.Name = "txt_TimDChi_NCC";
            }
        }

        private void btnTK_NCC_Click(object sender, EventArgs e)
        {
            string name = txtTK_NCC.Name;
            string tk = txtTK_NCC.Text;

            if ((name == "txt_TimTen_NCC"))
            {
                HienDSNCC("SELECT * FROM NhaCungCap WHERE TenNCC LIKE N'%" + tk + "%'");
            }
            else
            {
                HienDSNCC("SELECT * FROM NhaCungCap WHERE DiaChi LIKE N'%" + tk + "%'");
            }
        }

        private void btnFix_NCC_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (grid_NCC.SelectedRows.Count > 0)
            {
                // Lấy dòng dữ liệu đầu tiên được chọn
                DataGridViewRow selectedRow = grid_NCC.SelectedRows[0];

                string tenNCC = txt_TenNCC.Text;
                string dChi = txt_DchiNCC.Text;
                int SDT = int.Parse(txt_SDTNCC.Text);

                // Cập nhật dữ liệu của dòng được chọn từ các TextBox
                selectedRow.Cells["TenNCC"].Value = tenNCC;
                selectedRow.Cells["DiaChi"].Value = dChi;
                selectedRow.Cells["DienThoai"].Value = SDT;

                SqlConnection connection = new SqlConnection(connectionString);

                int maNCC = Convert.ToInt32(selectedRow.Cells["MaNCC"].Value);

                try
                {
                    connection.Open();

                    string sql = "UPDATE NhaCungCap SET TenNCC = @tenNCC, DiaChi = @dChi, DienThoai = @sdt WHERE MaNCC = @maNCC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tenNCC", tenNCC);
                        command.Parameters.AddWithValue("@dchi", dChi);
                        command.Parameters.AddWithValue("@sdt", SDT);
                        command.Parameters.AddWithValue("@maNCC", maNCC);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                MessageBox.Show("Đã sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                // Xóa dữ liệu từ các TextBox sau khi đã cập nhật
                txt_TenNCC.Clear();
                txt_DchiNCC.Clear();
                txt_SDTNCC.Clear();
                HienDSNCC(SelectNCC);
            }
        }
        //
        // Tab Phiếu Nhập
        //
        public void LoadNCCIntoCbx(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int maNCC = reader.GetInt32(0);
                        string tenNCC = reader.GetString(1);
                        cbxNCC_PN.Items.Add(new KeyValuePair<int, string>(maNCC, tenNCC));
                    }

                    reader.Close();
                    connection.Close();
                }
                // Thiết lập hiển thị và giá trị cho ComboBox
                cbxNCC_PN.DisplayMember = "Value"; // Hiển thị tên nhà cung cấp
                cbxNCC_PN.ValueMember = "Key"; // Sử dụng mã nhà cung cấp làm giá trị

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void LoadNVPNIntoCbx(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.GetString(8) == "Quản Lý Kho")
                        {
                            int maNV = reader.GetInt32(0);
                            string hoNV = reader.GetString(1);
                            string tenLot = reader.GetString(2);
                            string tenNV = reader.GetString(3);
                            string hoTen = hoNV + tenLot + tenNV;
                            cbx_NVPN.Items.Add(new KeyValuePair<int, string>(maNV, hoTen));
                        }
                    }

                    reader.Close();
                    connection.Close();
                }
                cbx_NVPN.DisplayMember = "Value";
                cbx_NVPN.ValueMember = "Key";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnAdd_PN_Click(object sender, EventArgs e)
        {
            if (cbxNCC_PN.SelectedIndex == -1 || cbx_NVPN.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp và nhân viên phụ trách.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu có điều kiện không đạt
            }
            SqlConnection connection = new SqlConnection(connectionString);

            DateTime ngLap = time_PN.Value;
            KeyValuePair<int, string> selectedNCC = (KeyValuePair<int, string>)cbxNCC_PN.SelectedItem;
            int Ncc = selectedNCC.Key;
            KeyValuePair<int, string> selectedNV = (KeyValuePair<int, string>)cbx_NVPN.SelectedItem;
            int nv = selectedNV.Key;

         
            string sql_PN = "INSERT INTO PhieuNhap (MaNV, NgayNhap, MaNCC) VALUES (@MaNV, @NgayNhap, @MaNCC)";
          
            try
            {
                connection.Open();

                int maPN;
                using (SqlCommand commandPN = new SqlCommand(sql_PN, connection))
                {
                    commandPN.Parameters.AddWithValue("@MaNV", nv);
                    commandPN.Parameters.AddWithValue("@NgayNhap", ngLap);
                    commandPN.Parameters.AddWithValue("@MaNCC", Ncc);

                   commandPN.ExecuteNonQuery();
                }
                LayMaPNMoiNhat();
                HienDsPN(SelectPN);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void LayMaPNMoiNhat()
        {
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Truy vấn để lấy mã PN mới nhất
                    string sqlLatestPN = "SELECT TOP 1 MaPN FROM PhieuNhap ORDER BY MaPN DESC";

                    using (SqlCommand commandLatestPN = new SqlCommand(sqlLatestPN, connection))
                    {
                        // Thực thi truy vấn và lấy kết quả
                        int latestPN = Convert.ToInt32(commandLatestPN.ExecuteScalar());

                        // Thêm mã PN mới nhất vào ComboBox
                        cbx_MaPN.Items.Add(latestPN);
                        cbx_MaPN.Text = latestPN.ToString();
                    }

                    // Đóng kết nối
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        public void XoaPN(int MaNXB)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "DELETE FROM PhieuNhap WHERE MaPN = @maPN";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@maPN", MaNXB);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDel_PN_Click(object sender, EventArgs e)
        {
            if (grid_PN.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_PN.SelectedRows[0];

                // cột đầu tiên chứa MaNXB, có thể truy cập giá trị của cột này
                int maPN = Convert.ToInt32(selectedRow.Cells["MaPN"].Value);
                DialogResult dlq = MessageBox.Show("Bạn có muốn xoá?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlq == DialogResult.Yes)
                {
                    XoaPN(maPN);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                grid_PN.Rows.Remove(selectedRow);
                HienDSNCC(SelectNCC);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grid_PN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Kiểm tra xem cell được click có hợp lệ không
            {
                DataGridViewCell selectedCell = grid_PN.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (selectedCell != null && selectedCell.Value != null && !string.IsNullOrEmpty(selectedCell.Value.ToString()))
                {
                    // Lấy dòng dữ liệu được chọn
                    DataGridViewRow selectedRow = grid_PN.Rows[e.RowIndex];

                    // Kiểm tra nếu dòng được chọn không null và có dữ liệu
                    if (selectedRow != null && selectedRow.Cells.Count > 0 && selectedRow.Cells[1].Value != null && selectedRow.Cells[2].Value != null &&
                        selectedRow.Cells[3].Value != null && selectedRow.Cells[4].Value != null && selectedRow.Cells[5].Value != null)
                    {
                        // Lấy dữ liệu từ các cột trong dòng được chọn
                        int maNV, maNCC;
                        int TongSl;
                        decimal TongTien;
                        DateTime ngNhap;

                        if (int.TryParse(selectedRow.Cells[1].Value.ToString(), out maNV) &&
                            int.TryParse(selectedRow.Cells[3].Value.ToString(), out maNCC) &&
                            DateTime.TryParse(selectedRow.Cells[2].Value.ToString(), out ngNhap) &&
                            int.TryParse(selectedRow.Cells[5].Value.ToString(), out TongSl) &&
                            decimal.TryParse(selectedRow.Cells[4].Value.ToString(), out TongTien))
                        {
                            string tenNV = FindNV(maNV);
                            string tenNCC = FindNCC(maNCC);

                            // Hiển thị dữ liệu lên các TextBox và ComboBox
                            cbxNCC_PN.Text = tenNCC;
                            cbx_NVPN.Text = tenNV;
                            time_PN.Value = ngNhap;
                            txt_TongSL_PN.Text = TongSl.ToString();
                            txt_TongTien_PN.Text = TongTien.ToString();

                        }
                        else
                        {
                            MessageBox.Show("Không thể lấy dữ liệu từ dòng được chọn.");
                        }
                    }
                    else
                    {

                        MessageBox.Show("Dòng được chọn không có dữ liệu.");
                    }
                }
                else
                {
                    time_PN.Value = DateTime.Now;
                    cbxNCC_PN.SelectedIndex = -1;
                    cbx_NVPN.SelectedIndex = -1;
                    txtTK_PN.Text = "";
                    //MessageBox.Show("Cell được chọn không có dữ liệu.");
                }
            }
        }

        private string FindNV(int manv)
        {
            string kq = "";

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT nv.HoNV + nv.TenLotNV + nv.TenNV as [tên nhân viên] FROM NhanVien nv INNER JOIN PhieuNhap pn ON nv.MaNV = pn.MaNV WHERE pn.MaNV = @manv";
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@manv", manv);
                    // Sử dụng ExecuteScalar để lấy tên nhân viên
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        kq = result.ToString();
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return kq;
        }
        private string FindNCC(int maNCC)
        {
            string kq = "";

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT ncc.TenNCC as [tên nhà cung cấp] FROM NhaCungCap ncc INNER JOIN PhieuNhap pn ON ncc.MaNCC = pn.MaNCC WHERE pn.MaNCC = @maNCC";
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@maNCC", maNCC);
                    // Sử dụng ExecuteScalar để lấy tên nhân viên
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        kq = result.ToString();
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return kq;
        }

        private void btnLM_PN_Click(object sender, EventArgs e)
        {
            HienDsPN(SelectPN);
            time_PN.Value = DateTime.Now;
            cbxNCC_PN.SelectedIndex = -1;
            cbx_NVPN.SelectedIndex = -1;
            txtTK_PN.Text = "";
            txt_TongSL_PN.Text = "";
            txt_TongTien_PN.Text = "";
        }

        private void btnFix_PN_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (grid_PN.SelectedRows.Count > 0)
            {
                // Lấy dòng dữ liệu đầu tiên được chọn
                DataGridViewRow selectedRow = grid_PN.SelectedRows[0];

                KeyValuePair<int, string> selectedNCC = (KeyValuePair<int, string>)cbxNCC_PN.SelectedItem;
                int maNCC = selectedNCC.Key;
                KeyValuePair<int, string> selectedNV = (KeyValuePair<int, string>)cbx_NVPN.SelectedItem;
                int maNV = selectedNV.Key;

                DateTime ngNhap = time_PN.Value;

             
                // Cập nhật dữ liệu của dòng được chọn từ các TextBox
                selectedRow.Cells["MaNV"].Value = maNV;
                selectedRow.Cells["NgayNhap"].Value = ngNhap;
                selectedRow.Cells["MaNCC"].Value = maNCC;

                SqlConnection connection = new SqlConnection(connectionString);

                int maPN = Convert.ToInt32(selectedRow.Cells["MaPN"].Value);

                try
                {
                    connection.Open();

                    string sql = "UPDATE PhieuNhap SET MaNV = @manv, NgayNhap = @ngnhap, MaNCC = @mncc WHERE MaPN = @mapn";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@mapn", maPN);
                        command.Parameters.AddWithValue("@manv", maNV);
                        command.Parameters.AddWithValue("@ngnhap", ngNhap);
                        command.Parameters.AddWithValue("@mncc", maNCC);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                MessageBox.Show("Đã sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK);
                // Xóa dữ liệu từ các TextBox sau khi đã cập nhật
                cbxNCC_PN.SelectedIndex = -1;
                cbx_NVPN.SelectedIndex = -1;
            }
        }

        private void cbxTK_PN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTK_PN.SelectedItem == "Tìm theo Mã Phiếu Nhập")
            {
                txtTK_PN.Name = "txtTK_MaPN";
            }
            else if (cbxTK_PN.SelectedItem == "Tìm theo Mã Nhân Viên")
            {
                txtTK_PN.Name = "txtTK_MaNV";
            }
            else if (cbxTK_PN.SelectedItem == "Tìm theo Mã Nhà Cung Cấp")
            {
                txtTK_PN.Name = "txtTK_MaNCC";
            }
            else
            {
                txtTK_PN.Visible = false;
                timeTK_PN.Visible = true;
            }
        }

        private void btnTK_PN_Click(object sender, EventArgs e)
        {
            string name = txtTK_PN.Name;

            if (name == "txtTK_MaPN")
            {
                int tk = int.Parse(txtTK_PN.Text);
                HienDsPN("SELECT * FROM PhieuNhap WHERE MaPN = " + tk);
            }
            else if (name == "txtTK_MaNV")
            {
                int tk = int.Parse(txtTK_PN.Text);
                HienDsPN("SELECT * FROM PhieuNhap WHERE MaNV = " + tk);
            }
            else if (name == "txtTK_MaNCC")
            {
                int tk = int.Parse(txtTK_PN.Text);
                HienDsPN("SELECT * FROM PhieuNhap WHERE MaNCC = " + tk);
            }
            else
            {
                DateTime ngNhap = timeTK_PN.Value;
                HienDsPN("SELECT * FROM PhieuNhap WHERE NgayNhap = '" + ngNhap+"'");
            }
        }
        //
        // tab Chi tiết phiếu nhập
        //
        public void LoadMPNIntoCbx(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int maPN = reader.GetInt32(0);
                        cbx_MaPN.Items.Add(maPN);
                    }

                    reader.Close();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void LoadMaSachIntoCbx(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int maSach = reader.GetInt32(0);
                        string tenSach = reader.GetString(1);
                        cbx_MS.Items.Add(maSach);
                        cbx_MS.Items.Add(maSach);
                    }
                    reader.Close();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnAdd_CTPN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbx_MaPN.Text) ||
                string.IsNullOrWhiteSpace(cbx_MS.Text) ||
                string.IsNullOrWhiteSpace(txtSLNhap.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cho chi tiết phiếu nhập.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu có điều kiện không đạt
            }
            SqlConnection connection = new SqlConnection(connectionString);

            int maPN = int.Parse(cbx_MaPN.Text);
            int maSach = int.Parse(cbx_MS.Text);
            int SLNhap = int.Parse(txtSLNhap.Text);
            decimal donGia = decimal.Parse(txtDonGia.Text);
            decimal thanhtien = SLNhap * donGia;
            int tongSL = TongSoLuong += SLNhap;
            decimal tongTien = TongThanhTien += thanhtien;

            string sql = "INSERT INTO ChiTietPN (MaPN,MaSach,SLnhap,GiaThanh,ThanhTien) VALUES (@MaPN,@MaSach,@SLNhap,@GiaThanh,@ThanhTien)";
            string uSql = "UPDATE PhieuNhap SET TongTien = @ttien, TongSoLuong = @tongSL WHERE MaPN = @mapn";

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaPN", maPN);
                    command.Parameters.AddWithValue("@MaSach", maSach);
                    command.Parameters.AddWithValue("@SLNhap", SLNhap);
                    command.Parameters.AddWithValue("@GiaThanh", donGia);
                    command.Parameters.AddWithValue("@ThanhTien", thanhtien);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                HienDsCTPN(SelectCTPN);

                using (SqlCommand command1 = new SqlCommand(uSql, connection))
                {
                    command1.Parameters.AddWithValue("@mapn", maPN);
                    command1.Parameters.AddWithValue("@ttien", tongTien);
                    command1.Parameters.AddWithValue("@tongSL", tongSL);

                    command1.ExecuteNonQuery();
                }
                HienDsPN(SelectPN);

                    connection.Close();
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLM_CTPN_Click(object sender, EventArgs e)
        {
            cbx_MaPN.SelectedIndex = -1;
            cbx_MS.SelectedIndex = -1;
            txtSLNhap.Text = "";
            txtDonGia.Text = "";
            HienDsCTPN(SelectCTPN);
        }

        private void grid_CTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Kiểm tra xem cell được click có hợp lệ không
            {
                DataGridViewCell selectedCell = grid_CTPN.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (selectedCell != null && selectedCell.Value != null && !string.IsNullOrEmpty(selectedCell.Value.ToString()))
                {
                    // Lấy dòng dữ liệu được chọn
                    DataGridViewRow selectedRow = grid_CTPN.Rows[e.RowIndex];

                    // Kiểm tra nếu dòng được chọn không null và có dữ liệu
                    if (selectedRow != null && selectedRow.Cells.Count > 0 && selectedRow.Cells[1].Value != null && selectedRow.Cells[2].Value != null &&
                        selectedRow.Cells[3].Value != null && selectedRow.Cells[4].Value != null)
                    {
                        // Lấy dữ liệu từ các cột trong dòng được chọn
                        int maPN, maSach;
                        decimal donGia;
                        int slNhap;

                        if (int.TryParse(selectedRow.Cells[0].Value.ToString(), out maPN) &&
                            int.TryParse(selectedRow.Cells[1].Value.ToString(), out maSach) &&
                            int.TryParse(selectedRow.Cells[2].Value.ToString(), out slNhap) &&
                            decimal.TryParse(selectedRow.Cells[3].Value.ToString(), out donGia))
                        {

                            // Hiển thị dữ liệu lên các TextBox và ComboBox
                            cbx_MaPN.Text = maPN.ToString();
                            cbx_MS.Text = maSach.ToString();
                            txtSLNhap.Text = slNhap.ToString();
                            txtDonGia.Text = donGia.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không thể lấy dữ liệu từ dòng được chọn.");
                        }
                    }
                    else
                    {

                        MessageBox.Show("Dòng được chọn không có dữ liệu.");
                    }
                }
                else
                {
                    cbx_MaPN.SelectedIndex = -1;
                    cbx_MS.SelectedIndex = -1;
                    txtSLNhap.Text = "";
                    txtDonGia.Text ="";
                    //MessageBox.Show("Cell được chọn không có dữ liệu.");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTk_CTPN.SelectedItem == "Tìm theo Mã Phiếu Nhập")
            {
                txtTK_CTPN.Name = "txtTK_MaPN";
            }
            else
            {
                txtTK_CTPN.Name = "txtTK_MaSach";
            }
        }

        private void btnTK_CTPN_Click(object sender, EventArgs e)
        {
            string name = txtTK_CTPN.Name;
            int tk = int.Parse(txtTK_CTPN.Text);

            if (name == "txtTK_MaPN")
            {
              
                HienDsCTPN("SELECT * FROM ChiTietPN WHERE MaPN = " + tk);
            }
            else
            {
                HienDsCTPN("SELECT * FROM ChiTietPN WHERE MaSach = " + tk);
            }    
        }

        private void btnDel_CTPN_Click(object sender, EventArgs e)
        {
            if (grid_CTPN.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_CTPN.SelectedRows[0];

                // cột đầu tiên chứa MaNXB, có thể truy cập giá trị của cột này
                int maPN = Convert.ToInt32(selectedRow.Cells["MaPN"].Value);
                DialogResult dlq = MessageBox.Show("Bạn có muốn xoá?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlq == DialogResult.Yes)
                {
                    XoaCTPN(maPN);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                grid_CTPN.Rows.Remove(selectedRow);
                HienDsCTPN(SelectCTPN);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFix_CTPN_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (grid_CTPN.SelectedRows.Count > 0)
            {
                // Lấy dòng dữ liệu đầu tiên được chọn
                DataGridViewRow selectedRow = grid_CTPN.SelectedRows[0];

                SqlConnection connection = new SqlConnection(connectionString);

                int maSach = int.Parse(cbx_MS.Text);
                int slNhap = int.Parse(txtSLNhap.Text);
                decimal donGia = decimal.Parse(txtDonGia.Text);
                decimal thanhTien = slNhap * donGia;
                string sql = "UPDATE ChiTietPN SET MaSach = @masach, SLnhap = @slnhap,GiaThanh = @giathanh, ThanhTien = @thanhtien WHERE MaPN = @mapn";
                int maPN = Convert.ToInt32(selectedRow.Cells["MaPN"].Value);

                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@masach", maSach);
                        command.Parameters.AddWithValue("@slnhap", slNhap);
                        command.Parameters.AddWithValue("@giathanh", donGia);
                        command.Parameters.AddWithValue("@thanhtien", thanhTien);
                        command.Parameters.AddWithValue("@mapn", maPN);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                MessageBox.Show("Đã sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK); 
            }
        }
        //
        // Thể loại sách
        //
        private void btnAdd_LoaiSach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại sách.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu có điều kiện không đạt
            }
            SqlConnection connection = new SqlConnection(connectionString);
            string tenLoai = txt_TenLoai.Text;

            string sql = "INSERT INTO TheLoaiSach (TenLoai) VALUES (@tenloai)";
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@tenloai", tenLoai);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                HienDSLoaiSach(SelectLoaiSach);

                txt_TenLoai.Text = "";

                connection.Close();
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void grid_LoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            if (grid_LoaiSach.SelectedRows.Count > 0)
            {
                // Lấy dòng dữ liệu đầu tiên được chọn
                DataGridViewRow selectedRow = grid_LoaiSach.SelectedRows[0];

                // Lấy dữ liệu từ các cột trong dòng được chọn
                string tenLoai = selectedRow.Cells[1].Value.ToString();

                // Hiển thị dữ liệu lên các TextBox
                txt_TenLoai.Text = tenLoai;
            }
        }

        private void btnLM_LoaiSach_Click(object sender, EventArgs e)
        {
            HienDSLoaiSach(SelectLoaiSach);
            txt_TenLoai.Text = "";
            cbxTK_LoaiSach.SelectedIndex = -1;
            txtTK_LoaiSach.Text = "";
        }

        private void btnFix_LoaiSach_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (grid_LoaiSach.SelectedRows.Count > 0)
            {
                // Lấy dòng dữ liệu đầu tiên được chọn
                DataGridViewRow selectedRow = grid_LoaiSach.SelectedRows[0];

                SqlConnection connection = new SqlConnection(connectionString);

                int maLoai = Convert.ToInt32(selectedRow.Cells["MaLoaiSach"].Value);
                string tenLoai = txt_TenLoai.Text;
                string sql = "UPDATE TheLoaiSach SET TenLoai = @tenloai WHERE MaLoaiSach = @maloai";
              
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@maloai", maLoai);
                        command.Parameters.AddWithValue("@tenloai", tenLoai);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                HienDSLoaiSach(SelectLoaiSach);
                MessageBox.Show("Đã sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK);
            }
        }

        private void btnDel_LoaiSach_Click(object sender, EventArgs e)
        {
            if (grid_LoaiSach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_LoaiSach.SelectedRows[0];

                // cột đầu tiên chứa MaNXB, có thể truy cập giá trị của cột này
                int maLoai = Convert.ToInt32(selectedRow.Cells[0].Value);
                DialogResult dlq = MessageBox.Show("Bạn có muốn xoá?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlq == DialogResult.Yes)
                {
                    XoaLoaiSach(maLoai);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                grid_LoaiSach.Rows.Remove(selectedRow);
                HienDsNXB(SelectNXS);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxTK_LoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTK_LoaiSach.SelectedItem == "Tìm theo Mã Loại")
            {
                txtTK_LoaiSach.Name = "txtTK_MaLoai";
            }
            else
            {
                txtTK_LoaiSach.Name = "txtTK_TenLoai";
            }
        }

        private void btnTK_LoaiSach_Click(object sender, EventArgs e)
        {
            string name = txtTK_LoaiSach.Name;
            if(name == "txtTK_MaLoai")
            {
                int tk = int.Parse(txtTK_LoaiSach.Text);
                HienDSLoaiSach("SELECT * FROM TheLoaiSach WHERE MaLoaiSach =" + tk);
            }
            else
            {
                string tk = txtTK_LoaiSach.Text;
                HienDSLoaiSach("SELECT * FROM TheLoaiSach WHERE TenLoai LIKE N'%" + tk + "%'");
            }
        }
        //
        // Tab Sách
        //
        private void btn_Pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
              
                // Hiển thị hình ảnh trên PictureBox
                pic_Sach.Image = Image.FromFile(selectedImagePath);
                img = Path.GetFileName(selectedImagePath);
            }
        }

        public void LoadLoaiSachIntoCbx(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int maLoai = reader.GetInt32(0);
                        string tenLoai = reader.GetString(1);
                        cbx_LoaiSach.Items.Add(new KeyValuePair<int, string>(maLoai, tenLoai));
                    }

                    reader.Close();
                }
                cbx_LoaiSach.DisplayMember = "Value";
                cbx_LoaiSach.ValueMember = "Key";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        public void LoaiNXBIntoCbx(string sql)
        {
            SqlConnection connection = new SqlConnection (connectionString);

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int maNXB = reader.GetInt32(0);
                        string tenNXB = reader.GetString(1);

                        cbx_NXB.Items.Add(new KeyValuePair<int, string>( maNXB, tenNXB));
                    }
                    reader.Close();
                }
                cbx_NXB.DisplayMember = "Value";
                cbx_NXB.ValueMember = "Key";
                connection.Close();
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnAdd_Sach_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_TenSach.Text) ||
                string.IsNullOrWhiteSpace(txt_TacGia.Text) ||
                cbx_LoaiSach.SelectedIndex == -1 ||
                cbx_NXB.SelectedIndex == -1 ||
                num_SL.Value == 0 ||
                num_ST.Value == 0 ||
                num_TL.Value == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cho sách.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SqlConnection connection = new SqlConnection(connectionString);

            string tenSach = txt_TenSach.Text;
            string tenTG = txt_TacGia.Text;
            KeyValuePair<int, string> selectedLoaiSach = (KeyValuePair<int, string>)cbx_LoaiSach.SelectedItem;
            int loaiSach = selectedLoaiSach.Key;
            KeyValuePair<int,string> selectNXB = (KeyValuePair<int,string>)cbx_NXB.SelectedItem;
            int NXB = selectNXB.Key;
            int soTrang = int.Parse(num_ST.Value.ToString());
            decimal trongLuong = decimal.Parse(num_TL.Value.ToString());
            int soLuong = int.Parse(num_SL.Value.ToString());
            string sql = "INSERT INTO Sach (TenSach,TacGia,MaLoaiSach,MaNXB,DonGiaNhap,DonGiaBan,SoTrang,TrongLuong,HinhAnh,SoLuong) VALUES (@TenSach,@TacGia,@MaLoaiSach,@MaNXB,@DonGiaNhap,@DonGiaBan,@SoTrang,@TrongLuong,@HinhAnh,@SoLuong)";
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@TenSach", tenSach);
                    command.Parameters.AddWithValue("@TacGia", tenTG);
                    command.Parameters.AddWithValue("@MaLoaiSach", loaiSach);
                    command.Parameters.AddWithValue("@MaNXB", NXB);
                    command.Parameters.AddWithValue("@DonGiaNhap", 0);
                    command.Parameters.AddWithValue("@DonGiaBan", 0);
                    command.Parameters.AddWithValue("@SoTrang", soTrang);
                    command.Parameters.AddWithValue("@TrongLuong", trongLuong);
                    command.Parameters.AddWithValue("@HinhAnh", img);
                    command.Parameters.AddWithValue("@SoLuong", soLuong);

                    command.ExecuteNonQuery();
                }
                HienDsSach(SelectSach);
                MessageBox.Show("Thêm thành công", "THÔNG BÁO", MessageBoxButtons.OK);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            txt_TenSach.Text = "";
            txt_TacGia.Text = "";
            num_SL.Value = 0;
            cbx_LoaiSach.SelectedIndex = -1;
            cbx_NXB.SelectedIndex = -1;
            num_ST.Value = 0;
            num_TL.Value = 0;
            pic_Sach.Image = null;
        }

        private void btnLM_Sach_Click(object sender, EventArgs e)
        {
            HienDsSach(SelectSach);
            txt_TenSach.Text = "";
            txt_TacGia.Text = "";
            num_SL.Value = 0;
            cbx_LoaiSach.SelectedIndex = -1;
            cbx_NXB.SelectedIndex = -1;
            num_ST.Value = 0;
            num_TL.Value = 0;
            pic_Sach.Image = null;
            txt_GiaNhap.Text = "";
            txt_GiaBan.Text = "";
            cellClicked = false;
        }
       
        private string FindLoaiSach(int maLoai)
        {
            string kq = "";

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT tls.TenLoai as [tên Loại sách] FROM TheLoaiSach tls INNER JOIN Sach s ON tls.MaLoaiSach = s.MaLoaiSach WHERE s.MaLoaiSach = @maLoai";
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@maLoai", maLoai);
                    // Sử dụng ExecuteScalar để lấy tên nhân viên
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        kq = result.ToString();
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return kq;
        }

        private string FindNXB(int maNXB)
        {
            string kq = "";

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT nxb.TenNXB as [tên NXB] FROM NhaXuatBan nxb INNER JOIN Sach s ON nxb.MaNXB = s.MaNXB WHERE s.MaNXB = @maNXB";
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@maNXB", maNXB);
                    // Sử dụng ExecuteScalar để lấy tên nhân viên
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        kq = result.ToString();
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return kq;
        }

        private void grid_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            try
            {
                if (grid_Sach.SelectedRows.Count > 0)
                {
                    // Lấy dòng dữ liệu đầu tiên được chọn
                    DataGridViewRow selectedRow = grid_Sach.SelectedRows[0];

                    // Lấy dữ liệu từ các cột trong dòng được chọn
                    string tenSach = selectedRow.Cells[1].Value.ToString();
                    string tacGia = selectedRow.Cells[2].Value.ToString();
                    int loaiSach = int.Parse(selectedRow.Cells[3].Value.ToString());
                    string tenLoai = FindLoaiSach(loaiSach);
                    int NXB = int.Parse(selectedRow.Cells[4].Value.ToString());
                    string tenNXB = FindNXB(NXB);
                    decimal donGiaNhap = decimal.Parse(selectedRow.Cells[5].Value.ToString());
                    decimal donGiaBan = decimal.Parse(selectedRow.Cells[6].Value.ToString());
                    int soTrang = int.Parse(selectedRow.Cells[7].Value.ToString());
                    decimal trongLuong = decimal.Parse(selectedRow.Cells[8].Value.ToString());
                    string hinhAnh = selectedRow.Cells[9].Value.ToString();
                    int soLuong = int.Parse(selectedRow.Cells[10].Value.ToString());

                    txt_TenSach.Text = tenSach;
                    txt_TacGia.Text = tacGia;
                    num_SL.Value = soLuong;
                    cbx_LoaiSach.Text = tenLoai;
                    cbx_NXB.Text = tenNXB;
                    num_ST.Value = soTrang;
                    txt_GiaNhap.Text = donGiaNhap.ToString();
                    txt_GiaBan.Text = donGiaBan.ToString();
                    num_TL.Value = trongLuong;
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnFix_Sach_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (grid_Sach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_Sach.SelectedRows[0];
                SqlConnection connection = new SqlConnection(connectionString);
                string tenSach = txt_TenSach.Text;
                string tenTG = txt_TacGia.Text;
                KeyValuePair<int, string> selectedLoaiSach = (KeyValuePair<int, string>)cbx_LoaiSach.SelectedItem;
                int loaiSach = selectedLoaiSach.Key;
                KeyValuePair<int, string> selectNXB = (KeyValuePair<int, string>)cbx_NXB.SelectedItem;
                int NXB = selectNXB.Key;
                int soTrang = int.Parse(num_ST.Value.ToString());
                decimal trongLuong = decimal.Parse(num_TL.Value.ToString());
                int soLuong = int.Parse(num_SL.Value.ToString());

                int maSach = Convert.ToInt32(selectedRow.Cells[0].Value);
                string sql = "UPDATE Sach SET TenSach = @TenSach,TacGia =@TacGia,MaLoaiSach=@MaLoaiSach,MaNXB=@MaNXB,SoTrang=@SoTrang,TrongLuong=@TrongLuong,SoLuong=@SoLuong WHERE MaSach = @MaSach";
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@TenSach", tenSach);
                        command.Parameters.AddWithValue("@TacGia", tenTG);
                        command.Parameters.AddWithValue("@MaLoaiSach", loaiSach);
                        command.Parameters.AddWithValue("@MaNXB", NXB);
                        command.Parameters.AddWithValue("@SoTrang", soTrang);
                        command.Parameters.AddWithValue("@TrongLuong", trongLuong);
                        command.Parameters.AddWithValue("@SoLuong", soLuong);
                        command.Parameters.AddWithValue("@MaSach", maSach);

                        command.ExecuteNonQuery();
                    }
                    HienDsSach(SelectSach);
                    MessageBox.Show("Sửa thành công","THÔNG BÁO",MessageBoxButtons.OK);
                    connection.Close();
                }catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void cbxTK_Sach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTK_Sach.SelectedItem == "Tìm theo Mã Sách")
            {
                txtTK_Sach.Name = "txtTK_MaSach";
            }
            else if(cbxTK_Sach.SelectedItem == "Tìm theo Tên Sách")
            {
                txtTK_Sach.Name = "txtTK_TenSach";
            }
            else
            {
                txtTK_Sach.Name = "txtTK_TacGia";
            }
        }

        private void btnTK_Sach_Click(object sender, EventArgs e)
        {
            string name = txtTK_Sach.Name;
            try
            {
                if (name == "txtTK_MaSach")
                {
                    int tk = int.Parse(txtTK_Sach.Text);
                    HienDsSach("SELECT * FROM Sach WHERE MaSach = " + tk);
                }
                else if (name == "txtTK_TenSach")
                {
                    string tk = txtTK_Sach.Text;
                    HienDsSach("SELECT * FROM Sach WHERE TenSach LIKE N'%" + tk + "%'");
                }
                else
                {
                    string tk = txtTK_Sach.Text;
                    HienDsSach("SELECT * FROM Sach WHERE TacGia LIKE N'%" + tk + "%'");
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message);
            }
           
        }
        public void XoaSach(int ma)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();

                string deleteChiTietSql = "DELETE FROM ChiTietHD WHERE MaSach = @ma";
                using (SqlCommand Command = new SqlCommand(deleteChiTietSql, connection, transaction))
                {
                    Command.Parameters.AddWithValue("@ma", ma);
                    Command.ExecuteNonQuery();
                }

                string deleteSachSql = "DELETE FROM Sach WHERE MaSach = @ma";
                using (SqlCommand Command1 = new SqlCommand(deleteSachSql, connection, transaction))
                {
                    Command1.Parameters.AddWithValue("@ma", ma);
                    Command1.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra, rollback transaction và hiển thị thông báo lỗi
                transaction?.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDel_Sach_Click(object sender, EventArgs e)
        {
            if(grid_Sach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_Sach.SelectedRows[0];

                int maSach = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                DialogResult dlq = MessageBox.Show("Bạn có muốn xoá sách có mã " + maSach, "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dlq == DialogResult.Yes)
                {
                    XoaSach(maSach);
                    grid_Sach.Rows.Remove(selectedRow);
                    HienDsSach(SelectSach);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại", "THÔNG BÁO", MessageBoxButtons.OK);
                }
            }
        }
    }
}
