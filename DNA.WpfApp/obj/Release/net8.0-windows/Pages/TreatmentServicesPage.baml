   M S B A M L   `   `   `  ����   
DNA.WpfApp,    &DNA.WpfApp.Pages.TreatmentServicesPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$#  Treatment Services Management��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�� $��0��$��0,0,0,20q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0��$8��2Quản lý dịch vụ điều trị hiếm muộn��$��28(�$
��Bold"�$��Center=��� -    ��Name$ btnAddService��$��1��$!��➕ Thêm dịch vụ mới��   PrimaryButtonStyle#��[  $
��15,8q�� $��1��$��0,0,0,20q� �� $	��300 ��� $��20 ��� $	��200 ��� $��20 ��� $	��150 ��� $��* �.+��� -    ��Name$ 	txtSearch��$��0��  InputTextBoxStyle#��[ 
 � Tag$* $Tìm kiếm theo tên dịch vụ...���� -    ��Name$ cmbTreatmentTypeFilter��$��2��.@��� $%��Tất cả loại điều trị���� $	��IUI���� $	��IVF���� $
��ICSI���� $��Khác���� -   $ cmbStatusFilter��$��4��.@��� $��Tất cả trạng thái���� $��Đang hoạt động���� $��Ngừng hoạt động���� $��2��  	CardStyle#��[ ._�� .+�&   System.Windows.Controls.DataGrid  -     Name$ 
dgServices��   AutoGenerateColumns$ False��	   
IsReadOnly$
	 True��
   SelectionMode$
 Single=�   GridLinesVisibility$ 
Horizontal=�   RowHeaderWidth$ 0Q�   CanUserResizeRows$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	ServiceId+  $ Mã dịch vụ��$	 100  �� *ServiceCode+  $ Tên dịch vụ��$	 250  �� *ServiceName+  $ Loại điều trị��$	 120  �� *TreatmentType+  $ Giá (VNĐ)��$	 120  �� *Price+ �� StringFormat$ N0��  $ Thời gian (ngày)��$	 120  �� *DurationDays+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ Hoạt động��$ 80  �� *
IsActive+  $ Ngày tạo��$	 100  �� *CreatedDate+$ 
dd/MM/yyyy��4  .System.Windows.Controls.DataGridTemplateColumn  $ 	Thao tác��$	 250    CellTemplate �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��👁️�� � ToolTip$ Xem chi tiết��$��2q�$	��8,4q����#17A2B8
�������$��0q� �� *	ServiceId+�� -   $��✏️��$ Chỉnh sửa��$��2q�$	��8,4q����#FFC107
�������$��0q� �� *	ServiceId+�� -   $
��📋��$ Quy trình điều trị��$��2q�$	��8,4q����#28A745
�������$��0q� �� *	ServiceId+�� -	   $
��💰��$ Bảng giá��$��2q�$	��8,4q����#6F42C1
�������$��0q� �� *	ServiceId+�� -
   $	��❌��$ Vô hiệu hóa��$��2q�$	��8,4q����#DC3545
�������$��0q� �� *	ServiceId+�� -    ��Name$ 
txtLoading��$ ��Đang tải dữ liệu...��$��Center=�$��Center=�$��16(�
�������$y�	Collapsed=��� -   $ 	txtNoData��$(��"Không có dữ liệu dịch vụ��$��Center=�$��Center=�$��16(�
�������$y�	Collapsed=