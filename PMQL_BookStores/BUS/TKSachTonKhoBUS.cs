using PMQL_BookStores.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    public class TKSachTonKhoBUS
    {
        private static TKSachTonKhoBUS instance;

        public static TKSachTonKhoBUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new TKSachTonKhoBUS();
                return instance;
            } 
            
            set => instance = value; 
        }

        public TKSachTonKhoBUS() { }

        public void loadCBOLoaiSach(ComboBox cboLoaiSach)
        {
            // Hiển thị dữ liệu lên combobox mã loại sách của sách
            List<Tuple<int, string>> result = TKSachTonKhoDAL.Instance.DuLieuCBOMaLoaiSach();

            cboLoaiSach.DataSource = result;

            cboLoaiSach.DisplayMember = "Item2";

            cboLoaiSach.ValueMember = "Item1";
        }

        public void ThongKeSachTheoLoaiSach(ComboBox cboLoaiSach,DataGridView dgvDanhSachTKTK,Label lblTongSoLuongTKTK)
        {
            if (cboLoaiSach.SelectedIndex != -1)
            {
                ExDGVnone(dgvDanhSachTKTK); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu

                // Show danh sách
                dgvDanhSachTKTK.DataSource = TKSachTonKhoDAL.Instance.HienThiDanhSachTheoTheLoaiTKSTK(cboLoaiSach);

                dgvDanhSachTKTK.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKTK.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKTK.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKTK.Columns[2].HeaderText = "Số lượng";

                // Thay đổi text label tổng số lượng
                lblTongSoLuongTKTK.Text = "Tổng số lượng sách: " + TKSachTonKhoDAL.Instance.TongSoLuongSachTheoTheLoaiTKSTK(cboLoaiSach);

                if (formatImage(dgvDanhSachTKTK)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                else
                {
                    MessageBox.Show("Không có sách với thể loại sách " + cboLoaiSach.Text + " trong kho!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thể loại sách cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeSachTrongKho(ComboBox cboLoaiSach, DataGridView dgvDanhSachTKTK, Label lblTongSoLuongTKTK)
        {
                ExDGVnone(dgvDanhSachTKTK); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKTK.DataSource = TKSachTonKhoDAL.Instance.HienThiDanhSachTrongKhoTKSTK();

            dgvDanhSachTKTK.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKTK.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKTK.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKTK.Columns[2].HeaderText = "Số lượng";

            // Thay đổi text label tổng số lượng
            lblTongSoLuongTKTK.Text = "Tổng số lượng sách: " + TKSachTonKhoDAL.Instance.TongSoLuongSachTrongKhoTKSTK();

            if (formatImage(dgvDanhSachTKTK)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                else
                {
                    MessageBox.Show("Không có sách nào trong kho!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        public bool formatImage(DataGridView dgv) // Hàm xử lý chuyển cột tên file hình ảnh thành hiển thị hình ảnh
        {
            bool data = false;

            // Kiểm tra datagridview có dữ liệu có thực hiện
            if (dgv.Rows.Count > 0 && dgv.Columns.Count > 0)
            {
                data = true;

                dgv.Columns[0].Width = 50; // Thiết lập chiều rộng của cột hình ảnh thành 50 pixels

                // Thêm một cột kiểu hình ảnh vào DataGridView
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "ImageColumn"; // Đặt tên cho cột
                imageColumn.HeaderText = "Hình ảnh"; // Đặt tiêu đề cho cột
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch; // Tuỳ chỉnh cách hiển thị hình ảnh trong ô
                dgv.Columns.Insert(0, imageColumn); // Thêm cột hình ảnh vào DataGridView với vị trí cột là 0

                // Thêm hình ảnh vào cột hình ảnh từ cột tên file hình ảnh
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    //Thiết lập đường dẫn để hiển thị hình ảnh
                    string imagePath = Application.StartupPath + "\\imgs\\" + dgv.Rows[i].Cells["Hình ảnh"].Value.ToString();

                    // Kiểm tra hình ảnh có tồn tại không
                    if (File.Exists(imagePath))
                    {
                        // Đọc hình ảnh từ đường dẫn
                        Image img = new Bitmap(imagePath);

                        // Thêm hình ảnh vào cột hình ảnh
                        dgv.Rows[i].Cells[0].Value = img;
                    }
                    else
                    {
                        // Thêm hình ảnh vào cột hình ảnh với giá trị là rỗng
                        dgv.Rows[i].Cells[0].Value = null;
                    }
                }

                // Kiểm tra xem cột tên file hình ảnh có tồn tại trong DataGridView không
                if (dgv.Columns.Contains("Hình ảnh"))
                {
                    // Xóa cột tên file hình ảnh
                    dgv.Columns.Remove("Hình ảnh");
                }
            }

            dgv.ClearSelection();

            return data;
        }

        public void ExDGVnone(DataGridView dgv) // Hàm kiểm tra datagridview có dữ liệu chưa -> nếu có thì clear dữ liệu
        {
            // Kiểm tra datagridview có dữ liệu có thực hiện
            if (dgv.Rows.Count > 0 && dgv.Columns.Count > 0)
            {
                // xóa tất cả các cột trong datagridview
                for (int i = 0; i <= dgv.Columns.Count; i++)
                {
                    dgv.Columns.RemoveAt(i);
                }
            }
        }
    }
}
