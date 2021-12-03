using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace TeleMist.Pages
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
            var page = new LoginPatientPage();
            NavigationService.Navigate(page);
        }

        private void GoToSignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage page = new SignUpPage();
            NavigationService.Navigate(page);
        }
    }
}
