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

namespace Entrega4WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int turno;
        public MainWindow()
        {
            Random rmd = new Random();
            int turno = rmd.Next(0, 1);
            InitializeComponent();
        }

        List<Jugador> ListaJugadores = new List<Jugador>();
        public void JugarCartas(Jugador JugadorVoid, int cartaAJugar)
        {
            if (JugadorVoid.mano[cartaAJugar - 1].nombre == "the coin")
            {
                JugadorVoid.manaTurno += 1;
                JugadorVoid.mano.Remove(JugadorVoid.mano[cartaAJugar - 1]);
                JugadorVoid.manoDisponible.Remove(JugadorVoid.manoDisponible[cartaAJugar - 1]);
                ManaP2.Content = null;
                ManaP2.Content = "Mana: " + JugadorVoid.manaTurno;
                ListBoxManoP2.ItemsSource = null;
                ListBoxManoP2.ItemsSource = JugadorVoid.manoDisponible;
            }
            else
            {
                if (JugadorVoid.manaTurno >= JugadorVoid.mano[cartaAJugar - 1].costo)
                {
                    JugadorVoid.manaTurno -= JugadorVoid.mano[cartaAJugar - 1].costo;
                    JugadorVoid.tablero.Add(JugadorVoid.mano[cartaAJugar - 1]);
                    JugadorVoid.tableroDisponible.Add(JugadorVoid.mano[cartaAJugar - 1].nombre + " | " + JugadorVoid.mano[cartaAJugar - 1].vida + " | " + JugadorVoid.mano[cartaAJugar - 1].ataque + " | " + JugadorVoid.mano[cartaAJugar - 1].costo);
                    ListBoxTuTableroP2.ItemsSource = null;
                    ListBoxTuTableroP2.ItemsSource = JugadorVoid.tableroDisponible;
                    JugadorVoid.manoDisponible.Remove(JugadorVoid.manoDisponible[cartaAJugar - 1]);
                    ListBoxManoP2.ItemsSource = null;
                    ListBoxManoP2.ItemsSource = JugadorVoid.manoDisponible;
                    JugadorVoid.mano.Remove(JugadorVoid.mano[cartaAJugar - 1]);
                    ManaP2.Content = "Mana: " + JugadorVoid.manaTurno;
                }
                else
                {
                    LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Visible;
                    LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }
        public static void crearMano(Jugador Jugador1, Jugador Jugador2, int turno, Cartas theCoin)
        {
            Random rmd = new Random();
            if (turno == 0)
            {
                while (Jugador1.mano.Count < 3)
                {
                    int r = rmd.Next(Jugador1.mazo.Count);
                    Jugador1.mano.Add(Jugador1.mazo[r]);
                    Jugador1.mazo.Remove(Jugador1.mazo[r]);
                }
                while (Jugador2.mano.Count < 4)
                {
                    int r = rmd.Next(Jugador2.mazo.Count);
                    Jugador2.mano.Add(Jugador2.mazo[r]);
                    Jugador2.mazo.Remove(Jugador2.mazo[r]);
                }
                Jugador2.mano.Add(theCoin);
            }
            else if (turno == 1)
            {
                while (Jugador2.mano.Count < 3)
                {
                    int r = rmd.Next(Jugador2.mazo.Count);
                    Jugador2.mano.Add(Jugador2.mazo[r]);
                    Jugador2.mazo.Remove(Jugador2.mazo[r]);
                }
                while (Jugador1.mano.Count < 4)
                {
                    int r = rmd.Next(Jugador1.mazo.Count);
                    Jugador1.mano.Add(Jugador1.mazo[r]);
                    Jugador1.mazo.Remove(Jugador1.mazo[r]);
                }
                Jugador1.mano.Add(theCoin);

            }
        }
        
        public void Draw (Jugador JugadorVoid)
        {
            if (JugadorVoid.mano.Count < 10)
            {
                Random rmd = new Random();
                int cartaASacar = rmd.Next(0, JugadorVoid.mazo.Count);
                JugadorVoid.mano.Add(JugadorVoid.mazo[cartaASacar]);
                JugadorVoid.manoDisponible.Add(JugadorVoid.mazo[cartaASacar].nombre + " | " + JugadorVoid.mazo[cartaASacar].vida + " | " + JugadorVoid.mazo[cartaASacar].ataque + " | " + JugadorVoid.mazo[cartaASacar].costo);
                JugadorVoid.mazo.Remove(JugadorVoid.mazo[cartaASacar]); 
            }
        }

        public void AtacarCarta (Jugador Jugador1, Jugador Jugador2, int cartaAtacante, int cartaAtacada)
        {
            Jugador1.tablero[cartaAtacante-1].vida -= Jugador2.tablero[cartaAtacada-1].ataque;
            Jugador2.tablero[cartaAtacada-1].vida -= Jugador1.tablero[cartaAtacante-1].ataque;

            if (Jugador1.tablero[cartaAtacante-1].vida <= 0)
            {
                Jugador1.tablero.Remove(Jugador1.tablero[cartaAtacante-1]);
                Jugador1.tableroDisponible.Remove(Jugador1.tableroDisponible[cartaAtacante-1]);
            }
            else
            {
                Jugador1.tableroDisponible[cartaAtacante - 1] = Jugador1.tablero[cartaAtacante - 1].nombre + " | " + Jugador1.tablero[cartaAtacante - 1].vida + " | " + Jugador1.tablero[cartaAtacante - 1].ataque + " | " + Jugador1.tablero[cartaAtacante - 1].costo;
            }

            if (Jugador2.tablero[cartaAtacada - 1].vida <= 0)
            {
                Jugador2.tablero.Remove(Jugador2.tablero[cartaAtacada - 1]);
                Jugador2.tableroDisponible.Remove(Jugador2.tableroDisponible[cartaAtacada - 1]);
            }
            else
            {
                Jugador2.tableroDisponible[cartaAtacada - 1] = Jugador2.tablero[cartaAtacada - 1].nombre + " | " + Jugador2.tablero[cartaAtacada - 1].vida + " | " + Jugador2.tablero[cartaAtacada - 1].ataque + " | " + Jugador2.tablero[cartaAtacada - 1].costo;
            }
            ListBoxTuTableroP2.ItemsSource = null;
            ListBoxTuTableroP2.ItemsSource = Jugador1.tableroDisponible;
            ListBoxTableroRivalP2.ItemsSource = null;
            ListBoxTableroRivalP2.ItemsSource = Jugador2.tableroDisponible;
        }



        private void BotonComenzarP1_Click(object sender, RoutedEventArgs e)
        {
            if ((TextBoxIngresarHeroesJ1P1.Text != "Druid") && (TextBoxIngresarHeroesJ1P1.Text != "Hunter") && (TextBoxIngresarHeroesJ1P1.Text != "Mage") && (TextBoxIngresarHeroesJ1P1.Text != "Paladin") && (TextBoxIngresarHeroesJ1P1.Text != "Priest") && (TextBoxIngresarHeroesJ1P1.Text != "Rogue") && (TextBoxIngresarHeroesJ1P1.Text != "Shaman") && (TextBoxIngresarHeroesJ1P1.Text != "Warlock") && (TextBoxIngresarHeroesJ1P1.Text != "Warrior") && (TextBoxIngresarHeroesJ1P1.Text != "druid") && (TextBoxIngresarHeroesJ1P1.Text != "hunter") && (TextBoxIngresarHeroesJ1P1.Text != "mage") && (TextBoxIngresarHeroesJ1P1.Text != "paladin") && (TextBoxIngresarHeroesJ1P1.Text != "priest") && (TextBoxIngresarHeroesJ1P1.Text != "rogue") && (TextBoxIngresarHeroesJ1P1.Text != "shaman") && (TextBoxIngresarHeroesJ1P1.Text != "warlock") && (TextBoxIngresarHeroesJ1P1.Text != "warrior"))
            {
                if ((TextBoxIngresarHeroesJ2P1.Text != "Druid") && (TextBoxIngresarHeroesJ2P1.Text != "Hunter") && (TextBoxIngresarHeroesJ2P1.Text != "Mage") && (TextBoxIngresarHeroesJ2P1.Text != "Paladin") && (TextBoxIngresarHeroesJ2P1.Text != "Priest") && (TextBoxIngresarHeroesJ2P1.Text != "Rogue") && (TextBoxIngresarHeroesJ2P1.Text != "Shaman") && (TextBoxIngresarHeroesJ2P1.Text != "Warlock") && (TextBoxIngresarHeroesJ2P1.Text != "Warrior") && (TextBoxIngresarHeroesJ2P1.Text != "druid") && (TextBoxIngresarHeroesJ2P1.Text != "hunter") && (TextBoxIngresarHeroesJ2P1.Text != "mage") && (TextBoxIngresarHeroesJ2P1.Text != "paladin") && (TextBoxIngresarHeroesJ2P1.Text != "priest") && (TextBoxIngresarHeroesJ2P1.Text != "rogue") && (TextBoxIngresarHeroesJ2P1.Text != "shaman") && (TextBoxIngresarHeroesJ2P1.Text != "warlock") && (TextBoxIngresarHeroesJ2P1.Text != "warrior"))
                {
                    LabelHeroeMalJ1P1.Visibility = System.Windows.Visibility.Visible;
                    LabelHeroeMalJ2P1.Visibility = System.Windows.Visibility.Visible;
                }

                else
                {
                    LabelHeroeMalJ1P1.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if ((TextBoxIngresarHeroesJ2P1.Text != "Druid") && (TextBoxIngresarHeroesJ2P1.Text != "Hunter") && (TextBoxIngresarHeroesJ2P1.Text != "Mage") && (TextBoxIngresarHeroesJ2P1.Text != "Paladin") && (TextBoxIngresarHeroesJ2P1.Text != "Priest") && (TextBoxIngresarHeroesJ2P1.Text != "Rogue") && (TextBoxIngresarHeroesJ2P1.Text != "Shaman") && (TextBoxIngresarHeroesJ2P1.Text != "Warlock") && (TextBoxIngresarHeroesJ2P1.Text != "Warrior") && (TextBoxIngresarHeroesJ2P1.Text != "druid") && (TextBoxIngresarHeroesJ2P1.Text != "hunter") && (TextBoxIngresarHeroesJ2P1.Text != "mage") && (TextBoxIngresarHeroesJ2P1.Text != "paladin") && (TextBoxIngresarHeroesJ2P1.Text != "priest") && (TextBoxIngresarHeroesJ2P1.Text != "rogue") && (TextBoxIngresarHeroesJ2P1.Text != "shaman") && (TextBoxIngresarHeroesJ2P1.Text != "warlock") && (TextBoxIngresarHeroesJ2P1.Text != "warrior"))
            {
                if ((TextBoxIngresarHeroesJ1P1.Text != "Druid") && (TextBoxIngresarHeroesJ1P1.Text != "Hunter") && (TextBoxIngresarHeroesJ1P1.Text != "Mage") && (TextBoxIngresarHeroesJ1P1.Text != "Paladin") && (TextBoxIngresarHeroesJ1P1.Text != "Priest") && (TextBoxIngresarHeroesJ1P1.Text != "Rogue") && (TextBoxIngresarHeroesJ1P1.Text != "Shaman") && (TextBoxIngresarHeroesJ1P1.Text != "Warlock") && (TextBoxIngresarHeroesJ1P1.Text != "Warrior") && (TextBoxIngresarHeroesJ1P1.Text != "druid") && (TextBoxIngresarHeroesJ1P1.Text != "hunter") && (TextBoxIngresarHeroesJ1P1.Text != "mage") && (TextBoxIngresarHeroesJ1P1.Text != "paladin") && (TextBoxIngresarHeroesJ1P1.Text != "priest") && (TextBoxIngresarHeroesJ1P1.Text != "rogue") && (TextBoxIngresarHeroesJ1P1.Text != "shaman") && (TextBoxIngresarHeroesJ1P1.Text != "warlock") && (TextBoxIngresarHeroesJ1P1.Text != "warrior"))
                {
                    LabelHeroeMalJ1P1.Visibility = System.Windows.Visibility.Visible;
                    LabelHeroeMalJ2P1.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    LabelHeroeMalJ2P1.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                TituloP1.Visibility = System.Windows.Visibility.Hidden;
                Jugador1P1.Visibility = System.Windows.Visibility.Hidden;
                Jugador2P1.Visibility = System.Windows.Visibility.Hidden;
                LabelIngresarNombreP1.Visibility = System.Windows.Visibility.Hidden;
                LabelIngresarHeroesP1.Visibility = System.Windows.Visibility.Hidden;
                TextBoxIngresarNombresJ1P1.Visibility = System.Windows.Visibility.Hidden;
                TextBoxIngresarNombresJ2P1.Visibility = System.Windows.Visibility.Hidden;
                TextBoxIngresarHeroesJ1P1.Visibility = System.Windows.Visibility.Hidden;
                TextBoxIngresarHeroesJ2P1.Visibility = System.Windows.Visibility.Hidden;
                BotonCargarPartidaP1.Visibility = System.Windows.Visibility.Hidden;
                BotonComenzarP1.Visibility = System.Windows.Visibility.Hidden;
                LabelHeroeMalJ1P1.Visibility = System.Windows.Visibility.Hidden;
                LabelHeroeMalJ2P1.Visibility = System.Windows.Visibility.Hidden;
                TurnoDeP2.Visibility = System.Windows.Visibility.Visible;
                VidaP2.Visibility = System.Windows.Visibility.Visible;
                ManaP2.Visibility = System.Windows.Visibility.Visible;
                UsarPoderP2.Visibility = System.Windows.Visibility.Visible;
                LeyendaCartasP2.Visibility = System.Windows.Visibility.Visible;
                LabelMostrarManoP2.Visibility = System.Windows.Visibility.Visible;
                LabelMostrarTuTableroP2.Visibility = System.Windows.Visibility.Visible;
                LabelMostrarTableroRivalP2.Visibility = System.Windows.Visibility.Visible;
                ListBoxManoP2.Visibility = System.Windows.Visibility.Visible;
                ListBoxTuTableroP2.Visibility = System.Windows.Visibility.Visible;
                ListBoxTableroRivalP2.Visibility = System.Windows.Visibility.Visible;
                LabelMenuAtacarP2.Visibility = System.Windows.Visibility.Visible;
                LabelInstrucciones1P2.Visibility = System.Windows.Visibility.Visible;
                CartaAtacanteP2.Visibility = System.Windows.Visibility.Visible;
                LabelInstrucciones2P2.Visibility = System.Windows.Visibility.Visible;
                CartaAtacadaP2.Visibility = System.Windows.Visibility.Visible;
                LabelMenuJugarCartaP2.Visibility = System.Windows.Visibility.Visible;
                BotonAtacarP2.Visibility = System.Windows.Visibility.Visible;
                LabelInstrucciones3P2.Visibility = System.Windows.Visibility.Visible;
                LabelInstrucciones4P2.Visibility = System.Windows.Visibility.Visible;
                CartaAJugarP2.Visibility = System.Windows.Visibility.Visible;
                BotonJugarCartaP2.Visibility = System.Windows.Visibility.Visible;
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Visible;
                BotonGuardarYSalirP2.Visibility = System.Windows.Visibility.Visible;
                BotonTerminarTurnoP2.Visibility = System.Windows.Visibility.Visible;
                List<Cartas> listaCartasShaman = new List<Cartas>();
                Cartas pichon = new Cartas(0, 0, 10000000, "pichon");
                Cartas dagger = new Cartas(0, 1, 2, "Dagger");
                Cartas wisp = new Cartas(0, 1, 1, "wisp");
                Cartas murlocRaider = new Cartas(1, 1, 2, "Murloc Raider");
                Cartas bloodfenRaptor = new Cartas(2, 3, 2, "Bloodfen Raptor");
                Cartas riverCrocolisk = new Cartas(2, 2, 3, "River CrocoLisk");
                Cartas magmaRager = new Cartas(3, 5, 1, "Magma Rager");
                Cartas chillwindYeti = new Cartas(4, 4, 5, "Chill Wind Yeti");
                Cartas oasisSnapjaw = new Cartas(4, 2, 7, "Oasis Snap Jaw");
                Cartas boulderfistOgre = new Cartas(6, 6, 7, "Boulder Fist Ogre");
                Cartas warGolem = new Cartas(7, 7, 7, "War Golem");
                Cartas coreHound = new Cartas(7, 9, 5, "Core Hound");
                Cartas theCoin = new Cartas(0, 0, 0, "the coin");
                List<Cartas> ManoJugador1 = new List<Cartas>();
                List<Cartas> ManoJugador2 = new List<Cartas>();
                List<Cartas> MazoJugador1 = new List<Cartas>();
                List<Cartas> MazoJugador2 = new List<Cartas>();
                List<Cartas> TableroJugador1 = new List<Cartas>();
                List<Cartas> TableroJugador2 = new List<Cartas>();
                List<string> ManoDisponible1 = new List<string>();
                List<string> ManoDisponible2 = new List<string>();
                List<string> TableroDisponible1 = new List<string>();
                List<string> TableroDisponible2 = new List<string>();
                MazoJugador1.Add(wisp);
                MazoJugador1.Add(wisp);
                MazoJugador1.Add(wisp);
                MazoJugador2.Add(wisp);
                MazoJugador2.Add(wisp);
                MazoJugador2.Add(wisp);
                MazoJugador1.Add(murlocRaider);
                MazoJugador1.Add(murlocRaider);
                MazoJugador1.Add(murlocRaider);
                MazoJugador2.Add(murlocRaider);
                MazoJugador2.Add(murlocRaider);
                MazoJugador2.Add(murlocRaider);
                MazoJugador1.Add(bloodfenRaptor);
                MazoJugador1.Add(bloodfenRaptor);
                MazoJugador1.Add(bloodfenRaptor);
                MazoJugador2.Add(bloodfenRaptor);
                MazoJugador2.Add(bloodfenRaptor);
                MazoJugador2.Add(bloodfenRaptor);
                MazoJugador1.Add(riverCrocolisk);
                MazoJugador1.Add(riverCrocolisk);
                MazoJugador1.Add(riverCrocolisk);
                MazoJugador2.Add(riverCrocolisk);
                MazoJugador2.Add(riverCrocolisk);
                MazoJugador2.Add(riverCrocolisk);
                MazoJugador1.Add(magmaRager);
                MazoJugador1.Add(magmaRager);
                MazoJugador1.Add(magmaRager);
                MazoJugador2.Add(magmaRager);
                MazoJugador2.Add(magmaRager);
                MazoJugador2.Add(magmaRager);
                MazoJugador1.Add(chillwindYeti);
                MazoJugador1.Add(chillwindYeti);
                MazoJugador1.Add(chillwindYeti);
                MazoJugador2.Add(chillwindYeti);
                MazoJugador2.Add(chillwindYeti);
                MazoJugador2.Add(chillwindYeti);
                MazoJugador1.Add(oasisSnapjaw);
                MazoJugador1.Add(oasisSnapjaw);
                MazoJugador1.Add(oasisSnapjaw);
                MazoJugador2.Add(oasisSnapjaw);
                MazoJugador2.Add(oasisSnapjaw);
                MazoJugador2.Add(oasisSnapjaw);
                MazoJugador1.Add(boulderfistOgre);
                MazoJugador1.Add(boulderfistOgre);
                MazoJugador1.Add(boulderfistOgre);
                MazoJugador2.Add(boulderfistOgre);
                MazoJugador2.Add(boulderfistOgre);
                MazoJugador2.Add(boulderfistOgre);
                MazoJugador1.Add(warGolem);
                MazoJugador1.Add(warGolem);
                MazoJugador1.Add(warGolem);
                MazoJugador2.Add(warGolem);
                MazoJugador2.Add(warGolem);
                MazoJugador2.Add(warGolem);
                MazoJugador1.Add(coreHound);
                MazoJugador1.Add(coreHound);
                MazoJugador1.Add(coreHound);
                MazoJugador2.Add(coreHound);
                MazoJugador2.Add(coreHound);
                MazoJugador2.Add(coreHound);
                Jugador Jugador1 = new Jugador(0, 30, 0, ManoJugador1, MazoJugador1, "", TableroJugador1, "", 0, pichon, ManoDisponible1, TableroDisponible1, 0);
                Jugador Jugador2 = new Jugador(0, 30, 0, ManoJugador2, MazoJugador2, "", TableroJugador2, "", 0, pichon, ManoDisponible2, TableroDisponible2, 0);
                Jugador1.nombre = TextBoxIngresarNombresJ1P1.Text;
                Jugador2.nombre = TextBoxIngresarNombresJ2P1.Text;
                Jugador1.heroe = TextBoxIngresarHeroesJ1P1.Text;
                Jugador2.heroe = TextBoxIngresarHeroesJ2P1.Text;
                ListaJugadores.Add(Jugador1);
                ListaJugadores.Add(Jugador2);
                crearMano(Jugador1, Jugador2, turno, theCoin);
                ListaJugadores[turno].ManaGrowth();
                ListaJugadores[turno].manaTurno = 0;
                ListaJugadores[turno].manaTurno += ListaJugadores[turno].mana;
                TurnoDeP2.Content = "Turno de " + ListaJugadores[turno].nombre;
                VidaP2.Content = "Vida: " + ListaJugadores[turno].vida;
                ManaP2.Content = "Mana: " + ListaJugadores[turno].manaTurno;
                int i = 0;
                while (i < ListaJugadores.Count)
                {
                    int a = 0;
                    while (a < ListaJugadores[i].mano.Count)
                    {
                        ListaJugadores[i].manoDisponible.Add(ListaJugadores[i].mano[a].nombre + " | " + ListaJugadores[i].mano[a].vida + " | " + ListaJugadores[i].mano[a].ataque + " | " + ListaJugadores[i].mano[a].costo);
                        a += 1;
                    }

                    i += 1;
                }

                ListBoxManoP2.ItemsSource = ListaJugadores[turno].manoDisponible;
                ListBoxTuTableroP2.ItemsSource = ListaJugadores[turno].tableroDisponible;
                if (turno == 1)
                {
                    ListBoxTableroRivalP2.ItemsSource = ListaJugadores[turno - 1].tableroDisponible;
                }
                else if (turno == 0)
                {
                    ListBoxTableroRivalP2.ItemsSource = ListaJugadores[turno + 1].tableroDisponible;
                }

            }
        }

        private void BotonAtacarP2_Click(object sender, RoutedEventArgs e)
        {
            if (turno == 0)
            {
                AtacarCarta(ListaJugadores[turno], ListaJugadores[turno + 1], Int32.Parse(CartaAtacanteP2.Text), Int32.Parse(CartaAtacadaP2.Text));
            }

            else if (turno == 1)
            {
                AtacarCarta(ListaJugadores[turno], ListaJugadores[turno - 1], Int32.Parse(CartaAtacanteP2.Text), Int32.Parse(CartaAtacadaP2.Text));
            }
        }

        private void BotonJugarCartaP2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JugarCartas(ListaJugadores[turno], Int32.Parse(CartaAJugarP2.Text));
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Hidden;
            }

            catch (FormatException)
            {
                LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Visible;
            }
            
            catch (ArgumentOutOfRangeException)
            {
                LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void BotonTerminarTurnoP2_Click(object sender, RoutedEventArgs e)
        {
            if (turno == 0)
            {
                turno += 1;
                Draw(ListaJugadores[turno]);
                ListaJugadores[turno].ManaGrowth();
                ListaJugadores[turno].manaTurno = 0;
                ListaJugadores[turno].manaTurno += ListaJugadores[turno].mana;
                TurnoDeP2.Content = null;
                TurnoDeP2.Content = "Turno de " + ListaJugadores[turno].nombre;
                VidaP2.Content = null;
                VidaP2.Content = "Vida: " + ListaJugadores[turno].vida;
                ManaP2.Content = null;
                ManaP2.Content = "Mana: " + ListaJugadores[turno].manaTurno;
                ListBoxManoP2.ItemsSource = null;
                ListBoxManoP2.ItemsSource = ListaJugadores[turno].manoDisponible;
                ListBoxTuTableroP2.ItemsSource = null;
                ListBoxTuTableroP2.ItemsSource = ListaJugadores[turno].tableroDisponible;
                ListBoxTableroRivalP2.ItemsSource = null;
                ListBoxTableroRivalP2.ItemsSource = ListaJugadores[turno - 1].tableroDisponible;
            }
            else if (turno == 1)
            {
                turno -= 1;
                Draw(ListaJugadores[turno]);
                ListaJugadores[turno].ManaGrowth();
                ListaJugadores[turno].manaTurno = 0;
                ListaJugadores[turno].manaTurno += ListaJugadores[turno].mana;
                TurnoDeP2.Content = null;
                TurnoDeP2.Content = "Turno de " + ListaJugadores[turno].nombre;
                VidaP2.Content = null;
                VidaP2.Content = "Vida: " + ListaJugadores[turno].vida;
                ManaP2.Content = null;
                ManaP2.Content = "Mana: " + ListaJugadores[turno].manaTurno;
                ListBoxManoP2.ItemsSource = null;
                ListBoxManoP2.ItemsSource = ListaJugadores[turno].manoDisponible;
                ListBoxTuTableroP2.ItemsSource = null;
                ListBoxTuTableroP2.ItemsSource = ListaJugadores[turno].tableroDisponible;
                ListBoxTableroRivalP2.ItemsSource = null;
                ListBoxTableroRivalP2.ItemsSource = ListaJugadores[turno + 1].tableroDisponible;
            }
        }

        private void BotonGuardarYSalirP2_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
