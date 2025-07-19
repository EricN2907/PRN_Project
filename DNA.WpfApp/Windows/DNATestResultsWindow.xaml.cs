using System.Windows;

namespace DNA.WpfApp.Windows
{
    public partial class DNATestResultsWindow : Window
    {
        private readonly int _patientId;

        public DNATestResultsWindow(int patientId)
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
