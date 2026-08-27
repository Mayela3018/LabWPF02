using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using LabWPF02.Helpers;
using LabWPF02.Models;

namespace LabWPF02.Views
{
    public partial class TransportistaRegistroWindow : Window
    {
        public TransportistaRegistroWindow()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!Validaciones.EsTextoValido(txtNombreEmpresa.Text))
            {
                Validaciones.MostrarError("Ingresa el nombre de la empresa.");
                return;
            }

            if (!Regex.IsMatch(txtRuc.Text.Trim(), @"^\d{11}$"))
            {
                Validaciones.MostrarError("El RUC debe tener 11 dígitos.");
                return;
            }

            if (!Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d{9}$"))
            {
                Validaciones.MostrarError("El teléfono debe tener 9 dígitos.");
                return;
            }

            if (!Validaciones.EsTextoValido(txtDireccion.Text))
            {
                Validaciones.MostrarError("Ingresa la dirección.");
                return;
            }

            string ruc = txtRuc.Text.Trim();
            if (DataStore.Transportistas.Any(t => t.Ruc == ruc))
            {
                Validaciones.MostrarError("Ya existe un transportista registrado con ese RUC.");
                return;
            }

            DataStore.Transportistas.Add(new Transportista
            {
                NombreEmpresa = txtNombreEmpresa.Text.Trim(),
                Ruc = ruc,
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            });

            Validaciones.MostrarExito("Transportista registrado correctamente.");
            this.Close();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}