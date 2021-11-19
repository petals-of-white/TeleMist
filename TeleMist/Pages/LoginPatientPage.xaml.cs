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
            Database db = (Database)App.Current.TryFindResource("AccessDB");
            if (Password.Password == "" || PatientID.Text == "")
            {
                MessageBox.Show("Заповніть, нарешті, поля");
                return;
            }

            //пошук користувача
            List<Patient> patients = db.GetPatients($"SELECT * FROM [patient] WHERE" +
                $" [username]='{PatientID.Text}' AND [password]='{Password.Password}';");

            MessageBox.Show(patients.Count<Patient>().ToString());

            //Якщо не виникла помилка в процесі запиту І список користувачів не пустий (користувач існує).
            //Насправді, все це нижче бажано перенести в окрему функцію.
            if (patients != null && patients.Count > 0)
            {
                Patient patient = patients[0];
                MessageBox.Show("Суперуспішний успіх. Нарешті ми це зробили!!");
                /*using (StreamWriter outputFile = new StreamWriter("patient.txt"))
                {
                    outputFile.WriteLine(patient.ToString());
                }*/
                
                App.Current.Resources.Add("CurrentUser", patient);

                Patient patient1 = (Patient)App.Current.TryFindResource("CurrentUser");

                db.UpdatePatientInfo(patient); //оновлює всі необхідну інформацію
  

                MainWindow main = new MainWindow();
                App.Current.MainWindow.Close();
                main.Show();

            }
        }

    }
}
