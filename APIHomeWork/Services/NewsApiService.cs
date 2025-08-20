using APIHomeWork.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text.Json;

namespace APIHomeWork.Services
{
    public class NewsApiService
    {
        private readonly HttpClient _httpClient;    //used to make web requests to news API
        private readonly string _apiKey; //API key for authentication
        public NewsApiService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["NewsApi:ApiKey"]; //Retrieve API key from configuration
            //need to set header according to the error
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Travs News");     //needed to add this 
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);            //needed to add this too to actually render the data
        }

        //call API and return data (via controller
        public async Task<NewsResponse> GetNewsAsync(string? query = "Apple", string? fromDate = "2025-07-20", string? sortBy = "popularity")      //essentially our query          //default values
        {
            // Construct the API URL with query parameters
            //https://newsapi.org/v2/everything?q=Apple&from=2025-08-20&sortBy=popularity&apiKey=API_KEY        //default

            var url = $"https://newsapi.org/v2/everything?q={query}&from={fromDate}&sortBy={sortBy}&apiKey={_apiKey}";      //now working     
            


            //var url = $"https://newsapi.org/v2/everything?q=bitcoin&apiKey={_apiKey}";          //also not working 
            // Make the HTTP GET request
            var response = await _httpClient.GetAsync(url);

            //check for errors
            var content = await response.Content.ReadAsStringAsync();       //added

            // Ensure the request was successful
            //response.EnsureSuccessStatusCode();     //error here
            if (!response.IsSuccessStatusCode)
            {
                // Optionally log or inspect the content
                throw new Exception($"News API request failed: {response.StatusCode} - {content}");
            }
            //chatGPT says i needa parse options
            
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true //to handle case insensitivity in JSON properties
            };
            
            return JsonSerializer.Deserialize<NewsResponse>(content, options);
        }
    }
}
