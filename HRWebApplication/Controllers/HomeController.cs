using HRWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BOL;
using DAL;

namespace HRWebApplication.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Products()
        {
            List<Product> products=DBManager.getAllProducts();

            ViewBag.Products = products;

            return View();
        }

            public IActionResult Add() { 
            return View();
            }

        [HttpPost]
        public IActionResult Add(string id, string name,string qty, string category,string price)
        {
            Product newProd = new Product(int.Parse(id), name, int.Parse(qty), Enum.Parse<Category>(category), double.Parse(price));
            Console.WriteLine(newProd);
            DBManager.insertProduct(newProd);
            
            return RedirectToAction("Products");
        }

        public IActionResult Delete()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
           // Console.WriteLine(id);
            DBManager.deleteProduct(id);
            return RedirectToAction("Products");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}