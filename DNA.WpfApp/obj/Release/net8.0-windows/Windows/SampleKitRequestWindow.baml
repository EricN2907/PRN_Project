   M S B A M L   `   `   `  ����   
DNA.WpfApp/    )DNA.WpfApp.Windows.SampleKitRequestWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$"  Yêu cầu kit xét nghiệm��$	��400��$	��600�� � WindowStartupLocation$ CenterOwner=�
�������.��� $��20q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$,��&Yêu cầu gửi kit xét nghiệm ADN��$��20(�$
��Bold"�$��Center=�$��0,0,0,20q��� $��1��.+��� $��Địa chỉ gửi kit:��$��SemiBold"�$��0,0,0,5q��� -    ��Name$ 
txtAddress��$��80�� �� AcceptsReturn$
 True��$
��Auto=�$��0,0,0,15q��� $��	Ghi chú:��$��SemiBold"�$��0,0,0,5q��� -   $ txtNotes��$��60��$
 True��$
��Auto=��� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -   $��Gửi yêu cầu��$��0,0,10,0q��� -   $��Hủy��