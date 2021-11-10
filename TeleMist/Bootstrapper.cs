using Caliburn.Micro;
using System.Windows;
using TeleMist.ViewModels;

namespace TeleMist
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();

        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();

        }
    }
}
