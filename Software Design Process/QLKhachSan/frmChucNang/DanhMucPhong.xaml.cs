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
using System.Data.SqlClient;
using System.Data;
using Bus;
using System.Collections.ObjectModel;

namespace frmChucNang
{
    /// <summary>
    /// Interaction logic for DanhMucPhong.xaml
    /// </summary>
    public partial class DanhMucPhong : UserControl
    {
        private BusinessL nghiep_vu;
        public DanhMucPhong()
        {
            InitializeComponent();
            nghiep_vu = new BusinessL();
        }

        private void DanhMucPhong_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable DM_Phong = nghiep_vu.Load_DanhMucPhong();
            cbxDanhMucPhong.DataContext = DM_Phong.DefaultView;
            cbxDanhMucPhong.DisplayMemberPath = DM_Phong.Columns[0].ToString();
            cbxDanhMucPhong.SelectedValuePath = DM_Phong.Columns[0].ToString();
            DataTable dsPhong = nghiep_vu.Load_DsPhong();
            DataGridDSPhong.DataContext = dsPhong.DefaultView;
            
        }
    }
}
