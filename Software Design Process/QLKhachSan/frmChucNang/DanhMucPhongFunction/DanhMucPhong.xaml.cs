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
using System.Collections.ObjectModel;
using System.Xml;
using DTO;

namespace frmChucNang
{
    /// <summary>
    /// Interaction logic for DanhMucPhong.xaml
    /// </summary>
    public partial class DanhMucPhong : UserControl
    {
        private ServiceReference1.QLKSKhoiDongClient nghiep_vu;
        List<LoaiPhong> lplist = new List<LoaiPhong>();

        int lpind = -1;

        class TmpPhong
        {
            string maphong = "";
            string tenloai = "";
            string toida = "";
            string ttrang = "";

            public string MaPhong
            {
                get { return maphong; }
                set { this.maphong = value; }
            }
            public string TenLoai
            {
                get { return tenloai; }
                set { this.tenloai = value; }
            }
            public string ToiDa
            {
                get { return toida; }
                set { this.toida = value; }
            }
            public string TinhTrang
            {
                get { return ttrang; }
                set { this.ttrang = value; }
            }

            public TmpPhong(string ma, string tenl, string song, string tinhtrang)
            {
                this.MaPhong = ma;
                this.TenLoai = tenl;
                this.ToiDa = song;
                this.TinhTrang = tinhtrang;
            }
        }

        public DanhMucPhong()
        {
            InitializeComponent();
            nghiep_vu = new ServiceReference1.QLKSKhoiDongClient();
        }

        private void DanhMucPhong_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDanhSachLoaiPhong();
        }

        private void LoadDanhSachLoaiPhong()
        {
            lplist.Clear();

            XmlDocument DM_Phong = new XmlDocument();
            DM_Phong.LoadXml(nghiep_vu.Load_DanhMucPhong());

            XmlNodeList dsLoaiPhong = DM_Phong.SelectNodes("/LOAIPHONG/TENLOAI");

            foreach (XmlNode item in dsLoaiPhong)
            {
                LoaiPhong lp = new LoaiPhong();
                XmlElement tenloai = item as XmlElement;
                cbxDanhMucPhong.Items.Add(tenloai.GetAttribute("VALUE").ToString());
                lp.TenLoai = tenloai.GetAttribute("VALUE").ToString();

                XmlElement sltrong = item.FirstChild as XmlElement;
                XmlElement dongia = sltrong.NextSibling as XmlElement;
                XmlElement toida = dongia.NextSibling as XmlElement;

                lp.SlTrong = Convert.ToInt32(sltrong.GetAttribute("VALUE").ToString());
                lp.DonGia = float.Parse(dongia.GetAttribute("VALUE").ToString());
                lp.ToiDa = Convert.ToInt32(toida.GetAttribute("VALUE").ToString());
                lplist.Add(lp);
            }

            if (lpind == -1)
            {
                cbxDanhMucPhong.SelectedIndex = lpind = 0;
                lbSL.Content = lplist[0].SlTrong;
                lbDG.Content = lplist[0].DonGia.ToString() + " VND";
                lbTD.Content = lplist[0].ToiDa.ToString();
            }
            else
            {
                cbxDanhMucPhong.SelectedIndex = lpind;
                lbSL.Content = lplist[lpind].SlTrong;
                lbDG.Content = lplist[lpind].DonGia.ToString() + " VND";
                lbTD.Content = lplist[lpind].ToiDa.ToString();
            }
        }

        private void Doi_loai_phong(object sender, SelectionChangedEventArgs e)
        {
            int slected = cbxDanhMucPhong.SelectedIndex;
            lbSL.Content = lplist[slected].SlTrong;
            lbDG.Content = lplist[slected].DonGia.ToString() + " VND";
            lbTD.Content = lplist[slected].ToiDa.ToString();

            lpind = slected;

            Load_Danh_Sach_Phong();
        }

