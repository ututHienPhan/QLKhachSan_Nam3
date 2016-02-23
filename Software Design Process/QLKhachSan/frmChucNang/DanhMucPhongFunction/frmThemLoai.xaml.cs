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
    /// Interaction logic for frmThemLoai.xaml
    /// </summary>
    public partial class frmThemLoai : UserControl
    {
        private ServiceReference1.QLKSKhoiDongClient nghiep_vu;

        public frmThemLoai()
        {
            InitializeComponent();
            nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();
        }

        private void ThemLoai_Loade(object sender, RoutedEventArgs e)
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
      
        private void Them_Click(object sender, RoutedEventArgs e)
        {
            string LoaiPhong = txtLoaiPhong.Text.Trim();
            
            int sotoida = 0;
            float gia = 0;

            if(int.TryParse(txtSoLuong.Text,out sotoida)==false)
            {
                MessageBox.Show("Số người tối đa nhập không hợp lệ");
                return;
            }

            if(float.TryParse(txtGia.Text,out gia)==false)
            {
                MessageBox.Show("Giá nhập không hợp lệ");
                return;
            }

            if (nghiep_vu.Themloaiphong(txtLoaiPhong.Text.Trim(), gia, sotoida))
            {
                MessageBox.Show("Thêm thành công");
                //AddStatus = true;
            }
            else
                MessageBox.Show("Thêm thất bại");

        }
    }
}
