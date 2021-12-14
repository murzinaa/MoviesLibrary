using MoviesLibrary.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviesLibrary.APIProviders
{
    public class MovieProvider : IApiMovieProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        public MovieProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<FullMovieResult> GetMoviesListById(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<FullMovieResult>(content);
            return model;
        }

        public async Task<MovieResult> GetMovieList(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<MovieResult>(content);

            return model;
        }

        public async Task<TrendingMoviesResult> GetTrendingMovies(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var model = JsonSerializer.Deserialize<TrendingMoviesResult>(content);
            return model;
        }
    }
}
