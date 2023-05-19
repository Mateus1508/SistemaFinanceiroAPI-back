using Microsoft.EntityFrameworkCore;
using SistemaFinanceiroAPI.Data;
using SistemaFinanceiroAPI.Models;
using SistemaFinanceiroAPI.Repositories.Interfaces;

namespace SistemaFinanceiroAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SistemaFinanceiroDBContext _dbContext;

        public CategoryRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext)
        {
            _dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<CategoryModel> AddCategory(CategoryModel category)
        {
            await _dbContext.Category.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<CategoryModel> GetById(Guid id)
        {
            return await _dbContext.Category.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CategoryModel> UpdateCategory(CategoryModel category, Guid id)
        {
            CategoryModel categoryById = await GetById(id);

            if (categoryById == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            categoryById.Title = category.Title;
            categoryById.Color = category.Color;
            categoryById.Expense = category.Expense;

            _dbContext.Category.Update(categoryById);
            await _dbContext.SaveChangesAsync();

            return categoryById;
        }
        
        public async Task<bool> DeleteCategory(Guid id)
        {
            CategoryModel categoryById = await GetById(id);

            if (categoryById == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            _dbContext.Category.Remove(categoryById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
