
using MyMvcNetCore.Entities;
using MyMvcNetCore.ViewModels.Categories;

namespace MyMvcNetCore.Services.EFContracts;

public interface ICategoryService
{
    Task<List<ShowCategory>> AllMainCategoriesAsync();

    Task<List<ShowCategory>> AllMainCategoriesAsync(int currentCategoryId);

    Task<List<ShowCategory>> GetCategoryChildrenAsync(int mainCatId);

    Task<List<CategoryAllFields>> GetAllFieldsAsync();

    Category GetToDelete(int id);
    Task<List<RootCategoryWithProductsViewModel>> GetRootCategoryWithProductsVAsync();
}
