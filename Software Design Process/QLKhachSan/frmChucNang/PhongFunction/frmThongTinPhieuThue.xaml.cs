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
    /// Interaction logic for frmThongTinPhieuThue.xaml
    /// </summary>
    public partial class frmThongTinPhieuThue : Window
    {
        Phong phongchon = new Phong();
        KhachHang khachhangthue = new KhachHang();
        PhieuThue phieuthuetu = new PhieuThue();
        ServiceReference1.QLKSKhoiDongClient nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();

        public frmThongTinPhieuThue(string ma_phong)
        {
            InitializeComponent();
            phongchon.Tenphong = ma_phong;
            Background.Background = DTO.DefaultConfig.localbg;
        }

        private void btnHD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOUT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string kq = nghiep_vu.LayThongTinPhieuThue(phongchon.Tenphong);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(kq);

            XmlElement phieuthue = doc.SelectSingleNode("/GOC/PT") as XmlElement;
            XmlElement khachhang = doc.SelectSingleNode("/GOC/KH") as XmlElement;

            phieuthuetu.Ma_phieu_thue = Convert.ToInt32(phieuthue.GetAttribute("MAPHIEUTHUE"));
            phieuthuetu.Ma_kh =khachhangthue.Ma_kh= Convert.ToInt32(phieuthue.GetAttribute("MA_KH"));
            phieuthuetu.Ngay_thue = phieuthue.GetAttribute("NgayThue");
            phieuthuetu.Ngay_tra = phieuthue.GetAttribute("NgayTra");

            khachhangthue.Ho_ten = khachhang.GetAttribute("HOTEN");
            khachhangthue.Cmnd = khachhang.GetAttribute("CMND");
            khachhangthue.Sdt = khachhang.GetAttribute("SDT");
            khachhangthue.Loai_kh = khachhang.GetAttribute("LOAI_KH");

            lbMPT.Content = phieuthuetu.Ma_phieu_thue;
            lbMKH.Content = phieuthuetu.Ma_kh;
            lbMP.Content = phieuthuetu.Ma_phong;
            lbNT.Content = phieuthuetu.Ngay_thue;
            lbNTR.Content = phieuthuetu.Ngay_tra;

            lbHT.Content = khachhangthue.Ho_ten;
            lbID.Content = khachhangthue.Cmnd;
            lbSDT.Content = khachhangthue.Sdt;
            lbLK.Content = khachhangthue.Loai_kh;
        }
    }
}
