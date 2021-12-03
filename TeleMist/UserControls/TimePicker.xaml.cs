using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace TeleMist.UserControls
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimePicker()
        {
            InitializeComponent();
            Debug.WriteLine("HEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEj");
            this.DataContext = this;

            this.AllAppointmentHours = new List<string>(hours);

            //Debug.WriteLine("I'm gonna create buttons");
            //foreach (string text in AllAppointmentHours)
            //{
            //    Button timeButton;
            //    Debug.WriteLine("Button is being created");

            //    timeButton = new Button();

            //    awa.Children.Add(timeButton);

            //}


            //Debug.WriteLine("This has ended");

        }


        private List<string> _allAppointmentHours;


        public List<string> AllAppointmentHours
        {
            get { return _allAppointmentHours; }
            set { _allAppointmentHours = value; }
        }

        private static string [] hours = {
            "9:00", "9:30", "10:00", "10:30", "11:00", "11:30",
            "12:00", "12:30", "13:00", "13:30", "14:00", "14:30",
            "15:00", "15:30", "16:00"
        };



        private List<string> _unavailableHours; //maybe a DateTime type will be a better choice, not sur,e though.


        //public static readonly DependencyProperty AllHoursButtonsProperty = DependencyProperty.Register("AllHoursButtons",
        //    typeof(List<Button>), typeof(TimePicker), new PropertyMetadata(true));



        public static readonly DependencyProperty AppointmentDateProperty = DependencyProperty.Register("AppointmentDate",
            typeof(DateTime?),
            typeof(TimePicker));

        public static readonly DependencyProperty NumberButtonsProperty = DependencyProperty.Register(
            "NumberOfButtons",
            typeof(string),
            typeof(TimePicker));


        public List<string> UnavailableHours
        {
            get { return _unavailableHours; }
            set
            {
                _unavailableHours = value;


            }

        }

        public string NumberOfButtons
        {
            get { return (string) GetValue(NumberButtonsProperty); }
            set { SetValue(NumberButtonsProperty, value); }
        }

        public DateTime? AppointmentDate
        {

            get
            {
                Debug.WriteLine("Getting date to");


                DateTime? dateAndTime = (DateTime?) GetValue(AppointmentDateProperty);
                return dateAndTime;
            }
            set
            {
                if (value != null)
                {
                    Debug.WriteLine("Setting date to" + value);
                    SetValue(AppointmentDateProperty, value); //Задаємо значення дати
                    GetBusyHoursFromDb(); //дістаємо з бази даних інформацію про недоступні години
                    MakeButtons(); //створюємо кнопки, заборонивши вибирати недоступні
                }

            }
        }
        //public List<Button> AllHoursButtons
        //{

        //    get
        //    {
        //        List<Button> buttons = (List<Button>)GetValue(AllHoursButtonsProperty);
        //        return buttons;
        //    }

        //    set
        //    {

        //        SetValue(AllHoursButtonsProperty, value); //Задаємо значення дати
        //        /*GetBusyHoursFromDb(); //дістаємо з бази даних інформацію про недоступні години
        //        MakeButtons(); //створюємо кнопки, заборонивши вибирати недоступні*/
        //    }
        //}

        private void GetBusyHoursFromDb()
        {
            Debug.WriteLine("Getting from db");
            //doing something... date

            string [] test = { "16:00", "11:00", "10:00" };
            UnavailableHours = new List<string>(test);

        }



        private void MakeButtons()
        {

            Debug.WriteLine("I'm gonna create buttons");
            foreach (string text in AllAppointmentHours)
            {
                Button timeButton;
                Debug.WriteLine("Button is being created");
                if (UnavailableHours.Contains(text))
                {
                    timeButton = new Button();
                    timeButton.Content = "re";

                }
                else
                {
                    timeButton = new Button();
                    timeButton.Content = "re";

                }

                //AllHoursButtons.Add(timeButton);


            }


            Debug.WriteLine("This has ended");


        }









    }
}
