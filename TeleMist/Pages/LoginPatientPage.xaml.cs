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

namespace TeleMist.Pages
{
    /// <summary>
    /// Interaction logic for LoginPatientPage.xaml
    /// </summary>
    public partial class LoginPatientPage : Page
    {
        public LoginPatientPage()
        {
            InitializeComponent();
        }

      
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GreetingPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPatientPage());
        }
    }
}
