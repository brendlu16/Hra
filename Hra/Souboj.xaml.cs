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
        private Page zdroj;
        private NPC Enemy = new NPC { ID = 0, Inv = new Inventar(), Zdravi = 100 };
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int BarMax = 0;
        private int BarMin = 0;
        private int status;
        public Souboj(string pozadi, Page stranka)
        {
            InitializeComponent();
            zdroj = stranka;
            VytvoritTestInventar();
            status = 1;
            Update();
        }
        public void Utok()
        {
            Zbran zbran = (Zbran)Hrac.Inv.VybavenaZbran;
            BarMax = zbran.MaxPoskozeni;
            BarMin = zbran.MinPoskozeni;
            ProsteBar.Maximum = BarMax;
            ProsteBar.Minimum = BarMin;
            int rychlost = zbran.Ovladatelnost;
            BarOvladac(rychlost, zbran.MaxPoskozeni - zbran.MinPoskozeni);
        }
        public void Utok2(int Poskozeni)
        {
            int blok = 0;
            if (Enemy.Inv.VybaveneBrneni != null)
            {
                Brneni brneni = (Brneni)Enemy.Inv.VybaveneBrneni;
                blok += brneni.Ochrana;
            }
            if (Enemy.Inv.VybavenaHelma != null)
            {
                Helma helma = (Helma)Enemy.Inv.VybavenaHelma;
                blok += helma.Ochrana;
            }
            if (Enemy.Inv.VybavenyStit != null)
            {
                Stit stit = (Stit)Enemy.Inv.VybavenyStit;
                blok += (stit.MaxBlok + stit.MinBlok) / 2;
            }
            int Vysledek = Poskozeni - Poskozeni * blok / 100;
            Enemy.Zdravi -= Vysledek;
            status = 2;
            Update();
        }
        public void Update()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(UpdateTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            ZdraviBar.Value = Hrac.Zdravi;
            ZdraviLabel.Content = Hrac.Zdravi;
            EnemyZdraviBar.Value = Enemy.Zdravi;
            EnemyZdraviLabel.Content = Enemy.Zdravi;
            dispatcherTimer.Start();
        }
        public void UpdateTimer_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            if (Enemy.Zdravi < 1)
            {
                status = 3;
            }
            if (Hrac.Zdravi < 1)
            {
                status = 4;
            }
            switch (status)
            {
                case 1:
                    Utok();
                    break;
                case 2:
                    Obrana();
                    break;
                case 3:
                    NavigationService.Navigate(zdroj);
                    break;
                case 4:
                    NavigationService.Navigate(zdroj);
                    break;
                default:
                    break;
            }
        }
        public void Obrana()
        {
            if (Hrac.Inv.VybavenyStit != null)
            {
                Stit stit = (Stit)Hrac.Inv.VybavenyStit;
                BarMax = stit.MaxBlok;
                BarMin = stit.MinBlok;
                ProsteBar.Maximum = BarMax;
                ProsteBar.Minimum = BarMin;
                int rychlost = 100 - stit.Hmotnost;
                BarOvladac(rychlost, stit.MaxBlok - stit.MinBlok);
            } else
            {
                Obrana2(0);
            }
        }
        public void Obrana2(int BlokStitu)
        {
            int blok = BlokStitu;
            if (Hrac.Inv.VybaveneBrneni != null)
            {
                Brneni brneni = (Brneni)Enemy.Inv.VybaveneBrneni;
                blok += brneni.Ochrana;
            }
            if (Hrac.Inv.VybavenaHelma != null)
            {
                Helma helma = (Helma)Enemy.Inv.VybavenaHelma;
                blok += helma.Ochrana;
            }
            Zbran zbran = (Zbran)Enemy.Inv.VybavenaZbran;
            int Poskozeni = (zbran.MinPoskozeni + zbran.MaxPoskozeni) / 2;
            int Vysledek = Poskozeni - Poskozeni * blok / 100;
            Hrac.Zdravi -= Vysledek;
            status = 1;
            Update();
        }
        public void BarOvladac(int rychlost, int rozsah)
        {

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, rychlost / rozsah * 20);
            dispatcherTimer.Start();
            StopButton.Visibility = Visibility.Visible;
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
            Enemy.Inv.VybavenaHelma = helma2;
            Zbran zbran2 = new Zbran { ID = 6, Name = "Zbran2", Hodnota = 120, Ovladatelnost = 30, MinPoskozeni = 50, MaxPoskozeni = 75 };
            Enemy.Inv.VybavenaZbran = zbran2;
            Stit stit2 = new Stit { ID = 8, Name = "Stit2", Hodnota = 70, Hmotnost = 20, MinBlok = 15, MaxBlok = 35 };
            Enemy.Inv.VybavenyStit = stit2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StopButton.Visibility = Visibility.Hidden;
            dispatcherTimer.Stop();
            switch (status)
            {
                case 1:
                    Utok2(int.Parse(ProsteBar.Value.ToString()));
                    break;
                case 2:
                    Obrana2(int.Parse(ProsteBar.Value.ToString()));
                    break;
                default:
                    break;
            }
        }
    }
}
