using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DNA.BussinessObject;

namespace DNA.WpfApp.Pages.Treatments
{
    public partial class TreatmentRegistrationPage : Page
    {
        private List<Patient> _patients;
        private List<TreatmentService> _services;
        private List<Doctor> _doctors;
        private Patient _selectedPatient;
        private TreatmentService _selectedService;
        private Doctor _selectedDoctor;

        public TreatmentRegistrationPage()
        {
            InitializeComponent();
            LoadInitialData();
        }

        private async void LoadInitialData()
        {
            try
            {
                // Load patients
                _patients = GenerateMockPatients();
                cmbPatients.ItemsSource = _patients;

                // Load doctors
                _doctors = GenerateMockDoctors();
                cmbDoctors.ItemsSource = _doctors;

                // Load services (will be filtered by treatment type)
                _services = GenerateMockServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<Patient> GenerateMockPatients()
        {
            return new List<Patient>
            {
                new Patient { PatientId = 1, FullName = "Nguyễn Thị Hoa", Email = "hoa.nguyen@email.com", Phone = "0901234567", DateOfBirth = new DateTime(1990, 5, 15), Address = "123 Nguyễn Huệ, Q1, HCM" },
                new Patient { PatientId = 2, FullName = "Trần Thị Lan", Email = "lan.tran@email.com", Phone = "0912345678", DateOfBirth = new DateTime(1988, 8, 20), Address = "456 Lê Lợi, Q1, HCM" },
                new Patient { PatientId = 3, FullName = "Lê Thị Mai", Email = "mai.le@email.com", Phone = "0923456789", DateOfBirth = new DateTime(1992, 3, 10), Address = "789 Pasteur, Q3, HCM" }
            };
        }

        private List<Doctor> GenerateMockDoctors()
        {
            return new List<Doctor>
            {
                new Doctor { DoctorId = 1, FullName = "BS. Nguyễn Văn An", Specialization = "Sản phụ khoa - Hỗ trợ sinh sản", Degree = "Thạc sĩ Y khoa", YearsOfExperience = 15, ConsultationFee = 500000 },
                new Doctor { DoctorId = 2, FullName = "BS. Trần Thị Bình", Specialization = "Nội tiết - Sinh sản", Degree = "Tiến sĩ Y khoa", YearsOfExperience = 12, ConsultationFee = 600000 },
                new Doctor { DoctorId = 3, FullName = "BS. Lê Minh Cường", Specialization = "Hỗ trợ sinh sản", Degree = "Thạc sĩ Y khoa", YearsOfExperience = 10, ConsultationFee = 450000 }
            };
        }

        private List<TreatmentService> GenerateMockServices()
        {
            return new List<TreatmentService>
            {
                new TreatmentService { ServiceId = 1, ServiceName = "IUI cơ bản", TreatmentType = "IUI", Price = 15000000, DurationDays = 14, Description = "Thụ tinh trong tử cung với theo dõi cơ bản" },
                new TreatmentService { ServiceId = 2, ServiceName = "IUI nâng cao", TreatmentType = "IUI", Price = 20000000, DurationDays = 18, Description = "IUI với kích thích buồng trứng và theo dõi chuyên sâu" },
                new TreatmentService { ServiceId = 3, ServiceName = "IVF thế hệ 1", TreatmentType = "IVF", Price = 85000000, DurationDays = 21, Description = "Thụ tinh trong ống nghiệm cơ bản" },
                new TreatmentService { ServiceId = 4, ServiceName = "IVF với PGD", TreatmentType = "IVF", Price = 120000000, DurationDays = 28, Description = "IVF kết hợp chẩn đoán di truyền" },
                new TreatmentService { ServiceId = 5, ServiceName = "ICSI", TreatmentType = "ICSI", Price = 95000000, DurationDays = 21, Description = "Tiêm tinh trùng vào bào tương trứng" }
            };
        }

        private void CmbPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedPatient = cmbPatients.SelectedItem as Patient;
            
            if (_selectedPatient != null)
            {
                txtPatientName.Text = _selectedPatient.FullName;
                txtPatientEmail.Text = _selectedPatient.Email;
                txtPatientPhone.Text = _selectedPatient.Phone;
                txtPatientDOB.Text = _selectedPatient.DateOfBirth.ToString("dd/MM/yyyy");
                txtPatientAddress.Text = _selectedPatient.Address;
                
                pnlPatientInfo.Visibility = Visibility.Visible;
            }
            else
            {
                pnlPatientInfo.Visibility = Visibility.Collapsed;
            }

            UpdateSummaryAndValidation();
        }

        private void CmbTreatmentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTreatmentType.SelectedIndex > 0)
            {
                var selectedType = ((ComboBoxItem)cmbTreatmentType.SelectedItem).Content.ToString();
                var filteredServices = _services.Where(s => s.TreatmentType == selectedType).ToList();
                
                lstServices.ItemsSource = filteredServices;
                lstServices.Visibility = Visibility.Visible;
            }
            else
            {
                lstServices.Visibility = Visibility.Collapsed;
            }

