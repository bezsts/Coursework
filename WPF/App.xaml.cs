using Microsoft.EntityFrameworkCore;
using System.Windows;
using WPF.DbContexts;
using WPF.Models;
using WPF.Services;
using WPF.Services.Creators;
using WPF.Services.Providers;
using WPF.Stores;
using WPF.ViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string ConnectionString = "Data Source=database.db";
        private readonly ScenarioManager _scenarioManager;
        private readonly NavigationStore _navigationStore;
        private readonly DataModelContextFactory _dataModelContextFactory;

        public App()
        {
            _dataModelContextFactory = new DataModelContextFactory(ConnectionString);
            IScenarioProvider scenarioProvider = new DatabaseProvider(_dataModelContextFactory);
            IScenarioCreator scenarioCreator = new DatabaseCreator(_dataModelContextFactory);
            IRequestProvider requestProvider = new DatabaseProvider(_dataModelContextFactory);
            IRequestCreator requestCreator = new DatabaseCreator(_dataModelContextFactory);

            _scenarioManager = new ScenarioManager(scenarioProvider, scenarioCreator, requestProvider, requestCreator);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (DataModelContext dbContext = _dataModelContextFactory.CreateDbContext())
            { 
                dbContext.Database.Migrate();
            }


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
            return ScenariousListingViewModel.LoadViewModel(_scenarioManager, 
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
            return RequestsListingViewModel.LoadViewModel(_scenarioManager,
                new NavigationService(_navigationStore, CreateRequestViewModel),
                new NavigationService(_navigationStore, CreateScenarioListingViewModel));
        }
    }

}
