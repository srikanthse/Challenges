using System.Threading.Tasks;

namespace Challenges.Application.HttpClientWrapper
{
    public interface IChallengesHttpClient
    {
        Task<T> GetAsync<T>(string uri);
        Task<TResponse> PostJsonAsync<TRequest, TResponse>(string uri, TRequest data);
    }
}
