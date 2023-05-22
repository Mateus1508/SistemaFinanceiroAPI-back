using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiroAPI.Models;
using SistemaFinanceiroAPI.Repositories.Interfaces;

namespace SistemaFinanceiroAPI.Controllers
{
    [Route("api/sistema-financeiro/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemModel>>> GetAll()
        {
            List<ItemModel> items = await _itemRepository.GetAll();
            return Ok(items);
        }
        
        [HttpGet("{date}")]
        public async Task<ActionResult<List<ItemModel>>> GetByDate(DateTime date)
        {
            ItemModel items = await _itemRepository.GetByDate(date);
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> addItem([FromBody] ItemModel itemModel)
        {
            ItemModel items = await _itemRepository.AddItem(itemModel);
            return Ok(items);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemModel>> UpdateItem([FromBody] ItemModel itemModel, Guid id)
        {
            itemModel.Id = id;
            ItemModel item = await _itemRepository.UpdateItem(itemModel, id);
            return Ok(item);

        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemModel>> DeleteItem( Guid id)
        {
            bool deletedItem = await _itemRepository.DeleteItem(id);
            return Ok(deletedItem);

        }

    }
}
