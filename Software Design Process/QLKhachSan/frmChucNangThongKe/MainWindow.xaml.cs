﻿using System;
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
using System.Xml;

namespace frmChucNangThongKe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceReference1.QLKSKhoiDongClient nghiep_vu;
        public MainWindow()
        {
            InitializeComponent();
            nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();
            Background.Background = DTO.DefaultConfig.localbg;
        }

        private void btnQuayVe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThongKe_Loaded(object sender, RoutedEventArgs e)
        {
            XmlDocument DM_Phong = new XmlDocument();
            DM_Phong.LoadXml(nghiep_vu.Load_DanhMucPhong());

            XmlNodeList dsLoaiPhong = DM_Phong.SelectNodes("/LOAIPHONG/TENLOAI");

            foreach (var item in dsLoaiPhong)
            {
                XmlElement tenloai = item as XmlElement;
                cbxDanhMucPhong.Items.Add(tenloai.GetAttribute("VALUE").ToString());
            }

            cbxDanhMucPhong.Items.Add("Tất cả");

            cbxDanhMucPhong.SelectedIndex = 0;
        }

        // Thoat
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Tra cuu
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int SL = -1;
            string[] dsloaip;

            if(cbxDanhMucPhong.SelectedIndex==(cbxDanhMucPhong.Items.Count-1))
                dsloaip=new string[cbxDanhMucPhong.Items.Count-1];
            else
                dsloaip=new string[1];

            try
            {
                SL = int.Parse(tbSL.Text);
            }
            catch
            {
                MessageBox.Show("Không được phép nhập chữ!", "Cảnh báo!");
                return;
            }

            if (SL < 0)
            {
                MessageBox.Show("Không cho phép nhập số!", "Cảnh báo");
                return;
            }
            DateTime tg_bd = DateTime.Now;
            DateTime tg_kt = DateTime.Now;

            if (cbxType.SelectedIndex == 0)
            {
                tg_bd = DateTime.Today.AddMonths(SL * -1);
                tg_kt = DateTime.Today;

            }
            else if (cbxType.SelectedIndex == 1)
            {
                tg_bd = DateTime.Today.AddYears(SL * -1);
                tg_kt = DateTime.Today;
            }

            string xml = "";

            if (cbxDanhMucPhong.SelectedIndex != (cbxDanhMucPhong.Items.Count - 1))
            {
                dsloaip[0] = cbxDanhMucPhong.SelectedItem.ToString();
                xml = nghiep_vu.LayThongTinThongKe(dsloaip, tg_bd.ToString("yyyy-dd-MM"),
                tg_kt.ToString("yyyy-dd-MM"), DTO.NguoiDung.GetND().Tk, "");
            }
            else
            {
                for (int i = 0; i < dsloaip.Length; i++)
                {
                    dsloaip[i] = cbxDanhMucPhong.Items[i].ToString();
                }
                xml = nghiep_vu.LayThongTinThongKe(dsloaip, tg_bd.ToString("yyyy-dd-MM"),
                tg_kt.ToString("yyyy-dd-MM"), DTO.NguoiDung.GetND().Tk, "all");
            }


            XmlDocument kqthongke = new XmlDocument();
            kqthongke.LoadXml(xml);

            tbLP.Content = kqthongke.DocumentElement.GetAttribute("LOAIPHONG");
            lbgiatri.Content = kqthongke.DocumentElement.GetAttribute("GIATRI");
            lbtyle.Content = kqthongke.DocumentElement.GetAttribute("TYLE") + "%";
        }
    }
}
