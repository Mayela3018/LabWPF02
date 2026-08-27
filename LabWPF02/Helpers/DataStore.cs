using System.Collections.Generic;
using LabWPF02.Models;

namespace LabWPF02.Helpers
{
    public static class DataStore
    {
        public static List<Usuario> Usuarios = new List<Usuario>
        {
            new Usuario { NombreUsuario = "admin", Password = "1234" }
        };

        public static List<Conductor> Conductores = new List<Conductor>();
        public static List<Ingreso> Ingresos = new List<Ingreso>();
        public static List<Transportista> Transportistas = new List<Transportista>();
        public static List<Camion> Camiones = new List<Camion>();
        public static List<Producto> Productos = new List<Producto>();
        public static List<Salida> Salidas = new List<Salida>();
    }
}