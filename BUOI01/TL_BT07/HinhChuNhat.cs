using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT07
{
    internal class HinhChuNhat
    {
        double dai, rong;

        public double Dai
        {
            get { return dai; }
            set
            {
                if (value > 0)
                    dai = value;
                else
                {
                    Console.WriteLine("Loi! Chieu dai phai lon hon 0");
                    dai = 0;
                }
            }
        }

        public double Rong
        {
            get { return rong; }
            set
            {
                if (value > 0)
                    rong = value;
                else
                {
                    Console.WriteLine("Loi! Chieu rong phai lon hon 0");
                    rong = 0;
                }
            }
        }

        public HinhChuNhat() { }

        public HinhChuNhat(double dai, double rong)
        {
            Dai = dai;
            Rong = rong;
        }

        public HinhChuNhat(HinhChuNhat a)
        {
            Dai = a.Dai;
            Rong = a.Rong;
        }

        public double ChuVi()
        {
            return (Dai + Rong) * 2;
        }

        public double DienTich()
        {
            return Dai * Rong;
        }

        public double DuongCheo()
        {
            return Math.Sqrt(Dai * Dai + Rong * Rong);
        }

        public void Nhap()
        {
            Console.WriteLine("===NHAP THONG TIN HINH CHU NHAT===");

            Console.Write("Nhap chieu dai: ");
            do
            {
                Dai = double.Parse(Console.ReadLine());
            } while (Dai <= 0);

            Console.Write("Nhap chieu rong: ");
            do
            {
                Rong = double.Parse(Console.ReadLine());
            } while (Rong <= 0);
        }

        public void Xuat()
        {
            Console.WriteLine("===THONG TIN HINH CHU NHAT===");
            Console.WriteLine(
                "{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}", "Chieu Dai", "Chieu Rong", "Chu vi", "Dien Tich", "Duong cheo");
            Console.WriteLine(
               "{0, -20:F1}{1, -20:F1}{2, -20:F1}{3, -20:F1}{4, -20:F1}", Dai, Rong, ChuVi(), DienTich(), DuongCheo());
        }
    }
}
