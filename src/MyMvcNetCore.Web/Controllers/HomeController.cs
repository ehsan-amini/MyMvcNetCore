using Microsoft.AspNetCore.Mvc;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Services.EFContracts;
using MyMvcNetCore.Web.Models;
using System.Diagnostics;

namespace MyMvcNetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _uow;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IUnitOfWork uow)
        {
            _logger = logger;
           _categoryService = categoryService;
            _uow = uow;
        }

        public async Task < IActionResult> Index()
        {
            var productsWithCategories = await _categoryService.GetRootCategoryWithProductsVAsync ();
            return View(productsWithCategories);
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
