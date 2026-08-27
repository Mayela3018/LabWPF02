using System;
using System.Linq;
using System.Windows;
using LabWPF02.Helpers;

namespace LabWPF02.Views
{
    public partial class ReporteIngresosWindow : Window
    {
        public ReporteIngresosWindow()
        {
            InitializeComponent();
            dgIngresos.ItemsSource = DataStore.Ingresos;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            var resultado = DataStore.Ingresos.AsEnumerable();

            if (dpFechaInicio.SelectedDate != null)
                resultado = resultado.Where(i => i.FechaHora.Date >= dpFechaInicio.SelectedDate.Value.Date);

            if (dpFechaFin.SelectedDate != null)
                resultado = resultado.Where(i => i.FechaHora.Date <= dpFechaFin.SelectedDate.Value.Date);

            if (!string.IsNullOrWhiteSpace(txtFiltroPlaca.Text))
                resultado = resultado.Where(i => i.Placa.IndexOf(txtFiltroPlaca.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(txtFiltroConductor.Text))
                resultado = resultado.Where(i => i.NombreConductor.IndexOf(txtFiltroConductor.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(txtFiltroProducto.Text))
                resultado = resultado.Where(i => i.Producto != null && i.Producto.IndexOf(txtFiltroProducto.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            dgIngresos.ItemsSource = resultado.ToList();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}