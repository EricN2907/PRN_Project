using System.Windows;

namespace DNA.WpfApp.Windows
{
    public partial class PatientFeedbackWindow : Window
    {
        private readonly int _patientId;

        public PatientFeedbackWindow(int patientId)
        {
            InitializeComponent();
            _patientId = patientId;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
