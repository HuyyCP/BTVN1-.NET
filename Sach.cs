using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102210105
{
    public class Sach
    {
        private string _maSach;
        public string maSach {
            get
            {
                return this._maSach;
            }
            set
            {
                if (value.Length != 5) throw new Exception();
                if ((value[0] < '1' && value[0] > '5')
                    || (value[1] < '0' && value[1] > '9')
                    || (value[2] < '0' && value[2] > '9')
                    || (value[3] < '0' && value[3] > '9')
                    || (value[4] < '0' && value[4] > '9')
                    ) throw new Exception();
                this._maSach = value; 
            }
        }
        public string tenSach { get; set; }
        public int _namXB;
        public int namXB { 
            get
            {
                return this._namXB;
            }
            set
            {
                if (value < 1000 || value > 9999) throw new Exception();
                this._namXB = value;
            }
        }
        public int soLuong { get; set; }
        public bool tinhTrang { get; set; }
        public override string ToString()
        {
            return "Ma sach: " + this.maSach + ", ten sach: " + this.tenSach + ", nam xb: " + this.namXB + ", so luong: " + this.soLuong + ", tinh trang: " + ((this.tinhTrang == true)? ("Con sach") : ("Het sach"));
        }
    }
}
