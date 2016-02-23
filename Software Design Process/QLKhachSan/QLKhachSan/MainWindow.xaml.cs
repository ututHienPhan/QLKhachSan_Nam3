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
using frmQuanLy;
using frmKhachSan;

namespace QLKhachSan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceReference1.QLKSKhoiDongClient XLKD;
        
        public MainWindow()
        {
            InitializeComponent();
            XLKD = new ServiceReference1.QLKSKhoiDongClient();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text == "" || pbxPass.Password == "")
            {
                MessageBox.Show("Nhap thieu tai khoan hoac mat khau. Vui long nhap day du");
            }
            else
            {
                string tk = txtId.Text;
                string mk = pbxPass.Password;

                int result = XLKD.Khoi_dong_dang_nhap(tk, mk);

                if (result == 0)
                    MessageBox.Show("Nhập sai tài khoản hay mật khẩu", "Lỗi đăng nhập", MessageBoxButton.OK);
                else if (result != 0)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    if (result == 1)
                    {
                        DTO.DefaultConfig.localbg = (LinearGradientBrush)Background.Background;
                        frmQuanLy.MainWindow quanly = new frmQuanLy.MainWindow();
                        DTO.NguoiDung.GetND(tk, "Quản lý");
                        this.Close();
                        quanly.ShowDialog();
                    }
                    else if (result == 2)
                    {
                        DTO.DefaultConfig.localbg = (LinearGradientBrush)Background.Background;
                        frmKhachSan.MainWindow chuks = new frmKhachSan.MainWindow();
                        DTO.NguoiDung.GetND(tk, "Chủ khách sạn");
                        this.Close();
                        chuks.ShowDialog();
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
        }

        
    }

    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
               object parameter, System.Globalization.CultureInfo culture)
        {
            int mau = (int)value;

            if (mau == 0)
                return new LinearGradientBrush()
                {
                    EndPoint = new Point(0.5, 1),
                    StartPoint = new Point(0.5, 0),
                    GradientStops = new GradientStopCollection()
                                                {
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFE3E6F5"), 0),
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FF9D9D9D"), 1)
                                                }
                };
            else if (mau == 1)
                return new LinearGradientBrush()
                {
                    EndPoint = new Point(0.5, 1),
                    StartPoint = new Point(0.5, 0),
                    GradientStops = new GradientStopCollection()
                                                {
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFE3FCA9"), 0),
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FF82B03C"), 1),
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFD8FA6C"), 0.5),
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFE0FF98"), 0.5)
                                                }
                };
                return new LinearGradientBrush()
                {
                    EndPoint = new Point(0.5, 1),
                    StartPoint = new Point(0.5, 0),
                    GradientStops = new GradientStopCollection()
                                                {
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFE5E7FA"), 0),
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFE1E4FF"), 1),
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFE3E6F5"), 0.5),
                                                    new GradientStop((Color)ColorConverter.ConvertFromString("#FFD5DBF1"), 0.5)
                                                }
                };
        }
        

        public object ConvertBack(object value, Type targetTypes,
               object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
}
