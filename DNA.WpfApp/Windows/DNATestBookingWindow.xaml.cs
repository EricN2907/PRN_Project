using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DNA.BussinessObject;
using DNA.Service;
using DNA.Repository;

namespace DNA.WpfApp.Windows
{
    public partial class DNATestBookingWindow : Window
    {
        private readonly int _patientId;
        private readonly IPatientService _patientService;
        private readonly ITreatmentService _treatmentService;

        public DNATestBookingWindow(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
            
            // Initialize services
            var context = new ApplicationDbContext();
            _patientService = new PatientService(context);
            _treatmentService = new TreatmentServiceImpl(context);

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
                    txtPatientName.Text = patient.FullName;
                    txtPatientEmail.Text = patient.Email;
                    txtPatientPhone.Text = patient.Phone;
                }                // Load available services
                var services = await _treatmentService.GetAllServicesAsync();
                cmbServices.ItemsSource = services.Where(s => s.IsActive);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbServices.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ xét nghiệm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string sampleMethod = "Tại nhà";
                if (rbClinicSample.IsChecked == true)
                    sampleMethod = "Tại cơ sở";
                else if (rbSelfSample.IsChecked == true)
                    sampleMethod = "Tự thu thập";

                // Here you would call the actual booking service
                // For now, just show success message
                MessageBox.Show("Đã đặt xét nghiệm ADN thành công!", "Thông báo", 
                    MessageBoxButton.OK, MessageBoxImage.Information);

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt xét nghiệm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
