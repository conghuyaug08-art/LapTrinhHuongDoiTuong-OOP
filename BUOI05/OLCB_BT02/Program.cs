using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace B6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            danhsachhoadon ds = new danhsachhoadon();

            try
            {
                ds.docfile("../../CongTy.xml");
                Console.WriteLine("Doc file XML thanh cong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi doc file: " + ex.Message);
                Console.WriteLine("Hay kiem tra lai file hoadon.xml.");
                Console.ReadKey();
                return;
            }

            int chon;

            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Xuat danh sach hoa don");
                Console.WriteLine("2. Tinh tong tien hoa don");
                Console.WriteLine("3. Khach hang mua nhieu nhat");
                Console.WriteLine("4. Tong chiet khau khach hang cong ty");
                Console.WriteLine("5. In danh sach dai ly cap 1");
                Console.WriteLine("6. Sap xep danh sach hoa don");
                Console.WriteLine("7. Tim hoa don theo ma khach hang");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    chon = -1;
                }

                switch (chon)
                {
                    case 1:
                        ds.xuatdanhsach();
                        break;

                    case 2:
                        Console.WriteLine(
                            $"Tong tien hoa don: {ds.tongtien():N0}");
                        break;

                    case 3:
                        ds.xuatkhachhangmuanhieunhat();
                        break;

                    case 4:
                        Console.WriteLine(
                            $"Tong chiet khau cong ty: " +
                            $"{ds.tongtienchietkhaukhachhangcongty():N0}");
                        break;

                    case 5:
                        ds.indailycap1();
                        break;

                    case 6:
                        ds.sort();
                        break;

                    case 7:
                        Console.Write("Nhap ma khach hang: ");
                        string makh = Console.ReadLine() ?? "";
                        ds.xuathoadontheomakh(makh);
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

