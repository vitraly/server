using API.Models;
using Hassie.NET.API.NewsAPI.API.v2;
using Hassie.NET.API.NewsAPI.Client;
using Hassie.NET.API.NewsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class WidgetsService : IWidgetsService
    {
        public async Task<List<NewsModel>> GetNews()
        {
            INewsClient newsClient = new ClientBuilder() { ApiKey = "211c5eff1c0447f399f3002328219836" }.Build();
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
    }
}
