using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Commands;
using WPF.Models;
using WPF.Models.Requests;
using WPF.Services;

namespace WPF.ViewModels
{
    public class RequestsListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RequestParametresViewModel> _requestParametres;

        public IEnumerable<RequestParametresViewModel> RequestParametres => _requestParametres;
        public ICommand CreateRequestCommand { get; }
        public ICommand LoadRequestsCommand { get; }
        public ICommand NavigateToScenarious {  get; }

        public RequestsListingViewModel(ScenarioManager scenarioManager, 
            NavigationService navigationCreateRequestService,
            NavigationService navigationScenariousService)
        {
            _requestParametres = new ObservableCollection<RequestParametresViewModel>();
            CreateRequestCommand = new NavigateCommand(navigationCreateRequestService);
            LoadRequestsCommand = new LoadRequestsCommand(scenarioManager, this);
            NavigateToScenarious = new NavigateCommand(navigationScenariousService);
        }

        public static RequestsListingViewModel LoadViewModel(ScenarioManager scenarioManager,
            NavigationService navigationCreateRequestService,
            NavigationService navigationScenariousService)
        {
            RequestsListingViewModel viewModel = new RequestsListingViewModel(scenarioManager, navigationCreateRequestService, navigationScenariousService);
        
            viewModel.LoadRequestsCommand.Execute(null);

            return viewModel;
        }

        public void UpdateRequests(IEnumerable<RequestParametres> requestParametres)
        {
            _requestParametres.Clear();

            foreach (var request in requestParametres)
            {
                RequestParametresViewModel requestParametresViewModel = new RequestParametresViewModel(request);

                _requestParametres.Add(requestParametresViewModel);
            }
        }
    }
}
