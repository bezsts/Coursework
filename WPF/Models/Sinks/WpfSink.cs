using Microsoft.Extensions.Configuration;
using NBomber.Contracts;
using NBomber.Contracts.Stats;
using OxyPlot;
using System.Windows;
using WPF.ViewModels;
using WPF.Windows;

namespace WPF.Models.Sinks
{
    public class WpfSink : IReportingSink
    {
        public string SinkName => nameof(WpfSink);

        private readonly StatisticViewModel _statisticsViewModel;
        private Window _window;

        public WpfSink()
        {
            _statisticsViewModel = new StatisticViewModel();
        }

        public void Dispose()
        {
        }

        public Task Init(IBaseContext context, IConfiguration infraConfig)
        {
            return Task.CompletedTask;
        }

        public Task SaveFinalStats(NodeStats stats)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _statisticsViewModel.ScenarioName = stats.ScenarioStats.FirstOrDefault()?.ScenarioName ?? "N/A";
                _statisticsViewModel.RequestCount += stats.AllRequestCount;
                _statisticsViewModel.SuccessCount += stats.AllOkCount;
                _statisticsViewModel.ErrorsCount += stats.AllFailCount;
                _statisticsViewModel.Duration = stats.Duration;
            });
            return Task.CompletedTask;
        }

        public Task SaveRealtimeStats(ScenarioStats[] stats)
        {
            foreach (var stat in stats)
            {
                _statisticsViewModel.ScenarioName = stat.ScenarioName;
                _statisticsViewModel.RequestCount += stat.AllRequestCount;
                _statisticsViewModel.SuccessCount += stat.AllOkCount;
                _statisticsViewModel.ErrorsCount += stat.AllFailCount;
                _statisticsViewModel.Duration = stat.Duration;
                _statisticsViewModel.AddDataPoint(stat.Duration, stat.LoadSimulationStats.Value);
            }
            
            return Task.CompletedTask;
        }

        public Task Start(SessionStartInfo sessionInfo)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _window = new StatisticWindow { DataContext = _statisticsViewModel };
                _window.Show();
            });
            return Task.CompletedTask;
        }

        public Task Stop()
        {
            Dispose();
            return Task.CompletedTask;
        }
    }
}
