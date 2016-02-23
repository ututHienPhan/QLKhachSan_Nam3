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

namespace frmChucNang.PhongFunction
{
    /// <summary>
    /// Interaction logic for frmCapNhapPhong.xaml
    /// </summary>
    public partial class frmCapNhapPhong : Window
    {
        private ServiceReference1.QLKSKhoiDongClient nghiep_vu;

        int loaiphongind = 0;

        string old_ma_phong = "";

        string past_tinh_trang = "";

        public bool UpdateState
        { get; set; }

        public frmCapNhapPhong(string ma_phong, int loaiphongind)
        {
            InitializeComponent();

            nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();

            this.loaiphongind = loaiphongind;
            
            RoomName.Text = old_ma_phong = ma_phong;

            UpdateState = false;

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

            cbLoaiPhong.SelectedIndex = loaiphongind;
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

            string tinhtrang = cbTinhTrang.SelectionBoxItem.ToString();

            if (nghiep_vu.Cap_nhap_phong(old_ma_phong.Trim(), tenPhong, loaiPhong, tinhtrang))
            {
                MessageBox.Show("Thay đổi thành công");
                UpdateState = true;
            }
            else
                MessageBox.Show("Thay đổi thất bại");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
