using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProgramaRafaAnass.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace ProgramaRafaAnass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "3d7da4c793msh13e60ea3130926ap1fb16cjsnd51dabd3c916");
            _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "genius-song-lyrics1.p.rapidapi.com");
        }

        public async Task<IActionResult> Index()
        {
            ProgramaRafaAnass.Models.API1.Root chartData = null;

            try
            {
                var requestUri = new Uri("https://genius-song-lyrics1.p.rapidapi.com/chart/albums/?per_page=10&page=1");
                var response = await _client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                chartData = JsonConvert.DeserializeObject<ProgramaRafaAnass.Models.API1.Root>(responseBody);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "An error occurred while fetching data from the API.");
            }
            catch (JsonSerializationException e)
            {
                _logger.LogError(e, "An error occurred while deserializing the JSON response.");
            }

            return View(chartData);
        }

        public async Task<IActionResult> Privacy()
        {
            ProgramaRafaAnass.Models.API2.Root chartData1 = null;

            try
            {
                var requestUri = new Uri("https://genius-song-lyrics1.p.rapidapi.com/chart/artists/?per_page=10&page=1");
                var response = await _client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                chartData1 = JsonConvert.DeserializeObject<ProgramaRafaAnass.Models.API2.Root>(responseBody);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "An error occurred while fetching data from the API.");
            }
            catch (JsonSerializationException e)
            {
                _logger.LogError(e, "An error occurred while deserializing the JSON response.");
            }

            return View(chartData1);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
