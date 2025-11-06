using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace xabiOFICIAL
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuario = TxtUsuario.Text;
            string contrasena = TxtContrasena.Password;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (ValidarUsuario(usuario, contrasena))
            {
                // Si es correcto, navega a la página principal (por ejemplo, InicioPage)
                if (this.NavigationService != null)
                    this.NavigationService.Navigate(new InicioPage());
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private bool ValidarUsuario(string usuario, string contrasena)
        {
            using (MySqlConnection conexion = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @contrasena";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void BtnIrASignup_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SignupPage());
        }
    }
}