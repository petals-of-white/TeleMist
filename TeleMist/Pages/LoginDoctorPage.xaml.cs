using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TeleMist.DB;
using TeleMist.Models;
using TeleMist.Windows;
namespace TeleMist.Pages
{
    /// <summary>
    /// Interaction logic for LoginDoctorPage.xaml
    /// </summary>
    public partial class LoginDoctorPage : Page
    {
        public LoginDoctorPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GreetingPage());
        }


        private void LoginAsADoctor_Click(object sender, RoutedEventArgs e)
        {
            Database db = (Database) App.Current.TryFindResource("AccessDB");

            if (Password.Password == "" || DoctorID.Text == "")
            {
                MessageBox.Show("Необхідно заповнити поля");
                return;
            }
            string passwordHash = Hasher.MD5Hash(Password.Password);

            /**/
            //Doctor doctor = db.GetDoctors($"SELECT * FROM [doctor] WHERE" +
            //    $" [username]='{DoctorID.Text}' AND [password]='{Password.Password}';")[0];
            List<Doctor> doctors = db.GetDoctors($"SELECT * FROM [doctor] WHERE" +
                $" [username]='{DoctorID.Text}' AND [password]='{passwordHash}';");
            if (doctors != null && doctors.Count > 0)
            {

                Doctor doctor = doctors [0];

                //MessageBox.Show("Суперуспішний успіх. Нарешті ми це зробили!!");

                App.Current.Resources.Add("CurrentUser", doctor);

                db.UpdateDoctorInfo(doctor);

                MainWindow main = new MainWindow();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = main;
                App.Current.MainWindow.Show();
            }
            else
            {
                Warning.Text = "Неможливо авторизуватись. Перевірте правильність уведення даних і повторіть спробу";
            }

        }



    }
}
