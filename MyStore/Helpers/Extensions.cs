using MyStore.Domain;
using MyStore.Helpers.Models;

namespace MyStore.Helpers
{
    public static class Extensions
    {
        public static int CountWords(this string paragraph)
        {
            var words = paragraph.Split(' ');
            return words.Length;
        }

        public static CategoryModel ToCategoryModel(this Category domainObject)
        {
            var model = new CategoryModel();

            model.Categoryid = domainObject.Categoryid;
            model.Description = domainObject.Description;
            model.Categoryname = domainObject.Categoryname;

            return model;
        }

        public static Category ToCategory(this CategoryModel model)
        {
            var category = new Category();

            category.Categoryid = model.Categoryid;
            category.Description = model.Description;
            category.Categoryname = model.Categoryname;

            return category;
        }
    }
}
