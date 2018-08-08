using API.Models;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IWidgetsService
    {
        Task<NewsModel> GetNews();

        Task<WeatherModel> GetWeather();

        Task<MessageModel> GetMessage();

        Task<QuoteModel> GetQuote();
    }
}
