   M S B A M L   `   `   `  ����  
DNA.WpfApp/    )DNA.WpfApp.Windows.SampleKitRequestWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  Yêu cầu kit xét nghiệm��5   	   $	��400��6(   $	��600��65    � WindowStartupLocation$ CenterOwner=�5   	   
�������.��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6   $,��&Yêu cầu gửi kit xét nghiệm ADN��6!   $��20(�6G   $
��Bold"�6U   $��Center=�5      $��0,0,0,20q�61   �� 5   
   $��1��6   .+�5      �� $��Địa chỉ gửi kit:��6   $��SemiBold"�60   $��0,0,0,5q�6F   �� 5      -   5         ��Name$ 
txtAddress��5      $��80��6*    �� AcceptsReturn$
 True��66   $
��Auto=�5      $��0,0,0,15q�6F   �� 5      $��	Ghi chú:��6   $��SemiBold"�6(   $��0,0,0,5q�6>   �� 5      -   5        $ txtNotes��5      $��60��6(   $
 True��64   $
��Auto=�5      5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5      �� -   5        $��Gửi yêu cầu��5      $��0,0,10,0q�6D   �� 5      -   5        $��Hủy��5      6#   5      5      5      