   M S B A M L   `   `   `  ����   
DNA.WpfApp;    5DNA.WpfApp.Pages.Treatments.TreatmentRegistrationPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  Treatment Registration��.���� .��� $��20q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$8��2Đăng ký dịch vụ điều trị hiếm muộn��$��28(�$
��Bold"�$��0,0,0,30q��� $��1��   	CardStyle#��[  $��0,0,0,20q�._��� .+��� $ ��1. Thông tin bệnh nhân��$��18(�$
��Bold"�$��0,0,0,15q��  � ColumnDefinitions �� $	��200 ��� $��* ��� $	��150 �.+��� $��0��$��Chọn bệnh nhân:��$��Center=��� -    ��Name$ cmbPatients��$��1�� �� DisplayMemberPath$ FullName�� �� SelectedValuePath$ 	PatientId��$
��10,0q��� -   $��2��$"��➕ Thêm bệnh nhân mới��  PrimaryButtonStyle#��[ $
��10,5q��� -    ��Name$ pnlPatientInfo��$y�	Collapsed=����#F8F9FA �� Padding$ 15q�$��0,15,0,0q� �� CornerRadius$ 5��._��  �� $��* ��� $��* ��� $��* �.+��� $��0��.+��� $��Họ và tên:��$��SemiBold"��� -   	 ��Name$	 txtPatientName��$��-��$��0,0,0,10q��� $��Email:��$��SemiBold"��� -   $	 txtPatientEmail��$��-���� $��1��.+��� $��Số điện thoại:��$��SemiBold"��� -   $	 txtPatientPhone��$��-��$��0,0,0,10q��� $��Ngày sinh:��$��SemiBold"��� -   $	 txtPatientDOB��$��-���� $��2��.+��� $��Địa chỉ:��$��SemiBold"��� -   $	 txtPatientAddress��$��-��$
��Wrap=��� $��2��#��[  $��0,0,0,20q�._��� .+��� $)��#2. Chọn dịch vụ điều trị��$��18(�$
��Bold"�$��0,0,0,15q��  �� $
��Auto ��� $
��Auto �.+�� $��0�� �� $	��200 ��� $��* �.+��� $��0��$��Loại điều trị:��$��Center=��� -	   $ cmbTreatmentType��$��1��$
��10,0q�.@��� $'��!-- Chọn loại điều trị --���� $	��IUI���� $	��IVF���� $
��ICSI���� -
   
 ��Name$
 lstServices��$��1��$��0,15,0,0q�$	��150��$	��200��$y�	Collapsed=����� .R��� $ 10q����#E0E0E0$��1q�$	��0,2q�._��  �� $��* ��� $	��150 ��� $	��100 �.+��� $��0��.+��� $��SemiBold"����� *ServiceName+�� $��12(�
�������$
��Wrap=����� *Description+�� $��1��$��Center=�.+��� $��SemiBold"����#2E86AB���� *Price+ �� StringFormat$ {0:N0} VNĐ���� $��12(�
����������� *DurationDays+$ 	{0} ngày���� $��2��$��Center=�$��Center=����#E3F2FD �� Padding$ 5q�$��12(����� *TreatmentType+�� $��3��#��[  $��0,0,0,20q�._��� .+��� $&�� 3. Chọn bác sĩ điều trị��$��18(�$
��Bold"�$��0,0,0,15q��  �� $	��200 ��� $��* �.+��� $��0��$��	Bác sĩ:��$��Center=��� -   $ 
cmbDoctors��$��1��$ FullName��$ DoctorId��$
��10,0q��� -   $ pnlDoctorInfo��$y�	Collapsed=����#F8F9FA$ 15q�$��0,15,0,0q�$ 5��._��  �� $��* ��� $��* �.+��� $��0��.+��� $��Chuyên khoa:��$��SemiBold"��� -   $	 txtDoctorSpecialization��$��-��$��0,0,0,10q��� $��Kinh nghiệm:��$��SemiBold"��� -   $	 txtDoctorExperience��$��-���� $��1��.+��� $��Bằng cấp:��$��SemiBold"��� -   $	 txtDoctorDegree��$��-��$��0,0,0,10q��� $��Phí tư vấn:��$��SemiBold"��� -   $	 txtDoctorFee��$��-���� $��4��#��[  $��0,0,0,20q�._��� .+��� $#��4. Lịch trình và ghi chú��$��18(�$
��Bold"�$��0,0,0,15q��  �� $
��Auto ��� $
��Auto �.+�� $��0�� �� $	��200 ��� $��* �.+��� $��0��$%��Ngày bắt đầu dự kiến:��$��Center=�O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem (  "System.Windows.Controls.DatePicker  6sys&clr-namespace:System;assembly=mscorlib     -     Name$ dpStartDate��$��1��$
��10,0q�
 �� Now   SelectedDate# Z � $��1��$��0,15,0,0q� �� $	��200 ��� $��* �.+��� $��0��$��	Ghi chú:��$	��Top=�$��0,10,0,0q��� -    ��Name$ txtNotes��$��1��  InputTextBoxStyle#��[ $��80�� �� AcceptsReturn$
 True�� �� TextWrapping$
 Wrap=�" �� VerticalScrollBarVisibility$
 Auto=�$
��10,0q��� $��5��#��[  ._��� .+��� $��5. Tóm tắt đăng ký��$��18(�$
��Bold"�$��0,0,0,15q�� -    �Name$ 
pnlSummary��$y�	Collapsed=� �� $��* ��� $	��200 �.+��� $��0��.+��� -   $	 txtSummaryPatient��$��Bệnh nhân: -��$	��0,2q��� -   $	 txtSummaryService��$��Dịch vụ: -��$	��0,2q��� -   $	 txtSummaryDoctor��$��Bác sĩ: -��$	��0,2q��� -   $	 txtSummaryStartDate��$��Ngày bắt đầu: -��$	��0,2q��� $��1��$��Center=�.+��� $��Tổng chi phí:��$��SemiBold"�$��Right=��� -   $	 txtTotalCost��$��0 VNĐ��$��24(�$
��Bold"����#2E86AB$��Right=���  �� Orientation$ 
Horizontal=�$��Right=�$��0,20,0,0q�.+��� -   $��
Hủy bỏ��$��0,0,10,0q�$��20,10q�
������ ���#DC3545$��2q����#DC3545�� -    ��Name$ btnRegister��$��Đăng ký điều trị��#��[ $��20,10q�${�False��