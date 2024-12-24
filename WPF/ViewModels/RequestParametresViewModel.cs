using WPF.Models.Requests;

namespace WPF.ViewModels
{
    public class RequestParametresViewModel : ViewModelBase
    {
        private readonly RequestParametres _requestParametres;
        public int Id => _requestParametres.Id;
        public string Name => _requestParametres.Name;
        public string Method => _requestParametres.Method;
        public string Url => _requestParametres.Url;

        public string ContentType => _requestParametres.ContentType;
        public string Body => _requestParametres.Body;

        public RequestParametresViewModel(RequestParametres requestParametres)
        {
            _requestParametres = requestParametres;
        }
    }
}
