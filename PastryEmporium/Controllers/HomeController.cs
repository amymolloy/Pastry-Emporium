using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PastryEmporium.Models;

namespace PastryEmporium.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPastryRepository _pastryRepository;

        public HomeController(IPastryRepository pastryRepository)
        {
            _pastryRepository = pastryRepository;
        }

        // GET: Home
        public IActionResult Index()
        {
            return View(_pastryRepository.GetPastries());
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
