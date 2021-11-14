using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows;

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
        public void Update()
        {
            throw new NotImplementedException();
        }
        public Array Select()
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
            

            catch(OleDbException e)
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


    }
}
