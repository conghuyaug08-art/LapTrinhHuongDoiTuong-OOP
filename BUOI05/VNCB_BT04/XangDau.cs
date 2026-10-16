
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bai4
{
    class MatHang
    {
        string maHang;
        string tenHang;
        double donGia;

        public string MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public double DonGia { get => donGia; set => donGia = value; }

        public MatHang(string maHang, string tenHang, double donGia)
        {
            MaHang = maHang;
            TenHang = tenHang;
            DonGia = donGia;
        }
    }

    abstract class HoaDon
    {
        string maSo;
        string hoTen;
        DateTime ngayLap;
        MatHang matHang;
        int soLuong;

        public string MaSo { get => maSo; set => maSo = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }
        public MatHang MatHang { get => matHang; set => matHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public HoaDon(string maSo, string hoTen, DateTime ngayLap,
            MatHang matHang, int soLuong)
        {
            MaSo = maSo;
            HoTen = hoTen;
            NgayLap = ngayLap;
            MatHang = matHang;
            SoLuong = soLuong;
        }

        public double ThanhTien()
        {
            return SoLuong * MatHang.DonGia;
        }

        public abstract double TienKhuyenMai();

        public double TriGia()
        {
            return ThanhTien() - TienKhuyenMai();
        }

        public virtual void Xuat()
        {
            Console.WriteLine(
                $"{MaSo,-10}{HoTen,-20}{NgayLap:dd/MM/yyyy,-13}" +
                $"{MatHang.TenHang,-15}{SoLuong,-10}" +
                $"{MatHang.DonGia,-15:N0}{ThanhTien(),-15:N0}" +
                $"{TienKhuyenMai(),-15:N0}{TriGia(),-15:N0}");
        }
    }

    class HoaDonVIP : HoaDon
    {
        public HoaDonVIP(string maSo, string hoTen, DateTime ngayLap,
            MatHang matHang, int soLuong)
            : base(maSo, hoTen, ngayLap, matHang, soLuong)
        {
        }

        public override double TienKhuyenMai()
        {
            if (SoLuong > 50)
                return 0.05 * ThanhTien();
            else if (SoLuong <= 50 && ThanhTien() >= 600000)
                return 0.04 * ThanhTien();
            else if (SoLuong >= 10)
                return 0.01 * ThanhTien();

            return 0;
        }
    }

    class HoaDonThanThiet : HoaDon
    {
        public HoaDonThanThiet(string maSo, string hoTen,
            DateTime ngayLap, MatHang matHang, int soLuong)
            : base(maSo, hoTen, ngayLap, matHang, soLuong)
        {
        }

        public override double TienKhuyenMai()
        {
            if (SoLuong > 60)
                return 0.04 * ThanhTien();
            else if (SoLuong <= 50 && ThanhTien() >= 800000)
                return 0.03 * ThanhTien();

            return 0;
        }
    }

    class HoaDonVangLai : HoaDon
    {
        public HoaDonVangLai(string maSo, DateTime ngayLap,
            MatHang matHang, int soLuong)
            : base(maSo, "", ngayLap, matHang, soLuong)
        {
        }

        public override double TienKhuyenMai()
        {
            if (ThanhTien() > 1000000)
                return 0.03 * ThanhTien();

            return 0;
        }
    }

    class DanhSachHoaDon
    {
        List<HoaDon> hoaDons = new List<HoaDon>();

        public void DocFile(string tenFile)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(tenFile);

            XmlNodeList danhSach = doc.SelectNodes("/cuahang/hoadon");

            foreach (XmlNode node in danhSach)
            {
                string loai = node.Attributes["loai"].Value;
                string maSo = node["maso"].InnerText;
                string hoTen = node["hoten"]?.InnerText ?? "";
                DateTime ngayLap = DateTime.Parse(node["ngaylap"].InnerText);
                string maHang = node["mahang"].InnerText;
                string tenHang = node["tenhang"].InnerText;
                double donGia = double.Parse(node["dongia"].InnerText);
                int soLuong = int.Parse(node["soluong"].InnerText);

                MatHang mh = new MatHang(maHang, tenHang, donGia);

                if (loai == "VIP")
                {
                    hoaDons.Add(new HoaDonVIP(
                        maSo, hoTen, ngayLap, mh, soLuong));
                }
                else if (loai == "ThanThiet")
                {
                    hoaDons.Add(new HoaDonThanThiet(
                        maSo, hoTen, ngayLap, mh, soLuong));
                }
                else if (loai == "VangLai")
                {
                    hoaDons.Add(new HoaDonVangLai(
                        maSo, ngayLap, mh, soLuong));
                }
            }
        }

        public void XuatDanhSach()
        {
            Console.WriteLine(
                $"{"Ma so",-10}{"Ho ten",-20}{"Ngay lap",-13}" +
                $"{"Mat hang",-15}{"So luong",-10}{"Don gia",-15}" +
                $"{"Thanh tien",-15}{"Khuyen mai",-15}{"Tri gia",-15}");

            foreach (HoaDon hd in hoaDons)
                hd.Xuat();
        }

        public void XuatHoaDonVangLai()
        {
            foreach (HoaDon hd in hoaDons)
            {
                if (hd is HoaDonVangLai)
                    hd.Xuat();
            }
        }

        public double TongTriGia()
        {
            return hoaDons.Sum(hd => hd.TriGia());
        }

        public void XuatHoaDonTriGiaCaoNhat()
        {
            if (hoaDons.Count == 0)
                return;

            double max = hoaDons.Max(hd => hd.TriGia());

            foreach (HoaDon hd in hoaDons.Where(
                hd => hd.TriGia() == max))
            {
                hd.Xuat();
            }
        }

        public void DemHoaDon()
        {
            int vip = hoaDons.Count(hd => hd is HoaDonVIP);
            int thanThiet = hoaDons.Count(
                hd => hd is HoaDonThanThiet);

            Console.WriteLine("So hoa don VIP: " + vip);
            Console.WriteLine("So hoa don than thiet: " + thanThiet);
        }

        public void SapXep()
        {
            hoaDons = hoaDons
                .OrderBy(hd => hd.TriGia())
                .ThenByDescending(hd => hd.MaSo)
                .ToList();

            XuatDanhSach();
        }
    }
}
