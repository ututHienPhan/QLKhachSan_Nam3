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

namespace frmChucNang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoaiPhongControl lpControl;

        private UserControl plugin = null;

        public MainWindow()
        {
            InitializeComponent();
            lpControl = new LoaiPhongControl();
            Background.Background = DTO.DefaultConfig.localbg;
        }

        public MainWindow(UserControl pluginGui)
        {
            InitializeComponent();
            plugin = pluginGui;
            Background.Background = DTO.DefaultConfig.localbg;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (plugin == null)
                this.Content.Children.Add(lpControl);
            else
                this.Content.Children.Add(plugin);
        }

        public static void Close()
        {
        }
    }
}
