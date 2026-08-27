using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace LabWPF02.Helpers
{
    public static class Validaciones
    {
        public static bool EsTextoValido(string texto)
        {
            return !string.IsNullOrWhiteSpace(texto);
        }

        public static bool EsPlacaValida(string placa)
        {
            if (!EsTextoValido(placa)) return false;
            return Regex.IsMatch(placa.Trim().ToUpper(), @"^[A-Z]{3}-\d{3}$");
        }

        public static bool EsLicenciaValida(string licencia)
        {
            if (!EsTextoValido(licencia)) return false;
            return Regex.IsMatch(licencia.Trim().ToUpper(), @"^[A-Z]\d{8}$");
        }

        public static bool EsDocumentoValido(string tipoDocumento, string numeroDocumento)
        {
            if (!EsTextoValido(numeroDocumento)) return false;
            string numero = numeroDocumento.Trim();

            if (tipoDocumento == "DNI")
                return Regex.IsMatch(numero, @"^\d{8}$");

            if (tipoDocumento == "RUC")
                return Regex.IsMatch(numero, @"^\d{11}$");

            return Regex.IsMatch(numero, @"^[A-Za-z0-9]{6,12}$");
        }

        public static bool EsNumeroPositivo(string texto, out double valor)
        {
            return double.TryParse(texto, out valor) && valor > 0;
        }

        public static bool EsHoraValida(string texto, out TimeSpan hora)
        {
            return TimeSpan.TryParseExact(texto?.Trim(), "hh\\:mm",
                System.Globalization.CultureInfo.InvariantCulture, out hora);
        }

        public static void MostrarError(string mensaje, string titulo = "Validación")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void MostrarExito(string mensaje, string titulo = "Éxito")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}