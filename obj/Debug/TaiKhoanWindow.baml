   M S B A M L   `   `   `  ����?  ;QLSV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLSVQLSV  5   	   ;"clr-namespace:QLSV.UserControlQLSVQLSV.UserControlQLSV  5   	       QLSV.TaiKhoanWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:QLSV     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   +uc"clr-namespace:QLSV.UserControlQLSV  5   	   -   5          �Name$  Window��5   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ TÀI KHOẢN��5   	   $	��600��5   	   $	��750��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     
DangNhapVM � DataContext# [ 5   	   .��5      � .+�5   
   �  � RowDefinitions 5       �� 5!      $
��auto �6    60   �� 5"      $
��auto �6    60   .+�5$      � $��0��6   .+�5%      '   !QLSV.UserControlQLSV.ControlBarUC  
	 � Tag	 6"   �� *Title+
 �� ElementName$
 Window��6N   5&      � 5'      $��1��6    5(      �� 5)      $
��auto �6$   64   �� 5*      $
��auto �6$   64   .+�5,      � $��0��6   .+�5-      #  MaterialDesignThemes.Wpf.Card  
�������$��10 10 10 10q�5/      .��50      �  � ColumnDefinitions 51      �� 52   "   65   �� 53   "   65   �� 54   "   65   �� 55   "   65   �� 56   "   65    � 	Resources 58       �� 
TargetType �� Property �� Value��%�   '�       �� 59   "   " �6(   .�5:   &   ��  � ��$
 auto��6?   6N   �� 5;   &    � ��$ 	15 0 15 0q�6?   6S   5<   #   5=      .+�5>      � $��0��6#   .+�5?   "   �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên tài khoản��5A   )    % !MaterialDesignFloatingHintTextBox#��[ 5B   )   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton . $��Center=�5D   )   $
��Left=�5E   )   $
��auto��5F   )   ��5@   )   �� *Ten+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5F   )   5G      � 5H      $��1��6#   .+�5I   "   �� $ Tên đăng nhập��5K   )   #��[ 5L   )    . $��Center=�5N   )   $
��Left=�5O   )   $
��auto��5P   )   ��5J   )   �� *
TaiKhoan+$ PropertyChanged=�$ TwoWay=�5P   )   5Q      � 5R      $��2��6#   .+�5S   "   �� $ Mật khẩu��5U   )   #��[ 5V   )    . $��Center=�5X   )   $
��Left=�5Y   )   $
��auto��5Z   )   ��5T   )   �� *	MatKhau+$ PropertyChanged=�$ TwoWay=�5Z   )   5[      � 5\      $��3��6#   .+�5]   "   ��    
HelperText$ Cấp tài khoản��5_   )    . $  ��5a   )   $��Center=�5b   )   $
��Left=�5c   )   $	��100��5d   )   $��0 10 0 0q�5e   )    �� Text 5^   )   �� *Cap_TK+$ PropertyChanged=�$ TwoWay=�.@�5f   &   �� .��63   True69   �� 5g   &   .��63   False6:   5h   #   5i      � 5j      $��4��6#    5k   "   �� 5l   &   66   �� 5m   &   66   �� 5n   &   66    5p   "   ��%�   '�       �� 5q   &   " �6,   .�5r   *   ��  � ��$
 auto��6C   6R   �� 5s   *    � ��$ 	10 5 10 5q�6C   6W   5t   '   5u   #   .+�5v   "   � $��0��6'   .+�5w   &   ��  $  MaterialDesignRaisedAccentButton#��[ 5y   )   $��Thêm��5z   )   ��5x   )   �� *Button_Them_CMD+5z   )   5{   #   � 5|   "   $��1��6'   .+�5}   &   �� #��[ 5   )   $��Sửa��5�   )   ��5~   )   �� *Button_Sua_CMD+5�   )   5�   #   � 5�   "   $��2��6'   .+�5�   &   �� #��[ 5�   )   $
��Xóa��5�   )   ��5�   )   �� *Button_Xoa_CMD+5�   )   5�   #   5�      5�      5�      5�      � 5�      $��1��6   .+�5�        $��
10 0 10 10q�6*   $��Stretch=�6>   $��Stretch=�6Z   .��5�      �� $
��Auto=�6'   .��5�      �� ��6'   �� *DangNhapList+ �� SelectedItem 6L   �� *SelectedItem+$ OneWayToSource=� �� View 5�   "   �� 5�   &   .P�5�   *   �� $��Tên tài khoản��69    �� DisplayMemberBinding 6P   �� *Ten+6w   �� 5�   *   $��Tên đăng nhập��69    6P   �� *
TaiKhoan+6|   �� 5�   *   $��Mật khẩu��69    6K   �� *	MatKhau+6v   �� 5�   *   $��Cấp tài khoản��69    6P   �� *Cap_TK+6z   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      