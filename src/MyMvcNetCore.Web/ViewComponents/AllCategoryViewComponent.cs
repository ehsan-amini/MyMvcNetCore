using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;
using MyMvcNetCore.Services.EFContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcNetCore.Web.ViewComponents
{
    public class AllCategoryViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _uow;
        private readonly ICategoryService _categoryService;
        public AllCategoryViewComponent(ICategoryService categoryService, IUnitOfWork uow)
        {
           _categoryService = categoryService;
            _uow = uow;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.AllMainCategoriesAsync();
            return View(categories);
        }
     
    }
}