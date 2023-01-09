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
            QLSach qlsach = new QLSach();

            while(true)
            {
                int choice = 0;
                while (true)
                {
                    Console.WriteLine("QUAN LY SACH");
                    Console.WriteLine("1. Them sach");
                    Console.WriteLine("2. Xoa sach");
                    Console.WriteLine("3. Tim kiem sach");
                    Console.WriteLine("4. Cap nhat sach");
                    Console.WriteLine("5. Sap xep sach");
                    Console.WriteLine("6. Hien tat ca sach");
                    Console.WriteLine("7. Thoat");

                    Console.Write("Nhap lua chon: ");
                    choice = Int32.Parse(Console.ReadLine());
                    if (choice < 1 || choice > 7)
                    {
                        Console.WriteLine("Lua chon khong hop le");
                    } else
                    {
                        break;
                    }
                }
                if(choice == 1)
                {
                    qlsach.Add();
                } else if(choice == 2)
                {
                    qlsach.RemoveAt();
                    Console.ReadKey(true);
                } else if(choice == 3)
                {
                    qlsach.Search();
                    Console.ReadKey(true);
                }
                else if(choice == 4)
                {
                    qlsach.Update();
                    Console.ReadKey(true);
                }
                else if(choice == 5)
                {
                    qlsach.Sort();
                    Console.ReadKey(true);
                } else if(choice == 6)
                {
                    qlsach.Show();
                    Console.ReadKey(true);
                } else
                {
                    break;
                }
            }
        }
    }
}
