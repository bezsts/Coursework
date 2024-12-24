using System.Windows.Input;
using WPF.Common.Enums;

namespace WPF.ViewModels
{
    public class CreateScenarioViewModel : ViewModelBase
    {
        private string _name;

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

        private int _maxRate;

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

        private int _interval;

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

        private int _duration;

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

        private Tests _selectedTest;

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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateScenarioViewModel()
        {
            TestTypes = Enum.GetValues(typeof(Tests)).Cast<Tests>().ToList();
        }
    }
}
