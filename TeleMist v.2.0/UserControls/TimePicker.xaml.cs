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

namespace TeleMist_v._2._0.UserControls
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimePicker()
        {
            InitializeComponent();
        }


        private string[] hours = {
            "9:00", "9:30", "10:00", "10:30", "11:00", "11:30",
            "12:00", "12:30", "13:00", "13:30", "14:00", "14:30",
            "15:00", "15:30", "16:00"
        };

        private List<string> AllAppointmentHours = new List<string>(hours);

        public static readonly DependencyProperty AppointmentDateProperty = DependencyProperty.Register(
            "AppointmentDate",
            typeof(DateTime),
            typeof(TimePicker));

        private List<string> _unavailableHours; //maybe a DateTime type will be a better choice, not sur,e though.
        


        private DateTime _appointmentDate;

        private List<Button> allHoursButtons;
        public DateTime AppointmentDate
        {

            get
            {
                DateTime dateAndTime = (DateTime)GetValue(AppointmentDateProperty);
                return dateAndTime.Date;
            }
            set
            {

                SetValue(AppointmentDateProperty, value); //Задаємо значення дати
                GetBusyHoursFromDb(AppointmentDate); //дістаємо з бази даних інформацію про недоступні години
                MakeButtons(UnavailableHours); //створюємо кнопки, заборонивши вибирати недоступні
            }
        }
        private void GetBusyHoursFromDb(DateTime date)
        {
            //doing something... date

            string[] test = { "Heck", "Kek","Kok" };
            UnavailableHours = new List<string>(test);

        }
        

        /// <summary>
        /// Створює всі кнопки, розміщує їх у списку
        /// </summary>
        /// <param name="unavailableHours"></param>
        private void MakeButtons(List<string> unavailableHours)
        {

        }

        

        public List<string> UnavailableHours
        {
            get { return _unavailableHours; }
            set {
                _unavailableHours = value;

            
            }

        }

        


    }
}
