// LoginWindow.xaml.cs
using DNA.BussinessObject;
using DNA.Repository;
using DNA.Service;
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
            _userService = new UserService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            var user = _userService.Login(txtUsername.Text.Trim(), txtPassword.Password.Trim());

            if (user != null)
            {
                MessageBox.Show($"Welcome {user.Username} - Role: {user.Role}");
                // TODO: Navigate to MainWindow
            }
            else
            {
                MessageBox.Show("Invalid login.");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Redirect to registration.");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
