using System.Windows;
using System.Windows.Controls;

namespace xabiOFICIAL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Verificar si hay sesión activa
            if (SesionManager.UsuarioLogueado != null)
            {
                // Si hay sesión, ir directamente a InicioPage
                MainFrame.Navigate(new InicioPage());
            }
            else
            {
                // Si no hay sesión, mostrar LoginPage
                MainFrame.Navigate(new LoginPage());
            }
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new InicioPage());
        }

        private void BtnEmpleo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmpleoPage());
        }

        private void BtnNoticias_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new NoticiasPage());
        }

        private void BtnCoches_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CochesPage());
        }
    }
}