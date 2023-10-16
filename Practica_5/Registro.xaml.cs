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
using System.Windows.Shapes;

namespace Practica_5
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }
        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Crear_Click(object sender, RoutedEventArgs e)
        {
            AccesoDatos ad = new AccesoDatos();
            int itemStore = 0;
            if (cbStore.SelectedIndex == 0)
            {
                itemStore = 1;
            }
            else if (cbStore.SelectedIndex == 1) 
            { 
                itemStore = 2;
            }
            
            if(txtPsw.Password != txtConfirmPsw.Password) 
            {
                MessageBox.Show("Las contraseñas deben coincidir");
            }
            else 
            {
                int res = ad.AltaEmpleado(txtName.Text, txtLastName.Text, txtEmail.Text, itemStore, txtUserName.Text, txtPsw.Password);
                if(res == 0) 
                {
                    MessageBox.Show("Introducido con exito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
    }
}
