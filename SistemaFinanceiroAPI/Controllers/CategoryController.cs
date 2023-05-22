using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiroAPI.Models;
using SistemaFinanceiroAPI.Repositories;
using SistemaFinanceiroAPI.Repositories.Interfaces;

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
            List<CategoryModel> category = await _categoryRepository.GetAll();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CategoryModel>>> GetByDate(int id)
        {
            CategoryModel category = await _categoryRepository.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> AddCategory([FromBody] CategoryModel categoryModel)
        {
            CategoryModel category = await _categoryRepository.AddCategory(categoryModel);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateItem([FromBody] CategoryModel categoryModel, int id)
        {
            categoryModel.Id = id;
            CategoryModel item = await _categoryRepository.UpdateCategory(categoryModel, id);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> DeleteCategory(int id)
        {
            bool deletedCategory = await _categoryRepository.DeleteCategory(id);
            return Ok(deletedCategory);
        }
    }
}
