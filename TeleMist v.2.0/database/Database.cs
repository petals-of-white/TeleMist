﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Microsoft.
namespace TeleMist_v._2._0.database
{
    class Database {
        string Name, Path, ConnectionString;
        
        public Database(string Name)
        {
            this.Name = @"App_Data\" + Name;
            ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; " +
                           "Data Source = " + Path + ";" +
                           "Persist Security Info = False;";
            Connection = new OleDbConnection(ConnectionString);
        }
    }
}
