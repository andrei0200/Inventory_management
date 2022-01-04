using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Globalization;

namespace Inventory_Manager
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        //static String connectionString = "Server=.;Database=Inventory_Management;Trusted_Connection=true";
        //SqlConnection connection = new SqlConnection(connectionString);
        //DataSet set = new DataSet();
        //SqlDataAdapter adapter = new SqlDataAdapter();
        Inv_ManagerDataContext context = new Inv_ManagerDataContext();

        String getCurDate()
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-US");
            var date = localDate.ToString(culture);
            date = date.Substring(0, 10);
            return date;
        }

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nume = in_nume.Text;
            String prenume = in_prenume.Text;
            String email = in_email.Text;
            String parola = in_parola.Text;
            String data = in_dataN.Text;
            String tara = in_tara.Text;
            String oras = in_oras.Text;
            String username = nume + prenume;

            if (string.IsNullOrWhiteSpace(nume) || string.IsNullOrWhiteSpace(prenume) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(parola) || string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(tara) || string.IsNullOrWhiteSpace(oras))
            {
                MessageBox.Show("Nu ati completat toate campurile!", "ERAORE", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //connection.Open();
            //var cmd = connection.CreateCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "select * from CREDENTIALE where NUME_UTILIZATOR = '" + username + "'";

            var cmd = (from credentiale in context.CREDENTIALEs
                       where credentiale.NUME_UTILIZATOR == username
                       select credentiale);
            if (cmd.Any())
            {
                MessageBox.Show("Username existent!", "ERAORE", MessageBoxButton.OK, MessageBoxImage.Warning);
                //result.Close();
                //connection.Close();
                return;
            }
            //result.Close();




            try
            {
                //var cmdInsertCred = new SqlCommand(@"INSERT INTO CREDENTIALE(
                // [NUME_UTILIZATOR], [PAROLA] ) 
                //    VALUES (
                // @user, @pass)", connection);

                //cmdInsertCred.Parameters.AddWithValue("@user", username);
                //cmdInsertCred.Parameters.AddWithValue("@pass", parola);
                //var InsertCred = cmdInsertCred.ExecuteReader();
                //InsertCred.Close();
                CREDENTIALE crd = new CREDENTIALE
                {
                    NUME_UTILIZATOR = username,
                    PAROLA = parola
                };
                context.CREDENTIALEs.InsertOnSubmit(crd);
                context.SubmitChanges();


                //var cmdCredID = connection.CreateCommand();
                //cmdCredID.CommandType = System.Data.CommandType.Text;
                //cmdCredID.CommandText = "select CREDENTIALE_ID from CREDENTIALE where NUME_UTILIZATOR = '" + username + "'";
                //var CredID = cmdCredID.ExecuteReader();
                //CredID.Read();
                //int ID_Cred = CredID.GetInt32(0);
                //CredID.Close();
                int ID_Cred = (from credentiale in context.CREDENTIALEs
                               where credentiale.NUME_UTILIZATOR == username
                               select credentiale.CREDENTIALE_ID).First();


                //var cmdInsertDetalii = new SqlCommand(@"INSERT INTO DETALII_CONT(
                // [NUME], [PRENUME], [ADRESA_EMAIL], [DATA_NASTERE], [TARA], [ORAS] ) 
                //    VALUES (
                // @nume, @prenume, @email, @data, @tara, @oras)", connection);

                //cmdInsertDetalii.Parameters.AddWithValue("@nume", nume);
                //cmdInsertDetalii.Parameters.AddWithValue("@prenume", prenume);
                //cmdInsertDetalii.Parameters.AddWithValue("@email", email);
                //cmdInsertDetalii.Parameters.AddWithValue("@data", data);
                //cmdInsertDetalii.Parameters.AddWithValue("@tara", tara);
                //cmdInsertDetalii.Parameters.AddWithValue("@oras", oras);
                //var InsertDetalii = cmdInsertDetalii.ExecuteReader();
                //InsertDetalii.Close();

                DETALII_CONT det = new DETALII_CONT
                {
                    NUME = nume,
                    PRENUME = prenume,
                    ADRESA_EMAIL = email,
                    DATA_NASTERE = Convert.ToDateTime(data),
                    TARA = tara,
                    ORAS = oras
                };
                context.DETALII_CONTs.InsertOnSubmit(det);
                context.SubmitChanges();


                //var cmdDetaliiID = connection.CreateCommand();
                //cmdDetaliiID.CommandType = System.Data.CommandType.Text;
                //cmdDetaliiID.CommandText = "select CONT_ID from DETALII_CONT where NUME = '" + nume + "'
                //and PRENUME = '" + prenume + "'";
                //var DetaliiID = cmdDetaliiID.ExecuteReader();
                //DetaliiID.Read();
                //int ID_Detalii = DetaliiID.GetInt32(0);
                //DetaliiID.Close();
                int ID_Detalii = (from detalii in context.DETALII_CONTs
                                    where detalii.NUME == nume && detalii.PRENUME == prenume
                                    select detalii.CONT_ID).First();


                string date = getCurDate();

                //var cmdInsertAng = new SqlCommand(@"INSERT INTO ANGAJATI(
                // [CREDENTIALE_ID], [CONT_ID], [ANUL_ANGAJARII] ) 
                //    VALUES (
                // @credentiale, @cont, @date)", connection);

                //cmdInsertAng.Parameters.AddWithValue("@credentiale", ID_Cred);
                //cmdInsertAng.Parameters.AddWithValue("@cont", ID_Detalii);
                //cmdInsertAng.Parameters.AddWithValue("@date", date);
                //var InsertAng = cmdInsertAng.ExecuteReader();
                //InsertAng.Close();

                ANGAJATI ang = new ANGAJATI
                {
                    CREDENTIALE_ID = ID_Cred,
                    CONT_ID = ID_Detalii,
                    ANUL_ANGAJARII = Convert.ToDateTime(date)
                };
                context.ANGAJATIs.InsertOnSubmit(ang);
                context.SubmitChanges();


                MessageBox.Show("Cont adaugat cu succes!", "SUCCES", MessageBoxButton.OK, MessageBoxImage.Information);
                LoginPage login = new LoginPage();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Eroare " + ex.ToString());
            }
            //connection.Close();
        }
    }
}
