using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using LabWPF02.Helpers;
using LabWPF02.Models;

namespace LabWPF02.Views
{
    public partial class SalidaWindow : Window
    {
        public SalidaWindow()
        {
            InitializeComponent();
            dpFecha.SelectedDate = DateTime.Today;
            dpFecha.DisplayDateEnd = DateTime.Today;
        }

        private void CmbTipoDocumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoDocumento.SelectedItem == null) return;

            string tipo = ((ComboBoxItem)cmbTipoDocumento.SelectedItem).Content.ToString();
            txtNumeroDocumento.Clear();

            switch (tipo)
            {
                case "DNI":
                    txtNumeroDocumento.MaxLength = 8;
                    txtAyudaDocumento.Text = "El DNI debe tener exactamente 8 dígitos numéricos.";
                    break;
                case "RUC":
                    txtNumeroDocumento.MaxLength = 11;
                    txtAyudaDocumento.Text = "El RUC debe tener exactamente 11 dígitos numéricos.";
                    break;
                case "Carnet de Extranjería":
                    txtNumeroDocumento.MaxLength = 12;
                    txtAyudaDocumento.Text = "El Carnet de Extranjería admite hasta 12 caracteres alfanuméricos.";
                    break;
            }
        }

        private void TxtNumeroDocumento_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (cmbTipoDocumento.SelectedItem == null)
            {
                e.Handled = true;
                return;
            }

            string tipo = ((ComboBoxItem)cmbTipoDocumento.SelectedItem).Content.ToString();

            if (tipo == "DNI" || tipo == "RUC")
                e.Handled = !Regex.IsMatch(e.Text, @"^[0-9]+$");
            else
                e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z0-9]+$");
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTipoDocumento.SelectedItem == null)
            {
                Validaciones.MostrarError("Selecciona un tipo de documento.");
                return;
            }

            string tipoDocumento = ((ComboBoxItem)cmbTipoDocumento.SelectedItem).Content.ToString();

            if (!Validaciones.EsDocumentoValido(tipoDocumento, txtNumeroDocumento.Text))
            {
                Validaciones.MostrarError(
                    tipoDocumento == "DNI" ? "El DNI debe tener 8 dígitos." :
                    tipoDocumento == "RUC" ? "El RUC debe tener 11 dígitos." :
                    "El número de documento no es válido.");
                return;
            }

            if (!Validaciones.EsPlacaValida(txtPlaca.Text))
            {
                Validaciones.MostrarError("La placa debe tener el formato ABC-123.");
                return;
            }

            if (cmbTurno.SelectedItem == null)
            {
                Validaciones.MostrarError("Selecciona un turno.");
                return;
            }

            if (!Validaciones.EsTextoValido(txtNombreConductor.Text))
            {
                Validaciones.MostrarError("Ingresa el nombre del conductor.");
                return;
            }

            if (!Validaciones.EsTextoValido(txtNombreCliente.Text))
            {
                Validaciones.MostrarError("Ingresa el nombre del cliente.");
                return;
            }

            if (dpFecha.SelectedDate == null || dpFecha.SelectedDate.Value.Date > DateTime.Today)
            {
                Validaciones.MostrarError("Selecciona una fecha válida (no puede ser futura).");
                return;
            }

            if (!Validaciones.EsHoraValida(txtHora.Text, out TimeSpan hora))
            {
                Validaciones.MostrarError("La hora debe tener el formato HH:mm (ej. 08:30).");
                return;
            }

            if (!Validaciones.EsNumeroPositivo(txtPeso.Text, out double peso))
            {
                Validaciones.MostrarError("El peso debe ser un número mayor a 0.");
                return;
            }

            DataStore.Salidas.Add(new Salida
            {
                TipoDocumento = tipoDocumento,
                NumeroDocumento = txtNumeroDocumento.Text.Trim(),
                Placa = txtPlaca.Text.Trim().ToUpper(),
                Turno = ((ComboBoxItem)cmbTurno.SelectedItem).Content.ToString(),
                NombreConductor = txtNombreConductor.Text.Trim(),
                NombreCliente = txtNombreCliente.Text.Trim(),
                Producto = txtProducto.Text.Trim(),
                Transporte = txtTransporte.Text.Trim(),
                FechaHora = dpFecha.SelectedDate.Value.Date + hora,
                PesoSalida = peso
            });

            Validaciones.MostrarExito("Salida registrada correctamente.");
            this.Close();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}