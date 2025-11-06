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
    public partial class SignupPage : Page
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            string usuario = TxtUsuario.Text;
            string correo = TxtCorreo.Text;
            string contrasena = TxtContrasena.Password;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (RegistrarUsuario(usuario, correo, contrasena))
            {
                MessageBox.Show("Usuario registrado exitosamente.");
                this.NavigationService.Navigate(new LoginPage());
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario. Puede que el nombre o correo ya estén en uso.");
            }
        }

        private bool RegistrarUsuario(string usuario, string correo, string contrasena)
        {
            using (MySqlConnection conexion = ConexionDB.ObtenerConexion())
            {
                string query = "INSERT INTO Usuarios (Usuario, Correo, Contrasena) VALUES (@usuario, @correo, @contrasena)";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException)
                {
                    return false; // Puede ser por clave duplicada
                }
            }
        }

        private void BtnIrALogin_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}