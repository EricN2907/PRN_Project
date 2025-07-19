// LoginWindow.xaml.cs
using DNA.BussinessObject;
using DNA.Repository;
using DNA.Service;
using DNA.WpfApp.Utils;
using DNA.WpfApp.Pages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DNA.WpfApp
{
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;

        public LoginWindow()
        {
            InitializeComponent();
            // Initialize services (in a real app, use DI container)
            var dbContext = new ApplicationDbContext();
            _userService = new UserService(dbContext);
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Password.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Đăng nhập thất bại", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                btnLogin.IsEnabled = false;

                var user = await _userService.LoginAsync(username, password);
                
                if (user != null)
                {
                    // Set user session
                    SessionManager.SetCurrentUser(user);
                    
                    // Navigate based on user role
                    if (user.UserType == "Admin" || user.UserType == "Manager" || user.UserType == "Staff")
                    {
                        // Staff, Manager, Admin go to MainWindow (management system)
                        var mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.DialogResult = true;
                        this.Close();
                    }
                    else if (user.UserType == "Customer")
                    {
                        // Customer goes to HomePage (public website)
                        this.DialogResult = true;
                        this.Close();
                        // The calling window (HomePage) will handle the UI update
                    }
                    else
                    {
                        // Unknown role, default to homepage
                        this.DialogResult = true;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Đăng nhập thất bại", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Password = "";
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                btnLogin.IsEnabled = true;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Trang đăng ký tài khoản sẽ được triển khai.", "Thông báo");
            // TODO: Create RegisterWindow and show it
            // var registerWindow = new RegisterWindow();
            // registerWindow.ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        
        private void btnGuestAccess_Click(object sender, RoutedEventArgs e)
        {
            // Allow guest access to public website
            this.DialogResult = false;
            this.Close();
        }
    }
}
