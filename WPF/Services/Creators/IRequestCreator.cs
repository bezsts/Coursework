using WPF.Models.Requests;

namespace WPF.Services.Creators
{
    public interface IRequestCreator
    {
        Task CreateRequest(RequestParametres requestParametres);
    }
}
