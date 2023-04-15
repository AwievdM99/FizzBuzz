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
            //Login behind how FizzBuzz is determined.
            List<string> fizzBuzzCalculationList = new List<string>();
            for (int i = 1; i <= 100; i++)
            {
                //3 and 5 are checked first to prevent a false trigger from either 3 or 5 which would give a false value.
                if (i % 3 == 0 && i % 5 == 0)
                {
                    fizzBuzzCalculationList.Add("FizzBuzz");
                }
                //The order in which 3 and 5 are checked does not matter because 3 is not a multiple of 5 and vice versa. 
                else if (i % 3 == 0)
                {
                    fizzBuzzCalculationList.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    fizzBuzzCalculationList.Add("Buzz " + i);
                }
                //If nothing is triggered, then the number is added to the list instead.
                else
                {
                    fizzBuzzCalculationList.Add(i.ToString());
                }
            }
            //Viewdata is used to pass the list to the index file.
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