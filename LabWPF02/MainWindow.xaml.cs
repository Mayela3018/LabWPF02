using System.Linq;
using System.Windows;
using LabWPF02.Helpers;
using LabWPF02.Views;

namespace LabWPF02
{
    public partial class MainWindow : Window
    {
        private int intentosFallidos = 0;
        private const int MaxIntentos = 3;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMostrarPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPasswordVisible.Text = txtPassword.Password;
            txtPasswordVisible.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
        }

        private void BtnMostrarPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = txtPasswordVisible.Text;
            txtPassword.Visibility = Visibility.Visible;
            txtPasswordVisible.Visibility = Visibility.Collapsed;
        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = (txtPasswordVisible.Visibility == Visibility.Visible
                ? txtPasswordVisible.Text
                : txtPassword.Password).Trim();

            if (!Validaciones.EsTextoValido(usuario) || !Validaciones.EsTextoValido(password))
            {
                Validaciones.MostrarError("Ingresa usuario y contraseña.");
                return;
            }

            var usuarioValido = DataStore.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == usuario && u.Password == password);

            if (usuarioValido == null)
            {
                intentosFallidos++;

                if (intentosFallidos >= MaxIntentos)
                {
                    Validaciones.MostrarError(
                        $"Usuario o contraseña incorrectos. Superaste el límite de {MaxIntentos} intentos.",
                        "Acceso bloqueado");
                    btnIngresar.IsEnabled = false;
                    return;
                }

                Validaciones.MostrarError(
                    $"Usuario o contraseña incorrectos. Intento {intentosFallidos} de {MaxIntentos}.");
                txtPassword.Clear();
                txtPasswordVisible.Clear();
                return;
            }

            intentosFallidos = 0;
            MenuWindow menu = new MenuWindow();
            menu.Show();
            this.Close();
        }
    }
}