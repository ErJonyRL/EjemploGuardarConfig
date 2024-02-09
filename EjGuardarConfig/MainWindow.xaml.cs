using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace EjGuardarConfig
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor de la clase MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            CargarValores();
        }

        /// <summary>
        /// Método para cargar los valores de configuración en los cuadros de texto.
        /// </summary>
        private void CargarValores()
        {
            // Obtener el valor del archivo de configuración clásico
            string valorArchivoConfiguracion = LeerValorArchivoConfiguracion();
            TextoValorConfiguracion.Text = valorArchivoConfiguracion;

            // Obtener el valor del App.config
            string valorAppConfig = ObtenerValorAppConfig();
            TextoValorAppConfig.Text = valorAppConfig;
        }

        /// <summary>
        /// Método para leer el valor del archivo de configuración clásico.
        /// Si el archivo no existe, se crea y se escribe un valor predeterminado.
        /// </summary>
        /// <returns>El valor leído o predeterminado.</returns>
        private string LeerValorArchivoConfiguracion()
        {
            string rutaArchivoConfiguracion = "config.txt";
            string valor = "";
            
            if (File.Exists(rutaArchivoConfiguracion))
            {
                valor = File.ReadAllText(rutaArchivoConfiguracion);
            }
            else
            {
                // Si el archivo no existe, creamos uno nuevo y asignamos un valor predeterminado
                valor = "Estoy en el MainWindows.xaml.cs";
                File.WriteAllText(rutaArchivoConfiguracion, valor);
            }

            return valor;
        }

        /// <summary>
        /// Método para obtener el valor del App.config.
        /// </summary>
        /// <returns>El valor obtenido del App.config.</returns>
        private string ObtenerValorAppConfig()
        {
            string valor = ConfigurationManager.AppSettings["MiClave"];

            return valor;
        }
    }
}
