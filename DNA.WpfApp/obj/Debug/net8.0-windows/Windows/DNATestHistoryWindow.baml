   M S B A M L   `   `   `  ����  
DNA.WpfApp-    'DNA.WpfApp.Windows.DNATestHistoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  Lịch sử xét nghiệm ADN��5   	   $	��700��6(   $
��1200��65    � WindowStartupLocation$ CenterOwner=�5   	   
�������.��5      � $��20q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,20q�6;   .+�5      �� $#��Lịch sử xét nghiệm ADN��6   $��24(�66   $
��Bold"�6D   $��Center=�6V   �� 5      -   5         ��Name$ txtPatientInfo��5      $��14(�60   $��20,0,0,0q�6>   $��Center=�6P   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgHistory��5       $��1��6      AutoGenerateColumns$ False��63      
IsReadOnly$
 True��5         CanUserSortColumns$
 True��6%   	   CanUserReorderColumns$
	 True��6?   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã đăng ký��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *RegistrationId+6\     5      $ Dịch vụ��6%   $	 250 6V    66   �� *ServiceName+6V     5      $ Loại��6%   $	 100 6S    63   �� *ServiceType+6S     5      $ Ngày đăng ký��6%   $	 120 6{    6;   �� *RegistrationDate+ �� StringFormat$ 
dd/MM/yyyy��6{     5      $ Trạng thái��6%   $	 150 6T    69   �� *Status+6T     5      $ Phương thức thu mẫu��6%   $	 150 6m    6B   �� *SampleCollectionMethod+6m     5      $ Chi phí��6%   $	 120 6g    66   �� *	TotalCost+$ N0��6g     5      $ Thanh toán��6%   $	 120 6[    69   �� *PaymentStatus+6[     5       $ Tiến độ (%)��6%   $	 100 6t    6:   �� *ProgressPercentage+$ F1��6t   5"      �� 5%   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5&      �� -   5        $��Xuất Excel��5&         SecondaryButtonStyle#��[  5'      $
��15,8q�6C   $��0,0,10,0q�6R   �� 5(      -   5        $��Đóng��5(      #��[  5)      $
��15,8q�6C   5*      5+      5,      