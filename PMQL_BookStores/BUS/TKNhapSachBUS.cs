using PMQL_BookStores.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    internal class TKNhapSachBUS
    {
        private static TKNhapSachBUS instance;

        internal static TKNhapSachBUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new TKNhapSachBUS();
                return instance;
            } 
            
            set => instance = value; 
        }

        public TKNhapSachBUS() { }

        public void ThongKeNgay(DataGridView dgvDanhSachTKngay, DataGridView dgvTopSachTKngay, DateTimePicker dtpTKngay, Label lblTslTKngay)
        {
            if (dtpTKngay.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKngay.DataSource = TKNhapSachDAL.Instance.HienThiDanhSachTKNSTheoNgay(dtpTKngay);
                dgvDanhSachTKngay.ClearSelection();

                dgvDanhSachTKngay.Columns[0].HeaderText = "Tên sách";
                dgvDanhSachTKngay.Columns[1].HeaderText = "Số lượng nhập";

                // Show sách nhập nhiều nhất
                dgvTopSachTKngay.DataSource = TKNhapSachDAL.Instance.HienThiTopSachTKNSTheoNgay(dtpTKngay);
                dgvTopSachTKngay.ClearSelection();

                dgvTopSachTKngay.Columns[0].HeaderText = "Tên sách";
                dgvTopSachTKngay.Columns[1].HeaderText = "Số lượng nhập";

                // Thay đổi text label tổng số lượng
                lblTslTKngay.Text = "Tổng số lượng sách đã nhập: " + TKNhapSachDAL.Instance.TongSoLuongBanTKNSNgay(dtpTKngay);

                if (dgvDanhSachTKngay.Rows.Count == 0 && dgvTopSachTKngay.Rows.Count == 0)
                {
                    MessageBox.Show("Không có sách nào được nhập trong ngày " + dtpTKngay.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ngày cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNgayHienTai(DataGridView dgvDanhSachTKngay, DataGridView dgvTopSachTKngay, Label lblTslTKngay)
        {
            // Show danh sách
            dgvDanhSachTKngay.DataSource = TKNhapSachDAL.Instance.HienThiDanhSachTKNSTheoNgayHienTai();
            dgvDanhSachTKngay.ClearSelection();

            dgvDanhSachTKngay.Columns[0].HeaderText = "Tên sách";
            dgvDanhSachTKngay.Columns[1].HeaderText = "Số lượng nhập";

            // Show sách nhập nhiều nhất
            dgvTopSachTKngay.DataSource = TKNhapSachDAL.Instance.HienThiTopSachTKNSTheoNgayHienTai();
            dgvTopSachTKngay.ClearSelection();

            dgvTopSachTKngay.Columns[0].HeaderText = "Tên sách";
            dgvTopSachTKngay.Columns[1].HeaderText = "Số lượng nhập";

            // Thay đổi text label tổng số lượng
            lblTslTKngay.Text = "Tổng số lượng sách đã nhập: " + TKNhapSachDAL.Instance.TongSoLuongBanTKNSNgayHienTai();

            if (dgvDanhSachTKngay.Rows.Count == 0 && dgvTopSachTKngay.Rows.Count == 0)
            {
                MessageBox.Show("Không có sách nào được nhập trong ngày hôm nay!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeThang(DataGridView dgvDanhSachTKthang, DataGridView dgvTopSachTKthang, ListBox lbThangTKmonth, ListBox lbNamTKmonth, Label lblTslTKmonth)
        {
            if (lbThangTKmonth.Text != "" && lbNamTKmonth.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKthang.DataSource = TKNhapSachDAL.Instance.HienThiDanhSachTKNSTheoThang(lbThangTKmonth, lbNamTKmonth);
                dgvDanhSachTKthang.ClearSelection();

                dgvDanhSachTKthang.Columns[0].HeaderText = "Tên sách";
                dgvDanhSachTKthang.Columns[1].HeaderText = "Số lượng nhập";

                // Show sách nhập nhiều nhất
                dgvTopSachTKthang.DataSource = TKNhapSachDAL.Instance.HienThiTopSachTKNSTheoThang(lbThangTKmonth, lbNamTKmonth);
                dgvTopSachTKthang.ClearSelection();

                dgvTopSachTKthang.Columns[0].HeaderText = "Tên sách";
                dgvTopSachTKthang.Columns[1].HeaderText = "Số lượng nhập";

                // Thay đổi text label tổng số lượng
                lblTslTKmonth.Text = "Tổng số lượng sách đã nhập: " + TKNhapSachDAL.Instance.TongSoLuongBanTKNSThang(lbThangTKmonth, lbNamTKmonth);

                if (dgvDanhSachTKthang.Rows.Count == 0 && dgvTopSachTKthang.Rows.Count == 0)
                {
                    MessageBox.Show("Không có sách nào được nhập trong tháng " + lbThangTKmonth.Text + "/" + lbNamTKmonth.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tháng cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeThangHienTai(DataGridView dgvDanhSachTKthang, DataGridView dgvTopSachTKthang, Label lblTslTKmonth)
        {
            // Show danh sách
            dgvDanhSachTKthang.DataSource = TKNhapSachDAL.Instance.HienThiDanhSachTKNSTheoNgayHienTai();
            dgvDanhSachTKthang.ClearSelection();

            dgvDanhSachTKthang.Columns[0].HeaderText = "Tên sách";
            dgvDanhSachTKthang.Columns[1].HeaderText = "Số lượng nhập";

            // Show sách nhập nhiều nhất
            dgvTopSachTKthang.DataSource = TKNhapSachDAL.Instance.HienThiTopSachTKNSTheoNgayHienTai();
            dgvTopSachTKthang.ClearSelection();

            dgvTopSachTKthang.Columns[0].HeaderText = "Tên sách";
            dgvTopSachTKthang.Columns[1].HeaderText = "Số lượng nhập";

            // Thay đổi text label tổng số lượng
            lblTslTKmonth.Text = "Tổng số lượng sách đã nhập: " + TKNhapSachDAL.Instance.TongSoLuongBanTKNSNgayHienTai();

            if (dgvDanhSachTKthang.Rows.Count == 0 && dgvTopSachTKthang.Rows.Count == 0)
            {
                MessageBox.Show("Không có sách nào được nhập trong tháng này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (lbQuyTKQ.Text != "" && lbNamTKQ.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKquy.DataSource = TKNhapSachDAL.Instance.HienThiDanhSachTKNSTheoQuy(lbNamTKQ, BatDauQuy, KetThucQuy);
                dgvDanhSachTKquy.ClearSelection();

                dgvDanhSachTKquy.Columns[0].HeaderText = "Tên sách";
                dgvDanhSachTKquy.Columns[1].HeaderText = "Số lượng nhập";

                // Show sách nhập nhiều nhất
                dgvTopSachTKquy.DataSource = TKNhapSachDAL.Instance.HienThiTopSachTKNSTheoQuy(lbNamTKQ, BatDauQuy, KetThucQuy);
                dgvTopSachTKquy.ClearSelection();

                dgvTopSachTKquy.Columns[0].HeaderText = "Tên sách";
                dgvTopSachTKquy.Columns[1].HeaderText = "Số lượng nhập";

                // Thay đổi text label tổng số lượng
                lblTslTKQ.Text = "Tổng số lượng sách đã nhập: " + TKNhapSachDAL.Instance.TongSoLuongBanTKNSQuy(lbNamTKQ, BatDauQuy, KetThucQuy);

                if (dgvDanhSachTKquy.Rows.Count == 0 && dgvTopSachTKquy.Rows.Count == 0)
                {
                    MessageBox.Show("Không có sách nào được nhập trong quý " + lbQuyTKQ.Text + " năm " + lbNamTKQ.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // Show danh sách
            dgvDanhSachTKquy.DataSource = TKNhapSachDAL.Instance.HienThiDanhSachTKNSTheoQuyHienTai(BatDauQuy, KetThucQuy);
            dgvDanhSachTKquy.ClearSelection();

            dgvDanhSachTKquy.Columns[0].HeaderText = "Tên sách";
            dgvDanhSachTKquy.Columns[1].HeaderText = "Số lượng nhập";

            // Show sách nhập nhiều nhất
            dgvTopSachTKquy.DataSource = TKNhapSachDAL.Instance.HienThiTopSachTKNSTheoQuyHienTai(BatDauQuy, KetThucQuy);
            dgvTopSachTKquy.ClearSelection();

            dgvTopSachTKquy.Columns[0].HeaderText = "Tên sách";
            dgvTopSachTKquy.Columns[1].HeaderText = "Số lượng nhập";

            // Thay đổi text label tổng số lượng
            lblTslTKQ.Text = "Tổng số lượng sách đã nhập: " + TKNhapSachDAL.Instance.TongSoLuongBanTKNSQuyHienTai(BatDauQuy, KetThucQuy);

            if (dgvDanhSachTKquy.Rows.Count == 0 && dgvTopSachTKquy.Rows.Count == 0)
            {
                MessageBox.Show("Không có sách nào được nhập trong quý này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNam(DataGridView dgvDanhSachTKnam, DataGridView dgvTopSachTKnam, ListBox lbNamTKN, Label lblTslTKN)
        {
            if (lbNamTKN.Text != "")
            {
                // Show danh sách
                dgvDanhSachTKnam.DataSource = TKNhapSachDAL.Instance.HienThiDanhSachTKNSTheoNam(lbNamTKN);
                dgvDanhSachTKnam.ClearSelection();

                dgvDanhSachTKnam.Columns[0].HeaderText = "Tên sách";
                dgvDanhSachTKnam.Columns[1].HeaderText = "Số lượng nhập";

                // Show sách nhập nhiều nhất
                dgvTopSachTKnam.DataSource = TKNhapSachDAL.Instance.HienThiTopSachTKNSTheoNam(lbNamTKN);
                dgvTopSachTKnam.ClearSelection();

                dgvTopSachTKnam.Columns[0].HeaderText = "Tên sách";
                dgvTopSachTKnam.Columns[1].HeaderText = "Số lượng nhập";

                // Thay đổi text label tổng số lượng
                lblTslTKN.Text = "Tổng số lượng sách đã nhập: " + TKNhapSachDAL.Instance.TongSoLuongBanTKNSNam(lbNamTKN);

                if (dgvDanhSachTKnam.Rows.Count == 0 && dgvTopSachTKnam.Rows.Count == 0)
                {
                    MessageBox.Show("Không có sách nào được nhập trong năm " + lbNamTKN.Text + " !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn năm cần thống kê!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ThongKeNamHienTai(DataGridView dgvDanhSachTKnam, DataGridView dgvTopSachTKnam, Label lblTslTKN)
        {
            // Show danh sách
            dgvDanhSachTKnam.DataSource = TKNhapSachDAL.Instance.HienThiDanhSachTKNSTheoNamHienTai();
            dgvDanhSachTKnam.ClearSelection();

            dgvDanhSachTKnam.Columns[0].HeaderText = "Tên sách";
            dgvDanhSachTKnam.Columns[1].HeaderText = "Số lượng nhập";

            // Show sách nhập nhiều nhất
            dgvTopSachTKnam.DataSource = TKNhapSachDAL.Instance.HienThiTopSachTKNSTheoNamHienTai();
            dgvTopSachTKnam.ClearSelection();

            dgvTopSachTKnam.Columns[0].HeaderText = "Tên sách";
            dgvTopSachTKnam.Columns[1].HeaderText = "Số lượng nhập";

            // Thay đổi text label tổng số lượng
            lblTslTKN.Text = "Tổng số lượng sách đã nhập: " + TKNhapSachDAL.Instance.TongSoLuongBanTKNSNamHienTai();

            if (dgvDanhSachTKnam.Rows.Count == 0 && dgvTopSachTKnam.Rows.Count == 0)
            {
                MessageBox.Show("Không có sách nào được nhập trong năm nay!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
