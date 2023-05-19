using SistemaFinanceiroAPI.Models;

namespace SistemaFinanceiroAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetAll();

        Task<CategoryModel> GetById(Guid id);

        Task<CategoryModel> AddCategory(CategoryModel category);

        Task<CategoryModel> UpdateCategory(CategoryModel category, Guid id);

        Task<bool> DeleteCategory(Guid id);
    }
}
