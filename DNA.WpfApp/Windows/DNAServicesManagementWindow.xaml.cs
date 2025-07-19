using System.Windows;

namespace DNA.WpfApp.Windows
{
    public partial class DNAServicesManagementWindow : Window
    {
        public DNAServicesManagementWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
