using PMQL_BookStores.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_BookStores.BUS
{
    public class AdminBUS
    {
        private static AdminBUS instance;

        public static AdminBUS Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new AdminBUS();
                return instance;
            } 

            set => instance = value; 
        }

        private Form formParent; // Khai báo form hiện tại của admin là rỗng

        public AdminBUS(){}

        public void openFormChild(Form formChild,Panel pnl) // Hàm mở form con của admin
        {
            if (formParent != null) // Nếu form hiện tại khác rỗng thì đóng form hiện tại lại
            {
                formParent.Close();
            }

            formParent = formChild; // Gán form hiện tại bằng form con
            formChild.TopLevel = false; // Dùng để tạo biểu mẫu cấp cao nhất
            formChild.FormBorderStyle = FormBorderStyle.None; // dùng để tạo cửa sổ công cụ
            formChild.Dock = DockStyle.Fill; // Điều khiển lấp đầy
            pnl.Controls.Add(formChild); // Dùng để form admin tham chiếu đến các form con của mình
            pnl.Tag = formChild; // dùng để thay thế form admin thành form con của nó
            formChild.BringToFront(); // Hàm gọi form con để hiển thị
            formChild.Show(); // Mở form con lên
        }

        public void HomePageBack(frm_Admin frmAD,Label title, AxWMPLib.AxWindowsMediaPlayer AMP)
        {
            frmAD.ActiveControl = null; // Tất cả control bên trong form không được chọn

            if (formParent != null) // Nếu click vào hình ảnh logo thì đóng form hiện tại và mở lại form admin
            {
                formParent.Close();
            }
            title.Text = "BookStores"; // Gán text của label tiêu đề admin

            if (System.IO.File.Exists(Application.StartupPath + "\\logoBookStores\\Video-Welcome.mp4")) // Kiểm tra video có tồn tại không
            {
                AMP.URL = Application.StartupPath + "\\logoBookStores\\Video-Welcome.mp4"; // cài đặt đường dẫn đến video

                AMP.uiMode = "none"; // Tắt thanh công cụ trên control phát video
                AMP.stretchToFit = true; // Điều chỉnh kích thước control phát video vừa khung

                AMP.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(frmAD.wmpWelcome_PlayStateChange); // gọi sự kiện thay đổi trạng thái phát của control phát video
            }
        }

        public void AdminShown(frm_Admin frmAD,AxWMPLib.AxWindowsMediaPlayer AMP) // form được mở lên
        {
            frmAD.ActiveControl = null; // Tất cả control bên trong form không được chọn

            if (System.IO.File.Exists(Application.StartupPath + "\\logoBookStores\\Video-Welcome.mp4")) // Kiểm tra video có tồn tại không
            {
                AMP.URL = Application.StartupPath + "\\logoBookStores\\Video-Welcome.mp4"; // cài đặt đường dẫn đến video

                AMP.uiMode = "none"; // Tắt thanh công cụ trên control phát video
                AMP.stretchToFit = true; // Điều chỉnh kích thước control phát video vừa khung

                AMP.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(frmAD.wmpWelcome_PlayStateChange); // gọi sự kiện thay đổi trạng thái phát của control phát video
            }
        }
    }
}
