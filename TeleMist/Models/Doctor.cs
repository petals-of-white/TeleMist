using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleMist.Models
{
    public class Doctor:Person
    {
        
        public string Specialty { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, DoctgorID = {Username}, Password =  {Password}, {FullName}, {Gender}, {DateOfBirth}, {Residence}, {Specialty}";
        }
        /* Нехай ми можемо записатись тільки на одну консультацію:
         * запис до одного лікаря на кілька консультацій уперед неможливий
   
         */


    }
}
