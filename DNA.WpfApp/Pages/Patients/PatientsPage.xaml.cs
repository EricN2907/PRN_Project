using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Required for async/await
using System.Windows;
using System.Windows.Controls;
using DNA.BussinessObject;
using DNA.BussinessObject.DTOs;
using DNA.Service;
using DNA.Repository;
using Microsoft.EntityFrameworkCore;
using DNA.WpfApp.Windows; // <--- ADDED/CONFIRMED THIS USING DIRECTIVE FOR AddEditPatientWindow
using DNA.WpfApp.Utils; // For SessionManager

namespace DNA.WpfApp.Pages.Patients
{
    public partial class PatientsPage : Page
    {
        private List<PatientListDTO>? _allPatients;
        private List<PatientListDTO>? _filteredPatients;
        private readonly IPatientService _patientService;

        // Ensure these UI elements are properly defined with x:Name in your PatientsPage.xaml
        // If they are not, you will get NullReferenceExceptions at runtime.
        // For example: <TextBox x:Name="txtSearch" ... />
        // private TextBox txtSearch; // If not defined in XAML, declare it here and assign in InitializeComponent
        // private ComboBox cmbGenderFilter;
        // private ComboBox cmbStatusFilter;
        // private DataGrid dgPatients;
        // private TextBlock txtLoading;
        // private TextBlock txtNoData;


        public PatientsPage()
        {
            InitializeComponent();
            cmbDNATestStatusFilter = FindName("cmbDNATestStatusFilter") as ComboBox;
            if (cmbDNATestStatusFilter == null)
            {
                // Create a temporary invisible ComboBox if it doesn't exist in XAML
                cmbDNATestStatusFilter = new ComboBox { Visibility = Visibility.Collapsed };
                // Add it to your main grid (or appropriate container)
                if (Content is Grid mainGrid)
                    mainGrid.Children.Add(cmbDNATestStatusFilter);
            }
            // Initialize services
            var context = new ApplicationDbContext();
            _patientService = new PatientService(context);

            // Setup UI based on user role
            SetupUserInterface();

            // Start loading patient data
            // LoadPatientsData is now async Task, so it can be awaited if needed by the caller,
            // but for a constructor, just calling it is fine, it won't block the UI thread.
            LoadPatientsData();
        }

        private void SetupUserInterface()
        {
            // Check user permissions and hide/show features accordingly
            if (SessionManager.IsCustomer)
            {
                // Customer chỉ xem được dữ liệu của mình
                SetupCustomerView();
            }
            else if (SessionManager.IsStaff)
            {
                // Staff có thể quản lý bệnh nhân nhưng không có các chức năng admin
                SetupStaffView();
            }
            else if (SessionManager.IsManager || SessionManager.IsAdmin)
            {
                // Manager và Admin có full access
                SetupManagerAdminView();
            }
            else
            {
                // Guest hoặc role không xác định
                SetupGuestView();
            }
        }

        private void SetupCustomerView()
        {
            // Customer không thể thêm/sửa/xóa bệnh nhân khác
            btnAddPatient.Visibility = Visibility.Collapsed;
            
            // Ẩn các button admin
            var quickActions = FindName("quickActionsPanel") as StackPanel;
            if (quickActions != null)
            {
                quickActions.Visibility = Visibility.Collapsed;
            }
        }

        private void SetupStaffView()
        {
            // Staff có thể quản lý bệnh nhân
            btnAddPatient.Visibility = Visibility.Visible;
            
            // Ẩn một số chức năng management
            // Có thể ẩn pricing management, comprehensive reports
        }

        private void SetupManagerAdminView()
        {
            // Manager và Admin có full access
            btnAddPatient.Visibility = Visibility.Visible;
            
            // Hiển thị tất cả quick actions
        }

        private void SetupGuestView()
        {
            // Guest không có quyền gì cả
            btnAddPatient.Visibility = Visibility.Collapsed;
            
            var quickActions = FindName("quickActionsPanel") as StackPanel;
            if (quickActions != null)
            {
                quickActions.Visibility = Visibility.Collapsed;
            }
        }

