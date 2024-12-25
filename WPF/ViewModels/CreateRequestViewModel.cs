using System.Windows.Input;
using WPF.Commands;
using WPF.Common.Enums;
using WPF.Models;
using WPF.Services;
using WPF.Stores;

namespace WPF.ViewModels
{
    public class CreateRequestViewModel : ViewModelBase
    {
        private string _name = "Request";
        private Methods _selectedMethod = Methods.GET;
        private string _url;
        private string _contentType = "application/json";
        private string _body = string.Empty;

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

        public List<Methods> MethodTypes { get; set; }

        public Methods SelectedMethod
        {
            get 
            { 
                return _selectedMethod; 
            }
            set 
            { 
                _selectedMethod = value;
                OnPropertyChanged(nameof(SelectedMethod));
            }
        }

        public string Url
        {
            get 
            { 
                return _url; 
            }
            set 
            { 
                _url = value;
                OnPropertyChanged(nameof(Url));
            }
        }

        public string ContentType
        {
            get 
            { 
                return _contentType; 
            }
            set 
            { 
                _contentType = value; 
                OnPropertyChanged(nameof(ContentType));
            }
        }

        public string Body
        {
            get 
            { 
                return _body;
            }
            set 
            { 
                _body = value;
                OnPropertyChanged(nameof(Body));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CreateRequestViewModel(ScenarioManager scenarioManager, NavigationService navigationService)
        {
            MethodTypes = Enum.GetValues(typeof(Methods)).Cast<Methods>().ToList();
            SubmitCommand = new CreateRequestCommand(this, scenarioManager, navigationService);
            CancelCommand = new NavigateCommand(navigationService);
        }
    }
}
