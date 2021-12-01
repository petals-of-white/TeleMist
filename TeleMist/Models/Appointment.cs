using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleMist.Models
{
    public class Appointment: IComparable<Appointment>
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
        }

        public override string ToString()
        {
            return $"Id = {Id}, Doctor =  {Doctor.Id}, Patient = {Patient.Id}, Date = {Date_Time}";
        }


    }
}
