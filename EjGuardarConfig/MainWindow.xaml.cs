using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace EjGuardarConfig
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarValores();
        }

        private void CargarValores()
        {
            // Obtener el valor del archivo de configuración clásico
            string valorArchivoConfiguracion = LeerValorArchivoConfiguracion();
            TextoValorConfiguracion.Text = valorArchivoConfiguracion;

            // Obtener el valor del App.config
            string valorAppConfig = ObtenerValorAppConfig();
            TextoValorAppConfig.Text = valorAppConfig;
        }

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
                valor = "Estoy en el MainWindows.xaml.cs";
                File.WriteAllText(rutaArchivoConfiguracion, valor);
            }

            return valor;
        }

        private string ObtenerValorAppConfig()
        {
            string valor = ConfigurationManager.AppSettings["MiClave"];

            return valor;
        }
    }
}