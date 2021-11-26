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

namespace TeleMist
{
    /// <summary>
    /// Interaction logic for MakeAppointmentWindow.xaml
    /// </summary>
    public partial class MakeAppointmentWindow : Window
    {
        public MakeAppointmentWindow()
        {
            InitializeComponent();
            this.Resources["SelectedDoctorDate"] = new List<string> {"sas","sos","sus" };
        }

        private void MakeAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((string)TimeBox.SelectedValue);
        }
    }
}
