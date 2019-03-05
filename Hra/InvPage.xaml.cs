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
    /// Interakční logika pro InvPage.xaml
    /// </summary>
    public partial class InvPage : Page
    {
        public InvPage()
        {
            InitializeComponent();
            foreach (var item in Hrac.Inv.Items)
            {
                ListItemu.Items.Add(VytvoritInvTemplate(item, item.InvTlacitko()));
            }
        }
        public Grid VytvoritInvTemplate(Item item, string tlacitko)
        {
            Grid grid = new Grid { Height = 50, Width = 335, Name = "grid"+item.ID.ToString() };
            Rectangle obrazek = new Rectangle { Fill = Brushes.GreenYellow, Height = 50, Width = 50, HorizontalAlignment = HorizontalAlignment.Left };
            Label nazev = new Label { Margin = new System.Windows.Thickness(50, 0, 0, 25), Content = item.Name };
            StackPanel staty = new StackPanel { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(50, 0, 50, 0) };
            foreach (var Listitem in item.VypsatStaty())
            {
                staty.Children.Add(new Label { Content = Listitem });
            }

            grid.Children.Add(obrazek);
            grid.Children.Add(nazev);
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
            string test = item.GetType().ToString();
            switch (item.GetType().ToString())
            {
                case "Hra.Brneni":
                    if (Hrac.Inv.VybaveneBrneni != null)
                    {
                        Hrac.Inv.Items.Add(Hrac.Inv.VybaveneBrneni);
                        Hrac.Inv.VybaveneBrneni = item;
                        Hrac.Inv.Items.Remove(item);
                        NavigationService.Refresh();
                    } else
                    {
                        Hrac.Inv.VybaveneBrneni = item;
                        Hrac.Inv.Items.Remove(item);
                        NavigationService.Refresh();
                    }
                    break;
                case "Hra.Helma":
                    break;
                default:
                    break;
            }
        }
    }
}
