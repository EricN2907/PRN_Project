   M S B A M L   `   `   `  ����   
DNA.WpfApp,    &DNA.WpfApp.Pages.Patients.PatientsPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  Patients Management�� N� 
Background
 �����.��� $��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0��$��0,0,0,20q� �� $
��Auto ��� $��10 ��� $
��Auto �.+�� $��0�� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0��$=��7Quản lý bệnh nhân & dịch vụ xét nghiệm ADN��$��24(�$
��Bold"�$��Center=��� -    ��Name$ btnAddPatient��$��1��$"��➕ Thêm bệnh nhân mới��   PrimaryButtonStyle#��[  $
��15,8q��� -    ��Name$ quickActionsPanel��$��2�� �� Orientation$ 
Horizontal=�$
��Left=�.+��� $��Thao tác nhanh:��$��Center=�$��SemiBold"�$��0,0,10,0q��� -   $��📊 Dashboard ADN��  SecondaryButtonStyle#��[ $��0,0,5,0q�$	��8,4q��� -   $!��🧪 Quản lý dịch vụ��#��[ $��0,0,5,0q�$	��8,4q��� -   $!��📈 Báo cáo tổng hợp��#��[ $��0,0,5,0q�$	��8,4q��� -   $$��⚙️ Cài đặt bảng giá��#��[ $	��8,4q�� $��1��$��0,0,0,20q� �� $
��Auto ��� $��10 ��� $
��Auto �.+�� $��0�� �� $	��300 ��� $��20 ��� $	��150 ��� $��20 ��� $	��150 ��� $��20 ��� $	��150 ��� $��* �.+��� -    ��Name$ 	txtSearch��$��0��  InputTextBoxStyle#��[ 
 � Tag$; 5Tìm kiếm theo tên, email, số điện thoại...���� -   	 ��Name$	 cmbGenderFilter��$��2��.@��� $��Tất cả giới tính���� $	��Nam���� $
��Nữ���� -	   $	 cmbStatusFilter��$��4��.@��� $��Tất cả trạng thái���� $��Đang hoạt động���� $��Không hoạt động���� -
   $	 cmbDNATestStatusFilter��$��6��.@��� $��Tất cả xét nghiệm���� $��Chưa xét nghiệm���� $��Đang xét nghiệm���� $��Hoàn thành���� $��
Đã hủy���� $��2��$ 
Horizontal=�$��Right=�.+��� -   $ btnExportReport��$��📊 Xuất báo cáo��#��[ $��0,0,10,0q�$
��10,5q��� -   $��🔄 Làm mới��#��[ $
��10,5q��� $��2��  	CardStyle#��[ ._�� .+��� -   
 ��Name$
 
txtLoading��$ ��Đang tải dữ liệu...��$��Center=�$��Center=�$��18(�$
��Bold"�$y�	Collapsed=� K� ZIndex$ 1���� -   $
 	txtNoData��$/��)Không có dữ liệu bệnh nhân nào.��$��Center=�$��Center=�$��16(�
�������$y�	Collapsed=�$ 1��&   System.Windows.Controls.DataGrid  -     Name$ 
dgPatients��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   SelectionMode$ Single=�   GridLinesVisibility$ 
Horizontal=�   RowHeaderWidth$ 0Q�   CanUserResizeRows$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	PatientId+  $ Họ và tên��$	 150  �� *
FullName+  $ Email��$	 150  �� *Email+  $ Số điện thoại��$	 110  �� *Phone+  $ 
Ngày sinh��$ 90  �� *DateOfBirth+ �� StringFormat$ 
dd/MM/yyyy��  $ Giới tính��$ 70  �� *Gender+  $ Trạng thái��$	 100  �� *Status+  $ Trạng thái ADN��$	 120  �� *DNATestStatus+  $ Số lần XN��$ 80  �� *TotalDNATests+4  .System.Windows.Controls.DataGridTemplateColumn  $ Quản lý bệnh nhân��$	 180    CellTemplate �� .R��� $ 
Horizontal=�$��Center=�.+��� -   $��✏️�� � ToolTip$ Sửa thông tin��#��[ $��2q�$��28��$��25�� �� *	PatientId+�� -   $��🗑️��$ Xóa bệnh nhân��  DangerButtonStyle#��[ $��2q�$��28��$��25�� �� *	PatientId+�� -   $
��📋��$ Xem hồ sơ��#��[ $��2q�$��28��$��25�� �� *	PatientId+  $# Dịch vụ xét nghiệm ADN��$	 250  �� .R��� $ 
Horizontal=�$��Center=�.+��� -   $
��🧬��$ Đặt xét nghiệm ADN��#��[  $��1q�$��28��$��25�� �� *	PatientId+�� -   $
��📦��$" Yêu cầu kit xét nghiệm��#��[ $��1q�$��28��$��25�� �� *	PatientId+�� -   $
��🏠��$( "Đặt lịch thu mẫu tại nhà��#��[ $��1q�$��28��$��25�� �� *	PatientId+�� -   $
��📊��$ Theo dõi tiến độ��#��[ $��1q�$��28��$��25�� �� *	PatientId+�� -   $
��📑��$ Xem kết quả��  SuccessButtonStyle#��[ $��1q�$��28��$��25�� �� *	PatientId+�� -   $
��📝��$ Lịch sử xét nghiệm��#��[ $��1q�$��28��$��25�� �� *	PatientId+  $ Đánh giá��$ 80  �� .R��� $ 
Horizontal=�$��Center=�.+��� -   $	��⭐��$$ Xem đánh giá & phản hồi��#��[ $��2q�$��28��$��25�� �� *	PatientId+