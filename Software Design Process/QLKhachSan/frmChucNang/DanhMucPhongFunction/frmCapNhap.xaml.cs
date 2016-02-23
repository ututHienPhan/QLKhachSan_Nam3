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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Xml;

namespace frmChucNang
{
    /// <summary>
    /// Interaction logic for frmCapNhap.xaml
    /// </summary>
    public partial class frmCapNhap : UserControl
    {
        private ServiceReference1.QLKSKhoiDongClient nghiep_vu;

        public frmCapNhap()
        {
            InitializeComponent();
            nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();
        }

        private void CapNhat_Loaded(object sender, RoutedEventArgs e)
        {
            XmlDocument DM_Phong = new XmlDocument();
            DM_Phong.LoadXml(nghiep_vu.Load_DanhMucPhong());

            XmlNodeList dsLoaiPhong = DM_Phong.SelectNodes("/LOAIPHONG/TENLOAI");

            foreach (var item in dsLoaiPhong)
            {
                XmlElement tenloai = item as XmlElement;
                cbxDanhMucPhong.Items.Add(tenloai.GetAttribute("VALUE").ToString());
            }

            cbxDanhMucPhong.SelectedIndex = 0;
        }

        private void cbxDanhMucPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string loaiphong = cbxDanhMucPhong.SelectedValue.ToString();
            
            string kq = nghiep_vu.ThongTin_LoaiPhong(loaiphong);

            XmlDocument lpinfo = new XmlDocument();

            lpinfo.LoadXml(kq);

            XmlElement info = lpinfo.SelectSingleNode("/LOAIPHONG") as XmlElement;

            txtLoaiPhong.Text = info.GetAttribute("TENLOAIPHONG").ToString();
            txtGia.Text = info.GetAttribute("DONGIA").ToString();
            txtSoLgNg.Text = info.GetAttribute("SONGUOITOIDA").ToString();
            txtSoLgPg.Text = info.GetAttribute("SLTRONG").ToString();
        }

        private void btnThayDoi_Click(object sender, RoutedEventArgs e)
        {
            string old_loaiphong = cbxDanhMucPhong.SelectedValue.ToString();
            string loaiphong = txtLoaiPhong.Text;
            float dongia = 0;
            int solgng = 0;
            int slphong = 0;

            if (float.TryParse(txtGia.Text, out dongia) == false)
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            if (int.TryParse(txtSoLgNg.Text, out solgng) == false)
            {
                MessageBox.Show("Số lượng người không hợp lệ!");
                return;
            }

            if (int.TryParse(txtSoLgPg.Text, out slphong) == false)
            {
                MessageBox.Show("Số lượng phòng không hợp lệ!");
                return;
            }

            if (nghiep_vu.CapNhat_LoaiPhong(old_loaiphong, loaiphong, dongia, solgng, slphong))
            {
                MessageBox.Show("Cập nhật loại phòng thành công");
            }
            else
                MessageBox.Show("Cập nhật loại phòng không thành công");

        }

        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    string tenPhong = RoomName.Text.Trim();
        //    int soNguoi = 0;

        //    if (!int.TryParse(RoomNumber.Text.Trim(), out soNguoi))
        //    {
        //        MessageBox.Show("Số người nhập không hợp lệ");
        //        return;
        //    }

        //    string loaiPhong = cbLoaiPhong.SelectedValue.ToString();

        //    if (nghiep_vu.Cap_nhap_phong(old_ma_phong, tenPhong, loaiPhong, soNguoi))
        //    {
        //        MessageBox.Show("Thay đổi thành công");
        //        UpdateState = true;
        //    }
        //    else
        //        MessageBox.Show("Thay đổi thất bại");
        //}
    }
}
