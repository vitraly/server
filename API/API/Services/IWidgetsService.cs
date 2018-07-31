using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IWidgetsService
    {
        Task<List<NewsModel>> GetNews();

        Task<WeatherModel> GetWeather();

        Task<MessageModel> GetMessage();
    }
}
