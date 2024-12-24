using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Models.Scenarious;

namespace WPF.ViewModels
{
    public class ScenariousListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ScenariousViewModel> _scenarious;
        public IEnumerable<ScenariousViewModel> Scenarious => _scenarious;
        public ICommand CreateScenarioCommand { get; }

        public ScenariousListingViewModel()
        {
            _scenarious = new ObservableCollection<ScenariousViewModel>();

            _scenarious.Add(new ScenariousViewModel(new LoadTestScenario("Load scenario", 1000, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1))));
            _scenarious.Add(new ScenariousViewModel(new SoakTestScenario("Soak scenario", 1000, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1),
                            new Models.Requests.RequestParametres("Request1", "google.com"))));

        }
    }
}
