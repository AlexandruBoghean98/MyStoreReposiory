using MyStore.Domain;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(int page);
        IEnumerable<Category> GetCategories(int page, string? text);
        Category? GetCategory(int id);
        Category InsertNew(Category category);
        bool IsDuplicated(string categoryName);
        int Remove(Category category);
        Category Update(Category category);

    }
}