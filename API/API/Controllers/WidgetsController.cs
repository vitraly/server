using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/widgets")]
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
    }
}
