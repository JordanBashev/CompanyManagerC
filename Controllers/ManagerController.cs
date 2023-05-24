using CompanyManagerC.Api_Calls;
using CompanyManagerC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CompanyManagerC.Controllers
{
    public class ManagerController : Controller
    {
        public Worker<Manager> test = new Worker<Manager>();
        private string endpointData = "manager";
        [HttpGet]
        public IActionResult getAll()
        {
            var result = test.GetAll($"api/{endpointData}/GetAll").Result;

            TableView<Manager> tableView = Paginate(result, 1);

            if (result == null)
                return Problem("Contact The Support Team");

            return View(tableView);
        }

        [HttpPost]
        public IActionResult getAll(int currentPageIndex, string searchCriteria)
        {
            Console.WriteLine(currentPageIndex + "Data");

            var result = test.GetAll($"api/{endpointData}/GetAll").Result;

            TableView<Manager> tableView = Paginate(result, currentPageIndex);


            if (!string.IsNullOrEmpty(searchCriteria))
            {
                tableView.itemList = tableView.itemList.Where(x => x.name.Contains(searchCriteria)).ToList();
            }

            if (result == null)
                return Problem("Contact The Support Team");

            return View(tableView);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Manager manager)
        {
            var result = test.Post(manager, $"api/{endpointData}/Post");

            return RedirectToAction(nameof(getAll));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = test.Get(id, $"api/{endpointData}/Get").Result;

            Manager? data = JsonConvert.DeserializeObject<Manager>(result);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Manager manager)
        {
            Console.WriteLine(manager.name);

            var result = test.Post(manager, $"api/{endpointData}/Post");
            Thread.Sleep(1000);

            return RedirectToAction(nameof(getAll));
        }

        private TableView<Manager> Paginate(string result, int currentPageIndex)
        {
            TableView<Manager> tableView = new TableView<Manager>()
            {
                itemList = JsonConvert.DeserializeObject<List<Manager>>(result),
            };

            TableView<Manager> tableResult = new TableView<Manager>();

            tableResult.itemList = tableView.itemList
                    .OrderBy(x => x.name)
                    .Skip((currentPageIndex - 1) * 10)
                    .Take(10).ToList();

            double pageCount = (double)((decimal)tableView.itemList.Count() / Convert.ToDecimal(10));
            tableResult.PageCount = (int)Math.Ceiling(pageCount);

            tableResult.CurrentPageIndex = currentPageIndex;

            return tableResult;
        }
    }
}
