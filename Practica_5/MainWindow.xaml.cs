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

namespace Practica_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccesoDatos ad = new AccesoDatos();
        public MainWindow()
        {
            InitializeComponent();
            numFilm.Text = ad.DameNumeroPeliculas().ToString();
        }

        private void click_register(object sender, RoutedEventArgs e)
        {
            Registro reg = new Registro();
            reg.Show();
        }

        private void click_enter(object sender, RoutedEventArgs e)
        {
            int res = ad.Login(txtUser.Text, txtPsw.Password);
            if(res == 0)
            {
                MessageBox.Show("Has iniciado sesión");
            }
            else
            {
                MessageBox.Show("Error en el inicio de sesión");
            }
        }
    }
}
