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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Entrega4WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int turno;
        Cartas ReclutaManoDePlata;
        Cartas dagger;
        public MainWindow()
        {
            Random rmd = new Random();
            int turno = rmd.Next(0, 1);
            InitializeComponent();
        }
        public void UsarPoder(Jugador JugadorPoder, Jugador JugadorOponente, Cartas carta, List<Cartas> lista, Cartas arma)
        {
            if (JugadorPoder.manaTurno >= 2)
            {
                if (JugadorPoder.heroe == "Warrior" || JugadorPoder.heroe == "warrior")
                {
                    JugadorPoder.armadura += 2;
                    JugadorPoder.manaTurno -= 2;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                }
                else if (JugadorPoder.heroe == "Hunter" || JugadorPoder.heroe == "hunter")
                {
                    JugadorOponente.vida -= 2;
                    VidaRivalP2.Content = null;
                    VidaRivalP2.Content = "Vida Rival: " + JugadorOponente.vida;
                    JugadorPoder.manaTurno -= 2;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                    if (JugadorOponente.vida <= 0)
                    {
                        this.Close();
                    }
                }
                else if (JugadorPoder.heroe == "Druid" || JugadorPoder.heroe == "druid")
                {
                    JugadorPoder.damage += 1;
                    JugadorPoder.armadura += 1;
                    JugadorPoder.manaTurno -= 2;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                }
                else if (JugadorPoder.heroe == "Mage" || JugadorPoder.heroe == "mage")
                {
                    JugadorOponente.vida -= 1;
                    VidaRivalP2.Content = null;
                    VidaRivalP2.Content = "Vida Rival: " + JugadorOponente.vida;
                    JugadorPoder.manaTurno -= 2;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                    if (JugadorOponente.vida <= 0)
                    {
                        this.Close();
                    }
                }
                else if (JugadorPoder.heroe == "Paladin" || JugadorPoder.heroe == "paladin")
                {
                    JugadorPoder.tablero.Add(carta);
                    JugadorPoder.tableroDisponible.Add(carta.nombre + " | " + carta.vida + " | " + carta.ataque + " | " + carta.costo);
                    JugadorPoder.manaTurno -= 2;
                    ListBoxTuTableroP2.ItemsSource = null;
                    ListBoxTuTableroP2.ItemsSource = JugadorPoder.tableroDisponible;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                }
                else if (JugadorPoder.heroe == "Priest" || JugadorPoder.heroe == "priest")
                {
                    JugadorPoder.vida += 2;
                    VidaP2.Content = null;
                    VidaP2.Content = "Vida: " + JugadorPoder.vida;
                    JugadorPoder.manaTurno -= 2;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                }
                else if (JugadorPoder.heroe == "Rogue" || JugadorPoder.heroe == "rogue")
                {
                    JugadorPoder.arma = arma;
                    JugadorPoder.manaTurno -= 2;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                }
                else if (JugadorPoder.heroe == "Shaman" || JugadorPoder.heroe == "shaman")
                {
                    Random rnd = new Random();
                    int largoLista = rnd.Next(0, 4);
                    JugadorPoder.tablero.Add(lista[largoLista]);
                    JugadorPoder.tableroDisponible.Add(lista[largoLista].nombre + " | " + lista[largoLista].vida + " | " + lista[largoLista].ataque + " | " + lista[largoLista].costo);
                    ListBoxTuTableroP2.ItemsSource = null;
                    ListBoxTuTableroP2.ItemsSource = JugadorPoder.tableroDisponible;
                    JugadorPoder.manaTurno -= 2;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                }
                else if (JugadorPoder.heroe == "Warlock" || JugadorPoder.heroe == "warlock")
                {
                    JugadorPoder.vida -= 2;
                    Random rmd = new Random ();
                    int cartaASacar = rmd.Next(0, JugadorPoder.mazo.Count);
                    JugadorPoder.mano.Add(JugadorPoder.mazo[cartaASacar]);
                    JugadorPoder.manoDisponible.Add(JugadorPoder.mazo[cartaASacar].nombre + " | " + JugadorPoder.mazo[cartaASacar].vida + " | " + JugadorPoder.mazo[cartaASacar].ataque + " | " + JugadorPoder.mazo[cartaASacar].costo);
                    JugadorPoder.mazo.Remove(JugadorPoder.mazo[cartaASacar]);
                    VidaP2.Content = null;
                    VidaP2.Content = "Vida: " + JugadorPoder.vida;
                    JugadorPoder.manaTurno -= 2;
                    ManaP2.Content = null;
                    ManaP2.Content = "Mana: " + JugadorPoder.manaTurno;
                    if (JugadorPoder.vida <= 0)
                    {
                        this.Close();
                    }
                }
            }
        }
        List<Jugador> ListaJugadores = new List<Jugador>();
        List<Cartas> listaCartasShaman = new List<Cartas>();
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

        public void Draw(Jugador JugadorVoid)
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

        public void AtacarCarta(Jugador Jugador1, Jugador Jugador2, int cartaAtacante, int cartaAtacada)
        {
            Jugador1.tablero[cartaAtacante - 1].vida -= Jugador2.tablero[cartaAtacada - 1].ataque;
            Jugador2.tablero[cartaAtacada - 1].vida -= Jugador1.tablero[cartaAtacante - 1].ataque;

            if (Jugador1.tablero[cartaAtacante - 1].vida <= 0)
            {
                Jugador1.tablero.Remove(Jugador1.tablero[cartaAtacante - 1]);
                Jugador1.tableroDisponible.Remove(Jugador1.tableroDisponible[cartaAtacante - 1]);
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
                LabelInstrucciones4P2.Visibility = System.Windows.Visibility.Visible;
                CartaAJugarP2.Visibility = System.Windows.Visibility.Visible;
                BotonJugarCartaP2.Visibility = System.Windows.Visibility.Visible;
                BotonGuardarYSalirP2.Visibility = System.Windows.Visibility.Visible;
                BotonTerminarTurnoP2.Visibility = System.Windows.Visibility.Visible;
                LabelAtacarHeroeP2.Visibility = System.Windows.Visibility.Visible;
                CartaAtacanteHeroesP2.Visibility = System.Windows.Visibility.Visible;
                BotonAtacarHeroeP2.Visibility = System.Windows.Visibility.Visible;
                LabelInstrucciones7P2.Visibility = System.Windows.Visibility.Visible;
                VidaRivalP2.Visibility = System.Windows.Visibility.Visible;
                ReclutaManoDePlata = new Cartas(0, 1, 1, "Esbirro de Plata");
                Cartas healingTotem = new Cartas(0, 0, 2, "Healing Totem");
                listaCartasShaman.Add(healingTotem);
                Cartas searingTotem = new Cartas(0, 1, 1, "Searing Totem");
                listaCartasShaman.Add(searingTotem);
                Cartas stoneclawTotem = new Cartas(0, 0, 2, "StoneClaw Totem");
                listaCartasShaman.Add(stoneclawTotem);
                Cartas wrathOfAirTotem = new Cartas(0, 0, 2, "Wrath Of Air Totem");
                listaCartasShaman.Add(wrathOfAirTotem);
                Cartas pichon = new Cartas(0, 0, 10000000, "pichon");
                dagger = new Cartas(0, 1, 2, "Dagger");
                Cartas wisp1 = new Cartas(0, 1, 1, "wisp");
                Cartas wisp2 = new Cartas(0, 1, 1, "wisp");
                Cartas wisp3 = new Cartas(0, 1, 1, "wisp");
                Cartas wisp4 = new Cartas(0, 1, 1, "wisp");
                Cartas wisp5 = new Cartas(0, 1, 1, "wisp");
                Cartas wisp6 = new Cartas(0, 1, 1, "wisp");
                Cartas murlocRaider1 = new Cartas(1, 1, 2, "Murloc Raider");
                Cartas murlocRaider2 = new Cartas(1, 1, 2, "Murloc Raider");
                Cartas murlocRaider3 = new Cartas(1, 1, 2, "Murloc Raider");
                Cartas murlocRaider4 = new Cartas(1, 1, 2, "Murloc Raider");
                Cartas murlocRaider5 = new Cartas(1, 1, 2, "Murloc Raider");
                Cartas murlocRaider6 = new Cartas(1, 1, 2, "Murloc Raider");
                Cartas bloodfenRaptor1 = new Cartas(2, 3, 2, "Bloodfen Raptor");
                Cartas bloodfenRaptor2 = new Cartas(2, 3, 2, "Bloodfen Raptor");
                Cartas bloodfenRaptor3 = new Cartas(2, 3, 2, "Bloodfen Raptor");
                Cartas bloodfenRaptor4 = new Cartas(2, 3, 2, "Bloodfen Raptor");
                Cartas bloodfenRaptor5 = new Cartas(2, 3, 2, "Bloodfen Raptor");
                Cartas bloodfenRaptor6 = new Cartas(2, 3, 2, "Bloodfen Raptor");
                Cartas riverCrocolisk1 = new Cartas(2, 2, 3, "River CrocoLisk");
                Cartas riverCrocolisk2 = new Cartas(2, 2, 3, "River CrocoLisk");
                Cartas riverCrocolisk3 = new Cartas(2, 2, 3, "River CrocoLisk");
                Cartas riverCrocolisk4 = new Cartas(2, 2, 3, "River CrocoLisk");
                Cartas riverCrocolisk5 = new Cartas(2, 2, 3, "River CrocoLisk");
                Cartas riverCrocolisk6 = new Cartas(2, 2, 3, "River CrocoLisk");
                Cartas magmaRager1 = new Cartas(3, 5, 1, "Magma Rager");
                Cartas magmaRager2 = new Cartas(3, 5, 1, "Magma Rager");
                Cartas magmaRager3 = new Cartas(3, 5, 1, "Magma Rager");
                Cartas magmaRager4 = new Cartas(3, 5, 1, "Magma Rager");
                Cartas magmaRager5 = new Cartas(3, 5, 1, "Magma Rager");
                Cartas magmaRager6 = new Cartas(3, 5, 1, "Magma Rager");
                Cartas chillwindYeti1 = new Cartas(4, 4, 5, "Chill Wind Yeti");
                Cartas chillwindYeti2 = new Cartas(4, 4, 5, "Chill Wind Yeti");
                Cartas chillwindYeti3 = new Cartas(4, 4, 5, "Chill Wind Yeti");
                Cartas chillwindYeti4 = new Cartas(4, 4, 5, "Chill Wind Yeti");
                Cartas chillwindYeti5 = new Cartas(4, 4, 5, "Chill Wind Yeti");
                Cartas chillwindYeti6 = new Cartas(4, 4, 5, "Chill Wind Yeti");
                Cartas oasisSnapjaw1 = new Cartas(4, 2, 7, "Oasis Snap Jaw");
                Cartas oasisSnapjaw2 = new Cartas(4, 2, 7, "Oasis Snap Jaw");
                Cartas oasisSnapjaw3 = new Cartas(4, 2, 7, "Oasis Snap Jaw");
                Cartas oasisSnapjaw4 = new Cartas(4, 2, 7, "Oasis Snap Jaw");
                Cartas oasisSnapjaw5 = new Cartas(4, 2, 7, "Oasis Snap Jaw");
                Cartas oasisSnapjaw6 = new Cartas(4, 2, 7, "Oasis Snap Jaw");
                Cartas boulderfistOgre1 = new Cartas(6, 6, 7, "Boulder Fist Ogre");
                Cartas boulderfistOgre2 = new Cartas(6, 6, 7, "Boulder Fist Ogre");
                Cartas boulderfistOgre3 = new Cartas(6, 6, 7, "Boulder Fist Ogre");
                Cartas boulderfistOgre4 = new Cartas(6, 6, 7, "Boulder Fist Ogre");
                Cartas boulderfistOgre5 = new Cartas(6, 6, 7, "Boulder Fist Ogre");
                Cartas boulderfistOgre6 = new Cartas(6, 6, 7, "Boulder Fist Ogre");
                Cartas warGolem1 = new Cartas(7, 7, 7, "War Golem");
                Cartas warGolem2 = new Cartas(7, 7, 7, "War Golem");
                Cartas warGolem3 = new Cartas(7, 7, 7, "War Golem");
                Cartas warGolem4 = new Cartas(7, 7, 7, "War Golem");
                Cartas warGolem5 = new Cartas(7, 7, 7, "War Golem");
                Cartas warGolem6 = new Cartas(7, 7, 7, "War Golem");
                Cartas coreHound1 = new Cartas(7, 9, 5, "Core Hound");
                Cartas coreHound2 = new Cartas(7, 9, 5, "Core Hound");
                Cartas coreHound3 = new Cartas(7, 9, 5, "Core Hound");
                Cartas coreHound4 = new Cartas(7, 9, 5, "Core Hound");
                Cartas coreHound5 = new Cartas(7, 9, 5, "Core Hound");
                Cartas coreHound6 = new Cartas(7, 9, 5, "Core Hound");
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
                MazoJugador1.Add(wisp1);
                MazoJugador1.Add(wisp2);
                MazoJugador1.Add(wisp3);
                MazoJugador2.Add(wisp4);
                MazoJugador2.Add(wisp5);
                MazoJugador2.Add(wisp6);
                MazoJugador1.Add(murlocRaider1);
                MazoJugador1.Add(murlocRaider2);
                MazoJugador1.Add(murlocRaider3);
                MazoJugador2.Add(murlocRaider4);
                MazoJugador2.Add(murlocRaider5);
                MazoJugador2.Add(murlocRaider6);
                MazoJugador1.Add(bloodfenRaptor1);
                MazoJugador1.Add(bloodfenRaptor2);
                MazoJugador1.Add(bloodfenRaptor3);
                MazoJugador2.Add(bloodfenRaptor4);
                MazoJugador2.Add(bloodfenRaptor5);
                MazoJugador2.Add(bloodfenRaptor6);
                MazoJugador1.Add(riverCrocolisk1);
                MazoJugador1.Add(riverCrocolisk2);
                MazoJugador1.Add(riverCrocolisk3);
                MazoJugador2.Add(riverCrocolisk4);
                MazoJugador2.Add(riverCrocolisk5);
                MazoJugador2.Add(riverCrocolisk6);
                MazoJugador1.Add(magmaRager1);
                MazoJugador1.Add(magmaRager2);
                MazoJugador1.Add(magmaRager3);
                MazoJugador2.Add(magmaRager4);
                MazoJugador2.Add(magmaRager5);
                MazoJugador2.Add(magmaRager6);
                MazoJugador1.Add(chillwindYeti1);
                MazoJugador1.Add(chillwindYeti2);
                MazoJugador1.Add(chillwindYeti3);
                MazoJugador2.Add(chillwindYeti4);
                MazoJugador2.Add(chillwindYeti5);
                MazoJugador2.Add(chillwindYeti6);
                MazoJugador1.Add(oasisSnapjaw1);
                MazoJugador1.Add(oasisSnapjaw2);
                MazoJugador1.Add(oasisSnapjaw3);
                MazoJugador2.Add(oasisSnapjaw4);
                MazoJugador2.Add(oasisSnapjaw5);
                MazoJugador2.Add(oasisSnapjaw6);
                MazoJugador1.Add(boulderfistOgre1);
                MazoJugador1.Add(boulderfistOgre2);
                MazoJugador1.Add(boulderfistOgre3);
                MazoJugador2.Add(boulderfistOgre4);
                MazoJugador2.Add(boulderfistOgre5);
                MazoJugador2.Add(boulderfistOgre6);
                MazoJugador1.Add(warGolem1);
                MazoJugador1.Add(warGolem2);
                MazoJugador1.Add(warGolem3);
                MazoJugador2.Add(warGolem4);
                MazoJugador2.Add(warGolem5);
                MazoJugador2.Add(warGolem6);
                MazoJugador1.Add(coreHound1);
                MazoJugador1.Add(coreHound2);
                MazoJugador1.Add(coreHound3);
                MazoJugador2.Add(coreHound4);
                MazoJugador2.Add(coreHound5);
                MazoJugador2.Add(coreHound6);
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

                if (turno == 1)
                {
                    VidaRivalP2.Content = null;
                    VidaRivalP2.Content = "Vida rival: " + ListaJugadores[turno - 1].vida;
                }
                else if (turno == 0)
                {
                    VidaRivalP2.Content = null;
                    VidaRivalP2.Content = "Vida rival: " + ListaJugadores[turno + 1].vida;
                }

            }
        }

        private void BotonAtacarP2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (turno == 0)
                {
                    AtacarCarta(ListaJugadores[turno], ListaJugadores[turno + 1], Int32.Parse(CartaAtacanteP2.Text), Int32.Parse(CartaAtacadaP2.Text));
                }

                else if (turno == 1)
                {
                    AtacarCarta(ListaJugadores[turno], ListaJugadores[turno - 1], Int32.Parse(CartaAtacanteP2.Text), Int32.Parse(CartaAtacadaP2.Text));
                }

                CartaAtacanteP2.Text = null;
                CartaAtacadaP2.Text = null;
            }
            catch (FormatException)
            {
                CartaAtacanteP2.Text = null;
                CartaAtacadaP2.Text = null;
            }
            catch (ArgumentOutOfRangeException)
            {
                CartaAtacanteP2.Text = null;
                CartaAtacadaP2.Text = null;
            }
        }

        private void BotonJugarCartaP2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JugarCartas(ListaJugadores[turno], Int32.Parse(CartaAJugarP2.Text));
                CartaAJugarP2.Text = null;
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Hidden;
            }

            catch (FormatException)
            {
                CartaAJugarP2.Text = null;
                LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Visible;
            }

            catch (ArgumentOutOfRangeException)
            {
                CartaAJugarP2.Text = null;
                LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void BotonTerminarTurnoP2_Click(object sender, RoutedEventArgs e)
        {
            if (turno == 0)
            {
                Draw(ListaJugadores[turno]);
                turno += 1;
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
                VidaRivalP2.Content = null;
                VidaRivalP2.Content = "Vida Rival: " + ListaJugadores[turno - 1].vida;
                CartaAJugarP2.Text = null;
                CartaAtacanteHeroesP2.Text = null;
                CartaAtacadaP2.Text = null;
                CartaAtacanteP2.Text = null;
                LabelInstrucciones3P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones8P2.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (turno == 1)
            {
                Draw(ListaJugadores[turno]);
                turno -= 1;
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
                VidaRivalP2.Content = null;
                VidaRivalP2.Content = "Vida Rival: " + ListaJugadores[turno + 1].vida;
                CartaAJugarP2.Text = null;
                CartaAtacanteHeroesP2.Text = null;
                CartaAtacadaP2.Text = null;
                CartaAtacanteP2.Text = null;
                LabelInstrucciones3P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones5P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones6P2.Visibility = System.Windows.Visibility.Hidden;
                LabelInstrucciones8P2.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void BotonAtacarHeroeP2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (turno == 0)
                {
                    ListaJugadores[turno + 1].armadura -= ListaJugadores[turno].tablero[Int32.Parse(CartaAtacanteHeroesP2.Text) - 1].ataque;
                    if (ListaJugadores[turno + 1].armadura < 0)
                    {
                        ListaJugadores[turno + 1].vida += ListaJugadores[turno + 1].armadura;
                        ListaJugadores[turno + 1].armadura = 0;
                    }
                    VidaRivalP2.Content = null;
                    CartaAtacanteHeroesP2.Text = null;
                    VidaRivalP2.Content = "Vida rival: " + ListaJugadores[turno + 1].vida;
                    LabelInstrucciones8P2.Visibility = System.Windows.Visibility.Hidden;
                    if (ListaJugadores[turno + 1].vida <= 0)
                    {
                        this.Close();
                    }
                }

                else if (turno == 1)
                {
                    ListaJugadores[turno - 1].armadura -= ListaJugadores[turno].tablero[Int32.Parse(CartaAtacanteHeroesP2.Text) - 1].ataque;
                    if (ListaJugadores[turno - 1].armadura < 0)
                    {
                        ListaJugadores[turno - 1].vida += ListaJugadores[turno - 1].armadura;
                        ListaJugadores[turno - 1].armadura = 0;
                    }
                    VidaRivalP2.Content = null;
                    CartaAtacanteHeroesP2.Text = null;
                    VidaRivalP2.Content = "Vida rival: " + ListaJugadores[turno - 1].vida;
                    LabelInstrucciones8P2.Visibility = System.Windows.Visibility.Hidden;
                    if (ListaJugadores[turno - 1].vida <= 0)
                    {
                        this.Close();
                    }
                }
            }

            catch (FormatException)
            {
                CartaAtacanteHeroesP2.Text = null;
                LabelInstrucciones8P2.Visibility = System.Windows.Visibility.Visible;
            }
            catch (ArgumentOutOfRangeException)
            {
                CartaAtacanteHeroesP2.Text = null;
                LabelInstrucciones8P2.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void BotonGuardarYSalirP2_Click(object sender, RoutedEventArgs e)
        {
            Jugador jugador1Guardado = ListaJugadores[0];
            Jugador jugador2Guardado = ListaJugadores[1];
            Stream stream = File.Open("jugador1Guardado.dat", FileMode.Create);
            Stream stream2 = File.Open("jugador2Guardado.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, jugador1Guardado);
            bf.Serialize(stream2, jugador2Guardado);
            stream.Close();
            stream2.Close();
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();

        }

        private void BotonCargarPartidaP1_Click(object sender, RoutedEventArgs e)
        {
            Stream stream = File.Open("jugador1Guardado.dat", FileMode.Open);
            Stream stream2 = File.Open("jugador2Guardado.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ListaJugadores.Add((Jugador)bf.Deserialize(stream));
            ListaJugadores.Add((Jugador)bf.Deserialize(stream2));
            Jugador Jugador1 = ListaJugadores[0];
            Jugador Jugador2 = ListaJugadores[1];
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
            LabelInstrucciones4P2.Visibility = System.Windows.Visibility.Visible;
            CartaAJugarP2.Visibility = System.Windows.Visibility.Visible;
            BotonJugarCartaP2.Visibility = System.Windows.Visibility.Visible;
            BotonGuardarYSalirP2.Visibility = System.Windows.Visibility.Visible;
            BotonTerminarTurnoP2.Visibility = System.Windows.Visibility.Visible;
            LabelAtacarHeroeP2.Visibility = System.Windows.Visibility.Visible;
            CartaAtacanteHeroesP2.Visibility = System.Windows.Visibility.Visible;
            BotonAtacarHeroeP2.Visibility = System.Windows.Visibility.Visible;
            LabelInstrucciones7P2.Visibility = System.Windows.Visibility.Visible;
            VidaRivalP2.Visibility = System.Windows.Visibility.Visible;
            TurnoDeP2.Content = "Turno de " + ListaJugadores[turno].nombre;
            VidaP2.Content = "Vida: " + ListaJugadores[turno].vida;
            ManaP2.Content = "Mana: " + ListaJugadores[turno].manaTurno;
            ListBoxManoP2.ItemsSource = ListaJugadores[turno].manoDisponible;
            ListBoxTuTableroP2.ItemsSource = ListaJugadores[turno].tableroDisponible;
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

            if (turno == 1)
            {
                VidaRivalP2.Content = null;
                VidaRivalP2.Content = "Vida rival: " + ListaJugadores[turno - 1].vida;
            }
            else if (turno == 0)
            {
                VidaRivalP2.Content = null;
                VidaRivalP2.Content = "Vida rival: " + ListaJugadores[turno + 1].vida;
            }
        }

        private void UsarPoderP2_Click(object sender, RoutedEventArgs e)
        {
            if (turno == 0)
            {
                UsarPoder(ListaJugadores[turno], ListaJugadores[turno + 1], ReclutaManoDePlata, listaCartasShaman, dagger);
            }

            else if (turno == 1)
            {
                UsarPoder(ListaJugadores[turno], ListaJugadores[turno - 1], ReclutaManoDePlata, listaCartasShaman, dagger);
            }
        }
    }
}
