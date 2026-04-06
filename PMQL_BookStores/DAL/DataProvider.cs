using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PMQL_BookStores.DAL
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }

            set => instance = value;
        }

        public DataProvider() { }

        public string Conn = "Data Source=.\\SQLEXPRESS;Initial Catalog=BookStores;Integrated Security=True"; // Chuỗi kết nối database

        public DataTable DataAccess(string query) // Hàm hiển thị dữ liệu lên datagridview
        {
            DataTable DT = null;

            SqlConnection sqlconn = new SqlConnection(Conn); // kết nối database

            try
            {
                sqlconn.Open(); // Mở kết nối

                SqlDataAdapter danhsach = new SqlDataAdapter(query, sqlconn);

                DT = new DataTable();

                danhsach.Fill(DT);

                sqlconn.Close(); // Đóng kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối => chi tiết: " + ex.Message);
            }

            return DT;
        }

        public bool DataHandle(string query) // Hàm xử lý thêm,xóa,sửa dữ liệu
        {
            bool result = false; // Gán kết quả xử lý bằng false

            SqlConnection sqlconn = new SqlConnection(Conn); // Kết nối database

            try
            {
                sqlconn.Open(); // Mở kết nối

                SqlCommand cmd = new SqlCommand(query, sqlconn);
                int numberRows = cmd.ExecuteNonQuery(); // Lấy ra số dòng đã thực thi

                if (numberRows > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                sqlconn.Close(); // Đóng kết nối
            }
            catch
            {
                result = false;
            }

            return result; // Trả kết quả
        }

        public string TakeData(string query, string get) // Hàm truy vấn lấy ra dữ liệu
        {
            string result = ""; // Gán kết quả mặc định bằng rỗng

            SqlConnection sqlconn = new SqlConnection(Conn); // Kết nối database

            try
            {
                sqlconn.Open(); // Mở kết nối

                SqlCommand cmd = new SqlCommand(query, sqlconn);
                SqlDataReader drd = cmd.ExecuteReader(); // Đọc dữ liệu

                while (drd.Read())
                {
                    result += drd[get].ToString();
                }

                drd.Close();

                sqlconn.Close(); // Đóng kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối => chi tiết: " + ex.Message);
            }


            return result; // trả kết quả
        }

        public List<string> TakeListData(string query) // Hàm truy vấn lấy ra dữ liệu
        {
            List<string> result = new List<string>();

            SqlConnection sqlconn = new SqlConnection(Conn); // Kết nối database

            try
            {
                sqlconn.Open(); // Mở kết nối

                SqlCommand cmd = new SqlCommand(query, sqlconn);
                SqlDataReader drd = cmd.ExecuteReader(); // Đọc dữ liệu

                while (drd.Read())
                {
                    result.Add(drd[0].ToString());
                }

                drd.Close();

                sqlconn.Close(); // Đóng kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối => chi tiết: " + ex.Message);
            }


            return result; // trả kết quả
        }

        public int PrintData(string sql, System.Drawing.Printing.PrintPageEventArgs ea, string dk, int bnDefault) // Hàm xử lý in phiếu nhập và hóa đơn
        {
            int buocnhay = bnDefault; // Vị trí mặc định để in tổng tiền

            SqlConnection sqlconn = new SqlConnection(Conn); // Kết nối database

            try
            {
                sqlconn.Open(); // Mở kết nối

                SqlCommand cmd = new SqlCommand(sql, sqlconn);

                SqlDataReader dr = cmd.ExecuteReader(); // Đọc dữ liệu

                int y = 390; // height nội dung tiêu đề mục lớn hơn tiêu đề mục 50 => Hóa đơn
                int yy = 500; // height nội dung tiêu đề mục lớn hơn tiêu đề mục 50 => Phiếu nhập

                if (dr.FieldCount == 1) // Kiểm tra dữ liệu có 1 cột
                {
                    while (dr.Read())
                    {
                        decimal money = decimal.Parse(dr[0].ToString());
                        ea.Graphics.DrawString("TỔNG TIỀN: ", new Font("Calibri", 18, FontStyle.Bold), Brushes.Black, new PointF(460, buocnhay));
                        ea.Graphics.DrawString(money.ToString("#,##0") + "đ", new Font("Calibri", 18, FontStyle.Bold), Brushes.Red, new PointF(610, buocnhay));
                    }
                }
                else if (dr.FieldCount == 3) // Kiểm tra dữ liệu có 3 cột
                {
                    while (dr.Read())
                    {
                        if (dk.ToString() == "Hóa Đơn")
                        {
                            string infoHD = "Hóa đơn #" + dr[0].ToString() + "\nNgày " + dr[1].ToString() + "\nSố lượng sách: " + dr[2].ToString();
                            ea.Graphics.DrawString(infoHD.ToString(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new PointF(610, 195));
                        }
                        else if (dk.ToString() == "Khách Hàng")
                        {
                            // Thiết lập khi địa chỉ xuống dòng khi đến vị trí mặc định
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Near;
                            stringFormat.LineAlignment = StringAlignment.Near;
                            stringFormat.Trimming = StringTrimming.Word;

                            string infoKH = "\nHọ tên khách hàng: " + dr[0].ToString() + "\nSố điện thoại khách hàng: (+84)" + dr[1].ToString() + "\nĐịa chỉ khách hàng: " + dr[2].ToString();
                            ea.Graphics.DrawString(infoKH.ToString(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new RectangleF(50, 160, 510, ea.PageBounds.Height - 100), stringFormat);
                        }
                        else if (dk.ToString() == "Phiếu Nhập")
                        {
                            string infoHD = "Phiếu nhập #" + dr[0].ToString() + "\nNgày " + dr[1].ToString() + "\nSố lượng sách: " + dr[2].ToString();
                            ea.Graphics.DrawString(infoHD.ToString(), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new PointF(610, 50));
                        }
                        else if (dk.ToString() == "Nhà Cung Cấp")
                        {
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Near;
                            stringFormat.LineAlignment = StringAlignment.Near;
                            stringFormat.Trimming = StringTrimming.Word;

                            string infoKH = "\nTên nhà cung cấp: " + dr[0].ToString() + "\nSố điện thoại nhà cung cấp: (+84)" + dr[1].ToString() + "\nĐịa chỉ nhà cung cấp: " + dr[2].ToString();
                            ea.Graphics.DrawString(infoKH.ToString(), new Font("Calibri", 14, FontStyle.Regular), Brushes.Black, new RectangleF(50, 280, 510, ea.PageBounds.Height - 100), stringFormat);
                        }
                    }
                }
                else if (dr.FieldCount == 4) // Kiểm tra dữ liệu có 4 cột
                {
                    while (dr.Read())
                    {
                        if (dk.ToString() == "Hóa Đơn")
                        {
                            decimal money1 = decimal.Parse(dr[2].ToString());
                            decimal money2 = decimal.Parse(dr[3].ToString());
                            ea.Graphics.DrawString(dr[0].ToString() + "\t\t\t" + dr[1].ToString() + "\t\t" + money1.ToString("#,##0") + "đ\t\t" + money2.ToString("#,##0") + "đ", new Font("Calibri", 16, FontStyle.Regular), Brushes.Black, new PointF(50, y));
                            y += 50;
                            buocnhay = y;
                        }
                        else if (dk.ToString() == "Phiếu Nhập")
                        {
                            decimal money1 = decimal.Parse(dr[2].ToString());
                            decimal money2 = decimal.Parse(dr[3].ToString());
                            ea.Graphics.DrawString(dr[0].ToString() + "\t\t\t" + dr[1].ToString() + "\t\t" + money1.ToString("#,##0") + "đ\t\t" + money2.ToString("#,##0") + "đ", new Font("Calibri", 16, FontStyle.Regular), Brushes.Black, new PointF(50, yy));
                            yy += 50;
                            buocnhay = yy;
                        }
                    }
                }

                sqlconn.Close(); // Đóng kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối => chi tiết: " + ex.Message);
            }

            return buocnhay;
        }
    }
}
