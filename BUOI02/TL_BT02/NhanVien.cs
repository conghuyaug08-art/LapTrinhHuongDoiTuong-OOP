using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT02
{
    internal class NhanVien
    {
        string maSo;
        string tenNV;
        float heSoLuong;
        int namVaoLam;
        public static int MucLuongToiThieu = 2340000;
        public string MaSo
        {
            get { return maSo; }
            set { maSo = value; }
        }
        
        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }

        public float HeSoLuong
        {
            get { return heSoLuong; }
            set
            {
                if (value < 0)
                    heSoLuong = 0;
                else
                    heSoLuong = value;
            }
        }

        public int NamVaoLam
        {
            get { return namVaoLam; }
            set
            {
                if (value < 0)
                    namVaoLam = 0;
                else
                    namVaoLam = value;
            }
        }

        public NhanVien()
        {
            MaSo = "32";
            TenNV = "Hoa";
            HeSoLuong = 2.34f;
            NamVaoLam = 2021;
        }

        public NhanVien(string maSo, string tenNV, float heSoLuong, int namVaoLam)
        {
            MaSo = maSo;
            TenNV = tenNV;
            HeSoLuong = heSoLuong;
            NamVaoLam = namVaoLam;
        }

        public NhanVien(NhanVien a)
        {
            MaSo = a.MaSo;
            TenNV = a.TenNV;
            HeSoLuong = a.HeSoLuong;
            NamVaoLam = a.NamVaoLam;
        }

        public float TinhLuongCoBan()
        {
            return HeSoLuong * NhanVien.MucLuongToiThieu;
        }

        public float TinhHeSOPCTN()
        {
            return (DateTime.Today.Year - NamVaoLam);
        }

        public float TinhLuong()
        {
            return TinhLuongCoBan() * (1 + TinhHeSOPCTN());
        }

        public void Nhap()
        {
            Console.WriteLine("Nhap ma so: ");
            MaSo = Console.ReadLine();
            Console.WriteLine("Nhap ten: ");
            TenNV = Console.ReadLine();
            Console.WriteLine("Nhap he so luong: ");
            HeSoLuong = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhap nam vao lam: ");
            NamVaoLam=int.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine("\t{0} \t{1} \t{2} \t{3} \t{4}"
                ,MaSo, TenNV, HeSoLuong, NamVaoLam, TinhLuong());
        }
    }
}
