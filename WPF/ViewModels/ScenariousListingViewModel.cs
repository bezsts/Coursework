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
        public ICommand NavigateToRequests {  get; }

        public ScenariousListingViewModel(ScenarioManager scenarioManager, 
            NavigationService navigationCreateScenarioService, NavigationService navigationRequestService)
        {
            _scenarioManager = scenarioManager;
            _scenarious = new ObservableCollection<ScenariousViewModel>();

            CreateScenarioCommand = new NavigateCommand(navigationCreateScenarioService);
            NavigateToRequests = new NavigateCommand(navigationRequestService);
            UpdateScenarious();
        }

        private void UpdateScenarious()
        {
            _scenarious.Clear();

            foreach (var scenario in _scenarioManager.GetScenarios())
            {
                ScenariousViewModel scenariousViewModel = new ScenariousViewModel(scenario);

                _scenarious.Add(scenariousViewModel);
            }
        }
    }
}
