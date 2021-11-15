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
using TeleMist.database;
using TeleMist.Models;
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

            Database db = (Database)App.Current.TryFindResource("AccessDB");

            if (Password.Password == "" || DoctorID.Text == "")
            {
                MessageBox.Show("Заповніть, нарешті, поля");
                return;
            }

            //Doctor doctor = db.GetDoctor($"SELECT * FROM [patient] WHERE [id]={PatientID.Text} AND [password]='{Password.Password}';");
            //if (doctor != null)
            //{
             //   MessageBox.Show("Суперуспішний успіх. Нарешті ми це зробили!! " + doctor.Id + " " + doctor.Password);
            //}
        }

    }
}
