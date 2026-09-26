using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT07
{
    internal class Program
    {
        static void Main(string[] args)
        {
           HinhChuNhat a = new HinhChuNhat();
           a.Nhap();
           a.Xuat();
           Console.ReadLine();
        }
    }
}