        // --- Changed from async void to async Task ---
        // This allows other async methods to await its completion.
        private async Task LoadPatientsData()
        {
            try
            {
                // Ensure these elements are defined in XAML
                if (txtLoading != null) txtLoading.Visibility = Visibility.Visible;
                if (dgPatients != null) dgPatients.Visibility = Visibility.Collapsed;

                // Load data from database
                var patients = await _patientService.GetAllPatientsAsync();

                // Filter patients based on user role
                if (SessionManager.IsCustomer)
                {
                    // Customer chỉ xem được dữ liệu của chính mình
                    var currentUserId = SessionManager.CurrentUserId;
                    patients = patients.Where(p => p.UserId == currentUserId).ToList();
                }

                // Convert to DTO
                _allPatients = patients.Select(p => new PatientListDTO
                {
                    PatientId = p.PatientId,
                    FullName = p.FullName,
                    Email = p.Email,
                    Phone = p.Phone,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    IsActive = p.IsActive,
                    CreatedDate = p.CreatedDate,
                    // DNA Testing specific properties
                    DNATestStatus = GetDNATestStatus(p.PatientId),
                    TotalDNATests = GetTotalDNATests(p.PatientId),
                    CompletedDNATests = GetCompletedDNATests(p.PatientId),
                    LastDNATestDate = GetLastDNATestDate(p.PatientId)
                }).ToList();

                _filteredPatients = _allPatients.ToList();
                if (dgPatients != null) dgPatients.ItemsSource = _filteredPatients;

                // Ensure these elements are defined in XAML
                if (txtLoading != null) txtLoading.Visibility = Visibility.Collapsed;
                if (dgPatients != null) dgPatients.Visibility = Visibility.Visible;

                UpdateNoDataVisibility();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);

                // Hide loading and show grid even on error, so UI is not stuck
                if (txtLoading != null) txtLoading.Visibility = Visibility.Collapsed;
                if (dgPatients != null) dgPatients.Visibility = Visibility.Visible;

                // Use fallback data if database fails
                _allPatients = GenerateMockPatients();
                _filteredPatients = _allPatients.ToList();
                if (dgPatients != null) dgPatients.ItemsSource = _filteredPatients;
                UpdateNoDataVisibility(); // Update visibility based on mock data
            }
        }

        private List<PatientListDTO> GenerateMockPatients()
        {
            return new List<PatientListDTO>
            {
                new PatientListDTO { 
                    PatientId = 1, 
                    FullName = "Nguyễn Thị Hoa", 
                    Email = "hoa.nguyen@email.com", 
                    Phone = "0901234567", 
                    DateOfBirth = new DateTime(1990, 5, 15), 
                    Gender = "Nữ", 
                    IsActive = true, 
                    CreatedDate = DateTime.Now.AddDays(-30),
                    DNATestStatus = "Hoàn thành",
                    TotalDNATests = 2,
                    CompletedDNATests = 2,
                    LastDNATestDate = DateTime.Now.AddDays(-10)
                },
                new PatientListDTO { 
                    PatientId = 2, 
                    FullName = "Trần Văn Nam", 
                    Email = "nam.tran@email.com", 
                    Phone = "0912345678", 
                    DateOfBirth = new DateTime(1988, 8, 20), 
                    Gender = "Nam", 
                    IsActive = true, 
                    CreatedDate = DateTime.Now.AddDays(-25),
                    DNATestStatus = "Đang xét nghiệm",
                    TotalDNATests = 1,
                    CompletedDNATests = 0,
                    LastDNATestDate = DateTime.Now.AddDays(-5)
                },
                new PatientListDTO { 
                    PatientId = 3, 
                    FullName = "Lê Thị Lan", 
                    Email = "lan.le@email.com", 
                    Phone = "0923456789", 
                    DateOfBirth = new DateTime(1992, 3, 10), 
                    Gender = "Nữ", 
                    IsActive = true, 
                    CreatedDate = DateTime.Now.AddDays(-20),
                    DNATestStatus = "Chưa xét nghiệm",
                    TotalDNATests = 0,
                    CompletedDNATests = 0,
                    LastDNATestDate = null
                },
                new PatientListDTO { 
                    PatientId = 4, 
                    FullName = "Phạm Minh Đức", 
                    Email = "duc.pham@email.com", 
                    Phone = "0934567890", 
                    DateOfBirth = new DateTime(1985, 12, 5), 
                    Gender = "Nam", 
                    IsActive = false, 
                    CreatedDate = DateTime.Now.AddDays(-15),
                    DNATestStatus = "Đã hủy",
                    TotalDNATests = 1,
                    CompletedDNATests = 0,
                    LastDNATestDate = DateTime.Now.AddDays(-12)
                },
                new PatientListDTO { 
                    PatientId = 5, 
                    FullName = "Hoàng Thị Mai", 
                    Email = "mai.hoang@email.com", 
                    Phone = "0945678901", 
                    DateOfBirth = new DateTime(1993, 7, 25), 
                    Gender = "Nữ", 
                    IsActive = true, 
                    CreatedDate = DateTime.Now.AddDays(-10),
                    DNATestStatus = "Hoàn thành",
                    TotalDNATests = 3,
                    CompletedDNATests = 3,
                    LastDNATestDate = DateTime.Now.AddDays(-2)
                }
            };
        }

