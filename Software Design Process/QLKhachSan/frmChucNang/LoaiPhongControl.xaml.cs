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
    /// Interaction logic for LoaiPhongControl.xaml
    /// </summary>
    public partial class LoaiPhongControl : UserControl
    {
        private frmThemLoai lpThem;
        private frmXoaLoai lpXoa;
        private frmCapNhap lpCapNhap;
        private DanhMucPhong pDanhMuc;

        public LoaiPhongControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lpThem = new frmThemLoai();

            tmpWin tmp = new tmpWin(lpThem);

            tmp.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lpXoa = new frmXoaLoai();
           
            tmpWin tmp = new tmpWin(lpXoa);

            tmp.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lpCapNhap = new frmCapNhap();
            
            tmpWin tmp = new tmpWin(lpCapNhap);

            tmp.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            pDanhMuc = new DanhMucPhong();

            tmpWin tmp = new tmpWin(pDanhMuc);

            tmp.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
        }

       
    }
}
