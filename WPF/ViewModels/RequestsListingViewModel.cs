using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WPF.ViewModels
{
    public class RequestsListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RequestParametresViewModel> _requestParametres;

        public IEnumerable<RequestParametresViewModel> RequestParametres => _requestParametres;
        public ICommand CreateRequestCommand { get; }

        public RequestsListingViewModel()
        {
            _requestParametres = new ObservableCollection<RequestParametresViewModel>();

            _requestParametres.Add(new RequestParametresViewModel(new Models.Requests.RequestParametres("Request1", "google.com")));
            _requestParametres.Add(new RequestParametresViewModel(new Models.Requests.RequestParametres("Request2", "instagram.com")));

        }
    }
}
