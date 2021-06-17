using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Constants = Challenges.Application.Utils.Constants;

namespace Challenges.Application.HttpClientWrapper
{
    public class ChallengesChallengesHttpClientWrapper : IChallengesHttpClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger _logger;
        private const string BaseUrl = "http://dev-companyA-recruitment.azurewebsites.net/";

        public ChallengesChallengesHttpClientWrapper(IHttpClientFactory clientFactory, ILogger<ChallengesChallengesHttpClientWrapper> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await GetHttpClient().GetAsync($"{BaseUrl}{uri}?token={Constants.Token}");
            var responseContent = response.Content != null ? response.Content.ReadAsStringAsync().Result : string.Empty;

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation(response.ReasonPhrase, responseContent, response.StatusCode);
            }
            else
            {
                HandleRemoteErrorResponse(response);
            }

            var responseBody = JsonConvert.DeserializeObject<T>(responseContent);
            return responseBody;
        }

        public async Task<TResponse> PostJsonAsync<TRequest, TResponse>(string uri, TRequest data)
        {
            var json = JsonConvert.SerializeObject(data);
            var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

            var completeUrl = $"{BaseUrl}{uri}?token={Constants.Token}";
            var response = await GetHttpClient().PostAsync(completeUrl, requestContent);

            var responseContent = response.Content != null ? response.Content.ReadAsStringAsync().Result : string.Empty;

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation(response.ReasonPhrase, responseContent, response.StatusCode);
            }
            else
            {
                HandleRemoteErrorResponse(response);
            }

            var responseBody = JsonConvert.DeserializeObject<TResponse>(responseContent);
            return responseBody;
        }

        private void HandleRemoteErrorResponse(HttpResponseMessage response)
        {

            var exceptionMessage = string.Join(
                $"Remote Challenges http call returned with status code ({(int)response.StatusCode}).",
                response.Content);
            _logger.LogError(exceptionMessage, response.Content, response.StatusCode);
            throw new ChallengesRemoteServiceException(exceptionMessage);
        }

        private HttpClient GetHttpClient() => _clientFactory.CreateClient();
    }
}
