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
using Bus;
namespace frmChucNang
{
    /// <summary>
    /// Interaction logic for frmXoaLoai.xaml
    /// </summary>
    public partial class frmXoaLoai : UserControl
    {
        private BusinessL nghiep_vu;
        public frmXoaLoai()
        {
            InitializeComponent();
            nghiep_vu = new BusinessL();

        }

      

        private void XoaLoai_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable DM_Phong = nghiep_vu.Load_DanhMucPhong();
            cbxDanhMucPhong.DataContext = DM_Phong.DefaultView;
            cbxDanhMucPhong.DisplayMemberPath = DM_Phong.Columns[0].ToString();
            cbxDanhMucPhong.SelectedValuePath = DM_Phong.Columns[0].ToString();
        }
    }
}
