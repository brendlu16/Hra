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
        bool InvOtevren = false;
        public Lokace1()
        {
            InitializeComponent();
        }
        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Lokace2());
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
    }
}
