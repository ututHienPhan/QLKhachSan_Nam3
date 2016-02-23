using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        // Private property
        int ma_hd;
        PhieuThue pt;
        string ngay_tt;
        float tong_tien;
        //

        // Get set method
        public int Ma_hd
        {
            get { return ma_hd; }
            set { ma_hd = value; }
        }

        public PhieuThue Pt
        {
            get { return pt; }
            set { pt = value; }
        }

        public string Ngay_tt
        {
            get { return ngay_tt; }
            set { ngay_tt = value; }
        }

        public float Tong_tien
        {
            get { return tong_tien; }
            set { tong_tien = value; }
        }
        //

        // Method
        public HoaDon()
        {
            ma_hd = -1;
        }
        //
    }
}
