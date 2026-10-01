using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TL_BT03
{
    internal class ThiSinh
    {
        string sbd;
        string tenTS;
        DateTime namSinh;
        float diemLT, diemTH1, diemTH2;
        public static float DiemChuan = 5.0f;

        public float DiemTrungBinh
        {
            get { return (diemLT + diemTH1 + diemTH2) / 3; }
        }

        public string Sbd
        {
            get { return sbd; }
            set { sbd = value; }
        }

        public string TenTS
        {
            get { return tenTS; }
            set { tenTS = value; }
        }

        public float DiemLT
        {
            get { return diemLT; }
            set { diemLT = value; }
        }

        public float DiemTH1
        {
            get { return diemTH1; }
            set { diemTH1 = value; }
        }

        public float DiemTH2
        {
            get { return diemTH2; }
            set { diemTH2 = value; }
        }

        public DateTime NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }

        public ThiSinh(string sbd, string tenTS, DateTime namSinh, float diemLT, float diemTH1, float diemTH2)
        {
            this.sbd = sbd;
            this.tenTS = tenTS;
            this.namSinh = namSinh;
            this.diemLT = diemLT;
            this.diemTH1 = diemTH1;
            this.diemTH2 = diemTH2;
        }

        public ThiSinh()
        {
            this.sbd = "";
            this.tenTS = "";
            this.namSinh = DateTime.Now;
            this.diemLT = 0;
            this.diemTH1 = 0;
            this.diemTH2 = 0;
        }

        public ThiSinh(ThiSinh ts)
        {
            this.sbd = ts.sbd;
            this.tenTS = ts.tenTS;
            this.namSinh = ts.namSinh;
            this.diemLT = ts.diemLT;
            this.diemTH1 = ts.diemTH1;
            this.diemTH2 = ts.diemTH2;
        }

        public string KetQua()
        {
            if(DiemTrungBinh >= DiemChuan && diemLT != 0 && diemTH1 != 0 && diemTH2 != 0 && diemLT >= 5 )
            {
                return "Đậu";
            }
            else
            {
                return "Rớt";
            }
        }

        public void Xuat()
        {
            Console.WriteLine($"{sbd,-10}{tenTS,-20}{namSinh:dd/MM/yyyy,-15}" +
                $"{diemLT,-10:F1}{diemTH1,-10:F1}{diemTH2,-10:F1}" +
                $"{DiemTrungBinh,-10:F1}{KetQua()}");
        }

        public void Nhap()
        {
            Console.Write("Nhap so bao danh: ");
            sbd = Console.ReadLine();
            Console.Write("Nhap ten thi sinh: ");
            tenTS = Console.ReadLine();
            Console.Write("Nhap nam sinh (dd/MM/yyyy): ");
            namSinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Nhap diem ly thuyet: ");
            diemLT = float.Parse(Console.ReadLine());
            Console.Write("Nhap diem thuc hanh 1: ");
            diemTH1 = float.Parse(Console.ReadLine());
            Console.Write("Nhap diem thuc hanh 2: ");
            diemTH2 = float.Parse(Console.ReadLine());
        }
    }

    class TrungTamCNTT
    {
        List<ThiSinh> dsThiSinh;

        internal List<ThiSinh> DsThiSinh { get => dsThiSinh; set => dsThiSinh = value; }

        public TrungTamCNTT()
        {
            dsThiSinh = new List<ThiSinh>();
        }

        public void NhapTS()
        {
            Console.WriteLine("Nhap so luong thi sinh: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin thi sinh thu {i + 1}");
                ThiSinh ts = new ThiSinh();
                ts.Nhap();
                dsThiSinh.Add(ts);
            }
        }

        public void DocFileXML(string filename)
        {
            XmlDocument read = new XmlDocument();
            read.Load(filename);
            XmlNodeList nodelist = read.SelectNodes("/TrungTam/ThiSinh");
            foreach (XmlNode node in nodelist)
            {
                ThiSinh ts = new ThiSinh();
                ts.Sbd = node.Attributes["Sbd"].Value;
                ts.TenTS = node["TenTS"].InnerText;
                ts.NamSinh = DateTime.Parse(node["NamSinh"].InnerText);
                ts.DiemLT = float.Parse(node["DiemLT"].InnerText);
                ts.DiemTH1 = float.Parse(node["DiemTH1"].InnerText);
                ts.DiemTH2 = float.Parse(node["DiemTH2"].InnerText);
                dsThiSinh.Add(ts);
            }
            Console.WriteLine("Doc file XML thanh cong");
        }

        public void XuatDS()
        {
            Console.WriteLine(
                $"{"SBD",-10}{"Ten TS",-20}{"Nam Sinh",-15}" +
                $"{"Diem LT",-10}{"Diem TH1",-10}{"Diem TH2",-10}" +
                $"{"Diem TB",-10}{"Ket Qua"}"
            ); foreach (ThiSinh ts in dsThiSinh)
            {
                ts.Xuat();
            }
        }

        public TrungTamCNTT SapXepTheoDiemTB()
        {
            TrungTamCNTT tt = new TrungTamCNTT();
            tt.DsThiSinh = dsThiSinh.OrderByDescending(ts => ts.DiemTrungBinh).ToList();
            return tt;
        }

        public TrungTamCNTT SapXepTheoTen()
        {
            TrungTamCNTT tt = new TrungTamCNTT();
            tt.DsThiSinh = dsThiSinh.OrderBy(t => t.TenTS).ThenBy(t => t.KetQua()).ToList();
            return tt;
        }

        public TrungTamCNTT TimThiSinhDau()
        {
            TrungTamCNTT tt = new TrungTamCNTT();
            tt.DsThiSinh = dsThiSinh.Where(t => t.KetQua() == "Đậu").ToList();
            return tt;
        }

        public int DemThiSinhDau()
        {
            int dem = 0;

            foreach (ThiSinh ts in DsThiSinh)
            {
                if (ts.KetQua() == "Đậu")
                {
                    dem++;
                }
            }

            return dem;
        }

        public void Menu()
        {
            Console.WriteLine("1. Nhap danh sach thi sinh");
            Console.WriteLine("2. Doc danh sach thi sinh tu file XML");
            Console.WriteLine("3. Xuat danh sach thi sinh");
            Console.WriteLine("4. Sap xep danh sach thi sinh theo diem trung binh giam dan");
            Console.WriteLine("5. Sap xep danh sach thi sinh theo ten va ket qua");
            Console.WriteLine("6. Tim cac thi sinh dau");
            Console.WriteLine("7. Dem so luong thi sinh dau");
            Console.WriteLine("0. Thoat");
        }

        public void Progess()
        {
            string filename ="../../trungtam.xml";
            int chon;
            do
            {
                Menu();
                Console.WriteLine("Nhap lua chon: ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        NhapTS();
                        break;
                    case 2:
                        DocFileXML(filename);
                        break;
                    case 3:
                        XuatDS();
                        break;
                    case 4:
                        TrungTamCNTT tt1 = SapXepTheoDiemTB();
                        tt1.XuatDS();
                        break;
                    case 5:
                        TrungTamCNTT tt2 = SapXepTheoTen();
                        tt2.XuatDS();
                        break;
                    case 6:
                        TrungTamCNTT tt3 = TimThiSinhDau();
                        tt3.XuatDS();
                        break;
                    case 7:
                        int dem = DemThiSinhDau();
                        Console.WriteLine($"So luong thi sinh dau: {dem}");
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;
                }
            } while (chon != 0);
        }
    }
}
