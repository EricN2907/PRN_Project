   M S B A M L   `   `   `  ����   
DNA.WpfApp-    'DNA.WpfApp.Windows.DNATestBookingWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Đặt xét nghiệm ADN��$	��600��$	��800�� � WindowStartupLocation$ CenterOwner=�
�������.��� $��20q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��Đặt xét nghiệm ADN��$��24(�$
��Bold"�$��Center=�$��0,0,0,20q��� $��1��.���� .+��� $��Thông tin bệnh nhân��$��0,0,0,15q�.��� $��10q� �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $	��150 ��� $��* �.+��� $��0��$��0��$��Họ và tên:��$��Center=��� -    ��Name$ txtPatientName��$��0��$��1��$
��Bold"��� $��1��$��0��$��Email:��$��Center=��� -   $ txtPatientEmail��$��1��$��1���� $��2��$��0��$��Số điện thoại:��$��Center=��� -   $ txtPatientPhone��$��2��$��1���� $&�� Chọn dịch vụ xét nghiệm��$��0,0,0,15q�.���� -    ��Name$ cmbServices�� �� DisplayMemberPath$ ServiceName�� �� SelectedValuePath$ 	ServiceId��$��10q��� $��Phương thức thu mẫu��$��0,0,0,15q�.���� $��10q�.+�	� -    	�Name$ rbHomeSample��$��Thu mẫu tại nhà��	 	� 	GroupName$	 SampleMethod��
 d� 	IsChecked$

 TrueY�	� -   $ rbClinicSample��$��Thu mẫu tại cơ sở��$	 SampleMethod��$��0,5,0,0q�	� -   $ rbSelfSample��$��Tự thu thập mẫu��$	 SampleMethod��$��0,5,0,0q��� $��Ghi chú��$��0,0,0,15q�.���� -    ��Name$ txtNotes�� �� AcceptsReturn$
 True��$��80��$
��Auto=�$��10q��� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -	   $��Đặt xét nghiệm��   PrimaryButtonStyle#��[  $
��15,8q�$��0,0,10,0q��� -
   $��Hủy��  SecondaryButtonStyle#��[ $
��15,8q