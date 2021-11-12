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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TeleMist_v._2._0.Pages
{
    /// <summary>
    /// Interaction logic for GreetingPage.xaml
    /// </summary>
    public partial class GreetingPage : Page
    {
        //private Window kek;
        //private Frame frame;
        public GreetingPage()
        {
            InitializeComponent();
            //NavigationService();
            //frame = kek.FindName("MainFrame") as Frame;
            
        }

        private void DoctorButton_Click(object sender, RoutedEventArgs e)
        {
            LoginDoctorPage page = new LoginDoctorPage();
            NavigationService.Navigate(page);
        }

        private void PatientButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPatientPage page = new LoginPatientPage();
            NavigationService.Navigate(page);
        }

        private void GoToSignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage page = new SignUpPage();
            NavigationService.Navigate(page);
        }
    }
}
