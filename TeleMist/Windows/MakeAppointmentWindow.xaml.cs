using System;
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
using TeleMist.Models;

namespace TeleMist
{
    /// <summary>
    /// Interaction logic for MakeAppointmentWindow.xaml
    /// </summary>
    public partial class MakeAppointmentWindow : Window
    {
        private static string[] hours = {
            "9:00", "9:30", "10:00", "10:30", "11:00", "11:30",
            "12:00", "12:30", "13:00", "13:30", "14:00", "14:30",
            "15:00", "15:30", "16:00"
        };
        private static bool[] states = { false, true };

        public MakeAppointmentWindow()
        {
            InitializeComponent();


            var times = new List<AppointmentTime>();
            var random = new Random();
            foreach (string hour in hours)
            {
                times.Add(new AppointmentTime { Time = hour, available = states[random.Next(2)] });
            }
            //times.Add(new AppointmentTime {Time="11:30", available=true });
            //times.Add(new AppointmentTime { Time = "10:00", available = false });

            //times.Add(new AppointmentTime { Time = "9:00", available = true });
            //times.Add(new AppointmentTime {Time="13:00", available = false });
            this.Resources["HoursForSelectedDate"] = times;
        }

        private void MakeAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((string)TimeBox.SelectedValue);
        }
    }
}
