using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using TeleMist.DB;
using TeleMist.Models;
using TeleMist.Windows;
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

        private void LoginAsAPatient_Click(object sender, RoutedEventArgs e)
        {

            Database db = (Database) App.Current.TryFindResource("AccessDB");
            if (Password.Password == "" || PatientID.Text == "")
            {
                MessageBox.Show("Необхідно заповнити поля");
                return;
            }

            string passwordHash = Hasher.MD5Hash(Password.Password);

            //пошук користувача
            var patients = db.GetPatients($"SELECT * FROM [patient] WHERE"
                + $" [username]='{PatientID.Text}' AND [password]='{passwordHash}';");

            //Якщо не виникла помилка в процесі запиту І список користувачів не пустий (користувач існує).
            //Насправді, все це нижче бажано перенести в окрему функцію.
            if (patients != null && patients.Count > 0)
            {
                Patient patient = patients [0];
                App.Current.Resources ["CurrentUser"] = patient;
                db.UpdatePatientInfo(patient); //оновлює всі необхідну інформацію

                //головне вікно
                MainPatientWindow main = new MainPatientWindow();
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
