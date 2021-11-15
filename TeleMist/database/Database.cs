using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using TeleMist.Models;
namespace TeleMist.database
{

    public class Database
    {


        private OleDbConnection Connection { get; set; }

        public Database()
        {
            this.Connection = new OleDbConnection(Helper.ConStr());


            /*this.Name = @"App_Data\" + Name;
            ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; " +
                           "Data Source = " + Path + ";" +
                           "Persist Security Info = False;";*/

        }
        public Patient GetPatient(string SQL)
        {
            Connection.Open();
            OleDbCommand selectCommand = new OleDbCommand(SQL, Connection);
            Patient patient = new Patient();
            try
            {
                /*
                 Привласнюємо отриманні значення з бази даних уластивостям об'єкта Patient,
                спершу перевіривши, чи не дорівнюють вони нулю за допомогою функції CheckNull
                 */

                OleDbDataReader reader = selectCommand.ExecuteReader();
                reader.Read();
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
                


                /*patient.Id = (int)CheckNull(reader.GetInt32(reader.GetOrdinal("id")));*/
                /*                patient.Username = (string)CheckNull(reader.GetString(reader.GetOrdinal("username")));
                                patient.Password = (string)CheckNull(reader.GetString(reader.GetOrdinal("password")));
                                //patient.Avatar = (string)CheckNull(reader.GetString(reader.GetOrdinal("avatar")));
                                patient.Surname = CheckNull(reader.GetString(reader.GetOrdinal("surname")));
                                patient.FirstName = (string)CheckNull(reader.GetString(reader.GetOrdinal("first_name")));
                                patient.Patronym = (string)CheckNull(reader.GetString(reader.GetOrdinal("patronym")));
                                patient.Gender = (string)CheckNull(reader.GetString(reader.GetOrdinal("gender")));
                                patient.DateOfBirth = (DateTime)CheckNull(reader.GetDateTime(reader.GetOrdinal("date_of_birth")));
                                patient.Residence = (string)CheckNull(reader.GetString(reader.GetOrdinal("residence")));
                                patient.Insurance = (string)CheckNull(reader.GetString(reader.GetOrdinal("insurance")));*/

            }

            catch (OleDbException e)
            {

                MessageBox.Show("Щось пішло не так " + e.Message + e.Data + e.GetType() + e.InnerException);
                return null;

            }

            finally
            {
                Connection.Close();
            }


            return patient;
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

    }
}
