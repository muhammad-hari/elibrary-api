using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moonlay.ELibrary.WebClient.Models;
using Moonlay.ELibrary.WebClient.Models.Request;
using Newtonsoft.Json;
using RestSharp;

namespace Moonlay.ELibrary.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] RentBookRequest rent)
        {
            try
            {
                var client = new RestClient(@"http://localhost:63524/");
                var request = new RestRequest(@"api/v1/Payment", Method.POST, DataFormat.Json).AddJsonBody(JsonConvert.SerializeObject(rent));
                var response = client.Post(request);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occured when request to API: {ex.Message}");
            }

            return View();
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
