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
            PhanSo a = new PhanSo();
            a.TuSo = 3;
            a.MauSo = 9;
            a.RutGon();
            a.HienThiPhanSo();

            PhanSo b = new PhanSo(7,2);
            PhanSo c = a.TinhTong(b);
            c.RutGon();
            c.HienThiPhanSo();

            DanhSachPhanSo ds = new DanhSachPhanSo();
            ds.NhapDanhSachPhanSo();
            ds.HienThiDanhSachPhanSo();

            Console.WriteLine("Toi gian danh sach");
            ds.RutGonDS();
            ds.HienThiDanhSachPhanSo();

            Console.WriteLine("Tim kiem.\n\t Nhap phan so can tim: ");
            PhanSo p = new PhanSo();
            p.NhapPhanSo();
            if(ds.SearchPS(p))
            {
                Console.WriteLine("Tim thay phan so trong danh sach.");
            }
            else
            {
                Console.WriteLine("Khong tim thay phan so trong danh sach.");
            }

            Console.WriteLine("Danh sach sau khi sap xep");
            DanhSachPhanSo dsSapXep = ds.SortGiaTri();
            dsSapXep.HienThiDanhSachPhanSo();

            Console.WriteLine("Danh sach phan so > 1:");
            DanhSachPhanSo dsLonHon1 = ds.LocDuLieu();
            dsLonHon1.HienThiDanhSachPhanSo();

            Console.WriteLine("Phan so lon nhat: ");
            PhanSo max = ds.MaxPhanSo();
            max.HienThiPhanSo();

            Console.WriteLine("Danh sach ba phan so lon nhat");
            DanhSachPhanSo top3 = ds.Top3PS();
            top3.HienThiDanhSachPhanSo();
        }
    }
}
