   M S B A M L   `   `   `  ����  
DNA.WpfApp1    +DNA.WpfApp.Windows.HomeSampleScheduleWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$(  "Đặt lịch thu mẫu tại nhà��5   	   $	��500��6*   $	��700��67    � WindowStartupLocation$ CenterOwner=�5   	   
�������.��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6   $(��"Đặt lịch thu mẫu tại nhà��6!   $��20(�6A   $
��Bold"�6O   $��Center=�5      $��0,0,0,20q�61   �� 5   
   $��1��6   .+�5      �� $��Ngày thu mẫu:��6   $��SemiBold"�6-   $��0,0,0,5q�6C   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpSampleDate��5      $��0,0,0,15q�6/   �� 5      $��Giờ thu mẫu:��6   $��SemiBold"�6,   $��0,0,0,5q�6B   �� 5      -   5         ��Name$ cmbTimeSlot��5      $��0,0,0,15q�6,   .@�5      �� $��08:00 - 09:00��6   �� 5      $��09:00 - 10:00��6   �� 5      $��10:00 - 11:00��6   �� 5      $��14:00 - 15:00��6   �� 5      $��15:00 - 16:00��6   �� 5      $��16:00 - 17:00��6   5      �� 5      $��Địa chỉ thu mẫu:��6   $��SemiBold"�60   $��0,0,0,5q�6F   �� 5      -   5         ��Name$ 
txtAddress��5      $��80��6*    �� AcceptsReturn$
 True��66   $
��Auto=�5       $��0,0,0,15q�6F   �� 5"      $��	Ghi chú:��6   $��SemiBold"�6(   $��0,0,0,5q�6>   �� 5#      -   5        $ txtNotes��5#      $��60��6(   $
 True��64   $
��Auto=�5$      5%      �� 5'   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5(      �� -   5        $��Đặt lịch��5(      $��0,0,10,0q�6B   �� 5)      -   5        $��Hủy��5)      6#   5*      5+      5,      