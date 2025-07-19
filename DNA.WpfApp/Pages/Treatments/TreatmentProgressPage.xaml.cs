using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DNA.WpfApp.Pages.Treatments
{
    public partial class TreatmentProgressPage : Page
    {
        private List<TreatmentProgressDTO> _allTreatments;
        private List<TreatmentProgressDTO> _filteredTreatments;

        public TreatmentProgressPage()
        {
            InitializeComponent();
            LoadTreatmentProgressData();
        }

        private async void LoadTreatmentProgressData()
        {
            try
            {
                txtLoading.Visibility = Visibility.Visible;
                dgTreatmentProgress.Visibility = Visibility.Collapsed;

                // Mock data - trong thực tế sẽ gọi từ service
                _allTreatments = GenerateMockTreatmentProgress();
                _filteredTreatments = _allTreatments.ToList();

                dgTreatmentProgress.ItemsSource = _filteredTreatments;
                
                txtLoading.Visibility = Visibility.Collapsed;
                dgTreatmentProgress.Visibility = Visibility.Visible;

                UpdateNoDataVisibility();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                txtLoading.Visibility = Visibility.Collapsed;
            }
        }

        private List<TreatmentProgressDTO> GenerateMockTreatmentProgress()
        {
            return new List<TreatmentProgressDTO>
            {
                new TreatmentProgressDTO 
                { 
                    RegistrationId = 1, 
                    PatientName = "Nguyễn Thị Hoa", 
                    ServiceName = "IVF thế hệ 1", 
                    DoctorName = "BS. Nguyễn Văn An", 
                    StartDate = DateTime.Now.AddDays(-15), 
                    Status = "Đang điều trị", 
                    ProgressPercentage = 65,
                    ProgressColor = new SolidColorBrush(Color.FromRgb(40, 167, 69))
                },
                new TreatmentProgressDTO 
                { 
                    RegistrationId = 2, 
                    PatientName = "Trần Thị Lan", 
                    ServiceName = "IUI cơ bản", 
                    DoctorName = "BS. Trần Thị Bình", 
                    StartDate = DateTime.Now.AddDays(-8), 
                    Status = "Đang điều trị", 
                    ProgressPercentage = 30,
                    ProgressColor = new SolidColorBrush(Color.FromRgb(255, 193, 7))
                },
                new TreatmentProgressDTO 
                { 
                    RegistrationId = 3, 
                    PatientName = "Lê Thị Mai", 
                    ServiceName = "ICSI", 
                    DoctorName = "BS. Lê Minh Cường", 
                    StartDate = DateTime.Now.AddDays(-30), 
                    Status = "Hoàn thành", 
                    ProgressPercentage = 100,
                    ProgressColor = new SolidColorBrush(Color.FromRgb(40, 167, 69))
                },
                new TreatmentProgressDTO 
                { 
                    RegistrationId = 4, 
                    PatientName = "Phạm Thị Nga", 
                    ServiceName = "IVF với PGD", 
                    DoctorName = "BS. Nguyễn Văn An", 
                    StartDate = DateTime.Now.AddDays(-5), 
                    Status = "Đã đăng ký", 
                    ProgressPercentage = 10,
                    ProgressColor = new SolidColorBrush(Color.FromRgb(108, 117, 125))
                },
                new TreatmentProgressDTO 
                { 
                    RegistrationId = 5, 
                    PatientName = "Hoàng Thị Linh", 
                    ServiceName = "IUI nâng cao", 
                    DoctorName = "BS. Trần Thị Bình", 
                    StartDate = DateTime.Now.AddDays(-45), 
                    Status = "Đã hủy", 
                    ProgressPercentage = 20,
                    ProgressColor = new SolidColorBrush(Color.FromRgb(220, 53, 69))
                }
            };
        }

        private void ApplyFilters()
        {
            var filtered = _allTreatments.AsEnumerable();

            // Search filter
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var searchTerm = txtSearch.Text.ToLower();
                filtered = filtered.Where(t =>
                    t.PatientName.ToLower().Contains(searchTerm) ||
                    t.ServiceName.ToLower().Contains(searchTerm) ||
                    t.DoctorName.ToLower().Contains(searchTerm));
            }

            // Treatment Type filter
            if (cmbTreatmentTypeFilter.SelectedIndex > 0)
            {
                var selectedType = ((ComboBoxItem)cmbTreatmentTypeFilter.SelectedItem).Content.ToString();
                filtered = filtered.Where(t => t.ServiceName.Contains(selectedType));
            }

            // Status filter
            if (cmbStatusFilter.SelectedIndex > 0)
            {
                var selectedStatus = ((ComboBoxItem)cmbStatusFilter.SelectedItem).Content.ToString();
                filtered = filtered.Where(t => t.Status == selectedStatus);
            }

            _filteredTreatments = filtered.ToList();
            dgTreatmentProgress.ItemsSource = _filteredTreatments;
            UpdateNoDataVisibility();
        }

        private void UpdateNoDataVisibility()
        {
            txtNoData.Visibility = _filteredTreatments.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        // Event Handlers
        private void BtnAddProgress_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng cập nhật tiến độ mới sẽ được triển khai.", "Thông báo");
        }

        private void BtnViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int registrationId)
            {
                MessageBox.Show($"Xem chi tiết điều trị ID: {registrationId}", "Thông báo");
            }
        }

        private void BtnUpdateProgress_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int registrationId)
            {
                MessageBox.Show($"Cập nhật tiến độ điều trị ID: {registrationId}", "Thông báo");
            }
        }

        private void BtnMedicationSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int registrationId)
            {
                MessageBox.Show($"Quản lý lịch thuốc cho điều trị ID: {registrationId}", "Thông báo");
            }
        }

        private void BtnAppointments_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int registrationId)
            {
                MessageBox.Show($"Quản lý lịch hẹn cho điều trị ID: {registrationId}", "Thông báo");
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_allTreatments != null)
                ApplyFilters();
        }

        private void CmbTreatmentTypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_allTreatments != null)
                ApplyFilters();
        }

        private void CmbStatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_allTreatments != null)
                ApplyFilters();
        }
    }

    // DTO for Treatment Progress display
    public class TreatmentProgressDTO
    {
        public int RegistrationId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ProgressPercentage { get; set; }
        public SolidColorBrush ProgressColor { get; set; } = new SolidColorBrush(Colors.Blue);
    }
}
