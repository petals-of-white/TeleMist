using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;
namespace TeleMist_v._2._0
{
    public partial class ResourceTest : ResourceDictionary
    {
        public ResourceTest()
        {

            InitializeComponent();

        }

        private void OpenAppointmentDialogueClick(object sender, RoutedEventArgs e)
        {
            Window make_appointment = new MakeAppointmentWindow();
            make_appointment.Show();

        }

        private void ShowAppointmentDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            Window appointment_details = new PatientAppointmentWindow();
            appointment_details.Show();
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

     
    }
}
