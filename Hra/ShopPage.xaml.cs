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
    /// Interakční logika pro ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        private NPC Npc = new NPC { ID = 0, Inv = new Inventar() };
        public ShopPage()
        {
            InitializeComponent();
            VytvoritTestInventar();
            VypsatInventar();
        }
        public void VypsatInventar()
        {
            ListItemu.Items.Clear();
            foreach (var item in Hrac.Inv.Items)
            {
                ListItemu.Items.Add(VytvoritInvTemplate(item, "Prodat", true));
            }
            PenizeLabel.Content = Hrac.Inv.Penize;
            VypsatNPCInventar();
        }
        public void VypsatNPCInventar()
        {
            ListItemuNPC.Items.Clear();
            foreach (var item in Npc.Inv.Items)
            {
                ListItemuNPC.Items.Add(VytvoritInvTemplate(item, "Koupit", false));
            }
        }
        public Grid VytvoritInvTemplate(Item item, string tlacitko, bool hrac)
        {
            Grid grid = new Grid { Height = 50, Width = 320, Name = "grid" + item.ID.ToString() };
            Rectangle obrazek = new Rectangle { Fill = Brushes.GreenYellow, Height = 50, Width = 50, HorizontalAlignment = HorizontalAlignment.Left };
            Label nazev = new Label { Margin = new System.Windows.Thickness(50, 0, 80, 25), Content = item.Name };
            Label hodnota = new Label { Margin = new System.Windows.Thickness(0, 0, 0, 25), HorizontalAlignment = HorizontalAlignment.Right, Content = "Hodnota: " + item.Hodnota };
            StackPanel staty = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(50, 0, 50, 0) };
            foreach (var Listitem in item.VypsatStaty())
            {
                staty.Children.Add(new Label { Content = Listitem });
            }

            grid.Children.Add(obrazek);
            grid.Children.Add(nazev);
            grid.Children.Add(hodnota);
            grid.Children.Add(staty);

            if (tlacitko != null)
            {
                Button button = new Button { HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Bottom, Width = 50, Height = 20, Content = tlacitko, Name = "button" + item.ID.ToString() };
                if (hrac)
                {
                    button.Click += ProdatItem;
                } else
                {
                    button.Click += KoupitItem;
                }
                grid.Children.Add(button);
            }
            return grid;
        }
        public void ProdatItem(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int buttonID = int.Parse(button.Name.Substring(6));
            Item item = new Brneni();
            foreach (var invItem in Hrac.Inv.Items)
            {
                if (invItem.ID == buttonID)
                {
                    item = invItem;
                    break;
                }
            }
            Hrac.Inv.Items.Remove(item);
            Hrac.Inv.Penize += item.Hodnota / 2;
            Npc.Inv.Items.Add(item);
            VypsatInventar();
        }
        public void KoupitItem(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int buttonID = int.Parse(button.Name.Substring(6));
            Item item = new Brneni();
            foreach (var invItem in Npc.Inv.Items)
            {
                if (invItem.ID == buttonID)
                {
                    item = invItem;
                    break;
                }
            }
            if (Hrac.Inv.Penize >= item.Hodnota)
            {
                Hrac.Inv.Items.Add(item);
                Hrac.Inv.Penize -= item.Hodnota;
                Npc.Inv.Items.Remove(item);
            }
            VypsatInventar();
        }
        public void VytvoritTestInventar()
        {
            Brneni brneni2 = new Brneni { ID = 2, Name = "Brneni2", Hodnota = 200, Ochrana = 15 };
            Npc.Inv.Items.Add(brneni2);
            Helma helma2 = new Helma { ID = 4, Name = "Helma2", Hodnota = 150, Ochrana = 10 };
            Npc.Inv.Items.Add(helma2);
            Zbran zbran2 = new Zbran { ID = 6, Name = "Zbran2", Hodnota = 120, Ovladatelnost = 30, MinPoskozeni = 50, MaxPoskozeni = 75 };
            Npc.Inv.Items.Add(zbran2);
            Stit stit2 = new Stit { ID = 8, Name = "Stit2", Hodnota = 70, Hmotnost = 20, MinBlok = 15, MaxBlok = 35 };
            Npc.Inv.Items.Add(stit2);
            Jidlo jidlo3 = new Jidlo { ID = 11, Name = "Jidlo3", Hodnota = 30, Doplneni = 30 };
            Npc.Inv.Items.Add(jidlo3);
            Npc.Inv.Items.Add(jidlo3);
        }
        private void ZavritShop(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
