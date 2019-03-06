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
            Hrac.Inv.Penize = 100;
        }
    }
}
