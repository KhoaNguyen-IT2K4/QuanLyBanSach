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
    public partial class frm_ThongKeNS : Form
    {
        public frm_ThongKeNS()
        {
            InitializeComponent();
        }

        private void tclThongKeNS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int NamHienTai = DateTime.Now.Year;
            int ThangHienTai = DateTime.Now.Month;

            if (tclThongKeNS.SelectedIndex == 1)
            {
                for (int i = 2015; i <= NamHienTai; i++)
                {
                    lbNamTKmonth.Items.Add(i.ToString());
                }

                lbNamTKmonth.Text = NamHienTai.ToString();
                lbThangTKmonth.Text = ThangHienTai.ToString();
            }
            else if (tclThongKeNS.SelectedIndex == 2)
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
            else if (tclThongKeNS.SelectedIndex == 3)
            {
                for (int i = 2015; i <= NamHienTai; i++)
                {
                    lbNamTKN.Items.Add(i.ToString());
                }

                lbNamTKN.Text = NamHienTai.ToString();
            }
        }

        // ================================================================== Thống Kê Ngày ===================================================================== //

        private void btnTKngay_Click(object sender, EventArgs e)
        {
            TKNhapSachBUS.Instance.ThongKeNgay(dgvDanhSachTKngay, dgvTopSachTKngay, dtpTKngay, lblTslTKngay);
        }

        private void btnNgayHienTaiTK_Click(object sender, EventArgs e)
        {
            TKNhapSachBUS.Instance.ThongKeNgayHienTai(dgvDanhSachTKngay, dgvTopSachTKngay, lblTslTKngay);
        }

        // ================================================================== Thống Kê Tháng ===================================================================== //

        private void btnTKmonth_Click(object sender, EventArgs e)
        {
            TKNhapSachBUS.Instance.ThongKeThang(dgvDanhSachTKthang, dgvTopSachTKthang, lbThangTKmonth, lbNamTKmonth, lblTslTKmonth);
        }

        private void btnThangHienTaiTK_Click(object sender, EventArgs e)
        {
            TKNhapSachBUS.Instance.ThongKeThangHienTai(dgvDanhSachTKthang, dgvTopSachTKthang, lblTslTKmonth);
        }

        // ================================================================== Thống Kê Quý ===================================================================== //

        private void btnQuyTKQ_Click(object sender, EventArgs e)
        {
            TKNhapSachBUS.Instance.ThongKeQuy(dgvDanhSachTKquy, dgvTopSachTKquy, lbQuyTKQ, lbNamTKQ, lblTslTKQ);
        }

        private void btnQuyHienTaiTKQ_Click(object sender, EventArgs e)
        {
            TKNhapSachBUS.Instance.ThongKeQuyHienTai(dgvDanhSachTKquy, dgvTopSachTKquy, lbQuyTKQ, lbNamTKQ, lblTslTKQ);
        }

        // ================================================================== Thống Kê Năm ===================================================================== //

        private void btnNamTKN_Click(object sender, EventArgs e)
        {
            TKNhapSachBUS.Instance.ThongKeNam(dgvDanhSachTKnam, dgvTopSachTKnam, lbNamTKN, lblTslTKN);
        }

        private void btnNamHienTaiTKN_Click(object sender, EventArgs e)
        {
            TKNhapSachBUS.Instance.ThongKeNamHienTai(dgvDanhSachTKnam, dgvTopSachTKnam, lblTslTKN);
        }
    }
}
