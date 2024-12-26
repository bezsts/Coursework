using WPF.Models.Requests;

namespace WPF.Services.Removers
{
    public interface IRequestRemover
    {
        Task DeleteRequest(RequestParametres requestParametres);
    }
}
