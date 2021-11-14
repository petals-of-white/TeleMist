using System.Windows;
using TeleMist.database;
namespace TeleMist
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application

    {
        //public Database AccessDB { get; set; }
        public App()
        {
            
            
        }

        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //this.AccessDB = new Database();
        }
    }
    
}
