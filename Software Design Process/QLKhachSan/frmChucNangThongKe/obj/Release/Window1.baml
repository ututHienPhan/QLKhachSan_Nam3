   M S B A M L   `   `   `  ����   frmChucNangThongKe     frmChucNangThongKe.Window1   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$>  8Phần mềm quản lý phòng - khách sạn Hoa Hồng��$	��550��$	��700�� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . 
������  � WindowStyle$
 None=� � ShowInTaskbar .   � SizeToContent$ WidthAndHeight=� +� FocusedElement ��  �� ElementName$ txtId��.���� -   $��
Background�� �� CornerRadius$ 10��
�������$��3q�$��24q�	 �� Padding$	 4q�
 J� Effect
 3  -System.Windows.Media.Effects.DropShadowEffect     Color$
 Gray��   Opacity$ 50Q�   ShadowDepth$ 15Q�._�� $��0,-1,0,1q� � RowDefinitions �� $	��100 ��� �� �� �� $	��100 ��� .+��� $��Xem thống kê doanh thu��$��0��$��0,20,0,0q�$��Center=�$��30(����� .���  � Color$ Black�� � Offset$ 0Q�� $ White��$ 1Q��� $��1�� �� Orientation$ 
Horizontal=�.+��� $��Danh sách quản lý��$
��Left=�$��28��$��20q�$	��Top=�$	��129���� -    ��Name$ 	cbxQuanLy��$
��Left=�$��20,25,20,15q�$	��Top=�$	��154������ �� $��2��$ 
Horizontal=�.+��� $��Danh mục loại phòng��$
��Left=�$��28��$��20q�$	��Top=�$	��129���� -   $ cbxDanhMucPhong��$
��Left=�$��20,25,20,15q�$	��Top=�$	��154������ �� $��3��$ 
Horizontal=�.+��� $��Loại tra cứu��$
��Left=�$��28��$��20q�$	��Top=�$	��129���� -   $ cbxType��$
��Left=�$��20,25,20,15q�$	��Top=�$	��154������ .@���  �� 
IsSelected . .��Số tháng trước�� .��Số năm trước�� $��20q�.�� � ToolTip$ Nhập số��Khoảng cách�� -   $
��tbSL��$��50��$��20q�� $��4�� � ColumnDefinitions �� $	��220 ��� $	��220 ��� $	��220 �.+�� $��0�� �� �� .+��� $��0��$��20,0,0,0q�.��Tên loại phòng�� -   $
��tbLP��$��1��$��20,0,0,0q�� $��1�� �� �� .+��� $��0��.��
Tổng thu�� -   $��lbgiatri��$��1��� $��2�� �� �� .+��� $��0��.��	Tỷ lệ�� -	   $��lbtyle��$��1���� $��5��$ 
Horizontal=�$��Right=�.+��� -
   $	��100��$��20��$��0,0,20,0q� �� 	IsDefault . .��	Tra cứu�� -   $	��100��$��20��$��0,0,20,0q� �� IsCancel . .��Thoát