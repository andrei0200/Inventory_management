using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Price_page.xaml
    /// </summary>
    public partial class Price_page : Window
    {
        static String connectionString = "Server=.;Database=Inventory_Management;Trusted_Connection=true";
        SqlConnection connection = new SqlConnection(connectionString);
        public Price_page()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            String ID_prod = id_price.Text;
            String New_Price = new_price.Text;

            var cmdCheck = connection.CreateCommand();
            cmdCheck.CommandType = System.Data.CommandType.Text;
            cmdCheck.CommandText = "select * from PRODUSE where PRODUSE_ID = '" + ID_prod + "'";
            using (var result = cmdCheck.ExecuteReader())
            {
                if (result.Read())
                {
                    result.Close();
                    var cmdDel = connection.CreateCommand();
                    cmdDel.CommandType = System.Data.CommandType.Text;
                    cmdDel.CommandText = "UPDATE PRODUSE SET PRET_BUCATA = '" + New_Price + "' WHERE PRODUSE_ID = '" + ID_prod + "'";
                    cmdDel.ExecuteReader();

                    MessageBox.Show("Pret schimbat cu succes!", "SUCCES", MessageBoxButton.OK, MessageBoxImage.Information);

                    connection.Close();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("ID inexistent!", "ERAORE", MessageBoxButton.OK, MessageBoxImage.Warning);
                    result.Close();
                    connection.Close();
                    return;
                }

            }

        }
    }
}
