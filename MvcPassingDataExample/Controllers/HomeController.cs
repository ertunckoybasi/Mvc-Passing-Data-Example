using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcPassingDataExample.Models;
using MvcPassingDataExample.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPassingDataExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService _dataservice;

        public HomeController(ILogger<HomeController> logger, IDataService dataservice)
        {
            _logger = logger;
            _dataservice = dataservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewBagExample()
        {
            ViewBag.Header = "ViewBag Example";
            ViewBag.ProductList = _dataservice.GetProducts();
            return View();
        }

        public IActionResult ViewDataExample()
        {
            ViewData["Header"] = "ViewData Example";
            ViewData["ProductList"] = _dataservice.GetProducts();
            return View();
        }

        public IActionResult TempDataExample()
        {
            TempData["Header"] = "TempData Header";
            TempData["ProductList"] = _dataservice.GetProducts();
            return View();
        }

        public IActionResult TupleExample()
        {
            var products = _dataservice.GetProducts();
            var employees = _dataservice.GetEmployees();
            var tuple = new Tuple<IEnumerable<Product>, IEnumerable<Employee>>(products, employees);
            ViewData["FirstDataHeader"] = "Product List";
            ViewData["SecondDataHeader"] = "Employee List";

            return View(tuple);
        }

        public IActionResult ModelDirectiveExample()
        {
            return View(_dataservice.GetProducts());

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
