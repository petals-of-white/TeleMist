using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TeleMist.DB;
using TeleMist.Models;
using TeleMist.Windows;

namespace TeleMist.Resources.Styles
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
            Database db = (Database) App.Current.TryFindResource("AccessDB");
            Patient currentPatient = App.Current.Resources ["CurrentUser"] as Patient;
            List<Appointment> appointments = App.Current.TryFindResource("HistoryOfAppointments") as List<Appointment>;
            List<Doctor> doctos = App.Current.TryFindResource("Doctors") as List<Doctor>;

            db.UpdatePatientInfo(currentPatient);
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
    }

}
