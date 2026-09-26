using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT04
{
    internal class HoaDon
    {
        string hangSX;
        string soSeri;
        string tenSP;
        double giaBan;
        string loaiSP;
        public static double VAT = 0.1;

        public string HangSX
        {
            get { return hangSX; }
            set { hangSX = value; }
        }

        public string SoSeri
        {
            get { return soSeri; }
            set
            {
                if (value.StartsWith("S"))
                    soSeri = value;
                else
                {
                    Console.WriteLine("Du lie loi");
                    soSeri = "S000";
                }
            }
        }

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }

        public double GiaBan
        {
            get { return  giaBan; }
            set
            {
                if (value > 4)
                    giaBan = value;
                else
                {
                    Console.WriteLine("Gia ban phai lon hon 4 trieu");
                    giaBan = 0;
                }
            }
        }

        public string LoaiSP
        {
            get { return loaiSP; }
            set
            {
                if (value == "May tinh de ban" || value == "May tinh xach tay" || value == "Dien thoai di dong")
                    loaiSP = value;
                else
                {
                    Console.WriteLine("Loai san pham khong hop le");
                    loaiSP = "Dien thoai di dong";
                }
            }
        }

        public double ThanhTien()
        {
            return GiaBan + PhiBaoHanh() - UuDai() + Thue();
        }

        public double PhiBaoHanh()
        {
            if (loaiSP == "May tinh de ban")
                return 0.08 * GiaBan;
            else if (loaiSP == "May tinh xach tay")
                return 0.05 * GiaBan;
            else if (loaiSP == "Dien thoai di dong")
                if (0.1 * GiaBan <= 2)
                    return 0.1 * GiaBan;
                else
                    return 0.0;
            else
                return 0.0;
        }

        public double UuDai()
        {
            if (hangSX == "SamSung" && loaiSP == "Dien thoai di dong")
                return 0.5;
            else
                return 0.0;
        }
        
        public double Thue()
        {
            return GiaBan * VAT;
        }

        public HoaDon() { }

        public HoaDon(string hangSX, string soSeri, string tenSP, double giaBan, string loaiSP)
        {
            HangSX = hangSX;
            SoSeri = soSeri;
            TenSP = tenSP;
            GiaBan = giaBan;
            LoaiSP = loaiSP;
        }

        public HoaDon(HoaDon a)
        {
            HangSX = a.HangSX;
            SoSeri = a.SoSeri;
            TenSP = a.TenSP;
            GiaBan = a.GiaBan;
            LoaiSP = a.LoaiSP;
        }

        public void NhapHoaDon()
        {
            Console.WriteLine("===NHAP VAO THONG TIN HOA DON===");
            Console.WriteLine("Nhap hang san xuaat: ");
            HangSX = Console.ReadLine();
            Console.WriteLine("Nhap so seri: ");
            SoSeri = Console.ReadLine();
            Console.WriteLine("Nhap ten san pham: ");
            TenSP = Console.ReadLine();
            Console.WriteLine("Nhap gia ban: ");
            GiaBan = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap loai san pham: ");
            LoaiSP = Console.ReadLine();
        }

        public void XuatHoaDon()
        {
            Console.WriteLine(
                "{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-15}",
                "Hang san xuat", "So seri", "Ten san pham", "Gia ban", "Loai san pham", "Thanh Tien");

            Console.WriteLine(
                "{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-15:F1}",
                hangSX, soSeri, tenSP, giaBan, loaiSP, ThanhTien());
        }



    }
}
