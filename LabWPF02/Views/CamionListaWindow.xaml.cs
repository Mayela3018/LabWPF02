using System.Windows;
using LabWPF02.Helpers;

namespace LabWPF02.Views
{
    public partial class CamionListaWindow : Window
    {
        public CamionListaWindow()
        {
            InitializeComponent();
            dgCamiones.ItemsSource = DataStore.Camiones;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}