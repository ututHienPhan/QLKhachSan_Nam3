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
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace frmChucNang
{
    /// <summary>
    /// Interaction logic for frmThemPhong.xaml
    /// </summary>
    public partial class frmThemPhong : Window
    {
        private ServiceReference1.QLKSKhoiDongClient nghiep_vu;

        public bool AddStatus
        {
            get;
            set;
        }

        public frmThemPhong()
        {
            InitializeComponent();
            
            nghiep_vu = new ServiceReference1.QLKSKhoiDongClient(); 
            
            AddStatus = false;

            Background.Background = DTO.DefaultConfig.localbg;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            XmlDocument DM_Phong = new XmlDocument();
            DM_Phong.LoadXml(nghiep_vu.Load_DanhMucPhong());

            XmlNodeList dsLoaiPhong = DM_Phong.SelectNodes("/LOAIPHONG/TENLOAI");

            foreach (var item in dsLoaiPhong)
            {
                XmlElement tenloai = item as XmlElement;
                cbLoaiPhong.Items.Add(tenloai.GetAttribute("VALUE").ToString());
            }

            cbLoaiPhong.SelectedIndex = 0;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            RoomName.Text = "";
            RoomName.Focus();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string tenPhong = RoomName.Text.Trim();

            string loaiPhong = cbLoaiPhong.SelectedValue.ToString();

            if (nghiep_vu.Them_phong(DTO.NguoiDung.GetND().Tk, tenPhong, loaiPhong))
            {
                MessageBox.Show("Thêm thành công");
                AddStatus = true;
            }
            else
                MessageBox.Show("Thêm thất bại");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
