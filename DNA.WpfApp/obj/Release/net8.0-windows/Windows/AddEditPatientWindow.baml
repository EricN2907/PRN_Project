   M S B A M L   `   `   `  ����   
DNA.WpfApp-    'DNA.WpfApp.Windows.AddEditPatientWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Thêm/Sửa Bệnh Nhân��$	��600��$	��500�� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=�.��� $��20q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��Thông Tin Bệnh Nhân��$��20(�$
��Bold"�$��0,0,0,20q��� $��1��$
��Auto=�.���� .+��  � ColumnDefinitions �� $	��120 ��� $��* �.+��� $��0��$��Họ và tên:��$��Center=��� -    ��Name$ txtFullName��$��1��$��8q��  �� $	��120 ��� $��* �.+��� $��0��$��Email:��$��Center=��� -   $ txtEmail��$��1��$��8q��  �� $	��120 ��� $��* �.+��� $��0��$��Số điện thoại:��$��Center=��� -   $ txtPhone��$��1��$��8q��  �� $	��120 ��� $��* �.+��� $��0��$��Ngày sinh:��$��Center=�(  "System.Windows.Controls.DatePicker  -     Name$ dpDateOfBirth��$��1��$��8q��  �� $	��120 ��� $��* �.+��� $��0��$��Giới tính:��$��Center=��� -    ��Name$ 	cmbGender��$��1��$��8q�.@��� $	��Nam���� $
��Nữ���  �� $	��120 ��� $��* �.+��� $��0��$��Địa chỉ:��$��Center=��� -   $ 
txtAddress��$��1��$��8q�$��60�� �� TextWrapping$
 Wrap=�	 �� AcceptsReturn$
	 True���  �� $	��120 ��� $��* �.+��� $��0��$��Tiền sử bệnh:��$��Center=��� -   $ txtMedicalHistory��$��1��$��8q�$��80��$
 Wrap=�$
	 True���  �� $	��120 ��� $��* �.+��� $��0��$��Liên hệ khẩn cấp:��$��Center=��� -   $ txtEmergencyContact��$��1��$��8q��  �� $	��120 ��� $��* �.+��� $��0��$��SĐT khẩn cấp:��$��Center=��� -	   $ txtEmergencyPhone��$��1��$��8q��  �� $	��120 ��� $��* �.+��� $��0��$��Nhóm máu:��$��Center=��� -
   $ cmbBloodType��$��1��$��8q�.@��� $��A+���� $��A-���� $��B+���� $��B-���� $	��AB+���� $	��AB-���� $��O+���� $��O-���  �� $	��120 ��� $��* �.+��� $��0��$��Dị ứng:��$��Center=��� -   $ txtAllergies��$��1��$��8q�$��60��$
 Wrap=�$
	 True���� -   
 ��Name$
 chkIsActive��$"��Trạng thái hoạt động�� d� 	IsChecked$
 TrueY��� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -    ��Name$ btnSave��$
��Lưu��$
��20,8q�$��0,0,10,0q����#007ACC
��������� -   $ 	btnCancel��$��Hủy��$
��20,8q����#6C757D
�������