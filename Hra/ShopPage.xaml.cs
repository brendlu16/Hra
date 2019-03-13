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
        public ShopPage()
        {
            InitializeComponent();
            VypsatInventar();
        }
        public void VypsatInventar()
        {
            ListItemu.Items.Clear();
            foreach (var item in Hrac.Inv.Items)
            {
                ListItemu.Items.Add(VytvoritInvTemplate(item, "Prodat"));
            }
            PenizeLabel.Content = Hrac.Inv.Penize;
        }
        public void VypsatNPCInventar()
        {

        }
        public Grid VytvoritInvTemplate(Item item, string tlacitko)
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
                button.Click += PouzitItem;
                grid.Children.Add(button);
            }
            return grid;
        }
        public void PouzitItem(object sender, RoutedEventArgs e)
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
            VypsatInventar();
        }
    }
}
