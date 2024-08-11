using System;
using WebAppServer.Models;

namespace WebAppServer.Services
{
    /// <summary>
    /// Represents a service for retrieving data from the Transport for London (TFL) API.
    /// </summary>
    public interface ITflService
    {
        /// <summary>
        /// Retrieves a list of accident statistics details from the TFL API.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="AccidentStatsDetail"/>.</returns>
        Task<List<AccidentStatsDetail>> GetAccidentData();

        /// <summary>
        /// Retrieves a list of bike points from the TFL API.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Place"/>.</returns>
        Task<List<Place>> GetBikePoint();
    }

    /// <summary>
    /// Represents a service for retrieving data from the Transport for London (TFL) API.
    /// </summary>
    public class TflService : ITflService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private string _apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="TflService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration object used to retrieve the TFL API key.</param>
        /// <param name="httpClient">The HTTP client used to make API requests.</param>
        public TflService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _apiKey = _configuration["ApiKeys:Tfl"];
            _httpClient = httpClient;
        }

        /// <inheritdoc/>
        public async Task<List<AccidentStatsDetail>> GetAccidentData()
        {
            // Make API request using the HttpClient
            _httpClient.DefaultRequestHeaders.Add("app_key", _apiKey);
            HttpResponseMessage response = await _httpClient.GetAsync("https://api.tfl.gov.uk/AccidentStats/2016");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<AccidentStatsDetail>>();
            }
            else
            {
                throw new Exception("Failed to retrieve data from API.");
            }
        }

        /// <inheritdoc/>
        public async Task<List<Place>> GetBikePoint()
        {
            // Make API request using the HttpClient
            _httpClient.DefaultRequestHeaders.Add("app_key", _apiKey);
            HttpResponseMessage response = await _httpClient.GetAsync("https://api.tfl.gov.uk/BikePoint");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Place>>();
            }
            else
            {
                throw new Exception("Failed to retrieve data from API.");
            }
        }
    }
}
