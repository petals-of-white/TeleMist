﻿using System;
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
using System.Windows.Shapes;
using TeleMist.DB;
using TeleMist.Models;

namespace TeleMist.Windows
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Увага! Метод потребує ліпшої реялізації
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            string surname, firstName, patronym, gender, residence, insurance;
            DateTime dateOfBirth;

            surname = Surname.Text;
            firstName = FirstName.Text;
            patronym = Patronym.Text;
            gender = GenderBox.Text;
            residence = Residence.Text;
            insurance = Insurance.Text;
            dateOfBirth = DateOfBirth.SelectedDate.Value;

          
            Patient currentPatient = App.Current.TryFindResource("CurrentUser") as Patient;
            
            if (currentPatient != null)
            {
                //!!!!!ПОдумати над цим
                Database db = App.Current.TryFindResource("AccessDB") as Database;
                string sql = $"UPDATE [patient] SET " +
                    $"[surname] = '{surname}', [first_name] = '{firstName}', [patronym] = '{patronym}', " +
                    $"[gender] = '{gender}', [date_of_birth] = '{dateOfBirth}', [residence] = '{residence}', " +
                    $"[insurance] = '{insurance}' " +
                    $"WHERE [id] = {currentPatient.Id}";
                bool res = db.NonQuery(sql);
                if (res)
                {
                    MessageBox.Show("Дані про користувача успішно оновлено");
                    db.UpdatePatientInfo(currentPatient);
                    MessageBox.Show(App.Current.TryFindResource("CurrentUser").ToString());

                }
            }

            

        }

        private void LogOutButotn_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            App.Current.Resources.Remove("CurrentUser");
            App.Current.Resources.Remove("HistoryOfAppointments");
            //App.Current.Resources.Remove("ActiveAppointments");
            App.Current.Resources.Remove("Doctors");


            this.Close();
            auth.Show();

        }

        private void SortDoctorsByName_Checked(object sender, RoutedEventArgs e)
        {

            List<Doctor> doctors = App.Current.Resources["Doctors"] as List<Doctor>;

            var updatedDoctors = from doctor in new List<Doctor>(doctors)
                                select doctor;
            var sortedDoctors = updatedDoctors.ToList();
            sortedDoctors.Sort(new Doctor.NameComparer());

            App.Current.Resources["Doctors"] = sortedDoctors;

       //     DoctorsList.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("FullName",
       //System.ComponentModel.ListSortDirection.Ascending));



            
        }
        private void SortDoctorsByDate_Checked(object sender, RoutedEventArgs e)
        {
            List<Doctor> doctors = App.Current.Resources["Doctors"] as List<Doctor>;

            var updatedDoctors = from doctor in new List<Doctor>(doctors)
                                 select doctor;
            var sortedDoctors = updatedDoctors.ToList();
            sortedDoctors.Sort(new Doctor.DateComparer());

            App.Current.Resources["Doctors"] = sortedDoctors;
        }
        /// <summary>
        /// Сортування ресурсу в залежності від 
        /// <br></br>
        /// T - тип об'єкта в списку ресурсів
        /// </summary>
        /// <typeparam name="T">Тип об'єкта в списку</typeparam>
        /// <param name="resource"></param>
        /// <param name="method"></param>
        private void SortResource<T>(ref List<T> resource, IComparer<T> comparer)
        {
            List<T> newResource = new List<T>(resource);
            newResource.Sort(comparer);

            //newResource = resource.Select(item => (T)item.Clone()).ToList()
            resource = newResource;
        }
    }
}
