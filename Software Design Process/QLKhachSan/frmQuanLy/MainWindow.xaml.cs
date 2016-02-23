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
using frmChucNang;
using frmChucNangThongKe;
using System.ComponentModel;
using System.Reflection;
using System.IO;
using UIContract;

namespace frmQuanLy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<IGUI> guis = new BindingList<IGUI>();

        public MainWindow()
        {
            InitializeComponent();
            Background.Background = DTO.DefaultConfig.localbg;
        }


        private void OpenFunc(object sender, RoutedEventArgs e)
        {
            int value = cbFuncSelect.SelectedIndex;

            if (value == 0)
            {
                frmChucNang.MainWindow GDLoaiPhong = new frmChucNang.MainWindow();

                GDLoaiPhong.Show();
            }
            else if (value == 1)
            {
                frmChucNangThongKe.MainWindow GDThongKe = new frmChucNangThongKe.MainWindow();

                GDThongKe.Show();
            }
            else
            {
                frmChucNang.MainWindow GDLoaiPhong = new frmChucNang.MainWindow(guis[0].GetMainWindow());

                GDLoaiPhong.Show();
            }
        }

        private void CloseFrm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Wdnm_Loaded(object sender, RoutedEventArgs e)
        {
            // Get list of DLL files in main executable folder
            string exePath = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(exePath);
            FileInfo[] fis = new DirectoryInfo(folder).GetFiles("frmQuanLyNhanVien.dll");


            // Load all assemblies from current working directory
            foreach (FileInfo fileInfo in fis)
            {
                var domain = AppDomain.CurrentDomain;
                Assembly assembly = domain.Load(AssemblyName.GetAssemblyName(fileInfo.FullName));

                // Get all of the types in the dll
                Type[] types = assembly.GetTypes();

                // Only create instance of concrete class that inherits from IGUI, IBus or IDao
                foreach (var type in types)
                {
                    if (type.IsClass && !type.IsAbstract)
                    {
                        if (typeof(IGUI).IsAssignableFrom(type))
                            guis.Add(Activator.CreateInstance(type) as IGUI);
                    }
                }
            }

            if (guis.Count == 0)
            {
                PluginResult.Content = "Không tìm thấy plugin nhân viên";
                PluginResult.Foreground = Brushes.Red;
                NVPlugin.IsEnabled = false;
            }
            else
            {
                PluginResult.Content = "Tìm thấy plugin nhân viên";
                PluginResult.Foreground = Brushes.Green;
                NVPlugin.IsEnabled = true;
            }
        }

        private void NVPlugin_Checked(object sender, RoutedEventArgs e)
        {
            if (NVPlugin.IsChecked == true)
                cbFuncSelect.Items.Add("Quản lý nhân viên");
            else
                cbFuncSelect.Items.RemoveAt(cbFuncSelect.Items.Count - 1);
        }
    }
}
