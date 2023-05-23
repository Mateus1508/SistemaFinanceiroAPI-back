using SistemaFinanceiroAPI.Models;

namespace SistemaFinanceiroAPI.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<List<ItemModel>> GetAll();

        Task<ItemModel> GetById(Guid id);

        Task<ItemModel> GetByDate(DateOnly date);

        Task<ItemModel> AddItem(ItemModel item);

        Task<ItemModel> UpdateItem(ItemModel item, Guid id);

        Task<bool> DeleteItem(Guid id);
    }
}
