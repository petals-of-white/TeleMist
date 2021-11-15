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
                OleDbDataReader reader = selectCommand.ExecuteReader();
                reader.Read();
                patient.Id = reader.GetInt32(reader.GetOrdinal("id"));
                patient.Username = reader.GetString(reader.GetOrdinal("username"));
                patient.Password = reader.GetString(reader.GetOrdinal("password"));
                patient.Avatar = reader.GetString(reader.GetOrdinal("avatar"));
                patient.Surname = reader.GetString(reader.GetOrdinal("surname"));
                patient.FirstName = reader.GetString(reader.GetOrdinal("first_name"));
                patient.Patronym = reader.GetString(reader.GetOrdinal("patronym"));
                patient.Gender = reader.GetString(reader.GetOrdinal("gender"));
                patient.DateOfBirth = reader.GetString(reader.GetOrdinal("date_of_birth"));
                patient.Residence = reader.GetString(reader.GetOrdinal("residence"));
                patient.Insurance = reader.GetString(reader.GetOrdinal("insurance"));
            }


            catch (OleDbException e)
            {

                MessageBox.Show("Щось пішло не так " + e.Message);
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
            string message = "The changes you requested to the table were not successful because they would create duplicate values in the index, primary key, or relationship. Change the data in the field or fields that contain duplicate data, remove the index, or redefine the index to permit duplicate entries and try again.";


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
            if (obj == DBNull.Value) {
                return null;
            }
            return obj;
        }


    }
    
}
