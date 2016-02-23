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

namespace frmKhachSan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Background.Background = DTO.DefaultConfig.localbg;
            cbFuncSelect.SelectedIndex = 0;
        }

        private void OpenFunc(object sender, RoutedEventArgs e)
        {
            frmChucNangThongKe.Window1 GDThongKe = new frmChucNangThongKe.Window1();

            GDThongKe.Show();
        }

        private void CloseFrm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
