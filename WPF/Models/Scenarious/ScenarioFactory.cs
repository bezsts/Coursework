using WPF.Common.Enums;
using WPF.DTOs;
using WPF.Models.Requests;
using WPF.ViewModels;

namespace WPF.Models.Scenarious
{
    public static class ScenarioFactory
    {
        public static BaseScenario CreateScenario(Tests type, CreateScenarioViewModel createScenarioViewModel)
        {
            return type switch
            {
                Tests.Load => new LoadTestScenario(
                    createScenarioViewModel.Name,
                    createScenarioViewModel.MaxRate,
                    TimeSpan.FromSeconds(createScenarioViewModel.Interval),
                    TimeSpan.FromSeconds(createScenarioViewModel.Duration)),
                Tests.Soak => new SoakTestScenario(
                    createScenarioViewModel.Name,
                    createScenarioViewModel.MaxRate,
                    TimeSpan.FromSeconds(createScenarioViewModel.Interval),
                    TimeSpan.FromSeconds(createScenarioViewModel.Duration)),
                Tests.Spike => new SpikeTestScenario(
                    createScenarioViewModel.Name,
                    createScenarioViewModel.MaxRate,
                    TimeSpan.FromSeconds(createScenarioViewModel.Interval),
                    TimeSpan.FromSeconds(createScenarioViewModel.Duration)),
                Tests.Stress => new StressTestScenario(
                    createScenarioViewModel.Name,
                    createScenarioViewModel.MaxRate,
                    TimeSpan.FromSeconds(createScenarioViewModel.Interval),
                    TimeSpan.FromSeconds(createScenarioViewModel.Duration)),
                _ => throw new ArgumentException($"Unknown test type: {type}")
            };            
        }

        public static BaseScenario CreateScenarioFromDatabase(Tests type, ScenarioDTO scenarioDTO)
        {
            return type switch
            {
                Tests.Load => new LoadTestScenario(
                    scenarioDTO.Name,
                    scenarioDTO.MaxRate,
                    scenarioDTO.Interval,
                    scenarioDTO.Duration,
                    ToRequest(scenarioDTO.RequestParametres)),
                Tests.Soak => new SoakTestScenario(
                    scenarioDTO.Name,
                    scenarioDTO.MaxRate,
                    scenarioDTO.Interval,
                    scenarioDTO.Duration,
                    ToRequest(scenarioDTO.RequestParametres)),
                Tests.Spike => new SpikeTestScenario(
                    scenarioDTO.Name,
                    scenarioDTO.MaxRate,
                    scenarioDTO.Interval,
                    scenarioDTO.Duration,
                    ToRequest(scenarioDTO.RequestParametres)),
                Tests.Stress => new StressTestScenario(
                    scenarioDTO.Name,
                    scenarioDTO.MaxRate,
                    scenarioDTO.Interval,
                    scenarioDTO.Duration,
                    ToRequest(scenarioDTO.RequestParametres)),
                _ => throw new ArgumentException($"Unknown test type: {type}")
            };
        }

        private static RequestParametres ToRequest(RequestParametresDTO requestParametresDTO)
        {
            RequestParametres requestParametres = 
                new RequestParametres(requestParametresDTO.Name, requestParametresDTO.Url, 
                requestParametresDTO.Method, requestParametresDTO.ContentType, requestParametresDTO.Body);
            requestParametres.Id = requestParametresDTO.Id;
            return requestParametres;
        }
    }
}
