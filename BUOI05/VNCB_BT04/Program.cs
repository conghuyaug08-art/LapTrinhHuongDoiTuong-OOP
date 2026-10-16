using System;

namespace Bai4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DanhSachHoaDon ds = new DanhSachHoaDon();

            try
            {
                ds.DocFile("../../hoadon.xml");
                Console.WriteLine("Doc file XML thanh cong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi doc file: " + ex.Message);
                Console.ReadKey();
                return;
            }

            int chon;

            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuat danh sach hoa don");
                Console.WriteLine("2. Xuat hoa don khach vang lai");
                Console.WriteLine("3. Tinh tong tri gia");
                Console.WriteLine("4. Xuat hoa don co tri gia cao nhat");
                Console.WriteLine("5. Dem hoa don VIP va than thiet");
                Console.WriteLine("6. Sap xep hoa don");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                    chon = -1;

                switch (chon)
                {
                    case 1:
                        ds.XuatDanhSach();
                        break;

                    case 2:
                        ds.XuatHoaDonVangLai();
                        break;

                    case 3:
                        Console.WriteLine(
                            $"Tong tri gia: {ds.TongTriGia():N0} VND");
                        break;

                    case 4:
                        ds.XuatHoaDonTriGiaCaoNhat();
                        break;

                    case 5:
                        ds.DemHoaDon();
                        break;

                    case 6:
                        ds.SapXep();
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

            } while (chon != 0);

            Console.ReadKey();
        }
    }
}
