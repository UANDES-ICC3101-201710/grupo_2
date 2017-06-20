using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Runtime.CompilerServices;


namespace Entrega3
{
    /// <summary>
    /// Lógica de interacción para Tablero.xaml
    /// </summary>
    public partial class Tablero : Window
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

        public Tablero(Jugador Jugador1, Jugador Jugador2)
        {
            InitializeComponent();
            this.Jugador1 = Jugador1;
            this.Jugador2 = Jugador2;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Jugador1.turno > Jugador2.turno)
            {
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
                List<string> Tablero1 = new List<string>();
                Tablero1.Clear();
                while (b < Jugador2.tablero.Count())
                {
                    Tablero1.Add(Jugador2.tablero[b].nombre + "|" + Jugador2.tablero[b].ataque + "|" + Jugador2.tablero[b].vida + "|" + Jugador2.tablero[b].costo);
                    b += 1;
                }
                TableroRival.ItemsSource = Tablero1;
                int c = 0;
                List<string> Tablero2 = new List<string>();
                Tablero2.Clear();
                while (c < Jugador1.tablero.Count())
                {
                    Tablero1.Add(Jugador1.tablero[c].nombre + "|" + Jugador1.tablero[c].ataque + "|" + Jugador1.tablero[c].vida + "|" + Jugador1.tablero[c].costo);
                    c += 1;
                }
                TableroTablero.ItemsSource = Tablero2;
                NombreJugadorShow.Visibility = System.Windows.Visibility.Visible;
                NombreJugadorShow.Content = "Turno de " + Jugador1.nombre;
                VidaJugador.Visibility = System.Windows.Visibility.Visible;
                VidaJugador.Content = "Tienes " + Jugador1.vida + " puntos de vida.";
                VidaJugadorOponente.Visibility = System.Windows.Visibility.Visible;
                VidaJugadorOponente.Content = "Tu oponente tiene " + Jugador2.vida + " puntos de vida.";
                ManaTurnoLabel.Visibility = System.Windows.Visibility.Visible;
                ManaTurnoLabel.Content = "Tienes " + Jugador1.mana.ToString() + "puntos de mana"; //Hay que ver como ponemos esto, tiene que ser mana turno
                BotonEmpezar.Visibility = System.Windows.Visibility.Hidden;
                BotonPasarTurno1a2.Visibility = System.Windows.Visibility.Visible;
                ListMano.Visibility = System.Windows.Visibility.Visible;
                BotonPoder.Visibility = System.Windows.Visibility.Visible;
                BotonJugarCarta1.Visibility = System.Windows.Visibility.Visible;
                BotonAtacar.Visibility = System.Windows.Visibility.Visible;
                JuegoActual.Visibility = System.Windows.Visibility.Visible;
                ManoActual.Visibility = System.Windows.Visibility.Visible;
                TableroLabel.Visibility = System.Windows.Visibility.Visible;
                TableroRivalLabel.Visibility = System.Windows.Visibility.Visible;
                TableroTablero.Visibility = System.Windows.Visibility.Visible;
                TableroRival.Visibility = System.Windows.Visibility.Visible;
            }

