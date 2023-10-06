using MyStore.Domain;

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

        public IQueryable<Category> GetAll()
        {
            return storeContext.Categories;
        }

        public IEnumerable<Category> GetAll(int page)
        {
            var pageSize = 2;
            var categories =
                 storeContext
                .Categories
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            return categories;
        }

        public IQueryable<Category> GetAll(int page, string? text)
        {
            var pageSize = 2;
            var categories = storeContext.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(text))
            {
                categories = categories.Where(c => c.Description.Contains(text));

                //categories = categories.Where(c =>
                //     c.Description.Contains(text) || c.Categoryname.Contains(text));
            }

            categories = categories.Skip(pageSize * (page - 1))
                .Take(pageSize);

            return categories;
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
