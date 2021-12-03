using System;
using System.Windows.Input;
using TeleMist.Commands;

namespace TeleMist.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new GreetingViewModel();
        public BaseViewModel SelectedViewModel
        {
            get
            {
                return _selectedViewModel;
            }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand UpdateViewCommand { get; set; }
        public MainViewModel()
        {

            UpdateViewCommand = new UpdateViewCommand(this);
            Console.WriteLine($"{UpdateViewCommand}");
        }
    }
}
