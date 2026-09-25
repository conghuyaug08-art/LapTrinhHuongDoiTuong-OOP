using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL_BT06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NuocGiaiKhat a = new NuocGiaiKhat();
            a.NhapMH();
            a.XuatMH();
            Console.ReadLine();
        }
    }
}
