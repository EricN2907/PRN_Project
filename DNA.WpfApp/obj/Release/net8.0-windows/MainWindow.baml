   M S B A M L   `   `   `  ����   
DNA.WpfApp    DNA.WpfApp.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$/  )DNA Fertility Treatment Management System��$	��800��$
��1200�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $��60 ��� $��* ��� $��30 �.+��� $��0�����#2E86AB �� Padding$ 10q�._��  � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��Assets/dna_icon.png��$��40��$��40��$��0,0,10,0q��� $��DNA Fertility Center��$��Center=�$��24(�$
��Bold"�
��������� $��2��$ 
Horizontal=�.+��� -    ��Name$ 
txtWelcome��$��Welcome, User��$��Center=�$��14(�
�������$��0,0,15,0q��� -    ��Name$ 	btnLogout��$��Logout��$
��10,5q�
����������#2E86AB
�������� $��1�� �� $	��250 ��� $��* �.+��� $��0�����#F8F9FA���#DEE2E6$��0,0,1,0q�._��� .���� $��10q�.+��� $��	MAIN MENU��$
��Bold"�$��12(����#6C757D$��0,0,0,10q��� -   $ btnDashboard��$��📊 Dashboard��   MenuButtonStyle#��[  �� -   $ btnPatients��$��👥 Patients��#��[  �� -   $ 
btnDoctors��$��👨‍⚕️ Doctors��#��[  �� -   $ btnAppointments��$��📅 Appointments��#��[  �� -   $ btnTreatments��$��🏥 Treatments��#��[  �� -   $ btnServices��$��⚕️ Services��#��[  �� -	   $ 
btnRecords��$��📋 Medical Records��#��[  �� -
   $ 
btnReports��$��📈 Reports��#��[  �� -   $ btnBlog��$��📝 Blog Management��#��[  �� -   $ btnSettings��$��⚙️ Settings��#��[  �� -   $ btnUsers��$��
👤 Users��#��[  �� $��1��
�������$ 20q�._� � -   	  �Name$	 	MainFrame��
  � NavigationUIVisibility$
 Hidden=��� $��2�����#F8F9FA.@��� .���� -   $ 	txtStatus��$��Ready���� $��Right=�.��O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     -   $ txtDateTime������ 
 �� Now �� Source# Z  �� StringFormat$ dd/MM/yyyy HH:mm:ss��