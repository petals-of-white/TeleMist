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

                //усі лікарі
                List<Doctor> doctors = db.GetDoctors($"SELECT * FROM [doctor]");
                foreach (Doctor doctor in doctors)
                {
                    MessageBox.Show(doctor.ToString());
                }

                if (doctors != null)
                {
                    App.Current.Resources.Add("Doctors", doctors);
                }
                

                //завершені консультації
                List<Appointment> historyOfAppointments = db.GetAppointments($"SELECT * FROM [appointment] WHERE " +
                    $"([patient_id]={patient.Id}) AND ([date_time] < Now())");

                foreach(Appointment appointment in historyOfAppointments)
                {
                    MessageBox.Show(appointment.ToString());
                }
                if (historyOfAppointments != null)
                {
                    App.Current.Resources.Add("HistoryOfAppointments", historyOfAppointments);
                }

                //майбутні консультації
                List<Appointment> activeAppointments = db.GetAppointments($"SELECT * FROM [appointment] WHERE " +
                    $"([patient_id]={patient.Id}) AND ([date_time] > Now())");
                

                if (activeAppointments != null)
                {
                    App.Current.Resources.Add("ActiveAppointments", activeAppointments);

                    //тестовий варіянт зв'язування відвідувань

                    foreach(Appointment appointment in activeAppointments)
                    {
                        var tempDocs = from doctor in doctors // зі списку всіх доступних лікарів
                                  where doctor.Id == appointment.Doctor.Id // де id лікаря = id лікаря в консультації
                                  select doctor; //вибрати лікаря (зазвичай поверне список з одного елемента (сподіваюсь))
                        Doctor doc = tempDocs.First();
                        doc.NextAppointment = appointment;

                    }
                }

               


                MainWindow main = new MainWindow();
                App.Current.MainWindow.Close();
                main.Show();

            }
        }

    }
}
