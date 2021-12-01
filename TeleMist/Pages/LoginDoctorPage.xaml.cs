using System;
using System.Collections.Generic;
using System.IO;
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
            Database db = (Database)App.Current.TryFindResource("AccessDB");

            if (Password.Password == "" || DoctorID.Text == "")
            {
                MessageBox.Show("Заповніть, нарешті, поля");
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

                Doctor doctor = doctors[0];

                MessageBox.Show("Суперуспішний успіх. Нарешті ми це зробили!!");
                /*using (StreamWriter outputFile = new StreamWriter("doctor.txt"))
                {
                    outputFile.WriteLine(doctor.ToString());
                }*/

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
