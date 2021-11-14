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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private void SingUpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Зареєструвалися!!! Ура");
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GreetingPage());
        }
    }
}
