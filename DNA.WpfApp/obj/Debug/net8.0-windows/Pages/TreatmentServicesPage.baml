   M S B A M L   `   `   `  ����  
DNA.WpfApp,    &DNA.WpfApp.Pages.TreatmentServicesPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$#  Treatment Services Management��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   � $��0��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $8��2Quản lý dịch vụ điều trị hiếm muộn��6(   $��28(�6R   $
��Bold"�6`   $��Center=�6r   �� 5      -   5         ��Name$ btnAddService��5   %   $��1��6   $!��➕ Thêm dịch vụ mới��6<      PrimaryButtonStyle#��[  5      $
��15,8q�6A   5      � 5   
   $��1��6   $��0,0,0,20q�6    5      �� 5      $	��300 �6#   �� 5      $��20 �6#   �� 5      $	��200 �6#   �� 5      $��20 �6#   �� 5       $	��150 �6#   �� 5!      $��* �6#   .+�5$      �� -   5         ��Name$ 	txtSearch��5$   &   $��0��6     InputTextBoxStyle#��[ 69   
 � Tag$* $Tìm kiếm theo tên dịch vụ...��5%      69   �� 5'      -   5         ��Name$ cmbTreatmentTypeFilter��5'   '   $��2��6   .@�5(      �� $%��Tất cả loại điều trị��6   �� 5)      $	��IUI��6   �� 5*      $	��IVF��6   �� 5+      $
��ICSI��6   �� 5,      $��Khác��6   5-      �� 5/      -   5        $ cmbStatusFilter��5/   '   $��4��6   .@�50      �� $��Tất cả trạng thái��6   �� 51      $��Đang hoạt động��6   �� 52      $��Ngừng hoạt động��6   53      54      �� 57   
   $��2��6     	CardStyle#��[ 6   ._�58      � .+�59      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgServices��59         AutoGenerateColumns$ False��6/   	   
IsReadOnly$
	 True��6K   
   SelectionMode$
 Single=�5:         GridLinesVisibility$ 
Horizontal=�62      RowHeaderWidth$ 0Q�5;         CanUserResizeRows$ False��6.      Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	ServiceId+6W     5>      $ Mã dịch vụ��6-   $	 100 6a    6A   �� *ServiceCode+6a     5?      $ Tên dịch vụ��6-   $	 250 6b    6B   �� *ServiceName+6b     5@      $ Loại điều trị��6-   $	 120 6f    6D   �� *TreatmentType+6f     5A      $ Giá (VNĐ)��6-   $	 120 6k    6@   �� *Price+ �� StringFormat$ N0��6k     5B      $ Thời gian (ngày)��6-   $	 120 6h    6G   �� *DurationDays+6h   4  .System.Windows.Controls.DataGridCheckBoxColumn  5C      $ Hoạt động��61   $ 80 6a    6D   �� *
IsActive+6a     5D      $ Ngày tạo��6-   $	 100 6x    6?   �� *CreatedDate+$ 
dd/MM/yyyy��6x   4  .System.Windows.Controls.DataGridTemplateColumn  5E      $ 	Thao tác��61   $	 250 6C      CellTemplate 5F      �� 5G   "   .R�5H   &   ��  �� Orientation$ 
Horizontal=�61   $��Center=�6J   .+�5I   *   �� -   5        $��👁️��5I   1    � ToolTip$ Xem chi tiết��6?   $��2q�5J   N   $	��8,4q�6Y   ���#17A2B8
�������$��0q�6�    5I   V   �� *	ServiceId+5J   �   �� 5K   *   -   5        $��✏️��5K   1   $ Chỉnh sửa��6>   $��2q�5L   N   $	��8,4q�6Y   ���#FFC107
�������$��0q�6�    5K   R   �� *	ServiceId+5L   �   �� 5M   *   -   5        $
��📋��5M   1   $ Quy trình điều trị��6>   $��2q�5N   Q   $	��8,4q�6\   ���#28A745
�������$��0q�6�    5M   [   �� *	ServiceId+5N   �   �� 5O   *   -	   5        $
��💰��5O   1   $ Bảng giá��6>   $��2q�5P   J   $	��8,4q�6U   ���#6F42C1
�������$��0q�6�    5O   Q   �� *	ServiceId+5P   �   �� 5Q   *   -
   5        $	��❌��5Q   1   $ Vô hiệu hóa��6=   $��2q�5R   T   $	��8,4q�6_   ���#DC3545
�������$��0q�6�    5Q   S   �� *	ServiceId+5R   �   5S   '   5T   #   5V      5X      �� 5[      -   5         ��Name$ 
txtLoading��5[      $ ��Đang tải dữ liệu...��60   $��Center=�6K   $��Center=�6h   $��16(�5\      
�������$y�	Collapsed=�6<   �� 5_      -   5        $ 	txtNoData��5_      $(��"Không có dữ liệu dịch vụ��6/   $��Center=�6O   $��Center=�6l   $��16(�5`      
�������$y�	Collapsed=�6<   5a      5b      5c      5d      