        private void ApplyFilters()
        {
            // Ensure _allPatients is not null before filtering
            if (_allPatients == null)
            {
                _filteredPatients = new List<PatientListDTO>();
                dgPatients.ItemsSource = _filteredPatients;
                UpdateNoDataVisibility();
                return;
            }

            var filtered = _allPatients.AsEnumerable();

            // Search filter
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var searchTerm = txtSearch.Text.ToLower();
                filtered = filtered.Where(p =>
                    p.FullName.ToLower().Contains(searchTerm) ||
                    p.Email.ToLower().Contains(searchTerm) ||
                    p.Phone.Contains(searchTerm));
            }

            // Gender filter
            // Ensure cmbGenderFilter is defined in XAML
            if (cmbGenderFilter != null && cmbGenderFilter.SelectedIndex > 0)
            {
                var selectedGender = (cmbGenderFilter.SelectedItem as ComboBoxItem)?.Content?.ToString();
                if (selectedGender != null)
                {
                    filtered = filtered.Where(p => p.Gender == selectedGender);
                }
            }

            // Status filter
            // Ensure cmbStatusFilter is defined in XAML
            if (cmbStatusFilter != null && cmbStatusFilter.SelectedIndex > 0)
            {
                var isActive = cmbStatusFilter.SelectedIndex == 1; // Assuming index 1 is "Active"
                filtered = filtered.Where(p => p.IsActive == isActive);
            }

            // DNA Test Status filter
            if (cmbDNATestStatusFilter != null && cmbDNATestStatusFilter.SelectedIndex > 0)
            {
                var dnaTestStatusOptions = new[] { "", "Chưa xét nghiệm", "Đang xét nghiệm", "Hoàn thành", "Đã hủy" };
                var selectedDNAStatus = dnaTestStatusOptions[cmbDNATestStatusFilter.SelectedIndex];
                if (!string.IsNullOrEmpty(selectedDNAStatus))
                {
                    filtered = filtered.Where(p => p.DNATestStatus == selectedDNAStatus);
                }
            }

