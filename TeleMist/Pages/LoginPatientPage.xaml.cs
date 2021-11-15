﻿using System;
using System.Collections.Generic;
using System.IO;
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
using TeleMist.database;
using TeleMist.Models;
namespace TeleMist.Pages
{
    /// <summary>
    /// Interaction logic for LoginPatientPage.xaml
    /// </summary>
    public partial class LoginPatientPage : Page
    {
        public LoginPatientPage()
        {
            InitializeComponent();
        }

      
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GreetingPage());
        }

        private void LoginAsAPatient_Click(object sender, RoutedEventArgs e)
        {
            Database db = (Database)App.Current.TryFindResource("AccessDB");

            if (Password.Password == "" || PatientID.Text == "")
            {
                MessageBox.Show("Заповніть, нарешті, поля");
                return;
            }

            Patient patient = db.GetPatient($"SELECT * FROM [patient] WHERE [username]='{PatientID.Text}' AND [password]='{Password.Password}';");
            if (patient != null)
            {
                MessageBox.Show("Суперуспішний успіх. Нарешті ми це зробили!!");
                using (StreamWriter outputFile = new StreamWriter("win.txt"))
                {
                    outputFile.WriteLine(patient.ToString());
                }
            }
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPatientPage());
        }*/
    }
}
