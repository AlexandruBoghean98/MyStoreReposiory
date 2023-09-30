using MyStore.Domain;
using System;
using System.Linq;

namespace MyStore.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext storeContext;

        public CategoryRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Category Add(Category category)
        {
            var addedEntity = storeContext.Categories.Add(category).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Category category)
        {
            storeContext.Categories.Remove(category);
            return storeContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return storeContext.Categories.ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return storeContext.Categories.Find(id);
        }

        public Category Update(Category category)
        {
            var updatedCategory = storeContext.Categories.Update(category).Entity;
            storeContext.SaveChanges();
            return updatedCategory;
        }
    }
}
