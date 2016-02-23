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
    /// Interaction logic for frmXoaLoai.xaml
    /// </summary>
    public partial class frmXoaLoai : UserControl
    {
        private ServiceReference1.QLKSKhoiDongClient nghiep_vu;

        public frmXoaLoai()
        {
            InitializeComponent();
            nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();
        }

      public void Load_Danhmucphong()
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

        private void XoaLoai_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Danhmucphong();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            string selectLoaiPhong = cbxDanhMucPhong.SelectedValue.ToString();
           if(selectLoaiPhong!=null)
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có thực sự muốn xóa loại phòng này?", "Cảnh báo", MessageBoxButton.YesNo);
                if (rs == MessageBoxResult.Yes)
                {
                    if (nghiep_vu.XoaLoaiPhong(selectLoaiPhong))
                    {
                        MessageBox.Show("Xóa phòng thành công");
                        Load_Danhmucphong();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phòng thất bại");
                    }
                }
                else if (rs == MessageBoxResult.No)
                    return;
            }
        }

       
    }
}
