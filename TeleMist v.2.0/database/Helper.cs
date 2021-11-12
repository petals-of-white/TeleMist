using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TeleMist_v._2._0;
namespace TeleMist_v._2._0.database
{
    public static class Helper
    {
        public static string ConStr(string name)
        {
            string str = (string)App.Current.FindResource("connectionString");
            return str;
        }
    }
}
