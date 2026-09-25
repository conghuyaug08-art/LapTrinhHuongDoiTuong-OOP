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
                    Console.WriteLine("Du lie loi");
                soSeri = "S000";
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
                    Console.WriteLine("Gia ban phai lon hon 4 trieu");
                    giaBan = 0;
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
                    Console.WriteLine("Loai san pham khong hop le");
                loaiSP = "Dien thoai di dong";
            }
        }

        public float ThanhTien()
        {

        }
    }
}
