   M S B A M L   `   `   `  ����   frmChucNang    frmChucNang.frmThemPhong   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$>  8Phần mềm quản lý phòng - khách sạn Hoa Hồng��$	��280��$	��610�� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . 
������  � WindowStyle$
 None=� � ShowInTaskbar .   � SizeToContent$ WidthAndHeight=�.���� -   $��
Background�� �� CornerRadius$ 10��
�������$��3q�$��24q� �� Padding$ 4q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   Color$
	 Gray��
   Opacity$
 50Q�   ShadowDepth$ 15Q�._��  � ColumnDefinitions �� $	��200 ��� .+��� $ 10��$��3q�$��10q�$��0������ .���  � Color$ Beige�� � Offset$ 0Q�� $ Bisque��$	 0.5Q�� $ 
BlueViolet��$
 0.75Q�� $
 Aqua��$ 1Q�._��� $��0��.+��� -   $��cbLoaiPhong��$��10,30,10,35q����� �� -   $	��Add��$��Thêm��$��
10,0,10,10q� �� 	IsDefault . �� -   $��Reset��$��
Làm mới��$��
10,0,10,10q��� -   $
��Exit��$��Thoát��$��
10,0,10,10q��� $ 10��$��3q�$��1��$��
0,10,10,10q����� .��� $ Beige��$ 1Q�� $ Bisque��$
 0.75Q�� $ 
BlueViolet��$	 0.5Q�� $
 Aqua��$ 0Q�._��  � RowDefinitions �� $	��100 ��� $	��100 � �� �� �� .+��� $��0��$��0��$��3��$��0q�$	��100��.+��� $%��../ImageResources/rose-icon.png��   $
	 Gray��$
 50Q�$ 8Q��� $��0��$��1��$��2��$��Center=�$��24(�$��0,30,0,0q����� .��� $ Beige��$ 1Q�� $ Bisque��$
 0.75Q�� $ 
BlueViolet��$	 0.5Q�� $
 Aqua��$ 0Q�.��Thêm Phòng�� $��1��$��0��$��20,10,10,10q�.+��� $��Tên phòng��$��0,5,0,0q��� $��1��$��1��$��2��$��20,10,20,10q�.+��� -   $��RoomName��$��20,10,20,10q�|�. 