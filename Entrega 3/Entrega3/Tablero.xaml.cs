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
            get;
            set;
        }
        public Jugador Jugador2
        {
            get;
            set;
        }
        MainWindow tablero = new MainWindow();
        public Tablero(Jugador Jugador1, Jugador Jugador2)
        {
            InitializeComponent();
            this.Jugador1 = Jugador1;
            this.Jugador2 = Jugador2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Jugador1.ManaGrowth();
            NombreJugadorShow.Visibility = System.Windows.Visibility.Visible;
            NombreJugadorShow.Content = "Turno de "+ Jugador1.nombre;
            VidaJugador.Visibility = System.Windows.Visibility.Visible;
            VidaJugador.Content = "Tienes " + Jugador1.vida + " puntos de vida.";
            VidaJugadorOponente.Visibility = System.Windows.Visibility.Visible;
            VidaJugadorOponente.Content = "Tu oponente tiene " + Jugador2.vida + " puntos de vida.";
            ManaTurnoLabel.Visibility = System.Windows.Visibility.Visible;
            ManaTurnoLabel.Content = "Tienes "+ Jugador1.mana.ToString() + "puntos de mana"; //Hay que ver como ponemos esto, tiene que ser mana turno
            BotonEmpezar.Visibility = System.Windows.Visibility.Hidden;
            BotonPasarTurno1a2.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Jugador2.ManaGrowth();
            NombreJugadorShow.Content = "Turno de " + Jugador2.nombre;
            VidaJugador.Content = "Tienes " + Jugador2.vida + " puntos de vida.";
            VidaJugadorOponente.Content = "Tu oponente tiene " + Jugador1.vida + " puntos de vida.";
            ManaTurnoLabel.Content = "Tienes " + Jugador2.mana.ToString() + "puntos de mana"; //Hay que ver como ponemos esto, tiene que ser mana turno
            BotonPasarTurno1a2.Visibility = System.Windows.Visibility.Hidden;
            BotonPasarTurno2a1.Visibility = System.Windows.Visibility.Visible;
        }

        private void BotonPasarTurno2a1_Click(object sender, RoutedEventArgs e)
        {
            Jugador1.ManaGrowth();
            BotonPasarTurno2a1.Visibility = System.Windows.Visibility.Hidden;
            BotonPasarTurno1a2.Visibility = System.Windows.Visibility.Visible;
            NombreJugadorShow.Content = "Turno de " + Jugador1.nombre;
            VidaJugador.Content = "Tienes " + Jugador1.vida + " puntos de vida.";
            VidaJugadorOponente.Content = "Tu oponente tiene " + Jugador2.vida + " puntos de vida.";
            ManaTurnoLabel.Content = "Tienes " + Jugador1.mana.ToString() + "puntos de mana"; //Hay que ver como ponemos esto, tiene que ser mana turno
        }
    }
}
