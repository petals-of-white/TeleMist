using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
namespace TeleMist
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application

    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            var vCulture = new CultureInfo("uk-UA");

            Thread.CurrentThread.CurrentCulture = vCulture;
            Thread.CurrentThread.CurrentUICulture = vCulture;

            base.OnStartup(e);
        }

        private void Application_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            //this.AccessDB = new Database();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

            string arrow = Path.GetFullPath(@"Images\reload_arrow.png");
            this.Resources.Add("ReloadArrow", arrow);
        }
    }

}
