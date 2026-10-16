using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TL_BT05
{
    public class NhanVien
    {
        string maNV;
        string tenNV;
        string phongBan;
        string chucVu;
        double hsLuong;
        int thamNien;
        int soNgayLam;
        public static double LuongCB = 23400000;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }

        public string PhongBan
        {
            get { return phongBan; }
            set { phongBan = value; }
        }

        public string ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }

        public double HsLuong
        {
            get { return hsLuong; }
            set { hsLuong = value; }
        }

        public int ThamNien
        {
            get { return thamNien; }
            set { thamNien = value; }
        }

        public int SoNgayLam
        {
            get { return soNgayLam; }
            set { soNgayLam = value; }
        }

        public NhanVien()
        {
            maNV = "";
            tenNV = "";
            phongBan = "";
            chucVu = "";
            hsLuong = 0;
            thamNien = 0;
            soNgayLam = 0;
        }

        public NhanVien(string maNV, string tenNV, string phongBan, string chucVu, double hsLuong, int thamNien, int soNgayLam)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.PhongBan = phongBan;
            this.ChucVu = chucVu;
            this.HsLuong = hsLuong;
            this.ThamNien = thamNien;
            this.SoNgayLam = soNgayLam;
        }

        public double TinhLuong()
        {
            return HsLuong * LuongCB + HsThiDua() + 1100000 + PhuCap();
        }

        public double HsThiDua()
        {
            if (ChucVu == "Lanh Dao")
                return 1.0;
            else if(ChucVu == "Nhan Vien")
            {
                if (SoNgayLam >= 22)
                    return 1.0;
                else if (SoNgayLam >= 20)
                    return 0.8;
                else
                    return 0.6;
            }
            else
                return 0;
        }

        public double PhuCap()
        {
            if(ChucVu == "Lanh Dao")
                return 1350000;
            else
                return 0;
        }

        public void XuatNV()
        {
            Console.WriteLine(
                $" {maNV,-10} {tenNV,-20}" +
                $" {phongBan,-15} {chucVu,-15} " +
                $" {hsLuong,10:N2} {thamNien,10} " +
                $" {soNgayLam,10} {TinhLuong(),15:N2}"
            );            
        }
    }
    class DSNV
    {
        List<NhanVien> dsNV;

        public List<NhanVien> DsNV
        {
            get { return dsNV; }
            set { dsNV = value; }
        }

        public DSNV()
        {
            dsNV = new List<NhanVien>();
        }

        public void DocFileXML(string filename)
        {
            XmlDocument read = new XmlDocument();
            read.Load(filename);
            XmlNodeList nodeList = read.SelectNodes("nhanviens/nhanvien");
            foreach(XmlNode node in nodeList)
            {
                NhanVien a = new NhanVien();
                a.MaNV = node["maNV"].InnerText;
                a.TenNV = node["tenNV"].InnerText;
                a.PhongBan = node["phongBan"].InnerText;
                a.ChucVu = node["chucVu"].InnerText;
                a.HsLuong = double.Parse(node["hsLuong"].InnerText);
                a.ThamNien = int.Parse(node["thamNien"].InnerText);
                a.SoNgayLam = int.Parse(node["soNgayLam"].InnerText);
                dsNV.Add(a);
            }
        }

        public void XuatDSNV()
        {
            Console.WriteLine(
                $" {"Ma NV",-10} {"Ten NV",-20}" +
                $" {"Phong Ban",-15} {"Chuc Vu",-15} " +
                $" {"HS Luong",10} {"Tham Nien",10} " +
                $" {"So Ngay Lam",10} {"Luong",15}"
            );
            foreach(NhanVien a in dsNV)
            {
                a.XuatNV();
            }
        }



    }
}