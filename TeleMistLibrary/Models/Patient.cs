namespace TeleMistLibrary.Models
{
    public class Patient : Person
    {
        public string Insurance { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, PatientID = {Username}, Password =  {Password}, {FullName}, {Gender}, {DateOfBirth}, {Residence}, {Insurance}";
        }

        /* Нехай ми можемо записатись тільки на одну консультацію:
         * запис до одного лікаря на кілька консультацій уперед неможливий
         */
        //public Appointment NextAppointment { get; set; }



    }
}
