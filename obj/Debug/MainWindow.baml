   M S B A M L   `   `   `  ����?  ;QLSV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:QLSVQLSV  5   	   ;"clr-namespace:QLSV.UserControlQLSVQLSV.UserControlQLSV  5   	       QLSV.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   localclr-namespace:QLSV  5   	   +uc"clr-namespace:QLSV.UserControlQLSV  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��
mainWindow��5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ QUẢN LÝ SINH VIÊN��5   	   $	��600��5   	   $	��750��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    
 MainVM � DataContext# [ 5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5!      /  )System.Windows.Interactivity.EventTrigger  5"   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5#      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+   CommandParameter 5$      ��  �� ElementName$ 
mainWindow��5%      .��5(      �  � RowDefinitions 5)   
   �� 5*      $
��auto �6   6,   �� 5+      6   �� 5,      $
��auto �6   6,   .+�5.   
   � $��0��6   .+�5/      '   !QLSV.UserControlQLSV.ControlBarUC  
 � Tag 6   �� *Title+$ 
mainWindow��6N   50      � 51   
   $��1��6    � 	Resources 53       �� 
TargetType �� Property �� Value  MaterialDesignFlatButton �� BasedOn��%�   '�       '�� V     7  �� 54      " �6   .�55      ��  � ��$ 20 10 20 10q�6/   6E   56      �� 57      " ��6   8   .�58      ��  � ��$	 110��6/   6=   �� 59       � ��$	 110��6.   6<   5:      5;      .+�5<      '  !MaterialDesignThemes.Wpf.PopupBox  $��0 20 0 0q�5=         PlacementMode$ BottomAndAlignCentres=�5>       ^� 	Placement$ Right=�5?      $	��Top=�5@      $
��Left=�5A         PopupContent. 5B      �� .+�5C      ��  & "MaterialDesignIconForegroundButton#��[ 5F      $��50��5G      $��50��6%   $��0 0 0 0q�60   ��5D      �� *LoadedWindowCommand+��5E      �� $ 
mainWindow��.��5H      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Printer=�62   5I      �� 5J      #��[ 5M      $��50��5N      $��50��6%   $��0 0 0 0q�60   ��5K      �� *LoadedWindowCommand+��5L      �� $ 
mainWindow��.��5O        $ LoginVariant=�62   5P      5R      5S      #	  MaterialDesignThemes.Wpf.Card	  5U      $��Center=�6"   $��Center=�6=   $��0 20 0 0q�6Z   .��5V      �  5W      �� 5X      6*   �� 5Y      $
��auto �6(   68   �� 5Z      6*   .+�5\      � $��0��6    � ColumnDefinitions 5]      �� 5^      61   �� 5_      $
��auto �6/   6>   �� 5`      61   �� 5a      $
��auto �6/   6>   �� 5b      61   .+�5d      � $��0��6   .+�5e      �� ��6%   �� *MenuSinhVien_CMD+.��5f   "   �� .+�5g   &     $# BadgeAccountHorizontalOutline=�5h   )   $��Center=�6N   $��Center=�6k   $��70��5i   )   $��70��65   �� 5k   &   $��Center=�60   $��Center=�6M   
SINH VIÊN5m   '   5n   #   5o      5p      � 5q      $��1��6   .+�5r      �� 
���   �
���   �$	��150��5u   !   $��1��5v   !   $��Center=�5w   !   $��Center=�5x   !   5y      5z      � 5{      $��2��6   .+�5|      �� ��6%   �� *MenuGiangVien_CMD+.��5}   "   �� .+�5~   &     $ BriefcaseAccountOutline=�5   )   $��Center=�6H   $��Center=�6e   $��70��5�   )   $��70��65   �� 5�   &   $��Center=�60   $��Center=�6M   GIẢNG VIÊN5�   '   5�   #   5�      5�      � 5�      $��3��6   .+�5�      �� 
���   �
���   �$	��150��5�   !   $��1��5�   !   $��Center=�5�   !   $��Center=�5�   !   5�      5�      � 5�      $��4��6   .+�5�      �� ��6%   �� *MenuMonHoc_CMD+.��5�   "   �� .+�5�   &     $ BookMultipleOutline=�5�   )   $��Center=�6D   $��Center=�6a   $��70��5�   )   $��70��65   �� 5�   &   $��Center=�60   $��Center=�6M   
MÔN HỌC5�   '   5�   #   5�      5�      5�      � 5�      $��1��6   .+�5�      �� 
���   �
���   �$��1��5�      $	��150��5�      $
��Left=�5�      5�      �� 5�      
���   �
���   �$��1��5�      $	��150��5�      $��Center=�5�      5�      �� 5�      
���   �
���   �$��1��5�      $	��150��5�      $��Right=�5�      5�      5�      � 5�      $��2��6    5�      �� 5�      61   �� 5�      $
��auto �6/   6>   �� 5�      61   �� 5�      $
��auto �6/   6>   �� 5�      61   .+�5�      � $��0��6   .+�5�      �� ��6%   �� *MenuSearch_CMD+.��5�   "   �� .+�5�   &     $ BookEducationOutline=�5�   )   $��Center=�6E   $��Center=�6b   $��70��5�   )   $��70��65   �� 5�   &   $��Center=�60   $��Center=�6M   	ĐIỂM5�   '   5�   #   5�      5�      � 5�      $��1��6   .+�5�      �� 
���   �
���   �$	��150��5�   !   $��1��5�   !   $��Center=�5�   !   $��Center=�5�   !   5�      5�      � 5�      $��2��6   .+�5�      �� ��6%   �� *MenuLopSH_CMD+.��5�   "   �� $	��-18q�6-   .+�5�   &     $ GoogleClassroom=�5�   )   $��Center=�6@   $��Center=�6]   $��70��5�   )   $��70��65   �� 5�   &   $��Center=�60   $��Center=�6M   LỚP SINH HOẠT5�   '   5�   #   5�      5�      � 5�      $��3��6   .+�5�      �� 
���   �
���   �$	��150��5�   !   $��1��5�   !   $��Center=�5�   !   $��Center=�5�   !   5�      5�      � 5�      $��4��6   .+�5�      �� ��6%   �� *MenuTaiKhoan_CMD+.��5�   "   �� .+�5�   &     $ AccountCogOutline=�5�   )   $��Center=�6B   $��Center=�6_   $��70��5�   )   $��70��65   �� 5�   &   $��Center=�60   $��Center=�6M   TÀI KHOẢN5�   '   5�   #   5�      5�      5�      5�      5�      5�      � 5�   
   $��2��6   5�      5�      5�      