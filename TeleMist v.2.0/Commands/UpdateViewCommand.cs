using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeleMist_v._2._0.ViewModels;

namespace TeleMist_v._2._0.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("test");
            if (parameter.ToString() == "greeting") {
                viewModel.SelectedViewModel = new GreetingViewModel();

            }
            else if (parameter.ToString() == "doctor") {
                viewModel.SelectedViewModel = new LoginDoctorViewModel();
            }
            else if (parameter.ToString() == "patient")
            {
                viewModel.SelectedViewModel = new LoginPatientViewModel();
            }
        }
    }
    
    
}
