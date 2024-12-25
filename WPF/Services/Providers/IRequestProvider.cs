using WPF.Models.Requests;

namespace WPF.Services.Providers
{
    public interface IRequestProvider
    {
        Task<IEnumerable<RequestParametres>> GetAllRequests();
        Task<RequestParametres?> GetRequestParametresById(int id);
    }
}
