using System.Windows.Input;
using WPF.Common.Enums;

namespace WPF.ViewModels
{
    public class CreateRequestViewModel : ViewModelBase
    {
        private string _name;
        private Methods _selectedMethod;
        private string _url;
        private string _contentType;
        private string _body;

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

        public CreateRequestViewModel()
        {
            MethodTypes = Enum.GetValues(typeof(Methods)).Cast<Methods>().ToList();
        }
    }
}
