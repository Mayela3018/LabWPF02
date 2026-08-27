using System.Windows;
using LabWPF02.Helpers;

namespace LabWPF02.Views
{
    public partial class ProductoListaWindow : Window
    {
        public ProductoListaWindow()
        {
            InitializeComponent();
            dgProductos.ItemsSource = DataStore.Productos;
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}