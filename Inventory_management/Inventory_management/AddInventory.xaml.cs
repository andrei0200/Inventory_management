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
    /// Interaction logic for AddInventory.xaml
    /// </summary>
   
    public partial class AddInventory : Window
    {
        string username;
        int id;
        static String connectionString = "Server=.;Database=Inventory_Management;Trusted_Connection=true";
        SqlConnection connection = new SqlConnection(connectionString);
        DataSet set = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public AddInventory(string username, int id)
        {
            InitializeComponent();
            this.username = username;
            this.id = id;
            functie();
        }

        void functie()
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT NUME_UTILIZATOR FROM CREDENTIALE INNER JOIN ANGAJATI ON ANGAJATI.CREDENTIALE_ID=CREDENTIALE.CREDENTIALE_ID WHERE ANGAJATI.ANGAJATI_ID = '" + id + "'";
            SqlDataReader da = cmd.ExecuteReader();
            da.Read();
            utilizator.Content = da.GetValue(0).ToString();
            da.Close();
            connection.Close();
        }

       

        private void Inserare_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT CATEGORIE_ID FROM CATEGORIE_PRODUSE INNER JOIN ANGAJATI ON ANGAJATI.ANGAJATI_ID=CATEGORIE_PRODUSE.ANGAJAT_ID WHERE ANGAJATI.ANGAJATI_ID = '" + id + "'";
            SqlDataReader da = cmd.ExecuteReader();
            da.Read();
            int catId = da.GetInt32(0);
            da.Close();
            connection.Close();

            string nume = in_nume.Text;
            string expirare = in_expirare.Text;
            string fabricatie = in_fabricatie.Text;
            string numar = in_numarkg.Text;
            string pret = in_pret.Text;

            if (string.IsNullOrWhiteSpace(nume) || string.IsNullOrWhiteSpace(expirare) || string.IsNullOrWhiteSpace(fabricatie) || string.IsNullOrWhiteSpace(numar) || string.IsNullOrWhiteSpace(pret))
            {
                MessageBox.Show("Nu ati completat toate campurile!", "ERAORE", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            connection.Open();
            var cmd1 = connection.CreateCommand();
            cmd1.CommandType = System.Data.CommandType.Text;
            cmd1.CommandText = "select * from PRODUSE where NUME = '" + nume + "'";
            using (var result = cmd1.ExecuteReader())
            {
                if (result.Read())
                {
                    MessageBox.Show("Nume existent!", "ERAORE", MessageBoxButton.OK, MessageBoxImage.Warning);
                    result.Close();
                    connection.Close();
                    return;
                }
                result.Close();
            }


            var cmdInsertprodus = new SqlCommand(@"INSERT INTO PRODUSE(
	                [CATEGORIE_ID], [NUME], [DATA_EXPIRARE], [DATA_FABRICATIE], [NUMAR_PRODUSE], [PRET_BUCATA] ) 
                    VALUES (
	                @id, @nume, @expirare, @fabricatie, @nr, @pret)", connection);

            cmdInsertprodus.Parameters.AddWithValue("@id", catId);
            cmdInsertprodus.Parameters.AddWithValue("@nume", nume);
            cmdInsertprodus.Parameters.AddWithValue("@expirare", expirare);
            cmdInsertprodus.Parameters.AddWithValue("@fabricatie", fabricatie);
            cmdInsertprodus.Parameters.AddWithValue("@nr", numar);
            cmdInsertprodus.Parameters.AddWithValue("@pret", pret);
            var Insertprodus = cmdInsertprodus.ExecuteReader();
            Insertprodus.Close();
            MessageBox.Show("Produs inserat cu succes!", "SUCCES!", MessageBoxButton.OK, MessageBoxImage.Warning);
            in_nume.Text = "";
            in_expirare.Text = "";
            in_fabricatie.Text = "";
            in_numarkg.Text = "";
            in_pret.Text = "";

            this.Close();
        }
    }
}
