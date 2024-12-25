using NBomber.Contracts;
using NBomber.CSharp;
using WPF.Common.Exceptions;
using WPF.Models.Requests;
using WPF.Models.Scenarious;

namespace WPF.Models
{
    public class ScenarioManager
    {
        private readonly List<BaseScenario> _scenarious;
        private readonly List<RequestParametres> _requestParametres;

        public ScenarioManager()
        {
            _scenarious = new List<BaseScenario>();
            _requestParametres = new List<RequestParametres>();
        }

        public IEnumerable<BaseScenario> GetScenarios()
        {
            return _scenarious;
        }

        public IEnumerable<RequestParametres> GetRequestParametres()
        {
            return _requestParametres;
        }

        public BaseScenario AddScenario(BaseScenario scenario)
        {
            if (!scenario.IsRequestParametresExist())
            {
                throw new ScenarioMissingRequestParametersException(scenario);
            }
            if (string.IsNullOrEmpty(scenario.Name) || scenario.MaxRate == 0 || scenario.Interval == TimeSpan.Zero
                || scenario.Duration == TimeSpan.Zero)
            {
                throw new ScenarioMissingProperty();
            }
            _scenarious.Add(scenario);
            return scenario;
        }

        public RequestParametres AddRequestParametres(RequestParametres requestParametres)
        {
            if (string.IsNullOrEmpty(requestParametres.Url))
            {
                throw new UrlMissingException();
            }

            _requestParametres.Add(requestParametres);
            return requestParametres;
        }

        public void AddRequestParametresToScenario(RequestParametres requestParametres, BaseScenario scenario)
        {
            scenario.RequestParametres = requestParametres;
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
