using MyStore.Domain;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        bool IsDuplicated(string categoryName);
        IEnumerable<Category> GetCategories(int page);
        IEnumerable<Category> GetCategories(int page, string? text);
        Category? GetCategory(int id);
        Category InsertNew(Category category);
        int Remove(Category category);
        Category Update(Category category);
    }
}