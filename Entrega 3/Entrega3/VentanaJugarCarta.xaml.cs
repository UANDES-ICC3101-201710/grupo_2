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
    /// Lógica de interacción para VentanaJugarCarta.xaml
    /// </summary>
    public partial class VentanaJugarCarta : Window
    {
        public Jugador Jugador1
        {
            get;
            set;

        }
        public Jugador Jugador2
        {
            get;
            set;
        }
        public VentanaJugarCarta(Jugador Jugador1, Jugador Jugador2)
        {
            InitializeComponent();
            this.Jugador1 = Jugador1;
            this.Jugador2 = Jugador2;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Jugador1.JugarCartas(Jugador1.mano, Jugador1.tablero, Int32.Parse(CartaAJugar.Text), Jugador1.manaTurno);
            Tablero tablero = new Tablero(Jugador1, Jugador2);
            tablero.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tablero tablero = new Tablero(Jugador1, Jugador2);
            tablero.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LabelMano.Visibility = System.Windows.Visibility.Visible;
            ListMano.Visibility = System.Windows.Visibility.Visible;
            ListTablero.Visibility = System.Windows.Visibility.Visible;
            LabelInstrucciones.Visibility = System.Windows.Visibility.Visible;
            CartaAJugar.Visibility = System.Windows.Visibility.Visible;
            BotonJugarCarta.Visibility = System.Windows.Visibility.Visible;
            BotonMenu.Visibility = System.Windows.Visibility.Visible;
            BotonEnorme.Visibility = System.Windows.Visibility.Hidden;
            int a = 0;
            List<string> ManoTurno = new List<string>();
            ManoTurno.Clear();
            while (a < Jugador1.mano.Count())
            {
                ManoTurno.Add(Jugador1.mano[a].nombre + "|" + Jugador1.mano[a].ataque + "|" + Jugador1.mano[a].vida + "|" + Jugador1.mano[a].costo);
                a += 1;
            }
            ListMano.ItemsSource = ManoTurno;


            int b = 0;
            List<string> TableroTurno = new List<string>();
            TableroTurno.Clear();
            while (b < Jugador1.tablero.Count())
            {
                TableroTurno.Add(Jugador1.tablero[b].nombre + " | " + Jugador1.tablero[b].ataque + " | " + Jugador1.tablero[b].vida + " | " + Jugador1.tablero[b].costo);
                b += 1;
            }
            ListTablero.ItemsSource = TableroTurno;
        }
    }
}
