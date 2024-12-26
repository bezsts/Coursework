using OxyPlot;
using OxyPlot.Series;

namespace WPF.ViewModels
{
    public class StatisticViewModel : ViewModelBase
    {
        private string _scenarioName;
        private int _requestCount;
        private int _successCount;
        private int _errorsCount;
        private string _successRate;
        private TimeSpan _duration;

        public string ScenarioName
        {
            get { return _scenarioName; }
            set
            {
                _scenarioName = value;
                OnPropertyChanged(nameof(ScenarioName));
            }
        }

        public int RequestCount
        {
            get { return _requestCount; }
            set
            {
                _requestCount = value;
                OnPropertyChanged(nameof(RequestCount));
            }
        }

        public int SuccessCount
        {
            get { return _successCount; }
            set 
            { 
                _successCount = value;
                SuccessRate = $"{((double)SuccessCount / RequestCount) * 100}%";
                OnPropertyChanged(nameof(SuccessCount));
            }
        }


        public int ErrorsCount
        {
            get { return _errorsCount; }
            set
            {
                _errorsCount = value;
                OnPropertyChanged(nameof(ErrorsCount));
            }
        }

        public string SuccessRate
        {
            get { return _successRate; }
            set
            {
                { _successRate = value; }
                OnPropertyChanged(nameof(SuccessRate));
            }
        }

        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        private LineSeries _lineSeries;
        private PlotModel _requestsPerSecondModel;

        public PlotModel RequestsPerSecondModel
        {
            get { return _requestsPerSecondModel; }
            set 
            { 
                _requestsPerSecondModel = value;
                OnPropertyChanged(nameof(RequestsPerSecondModel));
            }
        }


        public StatisticViewModel()
        {
            RequestsPerSecondModel = new PlotModel { Title = "Requests per second"};
            _lineSeries = new LineSeries
            {
                Title = "RPS",
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Red,
            };
            RequestsPerSecondModel.Series.Add(_lineSeries);
        }

        public void AddDataPoint(TimeSpan duration, int allRequestCount)
        {
            _lineSeries.Points.Add(new DataPoint(duration.TotalSeconds, allRequestCount));
            RequestsPerSecondModel.InvalidatePlot(true);
        }
    }
}
