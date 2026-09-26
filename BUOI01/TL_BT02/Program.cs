using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NhanVien nv1 = new NhanVien();
            Console.WriteLine("Thong tin nhan vien 1");
            nv1.Xuat();
            
            NhanVien nv2 = new NhanVien();
            nv2.Nhap();
            Console.WriteLine("Thong tin nhan vien 2");
            nv2.Xuat();

            NhanVien nv3 =new NhanVien("NV003", "Tran Hoang Anh", 25);
            Console.WriteLine("Thong tin nhan vien 3");
            nv3.Xuat();

            NhanVien nv4 = new NhanVien("NV004", "Tran Hoa", 1);
            Console.WriteLine("Thong tin nhan vien 4");
            nv4.Xuat();
            Console.ReadLine();
        }
    }
}
