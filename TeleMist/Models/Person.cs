using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleMist.Models
{
    public class Person

    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronym { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }

        public string Residence { get; set; }
        
        /// <summary>
        /// Інформація про найближчу зустріч для протилежної сторонки
        /// </summary>
        public Appointment NextAppointment { get; set; }

        public int GenderBoxIndex
        {
            get
            {
                if (Gender == "Чоловік") return 0;
                else return 1;
            }
            set
            {
                if (value == 0) Gender = "Чоловік";
                else if (value == 1) Gender = "Жінка";
            }
        }
        public string FullName
        {
            get
            {
                return Surname + " " + FirstName + " " + Patronym;
            }
        }

        public class NameComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.FullName.CompareTo(y.FullName);
            }
        }

        public class DateComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)

            {
                if(x.NextAppointment != null && y.NextAppointment != null)
                {
                    return x.NextAppointment.CompareTo(y.NextAppointment);
                }
                //if (x.NextAppointment.Date_Time.HasValue && y.NextAppointment.Date_Time.HasValue)
                //{
                //    return x.NextAppointment.Date_Time.Value.CompareTo(y.NextAppointment.Date_Time.Value);
                //}
                else if (x.NextAppointment == null && y.NextAppointment != null)
                {
                    return 1;
                }
                else if (x.NextAppointment != null && y.NextAppointment == null) {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
       
    }
}