            _selectedService = null;
            UpdateSummaryAndValidation();
        }

        private void LstServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedService = lstServices.SelectedItem as TreatmentService;
            UpdateSummaryAndValidation();
        }

        private void CmbDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedDoctor = cmbDoctors.SelectedItem as Doctor;
            
            if (_selectedDoctor != null)
            {
                txtDoctorSpecialization.Text = _selectedDoctor.Specialization;
                txtDoctorExperience.Text = $"{_selectedDoctor.YearsOfExperience} năm";
                txtDoctorDegree.Text = _selectedDoctor.Degree;
                txtDoctorFee.Text = $"{_selectedDoctor.ConsultationFee:N0} VNĐ";
                
                pnlDoctorInfo.Visibility = Visibility.Visible;
            }
            else
            {
                pnlDoctorInfo.Visibility = Visibility.Collapsed;
            }

            UpdateSummaryAndValidation();
        }

        private void UpdateSummaryAndValidation()
        {
            bool isValid = _selectedPatient != null && _selectedService != null && _selectedDoctor != null;

            if (isValid)
            {
                txtSummaryPatient.Text = $"Bệnh nhân: {_selectedPatient.FullName}";
                txtSummaryService.Text = $"Dịch vụ: {_selectedService.ServiceName}";
                txtSummaryDoctor.Text = $"Bác sĩ: {_selectedDoctor.FullName}";
                txtSummaryStartDate.Text = $"Ngày bắt đầu: {dpStartDate.SelectedDate?.ToString("dd/MM/yyyy")}";
                
                decimal totalCost = _selectedService.Price + _selectedDoctor.ConsultationFee;
                txtTotalCost.Text = $"{totalCost:N0} VNĐ";
                
                pnlSummary.Visibility = Visibility.Visible;
            }
            else
            {
                pnlSummary.Visibility = Visibility.Collapsed;
            }

            btnRegister.IsEnabled = isValid;
        }

        private void BtnAddNewPatient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng thêm bệnh nhân mới sẽ được triển khai.", "Thông báo");
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedPatient == null || _selectedService == null || _selectedDoctor == null)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    $"Xác nhận đăng ký điều trị:\n\n" +
                    $"Bệnh nhân: {_selectedPatient.FullName}\n" +
                    $"Dịch vụ: {_selectedService.ServiceName}\n" +
                    $"Bác sĩ: {_selectedDoctor.FullName}\n" +
                    $"Tổng chi phí: {(_selectedService.Price + _selectedDoctor.ConsultationFee):N0} VNĐ\n\n" +
                    $"Bạn có chắc chắn muốn đăng ký?",
                    "Xác nhận đăng ký", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Simulate registration process
                    MessageBox.Show("Đăng ký điều trị thành công!\n\nMã đăng ký: TR2024001\nNgười đăng ký sẽ được liên hệ trong vòng 24h.", 
                        "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    // Reset form
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng ký: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ đăng ký?", "Xác nhận", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                ResetForm();
            }
        }

        private void ResetForm()
        {
            cmbPatients.SelectedIndex = -1;
            cmbTreatmentType.SelectedIndex = 0;
            cmbDoctors.SelectedIndex = -1;
            txtNotes.Text = "";
            dpStartDate.SelectedDate = DateTime.Now;
            
            _selectedPatient = null;
            _selectedService = null;
            _selectedDoctor = null;
            
            pnlPatientInfo.Visibility = Visibility.Collapsed;
            pnlDoctorInfo.Visibility = Visibility.Collapsed;
            pnlSummary.Visibility = Visibility.Collapsed;
            lstServices.Visibility = Visibility.Collapsed;
            
            btnRegister.IsEnabled = false;
        }
    }
}
