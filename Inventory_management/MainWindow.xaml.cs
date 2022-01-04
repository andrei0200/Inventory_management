using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace Inventory_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //static String connectionString = "Server=.;Database=Inventory_Management;Trusted_Connection=true";
        //SqlConnection connection = new SqlConnection(connectionString);
        //DataSet DS = new DataSet();
        //SqlDataAdapter DA = new SqlDataAdapter();
        string username;

        Inv_ManagerDataContext context = new Inv_ManagerDataContext();


        int getCategorie()
        {
            //connection.Open();

            //var cmdGetId = connection.CreateCommand();
            //cmdGetId.CommandType = System.Data.CommandType.Text;
            //cmdGetId.CommandText = "select ANGAJATI_ID from DETALII_CONT inner join ANGAJATI ON ANGAJATI.CONT_ID = DETALII_CONT.CONT_ID
            //inner join CREDENTIALE ON CREDENTIALE.CREDENTIALE_ID = ANGAJATI.CREDENTIALE_ID WHERE NUME_UTILIZATOR = '" + username + "'";
            //var id = cmdGetId.ExecuteReader();
            //id.Read();
            //int id_angajat = id.GetInt32(0);
            //id.Close();

            var id = (from detalii in context.DETALII_CONTs
                      join angajati in context.ANGAJATIs
                      on detalii.CONT_ID equals angajati.CONT_ID
                      join credentiale in context.CREDENTIALEs
                      on angajati.CREDENTIALE_ID equals credentiale.CREDENTIALE_ID
                      where credentiale.NUME_UTILIZATOR == username
                      select angajati.ANGAJATI_ID);
            int id_angajat = id.First();


            //var cmd = connection.CreateCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "select * FROM CATEGORIE_PRODUSE as C inner join PRODUSE as P on P.CATEGORIE_ID = C.CATEGORIE_ID
            //where C.CATEGORIE_ID = '" + id_angajat + "'";
            //var categ = cmd.ExecuteReader();
            //categ.Read();
            //categoria.Content = "Manager categoria   ->" + categ.GetValue(2).ToString() + "<-";

            //categ.Close();
            var categ = (from categorie in context.CATEGORIE_PRODUSEs
                         join produse in context.PRODUSEs
                         on categorie.CATEGORIE_ID equals produse.CATEGORIE_ID
                         where categorie.CATEGORIE_ID == id_angajat
                         select categorie.NUME);
            categoria.Content = "Manager categoria   ->" + categ.First() + "<-";



            //var Produse = connection.CreateCommand();
            //Produse.CommandType = System.Data.CommandType.Text;
            //Produse.CommandText = "select PRODUSE_ID, NUME, NUMAR_PRODUSE, PRET_BUCATA, DATA_FABRICATIE, DATA_EXPIRARE
            //FROM  PRODUSE  where PRODUSE.CATEGORIE_ID = '" + id_angajat + "'";

            //DA.SelectCommand = Produse;
            //DS.Clear();
            //DA.Fill(DS, "PRODUSE");
            //DataGrid_Prod.ItemsSource = DS.Tables[0].DefaultView;

            var Produse = (from produse in context.PRODUSEs
                           where produse.CATEGORIE_ID == id_angajat
                           select new
                           {
                               produse.PRODUSE_ID,
                               produse.NUME,
                               produse.NUMAR_PRODUSE,
                               produse.PRET_BUCATA,
                               produse.DATA_FABRICATIE,
                               produse.DATA_EXPIRARE
                           });
            DataGrid_Prod.ItemsSource = Produse;

            //connection.Close();
            return id_angajat;
        }



        public MainWindow(string username, string pass)
        {
            InitializeComponent();
            this.username = username;
            getCategorie();
        }

        private void Button_logout(object sender, RoutedEventArgs e)
        {
            LoginPage LP = new LoginPage();
            LP.Show();
            this.Close();
        }

        bool main = true;
        private void Button_profil(object sender, RoutedEventArgs e)
        {
            if (main)
            {
                profile_info.Visibility = Visibility.Visible;
                main_page.Visibility = Visibility.Hidden;
                profil.Content = "Main";
                main = false;
            }
            else
            {
                profile_info.Visibility = Visibility.Hidden;
                main_page.Visibility = Visibility.Visible;
                profil.Content = "Profil";
                main = true;
            }

            //connection.Open();
            //var cmd = connection.CreateCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "select NUME, PRENUME, ADRESA_EMAIL, DATA_NASTERE, TARA, ORAS
            //from DETALII_CONT inner join ANGAJATI ON ANGAJATI.CONT_ID = DETALII_CONT.CONT_ID
            //inner join CREDENTIALE ON CREDENTIALE.CREDENTIALE_ID = ANGAJATI.CREDENTIALE_ID WHERE NUME_UTILIZATOR = '" + username + "'";
            //SqlDataReader da = cmd.ExecuteReader();
            //da.Read();

            var cmd = (from detalii in context.DETALII_CONTs
                       join angajati in context.ANGAJATIs
                       on detalii.CONT_ID equals angajati.CONT_ID
                       join credentiale in context.CREDENTIALEs
                       on angajati.CREDENTIALE_ID equals credentiale.CREDENTIALE_ID
                       where credentiale.NUME_UTILIZATOR == username
                       select detalii.NUME);
            var cmd1 = (from detalii in context.DETALII_CONTs
                       join angajati in context.ANGAJATIs
                       on detalii.CONT_ID equals angajati.CONT_ID
                       join credentiale in context.CREDENTIALEs
                       on angajati.CREDENTIALE_ID equals credentiale.CREDENTIALE_ID
                       where credentiale.NUME_UTILIZATOR == username
                       select detalii.PRENUME);
            var cmd2 = (from detalii in context.DETALII_CONTs
                        join angajati in context.ANGAJATIs
                        on detalii.CONT_ID equals angajati.CONT_ID
                        join credentiale in context.CREDENTIALEs
                        on angajati.CREDENTIALE_ID equals credentiale.CREDENTIALE_ID
                        where credentiale.NUME_UTILIZATOR == username
                        select detalii.ADRESA_EMAIL);
            var cmd3 = (from detalii in context.DETALII_CONTs
                        join angajati in context.ANGAJATIs
                        on detalii.CONT_ID equals angajati.CONT_ID
                        join credentiale in context.CREDENTIALEs
                        on angajati.CREDENTIALE_ID equals credentiale.CREDENTIALE_ID
                        where credentiale.NUME_UTILIZATOR == username
                        select detalii.DATA_NASTERE);
            var cmd4 = (from detalii in context.DETALII_CONTs
                        join angajati in context.ANGAJATIs
                        on detalii.CONT_ID equals angajati.CONT_ID
                        join credentiale in context.CREDENTIALEs
                        on angajati.CREDENTIALE_ID equals credentiale.CREDENTIALE_ID
                        where credentiale.NUME_UTILIZATOR == username
                        select detalii.TARA);
            var cmd5 = (from detalii in context.DETALII_CONTs
                        join angajati in context.ANGAJATIs
                        on detalii.CONT_ID equals angajati.CONT_ID
                        join credentiale in context.CREDENTIALEs
                        on angajati.CREDENTIALE_ID equals credentiale.CREDENTIALE_ID
                        where credentiale.NUME_UTILIZATOR == username
                        select detalii.ORAS);

            label.Content = cmd.First();
            label1.Content = cmd1.First();
            label2.Content = cmd2.First();
            label3.Content = cmd3.First().ToString().Substring(0, 10);
            label4.Content = cmd4.First();
            label5.Content = cmd5.First();
            username_label.Content = "(" + cmd.First() + cmd1.First() + ")";

            //da.Close();
            //connection.Close();
        }


        private void ButtonADD_Click(object sender, RoutedEventArgs e)
        {
            int id = getCategorie();
            AddInventory A = new AddInventory(username, id);
            A.Show();
        }

        private void ButtonDEL_Click(object sender, RoutedEventArgs e)
        {
            Delete_page D = new Delete_page();
            D.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getCategorie();
        }

        private void ButtonPrice_Click(object sender, RoutedEventArgs e)
        {
            Price_page P = new Price_page();
            P.Show();
        }

        private void ButtonBuc_Click(object sender, RoutedEventArgs e)
        {
            NrBuc N = new NrBuc();
            N.Show();
        }
    }
}
