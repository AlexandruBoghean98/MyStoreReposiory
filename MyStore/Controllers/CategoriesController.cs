using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Helpers.Models;
using System.Linq;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository repository;

        public CategoriesController(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryToSave = new Category();
            categoryToSave = model.ToCategory();

            repository.Add(categoryToSave);

            //return Ok(categoryToAdd);
            return CreatedAtAction(nameof(GetById), new { id = categoryToSave.Categoryid }, categoryToSave.ToCategoryModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = repository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            repository.Delete(category);

            return NoContent();
        }

        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            var allCategories = repository.GetAll();

            var modelsToReturn = new List<CategoryModel>();
            foreach (var category in allCategories)
            {
                modelsToReturn.Add(category.ToCategoryModel());
            }

            return modelsToReturn;
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryModel> GetById(int id)
        {
            var categoryFromDb = repository.GetCategoryById(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            var model = categoryFromDb.ToCategoryModel();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryModel> Update(int id, CategoryModel model)
        {
            var existingCategory = repository.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCategory);

            var categoryToUpdate = model.ToCategory();
            repository.Update(categoryToUpdate);

            return Ok(categoryToUpdate.ToCategoryModel());
        }
    }
}
