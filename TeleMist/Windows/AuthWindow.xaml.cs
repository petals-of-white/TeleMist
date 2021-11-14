using System.Windows;
using TeleMist.ViewModels;
using TeleMist.Pages;
namespace TeleMist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            MainFrame.Content = new GreetingPage();
            //DataContext = new MainViewModel();
            
        }

       /* private void DoctorButton_Click(object sender, RoutedEventArgs e)
        {
            Window DoctorWindow = new LoginDoctorWindow();
            DoctorWindow.Show();
        }*/
    }
}
