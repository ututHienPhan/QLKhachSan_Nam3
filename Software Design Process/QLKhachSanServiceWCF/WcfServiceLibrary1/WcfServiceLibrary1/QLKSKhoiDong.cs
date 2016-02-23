using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WcfServiceLibrary1
{
    class QLKSKhoiDong : IQLKSKhoiDong
    {
        DataL luu_tru = new DataL();

        public int Khoi_dong_dang_nhap(string tk, string mk)
        {
            DataTable du_lieu_dn = new DataTable();

            du_lieu_dn = luu_tru.Khoi_dong_dang_nhap(tk, mk);

            if (du_lieu_dn.Rows.Count == 0)
                return 0;
            else
            {
                if (du_lieu_dn.Rows[0]["LOAI"].ToString().Trim() == "CKS")
                    return 2;
            }
            return 1;
        }

        public bool Themloaiphong(string loaiphong, float gia, int sotd)
        {
            return luu_tru.ThemLoaiPhong(loaiphong, gia, sotd);
        }


        public bool XoaLoaiPhong(string loaiphong)
        {
            return luu_tru.Xoa_Loai_Phong(loaiphong);
        }


        public string ThongTin_LoaiPhong(string loaiphong)
        {
            DataTable result = luu_tru.ThongTin_LoaiPhong(loaiphong);

            XmlElement kq = Tao_goc("LOAIPHONG");

            kq.SetAttribute("TENLOAIPHONG", result.Rows[0]["TENLOAIPHONG"].ToString());
            kq.SetAttribute("DONGIA", result.Rows[0]["DONGIA"].ToString());
            kq.SetAttribute("SLTRONG", result.Rows[0]["SLTRONG"].ToString());
            kq.SetAttribute("SONGUOITOIDA", result.Rows[0]["SONGUOITOIDA"].ToString());

            return kq.OuterXml;
        }


        public bool CapNhat_LoaiPhong(string old_loai_phong, string loai_phong, float don_gia, int so_nguoi_td, int sltrong)
        {
            return luu_tru.CapNhapLoaiPhong(old_loai_phong, loai_phong, don_gia, so_nguoi_td, sltrong);
        }

        public string Load_DanhMucPhong()
        {
            DataTable du_lieu = new DataTable();
            du_lieu = luu_tru.DanhMuc_Phong();

            XmlElement result = Tao_goc("LOAIPHONG");

            foreach (DataRow item in du_lieu.Rows)
            {
                XmlElement ten_loai_phong = Tao_nut("TENLOAI", result);
                XmlElement sltrong = Tao_nut("SLTRONG", ten_loai_phong);
                XmlElement dongia = Tao_nut("DONGIA", ten_loai_phong);
                XmlElement toida = Tao_nut("SONGUOITOIDA", ten_loai_phong);

                ten_loai_phong.SetAttribute("VALUE", item["TENLOAIPHONG"].ToString());
                sltrong.SetAttribute("VALUE", item["SLTRONG"].ToString());
                dongia.SetAttribute("VALUE", item["DONGIA"].ToString());
                toida.SetAttribute("VALUE", item["SONGUOITOIDA"].ToString());
            }

            return result.OuterXml;
        }

        public XmlElement Tao_goc(string ten)
        {
            XmlElement kq;
            XmlDocument tai_lieu = new XmlDocument();
            kq = tai_lieu.CreateElement(ten);
            tai_lieu.AppendChild(kq);
            return kq;
        }

        public XmlElement Tao_nut(string ten, XmlElement cha)
        {
            XmlElement con;
            XmlDocument tai_lieu = cha.OwnerDocument;
            con = tai_lieu.CreateElement(ten);
            cha.AppendChild(con);
            return con;
        }

        public bool ThemPhieuThue(string ten_kh, string cmnd, string sdt, string loaikh, string ma_phong,
            string tg_bd, string tg_kt = "")
        {
            return luu_tru.ThemPhieuThue(ma_phong, ten_kh, cmnd, sdt, loaikh, tg_bd, tg_kt);
        }

        public string LayThongTinPhieuThue(string ma_phong)
        {
            DataSet tt = luu_tru.LayThongTinPhieuThue(ma_phong);

            XmlElement kq = Tao_goc("GOC");

            XmlElement pt = Tao_nut("PT", kq);
            XmlElement kh = Tao_nut("KH", kq);

            pt.SetAttribute("MAPHIEUTHUE", tt.Tables[0].Rows[0]["MAPHIEUTHUE"].ToString());
            pt.SetAttribute("MA_KH", tt.Tables[0].Rows[0]["MA_KH"].ToString());
            pt.SetAttribute("NgayThue", tt.Tables[0].Rows[0]["NgayThue"].ToString());
            pt.SetAttribute("NgayTra", tt.Tables[0].Rows[0]["NgayTra"].ToString());


            kh.SetAttribute("HOTEN", tt.Tables[1].Rows[0]["HOTEN"].ToString());
            kh.SetAttribute("CMND", tt.Tables[1].Rows[0]["CMND"].ToString());
            kh.SetAttribute("SDT", tt.Tables[1].Rows[0]["SDT"].ToString());
            kh.SetAttribute("LOAI_KH", tt.Tables[1].Rows[0]["LOAI_KH"].ToString());

            return kq.OuterXml;
        }

        public bool Them_phong(string tk, string ma_phong, string loai_phong)
        {
            return luu_tru.ThemPhong(tk, ma_phong, loai_phong);
        }

        public bool Xoa_phong(string tk, string ma_phong)
        {
            return luu_tru.XoaPhong(tk, ma_phong);
        }

        public bool Cap_nhap_phong(string old_ma_phong, string ma_phong, string loai_phong, string tinhtrang)
        {
            return luu_tru.CapNhapPhong(old_ma_phong, ma_phong, loai_phong, tinhtrang);
        }

        public string Load_DsPhong(string tk, string LoaiPhong = "")
        {
            DataTable result = new DataTable();
            if (LoaiPhong != "")
                result = luu_tru.Phong(tk, LoaiPhong);
            else
                result = luu_tru.Phong(tk);

            XmlElement kq = Tao_goc("LOAIPHONG");

            foreach (DataRow item in result.Rows)
            {
                XmlElement con = Tao_nut("PHONG", kq);

                con.SetAttribute("MAPHONG", item["TENPHONG"].ToString());
                con.SetAttribute("TENLOAIPHONG", item["TENLOAIPHONG"].ToString());
                con.SetAttribute("SONGUOITOIDA", item["SONGUOITOIDA"].ToString());
                con.SetAttribute("TINHTRANGPHONG", item["TINHTRANGPHONG"].ToString());
            }

            return kq.OuterXml;
        }

        public string LayThongTinDichVu(string loai_phong)
        {
            DataTable result = new DataTable();

            result = luu_tru.LayThongTinDichVu(loai_phong);

            XmlElement kq = Tao_goc("GOC");

            if (result.Rows.Count == 0)
                return kq.OuterXml;

            foreach (DataRow item in result.Rows)
            {
                XmlElement con = Tao_nut("SP_DV", kq);

                con.SetAttribute("MA_SPDV", item["MA_SPDV"].ToString());
                con.SetAttribute("TEN_SPDV", item["TEN_SPDV"].ToString());
                con.SetAttribute("DONGIA", item["DONGIA"].ToString());
            }

            return kq.OuterXml;
        }

        public string LayThongTinThongKe(List<string> tenloai, string tg_bd,
            string tg_kt, string tk, string all = "")
        {
            DataTable result = new DataTable();

            XmlElement kq = Tao_goc("THONGKE");

            if (all == "")
            {
                result = luu_tru.LayThongTinThongKe(tenloai, tg_bd, tg_kt, tk);


                kq.SetAttribute("LOAIPHONG", result.Rows[0]["LOAIPHONG"].ToString());
                kq.SetAttribute("GIATRI", result.Rows[0]["GIATRI"].ToString());
                kq.SetAttribute("TYLE", result.Rows[0]["TYLE"].ToString());
            }
            else
            {
                string LOAIPHONG = "Tổng thu";
                float TongThu = 0;

                result = luu_tru.LayThongTinThongKe(tenloai, tg_bd, tg_kt, tk, "all");

                for (int i = 0; i < result.Rows.Count; i++)
                    TongThu += float.Parse(result.Rows[i]["GIATRI"].ToString());


                kq.SetAttribute("LOAIPHONG", LOAIPHONG);
                kq.SetAttribute("GIATRI", TongThu.ToString());
                kq.SetAttribute("TYLE", "100");
            }

            return kq.OuterXml;
        }

        public bool ThemHoaDon(string maphieuthue, string maphong, string ngay_thanh_toan,
            float tongtien, string tk)
        {
            return luu_tru.ThemHoaDon(maphieuthue, maphong, ngay_thanh_toan, tongtien, tk);
        }

        public string LayDanhSachQuanLy()
        {
            DataTable result = new DataTable();

            XmlElement kq = Tao_goc("GOC");

            result=luu_tru.LayDanhSachQuanLy();

            foreach(DataRow item in result.Rows)
            {
                XmlElement con=Tao_nut("QUANLY",kq);

                con.SetAttribute("TAIKHOAN",item[0].ToString());
            }

            return kq.OuterXml;
        }
    }
}
