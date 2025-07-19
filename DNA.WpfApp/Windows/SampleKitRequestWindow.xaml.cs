using System.Windows;

namespace DNA.WpfApp.Windows
{
    public partial class SampleKitRequestWindow : Window
    {
        private readonly int _patientId;

        public SampleKitRequestWindow(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void BtnRequest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đã gửi yêu cầu kit thành công!", "Thông báo", 
                MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
