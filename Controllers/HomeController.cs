using RestSharp;
using System.Text.Json.Nodes;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CompanyManagerC.Models;
using CompanyManagerC.Api_Calls;
using System.Net;

namespace CompanyManagerC.Controllers
{
    public class HomeController : Controller
    {
        public Worker<LoginModel> test = new Worker<LoginModel>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel data)
        {
            var result = test.Authenticate(data, "api/base").Result;

            if( result != HttpStatusCode.OK)
                return Unauthorized();

            return RedirectToAction(nameof(Index));
        }
    }
}