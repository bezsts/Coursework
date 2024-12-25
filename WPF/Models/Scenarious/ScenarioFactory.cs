using WPF.Common.Enums;
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
    }
}
