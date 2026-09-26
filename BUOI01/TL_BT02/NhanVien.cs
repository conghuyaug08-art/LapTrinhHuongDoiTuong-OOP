using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT02
{
    internal class NhanVien
    {
        string maNV;
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        string hoTen;
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        int soNC;
        public int SoNC
        {
            get { return soNC; }
            set
            {
                if (value >= 0)
                    soNC = value;
                else
                    Console.WriteLine("Du lieu loi");
                    soNC = 0;
            }
        }

        public char XepLoai
        {
            get
            {
                if (SoNC >= 26)
                    return 'A';
                else if (SoNC >= 22)
                    return 'B';
                else
                    return 'C';
            }

        }

        public static double LuongNgay = 200000;

        public NhanVien()
        {
            MaNV = "3002";
            HoTen = "Van hoa";
            SoNC = 25;
        }

        public NhanVien (string maNV, string HoTen, int soNC)
        {
            this.maNV = maNV;
            this.HoTen = HoTen;
            this.SoNC = soNC;
        }

        public NhanVien (NhanVien nv)
        {
            this.MaNV = nv.MaNV;
            this.HoTen = nv.HoTen;
            this.SoNC = nv.SoNC;
        }

        public void Nhap()
        {
            Console.WriteLine("Nhap ma so: ");
            MaNV = Console.ReadLine();
            Console.WriteLine("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.WriteLine("Nhap so ngay cong: ");
            SoNC = int.Parse(Console.ReadLine());

        }

        public double  TinhLuong()
        {
            return SoNC * NhanVien.LuongNgay;
        }

        public double TinhThuong()
        {
            if (XepLoai == 'A')
                return TinhLuong() * 5 / 100;
            else if (XepLoai == 'B')
                return TinhLuong() * 2 / 100;
            else return 0;
        }

        public void Xuat  ()
        {
            Console.WriteLine("{0}, {1},  {2}, {3}, {4}, {5}",
                MaNV, HoTen, SoNC, XepLoai, TinhLuong(), TinhThuong()); 
        }
        
    }
}
