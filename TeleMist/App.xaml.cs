using System.Windows;
using TeleMist.DB;
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
            //InitializeComponent();
            //this.Resources["ReloadArrowImg"] = getpath
        }

        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //this.AccessDB = new Database();
        }
    }
    
}
