using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SistemaFinanceiroAPI.Models;
using SistemaFinanceiroAPI.Repositories;
using SistemaFinanceiroAPI.Repositories.Interfaces;
using System.Net;

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
           try
            {
                List<ItemModel> items = await _itemRepository.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
        
        [HttpGet("{date}")]
        public async Task<ActionResult<List<ItemModel>>> GetByDate([BindRequired] DateTime date)
        {
            try
            {
                ItemModel items = await _itemRepository.GetByDate(date);
                if (items == null)
                {
                    return NotFound("A data informada não existe.");
                }
                else
                {
                    return Ok(items);
                }
            }
            catch (Exception ex) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ItemModel>> addItem([FromBody] ItemModel itemModel, ICategoryRepository categoryRepository)
        {
            try
            {
                Task<CategoryModel> task = categoryRepository.GetById(itemModel.CategoryId);
                CategoryModel categoriesGet = await task;
                if (categoriesGet == null)
                {
                    return NotFound("A categoria informada não existe.");
                }
                else
                {
                    ItemModel items = await _itemRepository.AddItem(itemModel);
                    return Ok("Item adicionado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ItemModel>> UpdateItem([FromBody] ItemModel itemModel, [BindRequired] Guid id)
        {
           try
            {
                itemModel.Id = id;
                ItemModel item = await _itemRepository.UpdateItem(itemModel, id);
                return Ok("Item atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }

        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemModel>> DeleteItem([BindRequired] Guid id)
        {
            try
            {
                bool deletedItem = await _itemRepository.DeleteItem(id);
                return Ok("Item deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }

        }

    }
}
