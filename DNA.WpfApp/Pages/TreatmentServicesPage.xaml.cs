using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DNA.BussinessObject; // Assuming TreatmentService is in this namespace
using DNA.Service;         // Assuming ITreatmentService is here
using DNA.Repository;      // Assuming ApplicationDbContext and TreatmentServiceImpl are here
using Microsoft.EntityFrameworkCore; // Added for ApplicationDbContext
using DNA.WpfApp.Utils; // For SessionManager

namespace DNA.WpfApp.Pages
{
    public partial class TreatmentServicesPage : Page
    {
        private List<TreatmentService> _allServices = new List<TreatmentService>();
        private List<TreatmentService> _filteredServices = new List<TreatmentService>();
        private readonly ITreatmentService _treatmentService;

        // XAML elements that need to be declared as fields if they are not correctly referenced in the XAML.
        // If these are defined in your XAML (e.g., <TextBox x:Name="txtSearch" ... />), you don't need to declare them here.
        // Assuming they are correctly defined in XAML, these lines are commented out.
        // private TextBox txtSearch;
        // private ComboBox cmbTreatmentTypeFilter;
        // private ComboBox cmbStatusFilter;
        // private TextBlock txtNoData;
        // private DataGrid dgServices; // Assuming this is your DataGrid for services
        // private TextBlock txtLoading; // Assuming you have a loading text block in XAML

        public TreatmentServicesPage()
        {
            InitializeComponent();

            // Initialize services
            var context = new ApplicationDbContext();
            _treatmentService = new TreatmentServiceImpl(context);

            // Setup UI based on user role
            SetupUserInterface();

            // Load data when the page is initialized
            LoadServicesData();
        }

        private void SetupUserInterface()
        {
            // Check user permissions and adjust UI accordingly
            if (SessionManager.IsCustomer)
            {
                // Customer can only view services, not manage them
                SetupCustomerView();
            }
            else if (SessionManager.IsStaff)
            {
                // Staff can view services but limited management
                SetupStaffView();
            }
            else if (SessionManager.IsManager || SessionManager.IsAdmin)
            {
                // Manager and Admin have full access
                SetupManagerAdminView();
            }
            else
            {
                // Guest has very limited access
                SetupGuestView();
            }
        }

        private void SetupCustomerView()
        {
            // Hide management buttons if they exist
            // Customer can only view services to book
            // You would hide add/edit/delete buttons here if they exist in XAML
        }

        private void SetupStaffView()
        {
            // Staff can view all services but may not add/edit/delete
        }

        private void SetupManagerAdminView()
        {
            // Full access to all features
        }

        private void SetupGuestView()
        {
            // Very limited view - maybe just public service information
        }

        // Changed to async Task to allow awaiting this method.
        // This is a best practice for methods performing async operations that others might want to await.
        private async Task LoadServicesData()
        {
            try
            {
                // Show loading indicator
                // Ensure txtLoading and dgServices are defined in your XAML with x:Name
                if (txtLoading != null) txtLoading.Visibility = Visibility.Visible;
                if (dgServices != null) dgServices.Visibility = Visibility.Collapsed;

                // Load data from database
                var services = await _treatmentService.GetAllServicesAsync();
                _allServices = services.ToList();
                _filteredServices = _allServices.ToList();

                // Update UI on the main thread
                dgServices.ItemsSource = _filteredServices;

                // Hide loading indicator
                if (txtLoading != null) txtLoading.Visibility = Visibility.Collapsed;
                if (dgServices != null) dgServices.Visibility = Visibility.Visible;

                UpdateNoDataVisibility();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                // Hide loading indicator even on error
                if (txtLoading != null) txtLoading.Visibility = Visibility.Collapsed;

                // Use fallback data if database fails
                _allServices = GenerateMockServices();
                _filteredServices = _allServices.ToList();
                dgServices.ItemsSource = _filteredServices;
                UpdateNoDataVisibility(); // Update visibility based on mock data
            }
        }

        private List<TreatmentService> GenerateMockServices()
        {
            return new List<TreatmentService>
            {
                new TreatmentService
                {
                    ServiceId = 1,
                    ServiceCode = "IUI001",
                    ServiceName = "Thụ tinh trong tử cung cơ bản",
                    TreatmentType = "IUI",
                    Price = 15000000,
                    DurationDays = 14,
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddDays(-60),
                    Description = "Quy trình IUI cơ bản với theo dõi chuyên khoa"
                },
                new TreatmentService
                {
                    ServiceId = 2,
                    ServiceCode = "IVF001",
                    ServiceName = "Thụ tinh trong ống nghiệm thế hệ 1",
                    TreatmentType = "IVF",
                    Price = 85000000,
                    DurationDays = 21,
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddDays(-45),
                    Description = "IVF thế hệ 1 với công nghệ tiên tiến"
                },
                new TreatmentService
                {
                    ServiceId = 3,
                    ServiceCode = "ICSI001",
                    ServiceName = "Tiêm tinh trùng vào bào tương trứng",
                    TreatmentType = "ICSI",
                    Price = 95000000,
                    DurationDays = 21,
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddDays(-30),
                    Description = "ICSI cho các trường hợp tinh trùng yếu"
                },
                new TreatmentService
                {
                    ServiceId = 4,
                    ServiceCode = "IVF002",
                    ServiceName = "IVF với chẩn đoán di truyền",
                    TreatmentType = "IVF",
                    Price = 120000000,
                    DurationDays = 28,
                    IsActive = true,
                    CreatedDate = DateTime.Now.AddDays(-15),
                    Description = "IVF kết hợp với PGD/PGS"
                },
                new TreatmentService
                {
                    ServiceId = 5,
                    ServiceCode = "CON001",
                    ServiceName = "Tư vấn dinh dưỡng sinh sản",
                    TreatmentType = "Khác",
                    Price = 500000,
                    DurationDays = 1,
                    IsActive = false,
                    CreatedDate = DateTime.Now.AddDays(-90),
                    Description = "Tư vấn dinh dưỡng trước điều trị"
                }
            };
        }

