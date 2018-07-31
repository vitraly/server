﻿using API.Models;
using Hassie.NET.API.NewsAPI.API.v2;
using Hassie.NET.API.NewsAPI.Client;
using Hassie.NET.API.NewsAPI.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using OpenWeatherMap;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Services
{
    public class WidgetsService : IWidgetsService
    {
        private readonly IOptionsSnapshot<ExternalApisOptions> options;
        private readonly IHttpClientFactory httpClient;

        public WidgetsService(IOptionsSnapshot<ExternalApisOptions> options, IHttpClientFactory httpClient)
        {
            this.options = options;
            this.httpClient = httpClient;
        }

        public async Task<List<NewsModel>> GetNews()
        {
            string apiKey = options.Value.NewsApiKey;
            INewsClient newsClient = new ClientBuilder() { ApiKey = apiKey }.Build();
            INewsArticles newsArticles = await newsClient.GetTopHeadlines(new TopHeadlinesBuilder().WithSourcesQuery(Source.BBC_NEWS).Build());
            List<NewsModel> newsList = new List<NewsModel>();
            for (int i = 0; i < 3; i++)
            {
                var news = new NewsModel()
                {
                    Id = i + 1,
                    NewsTitle = newsArticles[i].Title,
                    NewsDescription = newsArticles[i].Description
                };
                newsList.Add(news);
            }
            return newsList;
        }

        public async Task<WeatherModel> GetWeather()
        {
            string apiKey = options.Value.WeatherApiKey;
            var weatherClinet = new OpenWeatherMapClient(apiKey);
            Coordinates coordinates = new Coordinates();
            coordinates.Latitude = CoordinatesModel.Latitude;
            coordinates.Longitude = CoordinatesModel.Longitude;
            var currentWeather = await weatherClinet.CurrentWeather.GetByCoordinates(coordinates);
            WeatherModel weather = new WeatherModel
            {
                Weather = currentWeather.Weather.Value,
                Temperature = currentWeather.Temperature.Value - 273.15,
                LastUpdate = currentWeather.LastUpdate.Value
            };
            return weather;
        }

        public async Task<MessageModel> GetMessage()
        {
            var client = httpClient.CreateClient();
            string requestUrl = options.Value.TimezoneApiUrl;
            string lat = CoordinatesModel.Latitude.ToString();
            string lng = CoordinatesModel.Longitude.ToString();
            HttpResponseMessage response = await client.GetAsync(requestUrl + "&lat=" + lat + "&lng=" + lng);

            string timezone = null;
            if (response.IsSuccessStatusCode)
            {
                timezone = await response.Content.ReadAsStringAsync();
            }

            JObject responseJson = JObject.Parse(timezone);
            int gmtOffset = responseJson["gmtOffset"].Value<int>();
            DateTimeOffset currentTime = new DateTimeOffset(DateTime.UtcNow.AddSeconds(gmtOffset));

            MessageModel result = new MessageModel();
            if (currentTime.Hour > 6 && currentTime.Hour < 12)
            {
                result.Message = "Good Morning";
            }
            else if (currentTime.Hour > 12 && currentTime.Hour < 18)
            {
                result.Message = "Time for lunch";
            }
            else if (currentTime.Hour > 18)
            {
                result.Message = "Good evening";
            }
            else
            {
                result.Message = "Time to sleep";
            }

            return result;
        }
    }
}
