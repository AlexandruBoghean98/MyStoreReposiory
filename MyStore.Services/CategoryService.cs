using MyStore.Data;
using MyStore.Domain;

namespace MyStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories(int page)
        {
            return categoryRepository.GetAll(page);
        }

        public IEnumerable<Category> GetCategories(int page, string? text)
        {
            return categoryRepository.GetAll(page, text);
        }


        public Category? GetCategory(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public Category InsertNew(Category category)
        {
            return categoryRepository.Add(category);
        }

        public bool IsDuplicated(string categoryName)
        {
            var categories = categoryRepository.GetAll();
            categories = categories.Where(c => c.Categoryname == categoryName);
            categories.Where(c => c.Description.Contains("er")).ToList();

            return categories.Any();
        }

        public int Remove(Category category)
        {
            return categoryRepository.Delete(category);
        }

        public Category Update(Category category)
        {
            return categoryRepository.Update(category);
        }

    }
}
