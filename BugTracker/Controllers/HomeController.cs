using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using BugTracker.Data;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {
        public MongoDBRepository mongoDB;
        public HomeController(IOptions<Settings> settings)
        {
           mongoDB = new MongoDBRepository(settings);
        }

        public IActionResult Index()
        {
            return Json(mongoDB.DataBase.Client.Cluster.Description);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
