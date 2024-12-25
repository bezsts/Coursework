
using System.Windows;
using WPF.Models;
using WPF.Models.Requests;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class LoadRequestsCommand : AsyncCommandBase
    {
        private readonly ScenarioManager _scenarioManager;
        private readonly RequestsListingViewModel _requestsListingViewModel;

        public LoadRequestsCommand(ScenarioManager scenarioManager, RequestsListingViewModel requestsListingViewModel)
        {
            _scenarioManager = scenarioManager;
            _requestsListingViewModel = requestsListingViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<RequestParametres> requestParametres = await _scenarioManager.GetRequestParametres();

                _requestsListingViewModel.UpdateRequests(requestParametres);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load requests", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
