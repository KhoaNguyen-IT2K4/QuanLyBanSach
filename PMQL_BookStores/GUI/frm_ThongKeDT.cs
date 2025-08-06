using PMQL_BookStores.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.GUI
{
    public partial class frm_ThongKeDT : Form
    {
        public frm_ThongKeDT()
        {
            InitializeComponent();
        }
        private void frm_ThongKeDT_Load(object sender, EventArgs e)
        {
            dgvDanhSachTKngay.RowTemplate.Height = 100; // Thiết lập chiều cao của mỗi dòng thành 100 pixels
        }

        private void tclThongKeDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int NamHienTai = DateTime.Now.Year;
            int ThangHienTai = DateTime.Now.Month;

            if (tclThongKeDT.SelectedIndex == 1)
            {
                for (int i = 2015; i <= NamHienTai; i++)
                {
                    lbNamTKmonth.Items.Add(i.ToString());
                }

                lbNamTKmonth.Text = NamHienTai.ToString();
                lbThangTKmonth.Text = ThangHienTai.ToString();
            }
            else if (tclThongKeDT.SelectedIndex == 2)
            {
                for (int i = 2015; i <= NamHienTai; i++)
                {
                    lbNamTKQ.Items.Add(i.ToString());
                }

                lbNamTKQ.Text = NamHienTai.ToString();
                if (ThangHienTai <= 3)
                {
                    lbQuyTKQ.Text = "1";
                }
                else if (ThangHienTai <= 6)
                {
                    lbQuyTKQ.Text = "2";
                }
                else if (ThangHienTai <= 9)
                {
                    lbQuyTKQ.Text = "3";
                }
                else
                {
                    lbQuyTKQ.Text = "4";
                }
            }
            else if (tclThongKeDT.SelectedIndex == 3)
            {
                for (int i = 2015; i <= NamHienTai; i++)
                {
                    lbNamTKN.Items.Add(i.ToString());
                }

                lbNamTKN.Text = NamHienTai.ToString();
            }
        }

        // ====================================================== Thống Kê Ngày ======================================================================== //

        private void btnTKngay_Click_1(object sender, EventArgs e)
        {
            TKDoanhThuBUS.Instance.ThongKeNgay(dgvDanhSachTKngay, dtpTKngay, lblTongTienTKngay,lblLoiNhuanTKngay);
        }

        private void btnNgayHienTaiTK_Click_1(object sender, EventArgs e)
        {
            TKDoanhThuBUS.Instance.ThongKeNgayHienTai(dgvDanhSachTKngay, lblTongTienTKngay, lblLoiNhuanTKngay);
        }

        // ====================================================== Thống Kê Tháng ======================================================================== //

        private void btnTKmonth_Click_1(object sender, EventArgs e)
        {
            TKDoanhThuBUS.Instance.ThongKeThang(dgvDanhSachTKthang, lbThangTKmonth, lbNamTKmonth, lblTongTienTKmonth, lblLoiNhuanTKmonth);
        }

        private void btnThangHienTaiTK_Click_1(object sender, EventArgs e)
        {
            TKDoanhThuBUS.Instance.ThongKeThangHienTai(dgvDanhSachTKthang, lblTongTienTKmonth, lblLoiNhuanTKmonth);
        }

        // ====================================================== Thống Kê Quý ======================================================================== //

        private void btnQuyTKQ_Click_1(object sender, EventArgs e)
        {
            TKDoanhThuBUS.Instance.ThongKeQuy(dgvDanhSachTKquy, lbQuyTKQ, lbNamTKQ, lblTongTienTKQ, lblLoiNhuanTKQ);
        }

        private void btnQuyHienTaiTKQ_Click_1(object sender, EventArgs e)
        {
            TKDoanhThuBUS.Instance.ThongKeQuyHienTai(dgvDanhSachTKquy, lbQuyTKQ, lbNamTKQ, lblTongTienTKQ, lblLoiNhuanTKQ);
        }

        // ====================================================== Thống Kê Năm ======================================================================== //

        private void btnNamTKN_Click_1(object sender, EventArgs e)
        {
            TKDoanhThuBUS.Instance.ThongKeNam(dgvDanhSachTKnam, lbNamTKN, lblTongTienTKN, lblLoiNhuanTKN);
        }

        private void btnNamHienTaiTKN_Click_1(object sender, EventArgs e)
        {
            TKDoanhThuBUS.Instance.ThongKeNamHienTai(dgvDanhSachTKnam, lblTongTienTKN, lblLoiNhuanTKN);
        }
    }
}
