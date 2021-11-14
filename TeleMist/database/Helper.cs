using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TeleMist;
namespace TeleMist.database
{
    public static class Helper
    {
        public static string ConStr()
        {
            string str = (string)App.Current.TryFindResource("ConnectionString");
            return str;
        }
    }
}
