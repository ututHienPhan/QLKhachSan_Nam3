using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang
    {
        int ma_kh;

        public int Ma_kh
        {
            get { return ma_kh; }
            set { ma_kh = value; }
        }

        string ho_ten;

        public string Ho_ten
        {
            get { return ho_ten; }
            set { ho_ten = value; }
        }

        string cmnd;

        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        string loai_kh;

        public string Loai_kh
        {
            get { return loai_kh; }
            set { loai_kh = value; }
        }
    }
}
