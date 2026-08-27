using System.Linq;
using System.Windows;
using LabWPF02.Helpers;
using LabWPF02.Models;

namespace LabWPF02.Views
{
    public partial class CamionRegistroWindow : Window
    {
        public CamionRegistroWindow()
        {
            InitializeComponent();
            cmbTransportista.ItemsSource = DataStore.Transportistas;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!Validaciones.EsPlacaValida(txtPlaca.Text))
            {
                Validaciones.MostrarError("La placa debe tener el formato ABC-123.");
                return;
            }

            if (!Validaciones.EsTextoValido(txtMarca.Text))
            {
                Validaciones.MostrarError("Ingresa la marca del camión.");
                return;
            }

            if (!Validaciones.EsTextoValido(txtModelo.Text))
            {
                Validaciones.MostrarError("Ingresa el modelo del camión.");
                return;
            }

            if (!Validaciones.EsNumeroPositivo(txtCapacidad.Text, out double capacidad))
            {
                Validaciones.MostrarError("La capacidad debe ser un número mayor a 0.");
                return;
            }

            if (cmbTransportista.SelectedItem == null)
            {
                Validaciones.MostrarError("Selecciona un transportista. Si no hay ninguno, regístralo primero en 'Transportistas'.");
                return;
            }

            string placa = txtPlaca.Text.Trim().ToUpper();
            if (DataStore.Camiones.Any(c => c.Placa == placa))
            {
                Validaciones.MostrarError("Ya existe un camión registrado con esa placa.");
                return;
            }

            DataStore.Camiones.Add(new Camion
            {
                Placa = placa,
                Marca = txtMarca.Text.Trim(),
                Modelo = txtModelo.Text.Trim(),
                CapacidadKg = capacidad,
                Transportista = ((Transportista)cmbTransportista.SelectedItem).NombreEmpresa
            });

            Validaciones.MostrarExito("Camión registrado correctamente.");
            this.Close();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}