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
using System.Windows.Threading;

namespace frmChucNang.PhongFunction
{
    /// <summary>
    /// Interaction logic for frmPhieuThue.xaml
    /// </summary>
    public partial class frmPhieuThue : Window
    {
        DispatcherTimer timer; 
        
        private ServiceReference1.QLKSKhoiDongClient nghiep_vu;

        public bool addState;

        public frmPhieuThue(string ma_phong, string loai_phong)
        {
            InitializeComponent();
            Background.Background = DTO.DefaultConfig.localbg;
            nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();
            addState = false;

            RoomName.Content = ma_phong;
            RoomType.Content = loai_phong;

            DateTime curtime = DateTime.Today;
            TG_BD.Content = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt");

            // Start timer to update form every second
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            DateTime curtime = DateTime.Today;
            TG_BD.Content = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string ten_kh = CusName.Text.Trim();
            int test = 0;
            
            if (!int.TryParse(CusNumber.Text, out test))
            {
                MessageBox.Show("CMND không hợp lệ!", "Lỗi nhập");
                return;
            }
            else
            {
                string cmnd = CusNumber.Text.Trim();

                if (!int.TryParse(CusPhone.Text, out test))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi nhập");
                    return;
                }
                else
                {
                    int songaythue=0;
                    
                    if (RentDays.Text != "")
                    {
                        if(!int.TryParse(RentDays.Text, out songaythue))
                        {
                            MessageBox.Show("Số ngày thuê không hợp lệ!", "Lỗi nhập");
                            return;
                        }
                    }

                    string dt = CusPhone.Text.Trim();
                    string loai = CusTypeVn.IsChecked == true ? CusTypeVn.Content.ToString() : CusTypeNn.Content.ToString();
                    string tgbd = DateTime.Now.ToString("MM/dd/yyyy");
                    
                    //Tính toán thời gian kết thúc
                    DateTime tgkt=DateTime.Now;
                    
                    if(songaythue>0)
                    {
                        tgkt = tgkt.AddDays(songaythue);
                    }

                    bool result = false;
                    if(tgkt.Day!=DateTime.Now.Day)
                        result=nghiep_vu.ThemPhieuThue(ten_kh, cmnd, dt, loai, 
                            RoomName.Content.ToString(), tgbd, tgkt.ToString("MM/dd/yyyy"));
                    else
                    {
                        result = nghiep_vu.ThemPhieuThue(ten_kh, cmnd, dt, loai,
                            RoomName.Content.ToString(), tgbd, "");
                    }

                    if(result==false)
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thành công");
                        addState = true;
                    }
                }
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            CusName.Text = "";
            CusNumber.Text = "";
            CusPhone.Text = "";
            CusTypeVn.IsChecked = true;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }


    // Bộ chuyển đổi hình thức
    public class BoolToTextHTConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
               object parameter, System.Globalization.CultureInfo culture)
        {
            string result = "";

            if ((bool)values[0] == true)
                result = "Theo giờ";
            if ((bool)values[1] == true)
                result = "Theo ngày";
            if ((bool)values[2] == true)
                result = "Theo tháng";

            return result.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
               object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
