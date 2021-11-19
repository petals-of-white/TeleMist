using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;
using TeleMist.DB;
using TeleMist.Models;

namespace TeleMist.Resources.Styles
{
    public partial class Buttons: ResourceDictionary
    { 
        public Buttons()
        {

            InitializeComponent();
        }
        private void OpenAppointmentMakingButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var doctor = (Doctor)button.DataContext;
            Window make_appointment = new MakeAppointmentWindow();
            make_appointment.Resources.Add("SelectedDoctor", doctor);


            make_appointment.Show();

        }

        private void ShowAppointmentDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var appointment = (Appointment)button.DataContext;
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
            Database db = (Database)App.Current.TryFindResource("AccessDB");
            Patient currentPatient = App.Current.Resources["CurrentUser"] as Patient;
            List<Appointment> appointments = App.Current.TryFindResource("HistoryOfAppointments") as List<Appointment>;
            List<Doctor> doctos = App.Current.TryFindResource("Doctors") as List<Doctor>;

            db.UpdatePatientInfo(currentPatient);
        }
    }

}
