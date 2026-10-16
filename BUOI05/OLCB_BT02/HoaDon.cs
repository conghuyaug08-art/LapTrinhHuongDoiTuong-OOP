using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace B6
{
    public abstract class hoadon
    {
        string makh;
        string tenkh;
        int soluong;
        double giaban;

        public static double VAT = 0.1;

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public double Giaban { get => giaban; set => giaban = value; }

        public hoadon(string makh, string tenkh, int soluong, double giaban)
        {
            Makh = makh;
            Tenkh = tenkh;
            Soluong = soluong;
            Giaban = giaban;
        }

        public double thanhtien()
        {
            return Soluong * Giaban - chietkhau() + thueVAT();
        }

        public double thueVAT()
        {
            return VAT * Soluong * Giaban;
        }

        public abstract double chietkhau();

        public virtual void xuat()
        {
            Console.WriteLine(
                $"{Makh,-12}{Tenkh,-25}{Soluong,-10}" +
                $"{Giaban,-12:F1}{chietkhau(),-15:F1}" +
                $"{thanhtien(),-15:F1}");
        }
    }

    class KHcanhan : hoadon
    {
        double khoangcach;

        public double Khoangcach
        {
            get => khoangcach;
            set => khoangcach = value;
        }

        public KHcanhan(string makh, string tenkh, int soluong,
            double giaban, double khoangcach)
            : base(makh, tenkh, soluong, giaban)
        {
            this.khoangcach = khoangcach;
        }

        public override double chietkhau()
        {
            double ck;

            if (Soluong < 5)
                ck = 0;
            else
                ck = 0.03 * Soluong * Giaban;

            if (Khoangcach < 10)
                ck += 20000 * Soluong;

            return ck;
        }

        public override void xuat()
        {
            base.xuat();
            Console.WriteLine($"Khoang cach: {Khoangcach} km");
        }
    }

    class KHDLC1 : hoadon
    {
        int thoigianhoptac;

        public int Thoigianhoptac
        {
            get => thoigianhoptac;
            set => thoigianhoptac = value;
        }

        public KHDLC1(string makh, string tenkh, int soluong,
            double giaban, int thoigianhoptac)
            : base(makh, tenkh, soluong, giaban)
        {
            this.thoigianhoptac = thoigianhoptac;
        }

        public override double chietkhau()
        {
            double ck = 0.03 * Soluong * Giaban;

            if (thoigianhoptac > 3)
                ck += 0.01 * (thoigianhoptac - 3) * Soluong * Giaban;

            if (ck > 0.1 * Soluong * Giaban)
                ck = 0.1 * Soluong * Giaban;

            return ck;
        }

        public override void xuat()
        {
            base.xuat();
            Console.WriteLine($"Thoi gian hop tac: {thoigianhoptac} nam");
        }
    }

    class KHcty : hoadon
    {
        int soluongnv;

        public int Soluongnv
        {
            get => soluongnv;
            set => soluongnv = value;
        }

        public KHcty(string makh, string tenkh, int soluong,
            double giaban, int soluongnv)
            : base(makh, tenkh, soluong, giaban)
        {
            this.soluongnv = soluongnv;
        }

        public override double chietkhau()
        {
            double ck = 0;

            if (Soluongnv > 5000)
                ck = 0.05 * Soluong * Giaban;
            else if (Soluongnv > 1000)
                ck = 0.03 * Soluong * Giaban;

            return ck;
        }

        public override void xuat()
        {
            base.xuat();
            Console.WriteLine($"So luong nhan vien: {soluongnv}");
        }
    }

    class danhsachhoadon
    {
        string tencongty = "";
        string dienthoai = "";
        string diachi = "";

        List<hoadon> hoadons = new List<hoadon>();

        // Cau 1: Doc du lieu tu XML
        public void docfile(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            tencongty = doc.SelectSingleNode("/congty/tencty").InnerText;
            dienthoai = doc.SelectSingleNode("/congty/dienthoai").InnerText;
            diachi = doc.SelectSingleNode("/congty/diachi").InnerText;

            XmlNodeList list = doc.GetElementsByTagName("hoadon");

            hoadons.Clear();

            foreach (XmlNode node in list)
            {
                string loai = node.Attributes["loai"].Value;
                string makh = node["makh"].InnerText;
                string tenkh = node["tenkh"].InnerText;
                int soluong = int.Parse(node["soluong"].InnerText);
                double giaban = double.Parse(node["giaban"].InnerText);

                if (loai == "1")
                {
                    double khoangcach =
                        double.Parse(node["khoangcach"].InnerText);

                    hoadons.Add(new KHcanhan(
                        makh, tenkh, soluong, giaban, khoangcach));
                }
                else if (loai == "2")
                {
                    int thoigian = int.Parse(
                        node["thoigianhoptac"].InnerText);

                    hoadons.Add(new KHDLC1(
                        makh, tenkh, soluong, giaban, thoigian));
                }
                else if (loai == "3")
                {
                    int soluongnv = int.Parse(
                        node["soluongnv"].InnerText);

                    hoadons.Add(new KHcty(
                        makh, tenkh, soluong, giaban, soluongnv));
                }
            }
        }

        // Cau 2: Xuat danh sach hoa don
        public void xuatdanhsach()
        {
            Console.WriteLine($"Cong ty: {tencongty}");
            Console.WriteLine($"Dien thoai: {dienthoai}");
            Console.WriteLine($"Dia chi: {diachi}");

            Console.WriteLine(
                $"{"Ma KH",-12}{"Ten KH",-25}{"So luong",-10}" +
                $"{"Gia ban",-12}{"Chiet khau",-15}{"Thanh tien",-15}");

            foreach (var hd in hoadons)
                hd.xuat();
        }

        // Cau 4: Tinh tong tien
        public double tongtien()
        {
            return hoadons.Sum(x => x.thanhtien());
        }

        // Cau 5: Khach hang mua nhieu nhat
        public void xuatkhachhangmuanhieunhat()
        {
            if (hoadons.Count == 0)
            {
                Console.WriteLine("Danh sach hoa don rong.");
                return;
            }

            int soluongmax = hoadons.Max(x => x.Soluong);

            List<hoadon> danhsachmax = hoadons
                .Where(x => x.Soluong == soluongmax)
                .ToList();

            foreach (var hd in danhsachmax)
                hd.xuat();
        }

        // Cau 6: Tong chiet khau khach hang cong ty
        public double tongtienchietkhaukhachhangcongty()
        {
            return hoadons.OfType<KHcty>()
                .Sum(x => x.chietkhau());
        }

        // Cau 7: In danh sach dai ly cap 1
        public void indailycap1()
        {
            Console.WriteLine("Danh sach khach hang la dai ly cap 1:");

            foreach (var hd in hoadons)
                if (hd is KHDLC1)
                    hd.xuat();
        }

        // Cau 8: Sap xep theo so luong tang dan,
        // neu bang nhau thi thanh tien giam dan
        public void sort()
        {
            hoadons = hoadons
                .OrderBy(x => x.Soluong)
                .ThenByDescending(x => x.thanhtien())
                .ToList();

            xuatdanhsach();
        }

        // Cau 9: Tim hoa don theo ma khach hang
        public void xuathoadontheomakh(string makh)
        {
            List<hoadon> loc = hoadons
                .Where(x => x.Makh == makh)
                .ToList();

            if (loc.Count < 1)
                Console.WriteLine("Khong co khach hang nay");
            else
            {
                Console.WriteLine("Danh sach hoa don cua khach hang:");

                foreach (var hd in loc)
                    hd.xuat();
            }
        }
    }
}
