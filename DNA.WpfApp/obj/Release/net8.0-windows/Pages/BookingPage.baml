   M S B A M L   `   `   `  ����   
DNA.WpfApp"    DNA.WpfApp.Pages.BookingPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$%  Đặt lịch Xét nghiệm ADN��$	��700��$	��900�� � WindowStartupLocation$ CenterScreen=� � 	Resources    SectionHeaderStyle �� 
TargetType �� Property �� Value  FormLabelStyle��%�   &	        &	 s     �� " ��.���  � ��$ 18(���  � ��$
 Bold"���  � �� �#2E86AB��  � ��$ 0,0,0,15q��� " ��.���  � ��$ SemiBold"���  � ��$ 0,0,0,5q�.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�����#2E86AB �� Padding$ 20q�._���  �� Orientation$ 
Horizontal=�.+��� $
��🧬��$��24(�$��Center=�$��0,0,10,0q�
��������� $%��Đặt lịch Xét nghiệm ADN��$��20(�$
��Bold"�
�������$��Center=��� $��1��$��30q�.���� .+��� $)��#1. Chọn dịch vụ xét nghiệm��#��[  �� ���#F8F9FA$ 20q�$��0,0,0,30q�	 �� CornerRadius$	 8��._�� 
 � ColumnDefinitions
 �� $��* ��� $��* �.+��� $��0��$��0,0,15,0q�.+�	� -    	�Name$ rbCivilTest��$!��Xét nghiệm ADN Dân sự��$��16(�$
��Bold"�$��0,0,0,10q� d� 	IsChecked$
 TrueY��� $B��<• Xác định quan hệ huyết thống cha con, mẹ con��$��20,0,0,5q��� $,��&• Phục vụ mục đích cá nhân��$��20,0,0,5q��� $4��.• Có thể tự thu thập mẫu tại nhà��$��	20,0,0,10q��� $��Giá: 2,500,000 VNĐ��$
��Bold"����#A23B72�� $��1��$��15,0,0,0q�.+�	� -   $ rbLegalTest��$$��Xét nghiệm ADN Hành chính��$��16(�$
��Bold"�$��0,0,0,10q��� $0��*• Phục vụ các thủ tục pháp lý��$��20,0,0,5q��� $'��!• Có giá trị tại tòa án��$��20,0,0,5q��� $=��7• Bắt buộc thu thập mẫu tại cơ sở y tế��$��	20,0,0,10q��� $��Giá: 3,500,000 VNĐ��$
��Bold"����#A23B72�� $)��#2. Phương thức thu thập mẫu��#��[  �� ���#F8F9FA$ 20q�$��0,0,0,30q�$	 8��._��� .+�	� -   $ rbSelfCollection��$U��OTự thu thập mẫu tại nhà (Chỉ áp dụng cho xét nghiệm dân sự)��$��14(�$
��Bold"�$��0,0,0,10q�$
 TrueY��� $B��<• Nhận bộ kit xét nghiệm qua đường bưu điện��$��20,0,0,5q��� $3��-• Tự thu thập mẫu theo hướng dẫn��$��20,0,0,5q��� $*��$• Gửi mẫu về cơ sở y tế��$��	20,0,0,15q�	� -   $ rbFacilityCollection��$,��&Thu thập mẫu tại cơ sở y tế��$��14(�$
��Bold"�$��0,0,0,10q��� $2��,• Đến cơ sở y tế theo lịch hẹn��$��20,0,0,5q��� $7��1• Nhân viên chuyên nghiệp thu thập mẫu��$��20,0,0,5q��� $6��0• Đảm bảo chất lượng mẫu tối ưu��$��20,0,0,5q��� $#��3. Thông tin người đặt��#��[  �� ���#F8F9FA$ 20q�$��0,0,0,30q�$	 8��._�� 
 �� $��* ��� $��* �.+��� $��0��$��0,0,15,0q�.+��� $��Họ và tên:��#��[ �� -    ��Name$ txtCustomerName��$��8q�$��0,0,0,15q��� $��Số điện thoại:��#��[ �� -   $ txtCustomerPhone��$��8q�$��0,0,0,15q��� $��Email:��#��[ �� -   $ txtCustomerEmail��$��8q�$��0,0,0,15q��� $��1��$��15,0,0,0q�.+��� $��
CMND/CCCD:��#��[ �� -   $ txtCustomerID��$��8q�$��0,0,0,15q��� $��Địa chỉ:��#��[ �� -	   $ txtCustomerAddress��$��8q�$��60�� �� TextWrapping$
 Wrap=� �� AcceptsReturn$
 True��$��0,0,0,15q��� $1��+4. Thông tin đối tượng xét nghiệm��#��[  �� ���#F8F9FA$ 20q�$��0,0,0,30q�$	 8��._��� .+��� $$��Đối tượng 1 (Bố/Mẹ):��$
��Bold"�$��0,0,0,10q�� $��0,0,0,20q�
 �� $��* ��� $��* ��� $��* �.+��� $��0��$��0,0,10,0q�.+��� $��Họ và tên:��#��[ �� -
   $ txtSubject1Name��$��8q��� $��1��$	��5,0q�.+��� $��
Năm sinh:��#��[ �� -   $ txtSubject1BirthYear��$��8q��� $��2��$��10,0,0,0q�.+��� $��
Quan hệ:��#��[ �� -    ��Name$ cmbSubject1Relationship��$��8q�.@��� $
��Bố���� $
��Mẹ���� $��Khác���� $��Đối tượng 2 (Con):��$
��Bold"�$��0,0,0,10q�� 
 �� $��* ��� $��* ��� $��* �.+��� $��0��$��0,0,10,0q�.+��� $��Họ và tên:��#��[ �� -   $ txtSubject2Name��$��8q��� $��1��$	��5,0q�.+��� $��
Năm sinh:��#��[ �� -   $ txtSubject2BirthYear��$��8q��� $��2��$��10,0,0,0q�.+��� $��
Quan hệ:��#��[ �� -   $ cmbSubject2Relationship��$��8q�.@��� $	��Con�� �� 
IsSelected$
 True���� $��Khác���� $E��?5. Thời gian (Áp dụng cho thu thập mẫu tại cơ sở)��#��[  �� ���#F8F9FA$ 20q�$��0,0,0,30q�$	 8��._�� 
 �� $��* ��� $��* �.+��� $��0��$��0,0,15,0q�.+��� $��Ngày hẹn:��#��[ (  "System.Windows.Controls.DatePicker  -     Name$ dpAppointmentDate��$��8q�$��0,0,0,15q��� $��1��$��15,0,0,0q�.+��� $��Thời gian:��#��[ �� -   $ cmbAppointmentTime��$��8q�.@��� $��08:00 - 09:00���� $��09:00 - 10:00���� $��10:00 - 11:00���� $��13:00 - 14:00���� $��14:00 - 15:00���� $��15:00 - 16:00���� $��16:00 - 17:00���� $��6. Ghi chú��#��[  �� ���#F8F9FA$ 20q�$��0,0,0,20q�$	 8��._��� -   $ txtNotes��$��80��$
 Wrap=�$
 True��$D��>Nhập ghi chú hoặc yêu cầu đặc biệt (nếu có)...���� $��2�����#F8F9FA$ 20q�._�� 
 �� $��* ��� $
��Auto ��� $
��Auto �.+��� $��0��$ 
Horizontal=�.+��� $��Tổng chi phí: ��$��16(�$
��Bold"�$��Center=��� -    ��Name$ txtTotalCost��$��2,500,000 VNĐ��$��18(�$
��Bold"����#A23B72$��Center=��� -    ��Name$ 	btnCancel��$��1��$��Hủy��$��20,10q�$��0,0,15,0q����#6C757D
�������$��0q��� -   $ btnConfirmBooking��$��2��$��Xác nhận đặt lịch��$��20,10q����#2E86AB
�������$��0q