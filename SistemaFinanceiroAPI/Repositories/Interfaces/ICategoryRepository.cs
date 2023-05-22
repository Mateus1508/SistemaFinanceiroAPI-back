using SistemaFinanceiroAPI.Models;

namespace SistemaFinanceiroAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetAll();

        Task<CategoryModel> GetById(int id);

        Task<CategoryModel> AddCategory(CategoryModel category);

        Task<CategoryModel> UpdateCategory(CategoryModel category, int id);

        Task<bool> DeleteCategory(int id);
    }
}
