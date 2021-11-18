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
using System.Windows.Shapes;

namespace Inventory_management
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        static String connectionString = "Server=.;Database=Inventory_Management;Trusted_Connection=true";
        SqlConnection connection = new SqlConnection(connectionString);
        DataSet set = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public LoginPage()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String pass = password_text.Password;
            String username = username_text.Text;

            if (pass == "" || username == "")
            {
                MessageBox.Show("Nu ati introdus credentialele necesare!","EROARE", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from CREDENTIALE where NUME_UTILIZATOR='" + username + "'and PAROLA='" + pass + "'";

            using (var rezultat = cmd.ExecuteReader())
            {
                if (rezultat.Read())
                {
                    MainWindow mainW = new MainWindow(username,pass);
                    mainW.Show();
                    this.Close();
                    MessageBox.Show("Bine ai venit, " + username, " :)");
                }
                else
                {
                    MessageBox.Show("Nume sau parola incorecta!", "ERAORE", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            connection.Close();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RegisterPage RP = new RegisterPage();
            RP.Show();
            this.Close();
        }
    }
}
