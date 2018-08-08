using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class WidgetsController : Controller
    {
        private readonly IWidgetsService widgetsService;

        public WidgetsController(IWidgetsService widgetsService)
        {
            this.widgetsService = widgetsService;
        }

        // GET: api/<controller>/news
        [HttpGet("news")]
        public async Task<IActionResult> Get()
        {
            List<NewsModel> newsList = await widgetsService.GetNews();
            return Ok(newsList);
        }

        // GET api/<controller>/weather
        [HttpGet("weather")]
        public async Task<IActionResult> GetWeather()
        {
            WeatherModel weather = await widgetsService.GetWeather();
            return Ok(weather);
        }

        // GET api/<controller>/message
        [HttpGet("message")]
        public async Task<IActionResult> GetMessage()
        {
            MessageModel message = await widgetsService.GetMessage();
            return Ok(message);
        }

        // GET api/<controller>/quote
        [HttpGet("quote")]
        public async Task<IActionResult> GetQuote()
        {
            QuoteModel quoteOfTheDay = await widgetsService.GetQuote();
            return Ok(quoteOfTheDay);
        }
    }
}
