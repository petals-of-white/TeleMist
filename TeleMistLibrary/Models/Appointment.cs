using System;
using System.Collections.Generic;

namespace TeleMistLibrary.Models
{
    public class Appointment : IComparable<Appointment>
    {
        public int Id { get; set; }
        //public int PatientId { get; set; }
        //public int DocgtorId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime? Date_Time { get; set; }
        public string Reason { get; set; }
        public string Diagnose { get; set; }
        public string Recommendations { get; set; }
        public string Status { get; set; }

        public int CompareTo(Appointment other)
        {
            return Date_Time.Value.CompareTo(other.Date_Time.Value);

        }

        public class PatientNameComparer : IComparer<Appointment>
        {
            public int Compare(Appointment x, Appointment y)
            {
                return x.Patient.FullName.CompareTo(y.Patient.FullName);
            }
        }

        public class DateComparer : IComparer<Appointment>
        {
            public int Compare(Appointment x, Appointment y)
            {
                if (x != null && y != null)
                {
                    return x.CompareTo(y);
                }

                else if (x == null && y != null)
                {
                    return -1;
                }
                else if (x != null && y == null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class DoctorNameComparer : IComparer<Appointment>
        {
            public int Compare(Appointment x, Appointment y)
            {
                return x.Doctor.FullName.CompareTo(y.Doctor.FullName);
            }
        }

        public override string ToString()
        {
            return $"Id = {Id}, Doctor =  {Doctor.Id}, Patient = {Patient.Id}, Date = {Date_Time}";
        }


    }
}
