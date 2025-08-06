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
    public class TKBanSachBUS
    {
        private static TKBanSachBUS instance;

        public static TKBanSachBUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new TKBanSachBUS();
                return instance;
            } 
            
            set => instance = value; 
        }

        public TKBanSachBUS() { }

        public void ThongKeNgay(DataGridView dgvDanhSachTKngay,DataGridView dgvTopSachTKngay,DateTimePicker dtpTKngay,Label lblTslTKngay) 
        {
            ExDGVnone(dgvDanhSachTKngay); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu
            ExDGVnone(dgvTopSachTKngay); // Kiểm tra danh sách top sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            if (dtpTKngay.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKngay.DataSource = TKBanSachDAL.Instance.HienThiDanhSachTKBSTheoNgay(dtpTKngay);

                dgvDanhSachTKngay.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKngay.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKngay.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKngay.Columns[2].HeaderText = "Số lượng bán";

                // Show sách bán chạy
                dgvTopSachTKngay.DataSource = TKBanSachDAL.Instance.HienThiTopSachTKBSTheoNgay(dtpTKngay);

                dgvTopSachTKngay.Columns[0].Name = "Hình ảnh";
                dgvTopSachTKngay.Columns[0].HeaderText = "Hình ảnh";
                dgvTopSachTKngay.Columns[1].HeaderText = "Tên sách";
                dgvTopSachTKngay.Columns[2].HeaderText = "Số lượng bán";

                // Thay đổi text label tổng số lượng
                lblTslTKngay.Text = "Tổng số lượng sách đã bán: " + TKBanSachDAL.Instance.TongSoLuongBanTKBSNgay(dtpTKngay);

                if (formatImage(dgvDanhSachTKngay)) // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                {
                    formatImage(dgvTopSachTKngay); // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                }
                else
                {
                    MessageBox.Show("Không có sách nào được bán trong ngày " + dtpTKngay.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ngày cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNgayHienTai(DataGridView dgvDanhSachTKngay, DataGridView dgvTopSachTKngay,Label lblTslTKngay) 
        {
            ExDGVnone(dgvDanhSachTKngay); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu
            ExDGVnone(dgvTopSachTKngay); // Kiểm tra danh sách top sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKngay.DataSource = TKBanSachDAL.Instance.HienThiDanhSachTKBSTheoNgayHienTai();

            dgvDanhSachTKngay.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKngay.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKngay.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKngay.Columns[2].HeaderText = "Số lượng bán";

            // Show sách bán chạy
            dgvTopSachTKngay.DataSource = TKBanSachDAL.Instance.HienThiTopSachTKBSTheoNgayHienTai();

            dgvTopSachTKngay.Columns[0].Name = "Hình ảnh";
            dgvTopSachTKngay.Columns[0].HeaderText = "Hình ảnh";
            dgvTopSachTKngay.Columns[1].HeaderText = "Tên sách";
            dgvTopSachTKngay.Columns[2].HeaderText = "Số lượng bán";

            // Thay đổi text label tổng số lượng
            lblTslTKngay.Text = "Tổng số lượng sách đã bán: " + TKBanSachDAL.Instance.TongSoLuongBanTKBSNgayHienTai();

            if (formatImage(dgvDanhSachTKngay)) // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            {
                formatImage(dgvTopSachTKngay); // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            }
            else
            {
                MessageBox.Show("Không có sách nào được bán trong ngày hôm nay!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeThang(DataGridView dgvDanhSachTKthang, DataGridView dgvTopSachTKthang, ListBox lbThangTKmonth, ListBox lbNamTKmonth, Label lblTslTKmonth) 
        {
            ExDGVnone(dgvDanhSachTKthang); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu
            ExDGVnone(dgvTopSachTKthang); // Kiểm tra danh sách top sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            if (lbThangTKmonth.Text != "" && lbNamTKmonth.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKthang.DataSource = TKBanSachDAL.Instance.HienThiDanhSachTKBSTheoThang(lbThangTKmonth, lbNamTKmonth);

                dgvDanhSachTKthang.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKthang.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKthang.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKthang.Columns[2].HeaderText = "Số lượng bán";

                // Show sách bán chạy
                dgvTopSachTKthang.DataSource = TKBanSachDAL.Instance.HienThiTopSachTKBSTheoThang(lbThangTKmonth, lbNamTKmonth);

                dgvTopSachTKthang.Columns[0].Name = "Hình ảnh";
                dgvTopSachTKthang.Columns[0].HeaderText = "Hình ảnh";
                dgvTopSachTKthang.Columns[1].HeaderText = "Tên sách";
                dgvTopSachTKthang.Columns[2].HeaderText = "Số lượng bán";

                // Thay đổi text label tổng số lượng
                lblTslTKmonth.Text = "Tổng số lượng sách đã bán: " + TKBanSachDAL.Instance.TongSoLuongBanTKBSThang(lbThangTKmonth, lbNamTKmonth);

                if (formatImage(dgvDanhSachTKthang)) // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                {
                    formatImage(dgvTopSachTKthang); // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                }
                else
                {
                    MessageBox.Show("Không có sách nào được bán trong tháng " + lbThangTKmonth.Text + "/" + lbNamTKmonth.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tháng cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeThangHienTai(DataGridView dgvDanhSachTKthang, DataGridView dgvTopSachTKthang, Label lblTslTKmonth) 
        {
            ExDGVnone(dgvDanhSachTKthang); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu
            ExDGVnone(dgvTopSachTKthang); // Kiểm tra danh sách top sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKthang.DataSource = TKBanSachDAL.Instance.HienThiDanhSachTKBSTheoThangHienTai();

            dgvDanhSachTKthang.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKthang.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKthang.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKthang.Columns[2].HeaderText = "Số lượng bán";

            // Show sách bán chạy
            dgvTopSachTKthang.DataSource = TKBanSachDAL.Instance.HienThiTopSachTKBSTheoThangHienTai();

            dgvTopSachTKthang.Columns[0].Name = "Hình ảnh";
            dgvTopSachTKthang.Columns[0].HeaderText = "Hình ảnh";
            dgvTopSachTKthang.Columns[1].HeaderText = "Tên sách";
            dgvTopSachTKthang.Columns[2].HeaderText = "Số lượng bán";

            // Thay đổi text label tổng số lượng
            lblTslTKmonth.Text = "Tổng số lượng sách đã bán: " + TKBanSachDAL.Instance.TongSoLuongBanTKBSThangHienTai();

            if (formatImage(dgvDanhSachTKthang)) // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            {
                formatImage(dgvTopSachTKthang); // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            }
            else
            {
                MessageBox.Show("Không có sách nào được bán trong tháng này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeQuy(DataGridView dgvDanhSachTKquy, DataGridView dgvTopSachTKquy, ListBox lbQuyTKQ, ListBox lbNamTKQ, Label lblTslTKQ) 
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

            ExDGVnone(dgvDanhSachTKquy); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu
            ExDGVnone(dgvTopSachTKquy); // Kiểm tra danh sách top sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            if (lbQuyTKQ.Text != "" && lbNamTKQ.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKquy.DataSource = TKBanSachDAL.Instance.HienThiDanhSachTKBSTheoQuy(lbNamTKQ, BatDauQuy, KetThucQuy);

                dgvDanhSachTKquy.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKquy.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKquy.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKquy.Columns[2].HeaderText = "Số lượng bán";

                // Show sách bán chạy
                dgvTopSachTKquy.DataSource = TKBanSachDAL.Instance.HienThiTopSachTKBSTheoQuy(lbNamTKQ, BatDauQuy, KetThucQuy);

                dgvTopSachTKquy.Columns[0].Name = "Hình ảnh";
                dgvTopSachTKquy.Columns[0].HeaderText = "Hình ảnh";
                dgvTopSachTKquy.Columns[1].HeaderText = "Tên sách";
                dgvTopSachTKquy.Columns[2].HeaderText = "Số lượng bán";

                // Thay đổi text label tổng số lượng
                lblTslTKQ.Text = "Tổng số lượng sách đã bán: " + TKBanSachDAL.Instance.TongSoLuongBanTKBSQuy(lbNamTKQ, BatDauQuy, KetThucQuy);

                if (formatImage(dgvDanhSachTKquy)) // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                {
                    formatImage(dgvTopSachTKquy); // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                }
                else
                {
                    MessageBox.Show("Không có sách nào được bán trong quý " + lbQuyTKQ.Text + " năm " + lbNamTKQ.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn quý cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeQuyHienTai(DataGridView dgvDanhSachTKquy, DataGridView dgvTopSachTKquy, ListBox lbQuyTKQ, ListBox lbNamTKQ, Label lblTslTKQ) 
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

            ExDGVnone(dgvDanhSachTKquy); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu
            ExDGVnone(dgvTopSachTKquy); // Kiểm tra danh sách top sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKquy.DataSource = TKBanSachDAL.Instance.HienThiDanhSachTKBSTheoQuyHienTai(BatDauQuy, KetThucQuy);

            dgvDanhSachTKquy.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKquy.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKquy.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKquy.Columns[2].HeaderText = "Số lượng bán";

            // Show sách bán chạy
            dgvTopSachTKquy.DataSource = TKBanSachDAL.Instance.HienThiTopSachTKBSTheoQuyHienTai(BatDauQuy, KetThucQuy);

            dgvTopSachTKquy.Columns[0].Name = "Hình ảnh";
            dgvTopSachTKquy.Columns[0].HeaderText = "Hình ảnh";
            dgvTopSachTKquy.Columns[1].HeaderText = "Tên sách";
            dgvTopSachTKquy.Columns[2].HeaderText = "Số lượng bán";

            // Thay đổi text label tổng số lượng
            lblTslTKQ.Text = "Tổng số lượng sách đã bán: " + TKBanSachDAL.Instance.TongSoLuongBanTKBSQuyHienTai(BatDauQuy, KetThucQuy);

            if (formatImage(dgvDanhSachTKquy)) // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            {
                formatImage(dgvTopSachTKquy); // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            }
            else
            {
                MessageBox.Show("Không có sách nào được bán trong quý này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNam(DataGridView dgvDanhSachTKnam, DataGridView dgvTopSachTKnam, ListBox lbNamTKN, Label lblTslTKN) 
        {
            ExDGVnone(dgvDanhSachTKnam); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu
            ExDGVnone(dgvTopSachTKnam); // Kiểm tra danh sách top sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            if (lbNamTKN.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKnam.DataSource = TKBanSachDAL.Instance.HienThiDanhSachTKBSTheoNam(lbNamTKN);

                dgvDanhSachTKnam.Columns[0].Name = "Hình ảnh";
                dgvDanhSachTKnam.Columns[0].HeaderText = "Hình ảnh";
                dgvDanhSachTKnam.Columns[1].HeaderText = "Tên sách";
                dgvDanhSachTKnam.Columns[2].HeaderText = "Số lượng bán";

                // Show sách bán chạy
                dgvTopSachTKnam.DataSource = TKBanSachDAL.Instance.HienThiTopSachTKBSTheoNam(lbNamTKN);

                dgvTopSachTKnam.Columns[0].Name = "Hình ảnh";
                dgvTopSachTKnam.Columns[0].HeaderText = "Hình ảnh";
                dgvTopSachTKnam.Columns[1].HeaderText = "Tên sách";
                dgvTopSachTKnam.Columns[2].HeaderText = "Số lượng bán";

                // Thay đổi text label tổng số lượng
                lblTslTKN.Text = "Tổng số lượng sách đã bán: " + TKBanSachDAL.Instance.TongSoLuongBanTKBSNam(lbNamTKN);

                if (formatImage(dgvDanhSachTKnam)) // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                {
                    formatImage(dgvTopSachTKnam); // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
                }
                else
                {
                    MessageBox.Show("Không có sách nào được bán trong năm " + lbNamTKN.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn năm cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNamHienTai(DataGridView dgvDanhSachTKnam, DataGridView dgvTopSachTKnam, Label lblTslTKN) 
        {
            ExDGVnone(dgvDanhSachTKnam); // Kiểm tra danh sách có dữ liệu chưa -> nếu có thì clear dữ liệu
            ExDGVnone(dgvTopSachTKnam); // Kiểm tra danh sách top sách có dữ liệu chưa -> nếu có thì clear dữ liệu

            // Show danh sách
            dgvDanhSachTKnam.DataSource = TKBanSachDAL.Instance.HienThiDanhSachTKBSTheoNamHienTai();

            dgvDanhSachTKnam.Columns[0].Name = "Hình ảnh";
            dgvDanhSachTKnam.Columns[0].HeaderText = "Hình ảnh";
            dgvDanhSachTKnam.Columns[1].HeaderText = "Tên sách";
            dgvDanhSachTKnam.Columns[2].HeaderText = "Số lượng bán";

            // Show sách bán chạy
            dgvTopSachTKnam.DataSource = TKBanSachDAL.Instance.HienThiTopSachTKBSTheoNamHienTai();

            dgvTopSachTKnam.Columns[0].Name = "Hình ảnh";
            dgvTopSachTKnam.Columns[0].HeaderText = "Hình ảnh";
            dgvTopSachTKnam.Columns[1].HeaderText = "Tên sách";
            dgvTopSachTKnam.Columns[2].HeaderText = "Số lượng bán";

            // Thay đổi text label tổng số lượng
            lblTslTKN.Text = "Tổng số lượng sách đã bán: " + TKBanSachDAL.Instance.TongSoLuongBanTKBSNamHienTai();

            if (formatImage(dgvDanhSachTKnam)) // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            {
                formatImage(dgvTopSachTKnam); // Hàm xử lý format tên file hình ảnh thành hiển thị hình ảnh và trả kết quả
            }
            else
            {
                MessageBox.Show("Không có sách nào được bán trong năm nay!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
