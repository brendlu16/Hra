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

namespace Hra
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool InvOtevren = false;
        public MainWindow()
        {
            InitializeComponent();
            VytvoritTestInventar();
            MainFrame.NavigationService.Navigate(new MenuPage());
        }
        private void OpenCloseInv(object sender, RoutedEventArgs e)
        {
            if (InvOtevren)
            {
                InvFrame.Navigate(null);
                InvOtevren = false;
            }
            else
            {
                InvFrame.Navigate(new InvPage());
                InvOtevren = true;
            }
        }
        public void VytvoritTestInventar()
        {
            Inventar inv = new Inventar();
            Hrac.Inv = inv;

            Brneni brneni1 = new Brneni { ID = 1, Name = "Brneni1", Hodnota = 100, Ochrana = 10 };
            Brneni brneni2 = new Brneni { ID = 2, Name = "Brneni2", Hodnota = 200, Ochrana = 15 };
            Hrac.Inv.Items.Add(brneni1);
            Hrac.Inv.Items.Add(brneni2);
            Helma helma1 = new Helma { ID = 3, Name = "Helma1", Hodnota = 80, Ochrana = 5 };
            Helma helma2 = new Helma { ID = 4, Name = "Helma2", Hodnota = 150, Ochrana = 10 };
            Hrac.Inv.Items.Add(helma1);
            Hrac.Inv.Items.Add(helma2);
            Zbran zbran1 = new Zbran { ID = 5, Name = "Zbran1", Hodnota = 80, Ovladatelnost = 40, MinPoskozeni = 40, MaxPoskozeni = 60 };
            Zbran zbran2 = new Zbran { ID = 6, Name = "Zbran2", Hodnota = 120, Ovladatelnost = 30, MinPoskozeni = 50, MaxPoskozeni = 75 };
            Hrac.Inv.Items.Add(zbran1);
            Hrac.Inv.Items.Add(zbran2);
            Stit stit1 = new Stit { ID = 7, Name = "Stit1", Hodnota = 30, Hmotnost = 10, MinBlok = 15, MaxBlok = 25 };
            Stit stit2 = new Stit { ID = 8, Name = "Stit2", Hodnota = 70, Hmotnost = 20, MinBlok = 15, MaxBlok = 35 };
            Hrac.Inv.Items.Add(stit1);
            Hrac.Inv.Items.Add(stit2);
            Jidlo jidlo1 = new Jidlo { ID = 9, Name = "Jidlo1", Hodnota = 30, Doplneni = 15 };
            Jidlo jidlo2 = new Jidlo { ID = 10, Name = "Jidlo2", Hodnota = 40, Doplneni = 25 };
            Jidlo jidlo3 = new Jidlo { ID = 11, Name = "Jidlo3", Hodnota = 30, Doplneni = 15 };
            Hrac.Inv.Items.Add(jidlo1);
            Hrac.Inv.Items.Add(jidlo2);
            Hrac.Inv.Items.Add(jidlo3);
            Hrac.Inv.Penize = 100;
            Hrac.Zdravi = 55;
        }
    }
}
