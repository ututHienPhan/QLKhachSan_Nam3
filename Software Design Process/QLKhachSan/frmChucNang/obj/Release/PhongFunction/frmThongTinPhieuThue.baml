   M S B A M L   `   `   `  ����   frmChucNang4    .frmChucNang.PhongFunction.frmThongTinPhieuThue   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$>  8Phần mềm quản lý phòng - khách sạn Hoa Hồng��$	��550��$	��800�� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . 
������  � WindowStyle$
 None=� � ShowInTaskbar .   � SizeToContent$ WidthAndHeight=�.���� -   $��
Background�� �� CornerRadius$ 10��
�������$��3q�$��24q� �� Padding$ 4q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   Color$
	 Gray��
   Opacity$
 50Q�   ShadowDepth$ 15Q�._��  � ColumnDefinitions �� .+��� $ 10��$��3q�$��1��$��
0,10,10,10q����� .���  � Color$ Beige�� � Offset$ 1Q�� $ Bisque��$
 0.75Q�� $ 
BlueViolet��$	 0.5Q�� $
 Aqua��$ 0Q�._��  � RowDefinitions �� $	��100 ��� $	��300 ���  �� �� �� �� .+��� $��0��$��0��$��3��$��
30,20,45,0q�.+��� $%��../ImageResources/rose-icon.png��$��94��   $
	 Gray��$
 50Q�$ 8Q��� $��0��$��1��$��3��$��Center=�$��24(�$��
20,30,15,0q�$	��400������ .��� $ Beige��$ 1Q�� $ Bisque��$
 0.75Q�� $ 
BlueViolet��$	 0.5Q�� $
 Aqua��$ 0Q�.��+)Thông tin phiếu thuê và khách hàng� $��1��$��0��$��4�� �� $	��300 ��� .+��� $��0��$��10q�.+��� $��Thông tin phiếu thuê��$��0,20,0,0q�$��Center=�$��20(����� .��� $ Black��$ 0Q�� $ White��$ 1Q�� $��0,5,0,0q�.+��� $��Mã phiếu thuê���� -   $��lbMPT��$��10,0,0,0q�� $��0,5,0,0q�.+��� $��Mã khách hàng���� -   $��lbMKH��$��10,0,0,0q�� $��0,5,0,0q�.+��� $��
Mã phòng���� -   $
��lbMP��$��10,0,0,0q�� $��0,5,0,0q�.+��� $��Ngày thuê���� -   $
��lbNT��$��10,0,0,0q�� $��0,5,0,0q�.+��� $��Ngày trả���� -   $��lbNTR��$��10,0,0,0q��� $��1��$��20,10,10,10q�.+��� $��Thông tin khách hàng��$��0,20,0,0q�$��Center=�$��20(����� .��� $ Black��$ 0Q�� $ White��$ 1Q�� $��0,5,0,0q�.+��� $��
Họ tên ���� -   $
��lbHT��$��10,0,0,0q�� $��0,5,0,0q�.+��� $��CMND ���� -	   $
��lbID��$��10,0,0,0q�� $��0,5,0,0q�.+��� $��Số điện thoại ���� -
   $��lbSDT��$��10,0,0,0q�� $��0,5,0,0q�.+��� $��Loại khách ���� -   $
��lbLK��$��10,0,0,0q��� $��2��$��4�� �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $��btnHD��$��10,10,10,10q�$	��100�� �� 	IsDefault . .��Lập hóa đơn�� -   $��btnOUT��$��10,10,10,10q�$	��100�� �� IsCancel . .��Thoát