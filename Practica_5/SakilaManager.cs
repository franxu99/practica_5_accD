using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Practica_5
{
    // This class implements INotifyPropertyChanged
    // to support one-way and two-way bindings
    // (such that the UI element updates when the source
    // has been changed dynamically)
    public class SakilaManager : INotifyPropertyChanged
    {
        

        //Campos privados
        private int _sumador;
        private int _numeroPeliculas;
        private int _resX;
        private int _resY;

        // Declarar el evento para MVVM
        public event PropertyChangedEventHandler PropertyChanged;

        public AccesoDatos _ad = new AccesoDatos();

        public int NumeroPeliculas
        {
            get { return _numeroPeliculas; }
            set 
            {
                _numeroPeliculas = value;
                OnPropertyChanged("NumeroPeliculas");
            }
        }
        public int Sumador
        {
            get { return _sumador; }
            set
            {
                _sumador = value;
                OnPropertyChanged("Sumador");
            }
        }

        public int ResX
        {
            get { return _resX; }
            set
            {
                _resX = value;
                OnPropertyChanged("ResX");
            }
        }
        public int ResY
        {
            get { return _resY; }
            set
            {
                _resY = value;
                OnPropertyChanged("ResY");
            }
        }

        //Constructor

        public SakilaManager()
        {
            _numeroPeliculas = 0;
            _sumador = 0;
            _resX = 1024;
            _resY = 768;
        }

        //Metodos (de Negocio)

        public void Login(string usuario, string pass)
        {
            //Comprobaciones previas

            if (_ad.Login(usuario, pass) == 0)
            {
                MessageBox.Show("Bienvenid@");
            }
            else
            {
                MessageBox.Show("Error de Login");
            }


        }

        public void Registrar(string nombre, string apellido, string mail, int id_tienda,
                                string usuario, string pass)
        {
            //Comprobaciones previas

            if (_ad.AltaEmpleado(nombre, apellido, mail, id_tienda, usuario, pass) == 0)
            {
                MessageBox.Show("Bienvenid@");
            }
            else
            {
                MessageBox.Show("Error de Login");
            }


        }

        public void ActualizarNumeroPeliculas()
        {
            NumeroPeliculas = _ad.DameNumeroPeliculas();
        }


        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}