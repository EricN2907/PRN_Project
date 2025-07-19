using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DNA.BussinessObject;
using DNA.Service;
using DNA.Repository;

namespace DNA.WpfApp.Windows
{
    public partial class DNATestHistoryWindow : Window
    {
        private readonly int _patientId;
        private readonly IPatientService _patientService;

        public DNATestHistoryWindow(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            
            // Initialize services
            var context = new ApplicationDbContext();
            _patientService = new PatientService(context);

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                // Load patient info
                var patient = await _patientService.GetPatientByIdAsync(_patientId);
                if (patient != null)
                {
                    txtPatientInfo.Text = $"Bệnh nhân: {patient.FullName} - {patient.Email}";
                }

                // Load test history - Mock data for now
                var historyData = GenerateMockHistory();
                dgHistory.ItemsSource = historyData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<object> GenerateMockHistory()
        {
            return new List<object>
            {
                new {
                    RegistrationId = 1,
                    ServiceName = "Xét nghiệm ADN xác định huyết thống cha con",
                    ServiceType = "Dân sự",
                    RegistrationDate = DateTime.Now.AddDays(-30),
                    Status = "Hoàn thành",
                    SampleCollectionMethod = "Tại nhà",
                    TotalCost = 2500000,
                    PaymentStatus = "Đã thanh toán",
                    ProgressPercentage = 100.0
                },
                new {
                    RegistrationId = 2,
                    ServiceName = "Xét nghiệm ADN xác định huyết thống mẹ con",
                    ServiceType = "Dân sự",
                    RegistrationDate = DateTime.Now.AddDays(-60),
                    Status = "Hoàn thành",
                    SampleCollectionMethod = "Tại cơ sở",
                    TotalCost = 2300000,
                    PaymentStatus = "Đã thanh toán",
                    ProgressPercentage = 100.0
                }
            };
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Export functionality would go here
                MessageBox.Show("Chức năng xuất Excel đang được phát triển!", "Thông báo", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
