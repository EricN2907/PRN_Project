   M S B A M L   `   `   `  ����   
DNA.WpfApp7    1DNA.WpfApp.Pages.Treatments.TreatmentProgressPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  Treatment Progress��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�� $��0��$��0,0,0,20q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0��$*��$Theo dõi tiến độ điều trị��$��28(�$
��Bold"�$��Center=��� -    ��Name$ btnAddProgress��$��1��$#��➕ Cập nhật tiến độ��   PrimaryButtonStyle#��[  $
��15,8q�� $��1��$��0,0,0,20q� �� $	��300 ��� $��20 ��� $	��200 ��� $��20 ��� $	��150 ��� $��* �.+��� -    ��Name$ 	txtSearch��$��0��  InputTextBoxStyle#��[ 
 � Tag$+ %Tìm kiếm theo tên bệnh nhân...���� -    ��Name$ cmbTreatmentTypeFilter��$��2��.@��� $%��Tất cả loại điều trị���� $	��IUI���� $	��IVF���� $
��ICSI���� -   $ cmbStatusFilter��$��4��.@��� $��Tất cả trạng thái���� $��Đã đăng ký���� $��Đang điều trị���� $��Hoàn thành���� $��
Đã hủy���� $��2��  	CardStyle#��[ ._�� .+�&   System.Windows.Controls.DataGrid  -     Name$ dgTreatmentProgress��   AutoGenerateColumns$ False��	   
IsReadOnly$
	 True��
   SelectionMode$
 Single=�   GridLinesVisibility$ 
Horizontal=�   RowHeaderWidth$ 0Q�   CanUserResizeRows$ False��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Mã ĐK��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *RegistrationId+  $ Bệnh nhân��$	 200  �� *PatientName+  $ Dịch vụ��$	 200  �� *ServiceName+  $ Bác sĩ��$	 150  �� *
DoctorName+  $ Ngày bắt đầu��$	 100  �� *	StartDate+ �� StringFormat$ 
dd/MM/yyyy��  $ Trạng thái��$	 100  �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  $ Tiến độ��$	 150    CellTemplate �� .R��� .+��  � Maximum$	 100Q�$��15�����#E0E0E0 � Value �� *ProgressPercentage+���� *ProgressColor+�� $��Center=�$��10(����� *ProgressPercentage+$
 {0}%��  $ 	Thao tác��$	 200  �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��👁️�� � ToolTip$ Xem chi tiết��$��2q�$	��8,4q����#17A2B8
�������$��0q� �� *RegistrationId+�� -   $
��📋��$ Cập nhật tiến độ��$��2q�$	��8,4q����#28A745
�������$��0q� �� *RegistrationId+�� -   $
��💊��$ Lịch thuốc��$��2q�$	��8,4q����#FFC107
�������$��0q� �� *RegistrationId+�� -	   $
��📅��$ Lịch hẹn��$��2q�$	��8,4q����#6F42C1
�������$��0q� �� *RegistrationId+�� -
    ��Name$ 
txtLoading��$ ��Đang tải dữ liệu...��$��Center=�$��Center=�$��16(�
�������$y�	Collapsed=��� -   $ 	txtNoData��$*��$Không có dữ liệu điều trị��$��Center=�$��Center=�$��16(�
�������$y�	Collapsed=