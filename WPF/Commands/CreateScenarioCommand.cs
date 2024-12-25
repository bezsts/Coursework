using System.Windows;
using WPF.Common.Exceptions;
using WPF.Models;
using WPF.Models.Scenarious;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class CreateScenarioCommand : CommandBase
    {
        private readonly ScenarioManager _scenarioManager;
        private readonly CreateScenarioViewModel _createScenarioViewModel;

        public CreateScenarioCommand(ScenarioManager scenarioManager, CreateScenarioViewModel createScenarioViewModel)
        {
            _scenarioManager = scenarioManager;
            _createScenarioViewModel = createScenarioViewModel;

        }
        public override void Execute(object? parameter)
        {
            try
            {
                BaseScenario scenario = ScenarioFactory.CreateScenario(_createScenarioViewModel.SelectedTest, _createScenarioViewModel);
                _scenarioManager.AddRequestParametresToScenario(_createScenarioViewModel.SelectedRequest, scenario);
                _scenarioManager.AddScenario(scenario);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ScenarioMissingRequestParametersException)
            {
                MessageBox.Show("Request parametres are missing", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ScenarioMissingProperty)
            {
                MessageBox.Show("Scenario is missing some property", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
