using System.Windows.Input;
using WPF.Commands;
using WPF.Common.Enums;
using WPF.Models;
using WPF.Models.Requests;
using WPF.Services;
using WPF.Stores;

namespace WPF.ViewModels
{
    public class CreateScenarioViewModel : ViewModelBase
    {
        private string _name = "Scenario";
        private int _maxRate = 0;
        private int _interval = 0;
        private int _duration = 0;
        private Tests _selectedTest = Tests.Load;
        private RequestParametres _selectedRequest;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int MaxRate
        {
            get
            {
                return _maxRate;
            }
            set
            {
                _maxRate = value;
                OnPropertyChanged(nameof(MaxRate));
            }
        }

        public int Interval
        {
            get
            {
                return _interval;
            }
            set
            {
                _interval = value;
                OnPropertyChanged(nameof(Interval));
            }
        }

        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        public List<Tests> TestTypes { get; set; }

        public Tests SelectedTest
        {
            get
            {
                return _selectedTest;
            }
            set
            {
                _selectedTest = value;
                OnPropertyChanged(nameof(SelectedTest));
            }
        }

        public List<RequestParametres> Requests { get; set; }

        public RequestParametres SelectedRequest
        {
            get 
            {
                return _selectedRequest; 
            }
            set 
            { 
                _selectedRequest = value;
                OnPropertyChanged(nameof(SelectedRequest));
            }
        }


        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateScenarioViewModel(ScenarioManager scenarioManager, NavigationService navigationService)
        {
            TestTypes = Enum.GetValues(typeof(Tests)).Cast<Tests>().ToList();
            Requests = scenarioManager.GetRequestParametres().ToList();
            SubmitCommand = new CreateScenarioCommand(scenarioManager, this, navigationService);
            CancelCommand = new NavigateCommand(navigationService);
        }
    }
}
