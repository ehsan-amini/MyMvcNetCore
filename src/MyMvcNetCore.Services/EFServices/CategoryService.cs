
using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;
using MyMvcNetCore.Services.EFContracts;
using MyMvcNetCore.ViewModels.Categories;

namespace MyMvcNetCore.Services.EFServices;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _uow;
    private readonly DbSet<Category> _categories;
    private readonly DbSet<Product> _products;

    public CategoryService(IUnitOfWork uow)
      
    {
        _uow = uow;
        _categories = uow.Set<Category>();
        _products = uow.Set<Product>();
    }

    public Task<List<ShowCategory>> AllMainCategoriesAsync()
        => _categories
            .Where(category => category.ParentId == null)
            .Select(category => new ShowCategory()
            {
                Id = category.Id,
                Title = category.Title,
                CanRemove = !category.Children.Any()
            }).ToListAsync();

    public Task<List<ShowCategory>> AllMainCategoriesAsync(int currentCategoryId)
        => _categories
            .Where(category => category.ParentId == null)
            .Where(category => category.Id != currentCategoryId)
            .Select(category => new ShowCategory()
            {
                Id = category.Id,
                Title = category.Title,
                CanRemove = category.Children.Any()
            }).ToListAsync();

    public Task<List<ShowCategory>> GetCategoryChildrenAsync(int mainCatId)
        => _categories
            .Where(category => category.ParentId == mainCatId)
            .Select(category => new ShowCategory()
            {
                Id = category.Id,
                Title = category.Title,
                CanRemove = !category.Products.Any()
            }).ToListAsync();

    public Task<List<CategoryAllFields>> GetAllFieldsAsync()
        => _categories.Select(x => new CategoryAllFields()
        {
            Children = x.Children.Select(c => new CategoryAllFields()
            {
                Id = c.Id,
                Title = c.Title
            }).ToList(),
            Id = x.Id,
            ParentId = x.ParentId,
            Title = x.Title
        }).ToListAsync();

    public Category GetToDelete(int id)
        => _categories.Where(x => !x.Products.Any())
            .SingleOrDefault(x => x.Id == id);



    //public async Task<List<RootCategoryWithProductsViewModel>> GetRootCategoryWithProductsVAsync()
    //{
    //    // دریافت تمام دسته‌بندی‌های ریشه (ParentId == null)
    //    var rootCategories = await _categories
    //        .Where(c => c.ParentId == null)
    //        .ToListAsync();

    //    var viewModel = new List<RootCategoryWithProductsViewModel>();

    //    foreach (var rootCat in rootCategories)
    //    {
    //        // پیدا کردن تمام ID‌های دسته‌بندی‌های فرزند زیر هر ریشه
    //        var childCategoryIds = await _categories
    //            .Where(c => c.ParentId == rootCat.Id)
    //            .Select(c => c.Id)
    //            .ToListAsync();

    //        // دریافت تمام محصولات مربوط به IDهای زیردسته
    //        var products = await _products
    //            .Where(p => childCategoryIds.Contains(p.CategoryId))
    //            .ToListAsync();

    //        viewModel.Add(new RootCategoryWithProductsViewModel
    //        {
    //            CategoryId = rootCat.Id,
    //            Title = rootCat.Title,
    //            Products = products
    //        });
    //    }
    //    return viewModel;
    //}


    public async Task<List<RootCategoryWithProductsViewModel>> GetRootCategoryWithProductsVAsync()
    {
        // دریافت تمام دسته‌بندی‌های ریشه (ParentId == null)
        var rootCategories = await _categories
            .Where(c => c.ParentId == null)
            .ToListAsync();

        var viewModel = new List<RootCategoryWithProductsViewModel>();

        foreach (var rootCat in rootCategories)
        {
            // پیدا کردن تمام ID‌های دسته‌بندی‌های فرزند زیر هر ریشه
            var childCategoryIds = await _categories
                .Where(c => c.ParentId == rootCat.Id)
                .Select(c => c.Id)
                .ToListAsync();

            // دریافت تمام محصولات مربوط به IDهای زیردسته به همراه تصاویرشان
            var products = await _products
                .Where(p => childCategoryIds.Contains(p.CategoryId))
                .Include(p => p.ProductImages) // بارگذاری تصاویر
                .ToListAsync();

            viewModel.Add(new RootCategoryWithProductsViewModel
            {
                CategoryId = rootCat.Id,
                Title = rootCat.Title,
                Products = products
            });
        }
        return viewModel;
    }


}
