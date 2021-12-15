using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TeleMist.DB;
using TeleMist.Models;

namespace TeleMist
{
    /// <summary>
    /// Interaction logic for MakeAppointmentWindow.xaml
    /// </summary>
    public partial class MakeAppointmentWindow : Window
    {

        private static string [] allAvailableHours = {
            "9:00", "9:30", "10:00", "10:30", "11:00", "11:30",
            "12:00", "12:30", "13:00", "13:30", "14:00", "14:30",
            "15:00", "15:30", "16:00"
        };
        private static bool [] states = { false, true };

        public MakeAppointmentWindow()
        {
            InitializeComponent();

        }

        private void MakeAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (AppointmentCalendar.SelectedDate == null)
            {
                MessageBox.Show("Оберіть дату");
                return;
            }

            if (TimeBox.SelectedValue == null)
            {
                MessageBox.Show("Оберіть час");
                return;
            }

            //MessageBox.Show(TimeBox.SelectedValue.ToString());

            if (AppointmentCalendar.SelectedDate.Value < DateTime.Now)
            {
                MessageBox.Show("Неможливо записатися в минуле");
                return;
            }
            Database db = (Database) App.Current.TryFindResource("AccessDB");

            var currentPatient = App.Current.Resources ["CurrentUser"] as Patient;
            var selectedDoctor = this.Resources ["SelectedDoctor"] as Doctor;

            DateTime appTime = DateTime.Parse(AppointmentCalendar.SelectedDate.Value.ToShortDateString() + " " + ((AppointmentTime) TimeBox.SelectedValue).Time);
            //MessageBox.Show(appTime.ToString());
            string SQL = $"INSERT INTO [appointment] ([patient_id], [doctor_id], " +
            $"[date_time], [status]) " +
            $"VALUES ({currentPatient.Id}, {selectedDoctor.Id}, '{appTime}', 'Заплановано')";
            bool res = db.NonQuery(SQL);
            if (res)
            {
                MessageBox.Show($"Вас записано на консультацію до лікаря {selectedDoctor.FullName}");
                db.UpdatePatientInfo(currentPatient);
                this.Close();
            }
          

        }

        private void AppointmentCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            //MessageBox.Show("Було обрано іншу дату");
            Database db = (Database) App.Current.TryFindResource("AccessDB");
            var currentDoctor = (Doctor) this.Resources ["SelectedDoctor"];
            string dateStr = AppointmentCalendar.SelectedDate.Value.ToString("dd.MM.yyyy");
            string SQL = $"SELECT * FROM [appointment] WHERE " +
                $"DateValue([date_time]) = '{dateStr}' " +
                $"AND [doctor_id] = {currentDoctor.Id};";


            List<Appointment> appointments = db.GetAppointments(SQL);

            IEnumerable<string> unavailableHours = from appointment in appointments
                                                   select appointment.Date_Time.Value.ToString("HH:mm").TrimStart('0');

            List<AppointmentTime> times = new List<AppointmentTime>();
            
            foreach (string hour in allAvailableHours)
            {
                //MessageBox.Show(hour + "" + unavailableHours.FirstOrDefault());
                bool isAvailable = !unavailableHours.Contains(hour);
                times.Add(new AppointmentTime { Time = hour, available = isAvailable });
            }
            this.Resources ["HoursForSelectedDate"] = times;
        }

    }
}
