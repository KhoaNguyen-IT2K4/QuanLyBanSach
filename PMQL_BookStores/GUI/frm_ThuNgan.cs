using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores
{
    public partial class frm_ThuNgan : Form
    {
        public event EventHandler DangXuatTN; // Tạo even ủy thác thu ngân

        public event EventHandler ThoatFormTN;
        public bool CheckExit = true; // Tạo biến kiểm tra điều kiện đóng form
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-60SQJEQ9\\SQLEXPRESS;Initial Catalog=BookStores;Integrated Security=True");
        public string SelectKH = "SELECT * FROM KhachHang";
        public string SelectHD = "SELECT * FROM HoaDon";
        public string SelectNV = "SELECT * FROM NhanVien";
        public string SelectSach = "SELECT * FROM Sach";
        public string SelectCTHD = "SELECT * FROM ChiTietHD";
        public string LayMaKH = "SELECT TOP 1 MaKH FROM KhachHang ORDER BY MaKH DESC";
        public string LayMaHD = "SELECT TOP 1 MaHD FROM HoaDon ORDER BY MaHD DESC";
        private bool cellClicked = false;
        decimal TongThanhTien = 0;
        int TongSoLuong = 0;

        public frm_ThuNgan()
        {
            InitializeComponent();
        }

        private void btnDangXuatTN_Click(object sender, EventArgs e)
        {
            DangXuatTN(this, new EventArgs()); // Sử dụng even ủy thác ở các form khác
        }

        private void frm_ThuNgan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(CheckExit) // Nếu điều kiện đúng thì sẽ đóng form
            {
                ThoatFormTN(this, new EventArgs());
                Application.Exit();
            }
        }

        private void frm_ThuNgan_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Xin chào Thu Ngân", "Đăng Nhập Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            HienDs(SelectKH, grid_KH);
            HienDs(SelectHD, grid_HD);
            HienDs(SelectCTHD, grid_CTHD);

            LoadNVIntoCbx(SelectNV);
            LoadKHIntoCbx(SelectKH);
            LoadHDIntoCbx(SelectHD);
            LoadSachIntoCbx(SelectSach);
        }

        public void ThoatChuongTrinh(object sender, EventArgs e)
        {
            DialogResult dlq = MessageBox.Show("Bạn có muốn thoát chương trình?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlq == DialogResult.Yes)
            {
                Close();
            }
        }

        //
        // Hàm hiện danh sách
        //
        public void HienDs(string sql,DataGridView dgv)
        {
            try
            {
                connection.Open();

                SqlDataAdapter ds = new SqlDataAdapter(sql, connection);
                DataSet dsach = new DataSet();
                ds.Fill(dsach);

                dgv.DataSource = dsach.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //
        // Hàm lấy mã Hoá đơn mới tạo
        // 
        private int LayMaMoiNhat(string sql)
        {
            int latestPN = 0;
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    latestPN = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return latestPN;
        }

        private void btn_KH_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_KH_HT.Text) ||
                string.IsNullOrWhiteSpace(cbx_KH_PHAI.Text) ||
                string.IsNullOrWhiteSpace(txt_KH_SDT.Text) ||
                string.IsNullOrWhiteSpace(txt_KH_DC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu có điều kiện không đạt
            }
            string tenKH = txt_KH_HT.Text;
            string phai = cbx_KH_PHAI.Text;
            DateTime NgSinh = time_KH.Value;
            int sdt = int.Parse(txt_KH_SDT.Text);
            string Dchi = txt_KH_DC.Text;

            string sql = "INSERT INTO KhachHang (HoTenKH,GioiTinh,NgaySinh,DiaChi,DienThoai) VALUES (@HoTenKH,@GioiTinh,@NgaySinh,@DiaChi,@DienThoai)";

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@HoTenKH", tenKH);
                    command.Parameters.AddWithValue("@GioiTinh", phai);
                    command.Parameters.AddWithValue("@NgaySinh", NgSinh);
                    command.Parameters.AddWithValue("@DiaChi", Dchi);
                    command.Parameters.AddWithValue("@DienThoai", sdt);

                    command.ExecuteNonQuery();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            MessageBox.Show("Thêm thành công với mã " + LayMaMoiNhat(LayMaKH), "THÔNG BÁO", MessageBoxButtons.OK);
            HienDs(SelectKH, grid_KH);
        }

        public void XoaKH(int makh)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKH = @makh";
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@makh", makh);

                    command.ExecuteNonQuery ();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void XoaHD(int makh)
        {
            string sql = "DELETE FROM HoaDon WHERE MaHD = @mahd";
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@mahd", makh);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btn_KH_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_KH.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = grid_KH.SelectedRows[0];

                    int makh = Convert.ToInt32(selectedRow.Cells[0].Value);
                    DialogResult dlq = MessageBox.Show("Bạn có muốn xoá?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlq == DialogResult.Yes)
                    {
                        XoaKH(makh);
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    grid_KH.Rows.Remove(selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            HienDs(SelectKH, grid_KH);
        }

        private void grid_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            try
            {
                if(grid_KH.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = grid_KH.SelectedRows[0];

                    string hoTen = selectedRow.Cells[1].Value.ToString();
                    string phai = selectedRow.Cells[2].Value.ToString();
                    DateTime ngSinh = DateTime.Parse(selectedRow.Cells[3].Value.ToString());
                    string dChi = selectedRow.Cells[4].Value.ToString();
                    int sdt = int.Parse(selectedRow.Cells[5].Value.ToString());

                    txt_KH_HT.Text = hoTen;
                    time_KH.Value = ngSinh;
                    txt_KH_DC.Text = dChi;
                    cbx_KH_PHAI.Text = phai;
                    txt_KH_SDT.Text = sdt.ToString();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLm_KH_Click(object sender, EventArgs e)
        {
            HienDs(SelectKH, grid_KH);
            cellClicked = false;
        }

        private void btn_KH_Fix_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (grid_KH.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = grid_KH.SelectedRows[0];

                    int maKH = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                    string hoTen = txt_KH_HT.Text;
                    DateTime ngSinh = DateTime.Parse(time_KH.Text);
                    string phai = cbx_KH_PHAI.Text;
                    string dchi = txt_KH_DC.Text;
                    int sdt = int.Parse(txt_KH_SDT.Text);
                  
                    string sql = "UPDATE KhachHang SET HoTenKH = @hoten,GioiTinh = @phai, NgaySinh = @ngsinh, DiaChi = @dchi, DienThoai = @sdt WHERE MaKH = @makh";
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@makh", maKH);
                            command.Parameters.AddWithValue("@hoten", hoTen);
                            command.Parameters.AddWithValue("@phai", phai);
                            command.Parameters.AddWithValue("@ngsinh", ngSinh);
                            command.Parameters.AddWithValue("@dchi", dchi);
                            command.Parameters.AddWithValue("@sdt", sdt);

                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Đã sửa thành công mã " + maKH, "THÔNG BÁO", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                    HienDs(SelectKH, grid_KH);
                }
            }
        }

        private void cbxTK_KH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTK_KH.SelectedItem == "Tìm theo Mã")
            {
                txtTK_KH.Name = "txtTK_MaKH";
            }
            else if(cbxTK_KH.SelectedItem == "Tìm theo Tên")
            {
                txtTK_KH.Name = "txtTK_TenKH";
            }
            else if(cbxTK_KH.SelectedItem == "Tìm theo Địa Chỉ")
            {
                txtTK_KH.Name = "txtTK_DChiKH";
            }
            else
            {
                txtTK_KH.Name = "txtTK_SDTKH";
            }
        }

        private void btn_KH_Search_Click(object sender, EventArgs e)
        {
            string name = txtTK_KH.Name;

            try
            {
                if (name == "txtTK_MaKH")
                {
                    int tk = int.Parse(txtTK_KH.Text);
                    HienDs("SELECT * FROM KhachHang WHERE MaKH =" + tk, grid_KH);
                }
                else if(name == "txtTK_TenKH")
                {
                    string tk = txtTK_KH.Text;
                    HienDs("SELECT * FROM KhachHang WHERE HoTenKH LIKE N'%" + tk + "%'", grid_KH);
                }
                else if(name == "txtTK_DChiKH")
                {
                    string tk = txtTK_KH.Text;
                    HienDs("SELECT * FROM KhachHang WHERE DiaChi LIKE N'%" + tk + "%'", grid_KH);
                }
                else
                {
                    int tk = int.Parse (txtTK_KH.Text);
                    HienDs("SELECT * FROM KhachHang WHERE DienThoai =" + tk, grid_KH);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        //
        // Hoá đơn
        //
        public void LoadNVIntoCbx(string sql)
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.GetString(8) == "Thu Ngân")
                        {
                            int maNV = reader.GetInt32(0);
                            string hoNV = reader.GetString(1);
                            string tenLot = reader.GetString(2);
                            string tenNV = reader.GetString(3);
                            string hoTen = hoNV + tenLot + tenNV;
                            cbx_NV.Items.Add(new KeyValuePair<int, string>(maNV, hoTen));
                        }
                    }

                    reader.Close();
                }
                cbx_NV.DisplayMember = "Value";
                cbx_NV.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void LoadKHIntoCbx(string sql)
        {
            try
            {
                connection.Open ();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int maKh = reader.GetInt32(0);
                        string tenKh = reader.GetString(1);

                        cbxKH_HD.Items.Add(new KeyValuePair<int, string>( maKh, tenKh));
                    }
                    reader.Close ();
                }
                cbxKH_HD.DisplayMember = "Value";
                cbxKH_HD.ValueMember = "Key";
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LayMaHDMoiNhat()
        {
            try
            {
                connection.Open();

                 using (SqlCommand commandLatestPN = new SqlCommand(LayMaHD, connection))
                 {
                    int latestPN = Convert.ToInt32(commandLatestPN.ExecuteScalar());

                    cbx_CTHD.Items.Add(latestPN);
                    cbx_CTHD.Text = latestPN.ToString();
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cbx_NV.SelectedIndex == -1 || cbxKH_HD.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên và khách hàng.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu có điều kiện không đạt
            }

            DateTime ngLap = time_HD.Value;
            KeyValuePair<int, string> selectNV = (KeyValuePair<int, string>)cbx_NV.SelectedItem;
            int maNV = selectNV.Key;
            KeyValuePair<int, string>selectKH =(KeyValuePair<int,string>)cbxKH_HD.SelectedItem;
            int maKH = selectKH.Key;

            string sql = "INSERT INTO HoaDon(MaNV,NgayLap,MaKH,TongTien,TongSoLuong) VALUES (@MaNV,@NgayLap,@MaKH,@TongTien,@TongSoLuong)";

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaNV",maNV);
                    command.Parameters.AddWithValue("@NgayLap", ngLap);
                    command.Parameters.AddWithValue("@MaKH", maKH);
                    command.Parameters.AddWithValue("@TongTien", 0);
                    command.Parameters.AddWithValue("@TongSoLuong", 0);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            HienDs(SelectHD,grid_HD);
            LayMaHDMoiNhat();
            MessageBox.Show("Thêm thành công mã " + LayMaMoiNhat(LayMaHD), "THÔNG BÁO", MessageBoxButtons.OK);
        }

        private string FindNV(int manv)
        {
            string kq = "";

            string sql = "SELECT nv.HoNV + nv.TenLotNV + nv.TenNV as [tên nhân viên] FROM NhanVien nv INNER JOIN HoaDon hd ON nv.MaNV = hd.MaNV WHERE hd.MaNV = @manv";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return kq;
        }

        private string FindKH(int makh)
        {
            string kq = "";
            string sql = "SELECT kh.HoTenKH as [tên khách Hàngd] FROM KhachHang kh INNER JOIN HoaDon hd ON kh.MaKH = hd.MaKH WHERE hd.MaKH = @makh";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@makh", makh);
                    object result = command.ExecuteScalar();
                    {
                        if (result != null)
                        {
                            kq = result.ToString();
                        }
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return kq;
        }

        private void grid_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            try
            {
                if (grid_HD.SelectedRows.Count > 0)
                {
                    DataGridViewRow seleledRow = grid_HD.SelectedRows[0];

                    int maNV = int.Parse(seleledRow.Cells[1].Value.ToString());
                    string tenNV = FindNV(maNV);
                    DateTime ngLap = DateTime.Parse(seleledRow.Cells[2].Value.ToString());
                    int maKH = int.Parse(seleledRow.Cells[3].Value.ToString());
                    string tenKH = FindKH(maKH);
                    decimal tongTien = decimal.Parse(seleledRow.Cells[4].Value.ToString());
                    decimal tongSl = decimal.Parse(seleledRow.Cells[5].Value.ToString());

                    time_HD.Value = ngLap;
                    cbx_NV.Text = tenNV;
                    cbxKH_HD.Text = tenKH;
                    txtTTien_HD.Text = tongTien.ToString();
                    txtTSL_HD.Text = tongSl.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {

                if(grid_HD.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = grid_HD.SelectedRows[0];

                    int maHD = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                    DialogResult dql = MessageBox.Show("Bạn có muốn xoá mã " + maHD, "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dql == DialogResult.Yes)
                    {
                        XoaCTHD(maHD);
                        XoaHD(maHD);
                        grid_HD.Rows.Remove(selectedRow);
                        HienDs(SelectHD, grid_HD);
                        cbx_CTHD.Items.Remove(maHD);
                        MessageBox.Show("Đã xoá thành công mã " + maHD, "THÔNG BÁO", MessageBoxButtons.OK);
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message);
            }
        }

        private void btnLM_HD_Click(object sender, EventArgs e)
        {
            HienDs(SelectHD, grid_HD);
            cellClicked = false;
        }

        private void btn_Fix_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (grid_HD.SelectedRows.Count > 0)
                {
                    try
                    {
                        connection.Open();
                        DataGridViewRow selectedRow = grid_HD.SelectedRows[0];

                        int maHD = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                        DateTime nglap = time_HD.Value;
                        KeyValuePair<int, string> selectNV = (KeyValuePair<int, string>)cbx_NV.SelectedItem;
                        int maNV = selectNV.Key;
                        KeyValuePair<int, string> selectKH = (KeyValuePair<int, string>)cbxKH_HD.SelectedItem;
                        int makh = selectKH.Key;
                        string sql = "UPDATE HoaDon SET MaNV = @manv, NgayLap = @nglap, MaKH = @makh WHERE MaHD = @mahd";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@mahd", maHD);
                            command.Parameters.AddWithValue("@manv", maNV);
                            command.Parameters.AddWithValue("@nglap", nglap);
                            command.Parameters.AddWithValue("@makh", makh);

                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Đã sửa thành công mã " + maHD, "THÔNG BÁO", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                HienDs(SelectHD, grid_HD);
            }
        }
       
        private void cbxTK_HD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTK_HD.SelectedItem == "Tìm Mã hoá đơn")
            {
                txtTK_HD.Name = "txtTK_MHD";
                timeTk_HD.Visible = false;
                txtTK_HD.Visible = true;
            }
            else if(cbxTK_HD.SelectedItem == "Tìm Mã Nhân viên")
            {
                txtTK_HD.Name = "txtTK_MNV";
                timeTk_HD.Visible = false;
                txtTK_HD.Visible = true;
            }
            else
            {
                txtTK_HD.Visible = false;
                timeTk_HD.Visible = true;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtTK_HD.Name;
                if(name == "txtTK_MHD")
                {
                    int tk = int.Parse(txtTK_HD.Text);
                    HienDs("SELECT * FROM HoaDon WHERE MaHD = " + tk,grid_HD);
                }
                else if(name == "txtTK_MNV")
                {
                    int tk = int.Parse(txtTK_HD.Text);
                    HienDs("SELECT * FROM HoaDon WHERE MaNV = " + tk, grid_HD);
                }
                else
                {
                   DateTime tk = timeTk_HD.Value;
                   HienDs("SELECT * FROM HoaDon WHERE CONVERT(date, NgayLap) = '" + tk.ToString("MM-dd-yyyy")+"'", grid_HD);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        //
        // chi tiết hoá đơn
        //
        public void LoadHDIntoCbx(string sql)
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int maHD = reader.GetInt32(0);

                        cbx_CTHD.Items.Add(maHD);
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void LoadSachIntoCbx(string sql)
        {
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

                        cbxCTHD_Sach.Items.Add(new KeyValuePair<int,string>(maSach,tenSach));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btn_CTHD_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbx_CTHD.Text) ||
                cbxCTHD_Sach.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txt_GiaThanh.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn, sách và nhập đúng giá thành.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực thi nếu có điều kiện không đạt
            }
            int maHD = int.Parse(cbx_CTHD.Text);
            KeyValuePair<int, string> SelectSach = (KeyValuePair<int, string>)cbxCTHD_Sach.SelectedItem;
            int maSach = SelectSach.Key;
            int soLuong = int.Parse(num_CTHD_SL.Value.ToString());
            decimal giaThanh = decimal.Parse(txt_GiaThanh.Text);
            decimal thanhTien = soLuong * giaThanh;
            int tongSl = TongSoLuong += soLuong;
            decimal tongTT = TongThanhTien += thanhTien;

            string sql = "INSERT INTO ChiTietHD (MaHD,MaSach,Slban,GiaThanh,ThanhTien) VALUES (@MaHD,@MaSach,@Slban,@GiaThanh,@ThanhTien)";
            string sql1 = "UPDATE HoaDon SET TongTien = @TongTien, TongSoLuong = @TongSoLuong WHERE MaHD = @mahd";

            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaHD", maHD);
                    command.Parameters.AddWithValue("@MaSach", maSach);
                    command.Parameters.AddWithValue("@Slban", soLuong);
                    command.Parameters.AddWithValue("@GiaThanh", giaThanh);
                    command.Parameters.AddWithValue("@ThanhTien", thanhTien);

                    command.ExecuteNonQuery();
                }
                using (SqlCommand command1 = new SqlCommand(sql1, connection))
                {
                    command1.Parameters.AddWithValue("@mahd", maHD);
                    command1.Parameters.AddWithValue("@TongTien", tongTT);
                    command1.Parameters.AddWithValue("@TongSoLuong", tongSl);

                    command1.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm thành công chi tiết hoá đơn: mã hoá đơn "+maHD, "THÔNG BÁO", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            HienDs(SelectCTHD, grid_CTHD);
            HienDs(SelectHD, grid_HD);
        }

        private void btnLM_CTHD_Click(object sender, EventArgs e)
        {
            HienDs(SelectCTHD, grid_CTHD);
            cellClicked = false;
        }

        public void XoaCTHD (int ma)
        {
            try
            {
                connection.Open();

                string sql = "DELETE FROM ChiTietHD WHERE MaHD = @ma";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ma", ma);

                    command.ExecuteNonQuery();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateThenDel(int mahd)
        {
            try
            {
                connection.Open();
                decimal thanhtien = decimal.Parse(txt_ThanhTien.Text);
                int Soluong = int.Parse(num_CTHD_SL.Value.ToString());

                DataGridViewRow select = grid_HD.SelectedRows[0];
                decimal gt = decimal.Parse(select.Cells[4].Value.ToString());
                int sl = int.Parse(select.Cells[5].Value.ToString());

                decimal ttsau = gt - thanhtien;
                int slsau = sl - Soluong;

                string sql = "UPDATE HoaDon SET TongTien = @TongTien, TongSoLuong = @TongSL WHERE MaHD = @mahd";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@mahd", mahd);
                    command.Parameters.AddWithValue("@TongTien", ttsau);
                    command.Parameters.AddWithValue("@TongSL", slsau);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void btn_CTHD_Del_Click(object sender, EventArgs e)
        {
            if(grid_CTHD.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_CTHD.SelectedRows[0];

                int maHD = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                DialogResult dlg = MessageBox.Show("Bạn có muốn xoá chi tiết hoá dơn có mã hoá đơn là " + maHD, "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dlg == DialogResult.Yes)
                {
                    XoaCTHD(maHD);
                    grid_CTHD.Rows.Remove(selectedRow);
                    MessageBox.Show("Xoá thành công có mã hoá đơn ", "THÔNG BÁO", MessageBoxButtons.OK);
                    UpdateThenDel(maHD);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại", "THÔNG BÁO", MessageBoxButtons.OK);
                }
            }
        }

        private void btn_CTHD_Fix_Click(object sender, EventArgs e)
        {
            if (!cellClicked)
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    connection.Open();
                    if (grid_CTHD.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = grid_CTHD.SelectedRows[0];

                        KeyValuePair<int, string> selectSach = default(KeyValuePair<int, string>);
                        if (cbxCTHD_Sach.SelectedItem != null && cbxCTHD_Sach.SelectedItem is KeyValuePair<int, string>)
                        {
                            selectSach = (KeyValuePair<int, string>)cbxCTHD_Sach.SelectedItem;
                        }
                        else
                        {
                            MessageBox.Show("Bạn chưa chọn chi tiết hoá đơn để sửa.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        int maHD = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());

                        int maSach = selectSach.Key;
                        decimal giaThanh = decimal.Parse(txt_GiaThanh.Text);
                        int soLuong = int.Parse(num_CTHD_SL.Value.ToString());
                        decimal thanhTien = soLuong * giaThanh;
                        int tongSl = TongSoLuong += soLuong;
                        decimal tongTT = TongThanhTien += thanhTien;

                        string sql = "UPDATE ChiTietHD SET MaSach = @masach, Slban = @sl,GiaThanh = @giathanh, ThanhTien = @thanhtien WHERE MaHD = @mahd";
                        string sql1 = "UPDATE HoaDon SET TongTien = @TongTien, TongSoLuong = @TongSoLuong WHERE MaHD = @mahd";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@mahd", maHD);
                            command.Parameters.AddWithValue("@masach", maSach);
                            command.Parameters.AddWithValue("sl", soLuong);
                            command.Parameters.AddWithValue("@giathanh", giaThanh);
                            command.Parameters.AddWithValue("@thanhtien", thanhTien);

                            command.ExecuteNonQuery();
                        }
                        using (SqlCommand command1 = new SqlCommand(sql1, connection))
                        {
                            command1.Parameters.AddWithValue("@mahd", maHD);
                            command1.Parameters.AddWithValue("@TongTien", tongTT);
                            command1.Parameters.AddWithValue("@TongSoLuong", tongSl);

                            command1.ExecuteNonQuery();
                        }
                        MessageBox.Show("Sửa thành công chi tiết hoá đơn có mã hoá đơn " + maHD, "THÔNG BÁO", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                HienDs(SelectCTHD, grid_CTHD);
                HienDs(SelectHD, grid_HD);
            }
        }

        private string FindSach(int mas)
        {
            string kq = "";
            string sql = "SELECT s.TenSach FROM Sach s INNER JOIN ChiTietHD hd ON s.MaSach = hd.MaSach WHERE hd.MaSach = @mas";
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@mas", mas);
                    object result = command.ExecuteScalar();
                    {
                        if (result != null)
                        {
                            kq = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return kq;
        }

        private void grid_CTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClicked = true;
            if (grid_CTHD.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = grid_CTHD.SelectedRows[0];

                int maHD = int.Parse(selectedRow.Cells[0].Value.ToString());
                int maSach = int.Parse(selectedRow.Cells[1].Value.ToString());
                string tenSach = FindSach(maSach);
                int soLuong = int.Parse(selectedRow.Cells[2].Value.ToString());
                decimal giaThanh = decimal.Parse(selectedRow.Cells[3].Value.ToString());
                decimal thanhTien = decimal.Parse(selectedRow.Cells[4].Value.ToString());

                cbx_CTHD.Text = maHD.ToString();
                cbxCTHD_Sach.Text = tenSach;
                txt_GiaThanh.Text = giaThanh.ToString();
                num_CTHD_SL.Value = soLuong;
                txt_ThanhTien.Text = thanhTien.ToString();
            }
        }

        private void btn_CTHD_Search_Click(object sender, EventArgs e)
        {
            string name = txtTK_CTHD.Name;
            int tk = int.Parse(txtTK_CTHD.Text);
            try
            {
                if (name == "txtTK_MaHD_CTHD")
                {
                    HienDs("SELECT * FROM ChiTietHD WHERE MaHD = " + tk, grid_CTHD);
                }
                else
                {
                    HienDs("SELECT * FROM ChiTietHD WHERE MaSach = " + tk, grid_CTHD);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
          
        }

        private void cbxTK_CTHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxTK_CTHD.SelectedItem == "Tìm theo Mã hoá đơn")
            {
                txtTK_CTHD.Name = "txtTK_MaHD_CTHD";
            }
            else
            {
                txtTK_CTHD.Name = "txtTK_Sach_CTHD";
            }
        }

        private void txt_KH_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length >= 11 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (textBox.Text.Length == 0 && e.KeyChar == '0')
            {
                e.Handled = false;
            }
        }
    }
}
