using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TeleMist;
using TeleMist.Models;
using System.Windows;
namespace TeleMist.DB
{
    public static class Helper
    {
        public static string ConStr()
        {
            string str = (string)App.Current.TryFindResource("ConnectionString");
            return str;
        }

        //public static void UpdateDoctorInfo(Doctor doctor)
        //{
        //    Database db = (Database)App.Current.TryFindResource("AccessDB");

        //    List<Patient> patients = db.GetPatients($"SELECT * FROM [doctor]");
        //    foreach (Patient patient in patients)
        //    {
        //        MessageBox.Show(patient.ToString());
        //    }

        //    if (patients != null)
        //    {

        //        App.Current.Resources.Add("Patients", patients);
        //    }

        //    List<Appointment> historyOfAppointments = db.GetAppointments($"SELECT * FROM [appointment] WHERE " +
        //            $"([doctor_id]={doctor.Id}) AND ([date_time] < Now())");

        //    foreach (Appointment appointment in historyOfAppointments)
        //        MessageBox.Show(appointment.ToString());


        //    if (historyOfAppointments != null)
        //        App.Current.Resources.Add("HistoryOfAppointments", historyOfAppointments);

        //    //майбутні консультації
        //    List<Appointment> activeAppointments = db.GetAppointments($"SELECT * FROM [appointment] WHERE " +
        //        $"([patient_id]={doctor.Id}) AND ([date_time] > Now())");


        //    if (activeAppointments != null)
        //    {
        //        App.Current.Resources.Add("ActiveAppointments", activeAppointments);

        //        //тестовий варіянт зв'язування відвідувань

        //        foreach (Appointment appointment in activeAppointments)
        //        {
        //            var tempDocs = from patient in patients // зі списку всіх доступних лікарів
        //                           where patient.Id == appointment.Patient.Id // де id лікаря = id лікаря в консультації
        //                           select patient; //вибрати лікаря (зазвичай поверне список з одного елемента (сподіваюсь))
        //            Patient pat = tempDocs.First();
        //            pat.NextAppointment = appointment;

        //        }
        //    }
        //}

        //public static void UpdatePatientInfo(Patient patient)
        //{
        //    /*    Type personType;
        //        string typeString;
        //        if (person.GetType() == typeof(Patient))
        //        {
        //            personType = typeof(Patient);
        //            typeString = "patient";
        //        }
        //        else if (person.GetType() == typeof(Doctor))
        //        {
        //            personType = typeof(Doctor);
        //            typeString = "doctor";
        //        }*/

        //    Database db = (Database)App.Current.TryFindResource("AccessDB");

        //    List<Doctor> doctors = db.GetDoctors($"SELECT * FROM [doctor]");
        //    foreach (Doctor doctor in doctors)
        //    {
        //        MessageBox.Show(doctor.ToString());
        //    }

        //    if (doctors != null)
        //    {
        //        App.Current.Resources.Add("Doctors", doctors);
        //    }

        //    List<Appointment> historyOfAppointments = db.GetAppointments($"SELECT * FROM [appointment] WHERE " +
        //            $"([patient_id]={patient.Id}) AND ([date_time] < Now())");

        //    foreach (Appointment appointment in historyOfAppointments)
        //        MessageBox.Show(appointment.ToString());


        //    if (historyOfAppointments != null)
        //        App.Current.Resources.Add("HistoryOfAppointments", historyOfAppointments);

        //    //майбутні консультації
        //    List<Appointment> activeAppointments = db.GetAppointments($"SELECT * FROM [appointment] WHERE " +
        //        $"([patient_id]={patient.Id}) AND ([date_time] > Now())");


        //    if (activeAppointments != null)
        //    {
        //        App.Current.Resources.Add("ActiveAppointments", activeAppointments);

        //        //тестовий варіянт зв'язування відвідувань

        //        foreach (Appointment appointment in activeAppointments)
        //        {
        //            var tempDocs = from doctor in doctors // зі списку всіх доступних лікарів
        //                           where doctor.Id == appointment.Doctor.Id // де id лікаря = id лікаря в консультації
        //                           select doctor; //вибрати лікаря (зазвичай поверне список з одного елемента (сподіваюсь))
        //            Doctor doc = tempDocs.First();
        //            doc.NextAppointment = appointment;

        //        }
        //    }

        //}
    }
}
