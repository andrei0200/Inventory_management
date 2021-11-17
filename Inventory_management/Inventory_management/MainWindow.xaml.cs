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

namespace Inventory_management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string username,string pass)
        {
            InitializeComponent();
        }

        private void Button_logout(object sender, RoutedEventArgs e)
        {
            LoginPage LP = new LoginPage();
            LP.Show();
            this.Close();
        }

        bool info_visi = true;
        private void Button_profil(object sender, RoutedEventArgs e)
        {
            
            if (info_visi)
            {
                profile_info.Visibility = Visibility.Hidden;
                info_visi = false;
            }
            else
            {
                profile_info.Visibility = Visibility.Visible;
                info_visi = true;
            }

        }
    }
}
