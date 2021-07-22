
  using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Weather.bll;
using WeatherMVC.Models;

namespace WeatherMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FileManager fileManager;
        private RequestManager requestManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            fileManager = new FileManager();
            requestManager = new RequestManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new WeatherModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(WeatherModel model)
        {
           if(ModelState.IsValid)
            {
                var data = fileManager.ReadDataJSON(model.CityName);
                if (data == null)
                {
                    data = await requestManager.GetDataFromApi(model.CityName);
                    if (data != null)
                    {
                        fileManager.SaveDataJSON(model.CityName, data);
                    }
                }
                model.WeatherData = data;
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
