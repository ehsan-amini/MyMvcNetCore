
using EShop.Web.Areas.Admin;
using Microsoft.AspNetCore.Mvc;
using MyMvcNetCore.Commen;
using MyMvcNetCore.Commen.Constants;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;
using MyMvcNetCore.Services;
using MyMvcNetCore.Services.EFContracts;
using MyMvcNetCore.ViewModels.Categories;

namespace MyMvcNetCore.Web.Areas.Admin.Controllers;

[Area(AreaConstants.AdminArea)]
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    private readonly IUnitOfWork _uow;

    public CategoryController(ICategoryService categoryService, IUnitOfWork uow)
    {
        _categoryService = categoryService;
        _uow = uow;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.AllMainCategoriesAsync();
        return View(categories);
    }

    public async Task<IActionResult> Add()
    {
        var categories = await _categoryService.AllMainCategoriesAsync();
        ViewBag.MainCategories = categories.ToList().CreateSelectListItem(firstItemText: "to be the parent");
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(AddCategoryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _categoryService.AllMainCategoriesAsync();
            ViewBag.MainCategories = categories.ToList()
                .CreateSelectListItem(model.ParentId, firstItemText: "to be the parent");
            ModelState.AddModelError(string.Empty, PublicConstantStrings.ModelStateErrorMessage);
            return View(model);
        }
        await _uow.CategoryRepository  .AddAsync(new Category()
        {
            Title = model.Title,
            ParentId = model.ParentId == 0 ? null : model.ParentId
        });
        await _uow.SaveAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var categoryToDelete = _categoryService.GetToDelete(id);
        if (categoryToDelete != null)
        {
            _uow.CategoryRepository.Remove(id);
            await _uow.SaveAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var categories = await _categoryService.AllMainCategoriesAsync(id);
        var category = await _uow.CategoryRepository.FindByIdAsync(id);
        ViewBag.MainCategories = categories.ToList()
            .CreateSelectListItem(category.ParentId, firstItemText: "to be the parent");
        var editCatViewModel = new EditCategoryViewModel()
        {
            Id = category.Id,
            ParentId = category.ParentId,
            Title = category.Title
        };
        return View(editCatViewModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditCategoryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _categoryService.AllMainCategoriesAsync(model.Id);
            ViewBag.MainCategories = categories.ToList()
                .CreateSelectListItem(model.ParentId, firstItemText: "to be the parent");
            ModelState.AddModelError(string.Empty, PublicConstantStrings.ModelStateErrorMessage);
            return View(model);
        }

        if (model.Id == model.ParentId)
            return View("Error");
        _uow.CategoryRepository.Update(new Category
        {
            Id = model.Id,
            ParentId = model.ParentId == 0 ? null : model.ParentId,
            Title = model.Title
        });
        await _uow.SaveAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ShowCategoryChildren(int mainCatId)
    {
        var categories = await _categoryService.GetCategoryChildrenAsync(mainCatId);
        return View("_ShowCategoryeChildrenPartial", categories);
    }
}
