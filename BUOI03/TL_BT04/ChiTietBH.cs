using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TL_BT04
{
    internal class ChiTietBH
    {
        public static float VAT = 0.1f;
        string maSP;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        string tenSP;
        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
        float giaBan;
        public float GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }
        int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }

        }
        public ChiTietBH(string maSP, string tenSP, float giaBan, int soLuong)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.giaBan = giaBan;
            this.soLuong = soLuong;
        }

        public ChiTietBH()
        {
            this.maSP = "";
            this.tenSP = "";
            this.giaBan = 0;
            this.soLuong = 0;
        }

        public ChiTietBH(ChiTietBH ct)
        {
            this.maSP = ct.maSP;
            this.tenSP = ct.tenSP;
            this.giaBan = ct.giaBan;
            this.soLuong = ct.soLuong;
        }

        public float ThanhTien
        {
            get { return giaBan * soLuong * (1 + VAT); }
        }

        public void Xuat()
        {
            Console.WriteLine("{0,-10} {1,-20} {2,10} {3,10} {4,10}", maSP, tenSP, giaBan, soLuong, ThanhTien);
        }
    }
    class HoaDon
    {
        string maHD;
        public string MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }

        string tenKH;
        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }
        List<ChiTietBH> dsCTBH;
        internal List<ChiTietBH> DsCTBH { get => dsCTBH; set => dsCTBH = value; }
        public HoaDon(string maHD, string tenKH, List<ChiTietBH> dsCTBH)
        {
            this.maHD = maHD;
            this.tenKH = tenKH;
            this.dsCTBH = dsCTBH;
        }

        public HoaDon()
        {
            this.maHD = "";
            this.tenKH = "";
            this.dsCTBH = new List<ChiTietBH>();
        }

        public HoaDon(HoaDon hd)
        {
            this.maHD = hd.maHD;
            this.tenKH = hd.tenKH;
            this.dsCTBH = new List<ChiTietBH>(hd.dsCTBH);
        }

        public float TongTien()
        {
            return dsCTBH.Sum(t => t.ThanhTien);
        }

        public void Xuat()
        {
            Console.WriteLine("=== Hoa Don ===");
            Console.WriteLine("Ma HD: {0}, Ten KH: {1}", maHD, tenKH);
            Console.WriteLine("{0,-10} {1,-20} {2,10} {3,10} {4,10}", "Ma SP", "Ten SP", "Gia Ban", "So Luong", "Thanh Tien");
            foreach (var ct in dsCTBH)
            {
                ct.Xuat();
            }
        }

        public void DocFileXML(string filename)
        {
            XmlDocument read = new XmlDocument();
            read.Load(filename);

            this.MaHD = read.SelectSingleNode("/hoadon/mahd").InnerText;
            this.TenKH = read.SelectSingleNode("/hoadon/tenkh").InnerText;

            XmlNodeList nodelist = read.SelectNodes("/hoadon/ctbhs/ctbh");

            foreach (XmlNode node in nodelist)
            {
                ChiTietBH ct = new ChiTietBH();

                ct.MaSP = node["masp"].InnerText;
                ct.TenSP = node["tensp"].InnerText;
                ct.GiaBan = float.Parse(node["gia"].InnerText);
                ct.SoLuong = int.Parse(node["soluong"].InnerText);

                dsCTBH.Add(ct);
            }

            Console.WriteLine("Doc file XML thanh cong");
        }

        public void Nhap()
        {
            Console.Write("Nhap ma hoa don: ");
            maHD = Console.ReadLine();
            Console.Write("Nhap ten khach hang: ");
            tenKH = Console.ReadLine();
            Console.Write("Nhap so luong chi tiet hoa don: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap chi tiet hoa don thu {0}:", i + 1);
                ChiTietBH ct = new ChiTietBH();
                Console.Write("Nhap ma san pham: ");
                ct.MaSP = Console.ReadLine();
                Console.Write("Nhap ten san pham: ");
                ct.TenSP = Console.ReadLine();
                Console.Write("Nhap gia ban: ");
                ct.GiaBan = float.Parse(Console.ReadLine());
                Console.Write("Nhap so luong: ");
                ct.SoLuong = int.Parse(Console.ReadLine());
                dsCTBH.Add(ct);
            }
        }
        public void Menu()
        {
            string filename = "../../hoadon.xml";
            Console.OutputEncoding = Encoding.UTF8;
            int choice;
            do
            {
                Console.WriteLine("1. Nhap hoa don");
                Console.WriteLine("2. Xuat hoa don");
                Console.WriteLine("3. Doc file XML");
                Console.WriteLine("4. Thoat");
                Console.Write("Nhap lua chon: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Nhap();
                        break;
                    case 2:
                        Xuat();
                        break;
                    case 3:
                        DocFileXML(filename);
                        break;
                    case 4:
                        Console.WriteLine("Thoat chuong trinh");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;
                }
            } while (choice != 4);
        }

        public void Progess()
        {
            Menu();
        }
    }
}
