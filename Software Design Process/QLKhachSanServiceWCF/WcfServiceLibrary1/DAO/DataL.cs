using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DataL : AccessDatabase
    {
        public DataL()
        {

        }

        public DataTable Khoi_dong_dang_nhap(string tk, string mk)
        {
            List<string> SelectItem = new List<string>();

            SelectItem.Add("TAIKHOAN");
            SelectItem.Add("MATKHAU");
            SelectItem.Add("LOAI");

            List<DieuKienParameter> WhereItem = new List<DieuKienParameter>();

            WhereItem.Add(new DieuKienParameter("TaiKhoan", tk, ParameterType.String));
            WhereItem.Add(new DieuKienParameter("MatKhau", mk, ParameterType.String));

            return Doc_bang_Adap("NGUOISUDUNG", SelectItem, WhereItem);
        }

        public DataTable DanhMuc_Phong()
        {
            List<string> SelectItem = new List<string>();
            SelectItem.Add("TENLOAIPHONG");
            SelectItem.Add("SLTRONG");
            SelectItem.Add("DONGIA");
            SelectItem.Add("SONGUOITOIDA");


            List<DieuKienParameter> WhereItem = new List<DieuKienParameter>();

            return Doc_bang_Adap("LOAIPHONG", SelectItem, WhereItem);
        }

        public DataTable Phong(string tk, string TenLoaiPhong = "")
        {
            DataTable kq = new DataTable();

            List<string> SelectItem = new List<string>();
            SelectItem.Add("p.TENPHONG");
            SelectItem.Add("t.TENLOAIPHONG");
            SelectItem.Add("t.SONGUOITOIDA");
            SelectItem.Add("p.TINHTRANGPHONG");

            int MaLoaiPhong = 0;

            if (TenLoaiPhong != "")
                MaLoaiPhong = Convert.ToInt32(Doc_bang_Scalar("LOAIPHONG", "MALOAIPHONG",
                    new List<DieuKienParameter>() { new DieuKienParameter("TENLOAIPHONG", 
                        TenLoaiPhong, ParameterType.String) }));

            List<DieuKienParameter> WhereItem = new List<DieuKienParameter>();

            if (TenLoaiPhong != "")
            {
                WhereItem.Add(new DieuKienParameter("t.MALOAIPHONG", MaLoaiPhong.ToString(), ParameterType.Inte));
            }

            if (tk != "")
            {
                WhereItem.Add(new DieuKienParameter("q.TAIKHOAN", tk, ParameterType.String));
            }

            kq = Doc_bang_Adap("PHONG p join PHONG_QUANLY q on p.MAPHONG=q.MA_PHONG join" +
            " LOAIPHONG t on p.MALOAIPHONG=t.MALOAIPHONG", SelectItem, WhereItem);

            return kq;
        }


        // This area is for room data
        public bool ThemPhong(string tk, string ma_phong, string loai_phong)
        {
            List<DieuKienParameter> Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("loaiphong", loai_phong, ParameterType.String));
            Value.Add(new DieuKienParameter("tenphong", ma_phong, ParameterType.String));
            Value.Add(new DieuKienParameter("tinhtrang", "Trống", ParameterType.String));
            Value.Add(new DieuKienParameter("taikhoan", tk, ParameterType.String));

            return TransactSQL("ThemPhong", Value);
        }

        public bool XoaPhong(string tk, string ma_phong)
        {
            List<DieuKienParameter> Value = new List<DieuKienParameter>();

            // Cập nhập số lượng phòng trống
            int ma_loai_phong = Convert.ToInt32(Doc_bang_Scalar("PHONG", "MALOAIPHONG",
                new List<DieuKienParameter>() { new DieuKienParameter("MAPHONG", 
                        ma_phong, ParameterType.String) }));

            int SoLuongTrong = 0;

            SoLuongTrong = Convert.ToInt32(Doc_bang_Scalar("LOAIPHONG", "SLTRONG",
                new List<DieuKienParameter>() { new DieuKienParameter("MALOAIPHONG", 
                        ma_loai_phong.ToString(), ParameterType.String) }));

            SoLuongTrong--;

            Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("SLTRONG", SoLuongTrong.ToString(), ParameterType.Inte));

            List<DieuKienParameter> DieuKien = new List<DieuKienParameter>();
            DieuKien.Add(new DieuKienParameter("MALOAIPHONG", ma_loai_phong.ToString(), ParameterType.Inte));

            if (!Cap_nhap_bang("LOAIPHONG", Value, DieuKien))
                return false;

            // Xóa phòng khỏi tài khoản quản lý
            Value.Clear();

            Value.Add(new DieuKienParameter("MA_PHONG", ma_phong, ParameterType.String));
            Value.Add(new DieuKienParameter("TAIKHOAN", tk, ParameterType.String));

            if (!Xoa_bang("PHONG_QUANLY", Value))
                return false;

            Value.Clear();

            // Xóa thông tin phòng
            Value.Add(new DieuKienParameter("MAPHONG", ma_phong, ParameterType.String));

            if (!Xoa_bang("PHONG", Value))
                return false;



            return true;
        }

        // We must set old_key (old_ma_phong) to let the query know with row need to be updated.
        public bool CapNhapPhong(string old_ma_phong, string ma_phong, string loai_phong, string tinhtrang)
        {
            List<DieuKienParameter> DieuKien = new List<DieuKienParameter>();
            DieuKien.Add(new DieuKienParameter("loaiphong", loai_phong, ParameterType.String));
            DieuKien.Add(new DieuKienParameter("tenphong", ma_phong, ParameterType.String));
            DieuKien.Add(new DieuKienParameter("tenphongold", old_ma_phong, ParameterType.String));
            DieuKien.Add(new DieuKienParameter("tinhtrang", tinhtrang, ParameterType.String));

            return TransactSQL("CapNhapPhong", DieuKien);
        }

        public int Dem_loaiphong()
        {
            List<string> InsertItem = new List<string>();
            InsertItem.Add("LOAIPHONG");
            int d;
            d = Dem("DONGIA_PHONG", InsertItem);
            return d;
        }

        // End room data

        // This area is for room catagory data

        //Thêm loại phòng
        public bool ThemLoaiPhong(string loaiphong, float dongia, int songuoitoida)
        {
            List<DieuKienParameter> Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("tenloai", loaiphong, ParameterType.String));
            Value.Add(new DieuKienParameter("dongia", dongia.ToString(), ParameterType.Float));
            Value.Add(new DieuKienParameter("sltrong", "0", ParameterType.Inte));
            Value.Add(new DieuKienParameter("sltoida", songuoitoida.ToString(), ParameterType.Inte));

            return TransactSQL("ThemLoaiPhong", Value);
        }

        public bool Xoa_Loai_Phong(string loaiphong)
        {
            List<DieuKienParameter> Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("tenloai", loaiphong, ParameterType.String));

            return TransactSQL("XoaLoaiPhong", Value);
        }

        public DataTable ThongTin_LoaiPhong(string loaiphong)
        {
            List<string> InsertItem = new List<string>();

            InsertItem.Add("TENLOAIPHONG");
            InsertItem.Add("DONGIA");
            InsertItem.Add("SLTRONG");
            InsertItem.Add("SONGUOITOIDA");

            List<DieuKienParameter> Value = new List<DieuKienParameter>();
            Value.Add(new DieuKienParameter("TENLOAIPHONG", loaiphong, ParameterType.String));

            return Doc_bang_Adap("LOAIPHONG", InsertItem, Value);
        }

        public bool CapNhapLoaiPhong(string old_loai_phong, string loai_phong, float don_gia, int so_nguoi_td, int sltrong)
        {
            List<DieuKienParameter> Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("tenloai", loai_phong, ParameterType.String));
            Value.Add(new DieuKienParameter("dongia", don_gia.ToString(), ParameterType.Float));
            Value.Add(new DieuKienParameter("sltrong", sltrong.ToString(), ParameterType.Inte));
            Value.Add(new DieuKienParameter("sltoida", so_nguoi_td.ToString(), ParameterType.Inte));
            Value.Add(new DieuKienParameter("oldtenloai", old_loai_phong, ParameterType.String));

            return TransactSQL("CapNhapLoai", Value);
        }

        // End room catagory data.

        // Room registration
        /*
        public bool ThemPhieuThue(string ma_phong, string ten_kh, string cmnd, string sdt, string loaikh,
            string tg_bd, string tg_kt = "")
        {
            // Add new customer first
            List<string> InsertItem = new List<string>();

            InsertItem.Add("HOTEN");
            InsertItem.Add("CMND");
            InsertItem.Add("SDT");
            InsertItem.Add("LOAI_KH");

            List<DieuKienParameter> Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("HOTEN", ten_kh, ParameterType.String));
            Value.Add(new DieuKienParameter("CMND", cmnd, ParameterType.String));
            Value.Add(new DieuKienParameter("SDT", sdt, ParameterType.String));
            Value.Add(new DieuKienParameter("LOAI_KH", loaikh, ParameterType.String));

            if (!Them_bang("KHACHHANG", InsertItem, Value))
                return false;

            InsertItem.Clear();
            Value.Clear();

            // Add new rent registration

            // Lấy mã khách hàng vừa thêm
            string LastCusID = Doc_bang_Scalar("KHACHHANG", "MA_KH", new List<DieuKienParameter>(), "MAX");
            // Kết thúc lấy mã khách hàng vừa thêm.

            InsertItem.Add("MA_KH");
            InsertItem.Add("MAPHONG");
            InsertItem.Add("NgayThue");
            if (tg_kt != "")
                InsertItem.Add("NgayTra");
            InsertItem.Add("XacNhan");

            Value.Add(new DieuKienParameter("MA_KH", LastCusID, ParameterType.Inte));
            Value.Add(new DieuKienParameter("MAPHONG", ma_phong, ParameterType.String));
            Value.Add(new DieuKienParameter("NgayThue", tg_bd, ParameterType.Datetime));
            if (tg_kt != "")
                Value.Add(new DieuKienParameter("NgayTra", tg_kt, ParameterType.Datetime));
            Value.Add(new DieuKienParameter("XacNhan", "0", ParameterType.Inte));

            if (!Them_bang("PHIEUTHUE", InsertItem, Value))
                return false;

            // End add rent registration

            InsertItem.Clear();
            Value.Clear();

            // Update room state

            Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("TINHTRANGPHONG", "Có người", ParameterType.String));

            List<DieuKienParameter> DieuKien = new List<DieuKienParameter>();
            DieuKien.Add(new DieuKienParameter("MAPHONG", ma_phong, ParameterType.String));

            if (!Cap_nhap_bang("PHONG", Value, DieuKien))
                return false;

            // End update room state

            // Cập nhập tình trạng loại phòng
            int MaLoaiPhong = 0;

            MaLoaiPhong = Convert.ToInt32(Doc_bang_Scalar("PHONG", "MALOAIPHONG",
                new List<DieuKienParameter>() { new DieuKienParameter("MAPHONG", 
                        ma_phong, ParameterType.String) }));

            int SoLuongTrong = 0;

            SoLuongTrong = Convert.ToInt32(Doc_bang_Scalar("LOAIPHONG", "SLTRONG",
                new List<DieuKienParameter>() { new DieuKienParameter("MALOAIPHONG", 
                        MaLoaiPhong.ToString(), ParameterType.Inte) }));

            SoLuongTrong--;

            Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("SLTRONG", SoLuongTrong.ToString(), ParameterType.Inte));

            DieuKien = new List<DieuKienParameter>();

            DieuKien.Add(new DieuKienParameter("MALOAIPHONG", MaLoaiPhong.ToString(), ParameterType.Inte));

            if (!Cap_nhap_bang("LOAIPHONG", Value, DieuKien))
                return false;

            // Kết thúc cập nhập tình trạng loại phòng

            return true;
        }
        */
        public bool ThemPhieuThue(string ma_phong, string ten_kh, string cmnd, string sdt, string loaikh,
            string tg_bd, string tg_kt="")
        {
            List<DieuKienParameter> Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("hoten", ten_kh, ParameterType.String));
            Value.Add(new DieuKienParameter("cmnd", cmnd, ParameterType.String));
            Value.Add(new DieuKienParameter("sdt", sdt, ParameterType.String));
            Value.Add(new DieuKienParameter("loai_KH", loaikh, ParameterType.String));
            Value.Add(new DieuKienParameter("ngaythue", tg_bd, ParameterType.Datetime));
            Value.Add(new DieuKienParameter("ngayketthuc", tg_bd, ParameterType.Datetime));
            Value.Add(new DieuKienParameter("ma_Phong", ma_phong, ParameterType.String));

            return TransactSQL("ThemPhieuThue", Value);

        }

        public DataSet LayThongTinPhieuThue(string ma_phong)
        {
            DataSet kq = new DataSet();

            int MaPhong = 0;

            MaPhong = Convert.ToInt32(Doc_bang_Scalar("PHONG", "MAPHONG",
                    new List<DieuKienParameter>() { new DieuKienParameter("TENPHONG", 
                        ma_phong, ParameterType.String) }));

            List<string> SelectItem = new List<string>();
            SelectItem.Add("MAPHIEUTHUE");
            SelectItem.Add("MA_KH");
            SelectItem.Add("NgayThue");
            SelectItem.Add("NgayTra");


            List<DieuKienParameter> WhereItem = new List<DieuKienParameter>();
            WhereItem.Add(new DieuKienParameter("MAPHONG", MaPhong.ToString(), ParameterType.Inte));
            WhereItem.Add(new DieuKienParameter("XacNhan", "0", ParameterType.Inte));

            kq.Tables.Add(Doc_bang_Adap("PHIEUTHUE", SelectItem, WhereItem));

            SelectItem.Clear();
            WhereItem.Clear();

            SelectItem.Add("HOTEN");
            SelectItem.Add("CMND");
            SelectItem.Add("SDT");
            SelectItem.Add("LOAI_KH");

            WhereItem.Add(new DieuKienParameter("MA_KH", kq.Tables[0].Rows[0]["MA_KH"].ToString(), ParameterType.Inte));

            kq.Tables.Add(Doc_bang_Adap("KHACHHANG", SelectItem, WhereItem));

            return kq;
        }

        // End room registration

        public DataTable LayThongTinDichVu(string loai_phong)
        {
            int MaLoaiPhong = 0;

            MaLoaiPhong = Convert.ToInt32(Doc_bang_Scalar("LOAIPHONG", "MALOAIPHONG",
                    new List<DieuKienParameter>() { new DieuKienParameter("TENLOAIPHONG", 
                        loai_phong, ParameterType.String) }));

            List<string> SelectItem = new List<string>();
            SelectItem.Add("MA_SPDV");
            SelectItem.Add("TEN_SPDV");
            SelectItem.Add("DONGIA");


            List<DieuKienParameter> WhereItem = new List<DieuKienParameter>();
            WhereItem.Add(new DieuKienParameter("MALOAIPHONG", MaLoaiPhong.ToString(), ParameterType.Inte));

            return Doc_bang_Adap("SANPHAM_DV", SelectItem, WhereItem);
        }

        public bool ThemHoaDon(string maphieuthue, string maphong, string ngay_thanh_toan,
            float tongtien, string tk)
        {
            List<DieuKienParameter> Value = new List<DieuKienParameter>();

            Value.Add(new DieuKienParameter("maphieuthue", maphieuthue, ParameterType.Inte));
            Value.Add(new DieuKienParameter("maphong", maphong, ParameterType.String));
            Value.Add(new DieuKienParameter("ngaythanhtoan", ngay_thanh_toan, ParameterType.Datetime));
            Value.Add(new DieuKienParameter("tk", tk, ParameterType.String));
            Value.Add(new DieuKienParameter("tongtien", tongtien.ToString(), ParameterType.Float));

            return TransactSQL("ThemHoaDon", Value);
        }

        public DataTable LayThongTinThongKe(List<string> tenloai, string tg_bd,
            string tg_kt, string tk, string all = "")
        {
            DataTable kq = new DataTable();
            
            if (all == "")
            {
                List<DieuKienParameter> Value = new List<DieuKienParameter>();

                Value.Add(new DieuKienParameter("thoigiandau", tg_bd, ParameterType.Datetime));
                Value.Add(new DieuKienParameter("thoigiancuoi", tg_kt, ParameterType.Datetime));
                Value.Add(new DieuKienParameter("tenloai", tenloai[0], ParameterType.String));
                Value.Add(new DieuKienParameter("taikhoan", tk, ParameterType.String));

                TransactSQL("ThongKeDoanhThu", Value);

                Value.Clear();

                List<string> SelectItem = new List<string>();
                SelectItem.Add("LOAIPHONG");
                SelectItem.Add("GIATRI");
                SelectItem.Add("TYLE");

                List<DieuKienParameter> WhereItem = new List<DieuKienParameter>();

                kq = Doc_bang_Adap("BAOCAO", SelectItem, WhereItem);

                TransactSQL("XoaBaoCao", Value);
            }
            else
            {
                kq.Columns.Add("LOAIPHONG");
                kq.Columns.Add("GIATRI");
                kq.Columns.Add("TYLE");

                List<DieuKienParameter> Value = new List<DieuKienParameter>();

                for (int i = 0; i < tenloai.Count; i++)
                {
                    Value.Add(new DieuKienParameter("thoigiandau", tg_bd, ParameterType.Datetime));
                    Value.Add(new DieuKienParameter("thoigiancuoi", tg_kt, ParameterType.Datetime));
                    Value.Add(new DieuKienParameter("tenloai", tenloai[i], ParameterType.String));
                    Value.Add(new DieuKienParameter("taikhoan", tk, ParameterType.String));

                    TransactSQL("ThongKeDoanhThu", Value);

                    Value.Clear();

                    List<string> SelectItem = new List<string>();
                    SelectItem.Add("LOAIPHONG");
                    SelectItem.Add("GIATRI");
                    SelectItem.Add("TYLE");

                    List<DieuKienParameter> WhereItem = new List<DieuKienParameter>();

                    DataTable tmp = new DataTable();

                    tmp = Doc_bang_Adap("BAOCAO", SelectItem, WhereItem);

                    DataRow tmprow = tmp.Rows[0];

                    kq.Rows.Add(tmprow.ItemArray);

                    TransactSQL("XoaBaoCao", Value);

                    Value.Clear();
                }
            }

            return kq;
        }

        public DataTable LayDanhSachQuanLy()
        {
            List<string> SelectItem = new List<string>();
            SelectItem.Add("TAIKHOAN");

            List<DieuKienParameter> WhereItem = new List<DieuKienParameter>();

            return Doc_bang_Adap("QUANLY", SelectItem, WhereItem);
        }
    }
}
