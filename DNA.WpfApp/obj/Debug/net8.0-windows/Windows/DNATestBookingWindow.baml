   M S B A M L   `   `   `  ����  
DNA.WpfApp-    'DNA.WpfApp.Windows.DNATestBookingWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Đặt xét nghiệm ADN��5   	   $	��600��6$   $	��800��61    � WindowStartupLocation$ CenterOwner=�5   	   
�������.��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Đặt xét nghiệm ADN��6!   $��24(�6;   $
��Bold"�6I   $��Center=�5      $��0,0,0,20q�61   �� 5   
   $��1��6   .��5      �� .+�5      �� $��Thông tin bệnh nhân��6   $��0,0,0,15q�68   .��5      � $��10q�6    5      �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5      $
��Auto �6,    � ColumnDefinitions 5      �� 5      $	��150 �6/   �� 5      $��* �6/   .+�5!      �� $��0��6$   $��0��61   $��Họ và tên:��6A   $��Center=�6S   �� 5"      -   5         ��Name$ txtPatientName��5"   A   $��0��6$   $��1��61   $
��Bold"�6Y   �� 5$      $��1��6$   $��0��61   $��Email:��6A   $��Center=�6O   �� 5%      -   5        $ txtPatientEmail��5%   A   $��1��6$   $��1��61   6A   �� 5'      $��2��6$   $��0��61   $��Số điện thoại:��6A   $��Center=�6W   �� 5(      -   5        $ txtPatientPhone��5(   A   $��2��6$   $��1��61   6A   5)      5*      �� 5,      $&�� Chọn dịch vụ xét nghiệm��6   $��0,0,0,15q�6<   .��5-      �� -   5         ��Name$ cmbServices��5-       �� DisplayMemberPath$ ServiceName��64    �� SelectedValuePath$ 	ServiceId��5.      $��10q�6=   5/      �� 51      $��Phương thức thu mẫu��6   $��0,0,0,15q�68   .��52      �� $��10q�6!   .+�53      	� -   5         	�Name$ rbHomeSample��53   &   $��Thu mẫu tại nhà��6<   	 	� 	GroupName$	 SampleMethod��6V   
 d� 	IsChecked$

 TrueY�6o   	� 54      -   5        $ rbClinicSample��54   &   $��Thu mẫu tại cơ sở��6>   $	 SampleMethod��6Z   $��0,5,0,0q�6s   	� 55      -   5        $ rbSelfSample��55   &   $��Tự thu thập mẫu��6<   $	 SampleMethod��6V   $��0,5,0,0q�6o   56      57      �� 59      $��Ghi chú��6   $��0,0,0,15q�6,   .��5:      �� -   5         ��Name$ txtNotes��5:       �� AcceptsReturn$
 True��60   $��80��6E   $
��Auto=�5;      $��10q�6N   5<      5=      5>      �� 5A   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5B      �� -	   5        $��Đặt xét nghiệm��5B         PrimaryButtonStyle#��[  5C      $
��15,8q�6A   $��0,0,10,0q�6P   �� 5D      -
   5        $��Hủy��5D        SecondaryButtonStyle#��[ 5E      $
��15,8q�6C   5F      5G      5H      