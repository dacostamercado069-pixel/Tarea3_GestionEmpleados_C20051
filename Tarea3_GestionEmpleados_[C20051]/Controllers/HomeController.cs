using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tarea3_GestionEmpleados__C20051_.Models;

namespace Tarea3_GestionEmpleados__C20051_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
