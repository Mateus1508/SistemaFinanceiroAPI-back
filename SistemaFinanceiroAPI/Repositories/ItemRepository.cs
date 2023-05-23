using Microsoft.EntityFrameworkCore;
using SistemaFinanceiroAPI.Models;
using SistemaFinanceiroAPI.Repositories.Interfaces;

namespace SistemaFinanceiroAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly SistemaFinanceiroDBContext _dbContext;

        public ItemRepository(SistemaFinanceiroDBContext sistemaFinanceiroDBContext) 
        {
            _dbContext = sistemaFinanceiroDBContext;
        }

        public async Task<ItemModel> AddItem(ItemModel item)
        {
            await _dbContext.Item.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }


        public async Task<List<ItemModel>> GetAll()
        {
            return await _dbContext.Item.ToListAsync();
        }

        public async Task<ItemModel> GetByDate(DateOnly date)
        {
            return await _dbContext.Item.FirstOrDefaultAsync(x => x.Date == date);
        }
        
        public async Task<ItemModel> GetById(Guid id)
        {
            return await _dbContext.Item.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ItemModel> UpdateItem(ItemModel item, Guid id)
        {
            ItemModel itemById = await GetById(id);

            if(itemById == null)
            {
                throw new Exception("Item não encontrado!");
            }

            itemById.Title = item.Title;
            itemById.Value = item.Value;
            item.Categories = item.Categories;

            _dbContext.Item.Update(itemById);
            await _dbContext.SaveChangesAsync();

            return itemById;
        }
        
        public async Task<bool> DeleteItem(Guid id)
        {
            ItemModel itemById = await GetById(id);

            if (itemById == null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            _dbContext.Item.Remove(itemById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
