using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Helpers.Models;
using MyStore.Services;
using System.Linq;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: buisiness rules
            if (categoryService.IsDuplicated(model.CategoryName))
            {
                ModelState.AddModelError(nameof(model.CategoryName), $"Category {model.CategoryName} already exists");
                return Conflict(ModelState);
            }
            var categoryToSave = new Category();
            categoryToSave = model.ToCategory();

            categoryService.InsertNew(categoryToSave);

            //return Ok(categoryToAdd);
            return CreatedAtAction(nameof(GetById), new { id = categoryToSave.Categoryid }, categoryToSave.ToCategoryModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            categoryService.Remove(category);

            return NoContent();
        }

        [HttpGet]
        public IEnumerable<CategoryModel> Get(string? text, int pag = 1)
        {
            // implementam paginarea unor rezultate
            // var pageSize = 2;
            // le iau pe toate

            var allCategories = categoryService.GetCategories(pag, text);

            // filtrez si iau doar cele de afisat pe pagina curenta
            // var currentPageItems = allCategories.Skip(pageSize * (pag - 1)).Take(pageSize).ToList();

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
            var categoryFromDb = categoryService.GetCategory(id);
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
            var existingCategory = categoryService.GetCategory(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCategory);

            var categoryToUpdate = model.ToCategory();
            categoryService.Update(categoryToUpdate);

            return Ok(categoryToUpdate.ToCategoryModel());
        }
    }
}
