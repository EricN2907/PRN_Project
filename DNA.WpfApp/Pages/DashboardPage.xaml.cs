using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using DNA.BussinessObject;
using DNA.WpfApp.Utils;

namespace DNA.WpfApp.Pages
{
    public partial class DashboardPage : Page
    {
        private User _currentUser;

        public DashboardPage(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            SessionManager.SetCurrentUser(currentUser); // Ensure session is set
            LoadDashboardData();
        }

        public DashboardPage() // Parameterless constructor for navigation
        {
            InitializeComponent();
            _currentUser = SessionManager.CurrentUser ?? new User { FullName = "Guest", UserType = "Guest" };
            LoadDashboardData();
        }

        private async void LoadDashboardData()
        {
            try
            {
                // Set welcome message based on user role
                if (SessionManager.CurrentUser != null)
                {
                    // Assuming you have a welcome text block in XAML
                    // txtWelcome.Text = $"Chào mừng, {SessionManager.CurrentUserName}";
                    // txtUserRole.Text = $"Vai trò: {GetRoleDisplayName(SessionManager.CurrentUserRole)}";
                }

                // Load content based on user role
                if (SessionManager.IsCustomer)
                {
                    LoadCustomerDashboard();
                }
                else if (SessionManager.IsStaff)
                {
                    LoadStaffDashboard();
                }
                else if (SessionManager.IsManager || SessionManager.IsAdmin)
                {
                    LoadManagerAdminDashboard();
                }
                else
                {
                    LoadGuestDashboard();
                }
                
                // Add an await operation to make this method truly asynchronous
                await System.Threading.Tasks.Task.CompletedTask;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error loading dashboard data: {ex.Message}");
            }
        }

        private string GetRoleDisplayName(string? role)
        {
            return role switch
            {
                "Admin" => "Quản trị viên",
                "Manager" => "Quản lý",
                "Staff" => "Nhân viên",
                "Customer" => "Khách hàng",
                _ => "Khách"
            };
        }

        private void LoadCustomerDashboard()
        {
            // Customer sees only their personal data
            try
            {
                txtTotalPatients.Text = "1"; // Customer only sees themselves
                txtActiveTreatments.Text = "2"; // Their active treatments
                txtTodayAppointments.Text = "1"; // Their appointments today
                txtAvailableDoctors.Text = "N/A"; // Not relevant for customers

                // Load customer's activities
                var customerActivities = new List<dynamic>
                {
                    new { Time = "10:30", Activity = "Xét nghiệm ADN hoàn thành", Patient = SessionManager.CurrentUserName, Status = "Hoàn thành" },
                    new { Time = "14:00", Activity = "Kết quả đã sẵn sàng", Patient = SessionManager.CurrentUserName, Status = "Sẵn sàng" }
                };
                lvRecentActivities.ItemsSource = customerActivities;

                // Load customer's appointments
                var customerAppointments = new List<dynamic>
                {
                    new { Time = "09:00", PatientName = SessionManager.CurrentUserName, DoctorName = "BS. Phạm Minh Tuấn" }
                };
                lvUpcomingAppointments.ItemsSource = customerAppointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dashboard khách hàng: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadStaffDashboard()
        {
            // Staff sees their work assignments
            try
            {
                txtTotalPatients.Text = "25"; // Patients assigned to this staff
                txtActiveTreatments.Text = "8"; // Active treatments they're handling
                txtTodayAppointments.Text = "5"; // Appointments for today
                txtAvailableDoctors.Text = "3"; // Doctors they work with

                // Load staff activities
                var staffActivities = new List<dynamic>
                {
                    new { Time = "08:30", Activity = "Thu mẫu xét nghiệm", Patient = "Nguyễn Thị Hoa", Status = "Hoàn thành" },
                    new { Time = "10:15", Activity = "Xử lý mẫu ADN", Patient = "Trần Văn Nam", Status = "Đang xử lý" },
                    new { Time = "14:00", Activity = "Gọi thông báo kết quả", Patient = "Lê Thị Lan", Status = "Cần thực hiện" }
                };
                lvRecentActivities.ItemsSource = staffActivities;

                // Load staff appointments
                var staffAppointments = new List<dynamic>
                {
                    new { Time = "09:00", PatientName = "Phạm Minh Đức", DoctorName = "BS. Phạm Minh Tuấn" },
                    new { Time = "11:00", PatientName = "Hoàng Thị Mai", DoctorName = "BS. Phạm Minh Tuấn" }
                };
                lvUpcomingAppointments.ItemsSource = staffAppointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dashboard nhân viên: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadManagerAdminDashboard()
        {
            // Manager/Admin sees full statistics
            try
            {
                txtTotalPatients.Text = "567"; // All patients
                txtActiveTreatments.Text = "123"; // All active treatments
                txtTodayAppointments.Text = "28"; // All appointments today
                txtAvailableDoctors.Text = "5"; // All doctors

                // Load management activities
                var managementActivities = new List<dynamic>
                {
                    new { Time = "08:00", Activity = "Hệ thống backup hoàn tất", Patient = "System", Status = "Hoàn thành" },
                    new { Time = "09:30", Activity = "Báo cáo doanh thu tuần", Patient = "Report", Status = "Đã tạo" },
                    new { Time = "11:15", Activity = "Xét nghiệm ADN #1234", Patient = "Nguyễn Văn A", Status = "Hoàn thành" },
                    new { Time = "14:00", Activity = "Đăng ký dịch vụ mới", Patient = "Trần Thị B", Status = "Đã xử lý" }
                };
                lvRecentActivities.ItemsSource = managementActivities;

                // Load all appointments
                var allAppointments = new List<dynamic>
                {
                    new { Time = "08:00", PatientName = "Nguyễn Thị Hoa", DoctorName = "BS. Phạm Minh Tuấn" },
                    new { Time = "09:30", PatientName = "Trần Văn Nam", DoctorName = "BS. Phạm Minh Tuấn" },
                    new { Time = "11:00", PatientName = "Lê Thị Lan", DoctorName = "BS. Phạm Minh Tuấn" },
                    new { Time = "14:00", PatientName = "Phạm Minh Đức", DoctorName = "BS. Phạm Minh Tuấn" }
                };
                lvUpcomingAppointments.ItemsSource = allAppointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dashboard quản lý: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadGuestDashboard()
        {
            // Guest sees limited public information
            try
            {
                txtTotalPatients.Text = "---";
                txtActiveTreatments.Text = "---";
                txtTodayAppointments.Text = "---";
                txtAvailableDoctors.Text = "5"; // Public info

                // Load public activities
                var publicActivities = new List<dynamic>
                {
                    new { Time = "---", Activity = "Vui lòng đăng nhập để xem thông tin", Patient = "---", Status = "---" }
                };
                lvRecentActivities.ItemsSource = publicActivities;

                // No appointments for guests
                var noAppointments = new List<dynamic>
                {
                    new { Time = "---", PatientName = "Vui lòng đăng nhập", DoctorName = "---" }
                };
                lvUpcomingAppointments.ItemsSource = noAppointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dashboard khách: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
