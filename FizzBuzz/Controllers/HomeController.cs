using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzz.Controllers
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
            List<string> fizzBuzzCalculationList = new List<string>();
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    fizzBuzzCalculationList.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    fizzBuzzCalculationList.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    fizzBuzzCalculationList.Add("Buzz " + i);
                }
                else
                {
                    fizzBuzzCalculationList.Add(i.ToString());
                }
            }
            ViewData["fizzBuzz"] = fizzBuzzCalculationList;
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