using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moonlay.ELibrary.WebClient.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Moonlay.ELibrary.WebClient.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] Customer customer)
        {
            try
            {
                var client = new RestClient(@"http://localhost:63524/");
                var request = new RestRequest(@"api/v1/Customers", Method.POST, DataFormat.Json).AddJsonBody(JsonConvert.SerializeObject(customer));
                var response = client.Post(request);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occured when request to API: {ex.Message}");
            }

            return View();
        }




    }
}
