using System.Windows;
using WPF.Common;
using WPF.Models;
using WPF.Models.Requests;
using WPF.Models.Scenarious;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ScenarioManager scenarioManager = new ScenarioManager();

            var loadScenario = scenarioManager.AddScenario(
                new LoadTestScenario("Load test", 1000, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1),
                    new RequestParametres("google parametres", "google.com")));

            var spikeScenario = scenarioManager.AddScenario(
                new SpikeTestScenario("Spike test", 1000, TimeSpan.FromSeconds(1), TimeSpan.FromMinutes(1)));

            IEnumerable<BaseScenario> baseScenarios = scenarioManager.GetScenarios();


            try
            {
                scenarioManager.RunScenarious(baseScenarios);
            }
            catch (ScenarioMissingRequestParametersException ex)
            {
            }

            base.OnStartup(e);
        }
    }

}
