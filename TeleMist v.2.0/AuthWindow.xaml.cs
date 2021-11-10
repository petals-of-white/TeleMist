using System.Windows;
using TeleMist_v._2._0.ViewModels;
using TeleMist_v._2._0.Pages;
namespace TeleMist_v._2._0
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
