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
    /// Interakční logika pro Lokace1.xaml
    /// </summary>
    public partial class Lokace1 : Page
    {
        public Lokace1()
        {
            InitializeComponent();
        }
        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }
    }
}
