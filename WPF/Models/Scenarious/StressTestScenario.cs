using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Http.CSharp;

namespace WPF.Models.Scenarious
{
    class StressTestScenario : BaseScenario
    {
        public StressTestScenario(string name, int max_rate, TimeSpan interval, TimeSpan duration)
            : base(name, max_rate, interval, duration) { }
        public override ScenarioProps Create()
        {
            return Scenario.Create("stress_test_scenario", async context =>
            {
                var request = CreateRequest();
                var response = await Http.Send(_httpClient, request);
                return response;
            })
            .WithWarmUpDuration(TimeSpan.FromSeconds(10))
            .WithLoadSimulations(
                Simulation.RampingInject(rate: (int)(0.25 * MaxRate),
                                         interval: Interval,
                                         during: Duration * 0.05),

                Simulation.Inject(rate: (int)(0.25 * MaxRate),
                                  interval: Interval,
                                  during: Duration * 0.1375),

                Simulation.RampingInject(rate: (int)(0.5 * MaxRate),
                                         interval: Interval,
                                         during: Duration * 0.05),

                Simulation.Inject(rate: (int)(0.5 * MaxRate),
                                  interval: Interval,
                                  during: Duration * 0.1375),

                Simulation.RampingInject(rate: (int)(0.75 * MaxRate),
                                         interval: Interval,
                                         during: Duration * 0.05),

                Simulation.Inject(rate: (int)(0.75 * MaxRate),
                                  interval: Interval,
                                  during: Duration * 0.1375),

                Simulation.RampingInject(rate: MaxRate,
                                         interval: Interval,
                                         during: Duration * 0.05),

                Simulation.Inject(rate: MaxRate,
                                  interval: Interval,
                                  during: Duration * 0.1375),

                Simulation.RampingInject(rate: 0,
                                         interval: Interval,
                                         during: Duration * 0.25)
            );
        }
    }
}
