using System.Windows;

namespace DNA.WpfApp.Windows
{
    public partial class ComprehensiveReportWindow : Window
    {
        public ComprehensiveReportWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
