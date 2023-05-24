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
        public Test test = new Test();
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
            var result = test.GetProductAsync("api/base/GetAll").Result;
            if (result == null)
                return Problem("Contact The Support Team");

            ViewData["data"] = result;

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var result = test.Authenticate(username, password, "api/base").Result;

            if( result != HttpStatusCode.OK)
                return Unauthorized();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateManager() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateManager(Manager manager)
        {
            var result = test.createManager(manager, "api/base/Post");

            Console.WriteLine(result.Result);

            return RedirectToAction(nameof(Index));
        }
    }
}