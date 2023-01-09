using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _102210105
{
    public class QLSach
    {
        private QL<Sach> danhsach;
        public QLSach()
        {
            this.danhsach = new QL<Sach>();
        }
        public int GetLength()
        {
            return this.danhsach.GetLength();
        }
        public Sach At(int index)
        {
            return this.danhsach.At(index);
        }
        private bool CheckExist(string ma, out Sach s)
        {
            for(int i = 0; i < this.GetLength(); i++)
            {
                if(this.At(i).maSach == ma)
                {
                    s = this.At(i);
                    return true;
                }
            }
            s = null;
            return false;
        }
        public void Add()
        {
            Sach s = new Sach();
            try
            {
                Console.Write("Nhap ma sach: ");
                s.maSach = Console.ReadLine();

                Console.Write("Nhap ten sach: ");
                s.tenSach = Console.ReadLine();

                Console.Write("Nhap nam xuat ban: ");
                s.namXB = Int32.Parse(Console.ReadLine());
                
                Console.Write("Nhap so luong: ");
                s.soLuong = Int32.Parse(Console.ReadLine());
                
                Console.Write("Nhap tinh trang sach: ");
                s.tinhTrang = bool.Parse(Console.ReadLine());
            } 
            catch (Exception)
            {
                Console.WriteLine("Thong tin khong hop le");
                return;
            }


            int pos = -1;
            for (int i = 0; i < this.GetLength(); ++i)
            {
                if (this.danhsach.At(i).Equals(s))
                {
                    pos = i;
                    break;
                }
            }
            if (pos == -1) {
                int index = this.GetLength();
                try
                {
                    Console.Write("Nhap vi tri can them: ");
                    index = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Vi tri khong hop le");
                    return;
                }
                this.danhsach.Add(ref s, index);
            }
            else this.danhsach.At(pos).soLuong += s.soLuong;
        }
        public void RemoveAt()
        {
            int index = 0;
            try
            {
                Console.Write("Nhap vi tri can xoa: ");
                index = Int32.Parse(Console.ReadLine());
                if (index < 0 || index >= this.GetLength()) throw new Exception(); 
            } 
            catch (Exception)
            {
                Console.WriteLine("Vi tri khong hop le");
                return;
            }
            int sl = 0;
            try
            {
                Console.WriteLine("Nhap so luong can xoa: ");
                sl = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("So luong khong hop le");
                return;
            }
            if(this.At(index).soLuong < sl)
            {
                this.danhsach.RemoveAt(index);
            } else
            {
                this.danhsach.At(index).soLuong -= sl;
            }
            
        }
        public void RemoveAll()
        {
            this.danhsach.RemoveAll();
        }
        
        public void Show()
        {
            for (int i = 0; i < this.danhsach.GetLength(); ++i)
            {
                Console.WriteLine(this.danhsach.At(i).ToString());
            }
        }
        public void Update()
        {
            string masach = "";
            try
            {
                Console.Write("Nhap ma sach can cap nhat: ");
                masach = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Thong tin khong hop le");
                return;
            }
            Sach s = new Sach();
            if(CheckExist(masach, out s))
            {
                while(true)
                {
                    int choice = 0;
                    try
                    {
                        while (true)
                        {
                            Console.WriteLine("Cap Nhat");
                            Console.WriteLine("1. Cap nhat ten sach");
                            Console.WriteLine("2. Cap nhat nam xuat ban");
                            Console.WriteLine("3. Cap nhat so luong sach");
                            Console.WriteLine("4. Quay ve");

                            Console.Write("Nhap lua chon: ");
                            choice = Int32.Parse(Console.ReadLine());
                            if (choice < 1 || choice > 4)
                            {
                                Console.WriteLine("Lua chon khong hop le");
                            } else
                            {
                                break;
                            }
                        }
                        if (choice == 1) // ten sach
                        {
                            Console.Write("Nhap ten sach: ");
                            s.tenSach = Console.ReadLine();
                            Console.WriteLine("Cap nhat thanh cong");
                        }
                        else if (choice == 2) // nam xuat ban
                        {
                            Console.Write("Nhap nam xuat ban: ");
                            s.namXB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Cap nhat thanh cong");
                        }
                        else if (choice == 3) {
                            Console.Write("Nhap so luong sach: ");
                            s.soLuong = Int32.Parse (Console.ReadLine());
                            Console.WriteLine("Cap nhat thanh cong");
                        } else
                        {
                            break;
                        }
                    }
                    catch ( Exception)
                    {
                        Console.WriteLine("Thong tin khong hop le");
                    }
                }
            } else
            {
                Console.WriteLine("Sach khong ton tai");
            }
        }
        public void Search()
        {
            string masach = "";
            try
            {
                Console.Write("Nhap ma sach can tim: ");
                masach = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Thong tin khong hop le");
                return;
            }
            int left = 0;
            int right = this.GetLength() - 1;
            if(left == right)
            {
                if (this.At(left).maSach == masach)
                {
                    Console.WriteLine(this.At(left).ToString());
                } else
                {
                    Console.WriteLine("Sach khong ton tai");
                }   
            }
            bool checkExist = false;
            while (left <= right && Int32.Parse(this.At(left).maSach) <= Int32.Parse(masach) && Int32.Parse(masach) <= Int32.Parse(this.At(right).maSach))
            {
                int val1 = (Int32.Parse(masach) - Int32.Parse(this.At(left).maSach)) / (Int32.Parse(this.At(right).maSach) - Int32.Parse(this.At(left).maSach));
                int val2 = right - left;
                int pos = left + val1 * val2;
                if(Int32.Parse(this.At(pos).maSach) == Int32.Parse(masach))
                {
                    Console.WriteLine(this.At(pos).ToString());
                    checkExist = true;
                    break;
                }
                if(Int32.Parse(this.At(pos).maSach) < Int32.Parse(masach)) {
                    left = pos + 1;
                } else
                {
                    right = pos - 1;
                }
            }
            if(!checkExist)
            {
                Console.WriteLine("Sach khong ton tai");
            }
        }
        public void Sort()
        {
            for(int gap = this.GetLength()/2; gap > 0; gap /= 2)
            {
                for(int i = gap; i < this.GetLength(); i++)
                {
                    Sach tmp = new Sach() { maSach = this.At(i).maSach, tenSach = this.At(i).tenSach, namXB = this.At(i).namXB, soLuong = this.At(i).soLuong, tinhTrang = this.At(i).tinhTrang };
                    int j;
                    for(j = i; j >= gap && Int32.Parse(this.At(j - gap).maSach) > Int32.Parse(tmp.maSach); j -= gap)
                    {
                        this.danhsach.list[j] = new Sach() { maSach = this.danhsach.list[j - gap].maSach, tenSach = this.danhsach.list[j - gap].tenSach, namXB = this.danhsach.list[j - gap].namXB, soLuong = this.danhsach.list[j - gap].soLuong, tinhTrang = this.danhsach.list[j - gap].tinhTrang };
                    }
                    this.danhsach.list[j] = new Sach() { maSach = tmp.maSach, tenSach = tmp.tenSach, namXB = tmp.namXB, soLuong = tmp.soLuong, tinhTrang = tmp.tinhTrang };
                }
            }
        }

    }
}
