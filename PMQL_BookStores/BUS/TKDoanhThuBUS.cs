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
    public class TKDoanhThuBUS
    {
        private static TKDoanhThuBUS instance;

        public static TKDoanhThuBUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new TKDoanhThuBUS();
                return instance;
            } 
            
            set => instance = value; 
        }

        public TKDoanhThuBUS() { }

        public void ThongKeNgay(DataGridView dgvDanhSachTKngay, DateTimePicker dtpTKngay, Label lblTongTienTKngay, Label lblLoiNhuanTKngay)
        {
            ExDGVnone(dgvDanhSachTKngay); // Kiểm tra danh sách có duwxx liệu chưa -> nếu có thì clear dữ liệu

            if (dtpTKngay.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKngay.DataSource = TKDoanhThuDAL.Instance.HienThiDanhSachTKDTTheoNgay(dtpTKngay);

                dgvDanhSachTKngay.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKngay.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKngay.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKngay.Columns[2].HeaderText = "Số lượng bán";
                dgvDanhSachTKngay.Columns[3].HeaderText = "Giá thành";
                dgvDanhSachTKngay.Columns[4].HeaderText = "Thành tiền";

                // Thay đổi text label tổng tiền
                lblTongTienTKngay.Text = "Tổng tiền bán sách: " + TKDoanhThuDAL.Instance.TongTienBanTKDTNgay(dtpTKngay);

                // Thay đổi text label lợi nhuận
                lblLoiNhuanTKngay.Text = "Lợi nhuận: " + TKDoanhThuDAL.Instance.LoiNhuanTKDTNgay(dtpTKngay);

                if (formatImage(dgvDanhSachTKngay)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                else
                {
                    MessageBox.Show("Không có doanh thu ngày " + dtpTKngay.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ngày cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNgayHienTai(DataGridView dgvDanhSachTKngay, Label lblTongTienTKngay, Label lblLoiNhuanTKngay)
        {
            ExDGVnone(dgvDanhSachTKngay); // Kiểm tra danh sách có duwxx liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKngay.DataSource = TKDoanhThuDAL.Instance.HienThiDanhSachTKDTTheoNgayHienTai();

            dgvDanhSachTKngay.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKngay.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKngay.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKngay.Columns[2].HeaderText = "Số lượng bán";
            dgvDanhSachTKngay.Columns[3].HeaderText = "Giá thành";
            dgvDanhSachTKngay.Columns[4].HeaderText = "Thành tiền";

            // Thay đổi text label tổng số lượng
            lblTongTienTKngay.Text = "Tổng tiền bán sách: " + TKDoanhThuDAL.Instance.TongTienBanTKDTNgayHienTai();

            // Thay đổi text label lợi nhuận
            lblLoiNhuanTKngay.Text = "Lợi nhuận: " + TKDoanhThuDAL.Instance.LoiNhuanTKDTNgayHienTai();

            if (formatImage(dgvDanhSachTKngay)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            else
            {
                MessageBox.Show("Không có doanh thu ngày hôm nay!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeThang(DataGridView dgvDanhSachTKthang, ListBox lbThangTKmonth, ListBox lbNamTKmonth, Label lblTongTienTKmonth, Label lblLoiNhuanTKmonth)
        {
            ExDGVnone(dgvDanhSachTKthang); // Kiểm tra danh sách có duwxx liệu chưa -> nếu có thì clear dữ liệu

            if (lbThangTKmonth.Text != "" && lbNamTKmonth.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKthang.DataSource = TKDoanhThuDAL.Instance.HienThiDanhSachTKDTTheoThang(lbThangTKmonth, lbNamTKmonth);

                dgvDanhSachTKthang.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKthang.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKthang.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKthang.Columns[2].HeaderText = "Số lượng bán";
                dgvDanhSachTKthang.Columns[3].HeaderText = "Giá thành";
                dgvDanhSachTKthang.Columns[4].HeaderText = "Thành tiền";

                // Thay đổi text label tổng số lượng
                lblTongTienTKmonth.Text = "Tổng tiền bán sách: " + TKDoanhThuDAL.Instance.TongTienBanTKDTThang(lbThangTKmonth, lbNamTKmonth);

                // Thay đổi text label lợi nhuận
                lblLoiNhuanTKmonth.Text = "Lợi nhuận: " + TKDoanhThuDAL.Instance.LoiNhuanTKDTThang(lbThangTKmonth, lbNamTKmonth);

                if (formatImage(dgvDanhSachTKthang)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                else
                {
                    MessageBox.Show("Không có doanh thu tháng " + lbThangTKmonth.Text + "/" + lbNamTKmonth.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tháng cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeThangHienTai(DataGridView dgvDanhSachTKthang, Label lblTongTienTKmonth, Label lblLoiNhuanTKmonth)
        {
            ExDGVnone(dgvDanhSachTKthang); // Kiểm tra danh sách có duwxx liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKthang.DataSource = TKDoanhThuDAL.Instance.HienThiDanhSachTKDTTheoThangHienTai();

            dgvDanhSachTKthang.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKthang.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKthang.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKthang.Columns[2].HeaderText = "Số lượng bán";
            dgvDanhSachTKthang.Columns[3].HeaderText = "Giá thành";
            dgvDanhSachTKthang.Columns[4].HeaderText = "Thành tiền";

            // Thay đổi text label tổng số lượng
            lblTongTienTKmonth.Text = "Tổng tiền bán sách: " + TKDoanhThuDAL.Instance.TongTienBanTKDTThangHienTai();

            // Thay đổi text label lợi nhuận
            lblLoiNhuanTKmonth.Text = "Lợi nhuận: " + TKDoanhThuDAL.Instance.LoiNhuanTKDTThangHienTai();

            if (formatImage(dgvDanhSachTKthang)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            else
            {
                MessageBox.Show("Không có doanh thu tháng này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeQuy(DataGridView dgvDanhSachTKquy, ListBox lbQuyTKQ, ListBox lbNamTKQ, Label lblTongTienTKQ, Label lblLoiNhuanTKQ)
        {
            string BatDauQuy;
            string KetThucQuy;

            if (lbQuyTKQ.SelectedIndex == 0)
            {
                BatDauQuy = "1";
                KetThucQuy = "3";
            }
            else if (lbQuyTKQ.SelectedIndex == 1)
            {
                BatDauQuy = "4";
                KetThucQuy = "6";
            }
            else if (lbQuyTKQ.SelectedIndex == 2)
            {
                BatDauQuy = "7";
                KetThucQuy = "9";
            }
            else
            {
                BatDauQuy = "10";
                KetThucQuy = "12";
            }

            ExDGVnone(dgvDanhSachTKquy); // Kiểm tra danh sách có duwxx liệu chưa -> nếu có thì clear dữ liệu

            if (lbQuyTKQ.Text != "" && lbNamTKQ.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKquy.DataSource = TKDoanhThuDAL.Instance.HienThiDanhSachTKDTTheoQuy(lbNamTKQ, BatDauQuy, KetThucQuy);

                dgvDanhSachTKquy.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKquy.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKquy.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKquy.Columns[2].HeaderText = "Số lượng bán";
                dgvDanhSachTKquy.Columns[3].HeaderText = "Giá thành";
                dgvDanhSachTKquy.Columns[4].HeaderText = "Thành tiền";

                // Thay đổi text label tổng số lượng
                lblTongTienTKQ.Text = "Tổng tiền bán sách: " + TKDoanhThuDAL.Instance.TongTienBanTKDTQuy(lbNamTKQ, BatDauQuy, KetThucQuy);

                // Thay đổi text label lợi nhuận
                lblLoiNhuanTKQ.Text = "Lợi nhuận: " + TKDoanhThuDAL.Instance.LoiNhuanTKDTQuy(lbNamTKQ, BatDauQuy, KetThucQuy);

                if (formatImage(dgvDanhSachTKquy)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                else
                {
                    MessageBox.Show("Không có doanh thu quý " + lbQuyTKQ.Text + " năm " + lbNamTKQ.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn quý cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeQuyHienTai(DataGridView dgvDanhSachTKquy, ListBox lbQuyTKQ, ListBox lbNamTKQ, Label lblTongTienTKQ, Label lblLoiNhuanTKQ)
        {
            int ThangHienTai = DateTime.Now.Month;
            string BatDauQuy;
            string KetThucQuy;

            if (ThangHienTai <= 3)
            {
                BatDauQuy = "1";
                KetThucQuy = "3";
            }
            else if (ThangHienTai <= 6)
            {
                BatDauQuy = "4";
                KetThucQuy = "6";
            }
            else if (ThangHienTai <= 9)
            {
                BatDauQuy = "7";
                KetThucQuy = "9";
            }
            else
            {
                BatDauQuy = "10";
                KetThucQuy = "12";
            }

            ExDGVnone(dgvDanhSachTKquy); // Kiểm tra danh sách có duwxx liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKquy.DataSource = TKDoanhThuDAL.Instance.HienThiDanhSachTKDTTheoQuyHienTai(BatDauQuy, KetThucQuy);

            dgvDanhSachTKquy.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKquy.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKquy.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKquy.Columns[2].HeaderText = "Số lượng bán";
            dgvDanhSachTKquy.Columns[3].HeaderText = "Giá thành";
            dgvDanhSachTKquy.Columns[4].HeaderText = "Thành tiền";

            // Thay đổi text label tổng số lượng
            lblTongTienTKQ.Text = "Tổng tiền bán sách: " + TKDoanhThuDAL.Instance.TongTienBanTKDTQuyHienTai(BatDauQuy, KetThucQuy);

            // Thay đổi text label lợi nhuận
            lblLoiNhuanTKQ.Text = "Lợi nhuận: " + TKDoanhThuDAL.Instance.LoiNhuanTKDTQuyHienTai(BatDauQuy, KetThucQuy);

            if (formatImage(dgvDanhSachTKquy)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            else
            {
                MessageBox.Show("Không có doanh thu quý này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNam(DataGridView dgvDanhSachTKnam, ListBox lbNamTKN, Label lblTongTienTKN, Label lblLoiNhuanTKN)
        {
            ExDGVnone(dgvDanhSachTKnam); // Kiểm tra danh sách có duwxx liệu chưa -> nếu có thì clear dữ liệu

            if (lbNamTKN.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKnam.DataSource = TKDoanhThuDAL.Instance.HienThiDanhSachTKDTTheoNam(lbNamTKN);

                dgvDanhSachTKnam.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKnam.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKnam.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKnam.Columns[2].HeaderText = "Số lượng bán";
                dgvDanhSachTKnam.Columns[3].HeaderText = "Giá thành";
                dgvDanhSachTKnam.Columns[4].HeaderText = "Thành tiền";

                // Thay đổi text label tổng số lượng
                lblTongTienTKN.Text = "Tổng tiền bán sách: " + TKDoanhThuDAL.Instance.TongTienBanTKDTNam(lbNamTKN);

                // Thay đổi text label lợi nhuận
                lblLoiNhuanTKN.Text = "Lợi nhuận: " + TKDoanhThuDAL.Instance.LoiNhuanTKDTNam(lbNamTKN);

                if (formatImage(dgvDanhSachTKnam)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                else
                {
                    MessageBox.Show("Không có doanh thu năm " + lbNamTKN.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn năm cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNamHienTai(DataGridView dgvDanhSachTKnam, Label lblTongTienTKN, Label lblLoiNhuanTKN)
        {
            ExDGVnone(dgvDanhSachTKnam); // Kiểm tra danh sách có duwxx liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKnam.DataSource = TKDoanhThuDAL.Instance.HienThiDanhSachTKDTTheoNamHienTai();

            dgvDanhSachTKnam.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKnam.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKnam.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKnam.Columns[2].HeaderText = "Số lượng bán";
            dgvDanhSachTKnam.Columns[3].HeaderText = "Giá thành";
            dgvDanhSachTKnam.Columns[4].HeaderText = "Thành tiền";

            // Thay đổi text label tổng số lượng
            lblTongTienTKN.Text = "Tổng tiền bán sách: " + TKDoanhThuDAL.Instance.TongTienBanTKDTNamHienTai();

            // Thay đổi text label lợi nhuận
            lblLoiNhuanTKN.Text = "Lợi nhuận: " + TKDoanhThuDAL.Instance.LoiNhuanTKDTNamHienTai();

            if (formatImage(dgvDanhSachTKnam)) { } // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            else
            {
                MessageBox.Show("Không có doanh thu năm nay!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void ExDGVnone(DataGridView dgv) // Hàm kiểm tra datagridview có dữ liệu -> nếu có thì clear dữ liệu
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
