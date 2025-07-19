using System;
using System.Windows;
using System.Windows.Controls;
using DNA.WpfApp.Utils;

namespace DNA.WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Window
    {
        public BookingPage()
        {
            InitializeComponent();
            InitializePage();
        }
        
        public BookingPage(string testType) : this()
        {
            // Pre-select test type if specified
            if (testType.Contains("Dân sự"))
            {
                rbCivilTest.IsChecked = true;
                rbLegalTest.IsChecked = false;
            }
            else if (testType.Contains("Hành chính"))
            {
                rbCivilTest.IsChecked = false;
                rbLegalTest.IsChecked = true;
                
                // For legal tests, facility collection is required
                rbSelfCollection.IsChecked = false;
                rbFacilityCollection.IsChecked = true;
                rbSelfCollection.IsEnabled = false;
            }
        }

        private void InitializePage()
        {
            // Set default values
            dpAppointmentDate.SelectedDate = DateTime.Now.AddDays(1);
            
            // Load customer information if logged in
            if (SessionManager.CurrentUser != null)
            {
                txtCustomerName.Text = SessionManager.CurrentUser.FullName ?? "";
                txtCustomerEmail.Text = SessionManager.CurrentUser.Email ?? "";
                txtCustomerPhone.Text = SessionManager.CurrentUser.Phone ?? "";
            }
            
            // Set up event handlers
            rbCivilTest.Checked += TestType_Changed;
            rbLegalTest.Checked += TestType_Changed;
            rbSelfCollection.Checked += CollectionMethod_Changed;
            rbFacilityCollection.Checked += CollectionMethod_Changed;
            
            UpdateUI();
        }

        private void TestType_Changed(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void CollectionMethod_Changed(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            // Update cost based on test type
            if (rbCivilTest.IsChecked == true)
            {
                txtTotalCost.Text = "2,500,000 VNĐ";
                rbSelfCollection.IsEnabled = true;
            }
            else if (rbLegalTest.IsChecked == true)
            {
                txtTotalCost.Text = "3,500,000 VNĐ";
                rbSelfCollection.IsEnabled = false;
                rbFacilityCollection.IsChecked = true;
            }
            
            // Show/hide appointment fields based on collection method
            bool showAppointmentFields = rbFacilityCollection.IsChecked == true;
            dpAppointmentDate.IsEnabled = showAppointmentFields;
            cmbAppointmentTime.IsEnabled = showAppointmentFields;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy đặt lịch?", "Xác nhận", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnConfirmBooking_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                // Create booking object and save to database
                var booking = CreateBookingFromForm();
                
                if (SaveBooking(booking))
                {
                    MessageBox.Show(
                        "Đặt lịch xét nghiệm thành công!\n\n" +
                        "Thông tin đặt lịch đã được ghi nhận. Chúng tôi sẽ liên hệ với bạn trong thời gian sớm nhất để xác nhận chi tiết.\n\n" +
                        "Cảm ơn bạn đã tin tưởng dịch vụ của chúng tôi!",
                        "Đặt lịch thành công",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    
                    this.DialogResult = true;
                    this.Close();
                }
            }
        }

        private bool ValidateForm()
        {
            // Validate customer information
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên người đặt.", "Thiếu thông tin");
                txtCustomerName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin");
                txtCustomerPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email.", "Thiếu thông tin");
                txtCustomerEmail.Focus();
                return false;
            }

            // Validate test subjects
            if (string.IsNullOrWhiteSpace(txtSubject1Name.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đối tượng xét nghiệm thứ 1.", "Thiếu thông tin");
                txtSubject1Name.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSubject2Name.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đối tượng xét nghiệm thứ 2.", "Thiếu thông tin");
                txtSubject2Name.Focus();
                return false;
            }

            // Validate appointment if facility collection is selected
            if (rbFacilityCollection.IsChecked == true)
            {
                if (dpAppointmentDate.SelectedDate == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày hẹn.", "Thiếu thông tin");
                    dpAppointmentDate.Focus();
                    return false;
                }

                if (dpAppointmentDate.SelectedDate <= DateTime.Now.Date)
                {
                    MessageBox.Show("Ngày hẹn phải sau ngày hôm nay.", "Ngày không hợp lệ");
                    dpAppointmentDate.Focus();
                    return false;
                }

                if (cmbAppointmentTime.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn thời gian hẹn.", "Thiếu thông tin");
                    cmbAppointmentTime.Focus();
                    return false;
                }
            }

            return true;
        }

        private object CreateBookingFromForm()
        {
            // Create a booking object with form data
            // This would typically be a proper model class
            return new
            {
                TestType = rbCivilTest.IsChecked == true ? "Dân sự" : "Hành chính",
                CollectionMethod = rbSelfCollection.IsChecked == true ? "Tự thu thập tại nhà" : "Thu thập tại cơ sở",
                CustomerName = txtCustomerName.Text.Trim(),
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                CustomerEmail = txtCustomerEmail.Text.Trim(),
                CustomerID = txtCustomerID.Text.Trim(),
                CustomerAddress = txtCustomerAddress.Text.Trim(),
                Subject1Name = txtSubject1Name.Text.Trim(),
                Subject1BirthYear = txtSubject1BirthYear.Text.Trim(),
                Subject1Relationship = (cmbSubject1Relationship.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Subject2Name = txtSubject2Name.Text.Trim(),
                Subject2BirthYear = txtSubject2BirthYear.Text.Trim(),
                Subject2Relationship = (cmbSubject2Relationship.SelectedItem as ComboBoxItem)?.Content.ToString(),
                AppointmentDate = dpAppointmentDate.SelectedDate,
                AppointmentTime = (cmbAppointmentTime.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Notes = txtNotes.Text.Trim(),
                TotalCost = txtTotalCost.Text,
                BookingDate = DateTime.Now,
                CustomerId = SessionManager.CurrentUserId
            };
        }

        private bool SaveBooking(object booking)
        {
            try
            {
                // TODO: Implement actual database save
                // For now, just simulate success
                System.Threading.Thread.Sleep(1000); // Simulate processing time
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu thông tin đặt lịch: {ex.Message}", "Lỗi", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
