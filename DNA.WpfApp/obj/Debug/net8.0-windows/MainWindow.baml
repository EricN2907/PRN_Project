   M S B A M L   `   `   `  ����  
DNA.WpfApp    DNA.WpfApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$/  )DNA Fertility Treatment Management System��5   	   $	��800��6;   $
��1200��6H    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�6!   .��5      �  � RowDefinitions 5      �� 5	      $��60 �6   �� 5
      $��* �6   �� 5      $��30 �6   .+�5      �� $��0��6   ���#2E86AB �� Padding$ 10q�6-   ._�5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6!   .+�5      �� $��Assets/dna_icon.png��6   $��40��6*   $��40��65   $��0,0,10,0q�6A   �� 5      $��DNA Fertility Center��6   $��Center=�6-   $��24(�6H   $
��Bold"�6V   
�������6h   5      �� 5      $��2��6   $ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ 
txtWelcome��5      $��Welcome, User��6%   $��Center=�6:   $��14(�6U   
�������$��0,0,15,0q�6v   �� 5      -   5         ��Name$ 	btnLogout��5      $��Logout��6!   $
��10,5q�6J   
����������#2E86AB
�������6�   5      5      5       � 5"      $��1��6	    5#      �� 5$      $	��250 �6   �� 5%      $��* �6   .+�5(      �� $��0��6   ���#F8F9FA���#DEE2E6$��0,0,1,0q�6G   ._�5)      �� .��5*      �� $��10q�6   .+�5+      �� $��	MAIN MENU��6   $
��Bold"�6#   $��12(�65   ���#6C757D$��0,0,0,10q�6X   �� 5-      -   5        $ btnDashboard��5-      $��📊 Dashboard��6%      MenuButtonStyle#��[  6W   �� 5.      -   5        $ btnPatients��5.      $��👥 Patients��6$   #��[  6T   �� 5/      -   5        $ 
btnDoctors��5/      $��👨‍⚕️ Doctors��6#   #��[  6T   �� 50      -   5        $ btnAppointments��50      $��📅 Appointments��6(   #��[  6`   �� 51      -   5        $ btnTreatments��51      $��🏥 Treatments��6&   #��[  6Z   �� 52      -   5        $ btnServices��52      $��⚕️ Services��6$   #��[  6T   �� 53      -	   5        $ 
btnRecords��53      $��📋 Medical Records��6#   #��[  6Y   �� 54      -
   5        $ 
btnReports��54      $��📈 Reports��6#   #��[  6Q   �� 55      -   5        $ btnBlog��55      $��📝 Blog Management��6    #��[  6S   �� 56      -   5        $ btnSettings��56      $��⚙️ Settings��6$   #��[  6T   �� 58      -   5        $ btnUsers��58      $��
👤 Users��6!   #��[  6K   59      5:      5;      �� 5=      $��1��6   
�������$ 20q�6/   ._�5>       � -   5        	  �Name$	 	MainFrame��5>      
  � NavigationUIVisibility$
 Hidden=�6   5?      5@      �� 5B      $��2��6   ���#F8F9FA.@�5C      �� .��5D      �� -   5        $ 	txtStatus��5D      $��Ready��6#   5E      �� 5F      $��Right=�6   .��5G      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6}   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6}   -   5        $ txtDateTime��5G      ��6%   �� 
 �� Now �� Source# Z  �� StringFormat$ dd/MM/yyyy HH:mm:ss��6}   5H      5I      5J      5K      