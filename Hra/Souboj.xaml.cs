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
using System.Windows.Threading;

namespace Hra
{
    /// <summary>
    /// Interakční logika pro Souboj.xaml
    /// </summary>
    public partial class Souboj : Page
    {
        Page zdroj;
        private NPC Enemy = new NPC { ID = 0, Inv = new Inventar() };
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int BarMax = 0;
        private int BarMin = 0;
        public Souboj(string pozadi, Page stranka)
        {
            InitializeComponent();
            zdroj = stranka;
            VytvoritTestInventar();
            Utok();
        }
        public void Utok()
        {
            Zbran zbran = (Zbran)Hrac.Inv.VybavenaZbran;
            BarMax = zbran.MaxPoskozeni;
            BarMin = zbran.MinPoskozeni;
            BarOvladac();
        }
        public void Utok2(int Poskozeni)
        {

        }
        public void BarOvladac()
        {
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            dispatcherTimer.Start();
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            ProsteBar.Value++;
            if (ProsteBar.Value == BarMax)
            {
                dispatcherTimer.Tick -= new EventHandler(DispatcherTimer_Tick);
                dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick2);
            }
            CommandManager.InvalidateRequerySuggested();
        }
        private void DispatcherTimer_Tick2(object sender, EventArgs e)
        {
            ProsteBar.Value--;
            if (ProsteBar.Value == BarMin)
            {
                dispatcherTimer.Tick -= new EventHandler(DispatcherTimer_Tick2);
                dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            }
            CommandManager.InvalidateRequerySuggested();
        }
        public void VytvoritTestInventar()
        {
            Brneni brneni2 = new Brneni { ID = 2, Name = "Brneni2", Hodnota = 200, Ochrana = 15 };
            Enemy.Inv.VybaveneBrneni = brneni2;
            Helma helma2 = new Helma { ID = 4, Name = "Helma2", Hodnota = 150, Ochrana = 10 };
            Enemy.Inv.Items.Add(helma2);
            Zbran zbran2 = new Zbran { ID = 6, Name = "Zbran2", Hodnota = 120, Ovladatelnost = 30, MinPoskozeni = 50, MaxPoskozeni = 75 };
            Enemy.Inv.Items.Add(zbran2);
            Stit stit2 = new Stit { ID = 8, Name = "Stit2", Hodnota = 70, Hmotnost = 20, MinBlok = 15, MaxBlok = 35 };
            Enemy.Inv.Items.Add(stit2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            Utok2(int.Parse(ProsteBar.Value.ToString()));
        }
    }
}
