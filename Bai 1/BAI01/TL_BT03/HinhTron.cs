using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT03
{
    internal class HinhTron
    {
        double r;
        public double R
        {
            get { return r; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Du lieu bi loi");
                    r = 0;
                }
                else
                    r = value;
            }
        }

        public HinhTron()
        {
            this.R = 0;
        }

        public HinhTron(double r)
        {
            this.R = r;
        }

        public void Nhap()
        {
            Console.WriteLine("Nhap ban kinh hinh tron: ");
            this.R = double.Parse(Console.ReadLine());
        }

        public double TinhChuVi()
        {
            return this.R * 2 * Math.PI;
        }

        public double TinhDienTich()
        {
            return Math.Pow(this.R, 2);
        }

        public void Xuat()
        {
            Console.WriteLine("Hinh Tron co ban kinh: {0:0.00}, Chu vi: {1:0.00}, Dien tich: {2:0.00}", R, TinhChuVi(), TinhDienTich()); 
        }
    }
}
