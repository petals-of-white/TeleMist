using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TeleMist
{
    /// <summary>
    /// Interaction logic for MakeAppointmentWindow.xaml
    /// </summary>
    public partial class MakeAppointmentWindow : Window
    {
   
        private static string[] allAvailableHours = {
            "9:00", "9:30", "10:00", "10:30", "11:00", "11:30",
            "12:00", "12:30", "13:00", "13:30", "14:00", "14:30",
            "15:00", "15:30", "16:00"
        };
        private static bool[] states = { false, true };

        public MakeAppointmentWindow()
        {
            InitializeComponent();

        }

        private void MakeAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TimeBox.SelectedValue.ToString());

        }

        /*
        private void TimeBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show("kok");
        }

        private void TimeBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("kok");

        }

        private void AppointmentCalendar_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show("Було обрано іншу дату");
        }

        private void TimeInfoText_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show("Було обрано іншу дату");

        }
        */
        private void AppointmentCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Було обрано іншу дату");
            Database db = (Database)App.Current.TryFindResource("AccessDB");

            var currentDoctor = (Doctor)this.Resources["SelectedDoctor"];

            string dateStr = AppointmentCalendar.SelectedDate.Value.ToString("dd.MM.yyyy");

            string SQL = $"SELECT * FROM [appointment] WHERE " +
                $"DateValue([date_time]) = '{dateStr}' " +
                $"AND [doctor_id] = {currentDoctor.Id};";


            List<Appointment> appointments = db.GetAppointments(SQL);


            foreach (Appointment appointment in appointments)
            {
                MessageBox.Show(appointment.ToString());
            }

            IEnumerable<string> unavailableHours = from appointment in appointments
                                                   select appointment.Date_Time.Value.ToString("HH:mm").TrimStart('0');


            foreach (string hour in unavailableHours)
            {
                MessageBox.Show(hour);
            }
            List<AppointmentTime> times = new List<AppointmentTime>();

            var random = new Random();
            foreach (string hour in allAvailableHours)
            {
                MessageBox.Show(hour + "" + unavailableHours.FirstOrDefault());
                bool isAvailable = !unavailableHours.Contains(hour);
                times.Add(new AppointmentTime { Time = hour, available = isAvailable });
            }
    
            this.Resources["HoursForSelectedDate"] = times;

            //string time = appointments[0].Date_Time.Value.ToShortTimeString();


            //catch (Exception)
            //{
            //    MessageBox.Show("Не правилно щосваві");
            //}

        }

    }
}
