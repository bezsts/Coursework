using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Commands;
using WPF.Models;
using WPF.Services;

namespace WPF.ViewModels
{
    public class RequestsListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RequestParametresViewModel> _requestParametres;
        private readonly ScenarioManager _scenarioManager;

        public IEnumerable<RequestParametresViewModel> RequestParametres => _requestParametres;
        public ICommand CreateRequestCommand { get; }
        public ICommand NavigateToScenarious {  get; }

        public RequestsListingViewModel(ScenarioManager scenarioManager, 
            NavigationService navigationCreateRequestService,
            NavigationService navigationScenariousService)
        {
            _requestParametres = new ObservableCollection<RequestParametresViewModel>();
            _scenarioManager = scenarioManager;

            CreateRequestCommand = new NavigateCommand(navigationCreateRequestService);
            NavigateToScenarious = new NavigateCommand(navigationScenariousService);

            UpdateRequests();
        }

        private void UpdateRequests()
        {
            _requestParametres.Clear();

            foreach (var request in _scenarioManager.GetRequestParametres())
            {
                RequestParametresViewModel requestParametresViewModel = new RequestParametresViewModel(request);

                _requestParametres.Add(requestParametresViewModel);
            }
        }
    }
}