            else
            {
                int a = 0;
                List<string> ManoTurno = new List<string>();
                ManoTurno.Clear();
                while (a < Jugador2.mano.Count())
                {
                    ManoTurno.Add(Jugador2.mano[a].nombre + "|" + Jugador2.mano[a].ataque + "|" + Jugador2.mano[a].vida + "|" + Jugador2.mano[a].costo);
                    a += 1;
                }
                ListMano.ItemsSource = ManoTurno;

                int b = 0;
                List<string> Tablero1 = new List<string>();
                Tablero1.Clear();
                while (b < Jugador2.tablero.Count())
                {
                    Tablero1.Add(Jugador2.tablero[b].nombre + "|" + Jugador2.tablero[b].ataque + "|" + Jugador2.tablero[b].vida + "|" + Jugador2.tablero[b].costo);
                    b += 1;
                }
                TableroTablero.ItemsSource = Tablero1;
                int c = 0;
                List<string> Tablero2 = new List<string>();
                Tablero2.Clear();
                while (c < Jugador1.tablero.Count())
                {
                    Tablero1.Add(Jugador1.tablero[c].nombre + "|" + Jugador1.tablero[c].ataque + "|" + Jugador1.tablero[c].vida + "|" + Jugador1.tablero[c].costo);
                    c += 1;
                }
                TableroRival.ItemsSource = Tablero2;
                NombreJugadorShow.Visibility = System.Windows.Visibility.Visible;
                NombreJugadorShow.Content = "Turno de " + Jugador2.nombre;
                VidaJugador.Visibility = System.Windows.Visibility.Visible;
                VidaJugador.Content = "Tienes " + Jugador2.vida + " puntos de vida.";
                VidaJugadorOponente.Visibility = System.Windows.Visibility.Visible;
                VidaJugadorOponente.Content = "Tu oponente tiene " + Jugador1.vida + " puntos de vida.";
                ManaTurnoLabel.Visibility = System.Windows.Visibility.Visible;
                ManaTurnoLabel.Content = "Tienes " + Jugador2.mana.ToString() + " puntos de mana"; //Hay que ver como ponemos esto, tiene que ser mana turno
                BotonEmpezar.Visibility = System.Windows.Visibility.Hidden;
                BotonPasarTurno2a1.Visibility = System.Windows.Visibility.Visible;
                ListMano.Visibility = System.Windows.Visibility.Visible;
                BotonPoder.Visibility = System.Windows.Visibility.Visible;
                BotonJugarCarta2.Visibility = System.Windows.Visibility.Visible;
                BotonAtacar.Visibility = System.Windows.Visibility.Visible;
                JuegoActual.Visibility = System.Windows.Visibility.Visible;
                ManoActual.Visibility = System.Windows.Visibility.Visible;
                TableroLabel.Visibility = System.Windows.Visibility.Visible;
                TableroRivalLabel.Visibility = System.Windows.Visibility.Visible;
                TableroTablero.Visibility = System.Windows.Visibility.Visible;
                TableroRival.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> ManoTurno = new List<string>();
            ManoTurno.Clear(); 
            int a = 0;
            while (a < Jugador2.mano.Count())
            {
                ManoTurno.Add(Jugador2.mano[a].nombre +"|" + Jugador2.mano[a].ataque+"|" + Jugador2.mano[a].vida + "|" + Jugador2.mano[a].costo );
                a += 1;
            }
            ListMano.ItemsSource = ManoTurno;
            int b = 0;
            List<string> Tablero1 = new List<string>();
            Tablero1.Clear();
            while (b < Jugador2.tablero.Count())
            {
                Tablero1.Add(Jugador2.tablero[b].nombre + "|" + Jugador2.tablero[b].ataque + "|" + Jugador2.tablero[b].vida + "|" + Jugador2.tablero[b].costo);
                b += 1;
            }
            TableroTablero.ItemsSource = Tablero1;
            int c = 0;
            List<string> Tablero2 = new List<string>();
            Tablero2.Clear();
            while (c < Jugador1.tablero.Count())
            {
                Tablero1.Add(Jugador1.tablero[c].nombre + "|" + Jugador1.tablero[c].ataque + "|" + Jugador1.tablero[c].vida + "|" + Jugador1.tablero[c].costo);
                c += 1;
            }
            TableroRival.ItemsSource = Tablero2;
            Jugador2.ManaGrowth();
            NombreJugadorShow.Content = "Turno de " + Jugador2.nombre;
            VidaJugador.Content = "Tienes " + Jugador2.vida + " puntos de vida.";
            VidaJugadorOponente.Content = "Tu oponente tiene " + Jugador1.vida + " puntos de vida.";
            ManaTurnoLabel.Content = "Tienes " + Jugador2.mana.ToString() + " puntos de mana"; //Hay que ver como ponemos esto, tiene que ser mana turno
            BotonPasarTurno1a2.Visibility = System.Windows.Visibility.Hidden;
            BotonPasarTurno2a1.Visibility = System.Windows.Visibility.Visible;
            Jugador2.turno += 2;
        }

        private void BotonPasarTurno2a1_Click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            List<string> ManoTurno = new List<string>();
            ManoTurno.Clear();
            while (a < Jugador1.mano.Count())
            {
                ManoTurno.Add(Jugador1.mano[a].nombre + "|" + Jugador1.mano[a].ataque + "|" + Jugador1.mano[a].vida + "|" + Jugador1.mano[a].costo);
                a += 1;
            }

            int b = 0;
            List<string> Tablero1 = new List<string>();
            Tablero1.Clear();
            while (b < Jugador2.tablero.Count())
            {
                Tablero1.Add(Jugador2.tablero[b].nombre + "|" + Jugador2.tablero[b].ataque + "|" + Jugador2.tablero[b].vida + "|" + Jugador2.tablero[b].costo);
                b += 1;
            }
            TableroRival.ItemsSource = Tablero1;
            int c = 0;
            List<string> Tablero2 = new List<string>();
            Tablero2.Clear();
            while (c < Jugador1.tablero.Count())
            {
                Tablero1.Add(Jugador1.tablero[c].nombre + "|" + Jugador1.tablero[c].ataque + "|" + Jugador1.tablero[c].vida + "|" + Jugador1.tablero[c].costo);
                c += 1;
            }
            TableroTablero.ItemsSource = Tablero2;
            ListMano.ItemsSource = ManoTurno;
            Jugador1.ManaGrowth();
            Jugador1.turno += 2;
            BotonPasarTurno2a1.Visibility = System.Windows.Visibility.Hidden;
            BotonPasarTurno1a2.Visibility = System.Windows.Visibility.Visible;
            NombreJugadorShow.Content = "Turno de " + Jugador1.nombre;
            VidaJugador.Content = "Tienes " + Jugador1.vida + " puntos de vida.";
            VidaJugadorOponente.Content = "Tu oponente tiene " + Jugador2.vida + " puntos de vida.";
            ManaTurnoLabel.Content = "Tienes " + Jugador1.mana.ToString() + "puntos de mana"; //Hay que ver como ponemos esto, tiene que ser mana turno
        }
        Cartas ReclutaManodePlata = new Entrega3.Cartas(0, 1, 1, "Recluta Mano de Plata");
        Cartas dagger = new Cartas(0, 1, 2, "dagger");
        List<Cartas> listaCartasShaman = new List<Cartas>();
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Jugador1.UsarPoder(Jugador1, Jugador2, ReclutaManodePlata,listaCartasShaman, dagger);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            VentanaJugarCarta ventana = new VentanaJugarCarta(Jugador1, Jugador2);
            ventana.Show();
            this.Close();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            VentanaJugarCarta ventana = new VentanaJugarCarta(Jugador2, Jugador1);
            ventana.Show();
            this.Close();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Ventana_Atacar ventana = new Ventana_Atacar(Jugador1, Jugador2);
            ventana.Show();
            this.Close();

        }

        
    }
}
