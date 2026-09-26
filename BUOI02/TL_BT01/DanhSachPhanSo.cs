using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT01
{
    internal class DanhSachPhanSo
    {
        List<PhanSo> lstPhanSo;
        public List<PhanSo> LstPhanSo
        {
            get { return lstPhanSo; }
            set { lstPhanSo = value; }
        }

        public DanhSachPhanSo()
        {
            lstPhanSo = new List<PhanSo>();
        }

        public DanhSachPhanSo(List<PhanSo> lstPhanSo)
        {
            LstPhanSo = lstPhanSo;
        }

        //Cac phuong thuc xu ly danh sach phan so
        //a. Nhap ds phan so tu ban phim
        public void NhapDanhSachPhanSo()
        {
            Console.WriteLine("Nhap so phan tu: ");
            int n = int.Parse(Console.ReadLine());
            for (int  i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap vao phan so thu:{0}", i + 1);
                PhanSo ps = new PhanSo();
                ps.NhapPhanSo();
                lstPhanSo.Add(ps);
            }
        }
        //b. Hien thi ds phan so ra man hinh
        public void HienThiDanhSachPhanSo()
        {
            foreach (var ps in lstPhanSo)
            {
                ps.HienThiPhanSo();
            }
        }
        //c. Toi gian tat ca cac phan so trong danh sach
        public void RutGonDS()
        {
            foreach(PhanSo x in LstPhanSo)
            {
                x.RutGon();
            }
        }

        //d. Tim phan so p co trong danh sach hay khong
        public bool SearchPS(PhanSo p)
        {
            PhanSo k = LstPhanSo.Find(t => t.GiaTriThuc == p.GiaTriThuc);
            if (k == null)
            {
                return false;
            }
            return true;
        }

        //e. SX cac phan so trong danh sach theo thu tu tang dan
        public DanhSachPhanSo SortGiaTri()
        {
            DanhSachPhanSo ds = new DanhSachPhanSo();
            ds.LstPhanSo = LstPhanSo.OrderBy(t => t.GiaTriThuc).ToList();
            return ds;
        }

        //f. Tim danh sach con thoa: gia tri thuc > 1
        public DanhSachPhanSo LocDuLieu()
        {
            DanhSachPhanSo ds = new DanhSachPhanSo();
            ds.LstPhanSo = LstPhanSo.Where(t => t.GiaTriThuc > 1).ToList();
            return ds;
        }

        //g. Tim phan so co gia tri thuc lon nhat
        public PhanSo MaxPhanSo()
        {
            double max = LstPhanSo.Max(t => t.GiaTriThuc);
            return LstPhanSo.FirstOrDefault(t => t.GiaTriThuc == max);
        }

        //h. Tim ba phan so co gia tri thuc lon nhat
        public DanhSachPhanSo Top3PS()
        {
            DanhSachPhanSo ds = new DanhSachPhanSo();
            ds.LstPhanSo = LstPhanSo.OrderByDescending(t => t.GiaTriThuc).Take(3).ToList();
            return ds;
        }
    }
}
