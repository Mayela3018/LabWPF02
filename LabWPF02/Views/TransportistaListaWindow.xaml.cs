using System.Windows;
using LabWPF02.Helpers;

namespace LabWPF02.Views
{
    public partial class TransportistaListaWindow : Window
    {
        public TransportistaListaWindow()
        {
            InitializeComponent();
            dgTransportistas.ItemsSource = DataStore.Transportistas;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}