        private void ThemPhong_Click(object sender, RoutedEventArgs e)
        {
            frmThemPhong frmThem = new frmThemPhong();
            frmThem.ShowDialog();
            if(frmThem.AddStatus)
            {
                LoadDanhSachLoaiPhong();
                Load_Danh_Sach_Phong();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = DataGridDSPhong.SelectedIndex;

            if(selectedIndex<0)
            {
                MessageBox.Show("Mời chọn 1 phòng!", "Lỗi : Không chọn phòng");
                return;
            }

            var selectedItem = DataGridDSPhong.Items[selectedIndex] as TmpPhong;

            if(selectedItem!=null)
            {
                if (selectedItem.TinhTrang == "Trống")
                {
                    MessageBox.Show("Phòng trống không có phiếu thuê!", "Cảnh báo");
                    return;
                }

                PhongFunction.frmThongTinPhieuThue thongtinphieu = new PhongFunction.frmThongTinPhieuThue(selectedItem.MaPhong);

                thongtinphieu.ShowDialog();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = DataGridDSPhong.SelectedIndex;

            if (selectedIndex < 0)
            {
                MessageBox.Show("Mời chọn 1 phòng!", "Lỗi : Không chọn phòng");
                return;
            }

            var selectedItem = DataGridDSPhong.Items[selectedIndex] as TmpPhong;

            frmChucNang.PhongFunction.frmCapNhapPhong frmCapNhap
                = new frmChucNang.PhongFunction.frmCapNhapPhong(selectedItem.MaPhong.Trim(),
                    cbxDanhMucPhong.SelectedIndex);
            
            frmCapNhap.ShowDialog();

            if (frmCapNhap.UpdateState == true)
            {
                LoadDanhSachLoaiPhong();
                Load_Danh_Sach_Phong();
            }
        }

        private void Load_Danh_Sach_Phong()
        {
            DataGridDSPhong.Items.Clear();
            
            string dsPhong = nghiep_vu.Load_DsPhong(DTO.NguoiDung.GetND().Tk,
                     cbxDanhMucPhong.SelectedValue.ToString());

            XmlDocument PhongDoc = new XmlDocument();
            PhongDoc.LoadXml(dsPhong);

            XmlNodeList PhongList = PhongDoc.SelectNodes("/LOAIPHONG/PHONG");

            foreach (XmlNode item in PhongList)
            {
                XmlElement phong = item as XmlElement;

                TmpPhong PhongObject = new TmpPhong(phong.GetAttribute("MAPHONG").ToString(),
                    phong.GetAttribute("TENLOAIPHONG").ToString(), phong.GetAttribute("SONGUOITOIDA").ToString()
                    , phong.GetAttribute("TINHTRANGPHONG").ToString());

                DataGridDSPhong.Items.Add(PhongObject);
            }
        }

        private void Rent_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = DataGridDSPhong.SelectedIndex;

            if (selectedIndex < 0)
            {
                MessageBox.Show("Mời chọn 1 phòng!", "Lỗi : Không chọn phòng");
                return;
            }

            var selectedItem = DataGridDSPhong.Items[selectedIndex] as TmpPhong;

            if (selectedItem == null)
            {
                MessageBox.Show("Mời chọn 1 phòng!", "Lỗi : Không chọn phòng");
                return;
            }

            if(selectedItem.TinhTrang!="Trống")
            {
                MessageBox.Show("Phòng chọn đã có người thuê","Lỗi : Có người thuê");
                return;
            }

            if (selectedItem != null)
            {
                PhongFunction.frmPhieuThue pt = new PhongFunction.frmPhieuThue(selectedItem.MaPhong,
                    selectedItem.TenLoai);

                pt.ShowDialog();
                if (pt.addState)
                {
                    LoadDanhSachLoaiPhong();
                    Load_Danh_Sach_Phong();
                }
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = DataGridDSPhong.SelectedIndex;

            if (selectedIndex < 0)
            {
                MessageBox.Show("Mời chọn 1 phòng!", "Lỗi : Không chọn phòng");
                return;
            }

            var selectedItem = DataGridDSPhong.Items[selectedIndex] as TmpPhong;

            if (selectedItem != null)
            {
                if (selectedItem.TinhTrang == "Trống")
                {
                    MessageBox.Show("Phòng trống không có phiếu thuê!", "Cảnh báo");
                    return;
                }

                LoaiPhong lptinh=new LoaiPhong();

                foreach(var item in lplist)
                {
                    if (item.TenLoai == selectedItem.TenLoai)
                    {
                        lptinh = item;
                        break;
                    }
                }

                PhongFunction.frmHoaDon hoadon = new PhongFunction.frmHoaDon(selectedItem.MaPhong, lptinh);

                hoadon.ShowDialog();

                LoadDanhSachLoaiPhong();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
