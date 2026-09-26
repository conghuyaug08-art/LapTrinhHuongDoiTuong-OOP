using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT01
{
    public static class TienIch
    {
        public static int UCLN(int a, int b)
        {
            if(a == 0 || b == 0)
                return  a + b;

            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
    }
    class PhanSo
    {
        int tuSo;
        int mauSo;
        double giaTriThuc;

        public int TuSo
        {
            get { return tuSo; }
            set
            {
                if (value > 0)
                {
                    tuSo = value;
                }
                else
                {
                    throw new ArgumentException("Tử số phải lớn hơn 0");
                }
            }
        }

        public int MauSo
        {
            get { return mauSo; }
            set
            {
                if (value > 0)
                {
                    mauSo = value;
                }
                else
                {
                    throw new ArgumentException("Mẫu số phải lớn hơn 0");
                }
            }
        }

        public double GiaTriThuc
        {
            get
            {
                return (double)tuSo / mauSo;
            }
        }

        //Phuong thuc khoi tao
        public PhanSo()
        {
            this.TuSo = 1;
            this.MauSo = 1;
        }

        public PhanSo(int tuSo, int mauSo)
        {
            this.TuSo = tuSo;
            this.MauSo = mauSo;
        }

        public PhanSo(PhanSo ps)
        {
            this.TuSo = ps.TuSo;
            this.MauSo = ps.MauSo;
        }

        public void RutGon()
        {
            int uc = TienIch.UCLN(this.TuSo, this.MauSo);
            TuSo /= uc;
            MauSo /= uc;
        }

        public PhanSo TinhTong(PhanSo p)
        {
            PhanSo tong = new PhanSo();
            tong.TuSo = this.TuSo * p.MauSo
                + p.TuSo * this.MauSo;
            tong.MauSo = this.MauSo * p.MauSo;
            tong.RutGon();
            return tong;
        }

        public PhanSo TinhTong(int x)
        {
            //Cach 1
            PhanSo tong = new PhanSo();
            tong.TuSo = this.TuSo + x * this.MauSo;
            tong.MauSo = this.MauSo;
            tong.RutGon();
            return tong;

            //Cach 2
            //return this.TinhTong(new PhanSo(x, 1));
        }

        public void NhapPhanSo()
        {
            Console.Write("Nhap tu so: ");
            this.TuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            this.MauSo = int.Parse(Console.ReadLine());
        }

        public void HienThiPhanSo()
        {
            Console.WriteLine("{0}/{1}", this.TuSo, this.MauSo);
        }
    }
}
