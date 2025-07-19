using System.Windows;

namespace DNA.WpfApp.Windows
{
    public partial class HomeSampleScheduleWindow : Window
    {
        private readonly int _patientId;

        public HomeSampleScheduleWindow(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đã đặt lịch thu mẫu tại nhà thành công!", "Thông báo", 
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
