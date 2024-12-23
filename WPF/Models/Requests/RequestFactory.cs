using System.Net.Http;
using System.Text;
using NBomber.Http.CSharp;

namespace WPF.Models.Requests
{
    public static class RequestFactory
    {
        public static Func<HttpRequestMessage> CreateFactory(RequestParametres requestParametres)
        {
            return () =>
            {
                var request = Http.CreateRequest(requestParametres.Method, requestParametres.Url)
                                  .WithHeader("Content-Type", requestParametres.ContentType);

                if (!string.IsNullOrEmpty(requestParametres.Body))
                {
                    request.Content = new StringContent(requestParametres.Body, Encoding.UTF8, requestParametres.ContentType);
                }

                return request;
            };
        }
    }
}
