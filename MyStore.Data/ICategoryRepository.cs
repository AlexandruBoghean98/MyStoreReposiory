﻿using MyStore.Domain;

namespace MyStore.Data
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        int Delete(Category category);
        IQueryable<Category> GetAll();
        IEnumerable<Category> GetAll(int page);
        IQueryable<Category> GetAll(int page, string? text);
        Category? GetCategoryById(int id);
        Category Update(Category category);
    }
}