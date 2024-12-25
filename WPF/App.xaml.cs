using System.Windows;
using WPF.Models;
using WPF.ViewModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ScenarioManager _scenarioManager;

        public App()
        {
            _scenarioManager = new ScenarioManager();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _scenarioManager.AddRequestParametres(new Models.Requests.RequestParametres("Request 1", "google.com"));
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_scenarioManager)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }

}
