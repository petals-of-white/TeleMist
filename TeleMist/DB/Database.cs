using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows;
using TeleMist.Models;
using System.Data;
using System.Linq;
namespace TeleMist.DB
{

    public class Database
    {
       
        private OleDbConnection Connection { get; set; }
        public Database()
        {
            this.Connection = new OleDbConnection(Helper.ConStr());

        }
        public List<Doctor> GetDoctors(string SQL)
        {
            bool toCloseConnection;
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
                toCloseConnection = true;
            }
            else
            {
                toCloseConnection= false;
            }
            OleDbCommand selectCommand = new OleDbCommand(SQL, Connection);
            List<Doctor> doctors = new List<Doctor>();
            try
            {

                OleDbDataReader reader = selectCommand.ExecuteReader();

                //Перевіримо, чи існують узагалі запитані записи в базі даних
                if (!reader.HasRows) {
                    MessageBox.Show("Немає такого користувача, мабуть");
                    return null;
                }

                /*
                 Привласнюємо отриманні значення з бази даних уластивостям об'єкта Patient,
                спершу перевіривши, чи не дорівнюють вони нулю за допомогою функції CheckNull
                 */
                while (reader.Read())
                {

                    Doctor doctor = new Doctor();
                    doctor.Id = (int)(TypedValue(reader["id"]));
                    doctor.Username = (string)(TypedValue(reader["username"]));
                    doctor.Password = (string)(TypedValue(reader["password"]));
                    //patient.Avatar = (int)(TypedValue(reader["avatar"]));
                    doctor.Surname = (string)(TypedValue(reader["surname"]));
                    doctor.FirstName = (string)(TypedValue(reader["first_name"]));
                    doctor.Patronym = (string)(TypedValue(reader["patronym"]));
                    doctor.Gender = (string)(TypedValue(reader["gender"]));
                    doctor.DateOfBirth = (DateTime?)(TypedValue(reader["date_of_birth"]));
                    doctor.Residence = (string)TypedValue(reader["residence"]);
                    doctor.Specialty = (string)TypedValue(reader["specialty"]);
                    doctors.Add(doctor);
                }

            }

            catch (OleDbException e)
            {
                MessageBox.Show("Щось пішло не так " + e.Message + e.Data + e.GetType() + e.InnerException);
                return null;
            }

            finally
            {
                if (toCloseConnection)
                    Connection.Close();
            }


            return doctors;
        }
        public List<Patient> GetPatients(string SQL)
        {

            bool toCloseConnection;
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
                toCloseConnection = true;
            }
            else
            {
                toCloseConnection = false;
            }
            OleDbCommand selectCommand = new OleDbCommand(SQL, Connection);

            List<Patient> patients = new List<Patient>(); //список пацієнтів

            try
            {
                OleDbDataReader reader = selectCommand.ExecuteReader();

                //Перевіримо, чи існують узагалі запитані записи в базі даних
                if (!reader.HasRows)
                {
                    MessageBox.Show("Немає такого користувача, мабуть");
                    return new List<Patient>();
                }


                while (reader.Read())
                {
                    /*
                 Привласнюємо отриманні значення з бази даних уластивостям об'єкта Patient,
                спершу перевіривши, чи не дорівнюють вони нулю за допомогою функції CheckNull
                 */
                    Patient patient = new Patient();
                    patient.Id = (int)(TypedValue(reader["id"]));
                    patient.Username = (string)(TypedValue(reader["username"]));
                    patient.Password = (string)(TypedValue(reader["password"]));
                    //patient.Avatar = (int)(TypedValue(reader["avatar"]));
                    patient.Surname = (string)(TypedValue(reader["surname"]));
                    patient.FirstName = (string)(TypedValue(reader["first_name"]));
                    patient.Patronym = (string)(TypedValue(reader["patronym"]));
                    patient.Gender = (string)(TypedValue(reader["gender"]));
                    patient.DateOfBirth = (DateTime?)(TypedValue(reader["date_of_birth"]));
                    patient.Residence = (string)TypedValue(reader["residence"]);
                    patient.Insurance = (string)TypedValue(reader["insurance"]);
                    patients.Add(patient);
                
                }

            }

