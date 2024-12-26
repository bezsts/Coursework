using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http.CSharp;
using WPF.Common.Enums;
using WPF.DTOs;
using WPF.Models.Requests;

namespace WPF.Models.Scenarious
{
    class SpikeTestScenario : BaseScenario
    {
        public override Tests TestType { get { return Tests.Spike; } }

        public SpikeTestScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration)
            : base(name, max_rate, interval, duration) { }

        public SpikeTestScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration, RequestParametres requestParametres)
            : base(name, max_rate, interval, duration, requestParametres) { }

        public SpikeTestScenario(ScenarioDTO scenarioDTO, RequestParametres requestParametres)
            : base(scenarioDTO, requestParametres) { }
        public override ScenarioProps Create()
        {
            return Scenario.Create("spike_test_scenario", async context =>
            {
                var request = CreateRequest();
                var response = await Http.Send(_httpClient, request);
                return response;
            })
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.RampingInject(rate: (int)(MaxRate * 0.05),
                                         interval: Interval,
                                         during: Duration * 0.02),

                Simulation.Inject(rate: (int)(MaxRate * 0.05),
                                  interval: Interval,
                                  during: Duration * 0.12),

                Simulation.RampingInject(rate: (int)(MaxRate * 0.95),
                                         interval: Interval,
                                         during: Duration * 0.02),

                Simulation.Inject(rate: (int)(MaxRate * 0.95),
                                  interval: Interval,
                                  during: Duration * 0.4),

                Simulation.RampingInject(rate: (int)(MaxRate * 0.05),
                                         interval: Interval,
                                         during: Duration * 0.02),

                Simulation.Inject(rate: (int)(MaxRate * 0.05),
                                  interval: Interval,
                                  during: Duration * 0.4),

                Simulation.RampingInject(rate: 0,
                                         interval: Interval,
                                         during: Duration * 0.02)
            );
        }
    }
}
