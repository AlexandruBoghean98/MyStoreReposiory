using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain;
using MyStore.Helpers;
using System.Linq;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly StoreContext context;
        public CategoriesController(StoreContext context)
        {
            this.context = context;
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

            //foreach (var category in description2)
            //{
            //    Console.WriteLine($"Id: {category.Id}, Description: {category.Descr}");
            //}


            return allCategories;
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(Category categoryToAdd)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Categories.Add(categoryToAdd);
            context.SaveChanges();

            //return Ok(categoryToAdd);
            return CreatedAtAction(nameof(GetById), new {id = categoryToAdd.Categoryid}, categoryToAdd);
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
