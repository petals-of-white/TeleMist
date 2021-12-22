using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TeleMistUI.DB;
using TeleMistUI.Models;
using TeleMistUI.Windows;

namespace TeleMistUI.Resources.Styles
{

    public partial class Buttons : ResourceDictionary
    {
        public Buttons()
        {
            InitializeComponent();
            
        }
        private void OpenAppointmentMakingButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var doctor = (Doctor) button.DataContext;
            var currentUser = (Patient) App.Current.Resources ["CurrentUser"];

            //обов'язкові поля
            ArrayList requiredFields = new ArrayList {
                currentUser.FirstName, currentUser.Surname, currentUser.Patronym,
                currentUser.DateOfBirth
            };
            
            if (requiredFields.Contains("") || requiredFields.Contains(null))
            {
                MessageBox.Show("Перш ніж записуватися на консультацію, заповність особисту інформацію.", "Увага");
                return;
            }
            
            Window make_appointment = new MakeAppointmentWindow();
            make_appointment.Resources.Add("SelectedDoctor", doctor);
            make_appointment.Show();

        }

        private void ShowAppointmentDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var appointment = (Appointment) button.DataContext;
            Window appointmentDetails = new PatientAppointmentWindow();
            appointmentDetails.Resources.Add("SelectedAppointment", appointment);
            appointmentDetails.Show();
        }

        private void OpenCallWindowButton_Click(object sender, RoutedEventArgs e)
        {
            Window call_window = new CallWindow();
            call_window.Show();
        }

        private void FillAppointmentInfoButton_Click(object sender, RoutedEventArgs e)
        {
            Window appointment_info = new DoctorAppointmentInfoWindow();
            appointment_info.Show();
        }

        private void UpdateInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.Current.Resources ["CurrentUser"];
            Database db = (Database) App.Current.TryFindResource("AccessDB");
            if (currentUser is Patient)
            {
                db.UpdatePatientInfo(currentUser as Patient);
            }
            else if (currentUser is Doctor)
            {
                db.UpdateDoctorInfo(currentUser as Doctor);
            }
            else
            {
                //MessageBox.Show("Something is wrong with the type");
            }
            //Patient currentPatient = App.Current.Resources ["CurrentUser"] as Patient;
            //List<Appointment> appointments = App.Current.TryFindResource("HistoryOfAppointments") as List<Appointment>;
            //List<Doctor> doctos = App.Current.TryFindResource("Doctors") as List<Doctor>;

        }
        /// <summary>
        /// Скасовує відповідний запис до лікаря.
        /// У випадку успіху оновлює дані про лікарів і відвідування.
        /// Інакше повідомляє про помилку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelAppointmentButton_Click(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Ви точно бажаєте скасувати запис?", "Увага", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var button = (Button) sender;
                var doctor = (Doctor) button.DataContext; //одержимо контекст для кнопки скасування
                Appointment appointment = doctor.NextAppointment;
                var db = (Database) App.Current.TryFindResource("AccessDB");
                int res = db.Delete($"DELETE FROM [appointment] WHERE [id] = {appointment.Id}");
                Patient currentPatient = App.Current.Resources ["CurrentUser"] as Patient;
                if (res == 1)
                {
                    db.UpdatePatientInfo(currentPatient);
                    MessageBox.Show($"Запис до лікаря {doctor.FullName} скасовано."); ;
                }
                else
                    MessageBox.Show("Помилка скасування запису.");
            }
            else
            {

            }


        }

        private void ViewPatientDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var context = button.DataContext as Appointment;

            MessageBox.Show($"Пацієнт: {context.Patient.FullName}, {context.Patient.DateOfBirth}" +
                $"{context.Patient.Gender}, {context.Patient.Residence}");
        }
    }

}
