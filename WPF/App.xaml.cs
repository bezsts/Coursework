using System.Windows;
using WPF.Models;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ScenarioManager _scenarioManager;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _scenarioManager = new ScenarioManager();
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateScenarioListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private ViewModelBase CreateScenarioViewModel()
        { 
            return new CreateScenarioViewModel(_scenarioManager, 
                new NavigationService(_navigationStore, CreateScenarioListingViewModel));
        }

        private ViewModelBase CreateScenarioListingViewModel()
        {
            return new ScenariousListingViewModel(_scenarioManager, 
                new NavigationService(_navigationStore, CreateScenarioViewModel),
                new NavigationService(_navigationStore, CreateRequestListingViewModel));
        }

        private ViewModelBase CreateRequestViewModel()
        { 
            return new CreateRequestViewModel(_scenarioManager,
                new NavigationService(_navigationStore, CreateRequestListingViewModel));

        }

        private ViewModelBase CreateRequestListingViewModel()
        {
            return new RequestsListingViewModel(_scenarioManager,
                new NavigationService(_navigationStore, CreateRequestViewModel),
                new NavigationService(_navigationStore, CreateScenarioListingViewModel));
        }
    }

}
