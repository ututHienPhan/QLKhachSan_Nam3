   M S B A M L   `   `   `  ���� F  BfrmChucNang, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:frmChucNang.PhongFunctionfrmChucNang.PhongFunction  ,    &frmChucNang.PhongFunction.frmPhieuThue   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5d'clr-namespace:frmChucNang.PhongFunction       � Title$>  8Phần mềm quản lý phòng - khách sạn Hoa Hồng��$	��480��$	��830�� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . 
������  � WindowStyle$
 None=� � ShowInTaskbar .   � SizeToContent$ WidthAndHeight=�.���� -   $��
Background�� �� CornerRadius$ 10��
�������$��3q�$��24q� �� Padding$ 4q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   Color$
	 Gray��
   Opacity$
 50Q�   ShadowDepth$ 15Q�._��  � ColumnDefinitions �� $	��250 ��� .+��� $ 10��$��3q�$��10q�$��0������ .���  � Color$ Beige�� � Offset$ 0Q�� $ Bisque��$	 0.5Q�� $ 
BlueViolet��$
 0.75Q�� $
 Aqua��$ 1Q�._��� $��0��.+�� $��10,0,0,0q�.+��� $��50��.��Tên phòng :�� -   $��RoomName��$��50��� $��10,0,0,0q�.+��� $��50��.��Loại phòng :�� -   $��RoomType��$��50��� $��10,0,0,0q�.+��� $��50��.��TG bắt đầu :�� -   $��TG_BD��$��50��� $��10,0,0,0q�.+��� $��50��.��TG kết thúc :�� -   $��TG_KT��$��50���� -   $	��Add��$��Thêm��$��
10,0,10,10q� �� 	IsDefault . �� -   $��Reset��$��
Làm mới��$��
10,0,10,10q��� -   $
��Exit��$��Thoát��$��
10,0,10,10q��� $ 10��$��3q�$��1��$��
0,10,10,10q����� .��� $ Beige��$ 1Q�� $ Bisque��$
 0.75Q�� $ 
BlueViolet��$	 0.5Q�� $
 Aqua��$ 0Q�._��  � RowDefinitions �� $	��100 ��� $	��222 ���  �� �� �� .+��� $��0��$��0��$��3��$��	38,0,37,0q�.+��� $%��../ImageResources/rose-icon.png��   $
	 Gray��$
 50Q�$ 8Q��� $��0��$��1��$��2��$��Center=�$��24(�$��
47,30,47,0q�$	��241������ .��� $ Beige��$ 1Q�� $ Bisque��$
 0.75Q�� $ 
BlueViolet��$	 0.5Q�� $
 Aqua��$ 0Q�.��Thông tin khách hàng�� $��1��$��0��$��
20,10,10,0q�.+��� $��	Họ tên��$��0,5,0,0q��� $
��CMND��$��0,15,0,0q��� $��Số điện thoại��$��0,15,0,0q��� $��Số ngày thuê��$��0,15,0,0q��� $��Loại khách hàng��$��0,15,0,0q��� $��1��$��1��$��2��$��
20,10,20,0q�.+��� -	   $��CusName��$��20,10,20,10q�|�. �� -
   $��	CusNumber��$��20,10,20,10q��� -   $��CusPhone��$��20,10,20,10q��� -   $��RentDays��$��20,10,20,10q�� $��
20,10,20,0q�.+�	� -   $��	CusTypeVn�� d� 	IsChecked$
 TrueY�$��0,0,20,0q�$��
Việt Nam��	� -   $��	CusTypeNn��$��0,0,20,0q�$��Nước ngoài���� $��2��$��0��$��
20,0,10,10q�.+��� -   $��	PriceType��$��Đơn giá ��$��0,5,0,0q��� $��2��$��1��$��2��$��
20,0,20,10q�.+��� -   $��Price��$��20,10,20,10q