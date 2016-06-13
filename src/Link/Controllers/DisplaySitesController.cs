using Link.Data;
using Link.Models.DisplaySitesViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Link.Controllers
{
    [Route("tulemused")]
    public class DisplaySitesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AddSitesController> _logger;
        private readonly IOptions<AppSettings> _optionsAccessor;

        public DisplaySitesController(ApplicationDbContext context, ILogger<AddSitesController> logger, IOptions<AppSettings> optionsAccessor)
        {
            _context = context;
            _logger = logger;
            _optionsAccessor = optionsAccessor;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["successMessage"] = TempData["successMessage"];
            string apiUrl = _optionsAccessor.Value.ZeldaApiSitesUrl;
            string apiRequestResult = "{}";
            using (HttpClient httpClient = new HttpClient())
            {
                apiRequestResult = await httpClient.GetStringAsync(apiUrl);
            }
            List<SiteInfoCombined> returnedData = JsonConvert.DeserializeObject<List<SiteInfoCombined>>(apiRequestResult);
            return View(new DisplaySitesViewModel(returnedData));
        }
    }
}