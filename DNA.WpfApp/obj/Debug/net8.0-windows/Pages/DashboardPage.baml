   M S B A M L   `   `   `  ����  
DNA.WpfApp$    DNA.WpfApp.Pages.DashboardPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  	Dashboard��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� $��0��6   $��	Dashboard��6!   $��28(�62   $
��Bold"�6@   $��0,0,0,20q�6R   � 5   
   $��1��6   $��0,0,0,20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   ���#E3F2FD �� Padding$ 20q�6:   $��0,0,10,0q�6G    �� CornerRadius$ 5��6Y   ._�5      �� .+�5      �� $
��📊��6    $��30(�6*   $��Center=�68   �� 5      -   5         ��Name$ txtTotalPatients��5       $��0��6:   $��36(�6C   $
��Bold"�6Q   $��Center=�6c   ���#1976D26�   �� 5      $��Total Patients��6    $��14(�66   $��Center=�6D   ���#6666a   5      5       �� 5#      $��1��6   ���#E8F5E8$ 20q�6:   $	��5,0q�6G   $ 5��6T   ._�5$      �� .+�5%      �� $
��🏥��6    $��30(�6*   $��Center=�68   �� 5&      -   5        $ txtActiveTreatments��5&       $��0��6=   $��36(�6F   $
��Bold"�6T   $��Center=�6f   ���#388E3C6�   �� 5'      $��Active Treatments��6    $��14(�69   $��Center=�6G   ���#6666d   5(      5)      �� 5,      $��2��6   ���#FFF3E0$ 20q�6:   $	��5,0q�6G   $ 5��6T   ._�5-      �� .+�5.      �� $
��📅��6    $��30(�6*   $��Center=�68   �� 5/      -   5        $ txtTodayAppointments��5/       $��0��6>   $��36(�6G   $
��Bold"�6U   $��Center=�6g   ���#F57C006�   �� 50      $��Today's Appointments��6    $��14(�6<   $��Center=�6J   ���#6666g   51      52      �� 55      $��3��6   ���#FCE4EC$ 20q�6:   $��10,0,0,0q�6G   $ 5��6Y   ._�56      �� .+�57      �� $��👨‍⚕️��6    $��30(�6-   $��Center=�6;   �� 58      -   5        $ txtAvailableDoctors��58       $��0��6=   $��36(�6F   $
��Bold"�6T   $��Center=�6f   ���#C2185B6�   �� 59      $��Available Doctors��6    $��14(�69   $��Center=�6G   ���#6666d   5:      5;      5<      � 5?   
   $��2��6    5@      �� 5A      $��2* �6#   �� 5B      $��* �6#   .+�5F      �� $��0��6   
����������#E0E0E0$��1q�6N   $ 15q�6b   $��0,0,10,0q�6o   $ 5��6�   ._�5G      �� .+�5H      �� $��Recent Activities��6    $��18(�69   $
��Bold"�6G   $��0,0,0,15q�6Y   �� 5I      -   5         ��Name$ lvRecentActivities��5I      $	��300��6;    �� View 5J      �� 5K      .P�5L   "   �� $
��Time��61    �� Width$	 100��6?   	 �� DisplayMemberBinding	 6K   �� *Time+�� 5M   "   $��Activity��61   $	 200��6C   	 6O   �� *
Activity+�� 5N   "   $��Patient��61   $	 150��6B   	 6N   �� *	Patient+�� 5O   "   $��Status��61   $	 100��6A   	 6M   �� *Status+5P      5R      5S      5T      �� 5W      $��1��6   
����������#E0E0E0$��1q�6N   $ 15q�6b   $��10,0,0,0q�6o   $ 5��6�   ._�5X      �� .+�5Y      �� $��Quick Actions��6    $��18(�65   $
��Bold"�6C   $��0,0,0,15q�6U   �� 5[      $��➕ New Patient��6   $��10q�65   $	��0,5q�6B   ���#2196F3
�������$��0q�6w   �� 5\      $��📅 Schedule Appointment��6   $��10q�6?   $	��0,5q�6L   ���#4CAF50
�������$��0q�6�   �� 5]      $��🏥 New Treatment��6   $��10q�68   $	��0,5q�6E   ���#FF9800
�������$��0q�6z   �� 5^      $��📋 View Records��6   $��10q�67   $	��0,5q�6D   ���#9C27B0
�������$��0q�6y   �� 5_      $��📊 Generate Report��6   $��10q�6:   $	��0,5q�6G   ���#607D8B
�������$��0q�6|   �� 5a      $
��0,20q�6    �� 5c      $��Upcoming Appointments��6    $��14(�6=   $
��Bold"�6K   $��0,0,0,10q�6]   �� 5d      -   5        $ lvUpcomingAppointments��5d      $	��150��6?   ��5e      �� 5f      .R�5g   "   �� .+�5h   &   �� $
��Bold"�6F   ��60   �� *Time+6F   �� 5i   &   $��12(�6M   ��60   �� *PatientName+6M   �� 5j   &   $��12(�6L   
���������60   �� *
DoctorName+6Z   5k   #   5l      5n      5o      5p      5q      5r      5s      