        private void ApplyFilters()
        {
            // Ensure _allServices is not null before filtering
            if (_allServices == null)
            {
                _filteredServices = new List<TreatmentService>(); // Or handle as appropriate
                dgServices.ItemsSource = _filteredServices;
                UpdateNoDataVisibility();
                return;
            }

            var filtered = _allServices.AsEnumerable();

            // Search filter
            // Ensure txtSearch is correctly named in XAML
            if (txtSearch != null && !string.IsNullOrEmpty(txtSearch.Text))
            {
                var searchTerm = txtSearch.Text.ToLower();
                filtered = filtered.Where(s =>
                    s.ServiceName.ToLower().Contains(searchTerm) ||
                    s.ServiceCode.ToLower().Contains(searchTerm) ||
                    (s.Description != null && s.Description.ToLower().Contains(searchTerm))); // Null check for Description
            }

            // Treatment Type filter
            // Ensure cmbTreatmentTypeFilter is correctly named in XAML
            if (cmbTreatmentTypeFilter != null && cmbTreatmentTypeFilter.SelectedIndex > 0)
            {
                var selectedItem = cmbTreatmentTypeFilter.SelectedItem as ComboBoxItem;
                if (selectedItem != null)
                {
                    var selectedType = selectedItem.Content.ToString();
                    filtered = filtered.Where(s => s.TreatmentType == selectedType);
                }
            }

            // Status filter
            // Ensure cmbStatusFilter is correctly named in XAML
            if (cmbStatusFilter != null && cmbStatusFilter.SelectedIndex > 0)
            {
                var isActive = cmbStatusFilter.SelectedIndex == 1; // Assuming index 1 is "Active"
                filtered = filtered.Where(s => s.IsActive == isActive);
            }

            _filteredServices = filtered.ToList();
            dgServices.ItemsSource = _filteredServices; // Update UI
            UpdateNoDataVisibility();
        }

        private void UpdateNoDataVisibility()
        {
            // Ensure txtNoData is correctly named in XAML
            if (txtNoData != null && _filteredServices != null)
            {
                txtNoData.Visibility = _filteredServices.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        // Event Handlers
        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng thêm dịch vụ mới sẽ được triển khai.", "Thông báo");
            // Here you would typically open an AddEditServiceWindow similar to how you handled patients.
            // For example:
            // var addEditServiceWindow = new AddEditServiceWindow();
            // if (addEditServiceWindow.ShowDialog() == true)
            // {
            //     await LoadServicesData(); // Refresh data after adding
            // }
        }

        private void BtnViewService_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int serviceId)
            {
                MessageBox.Show($"Xem chi tiết dịch vụ ID: {serviceId}", "Thông báo");
            }
        }

        private void BtnEditService_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int serviceId)
            {
                MessageBox.Show($"Chỉnh sửa dịch vụ ID: {serviceId}", "Thông báo");
                // Here you would typically open an AddEditServiceWindow with the service data.
                // For example:
                // var serviceToEdit = _allServices.FirstOrDefault(s => s.ServiceId == serviceId);
                // if (serviceToEdit != null)
                // {
                //     var addEditServiceWindow = new AddEditServiceWindow(serviceToEdit);
                //     if (addEditServiceWindow.ShowDialog() == true)
                //     {
                //         await LoadServicesData(); // Refresh data after editing
                //     }
                // }
            }
        }

        private void BtnTreatmentSteps_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int serviceId)
            {
                MessageBox.Show($"Quản lý quy trình điều trị cho dịch vụ ID: {serviceId}", "Thông báo");
            }
        }

        private void BtnPricing_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int serviceId)
            {
                MessageBox.Show($"Quản lý bảng giá cho dịch vụ ID: {serviceId}", "Thông báo");
            }
        }

        private async void BtnDeactivateService_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int serviceId)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn vô hiệu hóa dịch vụ này?",
                    "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Get the current service
                        var service = await _treatmentService.GetServiceByIdAsync(serviceId);
                        if (service != null)
                        {
                            // Update the status
                            service.IsActive = false;
                            service.UpdatedDate = DateTime.Now;

                            // Save the changes
                            await _treatmentService.UpdateServiceAsync(service);

                            MessageBox.Show("Đã vô hiệu hóa dịch vụ thành công!", "Thông báo",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            await LoadServicesData(); // Refresh data using await
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dịch vụ này.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi vô hiệu hóa dịch vụ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        // Filter event handlers
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // The null check for _allServices is handled within ApplyFilters, so it's not strictly needed here.
            ApplyFilters();
        }

        private void CmbTreatmentTypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CmbStatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }
    }
}