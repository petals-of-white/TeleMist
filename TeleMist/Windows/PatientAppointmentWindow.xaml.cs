using System.Windows;

namespace TeleMist
{
    /// <summary>
    /// Interaction logic for PatientAppointmentWindow.xaml
    /// </summary>
    public partial class PatientAppointmentWindow : Window
    {
        public PatientAppointmentWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
