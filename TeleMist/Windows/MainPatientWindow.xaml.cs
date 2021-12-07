using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using TeleMist.DB;
using TeleMist.Helpers;
using TeleMist.Models;
using static TeleMist.Helpers.ResourceSorter;

namespace TeleMist.Windows
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPatientWindow : Window
    {
        public MainPatientWindow()
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
            byte [] selectedAvatar;

            try
            {
                surname = Surname.Text;
                selectedAvatar = this.Resources ["SelectedAvatar"] as byte [];
                firstName = FirstName.Text;
                patronym = Patronym.Text;
                gender = GenderBox.Text;
                residence = Residence.Text;
                insurance = Insurance.Text;
                dateOfBirth = DateOfBirth.SelectedDate.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Було введено неприпустимі значення полів");
                return;
            }


            Patient currentUser = App.Current.TryFindResource("CurrentUser") as Patient;

            if (currentUser != null)
            {
                //!!!!!ПОдумати над цим
                Database db = App.Current.TryFindResource("AccessDB") as Database;
                bool res; //результат виконання запиту
                string sql; //sql-рядок

                if (selectedAvatar != null) //з обраним зображенням мармизки
                {
                    sql = $"UPDATE [patient] SET " +
                    $"[surname] = '{surname}', [first_name] = '{firstName}', [patronym] = '{patronym}', " +
                    $"[gender] = '{gender}', [date_of_birth] = '{dateOfBirth}', [residence] = '{residence}', " +
                    $"[insurance] = '{insurance}', [avatar] = @binary " +
                    $"WHERE [id] = {currentUser.Id}";
                    res = db.NonQuery(sql, binaryParameter: selectedAvatar);
                }

                else
                { //без змін мармизки
                    sql = $"UPDATE [patient] SET " +
                    $"[surname] = '{surname}', [first_name] = '{firstName}', [patronym] = '{patronym}', " +
                    $"[gender] = '{gender}', [date_of_birth] = '{dateOfBirth}', [residence] = '{residence}', " +
                    $"[insurance] = '{insurance}'" +
                    $"WHERE [id] = {currentUser.Id}";
                    res = db.NonQuery(sql);

                }


                if (res)
                {
                    MessageBox.Show("Ваші дані успішно оновлено.");
                    db.UpdatePatientInfo(currentUser);
                    //MessageBox.Show(App.Current.TryFindResource("CurrentUser").ToString());

                }

            }

        }
        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Resources.Remove("CurrentUser");
            App.Current.Resources.Remove("HistoryOfAppointments");
            //App.Current.Resources.Remove("ActiveAppointments");
            App.Current.Resources.Remove("Doctors");

            AuthWindow auth = new AuthWindow();

            App.Current.MainWindow.Close();
            App.Current.MainWindow = auth;
            App.Current.MainWindow.Show();

        }
        private void SortDoctorsByName_Checked(object sender, RoutedEventArgs e)
        {

            SortResource<Doctor>("Doctors", new Doctor.NameComparer());

        }
        private void SortDoctorsByDate_Checked(object sender, RoutedEventArgs e)
        {
            SortResource<Doctor>("Doctors" , new Doctor.DateComparer());
        }
        
        
        private void SortHistoryByName_Checked(object sender, RoutedEventArgs e)
        {
            SortResource<Appointment>("HistoryOfAppointments", new Appointment.DoctorNameComparer());
        }
        private void SortHistoryByDate_Checked(object sender, RoutedEventArgs e)
        {
            SortResource<Appointment>("HistoryOfAppointments");

        }
        private void ChangeAvatarButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Зображення (.jpg, .png, .gif, .bmp)|*.jpg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);

                TestText.Text = openFileDialog.FileName + " вибрано як мармизку";
                ByteImageConverter converter = new ByteImageConverter();
                byte [] bytes = converter.ImageToByte(fs);



                this.Resources ["SelectedAvatar"] = bytes;
                Debug.WriteLine("Мармизку встановлено");

            }


        }
        //internal void SortResource<T>(string resourceName, IComparer<T> comparer)
        //{
        //    List<T> resources = App.Current.TryFindResource(resourceName) as List<T>;

        //    var updatedResources = from resource in new List<T>(resources)
        //                           select resource;
        //    var sortedResources = updatedResources.ToList();
        //    sortedResources.Sort(comparer);


        //    App.Current.Resources [resourceName] = sortedResources;

        //}
        //internal void SortResource<T>(string resourceName)
        //{
        //    List<T> resources = App.Current.TryFindResource(resourceName) as List<T>;
        //    var updatedResources = from resource in new List<T>(resources)
        //                           select resource;
        //    var sortedResources = updatedResources.ToList();
        //    sortedResources.Sort();
        //    App.Current.Resources [resourceName] = sortedResources;

        //}
    }
}
