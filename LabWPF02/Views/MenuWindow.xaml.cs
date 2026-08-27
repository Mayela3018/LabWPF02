using System.Linq;
using System.Windows;
using LabWPF02.Helpers;

namespace LabWPF02.Views
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            txtTotalIngresos.Text = DataStore.Ingresos.Count.ToString();
            txtTotalSalidas.Text = DataStore.Salidas.Count.ToString();
            txtTotalConductores.Text = DataStore.Conductores.Count.ToString();
            txtTotalTransportistas.Text = DataStore.Transportistas.Count.ToString();
            txtTotalCamiones.Text = DataStore.Camiones.Count.ToString();
            txtTotalProductos.Text = DataStore.Productos.Count.ToString();
            txtPesoTotal.Text = DataStore.Ingresos.Sum(i => i.PesoIngreso).ToString("N0");
        }

        private void MenuIngresos_Click(object sender, RoutedEventArgs e)
        {
            new IngresoWindow().ShowDialog();
            RefreshDashboard();
        }

        private void MenuSalida_Click(object sender, RoutedEventArgs e)
        {
            new SalidaWindow().ShowDialog();
            RefreshDashboard();
        }

        private void MenuConductorRegistrar_Click(object sender, RoutedEventArgs e)
        {
            new ConductorRegistroWindow().ShowDialog();
            RefreshDashboard();
        }

        private void MenuConductorListar_Click(object sender, RoutedEventArgs e)
        {
            new ConductorListaWindow().ShowDialog();
        }

        private void MenuTransportistaRegistrar_Click(object sender, RoutedEventArgs e)
        {
            new TransportistaRegistroWindow().ShowDialog();
            RefreshDashboard();
        }

        private void MenuTransportistaListar_Click(object sender, RoutedEventArgs e)
        {
            new TransportistaListaWindow().ShowDialog();
        }

        private void MenuCamionRegistrar_Click(object sender, RoutedEventArgs e)
        {
            new CamionRegistroWindow().ShowDialog();
            RefreshDashboard();
        }

        private void MenuCamionListar_Click(object sender, RoutedEventArgs e)
        {
            new CamionListaWindow().ShowDialog();
        }

        private void MenuProductoRegistrar_Click(object sender, RoutedEventArgs e)
        {
            new ProductoRegistroWindow().ShowDialog();
            RefreshDashboard();
        }

        private void MenuProductoListar_Click(object sender, RoutedEventArgs e)
        {
            new ProductoListaWindow().ShowDialog();
        }

        private void MenuReporteCargas_Click(object sender, RoutedEventArgs e)
        {
            new ReporteCargasWindow().ShowDialog();
        }

        private void MenuReporteIngresos_Click(object sender, RoutedEventArgs e)
        {
            new ReporteIngresosWindow().ShowDialog();
        }

        private void MenuReporteSalidas_Click(object sender, RoutedEventArgs e)
        {
            new ReporteSalidasWindow().ShowDialog();
        }
    }
}