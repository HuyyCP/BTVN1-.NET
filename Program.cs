using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102210105
{
    public class Program
    {
        static void Main(string[] args)
        {
            QL<Sach> qlsach = new QL<Sach>();
            Sach s = new Sach() { maSach = "103", tenSach = "Huy", namXB = 2022, soLuong = 10, tinhTrang = true };
            qlsach.Insert(new Sach() { maSach = "101", tenSach = "Huy", namXB = 2022, soLuong = 10, tinhTrang = true });
            qlsach.Insert(new Sach() { maSach = "102", tenSach = "NVA", namXB = 2022, soLuong = 10, tinhTrang = true });
            qlsach.Insert(s);
            for (int i = 0; i < qlsach.GetLength(); ++i)
            {
                Console.WriteLine(qlsach.At(i).maSach + ", " + qlsach.At(i).tenSach + ", " + qlsach.At(i).namXB + ", " + qlsach.At(i).soLuong + ", " + qlsach.At(i).tinhTrang);
            }
            Console.WriteLine(qlsach.IndexOf(s));
        }
    }
}
