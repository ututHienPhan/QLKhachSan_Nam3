   M S B A M L   `   `   `  ����   frmChucNang    frmChucNang.DanhMucPhong   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $	��470��$	��650��  +� FocusedElement  ��  �� ElementName$ txtId��.��� -    � RowDefinitions �� $��50 ��� $��50 ��� $��50 ��� �� $��50 �.+���  �� Orientation$ 
Horizontal=�$��0��$��
-10,0,10,0q�.+��� $��Loại phòng��$
��Left=�$��	70,17,0,0q�$	��Top=��� -    ��Name$ cbxDanhMucPhong��$
��Left=�$��	30,22,0,0q�$	��Top=�$	��194������ �� -   $��	Quay về��$
��Left=�$��
115,22,0,0q�$	��Top=�$��75�� �� IsCancel . �� $��1��$ 
Horizontal=�.+��� $��Số lượng trống��$��	60,17,0,0q��� -   $
��lbSL��$��50��$��	10,17,0,0q��� $��
Đơn giá��$��	20,17,0,0q��� -   $
��lbDG��$	��100��$��	10,17,0,0q��� $��	Tối đa��$��	20,17,0,0q��� -   $
��lbTD��$	��100��$��	10,17,0,0q��� $��Danh sách phòng��$��2��$
��Left=�$��60,0,0,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ DataGridDSPhong��$
��Left=�$��60,0,0,0q�$	��Top=�$��3��$	��219��$	��481������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Ten Phong��	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ MaPhong�  $ 
Loai Phong��	 . $	
 100  �� $ TenLoai�  $ Toi Da��	 . $	
 100  �� $ ToiDa�  $ 
Tinh Trang��	 . $	
 140  �� $ 	TinhTrang��� $��4��$ 
Horizontal=�.+��� -   $	��Add��$��Thêm phòng��$
��Left=�$��60,0,0,0q�$	��Top=�$��75���� -	   $��Update��$��Sửa thông tin��$
��Left=�$��25,0,0,0q�$	��Top=�$��84���� -
   $��Delete��$��Phiếu thuê��$
��Left=�$��25,0,0,0q�$	��Top=�$��75���� -   $
��Rent��$��Thuê phòng��$
��Left=�$��25,0,0,0q�$	��Top=�$��75���� -   $	��Pay��$��Lập hóa đơn��$
��Left=�$��25,0,0,0q�$	��Top=�$��75��