using NBomber.Contracts;
using NBomber.CSharp;
using WPF.Common;
using WPF.Models.Scenarious;

namespace WPF.Models
{
    class ScenarioManager
    {
        private readonly List<BaseScenario> _scenarious;

        public ScenarioManager()
        {
            _scenarious = new List<BaseScenario>();
        }

        public IEnumerable<BaseScenario> GetScenarios()
        { 
            return _scenarious;
        }

        public BaseScenario AddScenario(BaseScenario scenario)
        {
            _scenarious.Add(scenario);
            return scenario;
        }

        public void RunScenarious(IEnumerable<BaseScenario> scenarious)
        {
            var scenarioProps = new List<ScenarioProps>();

            foreach (var scenario in scenarious)
            {
                if (scenario.IsRequestParametresExist())
                {
                    scenarioProps.Add(scenario.Create());
                }
                else
                {
                    throw new ScenarioMissingRequestParametersException(scenario);
                }
            }

            NBomberRunner.RegisterScenarios(scenarioProps.ToArray()).Run();
        }
    }
}
