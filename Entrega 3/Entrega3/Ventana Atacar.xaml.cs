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
    /// Lógica de interacción para Ventana_Atacar.xaml
    /// </summary>
    public partial class Ventana_Atacar : Window
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
        public Ventana_Atacar(Jugador Jugador1, Jugador Jugador2)
        {
            InitializeComponent();
            this.Jugador1 = Jugador1;
            this.Jugador2 = Jugador2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tablero tablero = new Tablero(Jugador1, Jugador2);
            tablero.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TuTablero.Visibility = System.Windows.Visibility.Visible;
            TableroRival.Visibility = System.Windows.Visibility.Visible;
            Intrucciones1.Visibility = System.Windows.Visibility.Visible;
            Intrucciones2.Visibility = System.Windows.Visibility.Visible;
            TextAtacante.Visibility = System.Windows.Visibility.Visible;
            TextDefensor.Visibility = System.Windows.Visibility.Visible;
            BotonAtacar.Visibility = System.Windows.Visibility.Visible;
            TuTableroLabel.Visibility = System.Windows.Visibility.Visible;
            TableroRivalLabel.Visibility = System.Windows.Visibility.Visible;
            BotonMenu.Visibility = System.Windows.Visibility.Visible;
            BotonGrande.Visibility = System.Windows.Visibility.Hidden;
            int a = 0;
            List<string> Tablero1 = new List<string>();
            Tablero1.Clear();
            while (a < Jugador1.tablero.Count())
            {
                Tablero1.Add(Jugador1.tablero[a].nombre + "|" + Jugador1.tablero[a].ataque + "|" + Jugador1.tablero[a].vida + "|" + Jugador1.tablero[a].costo);
                a += 1;
            }
            TuTablero.ItemsSource = Tablero1;


            int b = 0;
            List<string> Tablero2 = new List<string>();
            Tablero2.Clear();
            while (b < Jugador2.tablero.Count())
            {
                Tablero2.Add(Jugador2.tablero[b].nombre + " | " + Jugador2.tablero[b].ataque + " | " + Jugador2.tablero[b].vida + " | " + Jugador2.tablero[b].costo);
                b += 1;
            }
            TableroRival.ItemsSource = Tablero2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Jugador1.AtacarCarta(Jugador1.tablero, Int32.Parse(TextAtacante.Text), Jugador2.tablero, Int32.Parse(TextDefensor.Text));
            Tablero tablero = new Tablero(Jugador1, Jugador2);
            tablero.Show();
            this.Close();
        }
    }
}
