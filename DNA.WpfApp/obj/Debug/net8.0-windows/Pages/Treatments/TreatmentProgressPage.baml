   M S B A M L   `   `   `  ����  
DNA.WpfApp7    1DNA.WpfApp.Pages.Treatments.TreatmentProgressPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  Treatment Progress��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   � $��0��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $*��$Theo dõi tiến độ điều trị��6(   $��28(�6I   $
��Bold"�6W   $��Center=�6i   �� 5      -   5         ��Name$ btnAddProgress��5   %   $��1��6   $#��➕ Cập nhật tiến độ��6=      PrimaryButtonStyle#��[  5      $
��15,8q�6A   5      � 5   
   $��1��6   $��0,0,0,20q�6    5      �� 5      $	��300 �6#   �� 5      $��20 �6#   �� 5      $	��200 �6#   �� 5      $��20 �6#   �� 5       $	��150 �6#   �� 5!      $��* �6#   .+�5$      �� -   5         ��Name$ 	txtSearch��5$   &   $��0��6     InputTextBoxStyle#��[ 69   
 � Tag$+ %Tìm kiếm theo tên bệnh nhân...��5%      6;   �� 5'      -   5         ��Name$ cmbTreatmentTypeFilter��5'   '   $��2��6   .@�5(      �� $%��Tất cả loại điều trị��6   �� 5)      $	��IUI��6   �� 5*      $	��IVF��6   �� 5+      $
��ICSI��6   5,      �� 5.      -   5        $ cmbStatusFilter��5.   '   $��4��6   .@�5/      �� $��Tất cả trạng thái��6   �� 50      $��Đã đăng ký��6   �� 51      $��Đang điều trị��6   �� 52      $��Hoàn thành��6   �� 53      $��
Đã hủy��6   54      55      �� 58   
   $��2��6     	CardStyle#��[ 6   ._�59      � .+�5:      &   System.Windows.Controls.DataGrid  -   5          Name$ dgTreatmentProgress��5:         AutoGenerateColumns$ False��68   	   
IsReadOnly$
	 True��6T   
   SelectionMode$
 Single=�5;         GridLinesVisibility$ 
Horizontal=�62      RowHeaderWidth$ 0Q�5<         CanUserResizeRows$ False��6.      Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã ĐK��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *RegistrationId+6_     5?      $ Bệnh nhân��6-   $	 200 6`    6@   �� *PatientName+6`     5@      $ Dịch vụ��6-   $	 200 6^    6>   �� *ServiceName+6^     5A      $ Bác sĩ��6-   $	 150 6\    6=   �� *
DoctorName+6\     5B      $ Ngày bắt đầu��6-   $	 100 6z    6C   �� *	StartDate+ �� StringFormat$ 
dd/MM/yyyy��6z     5C      $ Trạng thái��6-   $	 100 6\    6A   �� *Status+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5D      $ Tiến độ��61   $	 150 6B      CellTemplate 5E      �� 5F   "   .R�5G   &   �� .+�5H   *   �  � Maximum$	 100Q�6[   $��15��6i   ���#E0E0E0 � Value 66   �� *ProgressPercentage+��5I   6   �� *ProgressColor+6[   �� 5J   *   $��Center=�5K   4   $��10(�6Q   ��5J   4   �� *ProgressPercentage+$
 {0}%��5K   Q   5L   '   5M   #   5O        5P      $ 	Thao tác��61   $	 200 6C    5Q      �� 5R   "   .R�5S   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   .+�5T   *   �� -   5        $��👁️��5T   1    � ToolTip$ Xem chi tiết��6?   $��2q�5U   N   $	��8,4q�6Y   ���#17A2B8
�������$��0q�6�    5T   V   �� *RegistrationId+5U   �   �� 5V   *   -   5        $
��📋��5V   1   $ Cập nhật tiến độ��6>   $��2q�5W   Q   $	��8,4q�6\   ���#28A745
�������$��0q�6�    5V   Y   �� *RegistrationId+5W   �   �� 5X   *   -   5        $
��💊��5X   1   $ Lịch thuốc��6>   $��2q�5Y   U   $	��8,4q�6`   ���#FFC107
�������$��0q�6�    5X   S   �� *RegistrationId+5Y   �   �� 5Z   *   -	   5        $
��📅��5Z   1   $ Lịch hẹn��6>   $��2q�5[   O   $	��8,4q�6Z   ���#6F42C1
�������$��0q�6�    5Z   Q   �� *RegistrationId+5[   �   5\   '   5]   #   5_      5a      �� 5d      -
   5         ��Name$ 
txtLoading��5d      $ ��Đang tải dữ liệu...��60   $��Center=�6K   $��Center=�6h   $��16(�5e      
�������$y�	Collapsed=�6<   �� 5h      -   5        $ 	txtNoData��5h      $*��$Không có dữ liệu điều trị��6/   $��Center=�6P   $��Center=�6m   $��16(�5i      
�������$y�	Collapsed=�6<   5j      5k      5l      5m      