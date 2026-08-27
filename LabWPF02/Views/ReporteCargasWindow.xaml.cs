using System.Windows;
using LabWPF02.Helpers;

namespace LabWPF02.Views
{
    public partial class ReporteCargasWindow : Window
    {
        public ReporteCargasWindow()
        {
            InitializeComponent();
            dgCargas.ItemsSource = DataStore.Camiones;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}