using System.Windows;
using WPF.Common.Enums;
using WPF.Common.Exceptions;
using WPF.Models;
using WPF.Models.Requests;
using WPF.Services;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class CreateRequestCommand : CommandBase
    {
        private readonly CreateRequestViewModel _createRequestViewModel;
        private readonly ScenarioManager _scenarioManager;
        private readonly NavigationService _navigationService;

        public CreateRequestCommand(CreateRequestViewModel createRequestViewModel, ScenarioManager scenarioManager,
            NavigationService navigationService)
        {
            _createRequestViewModel = createRequestViewModel;
            _scenarioManager = scenarioManager;
            _navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            RequestParametres requestParametres = new RequestParametres(
                _createRequestViewModel.Name,
                _createRequestViewModel.Url,
                Enum.GetName(typeof(Methods), _createRequestViewModel.SelectedMethod) ?? "GET",
                _createRequestViewModel.ContentType ?? "\"application/json\"",
                _createRequestViewModel.Body ?? string.Empty
                );

            try
            {
                _scenarioManager.AddRequestParametres(requestParametres);
                _navigationService.Navigate();
            }
            catch (UrlMissingException)
            {
                MessageBox.Show("Url is empty", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
