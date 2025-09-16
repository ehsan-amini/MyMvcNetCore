using EShop.Web.Areas.Admin;
using Microsoft.AspNetCore.Mvc;
using MyMvcNetCore.Web.Models;
using System.Diagnostics;

namespace MyMvcNetCore.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
public class DashboardController : BaseController
{
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
