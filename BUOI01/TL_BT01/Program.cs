using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string maSV, hoTen;
            float diemTB;
            string xepLoai;

            Console.WriteLine("Nhap thong tin sinh vien: ");
            Console.WriteLine("Nhap ma so SV: ");
            maSV = Console.ReadLine();
            Console.WriteLine("Nhap ho ten: ");
            hoTen = Console.ReadLine();
            Console.WriteLine("Nhap diem trung binh: ");
            diemTB = float.Parse(Console.ReadLine());
            if (diemTB >= 8)
                xepLoai = "Gioi";
            else if (diemTB >= 6.5)
                xepLoai = "Kha";
            else if (diemTB >= 5)
                xepLoai = "Trung binhh";
            else
                xepLoai = "Yeu kem";
            Console.WriteLine("Thong tin sv: \n MSSV: {0} - Ho ten: {1} - DTB: {2:0.00} -  Xep loai: {3}", maSV, hoTen, diemTB, xepLoai);
            Console.ReadLine();
        }
    }
}
