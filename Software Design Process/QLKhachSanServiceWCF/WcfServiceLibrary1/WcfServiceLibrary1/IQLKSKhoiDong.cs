using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IQLKSKhoiDong
    {
        [OperationContract]
        int Khoi_dong_dang_nhap(string tk, string mk);

        [OperationContract]
        bool Themloaiphong(string loaiphong, float gia, int sotd);


        [OperationContract]
        bool XoaLoaiPhong(string loaiphong);


        [OperationContract]
        string ThongTin_LoaiPhong(string loaiphong);


        [OperationContract]
        bool CapNhat_LoaiPhong(string old_loai_phong, string loai_phong, float don_gia, int so_nguoi_td, int sltrong);

        [OperationContract]
        string Load_DanhMucPhong();

        [OperationContract]
        bool ThemPhieuThue(string ten_kh, string cmnd, string sdt, string loaikh, string ma_phong,
            string tg_bd, string tg_kt = "");

        [OperationContract]
        string LayThongTinPhieuThue(string ma_phong);

        [OperationContract]
        bool Them_phong(string tk, string ma_phong, string loai_phong);

        [OperationContract]
        bool Xoa_phong(string tk, string ma_phong);

        [OperationContract]
        bool Cap_nhap_phong(string old_ma_phong, string ma_phong, string loai_phong, string tinhtrang);

        [OperationContract]
        string Load_DsPhong(string tk, string LoaiPhong = "");

        [OperationContract]
        string LayThongTinDichVu(string loai_phong);

        [OperationContract]
        bool ThemHoaDon(string maphieuthue, string maphong, string ngay_thanh_toan,
            float tongtien, string tk);

        [OperationContract]
        string LayThongTinThongKe(List<string> tenloai, string tg_bd,
            string tg_kt, string tk, string all = "");

        [OperationContract]
        string LayDanhSachQuanLy();
    }
}
