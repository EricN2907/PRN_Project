using System.Windows;

namespace DNA.WpfApp.Windows
{
    public partial class PricingManagementWindow : Window
    {
        public PricingManagementWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
