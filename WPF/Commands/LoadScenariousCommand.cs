using System.Windows;
using WPF.Models.Requests;
using WPF.Models;
using WPF.ViewModels;
using WPF.Models.Scenarious;

namespace WPF.Commands
{
    public class LoadScenariousCommand : AsyncCommandBase
    {
        private readonly ScenarioManager _scenarioManager;
        private readonly ScenariousListingViewModel _scenariousListingViewModel;

        public LoadScenariousCommand(ScenarioManager scenarioManager, ScenariousListingViewModel scenariousListingViewModel)
        {
            _scenarioManager = scenarioManager;
            _scenariousListingViewModel = scenariousListingViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<BaseScenario> scenarious = await _scenarioManager.GetScenarios();

                _scenariousListingViewModel.UpdateScenarious(scenarious);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load scenarious", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
