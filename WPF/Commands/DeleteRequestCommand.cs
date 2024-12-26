
using System.Windows;
using WPF.Models;
using WPF.ViewModels;

namespace WPF.Commands
{
    public class DeleteRequestCommand : AsyncCommandBase
    {
        private readonly RequestsListingViewModel _requestsListingViewModel;
        private readonly ScenarioManager _scenarioManager;

        public DeleteRequestCommand(RequestsListingViewModel requestsListingViewModel,
                                    ScenarioManager scenarioManager)
        {
            _requestsListingViewModel = requestsListingViewModel;
            _scenarioManager = scenarioManager;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _scenarioManager.DeleteRequest(_requestsListingViewModel.SelectedRequest.RequestParametres);
                var requests = await _scenarioManager.GetRequestParametres();
                _requestsListingViewModel.UpdateRequests(requests);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to delete request", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
