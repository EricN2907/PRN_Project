   M S B A M L   `   `   `  ����   
DNA.WpfApp$    DNA.WpfApp.Pages.DashboardPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       N� Title$  	Dashboard��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��	Dashboard��$��28(�$
��Bold"�$��0,0,0,20q�� $��1��$��0,0,0,20q� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0�����#E3F2FD �� Padding$ 20q�$��0,0,10,0q� �� CornerRadius$ 5��._��� .+��� $
��📊��$��30(�$��Center=��� -    ��Name$ txtTotalPatients��$��0��$��36(�$
��Bold"�$��Center=����#1976D2�� $��Total Patients��$��14(�$��Center=����#666�� $��1�����#E8F5E8$ 20q�$	��5,0q�$ 5��._��� .+��� $
��🏥��$��30(�$��Center=��� -   $ txtActiveTreatments��$��0��$��36(�$
��Bold"�$��Center=����#388E3C�� $��Active Treatments��$��14(�$��Center=����#666�� $��2�����#FFF3E0$ 20q�$	��5,0q�$ 5��._��� .+��� $
��📅��$��30(�$��Center=��� -   $ txtTodayAppointments��$��0��$��36(�$
��Bold"�$��Center=����#F57C00�� $��Today's Appointments��$��14(�$��Center=����#666�� $��3�����#FCE4EC$ 20q�$��10,0,0,0q�$ 5��._��� .+��� $��👨‍⚕️��$��30(�$��Center=��� -   $ txtAvailableDoctors��$��0��$��36(�$
��Bold"�$��Center=����#C2185B�� $��Available Doctors��$��14(�$��Center=����#666� $��2�� �� $��2* ��� $��* �.+��� $��0��
����������#E0E0E0$��1q�$ 15q�$��0,0,10,0q�$ 5��._��� .+��� $��Recent Activities��$��18(�$
��Bold"�$��0,0,0,15q��� -    ��Name$ lvRecentActivities��$	��300�� �� View �� .P��� $
��Time�� �� Width$	 100��	 �� DisplayMemberBinding	 �� *Time+�� $��Activity��$	 200��	 �� *
Activity+�� $��Patient��$	 150��	 �� *	Patient+�� $��Status��$	 100��	 �� *Status+�� $��1��
����������#E0E0E0$��1q�$ 15q�$��10,0,0,0q�$ 5��._��� .+��� $��Quick Actions��$��18(�$
��Bold"�$��0,0,0,15q��� $��➕ New Patient��$��10q�$	��0,5q����#2196F3
�������$��0q��� $��📅 Schedule Appointment��$��10q�$	��0,5q����#4CAF50
�������$��0q��� $��🏥 New Treatment��$��10q�$	��0,5q����#FF9800
�������$��0q��� $��📋 View Records��$��10q�$	��0,5q����#9C27B0
�������$��0q��� $��📊 Generate Report��$��10q�$	��0,5q����#607D8B
�������$��0q��� $
��0,20q��� $��Upcoming Appointments��$��14(�$
��Bold"�$��0,0,0,10q��� -   $ lvUpcomingAppointments��$	��150������ .R��� .+��� $
��Bold"����� *Time+�� $��12(����� *PatientName+�� $��12(�
����������� *
DoctorName+