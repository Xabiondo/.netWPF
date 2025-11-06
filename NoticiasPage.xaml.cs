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
    public partial class NoticiasPage : Page
    {
        public NoticiasPage()
        {
            InitializeComponent();
        }

        private void BtnVerNoticia_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DetalleNoticiaPage());
        }
    }
}