   M S B A M L   `   `   `  ����   
DNA.WpfApp-    'DNA.WpfApp.Windows.DNATestHistoryWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$#  Lịch sử xét nghiệm ADN��$	��700��$
��1200�� � WindowStartupLocation$ CenterOwner=�
�������.��� $��20q� � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��0,0,0,20q�.+��� $#��Lịch sử xét nghiệm ADN��$��24(�$
��Bold"�$��Center=��� -    ��Name$ txtPatientInfo��$��14(�$��20,0,0,0q�$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ 	dgHistory��$��1��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   CanUserSortColumns$
 True��	   CanUserReorderColumns$
	 True��
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mã đăng ký��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *RegistrationId+  $ Dịch vụ��$	 250  �� *ServiceName+  $ Loại��$	 100  �� *ServiceType+  $ Ngày đăng ký��$	 120  �� *RegistrationDate+ �� StringFormat$ 
dd/MM/yyyy��  $ Trạng thái��$	 150  �� *Status+  $ Phương thức thu mẫu��$	 150  �� *SampleCollectionMethod+  $ Chi phí��$	 120  �� *	TotalCost+$ N0��  $ Thanh toán��$	 120  �� *PaymentStatus+  $ Tiến độ (%)��$	 100  �� *ProgressPercentage+$ F1���� $��2��$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -   $��Xuất Excel��   SecondaryButtonStyle#��[  $
��15,8q�$��0,0,10,0q��� -   $��Đóng��#��[  $
��15,8q