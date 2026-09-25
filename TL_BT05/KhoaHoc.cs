using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT05
{
    internal class KhoaHoc
    {
        string maKH;
        string tenKH;
        int soBuoi;
        string gioHoc;
        int soLuong;
        string gv;

        static public double hocPhi = 100;
        static public double thuLao = 500;

        bool kiemTra(char x)
        {
            return x >= '1' && x <= '3';
        }
        public string MaKH
        {
            get { return maKH; }
            set
            {
                if (value != null &&
                    value.Length == 5 &&
                    value.StartsWith("KH") &&
                    kiemTra(value[2]) &&
                    char.IsDigit(value[3]) &&
                    char.IsDigit(value[4]))
                    maKH = value;
                else
                {
                    Console.WriteLine("Ma khach hang phai co dang KH1XX, KH2XX, KH3XX");
                    maKH = "KH1XX";
                }
            }
        }

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }

        public int SoBuoi
        {
            get { return soBuoi; }
            set
            {
                if (value > 0)
                    soBuoi = value;
                else
                {
                    Console.WriteLine("Loi! So buoi phai lon hon 0");
                    soBuoi = 0;
                }
            }
        }

        public string GioHoc
        {
            get { return gioHoc; }
            set
            {
                if(value == "2,4,6" || value == "3,5,7" || value == "7,CN")
                    gioHoc = value;
                else
                {
                    Console.WriteLine("Loi! Gio hoc khong hop le");
                    gioHoc = "2,4,6";
                }
            }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set
            {
                if(value >= 10 && value <= 20)
                    soLuong = value;
                else
                {
                    Console.WriteLine("Loi! So luong khong hop le");
                    soLuong = 0;
                }
            }
        }

        public string GV
        {
            get { return GV; }
            set { gv = value; }
        }

        public KhoaHoc() { }

        public KhoaHoc(string maKH, string tenKH, int soBuoi, string gioHoc, int soLuong, string gv)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SoBuoi = soBuoi;
            GioHoc = gioHoc;
            SoLuong = soLuong;
            GV = gv;
        }

        public KhoaHoc(KhoaHoc a)
        {
            MaKH = a.MaKH;
            TenKH =a.TenKH;
            SoBuoi = a.SoBuoi;
            GioHoc = a.GioHoc;
            SoLuong = a.SoLuong;
            GV = a.GV;
        }

        public double TinhHocPhi()
        {
            if (GioHoc == "2,4,6" || GioHoc == "3,5,7")
                return SoBuoi * hocPhi;
            else if (GioHoc == "7, CN")
                return SoBuoi * hocPhi * 1.2;
            else
                return 0;
        }

        public double TinhThuLao()
        {
            if (SoLuong >= 15)
                return SoBuoi * thuLao + 10 * SoBuoi;
            else
                return SoBuoi * thuLao;
        }

        public void NhapKH()
        {
            Console.WriteLine("=====NHAP THONG TIN KHOA HOC====");
            Console.WriteLine("Nhap ma khoa hoc (KH1XX, KH2XX, KH3XX): ");
            MaKH = Console.ReadLine();
            Console.WriteLine("Nhap ten khoa hoc: ");
            TenKH = Console.ReadLine();
            Console.WriteLine("Nhap so buoi hoc: ");
            SoBuoi = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao so gio hoc: ");
            GioHoc = Console.ReadLine();
            Console.WriteLine("Nhap vao so luong hoc vien: ");
            SoLuong = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap vao giao vien giang day: ");
            GV = Console.ReadLine();
        }

        public void XuatKH()
        {
            Console.WriteLine("====THONG TIN KHOA HOC====");
            Console.WriteLine(
                "{0, -10}{1, -20}{2, -10}{3, -10}{4, -10}{5, -20}{6, -10}{7, -10}{8, -10}{9, -10}"
                , "Ma KH", "Ten khoa hoc", "So buoi", "Gio hoc", "So Luong", "Giao Vien", "Hoc phi 1B","Hoc phi KH","Thu lao 1B","Thu lao");
            Console.WriteLine(
                "{0, -10}{1, -20}{2, -10}{3, -10}{4, -10}{5, -20}{6, -10}{7, -10}{8, -10}{9, -10}"
                , maKH, tenKH, soBuoi, gioHoc, soLuong, gv, hocPhi, TinhHocPhi(), thuLao, TinhThuLao());
        }       
    }
}
