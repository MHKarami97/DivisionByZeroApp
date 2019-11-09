using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using ServerConnect.Middleware;
using ServerConnect.Responses;

namespace ServerConnect.Services
{
    public class CatsService
    {
        private readonly HttpClient _httpClient;
        private readonly ITheCatsAPI _theCatsApi;

        public CatsService(Uri baseUrl)
        {
            _httpClient = new HttpClient(new HttpClientDiagnosticsHandler(new HttpClientHandler())) { BaseAddress = baseUrl };
            _theCatsApi = RestService.For<ITheCatsAPI>(_httpClient);
        }

        public async Task<IEnumerable<SearchResult>> Search(string breed)
        {
            return await _theCatsApi.Search(breed).ConfigureAwait(false);
        }
    }
}
