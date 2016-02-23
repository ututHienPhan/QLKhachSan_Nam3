using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiPhong
    {
        String tenLoai;

        public String TenLoai
        {
            get { return tenLoai; }
            set { tenLoai = value; }
        }

        int slTrong;

        public int SlTrong
        {
            get { return slTrong; }
            set { slTrong = value; }
        }

        float donGia;

        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        int toiDa;

        public int ToiDa
        {
            get { return toiDa; }
            set { toiDa = value; }
        }

        public LoaiPhong()
        {
            this.tenLoai = "";
            this.slTrong = 0;
            this.donGia = 0;
            this.toiDa = 0;
        }

        public LoaiPhong(String ten, int sl, float gia, int toida)
        {
            this.tenLoai = ten;
            this.slTrong = sl;
            this.donGia = gia;
            this.toiDa = toida;
        }
    }
}
