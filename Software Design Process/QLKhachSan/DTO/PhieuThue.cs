using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThue
    {
        // Private properties
        int ma_phieu_thue;
        int ma_kh;
        string ma_phong;
        string loai_phong;
        double gia_phong;
        string ngay_thue;
        string ngay_tra;
        int xac_nhan;
        //

        // Get, set method
        public int Ma_phieu_thue
        {
            get { return ma_phieu_thue; }
            set { ma_phieu_thue = value; }
        }

        public int Ma_kh
        {
            get { return ma_kh; }
            set { ma_kh = value; }
        }
        public string Ma_phong
        {
            get { return ma_phong; }
            set { ma_phong = value; }
        }
        public string Loai_phong
        {
            get { return loai_phong; }
            set { loai_phong = value; }
        }
        public double Gia_phong
        {
            get { return gia_phong; }
            set { gia_phong = value; }
        }
        public string Ngay_thue
        {
            get { return ngay_thue; }
            set { ngay_thue = value; }
        }
        public string Ngay_tra
        {
            get { return ngay_tra; }
            set { ngay_tra = value; }
        }
        public int Xac_nhan
        {
            get { return xac_nhan; }
            set { xac_nhan = value; }
        }
        //
    }
}
