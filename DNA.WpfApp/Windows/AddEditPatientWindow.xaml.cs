using System;
using System.Windows;
using DNA.BussinessObject;
using DNA.Service;
using DNA.Repository;

namespace DNA.WpfApp.Windows
{
    public partial class AddEditPatientWindow : Window
    {
        private readonly IPatientService _patientService;
        private Patient? _currentPatient;
        private bool _isEditMode;

        public AddEditPatientWindow()
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            _patientService = new PatientService(context);
            _isEditMode = false;
            Title = "Thêm Bệnh Nhân Mới";
        }

        public AddEditPatientWindow(Patient patient) : this()
        {
            _currentPatient = patient;
            _isEditMode = true;
            Title = "Chỉnh Sửa Thông Tin Bệnh Nhân";
            LoadPatientData();
        }

        private void LoadPatientData()
        {
            if (_currentPatient == null) return;

            txtFullName.Text = _currentPatient.FullName;
            txtEmail.Text = _currentPatient.Email;
            txtPhone.Text = _currentPatient.Phone;
            dpDateOfBirth.SelectedDate = _currentPatient.DateOfBirth;
            
            // Set gender
            foreach (var item in cmbGender.Items)
            {
                if (item.ToString()?.Contains(_currentPatient.Gender) == true)
                {
                    cmbGender.SelectedItem = item;
                    break;
                }
            }

            txtAddress.Text = _currentPatient.Address ?? "";
            txtMedicalHistory.Text = _currentPatient.MedicalHistory ?? "";
            txtEmergencyContact.Text = _currentPatient.EmergencyContact ?? "";
            txtEmergencyPhone.Text = _currentPatient.EmergencyPhone ?? "";
            
            // Set blood type
            foreach (var item in cmbBloodType.Items)
            {
                if (item.ToString()?.Contains(_currentPatient.BloodType ?? "") == true)
                {
                    cmbBloodType.SelectedItem = item;
                    break;
                }
            }

            txtAllergies.Text = _currentPatient.Allergies ?? "";
            chkIsActive.IsChecked = _currentPatient.IsActive;
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate required fields (validation code remains unchanged)
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ và tên!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtFullName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập email!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (!dpDateOfBirth.SelectedDate.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn ngày sinh!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    dpDateOfBirth.Focus();
                    return;
                }

                if (cmbGender.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    cmbGender.Focus();
                    return;
                }

                Patient patient;
                if (_isEditMode && _currentPatient != null)
                {
                    patient = _currentPatient;
                }
                else
                {
                    patient = new Patient();
                }

                // Update patient properties
                patient.FullName = txtFullName.Text.Trim();
                patient.Email = txtEmail.Text.Trim();
                patient.Phone = txtPhone.Text.Trim();
                patient.DateOfBirth = dpDateOfBirth.SelectedDate.Value;
                patient.Gender = (cmbGender.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content?.ToString() ?? "";
                patient.Address = txtAddress.Text.Trim();
                patient.MedicalHistory = txtMedicalHistory.Text.Trim();
                patient.EmergencyContact = txtEmergencyContact.Text.Trim();
                patient.EmergencyPhone = txtEmergencyPhone.Text.Trim();
                patient.BloodType = (cmbBloodType.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content?.ToString();
                patient.Allergies = txtAllergies.Text.Trim();
                patient.IsActive = chkIsActive.IsChecked ?? true;

                if (!_isEditMode)
                {
                    patient.CreatedDate = DateTime.Now;
                }
                else
                {
                    patient.UpdatedDate = DateTime.Now;
                }

                try
                {
                    Patient savedPatient;
                    if (_isEditMode)
                    {
                        savedPatient = await _patientService.UpdatePatientAsync(patient);
                    }
                    else
                    {
                        
                        savedPatient = await _patientService.CreatePatientAsync(patient);
                    }

                    // If we get here without an exception, and savedPatient is not null, consider it a success
                    if (savedPatient != null)
                    {
                        MessageBox.Show($"Đã {(_isEditMode ? "cập nhật" : "thêm")} bệnh nhân thành công!", 
                            "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                        DialogResult = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"Không thể {(_isEditMode ? "cập nhật" : "thêm")} bệnh nhân!", 
                            "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception serviceEx)
                {
                    MessageBox.Show($"Lỗi khi lưu dữ liệu: {serviceEx.Message}", 
                        "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
