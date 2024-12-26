using System.Windows;
using WPF.Models;
using WPF.Models.Scenarious;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class RunScenariousCommand : CommandBase
    {
        private readonly ScenariousListingViewModel _scenariousListingViewModel;
        private readonly ScenarioManager _scenarioManager;

        public RunScenariousCommand(ScenariousListingViewModel scenariousListingViewModel, 
            ScenarioManager scenarioManager)
        {
            _scenariousListingViewModel = scenariousListingViewModel;
            _scenarioManager = scenarioManager;
        }
        public override void Execute(object? parameter)
        {
            var scenario = _scenariousListingViewModel?.SelectedScenario?.Scenario;
            try
            {
                _scenarioManager.RunScenarious(scenario);
            }
            catch (Exception)
            {
                MessageBox.Show("You haven't selected any scenario.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
