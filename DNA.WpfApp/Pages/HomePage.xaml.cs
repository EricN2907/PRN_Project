using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DNA.WpfApp.Utils;

namespace DNA.WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml - Public website for DNA testing services
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
            SetupUserInterface();
        }

        private void SetupUserInterface()
        {
            // Update navigation based on user login status
            if (SessionManager.CurrentUser != null)
            {
                btnLogin.Content = "Hồ sơ";
                btnRegister.Content = "Đăng xuất";
                
                // Show user-specific options if logged in as customer
                if (SessionManager.IsCustomer)
                {
                    // Update UI to show logged in state
                    // You can add a welcome text block to the header if needed
                }
            }
            else
            {
                btnLogin.Content = "Đăng nhập";
                btnRegister.Content = "Đăng ký";
            }
        }

        #region Navigation Event Handlers
        
        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            // Already on home page, scroll to top
            // You can implement smooth scrolling here
        }

        private void BtnServices_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to services page or scroll to services section
            MessageBox.Show("Chức năng xem chi tiết dịch vụ sẽ được triển khai.", "Thông báo");
            // TODO: Create ServicesPage and navigate to it
        }

        private void BtnBlog_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to blog page
            MessageBox.Show("Trang blog chia sẻ kiến thức ADN sẽ được triển khai.", "Thông báo");
            // TODO: Create BlogPage and navigate to it
        }

        private void BtnResults_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để xem kết quả xét nghiệm.", "Yêu cầu đăng nhập");
                OpenLoginWindow();
                return;
            }

            // Navigate to results page
            MessageBox.Show("Trang xem kết quả xét nghiệm sẽ được triển khai.", "Thông báo");
            // TODO: Create ResultsPage and navigate to it
        }

        private void BtnContact_Click(object sender, RoutedEventArgs e)
        {
            // Scroll to contact section
            MessageBox.Show("Cuộn xuống phần liên hệ hoặc mở trang liên hệ riêng.", "Thông báo");
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.CurrentUser != null)
            {
                // Show user profile
                MessageBox.Show("Trang hồ sơ người dùng sẽ được triển khai.", "Thông báo");
                // TODO: Create UserProfilePage and navigate to it
            }
            else
            {
                OpenLoginWindow();
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.CurrentUser != null)
            {
                // Logout
                var result = MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    SessionManager.ClearSession();
                    SetupUserInterface();
                    MessageBox.Show("Đã đăng xuất thành công.", "Thông báo");
                }
            }
            else
            {
                // Register new account
                MessageBox.Show("Trang đăng ký tài khoản sẽ được triển khai.", "Thông báo");
                // TODO: Create RegisterPage and navigate to it
            }
        }

        #endregion

        #region Service Booking Event Handlers
        
        private void BtnBookTest_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                var result = MessageBox.Show("Bạn cần đăng nhập để đặt lịch xét nghiệm. Bạn có muốn đăng nhập ngay?", 
                    "Yêu cầu đăng nhập", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    OpenLoginWindow();
                }
                return;
            }

            // Open booking page
            var bookingPage = new BookingPage();
            bookingPage.ShowDialog();
        }

        private void BtnRequestKit_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                var result = MessageBox.Show("Bạn cần đăng nhập để yêu cầu bộ kit. Bạn có muốn đăng nhập ngay?", 
                    "Yêu cầu đăng nhập", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    OpenLoginWindow();
                }
                return;
            }

            // Open kit request (which is essentially booking with home collection)
            var bookingPage = new BookingPage("Xét nghiệm ADN Dân sự");
            bookingPage.rbSelfCollection.IsChecked = true;
            bookingPage.ShowDialog();
        }

        private void BtnBookCivilTest_Click(object sender, RoutedEventArgs e)
        {
            BookSpecificTest("Xét nghiệm ADN Dân sự");
        }

        private void BtnBookLegalTest_Click(object sender, RoutedEventArgs e)
        {
            BookSpecificTest("Xét nghiệm ADN Hành chính");
        }

        private void BtnRequestHomeKit_Click(object sender, RoutedEventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                var result = MessageBox.Show("Bạn cần đăng nhập để yêu cầu bộ kit. Bạn có muốn đăng nhập ngay?", 
                    "Yêu cầu đăng nhập", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    OpenLoginWindow();
                }
                return;
            }

            // Open booking page with home kit pre-selected
            var bookingPage = new BookingPage("Xét nghiệm ADN Dân sự");
            bookingPage.ShowDialog();
        }

        private void BookSpecificTest(string testType)
        {
            if (SessionManager.CurrentUser == null)
            {
                var result = MessageBox.Show($"Bạn cần đăng nhập để đặt {testType}. Bạn có muốn đăng nhập ngay?", 
                    "Yêu cầu đăng nhập", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    OpenLoginWindow();
                }
                return;
            }

            // Open booking page with specific test type
            var bookingPage = new BookingPage(testType);
            bookingPage.ShowDialog();
        }

        #endregion

        #region Consultation Event Handlers

        private void BtnGetConsultation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trang đặt lịch tư vấn miễn phí sẽ được triển khai.", "Thông báo");
            // TODO: Create ConsultationPage and navigate to it
        }

        private void BtnSubmitConsultation_Click(object sender, RoutedEventArgs e)
        {
            // Validate form
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên.", "Thiếu thông tin");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin");
                txtPhone.Focus();
                return;
            }

            if (cmbServiceType.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ cần tư vấn.", "Thiếu thông tin");
                cmbServiceType.Focus();
                return;
            }

            // Process consultation request
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string serviceType = (cmbServiceType.SelectedItem as ComboBoxItem)?.Content.ToString();
            string message = txtMessage.Text.Trim();

            // TODO: Save consultation request to database
            MessageBox.Show($"Cảm ơn {name}! Yêu cầu tư vấn của bạn đã được ghi nhận. Chúng tôi sẽ liên hệ với bạn trong thời gian sớm nhất.", "Thành công");

            // Clear form
            txtName.Clear();
            txtPhone.Clear();
            txtMessage.Clear();
            cmbServiceType.SelectedIndex = -1;
        }

        #endregion

        #region Helper Methods

        private void OpenLoginWindow()
        {
            var loginWindow = new LoginWindow();
            var result = loginWindow.ShowDialog();
            
            if (result == true && SessionManager.CurrentUser != null)
            {
                // Check user role and redirect accordingly
                if (SessionManager.IsStaff || SessionManager.IsManager || SessionManager.IsAdmin)
                {
                    // Staff, Manager, Admin go to MainWindow
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    // Customer stays on HomePage but with updated UI
                    SetupUserInterface();
                }
            }
        }

        #endregion
    }
}