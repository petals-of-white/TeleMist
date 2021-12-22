using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TeleMistUI.DB;
using TeleMistUI.Models;
using TeleMistUI.Windows;
namespace TeleMistUI.Pages
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

            //пошук користувача
            var doctors = db.GetDoctors($"SELECT * FROM [doctor] WHERE"
                + $" [username]='{DoctorID.Text}' AND [password]='{passwordHash}';");

            //Якщо не виникла помилка в процесі запиту І список користувачів не пустий (користувач існує).
            //Насправді, все це нижче бажано перенести в окрему функцію.
            if (doctors != null && doctors.Count > 0)
            {
                Doctor doctor = doctors [0];
                App.Current.Resources ["CurrentUser"] = doctor;
                db.UpdateDoctorInfo(doctor); //оновлює всі необхідну інформацію

                //головне вікно
                MainDoctorWindow main = new();
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
