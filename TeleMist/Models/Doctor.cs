using System.Windows;

namespace TeleMist.Models
{
    public class Doctor : Person
    {

        public string Specialty { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, DoctgorID = {Username}, Password =  {Password}, {FullName}, {Gender}, {DateOfBirth}, {Residence}, {Specialty}";
        }


        public string CancelButtonVisibility
        {
            get
            {
                if (this.NextAppointment != null)
                    return "Visible";

                else
                    return "Hidden";

            }
        }
        public Style AppointmentStatus
        {
            get
            {
                Style style;

                if (this.NextAppointment == null)
                {
                    style = (Style) App.Current.TryFindResource("OpenAppointmentMakingButton");

                }
                else
                {
                    style = (Style) App.Current.TryFindResource("AppointmentMadeButton");

                }
                return style;

            }
        }


        //private void MakeAppointmentButon_Click(object sender, RoutedEventArgs e)
        //{

        //    MakeAppointmentWindow window = new MakeAppointmentWindow();
        //    Doctor selectedDoctor = this;
        //    window.Resources.Add("SelectedDoctor", selectedDoctor);
        //    window.Show();
        //}





    }
}
