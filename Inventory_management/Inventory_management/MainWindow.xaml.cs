﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static String connectionString = "Server=.;Database=Inventory_Management;Trusted_Connection=true";
        SqlConnection connection = new SqlConnection(connectionString);
        DataSet set = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();
        string username;
        public MainWindow(string username,string pass)
        {
            InitializeComponent();
            this.username = username;
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
                profile_info.Visibility = Visibility.Visible;
                info_visi = false;
            }
            else
            {
                profile_info.Visibility = Visibility.Hidden;
                info_visi = true;
            }


            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select NUME, PRENUME, ADRESA_EMAIL, DATA_NASTERE, TARA, ORAS from DETALII_CONT inner join ANGAJATI ON ANGAJATI.CONT_ID = DETALII_CONT.CONT_ID inner join CREDENTIALE ON CREDENTIALE.CREDENTIALE_ID = ANGAJATI.CREDENTIALE_ID WHERE NUME_UTILIZATOR = '" + username + "'";
            SqlDataReader da = cmd.ExecuteReader();
            while(da.Read())
            {
                label.Content = da.GetValue(0).ToString();
                label1.Content = da.GetValue(1).ToString();
                label2.Content = da.GetValue(2).ToString();
                label3.Content = da.GetValue(3).ToString();
                label4.Content = da.GetValue(4).ToString();
                label5.Content = da.GetValue(5).ToString();
            }
            connection.Close();

        }
    }
}
