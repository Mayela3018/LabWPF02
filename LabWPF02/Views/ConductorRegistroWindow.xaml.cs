using System.Linq;
using System.Windows;
using LabWPF02.Helpers;
using LabWPF02.Models;

namespace LabWPF02.Views
{
    public partial class ConductorRegistroWindow : Window
    {
        public ConductorRegistroWindow()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!Validaciones.EsTextoValido(txtNombre.Text))
            {
                Validaciones.MostrarError("Ingresa el nombre del conductor.");
                return;
            }

            if (!Validaciones.EsLicenciaValida(txtLicencia.Text))
            {
                Validaciones.MostrarError("La licencia debe tener el formato: 1 letra + 8 números (ej. Q12345678).");
                return;
            }

            if (!Validaciones.EsTextoValido(txtTransporte.Text))
            {
                Validaciones.MostrarError("Ingresa el nombre del transporte.");
                return;
            }

            string licencia = txtLicencia.Text.Trim().ToUpper();
            bool yaExiste = DataStore.Conductores.Any(c => c.Licencia == licencia);

            if (yaExiste)
            {
                Validaciones.MostrarError("Ya existe un conductor registrado con esa licencia.");
                return;
            }

            DataStore.Conductores.Add(new Conductor
            {
                NombreConductor = txtNombre.Text.Trim(),
                Licencia = licencia,
                Transporte = txtTransporte.Text.Trim()
            });

            Validaciones.MostrarExito("Conductor registrado correctamente.");
            this.Close();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}