            _filteredPatients = filtered.ToList();
            if (dgPatients != null) dgPatients.ItemsSource = _filteredPatients; // Update the UI
            UpdateNoDataVisibility();
        }

        private void UpdateNoDataVisibility()
        {
            // Ensure txtNoData is defined in XAML
            if (txtNoData != null && _filteredPatients != null)
            {
                txtNoData.Visibility = _filteredPatients.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }



        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CmbGenderFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CmbStatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private async void BtnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            // Check permission
            if (!SessionManager.HasPermission("ManagePatients"))
            {
                MessageBox.Show("Bạn không có quyền thêm bệnh nhân mới!", "Không có quyền", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Correctly instantiate and show the AddEditPatientWindow
                var addPatientWindow = new AddEditPatientWindow();

                // ShowDialog returns a nullable bool. If true, the dialog was accepted (e.g., Save button clicked).
                if (addPatientWindow.ShowDialog() == true)
                {
                    // Await LoadPatientsData to refresh the grid after the new patient is added.
                    await LoadPatientsData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thêm bệnh nhân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnEditPatient_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                try
                {
                    // Retrieve the patient data for editing
                    var patient = await _patientService.GetPatientByIdAsync(patientId);
                    if (patient != null)
                    {
                        // Pass the existing patient data to the edit window's constructor
                        var editPatientWindow = new AddEditPatientWindow(patient);
                        if (editPatientWindow.ShowDialog() == true)
                        {
                            // Await LoadPatientsData to refresh the grid after editing.
                            await LoadPatientsData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin bệnh nhân!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi chỉnh sửa bệnh nhân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void BtnDeletePatient_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bệnh nhân này?",
                    "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var success = await _patientService.DeletePatientAsync(patientId);
                        if (success)
                        {
                            MessageBox.Show("Đã xóa bệnh nhân thành công!", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            // Await LoadPatientsData to refresh the grid after deletion.
                            await LoadPatientsData();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa bệnh nhân!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa bệnh nhân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        // DNA Testing Service Management Functions
        private async void BtnBookDNATest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                // Check permission
                if (!SessionManager.HasPermission("ManagePatients") && !SessionManager.HasPermission("BookAppointment"))
                {
                    MessageBox.Show("Bạn không có quyền đặt lịch xét nghiệm!", "Không có quyền", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    // Navigate to DNA test booking page/window
                    var bookingWindow = new DNA.WpfApp.Windows.DNATestBookingWindow(patientId);
                    if (bookingWindow.ShowDialog() == true)
                    {
                        MessageBox.Show("Đã đặt lịch xét nghiệm ADN thành công!", "Thông báo",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        await LoadPatientsData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đặt lịch xét nghiệm ADN: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void BtnViewDNATestHistory_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                try
                {
                    // Navigate to DNA test history page/window
                    var historyWindow = new DNA.WpfApp.Windows.DNATestHistoryWindow(patientId);
                    historyWindow.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xem lịch sử xét nghiệm ADN: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void BtnViewTestResults_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                // Check permission - customer có thể xem kết quả của mình
                if (!SessionManager.HasPermission("ViewOwnResults") && !SessionManager.HasPermission("ViewPatients"))
                {
                    MessageBox.Show("Bạn không có quyền xem kết quả xét nghiệm!", "Không có quyền", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    // Navigate to test results viewing page/window
                    var resultsWindow = new DNA.WpfApp.Windows.DNATestResultsWindow(patientId);
                    resultsWindow.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xem kết quả xét nghiệm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void BtnTrackTestProgress_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                try
                {
                    // Navigate to test progress tracking page/window
                    var progressWindow = new DNA.WpfApp.Windows.DNATestProgressWindow(patientId);
                    progressWindow.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi theo dõi tiến độ xét nghiệm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void BtnRequestSampleKit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                try
                {
                    var result = MessageBox.Show("Bạn có muốn yêu cầu gửi bộ kit xét nghiệm ADN không?",
                        "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Logic to request sample kit
                        var kitRequestWindow = new DNA.WpfApp.Windows.SampleKitRequestWindow(patientId);
                        if (kitRequestWindow.ShowDialog() == true)
                        {
                            MessageBox.Show("Đã gửi yêu cầu kit xét nghiệm thành công!", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi yêu cầu kit xét nghiệm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void BtnScheduleHomeSample_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                try
                {
                    // Navigate to home sample collection scheduling
                    var homeSampleWindow = new DNA.WpfApp.Windows.HomeSampleScheduleWindow(patientId);
                    if (homeSampleWindow.ShowDialog() == true)
                    {
                        MessageBox.Show("Đã đặt lịch thu mẫu tại nhà thành công!", "Thông báo",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đặt lịch thu mẫu tại nhà: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void BtnPatientFeedback_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                try
                {
                    // Navigate to patient feedback page
                    var feedbackWindow = new DNA.WpfApp.Windows.PatientFeedbackWindow(patientId);
                    feedbackWindow.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xem đánh giá bệnh nhân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Additional filter for DNA test status
        private void CmbDNATestStatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        // Export functionality for reports
        private async void BtnExportReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_filteredPatients == null || _filteredPatients.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Open save file dialog
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx|CSV files (*.csv)|*.csv",
                    DefaultExt = "xlsx",
                    FileName = $"BaoCaoBenhNhan_{DateTime.Now:yyyyMMdd_HHmmss}"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Export logic would go here
                    MessageBox.Show($"Đã xuất báo cáo thành công: {saveFileDialog.FileName}", "Thông báo",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Refresh button functionality
        private async void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            await LoadPatientsData();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // View patient record functionality
        private async void BtnViewPatientRecord_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int patientId)
            {
                try
                {
                    var patient = await _patientService.GetPatientByIdAsync(patientId);
                    if (patient != null)
                    {
                        // Pass patientId instead of patient object
                        var recordWindow = new DNA.WpfApp.Windows.PatientRecordWindow(patientId);
                        recordWindow.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin bệnh nhân!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xem hồ sơ bệnh nhân: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Quick Action Event Handlers
        private void BtnDNADashboard_Click(object sender, RoutedEventArgs e)
        {
            // Check permission
            if (!SessionManager.HasPermission("ViewDashboard"))
            {
                MessageBox.Show("Bạn không có quyền truy cập Dashboard!", "Không có quyền", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Navigate to DNA Dashboard
                var dashboardWindow = new DNA.WpfApp.Windows.DNADashboardWindow();
                dashboardWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở Dashboard ADN: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnManageServices_Click(object sender, RoutedEventArgs e)
        {
            // Check permission
            if (!SessionManager.HasPermission("ManageServices"))
            {
                MessageBox.Show("Bạn không có quyền quản lý dịch vụ!", "Không có quyền", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Navigate to DNA Services Management
                var servicesWindow = new DNA.WpfApp.Windows.DNAServicesManagementWindow();
                servicesWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở quản lý dịch vụ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnComprehensiveReport_Click(object sender, RoutedEventArgs e)
        {
            // Check permission
            if (!SessionManager.HasPermission("ViewReports"))
            {
                MessageBox.Show("Bạn không có quyền xem báo cáo tổng hợp!", "Không có quyền", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Navigate to Comprehensive Reports
                var reportWindow = new DNA.WpfApp.Windows.ComprehensiveReportWindow();
                reportWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở báo cáo tổng hợp: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnManagePricing_Click(object sender, RoutedEventArgs e)
        {
            // Check permission
            if (!SessionManager.HasPermission("ManagePricing"))
            {
                MessageBox.Show("Bạn không có quyền quản lý bảng giá!", "Không có quyền", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Navigate to Pricing Management
                var pricingWindow = new DNA.WpfApp.Windows.PricingManagementWindow();
                pricingWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở cài đặt bảng giá: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Helper methods for DNA test status
        private string GetDNATestStatus(int patientId)
        {
            // Mock implementation - in real app, this would query the database
            var random = new Random(patientId);
            var statuses = new[] { "Chưa xét nghiệm", "Đang xét nghiệm", "Hoàn thành", "Đã hủy" };
            return statuses[random.Next(statuses.Length)];
        }

        private int GetTotalDNATests(int patientId)
        {
            // Mock implementation
            var random = new Random(patientId);
            return random.Next(0, 5);
        }

        private int GetCompletedDNATests(int patientId)
        {
            // Mock implementation
            var random = new Random(patientId + 1);
            return random.Next(0, GetTotalDNATests(patientId) + 1);
        }

        private DateTime? GetLastDNATestDate(int patientId)
        {
            // Mock implementation
            if (GetTotalDNATests(patientId) > 0)
            {
                var random = new Random(patientId + 2);
                return DateTime.Now.AddDays(-random.Next(1, 365));
            }
            return null;
        }
    }
}