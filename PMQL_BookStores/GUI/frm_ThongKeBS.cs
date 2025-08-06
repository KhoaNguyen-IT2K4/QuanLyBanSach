using PMQL_BookStores.BUS;
using PMQL_BookStores.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.GUI
{
    public partial class frm_ThongKeBS : Form
    {
        string TopSach = "";

        public frm_ThongKeBS()
        {
            InitializeComponent();
        }

        private void frm_ThongKeBS_Load(object sender, EventArgs e)
        {
            dgvDanhSachTKngay.RowTemplate.Height = 100; // Thiết lập chiều cao của mỗi dòng thành 100 pixels
            dgvTopSachTKngay.RowTemplate.Height = 55; // Thiết lập chiều cao của mỗi dòng thành 100 pixels
        }

        private void tclThongKeBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int NamHienTai = DateTime.Now.Year;
            int ThangHienTai = DateTime.Now.Month;

            if (tclThongKeBS.SelectedIndex == 1)
            {
                for (int i = 2015; i <= NamHienTai; i++)
                {
                    lbNamTKmonth.Items.Add(i.ToString());
                }

                lbNamTKmonth.Text = NamHienTai.ToString();
                lbThangTKmonth.Text = ThangHienTai.ToString();
            }
            else if (tclThongKeBS.SelectedIndex == 2)
            {
                for (int i = 2015; i <= NamHienTai; i++)
                {
                    lbNamTKQ.Items.Add(i.ToString());
                }

                lbNamTKQ.Text = NamHienTai.ToString();
                if(ThangHienTai <= 3)
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
            else if (tclThongKeBS.SelectedIndex == 3)
            {
                for (int i = 2015; i <= NamHienTai; i++)
                {
                    lbNamTKN.Items.Add(i.ToString());
                }

                lbNamTKN.Text = NamHienTai.ToString();
            }
        }

        // ====================================================== Thống Kê Ngày ======================================================================== //

        private void btnTKngay_Click(object sender, EventArgs e)
        {
            TKBanSachBUS.Instance.ThongKeNgay(dgvDanhSachTKngay, dgvTopSachTKngay, dtpTKngay, lblTslTKngay);
        }

        private void btnNgayHienTaiTK_Click(object sender, EventArgs e)
        {
            TKBanSachBUS.Instance.ThongKeNgayHienTai(dgvDanhSachTKngay, dgvTopSachTKngay, lblTslTKngay);
        }

        // ====================================================== Thống Kê Tháng ======================================================================== //

        private void btnTKmonth_Click(object sender, EventArgs e)
        {
            TKBanSachBUS.Instance.ThongKeThang(dgvDanhSachTKthang, dgvTopSachTKthang, lbThangTKmonth, lbNamTKmonth, lblTslTKmonth);
        }

        private void btnThangHienTaiTK_Click(object sender, EventArgs e)
        {
            TKBanSachBUS.Instance.ThongKeThangHienTai(dgvDanhSachTKthang,dgvTopSachTKthang,lblTslTKmonth);
        }

        // ====================================================== Thống Kê Quý ======================================================================== //

        private void btnQuyTKQ_Click(object sender, EventArgs e)
        {
            TKBanSachBUS.Instance.ThongKeQuy(dgvDanhSachTKquy, dgvTopSachTKquy, lbQuyTKQ, lbNamTKQ, lblTslTKQ);
        }

        private void btnQuyHienTaiTKQ_Click(object sender, EventArgs e)
        {
            TKBanSachBUS.Instance.ThongKeQuyHienTai(dgvDanhSachTKquy,dgvTopSachTKquy,lbQuyTKQ,lbNamTKQ,lblTslTKQ);
        }

        // ====================================================== Thống Kê Năm ======================================================================== //

        private void btnNamTKN_Click(object sender, EventArgs e)
        {
            TKBanSachBUS.Instance.ThongKeNam(dgvDanhSachTKnam, dgvTopSachTKnam, lbNamTKN, lblTslTKN);
        }

        private void btnNamHienTaiTKN_Click(object sender, EventArgs e)
        {
            TKBanSachBUS.Instance.ThongKeNamHienTai(dgvDanhSachTKnam, dgvTopSachTKnam, lblTslTKN);
        }
    }
}
