using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO;
using System.Xml;

namespace frmChucNang.PhongFunction
{
    /// <summary>
    /// Interaction logic for frmHoaDon.xaml
    /// </summary>
    public partial class frmHoaDon : Window
    {
        Phong phongchon = new Phong();
        KhachHang khachhangthue = new KhachHang();
        PhieuThue phieuthuetu = new PhieuThue();
        LoaiPhong loaiphong = new LoaiPhong();
        List<SPDV> sanpham = new List<SPDV>();
        ServiceReference1.QLKSKhoiDongClient nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();
        float price = 0;

        public frmHoaDon(string ma_phong, LoaiPhong lp)
        {
            InitializeComponent();
            Background.Background = DTO.DefaultConfig.localbg;
            loaiphong = lp;
            phongchon.Tenphong = ma_phong;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin phiếu thuê & khách hàng

            string kq = nghiep_vu.LayThongTinPhieuThue(phongchon.Tenphong);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(kq);

            XmlElement phieuthue = doc.SelectSingleNode("/GOC/PT") as XmlElement;
            XmlElement khachhang = doc.SelectSingleNode("/GOC/KH") as XmlElement;

            phieuthuetu.Ma_phieu_thue = Convert.ToInt32(phieuthue.GetAttribute("MAPHIEUTHUE"));
            phieuthuetu.Ma_kh = khachhangthue.Ma_kh = Convert.ToInt32(phieuthue.GetAttribute("MA_KH"));
            phieuthuetu.Ngay_thue = phieuthue.GetAttribute("NgayThue");
            phieuthuetu.Ngay_tra = phieuthue.GetAttribute("NgayTra");

            khachhangthue.Ho_ten = khachhang.GetAttribute("HOTEN");
            khachhangthue.Cmnd = khachhang.GetAttribute("CMND");
            khachhangthue.Sdt = khachhang.GetAttribute("SDT");
            khachhangthue.Loai_kh = khachhang.GetAttribute("LOAI_KH");
            
            RentRoomName.Content = phieuthuetu.Ma_phong;

            CusName.Content = khachhangthue.Ho_ten;
            CusId.Content = khachhangthue.Cmnd;
            CusPhone.Content = khachhangthue.Sdt;
            CusRentDay.Content = phieuthuetu.Ngay_thue;
            PayDay.Content = DateTime.Now.ToString("dd/MM/yy");

            RoomType.Content = loaiphong.TenLoai;
            BasicPrice.Content = loaiphong.DonGia;

            price = loaiphong.DonGia;
            
            // Lấy thông tin sản phẩm dịch vụ
            kq = nghiep_vu.LayThongTinDichVu(loaiphong.TenLoai);

            doc = new XmlDocument();
            doc.LoadXml(kq);

            XmlNodeList listsp = doc.SelectNodes("/GOC/SP_DV");

            foreach(XmlNode item in listsp)
            {
                XmlElement spdv = item as XmlElement;

                SPDV added = new SPDV();
                added.Ma_spdv = spdv.GetAttribute("MA_SPDV");
                added.Ten_spdv = spdv.GetAttribute("TEN_SPDV");
                added.Don_gia = spdv.GetAttribute("DONGIA");

                sanpham.Add(added);
            }

            foreach(SPDV item in sanpham)
            {
                ServiceList.Items.Add(item.Ten_spdv);
            }
            TotalPrice.Content = price.ToString();
        }

        private void ServiceList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TotalPrice.Content = price.ToString();
            foreach (string item in ServiceList.SelectedItems)
            {
                foreach (var sp in sanpham)
                {

                    if (item == sp.Ten_spdv)
                    {
                        float dongia = float.Parse(TotalPrice.Content.ToString());
                        dongia += float.Parse(sp.Don_gia);
                        TotalPrice.Content = dongia.ToString();
                        break;
                    }
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Bạn có chắc muốn lập hóa đơn này?", "Thông báo", MessageBoxButton.YesNo);

            if(rs==MessageBoxResult.Yes)
            {
                DTO.NguoiDung curuser = null;
                bool kq = nghiep_vu.ThemHoaDon(phieuthuetu.Ma_phieu_thue.ToString(), phongchon.Tenphong, PayDay.Content.ToString(),
                    float.Parse(TotalPrice.Content.ToString()), DTO.NguoiDung.GetND().Tk);
                if(kq==true)
                {
                    MessageBox.Show("Thêm thông tin hóa đơn và cập nhập tình trạng thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Giao tác thất bại", "Thông báo");
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
