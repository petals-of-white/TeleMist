using System;

namespace TeleMist.Models
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
            return other.Date_Time.Value.CompareTo(this.Date_Time.Value);
            //if (this != null && other != null)
            //{
            //    return this.Date_Time.Value.CompareTo(other.Date_Time.Value);
            //}
            ////if (x.NextAppointment.Date_Time.HasValue && y.NextAppointment.Date_Time.HasValue)
            ////{
            ////    return x.NextAppointment.Date_Time.Value.CompareTo(y.NextAppointment.Date_Time.Value);
            ////}
            //else if (this == null && other != null)
            //{
            //    return 1;
            //}
            //else if (this != null && other == null)
            //{
            //    return -1;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public override string ToString()
        {
            return $"Id = {Id}, Doctor =  {Doctor.Id}, Patient = {Patient.Id}, Date = {Date_Time}";
        }


    }
}
