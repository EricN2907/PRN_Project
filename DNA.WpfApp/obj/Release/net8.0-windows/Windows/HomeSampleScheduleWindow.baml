   M S B A M L   `   `   `  ����   
DNA.WpfApp1    +DNA.WpfApp.Windows.HomeSampleScheduleWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$(  "Đặt lịch thu mẫu tại nhà��$	��500��$	��700�� � WindowStartupLocation$ CenterOwner=�
�������.��� $��20q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$(��"Đặt lịch thu mẫu tại nhà��$��20(�$
��Bold"�$��Center=�$��0,0,0,20q��� $��1��.+��� $��Ngày thu mẫu:��$��SemiBold"�$��0,0,0,5q�(  "System.Windows.Controls.DatePicker  -     Name$ dpSampleDate��$��0,0,0,15q��� $��Giờ thu mẫu:��$��SemiBold"�$��0,0,0,5q��� -    ��Name$ cmbTimeSlot��$��0,0,0,15q�.@��� $��08:00 - 09:00���� $��09:00 - 10:00���� $��10:00 - 11:00���� $��14:00 - 15:00���� $��15:00 - 16:00���� $��16:00 - 17:00���� $��Địa chỉ thu mẫu:��$��SemiBold"�$��0,0,0,5q��� -    ��Name$ 
txtAddress��$��80�� �� AcceptsReturn$
 True��$
��Auto=�$��0,0,0,15q��� $��	Ghi chú:��$��SemiBold"�$��0,0,0,5q��� -   $ txtNotes��$��60��$
 True��$
��Auto=��� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -   $��Đặt lịch��$��0,0,10,0q��� -   $��Hủy��