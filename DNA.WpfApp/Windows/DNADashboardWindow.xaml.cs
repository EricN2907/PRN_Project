using System.Windows;

namespace DNA.WpfApp.Windows
{
    public partial class DNADashboardWindow : Window
    {
        public DNADashboardWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
