# Hệ thống Quản lý Cửa hàng Sách (BookStores Management System)

Đây là đồ án môn học: Xây dựng ứng dụng quản lý cửa hàng sách toàn diện bằng WinForms và SQL Server.

## Tính năng chính
* **Quản lý hệ thống:** Đăng nhập phân quyền (Admin, Thu ngân, Quản lý kho).
* **Quản lý nghiệp vụ:**
  * Nhập hàng từ nhà cung cấp, quản lý tồn kho.
  * Bán hàng, lập hóa đơn cho khách hàng.
* **Quản lý danh mục:** Sách, Thể loại sách, Nhân viên, Khách hàng, Nhà cung cấp, Phiếu Nhập, Hóa đơn.
* **Tiện ích:** Tìm kiếm thông minh, **In Hóa đơn & Phiếu nhập trực tiếp**.

## Công nghệ sử dụng
* **Ngôn ngữ:** C# (.NET Framework).
* **Giao diện:** Windows Forms (WinForms).
* **Cơ sở dữ liệu:** SQL Server.
* **Kiến trúc:** 3-Layer (DAL, BUS, GUI) kết hợp Singleton Pattern DataProvider.

## Hướng dẫn chạy dự án
* **Database:** Vào thư mục Database, chạy script `BookStores.sql` trong SQL Server.
* **Chạy:** Mở file `.sln` bằng Visual Studio và nhấn `F5`.

## Tài khoản Demo
* **Admin:** `admin` / `123456`.
* **Thu ngân:** `staff1` / `123456`.
* **Quản lý kho:** `staff2` / `123456`.
