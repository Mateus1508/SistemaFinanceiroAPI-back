using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SistemaFinanceiroAPI.Models;
using SistemaFinanceiroAPI.Repositories;
using SistemaFinanceiroAPI.Repositories.Interfaces;
using System.Net;

namespace SistemaFinanceiroAPI.Controllers
{
    [Route("api/sistema-financeiro/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAll()
        {
           try
            {
                List<CategoryModel> category = await _categoryRepository.GetAll();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CategoryModel>>> GetByDate([BindRequired] int id)
        {
            try
            {
                CategoryModel category = await _categoryRepository.GetById(id);
                if (category == null)
                {
                    return NotFound("Categoria não encontrada.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> AddCategory([BindRequired] [FromBody] CategoryModel categoryModel)
        {
           try
            {
                CategoryModel category = await _categoryRepository.AddCategory(categoryModel);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateItem([FromBody] CategoryModel categoryModel, int id)
        {
            try
            {
                categoryModel.Id = id;
                CategoryModel item = await _categoryRepository.UpdateCategory(categoryModel, id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> DeleteCategory([BindRequired] int id)
        {
            try
            {
                bool deletedCategory = await _categoryRepository.DeleteCategory(id);
                return Ok(deletedCategory);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Houve um erro ao tratar sua solicitação.");
            }
        }
    }
}
