using WPF.Models.Scenarious;

namespace WPF.ViewModels
{
    public class ScenariousViewModel
    {
        private readonly BaseScenario _scenario;

        public int Id => _scenario.Id;
        public string Name => _scenario.Name;
        public string TestType => _scenario.TestType;
        public int MaxRate => _scenario.MaxRate;
        public TimeSpan Interval => _scenario.Interval;
        public TimeSpan Duration => _scenario.Duration;
        public string? RequestParametresName => _scenario.RequestParametres?.Name;
        public ScenariousViewModel(BaseScenario scenario)
        {
            _scenario = scenario;
        }
    }
}