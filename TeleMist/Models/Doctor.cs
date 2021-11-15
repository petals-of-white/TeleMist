using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleMist.Models
{
    internal class Doctor
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronym { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Residence { get; set; }
        public string Specialty { get; set; }

        public string FullName
        {
            get
            {
                return Surname + " " + FirstName + " " + Patronym;
            }
        }
        public override string ToString()
        {
            return $"Id = {Id}, DoctgorID = {Username}, Password =  {Password}, {FullName}, {Gender}, {DateOfBirth}, {Residence}, {Specialty}";
        }

    }
}
