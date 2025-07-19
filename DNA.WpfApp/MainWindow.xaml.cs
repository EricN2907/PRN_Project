using System;
using System.Windows;
using System.Windows.Threading;
using DNA.BussinessObject;
using DNA.WpfApp.Utils;
using DNA.WpfApp.Pages;

namespace DNA.WpfApp
{
    public partial class MainWindow : Window
    {
        private User _currentUser;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _currentUser = SessionManager.CurrentUser;
            
            if (_currentUser == null)
            {
                MessageBox.Show("Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại.", "Lỗi", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                var homePage = new HomePage();
                homePage.Show();
                this.Close();
                return;
            }
            
            InitializeWindow();
        }

        // Keep the old constructor for backward compatibility
        public MainWindow(User user) : this()
        {
            _currentUser = user;
            SessionManager.SetCurrentUser(user);
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            txtWelcome.Text = $"Xin chào, {_currentUser.FullName}";
            
            // Setup role-based UI
            SetupRoleBasedUI();
            
            // Setup timer for status bar
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
            
            // Load dashboard by default
            LoadDashboard();
        }

        private void SetupRoleBasedUI()
        {
            // Show/hide menu items based on user role
            if (SessionManager.IsAdmin)
            {
                // Admin has access to everything
                // All buttons are visible by default
            }
            else if (SessionManager.IsManager)
            {
                // Manager has most access except some admin-only features
                // Hide admin-only features if any
            }
            else if (SessionManager.IsStaff)
            {
                // Staff has limited access
                // Hide management features
                if (btnReports != null) btnReports.Visibility = Visibility.Collapsed;
                if (btnUsers != null) btnUsers.Visibility = Visibility.Collapsed;
            }
            
            // Update title based on role
            this.Title = $"DNA Testing Management System - {SessionManager.CurrentUserRole}";
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            txtDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                _timer?.Stop();
                SessionManager.ClearSession();
                
                // Return to HomePage (public website)
                var homePage = new HomePage();
                homePage.Show();
                this.Close();
            }
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            LoadDashboard();
        }

        private void BtnPatients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Patients.PatientsPage());
            txtStatus.Text = "Patients management loaded";
        }

        private void BtnDoctors_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.Doctors.DoctorsPage());
            txtStatus.Text = "Doctors management loaded";
        }

        private void BtnAppointments_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.Appointments.AppointmentsPage());
            txtStatus.Text = "Appointments management loaded";
        }

        private void BtnTreatments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Treatments.TreatmentProgressPage());
            txtStatus.Text = "Treatments management loaded";
        }

        private void BtnServices_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.TreatmentServicesPage());
            txtStatus.Text = "Services management loaded";
        }

        private void BtnRecords_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.MedicalRecordsPage());
            txtStatus.Text = "Medical records loaded";
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.ReportsPage());
            txtStatus.Text = "Reports loaded";
        }

        private void BtnBlog_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.BlogPage());
            txtStatus.Text = "Blog management loaded";
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.SettingsPage());
            txtStatus.Text = "Settings loaded";
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.HomePage());
            txtStatus.Text = "Home page loaded";
        }

        private void BtnTreatmentRegistration_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Treatments.TreatmentRegistrationPage());
            txtStatus.Text = "Treatment registration loaded";
        }

        private void BtnMedication_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.MedicationSchedulePage());
            txtStatus.Text = "Medication schedule loaded";
        }

        private void BtnRatings_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.RatingsPage());
            txtStatus.Text = "Ratings and feedback loaded";
        }

        private void BtnNotifications_Click(object sender, RoutedEventArgs e)
        {
            // MainFrame.Navigate(new Pages.NotificationsPage());
            txtStatus.Text = "Notifications loaded";
        }

        private void LoadDashboard()
        {
            MainFrame.Navigate(new Pages.DashboardPage(_currentUser));
            txtStatus.Text = "Dashboard loaded";
        }
    }
}
