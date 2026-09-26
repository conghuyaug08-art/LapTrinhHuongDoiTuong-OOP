using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT06
{
    internal class NuocGiaiKhat
    {
        string tenHang;
        string donViTinh;
        int soLuong;
        double donGia;
        public static double VAT = 0.1;

        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }

        public string DonViTinh
        {
            get { return donViTinh; }
            set
            {
                if (value == "Ket" || value == "Thung" || value == "Chai" || value == "Lon")
                    donViTinh = value;
                else
                {
                    Console.WriteLine("Loi! Don vi tinh khong hop le");
                    donViTinh = "Ket";
                }
            }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set
            {
                if (value >= 0)
                    soLuong = value;
                else
                {
                    Console.WriteLine("Loi! So luong phai lon hon hoac bang 0");
                    soLuong = 0;
                }
            }
        }

        public double DonGia
        {
            get { return donGia; }
            set
            {
                if(value >= 0)
                    donGia = value;
                else
                {
                    Console.WriteLine("Loi! Don gia phai lon hoac bang 0");
                    donGia = 0;
                }
            }
        }

        public NuocGiaiKhat()
        { }

        public NuocGiaiKhat(string tenHang, string donViTinh, int soLuong, double donGia)
        {
            TenHang = tenHang;
            DonViTinh = donViTinh;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public NuocGiaiKhat(NuocGiaiKhat a)
        {
            TenHang = a.TenHang;
            DonViTinh = a.DonViTinh;
            SoLuong = a.SoLuong;
            DonGia = a.DonGia;
        }

        public double ThanhTien()
        {
            if (DonViTinh == "Ket" || DonViTinh == "Thung")
                return SoLuong * DonGia * (1 + VAT);
            else if (DonViTinh == "Chai")
                return SoLuong * (DonGia / 20) * (1 + VAT);
            else if (DonViTinh == "Lon")
                return SoLuong * (DonGia / 24) * (1 + VAT);
            else
                return 0;
        }

        public void NhapMH()
        {
            Console.WriteLine("====NHAP THONG TIN MAT HANG====");
            Console.Write("Nhap vao ten hang: ");
            TenHang = Console.ReadLine();
            Console.Write("Nhap vao don vi tinh: ");
            DonViTinh = Console.ReadLine();
            Console.Write("Nhap vao so luong: ");
            SoLuong = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao don gia: ");
            DonGia = double.Parse(Console.ReadLine());
            Console.WriteLine("===============================");
        }

        public void XuatMH()
        {
            Console.WriteLine("====THONG TIN MAT HANG====");
            Console.WriteLine(
                "{0,-15}{1,-20}{2,-15}{3,-15}{4,-15}",
                "TEN MH", "DON VI TINH", "SO LUONG", "DON GIA", "THANH TIEN");

            Console.WriteLine(
                "{0,-15}{1,-20}{2,-15}{3,-15:F1}{4,-15:F1}",
                tenHang, donViTinh, soLuong, donGia, ThanhTien());
        }
    }
}
