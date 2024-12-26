using System.Windows;
using WPF.Models;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class DeleteScenarioCommand : AsyncCommandBase
    {
        private readonly ScenariousListingViewModel _scenariousListingViewModel;
        private readonly ScenarioManager _scenarioManager;

        public DeleteScenarioCommand(ScenariousListingViewModel scenariousListingViewModel,
                                     ScenarioManager scenarioManager)
        {
            _scenariousListingViewModel = scenariousListingViewModel;
            _scenarioManager = scenarioManager;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _scenarioManager.DeleteScenario(_scenariousListingViewModel.SelectedScenario.Scenario);
                var scenarious = await _scenarioManager.GetScenarios();
                _scenariousListingViewModel.UpdateScenarious(scenarious);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to delete scenario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
