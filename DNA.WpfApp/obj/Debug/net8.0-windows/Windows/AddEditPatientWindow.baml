   M S B A M L   `   `   `  ����  
DNA.WpfApp-    'DNA.WpfApp.Windows.AddEditPatientWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Thêm/Sửa Bệnh Nhân��5   	   $	��600��5   	   $	��500��6    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��20q�6    � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Thông Tin Bệnh Nhân��6!   $��20(�6<   $
��Bold"�6J   $��0,0,0,20q�6\   �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� .+�5      �  � ColumnDefinitions 5      �� 5      $	��120 �6+   �� 5      $��* �6+   .+�5      �� $��0��6    $��Họ và tên:��60   $��Center=�6B   �� 5      -   5         ��Name$ txtFullName��5   .   $��1��6   $��8q�6C   5      � 5       5      �� 5       $	��120 �6+   �� 5!      $��* �6+   .+�5#      �� $��0��6    $��Email:��60   $��Center=�6>   �� 5$      -   5        $ txtEmail��5$   .   $��1��6   $��8q�6@   5%      � 5'       5(      �� 5)      $	��120 �6+   �� 5*      $��* �6+   .+�5,      �� $��0��6    $��Số điện thoại:��60   $��Center=�6F   �� 5-      -   5        $ txtPhone��5-   .   $��1��6   $��8q�6@   5.      � 50       51      �� 52      $	��120 �6+   �� 53      $��* �6+   .+�55      �� $��0��6    $��Ngày sinh:��60   $��Center=�6B   (  "System.Windows.Controls.DatePicker  56      -   5          Name$ dpDateOfBirth��56   1   $��1��6!   $��8q�6H   57      � 59       5:      �� 5;      $	��120 �6+   �� 5<      $��* �6+   .+�5>      �� $��0��6    $��Giới tính:��60   $��Center=�6B   �� 5?      -   5         ��Name$ 	cmbGender��5?   /   $��1��6   $��8q�6B   .@�5@      �� $	��Nam��6'   �� 5A      $
��Nữ��6'   5B      5C      � 5E       5F      �� 5G      $	��120 �6+   �� 5H      $��* �6+   .+�5J      �� $��0��6    $��Địa chỉ:��60   $��Center=�6@   �� 5K      -   5        $ 
txtAddress��5K   .   $��1��6   $��8q�6B   $��60��6N    �� TextWrapping$
 Wrap=�6Z   	 �� AcceptsReturn$
	 True��6n   5L      � 5N       5O      �� 5P      $	��120 �6+   �� 5Q      $��* �6+   .+�5S      �� $��0��6    $��Tiền sử bệnh:��60   $��Center=�6E   �� 5T      -   5        $ txtMedicalHistory��5T   .   $��1��6   $��8q�6I   $��80��6U   $
 Wrap=�6a   $
	 True��6u   5U      � 5W       5X      �� 5Y      $	��120 �6+   �� 5Z      $��* �6+   .+�5\      �� $��0��6    $��Liên hệ khẩn cấp:��60   $��Center=�6I   �� 5]      -   5        $ txtEmergencyContact��5]   .   $��1��6   $��8q�6K   5^      � 5`       5a      �� 5b      $	��120 �6+   �� 5c      $��* �6+   .+�5e      �� $��0��6    $��SĐT khẩn cấp:��60   $��Center=�6E   �� 5f      -	   5        $ txtEmergencyPhone��5f   .   $��1��6   $��8q�6I   5g      � 5i       5j      �� 5k      $	��120 �6+   �� 5l      $��* �6+   .+�5n      �� $��0��6    $��Nhóm máu:��60   $��Center=�6A   �� 5o      -
   5        $ cmbBloodType��5o   /   $��1��6   $��8q�6E   .@�5p      �� $��A+��6'   �� 5q      $��A-��6'   �� 5r      $��B+��6'   �� 5s      $��B-��6'   �� 5t      $	��AB+��6'   �� 5u      $	��AB-��6'   �� 5v      $��O+��6'   �� 5w      $��O-��6'   5x      5y      � 5{       5|      �� 5}      $	��120 �6+   �� 5~      $��* �6+   .+�5�      �� $��0��6    $��Dị ứng:��60   $��Center=�6?   �� 5�      -   5        $ txtAllergies��5�   .   $��1��6   $��8q�6D   $��60��6P   $
 Wrap=�6\   $
	 True��6p   5�      �� 5�      -   5        
 ��Name$
 chkIsActive��5�      $"��Trạng thái hoạt động��60    d� 	IsChecked$
 TrueY�6O   5�      5�      �� 5�   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5�      �� -   5         ��Name$ btnSave��5�      $
��Lưu��6&   $
��20,8q�64   $��0,0,10,0q�6C   ���#007ACC
�������5�   =   �� 5�      -   5        $ 	btnCancel��5�      $��Hủy��6(   $
��20,8q�66   ���#6C757D
�������5�   =   5�      5�      5�      