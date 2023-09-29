using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly StoreContext context;
        private readonly ICategoryRepository repository;

        public CategoriesController(StoreContext context, ICategoryRepository repository)
        {
            this.context = context;
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var text = "ala bala porto cala";
            var noOfWords = text.CountWords();

            var allCategories = context.Categories.ToList();

            var description = allCategories
                .Where(category => category.Description.Contains("eer"))
                .Select(category => category);


            //var description2 = allCategories.Select(x =>
            //new
            //{
            //    Descr = x.Description,
            //    Id = x.Categoryid
            //});

            //foreach (var categoryFromDb in description2)
            //{
            //    Console.WriteLine($"Id: {categoryFromDb.Id}, Description: {categoryFromDb.Descr}");
            //}


            return allCategories;
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

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryToSave = new Category();
            categoryToSave = model.ToCategory();

            context.Add(categoryToSave);
            context.SaveChanges();

            //return Ok(categoryToAdd);
            return CreatedAtAction(nameof(GetById), new { id = categoryToSave.Categoryid }, categoryToSave.ToCategoryModel());
        }

        [HttpPut("{id}")]
        public ActionResult<Category> Update(int id, Category category)
        {
            var existingCategory = context.Categories.Find(id);
            if(existingCategory == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCategory);
            context.Categories.Update(category);
            context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            return NoContent();
        }
    }
}
