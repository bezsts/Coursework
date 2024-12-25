using WPF.Models;

namespace WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(ScenarioManager scenarioManager)
        {
            CurrentViewModel = new CreateScenarioViewModel(scenarioManager);
        }
    }
}
