using System.Windows;
using LabWPF02.Helpers;

namespace LabWPF02.Views
{
    public partial class ConductorListaWindow : Window
    {
        public ConductorListaWindow()
        {
            InitializeComponent();
            dgConductores.ItemsSource = DataStore.Conductores;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}