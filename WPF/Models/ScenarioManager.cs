using NBomber.CSharp;
using WPF.Common.Exceptions;
using WPF.Models.Requests;
using WPF.Models.Scenarious;
using WPF.Models.Sinks;
using WPF.Services.Creators;
using WPF.Services.Providers;
using WPF.Services.Removers;

namespace WPF.Models
{
    public class ScenarioManager
    {
        private readonly IScenarioProvider _scenarioProvider;
        private readonly IScenarioCreator _scenarioCreator;
        private readonly IScenarioRemover _scenarioRemover;
        private readonly IRequestProvider _requestProvider;
        private readonly IRequestCreator _requestCreator;
        private readonly IRequestRemover _requestRemover;

        public ScenarioManager(IScenarioProvider scenarioProvider, IScenarioCreator scenarioCreator,
                               IRequestProvider requestProvider, IRequestCreator requestCreator,
                               IScenarioRemover scenarioRemover, IRequestRemover requestRemover)
        {
            _scenarioProvider = scenarioProvider;
            _scenarioCreator = scenarioCreator;
            _requestProvider = requestProvider;
            _requestCreator = requestCreator;
            _scenarioRemover = scenarioRemover;
            _requestRemover = requestRemover;
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
        public async Task<BaseScenario> DeleteScenario(BaseScenario scenario)
        {
            await _scenarioRemover.DeleteScenario(scenario);
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

        public async Task<RequestParametres> DeleteRequest(RequestParametres requestParametres)
        {
            await _requestRemover.DeleteRequest(requestParametres);
            return requestParametres;
        }

        public void RunScenarious(BaseScenario? scenario)
        {
            if (scenario is null)
            {
                throw new NullReferenceException();
            }

            if (scenario.IsRequestParametresExist())
            {
                Task.Run(() =>
                {
                    var scenarioProps = scenario.Create();

                    NBomberRunner
                        .RegisterScenarios(scenarioProps)
                        .WithReportingSinks(new WpfSink())
                        .Run();
                });
            }
            else
            {
                throw new ScenarioMissingRequestParametersException(scenario);
            }
        }
    }
}
