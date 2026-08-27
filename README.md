# 🚛 Sistema de Control de Ingresos

Aplicación de escritorio desarrollada en **WPF (.NET)** para el control de ingresos y salidas de una empresa de transporte de carga. Proyecto del curso *Desarrollo de Aplicaciones Empresariales Avanzadas* — Semana 02 (Tecsup).

## 📋 Descripción

El sistema permite gestionar el flujo completo de una empresa de transporte: registro de vehículos que ingresan y salen, administración de conductores, transportistas, camiones y productos, además de reportes con filtros de búsqueda.

## ✨ Características

- 🔐 **Login** con validación de credenciales y bloqueo tras 3 intentos fallidos
- 📊 **Dashboard** principal con estadísticas en tiempo real
- 📥 **Operaciones**: registro de Ingresos y Salidas
- 🛠️ **Mantenimientos**: Conductores, Transportistas, Camiones y Productos (registro y listado)
- 📈 **Reportes**: Ingresos, Salidas y Cargas, con filtros por fecha, placa, conductor y producto
- ✅ Validaciones de formato en tiempo real (DNI, RUC, placas, licencias)
- 🎨 Interfaz moderna con estilos centralizados y diseño responsivo

## 🛠️ Tecnologías

- **C# / WPF** (.NET)
- **XAML** para la interfaz gráfica
- Almacenamiento en memoria (listas de C#) — sin base de datos

## 📁 Estructura del proyecto

LabWPF02/
├── Models/ → Clases de datos (Usuario, Conductor, Ingreso, Camion, etc.)

├── Views/ → Ventanas de la aplicación (Login, Menú, formularios, reportes)

├── Helpers/ → Validaciones.cs y DataStore.cs (lógica reutilizable)

├── App.xaml → Estilos y paleta de colores centralizados

└── MainWindow.xaml → Ventana de inicio de sesión

## 📸 Capturas

### Login
<img width="1097" height="630" alt="LOGIN-T" src="https://github.com/user-attachments/assets/2155217e-b033-4b90-8274-e3df4c51fa42" />

### Panel Principal
<img width="1172" height="792" alt="Menuprincipal-12" src="https://github.com/user-attachments/assets/a63cc06d-8045-44f9-bdfe-a04d1d00b8c4" />




## 🚀 Cómo ejecutar el proyecto

1. Clona este repositorio
```bash
   git clone https://github.com/Mayela3018/LabWPF02.git
```
2. Ábrelo con **Visual Studio 2022** o superior
3. Restaura las dependencias (si es necesario):
```bash
   dotnet restore
```
4. Compila y ejecuta con `F5`

**Usuario de prueba:** `admin` — **Contraseña:** `1234`

## 👤 Autor

**MAYELA** — Estudiante de Diseño y Desarrollo de Software, Tecsup
