using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Commands;
using WPF.Models;
using WPF.Models.Requests;
using WPF.Models.Scenarious;
using WPF.Services;

namespace WPF.ViewModels
{
    public class ScenariousListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ScenariousViewModel> _scenarious;
        private readonly ScenarioManager _scenarioManager;

        public IEnumerable<ScenariousViewModel> Scenarious => _scenarious;
        public ICommand CreateScenarioCommand { get; }
        public ICommand LoadScenariousCommand { get; }
        public ICommand NavigateToRequests {  get; }

        public ScenariousListingViewModel(ScenarioManager scenarioManager, 
            NavigationService navigationCreateScenarioService, NavigationService navigationRequestService)
        {
            _scenarioManager = scenarioManager;
            _scenarious = new ObservableCollection<ScenariousViewModel>();

            CreateScenarioCommand = new NavigateCommand(navigationCreateScenarioService);
            LoadScenariousCommand = new LoadScenariousCommand(scenarioManager, this);
            NavigateToRequests = new NavigateCommand(navigationRequestService);
        }

        public static ScenariousListingViewModel LoadViewModel(ScenarioManager scenarioManager,
            NavigationService navigationCreateRequestService,
            NavigationService navigationScenariousService)
        {
            ScenariousListingViewModel viewModel = new ScenariousListingViewModel(scenarioManager, navigationCreateRequestService, navigationScenariousService);

            viewModel.LoadScenariousCommand.Execute(null);

            return viewModel;
        }

        public void UpdateScenarious(IEnumerable<BaseScenario> scenarious)
        {
            _scenarious.Clear();

            foreach (var scenario in scenarious)
            {
                ScenariousViewModel scenariousViewModel = new ScenariousViewModel(scenario);

                _scenarious.Add(scenariousViewModel);
            }
        }
    }
}
