using System.Windows;
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


    }
}
