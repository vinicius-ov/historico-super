using System.List
using System.Threading.Tasks;

namespace Todoer.Service
{
    internal class HttpClient
    {
        public HttpClient()
        {
        }

        private async Task<string> GetAsync(string apiRoute)
        {
            var url = "http"
 
            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);
 
            ClearReponseHeaders();
            AddReponseHeaders();
 
            var response = await _restClient.GetAsync(_restClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;
 
            return data;
        }

    }
}