            catch (OleDbException e)
            { 
                MessageBox.Show("Щось пішло не так " + e.Message + e.Data + e.GetType() + e.InnerException);
                return new List<Patient>();
            }

            finally
            {
                if (toCloseConnection)
                    Connection.Close();
            }


            return patients;
        }
        public List<Appointment> GetAppointments(string SQL)
        {
            Connection.Open();
            OleDbCommand selectCommand = new OleDbCommand(SQL, Connection);
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                OleDbDataReader reader = selectCommand.ExecuteReader();

                //Перевіримо, чи існують узагалі запитані записи в базі даних
                if (!reader.HasRows)
                {
                    MessageBox.Show("Немає відвідувань поки що");
                    return new List<Appointment>();
                }

                while (reader.Read())
                {
                    /*
                 Привласнюємо отриманні значення з бази даних уластивостям об'єкта Patient,
                спершу перевіривши, чи не дорівнюють вони нулю за допомогою функції CheckNull
                 */
                    Appointment appointment = new Appointment();
                    appointment.Id = (int)(TypedValue(reader["id"]));

                    //Спробуємо дістати методами GetPatients і GetDoctors
                    //відповідного пацієнта і лікаря замість індентифікатора


                    //!!! Перевірити наявність пацієнта
                    int doctorId = (int)(TypedValue(reader["doctor_id"]));

                    

                    //MessageBox.Show(reader.ToString());


                    
                    //!!! Перевірити наявність пацієнта
                    int patientId = (int)(TypedValue(reader["patient_id"]));
                    

                    appointment.Reason = (string)(TypedValue(reader["reason"]));
                    appointment.Date_Time = (DateTime?)(TypedValue(reader["date_time"]));
                    appointment.Diagnose = (string)TypedValue(reader["diagnose"]);
                    appointment.Recommendations = (string)TypedValue(reader["recommendations"]);
                    appointment.Status = (string)TypedValue((reader["status"]));
                    appointment.Doctor = GetDoctors($"SELECT * FROM [doctor] WHERE" +
                $" [id]={doctorId}")[0];
                    appointment.Patient = GetPatients($"SELECT * FROM [patient] WHERE" +
                $" [id]={patientId}")[0];

                    appointments.Add(appointment);

                }

            }

            catch (OleDbException e)
            {
                MessageBox.Show("Щось пішло не так " + e.Message + e.Data + e.GetType() + e.InnerException);
                return new List<Appointment>();
            }

            finally
            {
                Connection.Close();
            }

            // THE END
            return appointments;

        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public int Insert(string SQL)
        {

            Connection.Open();
            OleDbCommand InsertCommand = new OleDbCommand(SQL, Connection);

            try
            {
                InsertCommand.ExecuteNonQuery();

            }


            catch (OleDbException e)
            {

                MessageBox.Show("Щось пішло не так");

            }

            finally
            {
                Connection.Close();
            }
            return 1;

            //throw new NotImplementedException();
        }
        public void Kek(string test)
        {
            MessageBox.Show(test);

        }
        private object CheckNull(object obj)
        {
            /*
                Перевіряє, чи є отримане значення з БД типу DBNull
             */
            if (obj == DBNull.Value)
            {
                return null;
            }
            return obj;
        }
        private object TypedValue(object Field)
        {
            if (Field == DBNull.Value)
                return null;
            else return Field;
/*
            if (type == typeof(string))
            {
                return (string)Field;
            }
            if (type == typeof(int))
            {
                return (int)Field;
            }

            if (type == typeof(DateTime))
            {
                return (DateTime)Field;
            }*/

            

        }

        public void UpdateDoctorInfo(Doctor doctor)
        {
            //Database db = (Database)App.Current.TryFindResource("AccessDB");

            List<Patient> patients = GetPatients($"SELECT * FROM [doctor]");

            /*foreach (Patient patient in patients)
            {
                MessageBox.Show(patient.ToString());
            }*/

            if (patients != null)
            {
                App.Current.Resources["Patients"] = patients;

                //App.Current.Resources.Add("Patients", patients);
            }

            List<Appointment> historyOfAppointments = GetAppointments($"SELECT * FROM [appointment] WHERE " +
                    $"([doctor_id]={doctor.Id}) AND ([date_time] < Now())");

            //foreach (Appointment appointment in historyOfAppointments)
            //    MessageBox.Show(appointment.ToString());


            if (historyOfAppointments != null)
                App.Current.Resources["HistoryOfAppointments"] = historyOfAppointments;
                //App.Current.Resources.Add("HistoryOfAppointments", historyOfAppointments);

            //майбутні консультації
            List<Appointment> activeAppointments = GetAppointments($"SELECT * FROM [appointment] WHERE " +
                $"([patient_id]={doctor.Id}) AND ([date_time] > Now())");


            if (activeAppointments != null)
            {
                App.Current.Resources["ActiveAppointments"]  = activeAppointments;
                //App.Current.Resources.Add("ActiveAppointments", activeAppointments);

                //тестовий варіянт зв'язування відвідувань
                foreach (Appointment appointment in activeAppointments)
                {
                    var tempDocs = from patient in patients // зі списку всіх доступних лікарів
                                   where patient.Id == appointment.Patient.Id // де id лікаря = id лікаря в консультації
                                   select patient; //вибрати лікаря (зазвичай поверне список з одного елемента (сподіваюсь))
                    Patient pat = tempDocs.First();
                    pat.NextAppointment = appointment;

                }
            }
        }

        public void UpdatePatientInfo(Patient patient)
        {
            /*    Type personType;
                string typeString;
                if (person.GetType() == typeof(Patient))
                {
                    personType = typeof(Patient);
                    typeString = "patient";
                }
                else if (person.GetType() == typeof(Doctor))
                {
                    personType = typeof(Doctor);
                    typeString = "doctor";
                }*/

            //Database db = (Database)App.Current.TryFindResource("AccessDB");

            List<Doctor> doctors = GetDoctors($"SELECT * FROM [doctor]");

            //foreach (Doctor doctor in doctors)
            //{
            //    MessageBox.Show(doctor.ToString());
            //}

            if (doctors != null)
            {
                App.Current.Resources["Doctors"] = doctors;
                //App.Current.Resources.Add("Doctors", doctors);
            }

            List<Appointment> historyOfAppointments = GetAppointments($"SELECT * FROM [appointment] WHERE " +
                    $"([patient_id]={patient.Id}) AND ([date_time] < Now())");

            //foreach (Appointment appointment in historyOfAppointments)
            //    MessageBox.Show(appointment.ToString());


            if (historyOfAppointments != null)
                App.Current.Resources["HistoryOfAppointments"] = historyOfAppointments;
                //App.Current.Resources.Add("HistoryOfAppointments", historyOfAppointments);

            //майбутні консультації
            List<Appointment> activeAppointments = GetAppointments($"SELECT * FROM [appointment] WHERE " +
                $"([patient_id]={patient.Id}) AND ([date_time] > Now())");


            if (activeAppointments != null)
            {
                App.Current.Resources["ActiveAppointments"] = activeAppointments;
                //App.Current.Resources.Add("ActiveAppointments", activeAppointments);

                //тестовий варіянт зв'язування відвідувань

                foreach (Appointment appointment in activeAppointments)
                {
                    var tempDocs = from doctor in doctors // зі списку всіх доступних лікарів
                                   where doctor.Id == appointment.Doctor.Id // де id лікаря = id лікаря в консультації
                                   select doctor; //вибрати лікаря (зазвичай поверне список з одного елемента (сподіваюсь))
                    Doctor doc = tempDocs.First();
                    doc.NextAppointment = appointment;

                }
            }

        }

        public void LogOutUser()
        {
            App.Current.Resources.Clear();
        }
    }
}
