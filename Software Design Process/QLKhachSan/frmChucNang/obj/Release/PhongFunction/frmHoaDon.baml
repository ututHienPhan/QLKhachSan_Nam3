   M S B A M L   `   `   `  ����   frmChucNang)    #frmChucNang.PhongFunction.frmHoaDon   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$>  8Phần mềm quản lý phòng - khách sạn Hoa Hồng��$	��500��$	��800�� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . 
������  � WindowStyle$
 None=� � ShowInTaskbar .   � SizeToContent$ WidthAndHeight=�.���� -   $��
Background�� �� CornerRadius$ 10��
�������$��3q�$��24q� �� Padding$ 4q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   Color$
	 Gray��
   Opacity$
 50Q�   ShadowDepth$ 15Q�._��  � ColumnDefinitions �� $	��250 ��� .+��� $ 10��$��3q�$��10q�$��0������ .���  � Color$ Beige�� � Offset$ 0Q�� $ Bisque��$	 0.5Q�� $ 
BlueViolet��$
 0.75Q�� $
 Aqua��$ 1Q�._��� $��0��.+��� $��50��.��Dịch vụ phụ thu :�� -   $��ServiceList��$	��200��
������  �� SelectionMode$ Multiple=��� -   $
��Save��$��Lưu hóa đơn��$��
10,0,10,10q� �� 	IsDefault . �� -   $
��Exit��$��Thoát��$��
10,0,10,10q��� $ 10��$��3q�$��1��$��
0,10,10,10q����� .��� $ Beige��$ 1Q�� $ Bisque��$
 0.75Q�� $ 
BlueViolet��$	 0.5Q�� $
 Aqua��$ 0Q�._��  � RowDefinitions �� $	��100 ��� $	��300 � �� �� �� �� .+��� $��0��$��0��$��3��$��
30,20,45,0q�.+��� $%��../ImageResources/rose-icon.png��   $
	 Gray��$
 50Q�$ 8Q��� $��0��$��1��$��3��$��Center=�$��24(�$��
55,30,55,0q�$	��241������ .��� $ Beige��$ 1Q�� $ Bisque��$
 0.75Q�� $ 
BlueViolet��$	 0.5Q�� $
 Aqua��$ 0Q�.��Thông tin hóa đơn�� $��1��$��0��$��2��$��
20,10,10,0q�.+��  �� �� �� �� �� �� ��  �� �� .+��� $��	Họ tên��$��0,5,0,0q�$��0��$��0���� $��Số điện thoại��$��0,15,0,0q�$��0��$��1���� $��Mã phòng thuê��$��0,15,0,0q�$��0��$��2���� $��Ngày bắt đầu thuê��$��0,15,0,0q�$��0��$��3���� $��Số ngày thuê��$��0,15,0,0q�$��0��$��4���� $�� ��$��0,15,0,0q�$��5��$��0���� $��Thành tiền��$��0,15,0,0q�$��6��$��0��$��	ExtraBold"��� -   $��CusName��$��0,15,0,0q�$��1��$��0���� -   $��CusPhone��$��0,15,0,0q�$��1��$��1���� -   $��RentRoomName��$��0,15,0,0q�$��1��$��2���� -	   $��
CusRentDay��$��0,15,0,0q�$��1��$��3���� -
   $��	CusNumDay��$��0,15,0,0q�$��1��$��4���� $��1��$��2��$��2��$��	20,56,0,0q�.+��  �� �� �� �� �� ��  �� �� .+��� $
��CMND��$��0,0,0,0q�$��0��$��0���� $��Loại phòng��$��0,15,0,0q�$��1��$��0���� $��Ngày thanh toán��$��0,15,0,0q�$��2��$��0���� $��Đơn giá phòng��$��0,15,0,0q�$��3��$��0���� $��Phí dịch vụ��$��0,15,0,0q�$��4��$��0���� -   $��CusId��$��0,0,0,0q�$��0��$��1���� -   $��RoomType��$��0,15,0,0q�$��1��$��1���� -   $��PayDay��$��0,15,0,0q�$��2��$��1���� -   $��
BasicPrice��$��0,15,0,0q�$��3��$��1���� -   $��ServicePrice��$��0,15,0,0q�$��4��$��1���� -   $��
TotalPrice��$��0.000��$��0,15,0,0q�$��5��$��1��
���  ��