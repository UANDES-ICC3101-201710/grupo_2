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

namespace Entrega3
{
    /// <summary>
    /// Lógica de interacción para Tablero.xaml
    /// </summary>
    public partial class Tablero : Window
    {
        public Jugador Jugador1
        {
            get
            {
                return Jugador1;
            }

            set
            {
                Jugador1 = value;
            }
        }
        MainWindow tablero = new MainWindow();
        public Tablero(Jugador Jugador1)
        {
            InitializeComponent();
            this.Jugador1 = Jugador1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
