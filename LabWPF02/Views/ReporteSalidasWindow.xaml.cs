using System;
using System.Linq;
using System.Windows;
using LabWPF02.Helpers;

namespace LabWPF02.Views
{
    public partial class ReporteSalidasWindow : Window
    {
        public ReporteSalidasWindow()
        {
            InitializeComponent();
            dgSalidas.ItemsSource = DataStore.Salidas;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            var resultado = DataStore.Salidas.AsEnumerable();

            if (dpFechaInicio.SelectedDate != null)
                resultado = resultado.Where(s => s.FechaHora.Date >= dpFechaInicio.SelectedDate.Value.Date);

            if (dpFechaFin.SelectedDate != null)
                resultado = resultado.Where(s => s.FechaHora.Date <= dpFechaFin.SelectedDate.Value.Date);

            if (!string.IsNullOrWhiteSpace(txtFiltroPlaca.Text))
                resultado = resultado.Where(s => s.Placa.IndexOf(txtFiltroPlaca.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(txtFiltroConductor.Text))
                resultado = resultado.Where(s => s.NombreConductor.IndexOf(txtFiltroConductor.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            if (!string.IsNullOrWhiteSpace(txtFiltroProducto.Text))
                resultado = resultado.Where(s => s.Producto != null && s.Producto.IndexOf(txtFiltroProducto.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            dgSalidas.ItemsSource = resultado.ToList();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}