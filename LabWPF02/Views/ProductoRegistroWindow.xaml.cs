using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LabWPF02.Helpers;
using LabWPF02.Models;

namespace LabWPF02.Views
{
    public partial class ProductoRegistroWindow : Window
    {
        public ProductoRegistroWindow()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!Validaciones.EsTextoValido(txtNombre.Text))
            {
                Validaciones.MostrarError("Ingresa el nombre del producto.");
                return;
            }

            if (!Validaciones.EsTextoValido(txtCategoria.Text))
            {
                Validaciones.MostrarError("Ingresa la categoría del producto.");
                return;
            }

            if (cmbUnidad.SelectedItem == null)
            {
                Validaciones.MostrarError("Selecciona una unidad de medida.");
                return;
            }

            string nombre = txtNombre.Text.Trim();
            if (DataStore.Productos.Any(p => p.Nombre.ToLower() == nombre.ToLower()))
            {
                Validaciones.MostrarError("Ya existe un producto registrado con ese nombre.");
                return;
            }

            DataStore.Productos.Add(new Producto
            {
                Nombre = nombre,
                Categoria = txtCategoria.Text.Trim(),
                UnidadMedida = ((ComboBoxItem)cmbUnidad.SelectedItem).Content.ToString()
            });

            Validaciones.MostrarExito("Producto registrado correctamente.");
            this.Close();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}