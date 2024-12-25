using NBomber.Contracts;
using NBomber.CSharp;
using WPF.Common.Exceptions;
using WPF.Models.Requests;
using WPF.Models.Scenarious;
using WPF.Services.Creators;
using WPF.Services.Providers;

namespace WPF.Models
{
    public class ScenarioManager
    {
        private readonly IScenarioProvider _scenarioProvider;
        private readonly IScenarioCreator _scenarioCreator;
        private readonly IRequestProvider _requestProvider;
        private readonly IRequestCreator _requestCreator;

        public ScenarioManager(IScenarioProvider scenarioProvider, IScenarioCreator scenarioCreator, 
                               IRequestProvider requestProvider, IRequestCreator requestCreator)
        {
            _scenarioProvider = scenarioProvider;
            _scenarioCreator = scenarioCreator;
            _requestProvider = requestProvider;
            _requestCreator = requestCreator;
        }

        public async Task<IEnumerable<BaseScenario>> GetScenarios()
        {
            return await _scenarioProvider.GetAllScenarious();
        }

        public async Task<IEnumerable<RequestParametres>> GetRequestParametres()
        {
            return await _requestProvider.GetAllRequests();
        }

        public async Task<BaseScenario> AddScenario(BaseScenario scenario)
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
            await _scenarioCreator.CreateScenario(scenario);
            return scenario;
        }

        public async Task<RequestParametres> AddRequestParametres(RequestParametres requestParametres)
        {
            if (string.IsNullOrEmpty(requestParametres.Url))
            {
                throw new UrlMissingException();
            }

            await _requestCreator.CreateRequest(requestParametres);
            return requestParametres;
        }

        public async Task AddRequestParametresToScenarioAsync(int requestParametresId, BaseScenario scenario)
        {
            RequestParametres? requestParametres = await _requestProvider.GetRequestParametresById(requestParametresId);
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
