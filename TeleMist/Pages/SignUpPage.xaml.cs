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
using TeleMist.DB;
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
            if (UserID.Text == "")
            {
                Warning.Text = "Ім'я користувача не може бути порожнім";
                //MessageBox.Show("Ім'я користувача не може бути порожнім");
                return;
            }

            if (Password.Password == "" || CheckPassword.Password == "")
            {
                Warning.Text = "Пароль не може бути порожнім";
                //MessageBox.Show("Пароль не може бути порожнім");
                return;
            }

            if (Password.Password != CheckPassword.Password)
            {
                Warning.Text = "Паролі не збігаються. Будь ласка, перевірте.";
                //MessageBox.Show("Паролі не збігаються. Будь ласка, перевірте.");
                return;
            }

            
            
            Database db = (Database)App.Current.TryFindResource("AccessDB");

            string role;
            if (Doctor.IsChecked == true) {
                role = "doctor";
            }
            else
            {
                role = "patient";

            }

            
            int res = db.Insert($"INSERT INTO [{role}] ([username], [password]) VALUES ('{UserID.Text}', '{Password.Password}');");
            if (res == 1)
                MessageBox.Show("Успішний успіх");
            else
            {
                Warning.Text = "Неможливо авторизуватись. " +
                    "Перевірте правильність уведення даних і повторіть спробу";
            }



            /*MessageBox.Show("Зареєструвалися!!! Ура");*/
            /*App.AccessDb*/

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GreetingPage());
        }
    }
}
